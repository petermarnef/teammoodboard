# Team Moodboard

A simple web app to discover how your team is feeling! 🤠

Share a unique URL with your team, let everyone vote with emojis, and see the collective mood in real-time. It's live and free to use at [teammoodboard.com](https://teammoodboard.com).

Built with [ASP.NET Core Blazor WebAssembly](https://docs.microsoft.com/en-us/aspnet/core/blazor) and [SignalR](https://docs.microsoft.com/en-us/aspnet/core/signalr/introduction) for that real-time magic ✨

## Contributing

I'd love your help making this better! Here's how to get started:

### What you'll need

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Your favorite code editor (VS Code works great!)

### Getting up and running

1. Clone this repository
2. Navigate to `/src/Server` 
3. Run `dotnet run` (or `dotnet watch run` for hot reload during development)
4. Open your browser and start clicking those emojis!

### Code structure

The magic happens in just a few key files:

**Client side:**
- `/src/Client/Pages/Index.razor` - The main UI and voting logic

**Server side:**
- `/src/Server/Hubs/VoteHub.cs` - SignalR hub handling real-time communication

### Making changes

Just create a Pull Request to the `main` branch and I'll take a look!

## Deployment

Deployment is fully automated:
1. Create a PR to `main`
2. Once merged, GitHub Actions builds and deploys to Azure
3. Your changes go live at [teammoodboard.com](https://teammoodboard.com)

**Heads up:** Since moodboard state lives in memory, each deployment resets all active sessions. I know, I know - it's on my list to fix! 😅
