using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCards.utility
{
    [Serializable]
    public class Player
    {
        public Player()
        {
            UID = Guid.NewGuid().ToString();
            Image = string.Empty;
            Name = string.Empty;
            SunSign = string.Empty;
            Team = string.Empty;
            BirthDate = string.Empty;
            BirthPlace = string.Empty;
            Height = string.Empty;
            Score = "0";
            Description = string.Empty;
        }

        public Player(Player p)
        {
            this.UID = p.UID;
            this.Image = p.Image;
            this.Name = p.Name;
            this.SunSign = p.SunSign;
            this.Team = p.Team;
            this.BirthDate = p.BirthDate;
            this.BirthPlace = p.BirthPlace;
            this.Height = p.Height;
            this.Score = p.Score;
            this.Description = p.Description;
        }

        public void Update(Player p)
        {
            this.Image = p.Image;
            this.Name = p.Name;
            this.SunSign = p.SunSign;
            this.Team = p.Team;
            this.BirthDate = p.BirthDate;
            this.BirthPlace = p.BirthPlace;
            this.Height = p.Height;
            this.Score = p.Score;
            this.Description = p.Description;
        }
        public string UID { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string SunSign { get; set; }
        public string Team { get; set; }
        public string BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string Height { get; set; }
        public string Score { get; set; }
        public string Description { get; set; }
    } 
}
