import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditTerminalTransactionComponent } from './edit-terminal-transaction.component';

describe('EditTerminalTransactionComponent', () => {
  let component: EditTerminalTransactionComponent;
  let fixture: ComponentFixture<EditTerminalTransactionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditTerminalTransactionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditTerminalTransactionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
