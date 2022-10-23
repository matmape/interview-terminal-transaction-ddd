import { Component, OnInit } from '@angular/core';
import { TerminalTransactionService } from 'src/app/services/terminal-transaction.service';

@Component({
  selector: 'app-overview',
  templateUrl: './overview.component.html',
  styleUrls: ['./overview.component.css']
})
export class OverviewComponent implements OnInit {
  overview:any={};
  constructor(private api:TerminalTransactionService) { }

  ngOnInit(): void {
    this.overview.transactionVolume=109323232;
    this.overview.userCount=4576;
    this.overview.stockCount=684;
    this.overview.withdrawalCount=898;

    this.getDashboard();
  }
  getDashboard() {
    this.api.getDashboard().subscribe(
      (res:any) => {
        if (res.successful) {
          this.overview = res.result;
        } else {
           
        }
      },
      (err:any) => {
         
      }
    );
  }

}
