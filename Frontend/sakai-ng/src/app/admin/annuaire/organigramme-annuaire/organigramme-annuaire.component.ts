import { Component, OnInit } from '@angular/core';
import { OrgannigrameChartComponent } from '../components/organnigrame-chart/organnigrame-chart.component';
import { ButtonModule } from 'primeng/button';
import { ToolbarModule } from 'primeng/toolbar';
import { AdminEntiteService } from '../../services/admin-entite.service';
import { entiteHiearchieDto } from '../../types/entite';

@Component({
    selector: 'app-organigramme-annuaire',
    templateUrl: './organigramme-annuaire.component.html',
    styleUrl: './organigramme-annuaire.component.scss',
    imports: [OrgannigrameChartComponent, ButtonModule, ToolbarModule],
    providers: [AdminEntiteService],
    standalone: true
})
export class OrganigrammeAnnuaireComponent implements OnInit {
    entitesHiearchie!: entiteHiearchieDto;
    constructor(private readonly adminEntite: AdminEntiteService) {}
    ngOnInit(): void {
        this.loadEntiteHiearchie();
    }
    private loadEntiteHiearchie(): void {
        this.adminEntite.getRootEntitesHiearchie().subscribe((response) => {
            this.entitesHiearchie = response;
        });
    }
}
