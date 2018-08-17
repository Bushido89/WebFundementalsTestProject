using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace TestProject.Model
{
    public class DigitalProfile
    {
        public string Name { get; set; }

        public Sport FavouriteSport { get; set; }

        public string[] LastFiveProjects { get; set; }

        public string[] InterestingFacts { get; set; }

        public string[] FavouriteFood { get; set; }

        public CustomImage PersonalImage { get; set; }

        public CustomClip AudioClip { get; set; }

        public class CustomImage
        {

        }

        public class CustomClip
        {

        }

        public enum Sport
        {
            Football,
            Rugby,
            MMA,
            Cricket
        }
    }
}