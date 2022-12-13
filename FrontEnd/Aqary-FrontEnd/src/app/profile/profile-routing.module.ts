import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { LoginComponent } from "./components/login/login.component";
import { ProfilePageComponent } from "./components/profile-page/profile-page.component";
import { SignupComponent } from "./components/signup/signup.component";

const routes: Routes = [
    {path:'', component: ProfilePageComponent},
    {path:'login', component: LoginComponent},
    {path:'signup', component: SignupComponent},
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class ProfileRoutingModule {}
