import { TestBed } from '@angular/core/testing';

import { SoccerEventService } from './soccer-event.service';

describe('SoccerEventService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: SoccerEventService = TestBed.get(SoccerEventService);
    expect(service).toBeTruthy();
  });
});
