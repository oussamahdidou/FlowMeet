# FlowMeet

FlowMeet is an enterprise-grade, microservices-based platform designed for managing meetings with a modular and scalable architecture. It leverages modern technologies and follows best practices to ensure maintainability, security, and performance.
![FlowMeet Logo](Frontend/sakai-ng/src/assets/img/flowMeetLogo.png)

## Table of Contents

1. [Features](#features)

1. [Architecture](#architecture)

1. [Tech Stack](#tech-stack)

1. [Modules / Microservices](#modules--microservices)

1. [Getting Started](#getting-started)

1. [Contributing](#contributing)

## Features

1. **User Management & Roles:** Centralized authentication and authorization with dynamic roles and groups.

1. **Scheduling & Appointments:** Manage types of meetings, availability, absences, and planning.

1. **Notifications:** Event-driven notification system for real-time alerts.

1. **Modular Microservices:** Services communicate via REST APIs or event-driven mechanisms.

1. **Permissions Control:** Customizable permissions per service and per role/group.

## Architecture

1. FlowMeet is designed using a microservices architecture with event-driven patterns:

1. Each microservice handles a specific domain (e.g., Authentication, Annuaire, Notification, Scheduling).

1. Event-driven communication ensures decoupled, real-time updates between services.

1. API Gateway orchestrates requests and enforces authentication.

1. Database per service pattern for isolation and scalability.

## Tech Stack

### Backend

**1. .NET 8 RESTful APIs**
**2. C#**
**3. EF Core 8 for ORM**
**4. PostgreSQL**
**5. Kafka**

### Frontend

**1. Angular 18**
**2. Prime ng**

## Modules / Microservices

**1. Auth Service:** Manages users, roles, groups, and permissions.

**2. Annuaire Service:** Handles personnel records, availability.

**3. Notification Service:** Sends real-time notifications to users for events and updates.

**4. Rendezvous / Planning Service:** Manages meeting types, scheduling, and allocations.

## Getting Started

### Clone the repository

```bash
git clone https://github.com/oussamahdidou/flowmeet.git
cd flowmeet
```

Run services using Aspire:

```bash
cd Backend\Infrastructure\FlowMeet.AppHost
dotnet watch run 
```

### Contributing

1. Fork the repository and create a feature branch.

1. Use clear commit messages and follow the branch naming convention: username/feature-name.

1. Submit a pull request for review.
