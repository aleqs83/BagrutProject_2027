namespace BagrutProject_2027.Views;

public partial class GameLibrary : ContentPage
{
	public GameLibrary()
	{
		InitializeComponent();

		List<Models.GamesLists> games = new List<Models.GamesLists>();
		games.Add(new Models.GamesLists { GameId = 1, Title = "The Legend of Zelda: Breath of the Wild", genre = "Action-adventure", Platform = "Nintendo Switch", releaseDate = "March 3, 2017", CoverImageURL = "the_legend_of_zelda_breath_of_the_wild.jpg" });
		games.Add(new Models.GamesLists { GameId = 2, Title = "Super Mario Odyssey", genre = "Platform", Platform = "Nintendo Switch", releaseDate = "October 27, 2017", CoverImageURL = "super_mario_odyssey.jpg" });
		games.Add(new Models.GamesLists { GameId = 3, Title = "Red Dead Redemption 2", genre = "Action-adventure", Platform = "PlayStation 4, Xbox One, PC", releaseDate = "October 26, 2018", CoverImageURL = "red_dead_red_2.jpg" });
		games.Add(new Models.GamesLists { GameId = 4, Title = "The Witcher 3: Wild Hunt", genre = "Action role-playing", Platform = "PlayStation 4, Xbox One, PC", releaseDate = "May 19, 2015", CoverImageURL = "witcher_3.jpg" });
		games.Add(new Models.GamesLists { GameId = 5, Title = "Minecraft", genre = "Sandbox, survival", Platform = "PC, consoles, mobile", releaseDate = "November 18, 2011", CoverImageURL = "minecraft_cover.png" });


    }
}