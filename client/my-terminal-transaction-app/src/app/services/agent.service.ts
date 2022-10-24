import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IResource } from '../base/classes/iresource';

@Injectable({
  providedIn: 'root'
})
export class AgentService implements IResource {

  constructor(private http: HttpClient) { }

  url = environment.tms +'api/v1/';

 
  update(item: any, id?: any) {
    return this.http.put<any>(this.url+'agent' ,item);
  }
  getById(id: any) {
    return this.http.get<any>(this.url + `agent/${id}`);
  }
  create(item: any) {
    return this.http.post<any>(this.url +'agent',item);
  }
  count(config?: any) {
    return this.http.get<any>(this.url + `agent/get-paged-requests/${config.page}/${config.pageSize}/${config.whereCondition}`);
  }
  query(config?: any) {
    return this.http.get<any>(this.url + `agent/query-paged-requests/${config.page}/${config.pageSize}/${config.whereCondition}`);
  }
  delete(id: any) {
    return this.http.delete<any>(this.url +`agent/${id}`);
  } 
}
