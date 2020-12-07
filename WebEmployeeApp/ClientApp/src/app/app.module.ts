import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { RouterModule } from "@angular/router";

import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { HomeComponent } from "./views/home/home.component";
import { ApiAuthorizationModule } from "src/api-authorization/api-authorization.module";
import { AuthorizeGuard } from "src/api-authorization/authorize.guard";
import { AuthorizeInterceptor } from "src/api-authorization/authorize.interceptor";
import { GameDetailsComponent } from "./views/game/game-details/game-details.component";
import { GameListComponent } from "./views/game/game-list/game-list.component";
import { AddSoccerEventComponent } from "./views/game/add-soccer-event/add-soccer-event.component";
import { FontAwesomeModule } from "@fortawesome/angular-fontawesome";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    GameListComponent,
    GameDetailsComponent,
    AddSoccerEventComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ApiAuthorizationModule,
    FontAwesomeModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
      {
        path: "games",
        component: GameListComponent,
        canActivate: [AuthorizeGuard],
      },
      {
        path: "games/:gameId",
        component: GameDetailsComponent,
        canActivate: [AuthorizeGuard],
      },
      {
        path: "games/:gameId/new-event",
        component: AddSoccerEventComponent,
        canActivate: [AuthorizeGuard],
      },
    ]),
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
