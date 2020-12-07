# RateMyAgent

This app is architectured using clean code design. 
`Core` - contains only entities, interface and domain logic. <br/>
`Infrastructure` - contains reference to Core and implements data layer. <br/>
`Admin` - is a API server and contain SPA Angular. Ideally is used for adding new games, players and basically managing whole ecosystem. <br/>
`WebAdminApp` - is a API server and contain SPA Angular. Ideally is used for adding new games, players and basically managing whole ecosystem. <br/>
`WebEmployeeApp` - is a API server and contain SPA Angular. Ideally is by employees to just log soccer events.  <br/>

### Things done:
- [x] Added authentication/authorization
- [x] Added basic unit tests
- [x] Added Repository Pattern and Unit of Work
- [x] Added Angular for Admin and Employee
- [x] Added Bootstrap for mobile-first experience. 

### Things would be nice to have
- [ ] Add WebCustomerApp - would be ASP.Net MVC where page will be rendered on the server and SEO will be generated
- [ ] Add SignalR to WebCustomerApp and WebEmployeeApp for real-time update without refresh page. When employee adds new event in `WebEmployeeApp` it will push live data to `WebCustomerApp`

### WebAdminApp functionality
1. View list of games
![Screen Shot 2020-12-07 at 11 52 02 pm](https://user-images.githubusercontent.com/1040210/101353134-3acc4b00-38e7-11eb-8e0d-64a07577d068.png)

![Screen Shot 2020-12-07 at 11 52 22 pm](https://user-images.githubusercontent.com/1040210/101353155-4455b300-38e7-11eb-8650-c99616e17657.png)

### WebEmployeeApp
1. View list of games
![Screen Shot 2020-12-07 at 11 53 57 pm](https://user-images.githubusercontent.com/1040210/101353333-87b02180-38e7-11eb-8ef4-36ed964998d4.png)

2. View details of the specific game
![Screen Shot 2020-12-07 at 11 10 44 pm](https://user-images.githubusercontent.com/1040210/101349550-a3b0c480-38e1-11eb-8591-31846d4465be.png)

3. Start/Stop game

4. Add new event
![Screen Shot 2020-12-07 at 11 56 20 pm](https://user-images.githubusercontent.com/1040210/101353506-d2319e00-38e7-11eb-853f-66fc85f5c5a2.png)

5. Edit existing event
![Screen Shot 2020-12-07 at 11 56 41 pm](https://user-images.githubusercontent.com/1040210/101353539-de1d6000-38e7-11eb-91a4-a559bd2f0e58.png)
