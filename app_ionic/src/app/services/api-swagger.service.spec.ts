import { TestBed } from '@angular/core/testing';

import { ApiSwaggerService } from './api-swagger.service';

describe('ApiSwaggerService', () => {
  let service: ApiSwaggerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ApiSwaggerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
