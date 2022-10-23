import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BaseEditComponent } from 'src/app/base/classes/base-edit-component';
import { TerminalTransactionService } from 'src/app/services/terminal-transaction.service';

@Component({
  selector: 'app-edit-terminal-transaction',
  templateUrl: './edit-terminal-transaction.component.html',
  styleUrls: ['./edit-terminal-transaction.component.css']
})
export class EditTerminalTransactionComponent extends BaseEditComponent implements OnInit {

  constructor(api:TerminalTransactionService,
     route: ActivatedRoute, router:Router) {
    super(api,route);
    this.router = router;
   }
  ngOnInit(): void {
    this.title='Edit Terminal Transaction';
  }
   
}
