import { SoccerPlayerDto } from "./SoccerPlayerDto";

export interface SoccerTeamDto {
  id: string;
  name: string;
  players: SoccerPlayerDto[];
}
