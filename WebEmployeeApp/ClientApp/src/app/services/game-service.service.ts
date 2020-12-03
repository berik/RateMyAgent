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

  getGame(gameId: string): Observable<SoccerGameDto> {
    return this.http.get<SoccerGameDto>(`${this.baseApiUrl}/${gameId}`);
  }

  assignGame(gameId: string): Observable<string> {
    return this.http.put<string>(`${this.baseApiUrl}/AssignGame/${gameId}`, {});
  }

  startGame(gameId: string): Observable<string> {
    return this.http.put<string>(`${this.baseApiUrl}/StartGame/${gameId}`, {});
  }
}
