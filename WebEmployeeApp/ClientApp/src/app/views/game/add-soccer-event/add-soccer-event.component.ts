import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { SoccerEventType } from "src/app/models/enums/SoccerEventType";
import {
  CreateSoccerEventDto,
  SoccerEventDto,
} from "src/app/models/SoccerEventDto";
import { SoccerGameDto } from "src/app/models/SoccerGameDto";
import { SoccerPlayerDto } from "src/app/models/SoccerPlayerDto";
import { SoccerTeamDto } from "src/app/models/SoccerTeamDto";
import { GameServiceService } from "src/app/services/game-service.service";
import { SoccerEventService } from "src/app/services/soccer-event.service";

@Component({
  selector: "app-add-soccer-event",
  templateUrl: "./add-soccer-event.component.html",
  styleUrls: ["./add-soccer-event.component.css"],
})
export class AddSoccerEventComponent implements OnInit {
  isLoading = false;
  eventIsSubmitting = false;
  gameId: string;
  soccerEvents: SoccerEventDto[] = [];
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
  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private gameService: GameServiceService,
    private soccerEventService: SoccerEventService
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
      this.teams.push(this.game.homeSoccerTeam);
      this.teams.push(this.game.guestSoccerTeam);
    });
  }

  onSelectTeam() {
    let soccerTeam: SoccerTeamDto = this.eventForm.get("soccerTeam").value;
    this.selectedTeam = soccerTeam;
    this.model.soccerTeamId = soccerTeam.id;
  }

  onSelectPlayer() {
    let soccerPlayer: SoccerPlayerDto = this.eventForm.get("soccerPlayer")
      .value;
    this.model.soccerPlayerId = soccerPlayer.id;
    this.selectedPlayer = soccerPlayer;
  }

  onSelectEvent() {
    let soccerEvent: SoccerEventType = this.eventForm.get("soccerEvent").value;
    this.model.soccerEventType = soccerEvent;
  }

  onSubmit() {
    this.eventIsSubmitting = true;
    this.model.soccerGameId = this.gameId;
    this.soccerEventService.addSoccerEvent(this.model).subscribe(() => {
      this.eventIsSubmitting = false;
      this.router.navigate(["/games", this.gameId], { relativeTo: this.route });
    });
  }
}
