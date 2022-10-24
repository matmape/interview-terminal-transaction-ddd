import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AgentCreateComponent } from './components/agent-create/agent-create.component';
import { AgentDetailsComponent } from './components/agent-details/agent-details.component';
import { AgentEditComponent } from './components/agent-edit/agent-edit.component';
import { AgentlistComponent } from './components/agentlist/agentlist.component';
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
  { path: "agents", component:AgentlistComponent },
  { path: "agents/edit/:id", component:AgentEditComponent },
  { path: "agents/details/:id", component:AgentDetailsComponent },
  { path: "agents/create", component:AgentCreateComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
