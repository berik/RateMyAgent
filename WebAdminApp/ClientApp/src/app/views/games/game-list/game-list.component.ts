import { Component, OnInit } from '@angular/core';
import { GameDto } from 'src/app/models/GameDto';
import { GameService } from 'src/app/services/game.service';

@Component({
  selector: 'app-game-list',
  templateUrl: './game-list.component.html',
  styleUrls: ['./game-list.component.css']
})
export class GameListComponent implements OnInit {
  isLoading = false;
  games:GameDto[];
  constructor(private gameService: GameService) { }

  ngOnInit() {
    this.isLoading = true;
    this.gameService.getGames().subscribe((result) => {
      this.isLoading = false;
      this.games = result;
    });
  }
}
