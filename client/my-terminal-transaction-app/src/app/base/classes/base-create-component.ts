import { Router } from "@angular/router";
import { IResource } from "./iresource";
import { IBackLink } from "./pagination-config";

 

export class BaseCreateComponent {
  router: any;


  constructor(
    public Resource: IResource
  ) {  }

  err = "";
  item: any = {};
  title: any = "";
  backLink: IBackLink = { route: "", name: "" };
 
  permissions: any = {};
   
  
   submit() {
     
    this.err = "";
    // console.log(this.item);

    this.Resource.create(this.item).subscribe(
      (res:any) => {
        if (res.successful) {
          this.goBack();
        } else {
          this.err = res.validationMessages!=null? res.validationMessages.join(","):res.message; 
        }
      },
      (err:any) => {
        this.err = err.error.message;
        if (err.error.validationMessages != null) {
          this.err = err.error.validationMessages.join(",");
        }
      }
    );
  }
  goBack() {
    this.router.navigate([this.backLink.route]);
  }
 
}
