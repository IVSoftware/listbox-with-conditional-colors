As I understand it, your question is about changing the color of list box items based on their `MTBF` property for a recordset returned by a SQL query. For purposes of a minimal example, let's say your record class is named `Product` and for testing purposes it will generate a random `MTBF` that is one of {0, 29, 30, or 31}. It will also have a `DisplayColor` property based on the `MTBF` property.

    class Product
    {
        static int _testCount = 0;
        static Random _rando = new Random(100);

        public string Name { get; set; } = $"Item {++_testCount}";
        public int MTBF { get; set; } = mockMTBF();
        public Color DisplayColor =>
            MTBF.Equals(0) ? Color.Red :
            MTBF <= 30 ? Color.YellowGreen : Color.Black;

        public override string ToString() => Name;

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
    }

***
**Simulated SQL Query**

When the [Mock Query] button is clicked, five new Product records will be generated and placed in the list box.

[![screenshot][1]][1]

    private void onClickMockQuery(object sender, EventArgs e)
    {
        Product[] recordset =
            Enumerable.Range(0, 5)
            .Select(_ => new Product())
            .ToArray();

        listBox.Items.Clear();
        listBox.Items.AddRange(recordset);
    }

***
**ListBox Owner Draw**

The main form ctor sets the `listBox.DrawMode` to `OwnerDrawFixed` and borrows from this Microsoft [code example](https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.listbox.drawitem) to render the text according to the `DisplayColor` property of `Product`. 

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
        .
        .
        .
    }


  [1]: https://i.stack.imgur.com/dokz4.png