import { Component, OnInit } from '@angular/core';
import { BaseListComponent } from 'src/app/base/classes/base-list-component';
import { AgentService } from 'src/app/services/agent.service';

@Component({
  selector: 'app-agentlist',
  templateUrl: './agentlist.component.html',
  styleUrls: ['./agentlist.component.css']
})
export class AgentlistComponent extends BaseListComponent implements OnInit {

  constructor(private api:AgentService) {
    super(api,'AgentList');
   }

  ngOnInit(): void {
    this.init();
  }

}
