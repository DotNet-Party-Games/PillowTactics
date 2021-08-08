import { TestBed } from '@angular/core/testing';

import { GameroomService } from './gameroom.service';

describe('Gameroomservice', () => {
  let service: GameroomService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GameroomService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
