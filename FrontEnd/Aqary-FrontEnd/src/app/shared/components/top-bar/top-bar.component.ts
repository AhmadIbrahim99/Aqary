import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-top-bar',
  templateUrl: './top-bar.component.html',
  styleUrls: ['./top-bar.component.scss']
})
export class TopBarComponent implements OnInit {
@Output() sideNavToggled = new EventEmitter<boolean>();
menuStatus: boolean  = false;
constructor() { }

  ngOnInit(): void {
  }
  SideNavToggled(){
    this.menuStatus = ! this.menuStatus;
    this.sideNavToggled.emit(this.menuStatus);
  }
}
