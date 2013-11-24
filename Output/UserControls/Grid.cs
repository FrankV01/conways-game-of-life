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
    /// Just represent the grid (which itself is
    /// stored in _gridBits)
    /// </summary>
    public partial class Grid : UserControl
    {
        //ICollection<Pixel> _gridPixels;
        protected int _generation;

        IDictionary<Point, Pixel> _gridPixels;
        IDictionary<int, FlowLayoutPanel> _rows;

        private Timer _t;

        private bool[,] _gridBits;
        private int size;

        private int tmp_val = 0;

        public Grid() //We need a default constructor.
        {
            InitializeComponent();

            this.size = 50;
            this._gridBits = new bool[this.size, this.size];

            //_gridPixels = new List<Pixel>();
            this._gridPixels = new Dictionary<Point, Pixel>();
            this._rows = new Dictionary<int, FlowLayoutPanel>();
            
            this.SuspendLayout();
            this.initGrid();
            this.ResumeLayout();

            this._generation = 0;

            _t = new Timer();
            //_t.Tick += OnTick;
            _t.Interval = 1000/4;
        }

        public Timer GenerationTimer
        {
            get
            {
                return this._t;
            }
        }

        public bool[,] GridBits
        {
            get
            {
                return this._gridBits;
            }
            set
            {
                this._gridBits = value;
                this.UpdateGrid(); //I'd perfer to make this an event handler.
            }
        }

        void clearAll()
        {
            foreach (var itm in this._gridPixels)
            {
                itm.Value.State = false;
            }
        }

        //We need to refactor this; we want this to just represent
        // a grid and then pass in a "IDrawer" (new interface concept) or
        // perhaps call it a ICell (new interface concept). The cell can 
        // mutate per the rule and is and the "Grid" can draw it. (Either
        // through an adapter or some other reasonable means.
        //  -> One thought is that the grid will contain multiple cells 
        //     and each cell must be maintained and evolved. So perhaps it's better. 
        //     to not package it as an ICell...
        void OnTick(object sender, EventArgs e)
        {
            //This is a long loop....
            //What I'd like to see is a line painting down. I want to know what that might look like.



            bool[,] _wrk = this.GridBits;

            _wrk[this.tmp_val, this.tmp_val] = false;

            this.tmp_val++;

            if (this.tmp_val >= this.size) this.tmp_val = 0;

            _wrk[this.tmp_val, this.tmp_val] = true; //Should walk it down every quarter second.
            this.GridBits = _wrk;
            _wrk = null;
        }

        public void startDrawing()
        {
            _t.Start();
        }
        public void stopDrawing()
        {
            _t.Stop();
        }

        private void UpdateGrid()
        {
            Point _p = Point.Empty; //Generation will be the row. 
            for (int h = 0; h < this.size; h++) 
            {
                for (int v = 0; v < this.size; v++ )
                {
                    _p = new Point(h, v);
                    this._gridPixels[_p].State = this._gridBits[h,v];
                    _p = Point.Empty;
                }
            }
        }

        /// <summary>
        /// This method is to just do the inital draw. This may not be needed anymore. 
        /// Update grid may be able to take over.
        /// </summary>
        private void initGrid()
        {
            Pixel _px = null;
            FlowLayoutPanel _p = null;
            for (int vertical_row = 0; vertical_row < this.size; vertical_row++)
            {
                //each row, establish a flow panel. 
                _p = new FlowLayoutPanel();
                _p.BackColor = Color.DarkGray;
                _p.Width = this.Width;
                _p.Height = 12;
                _p.Margin = new Padding(0);

                for (int horizontal_row = 0; horizontal_row < this.size; horizontal_row++)
                {
                    _px = new Pixel();
                    _px.State = this._gridBits[vertical_row, horizontal_row];

                    _px.Address = new Point(vertical_row, horizontal_row);

                    _px.MouseHover += delegate(object sender, EventArgs e)
                    {
                        StringBuilder _sb = new StringBuilder("Frank Villasesnor's Game of Life [");
                        _sb.Append("Pixel: ");
                        _sb.Append((sender as Pixel).Address.ToString());
                        _sb.Append("]");

                        this.ParentForm.Text = _sb.ToString();
                        _sb = null;
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
