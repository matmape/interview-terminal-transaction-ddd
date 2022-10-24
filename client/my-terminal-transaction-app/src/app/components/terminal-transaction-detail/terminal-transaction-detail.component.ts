import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BaseDetailsComponent } from 'src/app/base/classes/base-detail-component';
import { TerminalTransactionService } from 'src/app/services/terminal-transaction.service';

@Component({
  selector: 'app-terminal-transaction-detail',
  templateUrl: './terminal-transaction-detail.component.html',
  styleUrls: ['./terminal-transaction-detail.component.css']
})
export class TerminalTransactionDetailComponent extends BaseDetailsComponent implements OnInit {
  constructor(api:TerminalTransactionService,route:ActivatedRoute) { 
    super(api,route);
  }

  ngOnInit(): void {
    this.title='Terminal Transaction Detail';
  }

}
