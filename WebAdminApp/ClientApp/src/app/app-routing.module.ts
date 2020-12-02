import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule, Routes } from "@angular/router";
import { AuthorizeGuard } from "src/api-authorization/authorize.guard";
import { CounterComponent } from "./views/counter/counter.component";
import { FetchDataComponent } from "./views/fetch-data/fetch-data.component";
import { HomeComponent } from "./views/home/home.component";
import { GameListComponent } from "./views/games/game-list/game-list.component";

const routes: Routes = [
  { path: "", component: HomeComponent, pathMatch: "full" },
  { path: "counter", component: CounterComponent },
  {
    path: "fetch-data",
    component: FetchDataComponent,
    canActivate: [AuthorizeGuard],
  },
  {
    path: "games",
    component: GameListComponent,
    canActivate: [AuthorizeGuard],
  },
];

@NgModule({
  declarations: [
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    GameListComponent,
  ],
  imports: [CommonModule, RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
