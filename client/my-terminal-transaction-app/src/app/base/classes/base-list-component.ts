import { FilterService } from "./filter-service";
import { IResource } from "./iresource";
import { Config } from "./pagination-config";

export class BaseListComponent {
    filter: any = {};
    items: any[] = [];
    pager = { page: 1 };
    hideFilter: boolean = false;
    hasColumns = false;
    extraInfo: any = {};
    err = "";
    pageSizes = [
        { id: 25, name: 25 },
        { id: 50, name: 50 },
        { id: 100, name: 100 },
        { id: 200, name: 200 },
        { id: 500, name: 500 }
    ];
    reportColumns: any = [];
    showSpinner = true;
    filterService: FilterService;
    paginationConfig = new Config(1, 25, 0, JSON.stringify(this.filter));
    page: number = 1;
    isAllItemsChecked = false;
    selectedIds: any = [];
    otherInfo: any = {};

    constructor(
        public Resource: IResource,
        public pageName: string,
    ) {
        this.filterService = new FilterService();
        this.filter = this.filterService.getFilterObject(this.pageName);
    }
    init(count?: number) {
        this.initScope(count);
        this.setupPagination();
    }

    setupPagination() {
        this.showSpinner = true;
        this.items = [];
        this.otherInfo = {};
        this.extraInfo = {};
        let conf = {
            pageSize: this.paginationConfig.pageSize,
            page: this.paginationConfig.page,
            whereCondition: JSON.stringify(this.filter),
        }

        const storedFilter = this.filterService.getFilterObject(this.pageName);
        var spreader = { ...conf, ...this.filter, ...storedFilter };

        this.Resource.count( spreader ).subscribe(
            (data: any) => {
                this.showSpinner = false;
                var serverResponse = data;
                if (data.hasOwnProperty("result")) {
                    serverResponse = data.result;
                } else {
                    serverResponse = data;
                }

                if (serverResponse.items.length !== 0) {
                    this.paginationConfig.total = serverResponse.total;
                    this.items = serverResponse.items;
                    this.extraInfo = serverResponse.info;
                    this.filterService.saveFilterObject(this.pageName, this.filter);

                    this.showSpinner = false;
                    this.otherInfo = serverResponse.otherInfo;
                } else {
                    this.showSpinner = false;
                    this.err = "No result";
                }
            },
            (err: any) => {
                this.showSpinner = false;
                this.err = err.message;
            }
        );
    }

    pageChanged(page: number) {
        this.showSpinner = true;
        this.items = [];
        this.paginationConfig.page = page;
        const storedFilter = this.filterService.getFilterObject(this.pageName);
        this.filter = storedFilter;
        let conf = {
            pageSize: this.paginationConfig.pageSize,
            page: this.paginationConfig.page,
            whereCondition: JSON.stringify(this.filter),
        }
        var spreader = { ...conf, ...this.filter, ...storedFilter };
        this.Resource.query(spreader  ).subscribe(
            (data: any) => {
                this.showSpinner = false;
                var serverResponse = data;
                if (data.hasOwnProperty("result")) {
                    serverResponse = data.result;
                } else {
                    serverResponse = data;
                }
                this.items = serverResponse;

                this.hideFilter = false;
                this.pager.page = this.paginationConfig.page;
                this.filterService.saveFilterObject(this.pageName, this.filter);
            },
            (err: any) => {
                this.showSpinner = false;
                console.log(err);
            }
        );
    }

    async pageSizeChanged(e: number) {
        this.paginationConfig.pageSize = e;
        this.pageChanged(this.paginationConfig.page);
    }

    initScope(count: any) {
        this.items = [];
        this.page = 1;
        this.paginationConfig = {
            pageSize: count || 50,
            page: 1,
            total: 0,
        };
        this.pager = { page: 1 };
    }

    resetFiltering(formId?: any) {
        this.filterService.clearCookiesFromSite();
        this.filter = this.filterService.getFilterObject(this.pageName);
        this.setupPagination();
    }

    getTotalPages() {
        return Math.ceil(
            this.paginationConfig.total / this.paginationConfig.pageSize
        );
    }
    getIndexSeed($index: number) {
        return (this.pager.page - 1) * this.paginationConfig.pageSize + $index + 1;
    }

    getPageInfoDescription() {
        if (this.items) {
            return (
                "Showing " +
                (this.paginationConfig.pageSize * (this.pager.page - 1) + 1) +
                " to " +
                (this.paginationConfig.pageSize * (this.pager.page - 1) +
                    this.items.length) +
                " of " +
                this.paginationConfig.total
            );
        }
        return "";
    }

    toggleHideFilter() {
        this.hideFilter = !this.hideFilter;
    }


    export() { }

    checkAll() {
        this.isAllItemsChecked = !this.isAllItemsChecked;
        if (this.isAllItemsChecked) {
            this.items.forEach((item) => (item.checked = true));

            this.selectedIds = this.items
                .filter((item) => {
                    return item.checked;
                })
                .map((i) => {
                    return i.id;
                });
        } else {
            this.items.forEach((item) => (item.checked = false));
            this.selectedIds = [];
        }

    }

    checkboxChanged() {
        this.selectedIds = this.items
            .filter((item) => {
                return item.checked;
            })
            .map((i) => {
                return i.id;
            });
    }
}