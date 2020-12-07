import { Component, OnInit } from "@angular/core";
import { FormGroup, FormControl, Validators } from "@angular/forms";
import { ActivatedRoute } from "@angular/router";
import { SoccerEventType } from "src/app/models/enums/SoccerEventType";
import {
  CreateSoccerEventDto,
  SoccerEventDto,
} from "src/app/models/SoccerEventDto";
import { SoccerGameDto } from "src/app/models/SoccerGameDto";
import { SoccerPlayerDto } from "src/app/models/SoccerPlayerDto";
import { SoccerTeamDto } from "src/app/models/SoccerTeamDto";
import { GameServiceService } from "src/app/services/game-service.service";

import { faFutbol } from "@fortawesome/free-solid-svg-icons";
import { faExchangeAlt } from "@fortawesome/free-solid-svg-icons";
import { faSquare } from "@fortawesome/free-solid-svg-icons";

@Component({
  selector: "app-game-details",
  templateUrl: "./game-details.component.html",
  styleUrls: ["./game-details.component.css"],
})
export class GameDetailsComponent implements OnInit {
  isLoading = false;
  isLoadingEvents = false;
  gameIsUpdating = false;
  soccerEvents: SoccerEventDto[] = [];

  eventIsSubmitting = false;
  gameId: string;
  game: SoccerGameDto;
  teams: SoccerTeamDto[] = [];
  selectedTeam: SoccerTeamDto;
  selectedPlayer: SoccerPlayerDto;
  events = [
    { id: 0, name: "Yellow Card" },
    { id: 1, name: "Red Card" },
    { id: 2, name: "Substitute" },
    { id: 3, name: "Score Goal" },
  ];
  model: CreateSoccerEventDto = {
    soccerGameId: "",
    soccerEventType: 0,
    soccerPlayerId: "",
    soccerTeamId: "",
  };
  eventForm: FormGroup;
  faFutbol = faFutbol;
  faExchangeAlt = faExchangeAlt;
  faSquare = faSquare;
  constructor(
    private route: ActivatedRoute,
    private gameService: GameServiceService
  ) {}
  ngOnInit() {
    this.gameId = this.route.snapshot.paramMap.get("gameId");
    if (this.gameId) {
      this.getGame(this.gameId);
    }
    this.initForm();
  }

  private initForm() {
    this.eventForm = new FormGroup({
      soccerTeam: new FormControl(null, Validators.required),
      soccerPlayer: new FormControl(null, Validators.required),
      soccerEvent: new FormControl(null, Validators.required),
    });
  }

  getGame(gameId: string) {
    this.isLoading = true;
    this.gameService.getGame(gameId).subscribe((result) => {
      this.isLoading = false;
      this.game = result;
    });
  }

  startGame(gameId: string) {
    this.gameIsUpdating = true;
    this.gameService.startGame(gameId).subscribe(() => {
      this.gameIsUpdating = false;
      this.game.gameStatus = 1;
    });
  }

  stopGame(gameId: string) {
    this.gameIsUpdating = true;
    this.gameService.stopGame(gameId).subscribe(() => {
      this.gameIsUpdating = false;
      this.game.gameStatus = 2;
    });
  }

  getTeamName(gameId: string) {
    if (this.game.guestSoccerTeam.id === gameId) {
      return this.game.guestSoccerTeam.name;
    } else {
      return this.game.homeSoccerTeam.name;
    }
  }

  getTitleName(game: SoccerGameDto): string {
    const homeTeamId = game.homeSoccerTeam.id;
    const guestTeamId = game.guestSoccerTeam.id;

    const scoreOfHometeam = game.soccerEvents.filter(
      (a) =>
        a.soccerTeamId == homeTeamId &&
        a.soccerEventType == SoccerEventType.ScoreGoal
    ).length;
    const scoreOfGuestTeam = game.soccerEvents.filter(
      (a) =>
        a.soccerTeamId == guestTeamId &&
        a.soccerEventType == SoccerEventType.ScoreGoal
    ).length;

    return `${game.homeSoccerTeam.name} ${scoreOfHometeam} : ${scoreOfGuestTeam} ${game.guestSoccerTeam.name}`;
  }
}
