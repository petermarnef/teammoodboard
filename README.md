# Team Moodboard

A web app you can use to measure the mood of your team. The app is deployed, and free to use, on https://teammoodboard.com.

This app is build with [ASP.NET Core Blazor](https://docs.microsoft.com/en-us/aspnet/core/blazor) (webassembly) and [SignalR](https://docs.microsoft.com/en-us/aspnet/core/signalr/introduction).

## How to get started contributing code

### Prerequisites

- Have the .NET Core SDK installed (v5)

### Next steps

- Clone the code
- Start the app by going to `/src/Server` and running `dotnet run`
- Or use the `dotnet watch run` command during development
- Create a PR on the master branch

### Main files

- On the Client
  - `/src/Client/Pages/Index.razor` - this file contains most of the client code
- On the Server
  - `/src/Server/Hubs/VoteHub.cs` - this file is the SignalR hub which is the gateway for the backend code

## Deployment

- Code commited to the `production` branch is automatically deployed to https://teammoodboard.com
- The main reason the `production` branch is deployed and not `master` is that we want to limit production deploys as the current state of the application is held in memory - and as such, a deploy wipes the state and all ongoing moodboards

## Todo

- Work on the UI/UX
- Make the app responsive, also on mobile
- Make topics and vote options configurable when creating a new moodboard
- Make it possible to have N number of topics/options (CSS change)
- Do some SEO
- Move the state of the application out of the web app
- Cleanup the .vscode files and get debugging working
- Add application insights

### Enhancements

- Emoji picker
- Randomize emoji's (twice the fun)
# Force rebuild - Sat Jun  7 22:59:27 CEST 2025
