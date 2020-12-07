import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditSoccerEventComponent } from './edit-soccer-event.component';

describe('EditSoccerEventComponent', () => {
  let component: EditSoccerEventComponent;
  let fixture: ComponentFixture<EditSoccerEventComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditSoccerEventComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditSoccerEventComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
