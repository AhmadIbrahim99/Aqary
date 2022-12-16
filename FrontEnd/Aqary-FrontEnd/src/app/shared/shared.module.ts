import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SideBarComponent } from './components/side-bar/side-bar.component';
import { TopBarComponent } from './components/top-bar/top-bar.component';
import { RouterModule } from '@angular/router';
import { ThirdpartyModule } from '../thirdparty/thirdparty.module';

@NgModule({
  declarations: [SideBarComponent, TopBarComponent],
  imports: [CommonModule, ThirdpartyModule, RouterModule],
  exports: [SideBarComponent, TopBarComponent],
})
export class SharedModule {}
