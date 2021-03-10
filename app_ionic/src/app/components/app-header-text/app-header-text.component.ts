import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-header-text',
  templateUrl: 'app-header-text.component.html',
  styleUrls: ['app-header-text.component.scss'],
})
export class AppHeaderText implements OnInit {
  @Input() text: string;
  constructor() {}
  ngOnInit(): void {}

}
