import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { IEstate, ISortable } from 'src/app/interfaces/iEstate/i-estate';
import { EstateService } from 'src/app/services/estate/estate.service';

@Component({
  selector: 'app-estate-item',
  templateUrl: './estate-item.component.html',
  styleUrls: ['./estate-item.component.scss'],
})
export class EstateItemComponent implements OnInit {
  data: IEstate[];
  spinner: boolean = true;
  sortable: ISortable[] = [
    { key: 'Id', value: '#' },
    { key: 'name', value: 'Name' },
  ];

  image = 'https://mdbcdn.b-cdn.net/img/new/standard/city/044.webp';
  //Form
  searchForm: FormGroup;
  constructor(private service: EstateService, private toaster: ToastrService) {}

  ngOnInit(): void {
    this.spinner = true;
    this.initForm();
    this.retriveData();
  }

  initForm() {
    this.searchForm = new FormGroup({
      ascending: new FormControl(true),
      sortable: new FormControl(''),
      search: new FormControl(''),
    });
  }

  onSubmit() {
    this.spinner = true;
    const { search } = this.searchForm.value;
    const { sortable } = this.searchForm.value;
    const { ascending } = this.searchForm.value;
    this.service
      .getSortedEstates(
        1,
        10,
        search,
        sortable,
        ascending == true ? 'ascending' : 'descending'
      )
      .subscribe({
        next: (reponse) => {
          console.log('___________');
          console.log(reponse.estates.data);
          this.data = reponse.estates.data;
          console.log('___________');
          this.spinner = false;
        },
        error: (error)=>{this.spinner = false;}
      });
  }

  retriveData() {
    this.service.getEntities.subscribe((data) => {
      this.data = data;
      this.spinner = false;
    });
  }
  deleteEstate(id: number) {
    this.toaster.warning('You Are Trying To Delete Estate');
    this.service.deleteEntity(id).subscribe({
      next: () => {
        // this.data.slice(this.data.findIndex(e=> e.id== id),1);
        this.retriveData();
        this.toaster.info('Succefully Deleted');
      },
      error: (error) => {
        this.toaster.warning('some thing went wrong');
      },
    });
  }

  getDate = (createdAt: string): Date => new Date(createdAt);
}
