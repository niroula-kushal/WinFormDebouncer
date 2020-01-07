using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Debouncer
{
    public partial class Form1 : Form
    {
        Debouncer debouncer;
        private List<string> names = new List<string>
        {
            "Tony Stark",
            "Steve Rogers",
            "Clint Barton",
            "Thor Odinson",
            "Natasha Romanoff",
            "Bruce Banner",
            "Wanda Maximoff",
            "Pietro Maximoff",
            "Sam Wilson",
            "Tchalla",
            "Star Lord",
            "Peter Parker"
        };
        public Form1()
        {
            InitializeComponent();
            debouncer = new Debouncer();
            RenderAvengersTree(names);
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            debouncer.Debounce(PerformSearch, 500);
            void PerformSearch()
            {
                var searchKey = textBox1.Text.Trim().ToLower();
                var matched = names.Where(x => x.ToLower().Contains(searchKey));
                treeView1.Nodes.Clear();
                RenderAvengersTree(matched);
            }
        }

        private void RenderAvengersTree(IEnumerable<string> matched)
        {
            treeView1.Nodes.AddRange(matched.Select(x => new TreeNode()
            {
                Text = x
            }).ToArray());
        }
    }
}
