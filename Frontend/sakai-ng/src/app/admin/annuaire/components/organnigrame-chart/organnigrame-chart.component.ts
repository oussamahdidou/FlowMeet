import { AfterViewInit, Component, Input, OnChanges, OnInit } from '@angular/core';
import { OrganizationChartModule } from 'primeng/organizationchart';
import { TreeNode } from 'primeng/api';
import { entiteHiearchieDto } from '../../../types/entite';
@Component({
    selector: 'app-organnigrame-chart',
    imports: [OrganizationChartModule],
    templateUrl: './organnigrame-chart.component.html',
    styleUrl: './organnigrame-chart.component.scss'
})
export class OrgannigrameChartComponent implements OnChanges, OnInit {
    ngOnInit(): void {
        if (this.entitesHiearchie) {
            this.data = [this.mapToTreeNode(this.entitesHiearchie)];
            console.log(this.data);
        }
    }
    @Input() entitesHiearchie!: entiteHiearchieDto;
    selectedNodes!: TreeNode[];

    data: TreeNode[] = [];
    ngOnChanges(): void {
        if (this.entitesHiearchie) {
            this.data = [this.mapToTreeNode(this.entitesHiearchie)];
            console.log(this.data);
        }
    }
    mapToTreeNode(entite: entiteHiearchieDto): TreeNode {
        return {
            key: entite.id,
            label: entite.label,
            type: 'person',

            expanded: true,
            data: {
                label: entite.label,
                type: entite.type,
                image: '/assets/img/gov.png'
            },
            children: entite.enfants?.map((e) => this.mapToTreeNode(e)) || []
        };
    }
}
