using ArchiSteamFarm.Interfaces;
using ArchiSteamFarm.Steam;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RndFrndPlugin
{
    public class RndFrnd : IPlugin
    {
        public string Name => "RndFrnd";
        public string Version => "1.0.0";

        public Task OnGroupChatMessageReceived(string group, ulong userId, string message)
        {
            // Логика обработки сообщений
            Console.WriteLine($"Message from {userId} in {group}: {message}");
            return Task.CompletedTask;
        }

        public async Task AddRandomFriend(ArchiHandler archiHandler, ulong groupId)
        {
            List<ulong> friends = await archiHandler.GetGroupMembers(groupId);
            if (friends.Count == 0)
            {
                Console.WriteLine("No friends found in the group.");
                return;
            }

            Random random = new Random();
            ulong randomFriendId = friends[random.Next(friends.Count)];
            await archiHandler.AddFriend(randomFriendId);
            Console.WriteLine($"Added friend: {randomFriendId}");
        }
    }
}
