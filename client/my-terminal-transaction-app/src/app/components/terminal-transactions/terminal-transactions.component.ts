import { Component, OnInit } from '@angular/core';
import { BaseListComponent } from 'src/app/base/classes/base-list-component';
import { TerminalTransactionService } from 'src/app/services/terminal-transaction.service';
@Component({
  selector: 'app-terminal-transactions',
  templateUrl: './terminal-transactions.component.html',
  styleUrls: ['./terminal-transactions.component.css']
})
export class TerminalTransactionsComponent extends BaseListComponent implements OnInit {

  constructor(private api: TerminalTransactionService) {
    super(api, 'TerminalTransactions');
  }
  filterModel: any = {};
  showAddForm: boolean = false;
  item: any = {};
  error: string = '';
  ngOnInit(): void {
    this.init(25);
  }
  searchBar(event: any) {
    console.log(event.value);
    if (event.value.length > 2) {
      (<any>this.filter).agentName = event.value;
      this.paginationConfig.whereCondition = this.filter;
      this.setupPagination();
    } else {
      this.setupPagination();
    }
  }
  hideAddForm() {
    this.showAddForm = !this.showAddForm;
  }
  submit() {

    this.api.create(this.item).subscribe(
      (res) => {
        if (res.successful) {
          this.showAddForm = false;
          this.items.unshift(this.item);
          this.item = {};
          this.setupPagination();
        } else {

          this.error = res.validationMessages != null ? res.validationMessages.join(",") : res.message;
        }
      },
      (err) => {
        this.err = err.error.message;
        if (err.error.validationMessages != null) {
          this.error = err.error.validationMessages.join(",");
        }
      }
    );
  }

  remove(item:any){

  }
}
