import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditPipUpComponent } from './edit-pip-up.component';

describe('EditPipUpComponent', () => {
  let component: EditPipUpComponent;
  let fixture: ComponentFixture<EditPipUpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditPipUpComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditPipUpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
