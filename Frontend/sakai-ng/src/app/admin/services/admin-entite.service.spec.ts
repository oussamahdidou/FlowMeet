import { TestBed } from '@angular/core/testing';

import { AdminEntiteService } from './admin-entite.service';

describe('AdminEntiteService', () => {
  let service: AdminEntiteService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AdminEntiteService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
