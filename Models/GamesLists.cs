using System;
using System.Collections.Generic;
using System.Text;

namespace BagrutProject_2027.Models
{
    internal class GamesLists
    {
        public int GameId{  get; set; }
        public string? Title {  get; set; }
        public string? genre {  get; set; }
        public string? Platform {  get; set; }
        public string? releaseDate {  get; set; }
        public string?  CoverImageURL {  get; set; }
    }
}
