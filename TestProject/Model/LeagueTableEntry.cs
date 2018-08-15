using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestProject.Model
{
    public class LeagueTableEntry
    {
        public int Position { get; set; }

        public string TeamName { get; set; }

        public int Played { get; set; }

        public int Won { get; set; }

        public int Drawn { get; set; }

        public int Lost { get; set; }

        public int GF { get; set; }

        public int GA { get; set; }

        public int GD { get; set; }

        public int Points { get; set; }
    }
}