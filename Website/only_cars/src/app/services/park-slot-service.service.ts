import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class ParkSlotServiceService {

  constructor(private http: HttpClient) { }

  public getParkSlotObject() {
    let header = new HttpHeaders();
    header.set("Access-Control-Allow-Origin: ", "http://localhost:5215/");
    return this.http.get("http://localhost:5215/parkingSpaces", {headers: header});
  }
}
