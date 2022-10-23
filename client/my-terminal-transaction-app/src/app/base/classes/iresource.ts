export interface IResource {
    update(item: any, id?: any):any;
    getById(id: any):any;
    create(item: any):any;
    count(config?: any): any;
    query(config?: any): any;
  }
  