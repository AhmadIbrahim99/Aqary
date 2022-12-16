import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EstatePageComponent } from './components/estate-page/estate-page.component';
import { EstateItemComponent } from './components/estate-item/estate-item.component';
import { EstateFormComponent } from './components/estate-form/estate-form.component';
import { EstateRoutingModule } from './estate-routing.module';
import { EstateDetailsComponent } from './components/estate-details/estate-details.component';
import { MdbCarouselModule } from 'mdb-angular-ui-kit/carousel';
import { ReactiveFormsModule } from '@angular/forms';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';



@NgModule({
  declarations: [
    EstatePageComponent,
    EstateItemComponent,
    EstateFormComponent,
    EstateDetailsComponent
  ],
  imports: [
    CommonModule,
    EstateRoutingModule,
    MdbCarouselModule,
    ReactiveFormsModule,
    SweetAlert2Module
  ]
})
export class EstateModule { }
