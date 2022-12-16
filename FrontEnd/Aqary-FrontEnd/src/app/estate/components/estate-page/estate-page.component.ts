import { HttpClient } from '@angular/common/http';
import { Component, OnChanges, OnInit } from '@angular/core';
import { IEstate } from 'src/app/interfaces/iEstate/i-estate';
import { EstateService } from 'src/app/services/estate/estate.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-estate-page',
  templateUrl: './estate-page.component.html',
  styleUrls: ['./estate-page.component.scss'],
})
export class EstatePageComponent implements OnInit {

  constructor() {}

  ngOnInit(): void {

  }
  
}
