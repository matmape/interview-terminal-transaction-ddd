// import * as $ from 'jquery';
export class FilterService {
    getFilterObject(listPageName: string): any {
      if (listPageName !== undefined && listPageName!=='') {
        const type = 'undefined';
        if (typeof (sessionStorage.getItem(listPageName)) !== type) {
          if (sessionStorage.getItem(listPageName)) {
            return JSON.parse(sessionStorage.getItem(listPageName) || '');
          }
          return {};
        }
        return {};
      }else{
        const type = 'undefined';
        if (typeof (sessionStorage.getItem('listCtrlNames')) !== type) {
          if (sessionStorage.getItem('listCtrlNames')) {
            console.log(sessionStorage.getItem('listCtrlNames'))
            //return JSON.parse(sessionStorage.getItem('listCtrlNames'));
          }
          return {};
        }
      }
      return {};
    }
    saveFilterObject(listPageName: string, filter: any) {
      const data = JSON.stringify(filter);
      this.clearCookiesFromSite();
      sessionStorage.setItem(listPageName, data);
      sessionStorage.setItem('listCtrlNames', listPageName);
    }
    clearCookiesFromSite() {
      const type = 'undefined';
      if (typeof (sessionStorage.getItem('listCtrlNames')) !== type) {
        if (sessionStorage.getItem('listCtrlNames')) {
          try {
            const siteCookie = sessionStorage.getItem('listCtrlNames') || '';
            // sessionStorage.removeItem(siteCookie);
            const cookies = siteCookie.split(',');
  
            for (let i = 0; i < cookies.length; i++) {
              sessionStorage.removeItem(cookies[i]);
            }
          } catch (err) {
            console.log(err);
          }
        }
      }
  
    }
  }
  