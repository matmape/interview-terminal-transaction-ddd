import { Router, ActivatedRoute } from "@angular/router";
import { IResource } from "./iresource";
import { IBackLink } from "./pagination-config";

export class BaseEditComponent {
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
      this.init();
      this.getItem();
     // this.router = new Router();
    }
    init() {
       
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
  
    submit() {
      this.err = "";
  
      this.Resource.update(this.item).subscribe(
        (res:any) => {
          if (res.successful) {
            this.goBack();
          } else {
            if (res.resultType === 2) {
              this.err = res.message;
            } else {
              this.err = res.validationMessages;
            }
          }
        },
        (err:any) => {
          this.err = err.error.message;
        }
      );
    }
  
    goBack() {
      this.router.navigate([this.backLink.route]);
    }
  }