using Microsoft.AspNetCore.SignalR;

namespace SignalrR.TypingIndicator.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
    
    // Начал печатать
    public async Task StartTyping(string user)
    {
        await Clients.Others.SendAsync("UserTyping", user);
    }

    // Перестал печатать
    public async Task StopTyping(string user)
    {
        await Clients.Others.SendAsync("UserStoppedTyping", user);
    }
}