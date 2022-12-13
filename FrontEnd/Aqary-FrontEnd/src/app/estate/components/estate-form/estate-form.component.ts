import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { TypeEstate } from 'src/app/enums/type-estate';
import { ICategory } from 'src/app/interfaces/ICategory/icategory';
import { IEstate } from 'src/app/interfaces/iEstate/i-estate';
import { CategoryService } from 'src/app/services/category/category.service';
import { EstateService } from 'src/app/services/estate/estate.service';
import { ConverterService } from 'src/app/shared/services/converter.service';

@Component({
  selector: 'app-estate-form',
  templateUrl: './estate-form.component.html',
  styleUrls: ['./estate-form.component.scss'],
})
export class EstateFormComponent implements OnInit {
  spinner:boolean=false;
  createEstateForm: FormGroup;
  estate: IEstate;
  typeEstate:TypeEstate = new TypeEstate();
  categories: ICategory[] = [];
  constructor(
    private toaster:ToastrService,
    private converterService: ConverterService,
    private estateService: EstateService,
    private categoryService: CategoryService
  ) {}

  ngOnInit(): void {
    this.categoryService.getEntities.subscribe((categories) => {
      this.categories = categories;
    });
    this.createEstateFormInstantiatFormGroup();
  }

  createEstateFormInstantiatFormGroup = (): void => {
    this.createEstateForm = new FormGroup({
      name: new FormControl('Test', Validators.required),
      description: new FormControl('Test', Validators.required),
      typeEstate: new FormControl(0, Validators.required),
      status: new FormControl(true, Validators.required),
      salary: new FormControl(200, Validators.required),
      priceInDinar: new FormControl(200, Validators.required),
      idCategory: new FormControl(2, Validators.required),
      images: new FormControl('', Validators.required),
    });
  };

  onSubmit() {
    this.spinner=true;
    this.toaster.info('Starting Create');
    this.estate = this.createEstateForm.value;
    this.estate.idUser = 12;
    this.estate.attachmentsString = this.converterService.imagesBase64;
    console.log(this.estate);
    this.estate.idCategory = +this.estate.idCategory;
    this.estateService.createEntity(this.estate).subscribe({
      next: (data) => {
        console.log(data);
        this.toaster.success("Succefully Added");
        this.createEstateForm.reset();
        this.spinner = false;
      },
      error: (error) => {
        console.log(error);
        this.toaster.error("Some Thing Went Wrong");
      },
    });
  }

  onSelectidImages(event: any) {
    console.log(event.target!.files[0]);
    let files: FileList = event.target!.files as FileList;
    for (let index = 0; index < files.length; index++) {
      this.converterService.convertToBase64(files[index]);
    }
  }
}
