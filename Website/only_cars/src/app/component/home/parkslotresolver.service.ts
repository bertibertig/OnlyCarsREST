import { Injectable } from '@angular/core';
import {ActivatedRouteSnapshot, Resolve} from "@angular/router";
import {ParkSlot} from "../../models/ParkSlot";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class ParkslotresolverService implements Resolve<ParkSlot>{

  constructor() { }

  resolve(route: ActivatedRouteSnapshot): Observable<ParkSlot> {

    return undefined;
  }
}
