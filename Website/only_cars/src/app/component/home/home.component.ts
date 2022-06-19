import { Component, OnInit } from '@angular/core';
import { ParkSlotServiceService } from 'src/app/services/park-slot-service.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.sass']
})
export class HomeComponent implements OnInit {

  public parkSlotObject: any;
  constructor(private parkSlotService:ParkSlotServiceService) { }

  ngOnInit(): void {
    console.log("Test");
      this.parkSlotService.getParkSlotObject().subscribe(x => {
        this.parkSlotObject = x;
      });
  }

  levels: any = [
    {
      name: 0
    },
    {
      name: 1
    }];

  numParkSlots: any = 6;
}
