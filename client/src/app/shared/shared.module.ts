import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { PagingHearderComponent } from './components/paging-hearder/paging-hearder.component';
import { PagerComponent } from './components/pager/pager.component';

@NgModule({
  declarations: [
    PagingHearderComponent,
    PagerComponent
  ],
  imports: [
    CommonModule,
    PaginationModule.forRoot()
  ],
  exports: [ 
    PaginationModule,
    PagingHearderComponent,
    PagerComponent
  ]
})
export class SharedModule { }
