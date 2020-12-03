import { SoccerEventType } from "./enums/SoccerEventType";
import { SoccerPlayerDto } from "./SoccerPlayerDto";

export interface SoccerEventDto {
  id: string;
  soccerEventType: SoccerEventType;
  soccerPlayer: SoccerPlayerDto;
}
