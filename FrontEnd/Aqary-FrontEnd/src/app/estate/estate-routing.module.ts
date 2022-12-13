import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { EstateDetailsComponent } from "./components/estate-details/estate-details.component";
import { EstateFormComponent } from "./components/estate-form/estate-form.component";
import { EstatePageComponent } from "./components/estate-page/estate-page.component";

const routes: Routes=[
  {path:'', component: EstatePageComponent},
  {path:':id', component: EstateDetailsComponent},
  {path:'create/:Id', component: EstateFormComponent},
  {path:'update/:Id', component: EstateFormComponent},
];
@NgModule({
  imports:[RouterModule.forChild(routes)],
  exports:[RouterModule]
})
export class EstateRoutingModule {}