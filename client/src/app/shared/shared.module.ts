import { NgModule } from '@angular/core';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { PagingHearderComponent } from './components/paging-hearder/paging-hearder.component';
import { PagerComponent } from './components/pager/pager.component';
import { OrderTotalsComponent } from './components/order-totals/order-totals.component';
import { ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TextInputComponent } from './components/text-input/text-input.component';

@NgModule({
  declarations: [
    PagingHearderComponent,
    PagerComponent,
    OrderTotalsComponent,
    TextInputComponent
  ],
  imports: [
    CommonModule,
    PaginationModule.forRoot(),
    CarouselModule.forRoot(),
    BsDropdownModule.forRoot(),
    ReactiveFormsModule,
  ],
  exports: [ 
    PaginationModule,
    PagingHearderComponent,
    PagerComponent,
    CarouselModule,
    OrderTotalsComponent,
    ReactiveFormsModule,
    BsDropdownModule,
    TextInputComponent
  ]
})
export class SharedModule { }
