import { Injectable } from '@angular/core';
import {ActivatedRouteSnapshot, Resolve} from "@angular/router";
import {ParkSlot} from "../../models/ParkSlot";
import {Observable} from "rxjs";
import {ParkSlotServiceService} from "../../services/park-slot-service.service";

@Injectable({
  providedIn: 'root'
})
export class ParkslotresolverService implements Resolve<ParkSlot>{

  constructor(private service : ParkSlotServiceService) { }

  resolve(route: ActivatedRouteSnapshot): Observable<ParkSlot> {

    return this.service.getParkSlotObject();
  }
}
