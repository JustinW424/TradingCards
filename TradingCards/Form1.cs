using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TradingCards.utility;

namespace TradingCards
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Util.LoadAllPlayers();

            Binding b = new Binding(nameof(TextBox.Text), playerBindingSource, "Score", true, DataSourceUpdateMode.OnPropertyChanged);
            b.Format += (s, e1) =>
            {
                picture.BackColor = int.Parse(e1.Value.ToString()) > 500 ? Color.DarkOrange : Color.DarkGreen;
            };
            score.DataBindings.Add(b);

            foreach (Player player in Util.playersL)
                playerBindingSource.Add(player);
        }

        private void dataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            object player = playerBindingSource.Current;
            Form editForm = new Edit(player);
            DialogResult dialogResult = editForm.ShowDialog();
            if (dialogResult != DialogResult.Cancel)
            {
                var playerlist = from p in Util.playersL
                                 where p.UID == Util.curPlayer.UID
                                 select p;
                foreach (Player p in playerlist)
                {
                    p.Update(Util.curPlayer);
                    playerBindingSource.ResetBindings(false);
                }

                playerlist = from p in Util.playersL
                             orderby p.Name
                             select p;
                Util.SavePlayer(Util.curPlayer);
                playerBindingSource.DataSource = playerlist;
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            Form editForm = new Edit();
            DialogResult dialogResult = editForm.ShowDialog();
            if (dialogResult != DialogResult.Cancel)
            {
                Util.playersL.Add(Util.curPlayer);
                var playerlist = from p in Util.playersL
                             orderby p.Name
                             select p;

                int index = playerlist.ToList().FindIndex(a => a.Name == Util.curPlayer.Name);
                playerBindingSource.DataSource = playerlist;
                playerBindingSource.Position = index;
                Util.SavePlayer(Util.curPlayer);
            }
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            Player player = (Player)playerBindingSource.Current;
            Util.playersL.RemoveAll(x => x.UID == player.UID);
            var playerlist = from p in Util.playersL
                             orderby p.Name
                             select p;
            Util.RemoveFile(player);
            playerBindingSource.DataSource = playerlist;
        }
    }
}
