import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArenalistComponent } from './arenalist.component';

describe('ArenalistComponent', () => {
  let component: ArenalistComponent;
  let fixture: ComponentFixture<ArenalistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ArenalistComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ArenalistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
