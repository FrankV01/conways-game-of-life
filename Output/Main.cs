using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrankVillasenor.Life.Output.Data;
using FrankVillasenor.Life.ProcessingEngine.Cells;

namespace FrankVillasenor.Life.Output
{
    public partial class Main : Form
    {
        const int GRID_SIZE = 50;

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
            this.cbCellList.Items.Add(new ComboBoxEntry(0, "Simple Custom [Flipping Line]"));
            this.cbCellList.Items.Add(new ComboBoxEntry(1, "Glider"));
            this.cbCellList.Items.Add(new ComboBoxEntry(2, "Small Exploder"));
        }

        private void cbCellList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ICell _cell = null ;
            ComboBox cb = (sender as ComboBox);
            ComboBoxEntry entry = (cb.SelectedItem as ComboBoxEntry);

            switch (entry.ID)
            {
                case 0:
                    _cell = new SimpleCustomCell(GRID_SIZE);
                    break;
                case 1:
                    _cell = new GliderCell(GRID_SIZE);
                    break;

                case 2:
                    _cell = new SmallExploderCell(GRID_SIZE);
                    break;
                default:
                    break;
            }
            if( _cell != null ) this.grid1.GridBits = _cell.ToGrid();
        }


    }
}
