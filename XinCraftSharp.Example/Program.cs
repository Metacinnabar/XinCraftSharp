using System;
using XinCraftSharp.Core;
using XinCraftSharp.Example.Utils;
using XinCraftSharp.Player;

XinCraftApi api = new(ConsoleUtils.RequestInput("Please input your API key."));

string username = ConsoleUtils.RequestInput("Please input your desired username.");
ApiResponse<UserInfo> userInfoResponse = 
    await api.GetUserInfoFromUsername(username);

if (userInfoResponse.Success)
{
    UserInfo userInfo = userInfoResponse.Data;
    
    Console.WriteLine(username + "'s best overall winstreak: " + userInfo.Stats.Overall.BestWinstreak);
    Console.WriteLine(username + "'s best solos winstreak: " + userInfo.Stats.Solos.BestWinstreak);
    Console.WriteLine(username + "'s best doubles winstreak: " + userInfo.Stats.Doubles.BestWinstreak);
    Console.WriteLine(username + "'s best threes winstreak: " + userInfo.Stats.Threes.BestWinstreak);
    Console.WriteLine(username + "'s best fours winstreak: " + userInfo.Stats.Fours.BestWinstreak);
    
    Console.WriteLine(username + "'s username: " + userInfo.Name);
    Console.WriteLine(username + "'s uuid (with dashes): " + userInfo.Uuid);
    Console.WriteLine(username + "'s title: " + userInfo.Title);
    Console.WriteLine(username + "'s rank + color: " + userInfo.RankColor);
    Console.WriteLine(username + "'s token count: " + userInfo.Tokens);
    
    Console.WriteLine(username + "'s favourite maps:");
    foreach (var favouriteMap in userInfo.FavoriteMaps)
    {
        Console.WriteLine(favouriteMap);
    }
}
else
{
    Console.WriteLine("An error occured: " + userInfoResponse.Cause);
}
