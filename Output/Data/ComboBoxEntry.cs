using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrankVillasenor.Life.UI.Data
{
    class ComboBoxEntry
    {

        public ComboBoxEntry(int id, string text)
        {
            this.ID = id;
            this.Text = text;
        }

        public int ID { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return this.Text;
        }
    }
}
