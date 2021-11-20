using System;
using XinCraftSharp.Core;
using XinCraftSharp.Endpoints.Player;
using XinCraftSharp.Example.Utils;

// Initialise our own API object with the inputted key requested to console.
// We use our own helper utility method here to reduce duplicate code.
XinCraftApi api = new(ConsoleUtils.RequestInput("Please input your API key."));

// Ask the user to input their desired username using the
// helper method we used earlier.
string username = ConsoleUtils.RequestInput("Please input your desired username.");

// Get an API response for the UserInfo object from username through our
// api object.
ApiResponse<UserInfo> userInfoResponse = await api.GetUserInfoFromUsername(username);

// Check if the response was successful
if (userInfoResponse.Success)
{
    // Create a userInfo variable to ease grabbing information from it.
    UserInfo userInfo = userInfoResponse.Data;
    
    // Print information about our provided username.
    Console.WriteLine(username + "'s username: " + userInfo.Name);
    Console.WriteLine(username + "'s uuid (with dashes): " + userInfo.Uuid);
    Console.WriteLine(username + "'s title: " + userInfo.Title);
    Console.WriteLine(username + "'s rank + color: " + userInfo.RankColor);
    Console.WriteLine(username + "'s token count: " + userInfo.Tokens);
    
    // Print the best winstreaks from the provided username for each gamemode, as well as overall.
    Console.WriteLine(username + "'s best overall winstreak: " + userInfo.Stats.Overall.BestWinstreak);
    Console.WriteLine(username + "'s best solos winstreak: " + userInfo.Stats.Solos.BestWinstreak);
    Console.WriteLine(username + "'s best doubles winstreak: " + userInfo.Stats.Doubles.BestWinstreak);
    Console.WriteLine(username + "'s best threes winstreak: " + userInfo.Stats.Threes.BestWinstreak);
    Console.WriteLine(username + "'s best fours winstreak: " + userInfo.Stats.Fours.BestWinstreak);

    // Print each of the inputted user's favourite maps
    Console.WriteLine(username + "'s favourite maps:");
    // Loop through the list and print each on a new line.
    foreach (var favouriteMap in userInfo.FavoriteMaps)
        Console.WriteLine(favouriteMap);
}
// If the API request failed...
else
{
    // Print the error message to console.
    Console.WriteLine("An error occured: " + userInfoResponse.Cause);
}
