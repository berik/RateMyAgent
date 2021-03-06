import { Component, OnInit } from "@angular/core";
import { SoccerGameDto } from "src/app/models/SoccerGameDto";
import { GameService } from "src/app/services/game.service";

@Component({
  selector: "app-game-list",
  templateUrl: "./game-list.component.html",
  styleUrls: ["./game-list.component.css"],
})
export class GameListComponent implements OnInit {
  isLoading = false;
  games: SoccerGameDto[];
  constructor(private gameService: GameService) {}

  ngOnInit() {
    this.isLoading = true;
    this.gameService.getGames().subscribe((result) => {
      this.isLoading = false;
      this.games = result;
    });
  }
}
