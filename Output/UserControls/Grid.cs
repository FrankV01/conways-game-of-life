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
            Pixel _p = null;
            for( int x = 0; x < 36; x++ )
            {
                for (int y = 0; y < 2; y++)
                {
                    _p = new Pixel();
                    _p.State = false; //Turn off. 

                    _p.Address = new Point(x, y);

                    _p.DoubleClick +=  delegate(object sender, EventArgs e)
                    {
                        MessageBox.Show((sender as Pixel).Address.ToString());
                    };
                    this.flowLayoutPanel1.Controls.Add(_p);
                    _gridPixels.Add(_p);
                }
            }
            //this.flowLayoutPanel1.Controls.AddRange(_gridPixels.ToArray());
        }
    }
}
