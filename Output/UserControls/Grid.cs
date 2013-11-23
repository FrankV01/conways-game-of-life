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
        //ICollection<Pixel> _gridPixels;
        protected int _generation;

        IDictionary<Point, Pixel> _gridPixels;
        IDictionary<int, FlowLayoutPanel> _rows;

        Timer _t;

        const int PIXELS_PER_LINE = 50;
        const int LINES_OF_PIXELS = 40;

        public Grid()
        {
            InitializeComponent();
            //_gridPixels = new List<Pixel>();
            this._gridPixels = new Dictionary<Point, Pixel>();
            this._rows = new Dictionary<int, FlowLayoutPanel>();
            
            this.SuspendLayout();
            this.initGrid();
            this.ResumeLayout();

            this._generation = 0;

            _t = new Timer();
            _t.Tick += OnTick;
            _t.Interval = 1000/4;
        }

        void clearAll()
        {
            foreach (var itm in this._gridPixels)
            {
                itm.Value.State = false;
            }
        }

        void OnTick(object sender, EventArgs e)
        {
            //This is a long loop....
            //What I'd like to see is a line painting down. I want to know what that might look like.

            this.clearAll();

            Point _p = Point.Empty; //Generation will be the row. 
            for (int i = 0; i < PIXELS_PER_LINE; i++)
            {
                _p = new Point(this._generation, i);
                this._gridPixels[_p].State = true;
                _p = Point.Empty;
            }
            this._generation++;
            if (this._generation > LINES_OF_PIXELS-1) this._generation = 0;
        }

        public void startDrawing()
        {
            _t.Start();
        }
        public void stopDrawing()
        {
            _t.Stop();
        }

        private void initGrid()
        {
            //Lets start with a 50x50 grid. 
            Pixel _px = null;
            FlowLayoutPanel _p = null;
            for (int vertical_row = 0; vertical_row < LINES_OF_PIXELS; vertical_row++)
            {
                //each row, establish a flow panel. 
                _p = new FlowLayoutPanel();
                _p.BackColor = Color.DarkGray;
                //_p.Location = new Point(1*x, 0);
                _p.Width = this.Width;
                _p.Height = 12;
                _p.Margin = new Padding(0);

                for (int horizontal_row = 0; horizontal_row < PIXELS_PER_LINE; horizontal_row++)
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
                    this._gridPixels.Add(_px.Address, _px);
                    _px = null;
                }
                
                this.flowLayoutPanel1.Controls.Add(_p);
                _p = null;
            }
            
        }
    }
}
