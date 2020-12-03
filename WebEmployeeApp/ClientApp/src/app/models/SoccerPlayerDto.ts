import { SoccerPlayerType } from "./enums/SoccerPlayerType";

export interface SoccerPlayerDto {
  id: string;
  name: string;
  soccerPlayerType: SoccerPlayerType;
}
