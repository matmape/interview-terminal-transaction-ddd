import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { NgxPaginationModule } from 'ngx-pagination';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TerminalTransactionsComponent } from './components/terminal-transactions/terminal-transactions.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NewTerminalTransactionComponent } from './components/new-terminal-transaction/new-terminal-transaction.component';
import { EditTerminalTransactionComponent } from './components/edit-terminal-transaction/edit-terminal-transaction.component';
import { TerminalTransactionDetailComponent } from './components/terminal-transaction-detail/terminal-transaction-detail.component';
import { OverviewComponent } from './components/overview/overview.component';

@NgModule({
  declarations: [
    AppComponent,
    TerminalTransactionsComponent,
    NewTerminalTransactionComponent,
    EditTerminalTransactionComponent,
    TerminalTransactionDetailComponent,
    OverviewComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    NgxPaginationModule,
    FontAwesomeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
