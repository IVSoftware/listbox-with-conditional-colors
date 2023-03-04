using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace listbox_with_conditional_colors
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            listBox.DrawMode= DrawMode.OwnerDrawFixed;
            listBox.DrawItem += onDrawItem;
            buttonMockQuery.Click += onClickMockQuery;
        }

        private void onDrawItem(object sender, DrawItemEventArgs e)
        {
            if ((sender is ListBox listBox) && !e.Index.Equals(-1))
            {
                e.DrawBackground();
                Product product = (Product)listBox.Items[e.Index];
                using (Brush brush = new SolidBrush(product.DisplayColor))
                {
                    e.Graphics.DrawString(listBox.Items[e.Index].ToString(),
                        e.Font, brush, e.Bounds, StringFormat.GenericDefault);
                }
            }
        }

        private void onClickMockQuery(object sender, EventArgs e)
        {
            Product[] recordset =
                Enumerable.Range(0, 5)
                .Select(_ => new Product())
                .ToArray();

            listBox.Items.Clear();
            listBox.Items.AddRange(recordset);
        }
    }
    class Product
    {
        static int _testCount = 0;

        static Random _rando = new Random(100);
        public string Name { get; set; } = $"Item {++_testCount}";
        public int MTBF { get; set; } = mockMTBF();

        private static int mockMTBF()
        {
            int randNext = _rando.Next(29, 33);
            switch (randNext)
            {
                case 29:
                case 30:
                case 31:
                    return randNext;
                case 32:
                    return 0;
                default:
                    throw new NotImplementedException();
            }
        }

        public Color DisplayColor =>
            MTBF.Equals(0) ? Color.Red :
            MTBF <= 30 ? Color.YellowGreen : Color.Black;

        public override string ToString() => Name;
    }
}
