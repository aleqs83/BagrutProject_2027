using BagrutProject_2027.Models;
using BagrutProject_2027.Services;
namespace BagrutProject_2027.Views;

public partial class GameLibrary : ContentPage
{
	
    public GameLibrary()
	{
		InitializeComponent();
        // Connect the page to the games stored in DataRepo.
        BindingContext = DataRepo.Games;

    }
}