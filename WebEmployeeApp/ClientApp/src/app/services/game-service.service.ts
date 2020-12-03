import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { SoccerGameDto } from "../models/SoccerGameDto";

@Injectable({
  providedIn: "root",
})
export class GameServiceService {
  baseApiUrl = "";
  constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.baseApiUrl = baseUrl + "api/Game";
  }

  getGames(): Observable<SoccerGameDto[]> {
    return this.http.get<SoccerGameDto[]>(`${this.baseApiUrl}`);
  }
}
