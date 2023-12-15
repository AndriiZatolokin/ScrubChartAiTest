Hello ScrubChart team
This is a WEB API project for the test task
1) I Integrate MediatR for handling commands and queries.
2) For now I didn't add a test for this project, but definitely it needs an integration test for the controller and a unit test for the repository
3) I added a few types of queries and handlers for filtering, but in my opinion, the variant with only one HTTP GET method with filter parameters is better
4) I use PostgreSQL and implement Swagger, so you can run and test it
5) For testing you need to pass for the connection string in appsettings.json and also to AppDbContext.cs
6) I added a "workaround" to repositories to add doctor entity and patient entity, so it is possible to play with visit API without adding doctors and patient info
