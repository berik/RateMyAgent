import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { SoccerGameDto } from "src/app/models/SoccerGameDto";
import { GameServiceService } from "src/app/services/game-service.service";

@Component({
  selector: "app-game-details",
  templateUrl: "./game-details.component.html",
  styleUrls: ["./game-details.component.css"],
})
export class GameDetailsComponent implements OnInit {
  isLoading = false;
  gameIsUpdating = false;
  gameId: string;
  game: SoccerGameDto;
  constructor(
    private route: ActivatedRoute,
    private gameService: GameServiceService
  ) {}
  ngOnInit() {
    this.gameId = this.route.snapshot.paramMap.get("gameId");
    if (this.gameId) {
      this.getGame(this.gameId);
    }
  }

  getGame(gameId: string) {
    this.isLoading = true;
    this.gameService.getGame(gameId).subscribe((result) => {
      this.isLoading = false;
      this.game = result;
    });
  }

  assignGame(gameId: string) {
    this.gameIsUpdating = true;
    this.gameService.assignGame(gameId).subscribe((result) => {
      this.gameIsUpdating = false;
    });
  }

  startGame(gameId: string) {
    this.gameIsUpdating = true;
    this.gameService.startGame(gameId).subscribe((result) => {
      this.gameIsUpdating = false;
    });
  }
}
