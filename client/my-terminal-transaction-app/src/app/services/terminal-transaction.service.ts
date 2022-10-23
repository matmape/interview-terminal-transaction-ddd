import { Injectable } from '@angular/core';
import { IResource } from '../base/classes/iresource';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TerminalTransactionService implements IResource {

  constructor(private http: HttpClient) { }

  url = environment.tms +'api/v1/';

 
  update(item: any, id?: any) {
    return this.http.put<any>(this.url+'terminaltransaction' ,item);
  }
  getById(id: any) {
    return this.http.get<any>(this.url + `terminaltransaction/${id}`);
  }
  create(item: any) {
    return this.http.post<any>(this.url +'terminaltransaction',item);
  }
  count(config?: any) {
    return this.http.get<any>(this.url + `terminaltransaction/get-paged-requests/${config.page}/${config.pageSize}/${config.whereCondition}`);
  }
  query(config?: any) {
    return this.http.get<any>(this.url + `terminaltransaction/query-paged-requests/${config.page}/${config.pageSize}/${config.whereCondition}`);
  }
  delete(id: any) {
    return this.http.delete<any>(this.url +`terminaltransaction/${id}`);
  }
  getDashboard() {
    return this.http.get<any>(this.url +`dashboard`);
  }
}
