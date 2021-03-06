import { NgModule } from '@angular/core';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { PagingHearderComponent } from './components/paging-hearder/paging-hearder.component';
import { PagerComponent } from './components/pager/pager.component';
import { OrderTotalsComponent } from './components/order-totals/order-totals.component';


@NgModule({
  declarations: [
    PagingHearderComponent,
    PagerComponent,
    OrderTotalsComponent
  ],
  imports: [
    CommonModule,
    PaginationModule.forRoot(),
    CarouselModule.forRoot()
  ],
  exports: [ 
    PaginationModule,
    PagingHearderComponent,
    PagerComponent,
    CarouselModule,
    OrderTotalsComponent
  ]
})
export class SharedModule { }
