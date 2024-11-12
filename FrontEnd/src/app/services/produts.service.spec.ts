import { TestBed } from '@angular/core/testing';

import { ProductsService } from './produts.service';

describe('ProdutsService', () => {
  let service: ProductsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProductsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
