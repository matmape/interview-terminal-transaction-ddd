export class Config {
    constructor(
      public page: number,
      public pageSize: number,
      public total: number,
      public whereCondition?: {},
      public filter?: {},
      public id?: string
    ) {}
  }
  export interface IBackLink {
    route: string;
    name: string;
    }