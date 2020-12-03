import { Component, OnInit } from "@angular/core";
import { SoccerGameDto } from "src/app/models/SoccerGameDto";
import { GameServiceService } from "src/app/services/game-service.service";

@Component({
  selector: "app-game",
  templateUrl: "./game.component.html",
  styleUrls: ["./game.component.css"],
})
export class GameComponent implements OnInit {
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
}
