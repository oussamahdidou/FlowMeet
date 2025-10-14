var builder = DistributedApplication.CreateBuilder(args);
var postgres = builder.AddPostgres("postgresql", port: 5432)
    .WithPgAdmin()
    .WithVolume("flowmeet", "/var/lib/postgresql/data");

var kafka = builder.AddKafka("kafka")
    .WithEnvironment("KAFKA_AUTO_CREATE_TOPICS_ENABLE", "true")
    .WithKafkaUI()
    .WithDataVolume();
// Create dedicated databases for each service
var annuaireDb = postgres.AddDatabase("annuairedb", "annuaire_user");
var planningEngineDb = postgres.AddDatabase("planningenginedb", "planningengine_user");
var serviceRendezVousDb = postgres.AddDatabase("servicerendezvousdb", "servicerendezvous_user");
var serviceNotificationDb = postgres.AddDatabase("servicenotificationdb", "servicenotification_user");
var authServiceDb = postgres.AddDatabase("authservicedb", "authservice_user");
// Configure each service with its dedicated database
var annuaireApi = builder.AddProject<Projects.FlowMeet_Annuaire_API>("flowmeet-annuaire-api")
    .WithReference(annuaireDb, "Database")
    .WithReference(kafka, "MessageBroker")
    .WaitFor(annuaireDb)
    .WaitFor(kafka);
var serviceNotificationApi = builder.AddProject<Projects.FlowMeet_Notification_API>("flowmeet-notification-api")
    .WithReference(serviceNotificationDb, "Database")
    .WithReference(kafka, "MessageBroker")
    .WaitFor(serviceNotificationDb)
    .WaitFor(kafka);

var planningEngineApi = builder.AddProject<Projects.FlowMeet_PlanningEngine_API>("flowmeet-planningengine-api")
    .WithReference(planningEngineDb, "Database")
    .WithReference(kafka, "MessageBroker")
    .WaitFor(planningEngineDb)
    .WaitFor(kafka);
var serviceRendezVousApi = builder.AddProject<Projects.FlowMeet_ServiceRendezVous_API>("flowmeet-servicerendezvous-api")
    .WithReference(serviceRendezVousDb, "Database")
    .WithReference(kafka, "MessageBroker")
    .WaitFor(serviceRendezVousDb)
    .WaitFor(kafka);
var authService = builder.AddProject<Projects.FlowMeet_AuthService>("flowmeet-authservice")
    .WithReference(authServiceDb, "Database")
    .WithReference(kafka, "MessageBroker")
    .WaitFor(authServiceDb)
    .WaitFor(kafka);

///gateway
var gateway = builder.AddProject<Projects.Gateway>("gateway")
    .WithReference(annuaireApi)        // Will use service name as connection key
    .WithReference(planningEngineApi)
    .WithReference(serviceRendezVousApi)
    .WithReference(serviceNotificationApi)
    .WithReference(authService)
    .WaitFor(annuaireApi)
    .WaitFor(planningEngineApi)
    .WaitFor(serviceRendezVousApi)
    .WaitFor(serviceNotificationApi)
    .WaitFor(authService);
builder.Build().Run();
