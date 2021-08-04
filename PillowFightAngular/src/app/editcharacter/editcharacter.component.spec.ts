import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditcharacterComponent } from './editcharacter.component';

describe('EditcharacterComponent', () => {
  let component: EditcharacterComponent;
  let fixture: ComponentFixture<EditcharacterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditcharacterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditcharacterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
