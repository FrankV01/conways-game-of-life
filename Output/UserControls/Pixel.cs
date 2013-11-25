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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrankVillasenor.Life.UI.UserControls
{
    /// <summary>
    /// Represents a pixel in a grid. A pixel 
    /// is the UI component for a Cell.
    /// </summary>
    public partial class Pixel : UserControl
    {
        /// <summary>
        /// Fired when the state is changed.
        /// </summary>
        public event EventHandler StateChanged;

        private bool _state;

        private Point _address;

        public Pixel()
        {
            InitializeComponent();

            StateChanged += Pixel_StateChanged;
            this.BackColor = Color.White;
        }

        public Point Address
        {
            get
            {
                return this._address;
            }
            set
            {
                this._address = value;
            }
        }

        private void Pixel_StateChanged(object sender, EventArgs e)
        {
            if (this.State)
            {
                this.BackColor = Color.DarkBlue;
            }
            else
            {
                this.BackColor = Color.White;
            }
        }

        #region [ Properties ]

        /// <summary>
        /// Accessor to the State of the pixcel; changing this
        /// triggers the StateChanged event handler.
        /// </summary>
        public bool State
        {
            get
            {
                return this._state;
            }
            set
            {
                this._state = value;
                this.OnStateChanged(new EventArgs());
            }
        }


        #endregion
        protected virtual void OnStateChanged(EventArgs e)
        {
            if (StateChanged != null)
                StateChanged(this, e);
        }
    }
}
