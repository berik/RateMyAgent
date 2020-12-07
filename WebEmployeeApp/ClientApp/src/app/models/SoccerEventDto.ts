import { SoccerEventType } from "./enums/SoccerEventType";
import { SoccerPlayerDto } from "./SoccerPlayerDto";

export interface SoccerEventDto {
  id: string;
  soccerGameId: string;
  soccerTeamId: string;
  soccerPlayer: SoccerPlayerDto;
  soccerEventType: SoccerEventType;
}

export interface CreateSoccerEventDto {
  soccerGameId: string;
  soccerTeamId: string;
  soccerPlayerId: string;
  soccerEventType: SoccerEventType;
}
