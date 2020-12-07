import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddSoccerEventComponent } from './add-soccer-event.component';

describe('AddSoccerEventComponent', () => {
  let component: AddSoccerEventComponent;
  let fixture: ComponentFixture<AddSoccerEventComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddSoccerEventComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddSoccerEventComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
