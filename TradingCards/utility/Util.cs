using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCards.utility
{
    static public class Util
    {
        static void WriteXML(Player player, string path)
        {
            XmlSerializer writer =
                new XmlSerializer(typeof(Player));
            FileStream file = File.Create(path);
            writer.Serialize(file, player);
            file.Close();
        }

        static Player ReadXML(string path)
        {
            XmlSerializer reader = new XmlSerializer(typeof(Player));
            StreamReader file = new StreamReader(path);
            Player player = (Player)reader.Deserialize(file);
            file.Close();
            return player;
        }

        static public string PATH = Path.Combine(Directory.GetCurrentDirectory(), "data");

        static public List<Player> playersL = new List<Player>();

        static public Player curPlayer = new Player();
        static public void LoadAllPlayers()
        {
            try
            {
                string[] w_list = Directory.GetFiles(PATH, "*.xml");
                foreach (string file in w_list)
                {
                    Player player = ReadXML(file);
                    playersL.Add(player);
                }
            }
            catch { }
        }
        static public void SavePlayer(Player player)
        {
            if (!Directory.Exists(PATH))
                Directory.CreateDirectory(PATH);
            string path = Path.Combine(PATH, $"{player.Name}.xml");
            WriteXML(player, path);
        }

        static public void RemoveFile(Player player)
        {
            try
            {
                string path = Path.Combine(PATH, $"{player.Name}.xml");
                File.Delete(path);
            }
            catch { }
        }
    }
}
