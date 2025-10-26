import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { entiteHiearchieDto } from '../types/entite';

@Injectable({
    providedIn: 'root'
})
export class AdminEntiteService {
    constructor(private readonly http: HttpClient) {}
    public getRootEntitesHiearchie(): Observable<entiteHiearchieDto> {
        return this.http.get<entiteHiearchieDto>(`${environment.apiUrl}/api/Entite/GetRootEntiteHiearchie`);
    }
}
