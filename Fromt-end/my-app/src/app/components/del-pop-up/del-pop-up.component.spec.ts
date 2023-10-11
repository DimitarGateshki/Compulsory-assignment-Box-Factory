import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DelPopUpComponent } from './del-pop-up.component';

describe('DelPipUpComponent', () => {
  let component: DelPopUpComponent;
  let fixture: ComponentFixture<DelPopUpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DelPopUpComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DelPopUpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
