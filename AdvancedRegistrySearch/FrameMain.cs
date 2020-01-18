using System;
using System.Windows.Forms;

namespace AdvancedRegistrySearch
{
    public partial class FrameMain : Form
    {
        private SearchEngine se;

        public FrameMain()
        {
            InitializeComponent();
        }

        private void FrameMain_Shown(object sender, EventArgs e)
        {
            var f = new FrameLoading();
            f.Show();

            Application.DoEvents();

            se = new SearchEngine();
            se.index();

            f.Close();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string str = textSearch.Text.Trim();
            if (!String.IsNullOrEmpty(str))
            {
                var results = se.getQueryResult(str);
                if (results != null && results.Count > 0)
                {
                    listSearch.Items.Clear();
                    foreach (var item in results)
                    {
                        listSearch.Items.Add(new ListViewItem(new string[] { item.key, item.value }));
                    }
                }
            }
        }

        private void listSearch_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // TODO

        }
    }
}
