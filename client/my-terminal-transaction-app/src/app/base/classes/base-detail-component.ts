import { Router, ActivatedRoute } from "@angular/router";
import { IResource } from "./iresource";
import { IBackLink } from "./pagination-config";

export class BaseDetailsComponent {
    backLink: IBackLink = { route: "", name: "" };
    router: any;
    permissions: any = {};
    item: any = {};
    err = "";
    yesNoList = [
      { name: "Yes", id: true },
      { name: "No", id: false },
    ];
    title = "";
    constructor(
      public Resource: IResource,
      public route: ActivatedRoute
    ) {
      this.getItem();
     // this.router = new Router();
    }
    
  
    getItem() {
      this.route.paramMap.subscribe((param) => {
        this.Resource.getById(param.get("id")).subscribe(
          (res:any) => {
            if (res.successful) {
              this.item = res.result;
            } else {
                this.err = res.message;
            }
          },
          (err:any) => {
            this.err = err.error.message;
          }
        );
      });
    }
  
    
    goBack() {
      this.router.navigate([this.backLink.route]);
    }
  }