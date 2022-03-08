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
    public partial class Edit : Form
    {
        private Player g_player = new Player();
        private bool isNew;
        public Edit()
        {
            InitializeComponent();
            InitBinding();
            bindingSource.Add(g_player);
            bindingSource.Position = 0;
        }

        private void InitBinding()
        {
            card.DataBindings.Add(nameof(TextBox.Text), bindingSource, "Image", true, DataSourceUpdateMode.OnPropertyChanged);
            name.DataBindings.Add(nameof(TextBox.Text), bindingSource, "Name", true, DataSourceUpdateMode.OnPropertyChanged);
            team.DataBindings.Add(nameof(TextBox.Text), bindingSource, "Team", true, DataSourceUpdateMode.OnPropertyChanged);
            birthDate.DataBindings.Add(nameof(TextBox.Text), bindingSource, "BirthDate", true, DataSourceUpdateMode.OnPropertyChanged);
            birthPlace.DataBindings.Add(nameof(TextBox.Text), bindingSource, "BirthPlace", true, DataSourceUpdateMode.OnPropertyChanged);
            sunSign.DataBindings.Add(nameof(TextBox.Text), bindingSource, "SunSign", true, DataSourceUpdateMode.OnPropertyChanged);
            description.DataBindings.Add(nameof(TextBox.Text), bindingSource, "Description", true, DataSourceUpdateMode.OnPropertyChanged);
            height.DataBindings.Add(nameof(NumericUpDown.Text), bindingSource, "Height", true, DataSourceUpdateMode.OnPropertyChanged);
            score.DataBindings.Add(nameof(NumericUpDown.Text), bindingSource, "Score", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        public Edit(object _player)
        {
            g_player = new Player((Player)_player);
            InitializeComponent();
            InitBinding();
            bindingSource.Add(g_player);
            bindingSource.Position = 0;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Util.curPlayer = g_player;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = card.Text;
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
                card.Text = openFileDialog.FileName;
        }
    }
}
