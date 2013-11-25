/**
 * This file is part of "FrankVillasenor.Life"
 * A "Conway's Game of Life" Implementation - http://en.wikipedia.org/wiki/Conway's_Game_of_Life
 * Copyright (C) 2013  Frank Villasenor <frank.villasenor[at]gmail[dot]com>
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *  
 * You should have received a copy of the GNU General Public License
 * along with this program as COPYING.txt.  If not, see
 * <http://www.gnu.org/licenses/>.
 **/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrankVillasenor.Life.UI.Data;
using FrankVillasenor.Life.ProcessingEngine.Cells;
using FrankVillasenor.Life.ProcessingEngine.Transitions;

namespace FrankVillasenor.Life.UI
{
    public partial class Main : Form
    {
        const int GRID_SIZE = 50;
        CellTransitionImpl _cti;

        int generation = 0;

        public Main()
        {
            InitializeComponent();

            _cti = new CellTransitionImpl();
            this.grid1.GenerationTimer.Tick += delegate(object s, EventArgs e1)
            {
                this.grid1.GridBits = _cti.ApplyTransition(this.grid1.GridBits);
                this.lblGenNum.Text = (generation++).ToString();
            };
        }

        private void start_Click(object sender, EventArgs e)
        {
            this.cbCellList.Enabled = false;
            this.grid1.startDrawing();
        }

        private void stop_Click(object sender, EventArgs e)
        {
            this.cbCellList.Enabled = true;
            this.grid1.stopDrawing();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            // Credit: These "starting" cells are borrowed from http://www.bitstorm.org/gameoflife/
            this.cbCellList.Items.Add(new ComboBoxEntry(0, "Simple Custom [Flipping Line]"));
            this.cbCellList.Items.Add(new ComboBoxEntry(1, "Glider"));
            this.cbCellList.Items.Add(new ComboBoxEntry(2, "Small Exploder"));
            this.cbCellList.Items.Add(new ComboBoxEntry(3, "Exploder"));
            this.cbCellList.Items.Add(new ComboBoxEntry(4, "Ten Cell Row"));

            this.cbCellList.Items.Add(new ComboBoxEntry(5, "Tumbler"));
            this.cbCellList.Items.Add(new ComboBoxEntry(6, "Gosper Glider Gun"));
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
                    _cell = new SmallExploderCell(GRID_SIZE, 20);
                    break;

                case 3:
                    _cell = new ExploderCell(GRID_SIZE, 20);
                    break;

                case 4:
                    _cell = new TenCellRowCell(GRID_SIZE, 20);
                    break;

                case 5:
                    _cell = new TumblerCell(GRID_SIZE, 20);
                    break;

                case 6:
                    _cell = new GosperGliderGunCell(GRID_SIZE, 7);
                    break;

                default:
                    break;
            }
            if (_cell != null)
            {
                this.grid1.GridBits = _cell.ToGrid();
                this.generation = 0;
                this.lblGenNum.Text = generation.ToString();
            }
        }


    }
}
