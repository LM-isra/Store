import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-paging-hearder',
  templateUrl: './paging-hearder.component.html',
  styleUrls: ['./paging-hearder.component.scss']
})
export class PagingHearderComponent implements OnInit {
  @Input() pageNumber: number;
  @Input() pageSize: number;
  @Input() totalCount: number;

  constructor() { }

  ngOnInit(): void {
  }

}
