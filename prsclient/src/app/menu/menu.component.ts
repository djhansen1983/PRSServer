import { Component, OnInit } from '@angular/core';
import { Menu } from './menu.class'

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  menus: Menu[] = [
    new Menu("USERS", "/user/list"),
    new Menu("VENDORS", "/vendor/list"),
    new Menu("PRODUCTS", "/product/list"),
    new Menu("REQUESTS", "/request/list"),
  ];

  constructor() { }

  ngOnInit(): void {
  }

}
