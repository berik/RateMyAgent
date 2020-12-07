import { Component, OnInit } from "@angular/core";
import { GameStatus } from "src/app/models/enums/GameStatus";
import { SoccerGameDto } from "src/app/models/SoccerGameDto";
import { GameServiceService } from "src/app/services/game-service.service";

@Component({
  selector: "app-game-list",
  templateUrl: "./game-list.component.html",
  styleUrls: ["./game-list.component.css"],
})
export class GameListComponent implements OnInit {
  isLoading = false;
  games: SoccerGameDto[];
  constructor(private gameService: GameServiceService) {}
  ngOnInit() {
    this.getGames();
  }

  getGames() {
    this.isLoading = true;
    this.gameService.getGames().subscribe((result) => {
      this.isLoading = false;
      this.games = result;
    });
  }

  getStatus(gameStatus: GameStatus): string {
    if (gameStatus == GameStatus.NotStarted) return "Game not started";
    else if (gameStatus == GameStatus.InProgress) return "Game in progress";
    return "Game completed";
  }
}
