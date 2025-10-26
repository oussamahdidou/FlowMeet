import { TestBed } from '@angular/core/testing';

import { TypeRendezVousService } from './type-rendez-vous.service';

describe('TypeRendezVousService', () => {
  let service: TypeRendezVousService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TypeRendezVousService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
