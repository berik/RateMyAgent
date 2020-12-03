import { GameStatus } from "./enums/GameStatus";
import { SoccerEventDto } from "./SoccerEventDto";
import { SoccerTeamDto } from "./SoccerTeamDto";

export interface SoccerGameDto {
  id: string;
  created: string;
  name: string;
  gameStatus: GameStatus;
  reporterId: string;
  soccerEvents: SoccerEventDto[];
  homeSoccerTeam: SoccerTeamDto;
  guestSoccerTeam: SoccerTeamDto;
}
