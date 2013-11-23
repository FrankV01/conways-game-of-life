using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Output.Data;

namespace Output
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, EventArgs e)
        {
            this.grid1.startDrawing();
        }

        private void stop_Click(object sender, EventArgs e)
        {
            this.grid1.stopDrawing();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            this.comboBox1.Items.Add(new ComboBoxEntry(1, "Glider"));
            this.comboBox1.Items.Add(new ComboBoxEntry(2, "Small Exploder"));
        }


    }
}
