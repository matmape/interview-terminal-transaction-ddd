import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewTerminalTransactionComponent } from './new-terminal-transaction.component';

describe('NewTerminalTransactionComponent', () => {
  let component: NewTerminalTransactionComponent;
  let fixture: ComponentFixture<NewTerminalTransactionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewTerminalTransactionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NewTerminalTransactionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
