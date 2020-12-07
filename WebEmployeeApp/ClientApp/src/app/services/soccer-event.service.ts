import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { CreateSoccerEventDto, SoccerEventDto } from "../models/SoccerEventDto";

@Injectable({
  providedIn: "root",
})
export class SoccerEventService {
  baseApiUrl = "";
  constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.baseApiUrl = baseUrl + "api/Event";
  }

  getSoccerEvents(gameId: string): Observable<SoccerEventDto[]> {
    return this.http.get<SoccerEventDto[]>(`${this.baseApiUrl}/${gameId}`);
  }

  getSoccerEvent(gameId, eventId: string): Observable<SoccerEventDto> {
    return this.http.get<SoccerEventDto>(
      `${this.baseApiUrl}/${gameId}/${eventId}`
    );
  }

  addSoccerEvent(gameEvent: CreateSoccerEventDto): Observable<SoccerEventDto> {
    return this.http.post<SoccerEventDto>(
      `${this.baseApiUrl}/AddGameEvent`,
      gameEvent
    );
  }

  updateSoccerEvent(
    eventId: string,
    gameEvent: CreateSoccerEventDto
  ): Observable<SoccerEventDto> {
    return this.http.put<SoccerEventDto>(
      `${this.baseApiUrl}/UpdateGameEvent/${eventId}`,
      gameEvent
    );
  }
}
