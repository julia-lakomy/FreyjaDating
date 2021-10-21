import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {

  @Input() usersFromHomeComponent: any;
  @Output() cancelRegister = new EventEmitter();

  model: any = {};

  constructor() { }

  ngOnInit() { }

  register() {
    console.log(this.model);
  }

  cancel() {
    // console.log('cancelled');
    this.cancelRegister.emit(false);
  }
}
