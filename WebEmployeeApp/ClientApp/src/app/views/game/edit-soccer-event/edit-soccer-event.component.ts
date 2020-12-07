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
  selector: "app-edit-soccer-event",
  templateUrl: "./edit-soccer-event.component.html",
  styleUrls: ["./edit-soccer-event.component.css"],
})
export class EditSoccerEventComponent implements OnInit {
  isLoading = false;
  gameId: string;
  eventId: string;
  soccerEvent: SoccerEventDto;
  eventForm: FormGroup;
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
  eventIsSubmitting = false;
  game: SoccerGameDto;
  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private gameService: GameServiceService,
    private soccerEventService: SoccerEventService
  ) {}

  ngOnInit() {
    this.gameId = this.route.snapshot.paramMap.get("gameId");
    this.eventId = this.route.snapshot.paramMap.get("eventId");
    if (this.gameId && this.eventId) {
      this.getGame(this.gameId);
    }
  }

  getEvent(gameId: string, eventId: string) {
    this.isLoading = true;
    this.soccerEventService
      .getSoccerEvent(gameId, eventId)
      .subscribe((result) => {
        this.isLoading = false;
        this.soccerEvent = result;
        this.selectedTeam = this.teams[
          this.teams.findIndex((a) => a.id == this.soccerEvent.soccerTeamId)
        ];
        this.selectedPlayer = this.selectedTeam.players[
          this.selectedTeam.players.findIndex(
            (a) => a.id == this.soccerEvent.soccerPlayer.id
          )
        ];
        this.initForm(this.soccerEvent);
        this.initModel(this.soccerEvent);
      });
  }

  getGame(gameId: string) {
    this.isLoading = true;
    this.gameService.getGame(gameId).subscribe((result) => {
      this.isLoading = false;
      this.game = result;
      this.teams.push(this.game.homeSoccerTeam);
      this.teams.push(this.game.guestSoccerTeam);
      this.getEvent(this.gameId, this.eventId);
    });
  }

  private initForm(soccerEvent: SoccerEventDto) {
    this.eventForm = new FormGroup({
      soccerTeam: new FormControl(
        this.teams[
          this.teams.findIndex((a) => a.id == soccerEvent.soccerTeamId)
        ],
        Validators.required
      ),
      soccerPlayer: new FormControl(
        this.selectedTeam.players[
          this.selectedTeam.players.findIndex(
            (a) => a.id == soccerEvent.soccerPlayer.id
          )
        ],
        Validators.required
      ),
      soccerEvent: new FormControl(
        soccerEvent.soccerEventType,
        Validators.required
      ),
    });
  }

  private initModel(soccerEvent: SoccerEventDto) {
    this.model.soccerPlayerId = soccerEvent.soccerPlayer.id;
    this.model.soccerTeamId = soccerEvent.soccerTeamId;
    this.model.soccerGameId = soccerEvent.soccerGameId;
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
    this.soccerEventService
      .updateSoccerEvent(this.soccerEvent.id, this.model)
      .subscribe(() => {
        this.eventIsSubmitting = false;
        this.router.navigate(["/games", this.gameId], {
          relativeTo: this.route,
        });
      });
  }
}
