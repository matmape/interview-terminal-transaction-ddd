import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EditTerminalTransactionComponent } from './components/edit-terminal-transaction/edit-terminal-transaction.component';
import { NewTerminalTransactionComponent } from './components/new-terminal-transaction/new-terminal-transaction.component';
import { OverviewComponent } from './components/overview/overview.component';
import { TerminalTransactionDetailComponent } from './components/terminal-transaction-detail/terminal-transaction-detail.component';
import { TerminalTransactionsComponent } from './components/terminal-transactions/terminal-transactions.component';

const routes: Routes = [
  {
    path: "",
    pathMatch: "full",
    component: OverviewComponent
  },
  { path: "add-new", component:NewTerminalTransactionComponent },
  { path: "edit/:id", component:EditTerminalTransactionComponent },
  { path: "details/:id", component:TerminalTransactionDetailComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
