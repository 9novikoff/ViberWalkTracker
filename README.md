# ViberWalkTracker
Viber bot for Walk Tracking creeated using ASP.NET Core WebApi.
Refference: www.viber.com/fastwalktracker (unlikely to work since I disabled ngrok)
### How to use
1. Clone and open the repository 
2. Connect to database and run mssql scripts(two tables will be created in the database and one of them will be filled, they are integral components of the program)
4. Register a viber public account and get token
3. Set webhook for viber rest api using ngrok tunnels(maybe there will be automation in future versions)

### Implementation features
1. Scripts were created that create and populate the Walk table, which encapsulates the walks from the TrackLocation table, for convenient communication with the Viber Rest Api, it was decided to also create a UserBot table.
2. A multitier architecture was used
3. During the development, the main principles of OOP were followed as much as possible, the application consists of several abstract levels, which are provided by controllers, services, repositories and models for different levels.