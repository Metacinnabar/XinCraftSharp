using System;
using XinCraftSharp.Core;
using XinCraftSharp.Player;

Console.WriteLine("Please input your API key.");
string? key = Console.ReadLine();

if (string.IsNullOrEmpty(key)) {
    Console.WriteLine("Exiting due to incorrect API key format.");
    return;
}

XinCraftApi api = new(key);
ApiResponse<UserInfo> userInfoResponse = await api.GetUserInfoFromUsername("metacinnabar", true);

if (userInfoResponse.Success)
{
    UserInfo userInfo = userInfoResponse.Data;
    Console.WriteLine("metacinnabar's best overall winstreak: " + userInfo.Stats.Overall.BestWinstreak);
}
else
{
    Console.WriteLine("An error occured: " + userInfoResponse.Cause);
}