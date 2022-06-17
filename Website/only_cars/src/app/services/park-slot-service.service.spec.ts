import { TestBed } from '@angular/core/testing';

import { ParkSlotServiceService } from './park-slot-service.service';

describe('ParkSlotServiceService', () => {
  let service: ParkSlotServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ParkSlotServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
