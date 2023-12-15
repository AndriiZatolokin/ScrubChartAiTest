Hello ScrubChart team
This is a WEB API project for the test task
1) I Integrate MediatR for handling commands and queries.
2) For now I didn't add a test for this project, but definitely it needs an integration test for the controller and a unit test for the repository
3) I added a few types of queries and handlers for filtering, but in my opinion, the variant with only one HTTP GET method with filter parameters is better
4) I use PostgreSQL and implement Swagger, so you can run and test it
5) For testing you need to pass for the connection string in appsettings.json and also to AppDbContext.cs
6) I added a "workaround" to repositories to add doctor entity and patient entity, so it is possible to play with visit API without adding doctors and patient info

For non-coding task 
I added a design file, you can open it in the browser to see it. 
I tried to write all my minds as a comment there, but in any case please ask me for any scenario

I haven't thought about fault tolerance or anything else that isn't related to tenants and timekeeping.

I assumed two options to save time. 
How to save time in UTC, and where the front end can translate the time to the user's time using the timezone in the browser,
and in a concept where the user can see the time exactly configured for the tenant.
In the case of a tenant-oriented time, I suggest the following solution
1) We save the timezone in the tenant record. which we can access everywhere through the ITenant interface that will be initialized through TenantMiddleware
2) In the same way, store all time through UTS, and convert it before sending it to the front. this will allow you to change the time zone of the tenant without changing all the time in the database
3) To convert the time to the tenant's time, I suggest that all fields be marked with an attribute, and add a handle for MediaR that will change the time to the tenant's time through reflection

But my main proposal is to store the time in the UTC format and it is the front that will be able to convert the time into the user's time
