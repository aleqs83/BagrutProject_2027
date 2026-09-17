using BagrutProject_2027.Models;
namespace BagrutProject_2027.Views;

public partial class GameLibrary : ContentPage
{
	List<Models.Game> games;
	Dictionary<string, GameConsole> gamePlatformDict = new Dictionary<string, GameConsole>()
	{
        { "nintendo_switch", new GameConsole { GameConsoleName = "Nintendo Switch", GameConsoleIcon="nintendo_switch.png"} },
        { "playstation_4", new GameConsole { GameConsoleName = "PlayStation 4", GameConsoleIcon="playstation_4.png" } },
        { "xbox_one", new GameConsole { GameConsoleName = "Xbox One", GameConsoleIcon="xbox_one.png" } },
		{ "pc", new GameConsole { GameConsoleName = "PC", GameConsoleIcon="pc.png" } },
		{ "mobile", new GameConsole { GameConsoleName = "Mobile", GameConsoleIcon = "mobile.png" } }
	};
    public GameLibrary()
	{
		InitializeComponent();

        games = new List<Game>();
		games.Add(new Game { GameId = 1, Title = "The Legend of Zelda: Breath of the Wild", genre = "Action-adventure", GameConsoles = new List<GameConsole> { gamePlatformDict["nintendo_switch"] }, releaseDate = "March 3, 2017", CoverImageURL = "the_legend_of_zelda_breath_of_the_wild.jpg" });
		games.Add(new Game { GameId = 2, Title = "Super Mario Odyssey", genre = "Platform", GameConsoles = new List<GameConsole> { gamePlatformDict["nintendo_switch"] }, releaseDate = "October 27, 2017", CoverImageURL = "super_mario_odyssey.jpg" });
		games.Add(new Game { GameId = 3, Title = "Red Dead Redemption 2", genre = "Action-adventure", GameConsoles = new List<GameConsole> { gamePlatformDict["playstation_4"], gamePlatformDict["xbox_one"], gamePlatformDict["pc"] }, releaseDate = "October 26, 2018", CoverImageURL = "red_dead_red_2.jpg" });
		games.Add(new Game { GameId = 4, Title = "The Witcher 3: Wild Hunt", genre = "Action role-playing", GameConsoles = new List<GameConsole> { gamePlatformDict["playstation_4"], gamePlatformDict["xbox_one"], gamePlatformDict["pc"] }, releaseDate = "May 19, 2015", CoverImageURL = "witcher_3.jpg" });
		games.Add(new Game { GameId = 5, Title = "Minecraft", genre = "Sandbox, survival", GameConsoles = new List<GameConsole> { gamePlatformDict["pc"], gamePlatformDict["nintendo_switch"], gamePlatformDict["mobile"] }, releaseDate = "November 18, 2011", CoverImageURL = "minecraft_cover.png" });

		foreach (var game in games)
		{

			var gameView = new Label
			{
				Text = games.IndexOf(game) + 1 + ". " + game.Title + " (" + game.genre + ") - Released on: " + game.releaseDate + " is on " + string.Join(", ", game.GameConsoles.Select(g => g.GameConsoleName)) ,
            };
            var gameImage = new Image
            {
                Source = game.CoverImageURL,
                HeightRequest = 100,
                WidthRequest = 100,
                Aspect = Aspect.AspectFit
            };

            results.Children.Add(gameView);
            results.Children.Add(gameImage);
        }




    }
}