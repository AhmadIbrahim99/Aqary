import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IEstate } from 'src/app/interfaces/iEstate/i-estate';
import { EstateService } from 'src/app/services/estate/estate.service';

@Component({
  selector: 'app-estate-details',
  templateUrl: './estate-details.component.html',
  styleUrls: ['./estate-details.component.scss'],
})
export class EstateDetailsComponent implements OnInit {
  spinner:boolean=true;
  current: IEstate;
  constructor(
    protected service: EstateService,
    protected route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.spinner = true;
    this.route.paramMap.subscribe((data) => {
      this.service.getEntityById(+data.get('id')!).subscribe((data) => {
        this.current = data;
        this.current.createdAt = this.getDate(this.current.createdAt).toString();
        this.spinner = false;
      });
    });
  }
  getDate = (createdAt: string):Date =>new Date(createdAt);

}
