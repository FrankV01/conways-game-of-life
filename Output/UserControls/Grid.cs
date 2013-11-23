using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Output.UserControls
{
    public partial class Grid : UserControl
    {
        ICollection<Pixel> _gridPixels;

        public Grid()
        {
            InitializeComponent();
            _gridPixels = new List<Pixel>();
            this.initGrid();
        }

        private void initGrid()
        {
            //Lets start with a 50x50 grid. 
            Pixel _px = null;
            for( int x = 0; x < 36; x++ )
            {
                //each row, establish a flow panel. 
                FlowLayoutPanel _p = new FlowLayoutPanel();
                _p.BackColor = Color.DarkGray;
                //_p.Location = new Point(1*x, 0);
                _p.Width = this.Width;
                _p.Height = 12;
                _p.Margin = new Padding(0);
                for (int y = 0; y < 50; y++)
                {
                    _px = new Pixel();
                    _px.State = false; //Turn off. 

                    _px.Address = new Point(x, y);

                    _px.DoubleClick +=  delegate(object sender, EventArgs e)
                    {
                        MessageBox.Show((sender as Pixel).Address.ToString());
                    };

                    _p.Controls.Add(_px);
                    _gridPixels.Add(_px); //Not sure we need this.
                }
                 
                this.flowLayoutPanel1.Controls.Add(_p);
            }
            
        }
    }
}
