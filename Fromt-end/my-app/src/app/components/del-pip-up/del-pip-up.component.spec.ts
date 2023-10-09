import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DelPipUpComponent } from './del-pip-up.component';

describe('DelPipUpComponent', () => {
  let component: DelPipUpComponent;
  let fixture: ComponentFixture<DelPipUpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DelPipUpComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DelPipUpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
