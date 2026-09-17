using System;
using System.Collections.Generic;
using System.Text;

namespace BagrutProject_2027.Models
{
    internal class Game
    {
        public int GameId{  get; set; }
        public string? Title {  get; set; }
        public string? genre {  get; set; }
        public List<GameConsole>? GameConsoles{  get; set; }
        public string? releaseDate {  get; set; }
        public string?  CoverImageURL {  get; set; }
    }
}
