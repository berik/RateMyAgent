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

### Things would be nice to have
- [ ] Add WebCustomerApp - would be ASP.Net MVC where page will be rendered on the server and SEO will be generated
- [ ] Add SignalR to WebCustomerApp and WebEmployeeApp for real-time update without refresh page. When employee adds new event in `WebEmployeeApp` it will push live data to `WebCustomerApp`


![Screen Shot 2020-12-07 at 11 10 44 pm](https://user-images.githubusercontent.com/1040210/101349550-a3b0c480-38e1-11eb-8591-31846d4465be.png)
