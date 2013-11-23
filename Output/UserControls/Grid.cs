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

            this.SuspendLayout();
            this.initGrid();
            this.ResumeLayout();
        }

        private void initGrid()
        {
            //Lets start with a 50x50 grid. 
            Pixel _px = null;
            FlowLayoutPanel _p = null;
            for( int vertical_row = 0; vertical_row < 40; vertical_row++ )
            {
                //each row, establish a flow panel. 
                _p = new FlowLayoutPanel();
                _p.BackColor = Color.DarkGray;
                //_p.Location = new Point(1*x, 0);
                _p.Width = this.Width;
                _p.Height = 12;
                _p.Margin = new Padding(0);

                for (int horizontal_row = 0; horizontal_row < 50; horizontal_row++)
                {
                    _px = new Pixel();
                    _px.State = false; //Turn off. 

                    _px.Address = new Point(vertical_row, horizontal_row);

                    _px.MouseHover += delegate(object sender, EventArgs e)
                    {
                        this.ParentForm.Text = "Pixel: " + (sender as Pixel).Address.ToString();
                    };

                    _px.DoubleClick +=  delegate(object sender, EventArgs e)
                    {
                        MessageBox.Show((sender as Pixel).Address.ToString());
                    };

                    _p.Controls.Add(_px);
                    _gridPixels.Add(_px); //Not sure we need this.
                    _px = null;
                }
                
                this.flowLayoutPanel1.Controls.Add(_p);
                _p = null;
            }
            
        }
    }
}
