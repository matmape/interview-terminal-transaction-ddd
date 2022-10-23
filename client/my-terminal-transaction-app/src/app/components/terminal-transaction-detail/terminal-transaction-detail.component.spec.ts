import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TerminalTransactionDetailComponent } from './terminal-transaction-detail.component';

describe('TerminalTransactionDetailComponent', () => {
  let component: TerminalTransactionDetailComponent;
  let fixture: ComponentFixture<TerminalTransactionDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TerminalTransactionDetailComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TerminalTransactionDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
