import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrganigrammeAnnuaireComponent } from './organigramme-annuaire.component';

describe('OrganigrammeAnnuaireComponent', () => {
  let component: OrganigrammeAnnuaireComponent;
  let fixture: ComponentFixture<OrganigrammeAnnuaireComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OrganigrammeAnnuaireComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OrganigrammeAnnuaireComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
