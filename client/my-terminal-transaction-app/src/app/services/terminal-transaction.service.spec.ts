import { TestBed } from '@angular/core/testing';

import { TerminalTransactionService } from './terminal-transaction.service';

describe('TerminalTransactionService', () => {
  let service: TerminalTransactionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TerminalTransactionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
