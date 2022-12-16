import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { ProfilePageComponent } from './components/profile-page/profile-page.component';
import { ProfileRoutingModule } from './profile-routing.module';



@NgModule({
  declarations: [
    LoginComponent,
    SignupComponent,
    ProfilePageComponent
  ],
  imports: [
    CommonModule,
    ProfileRoutingModule
  ],
  exports:[]
})
export class ProfileModule { }
