import { Component, OnInit } from '@angular/core';
import { ParkSlotServiceService } from 'src/app/services/park-slot-service.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.sass']
})
export class HomeComponent implements OnInit {

  constructor(private parkSlotService:ParkSlotServiceService) { }

  ngOnInit(): void {
    console.log("Test");
      this.parkSlotService.getParkSlotObject().subscribe(x => console.log(x));
  }

  levels: any = [
    {
      name: 0
    },
    {
      name: 1
    }];
  parkSlots: any = [
    {
      id: 1,
      occupation: 0,
      level: 0
    },
    {
      id: 2,
      occupation: 1,
      level: 0
    },
    {
      id: 3,
      occupation: 0,
      level: 0
    },
    {
      id: 4,
      occupation: 1,
      level: 0
    },
    {
      id: 5,
      occupation: 0,
      level: 0
    },
    {
      id: 6,
      occupation: 0,
      level: 0
    },
  ]
  numParkSlots: any = 6;
}
