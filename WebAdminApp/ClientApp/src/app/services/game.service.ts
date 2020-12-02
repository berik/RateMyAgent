import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { GameDto } from "../models/GameDto";

@Injectable({
  providedIn: 'root'
})
export class GameService {
  baseApiUrl = "";
  constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.baseApiUrl = baseUrl + "api/Game";
  }

  getGames(): Observable<GameDto[]> {
    return this.http.get<GameDto[]>(`${this.baseApiUrl}`);
  }
}
