import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.scss']
})
export class SideBarComponent implements OnInit {
  list =[
    {number:'1',name:'Estates',icon:'fa-solid fa-box', link:'estate'},
    // {number:'2',name:'Craete Estate',icon:'fa-solid fa-box', link:'estate/create/create'},
    {number:'3',name:'Profile',icon:'fa-solid fa-user', link:'profile'}
  ];
  @Input() sideNavStatus: boolean= false ;
  constructor() { }

  ngOnInit(): void {
  }

}
