import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { CreateTypeRendezVousCommand, TypeRendezVousDto } from '../types/typerendezvous';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class TypeRendezVousService {
    constructor(private readonly http: HttpClient) {}
    AddTypeRendezVous(data: CreateTypeRendezVousCommand): Observable<TypeRendezVousDto> {
        return this.http.post<TypeRendezVousDto>(`${environment.apiUrl}/TypeEntite/CreateTypeRendezVous`, data);
    }
}
