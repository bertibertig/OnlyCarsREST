import { TestBed } from '@angular/core/testing';

import { ParkslotresolverService } from './parkslotresolver.service';

describe('ParkslotresolverService', () => {
  let service: ParkslotresolverService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ParkslotresolverService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
