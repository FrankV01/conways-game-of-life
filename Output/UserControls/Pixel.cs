using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrankVillasenor.Life.Output.UserControls
{
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
