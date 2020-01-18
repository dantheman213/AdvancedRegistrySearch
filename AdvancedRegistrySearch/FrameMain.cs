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
        
        private void listSearch_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listSearch.Items.Count > 0)
            {
                if (CLI.isRegeditRunning())
                {
                    MessageBox.Show("Please close registry editor before attempting to open another key.", "Unable to open another instance of regedit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string key = listSearch.SelectedItems[0].SubItems[0].Text;
                var p1 = CLI.runCommand("REG ADD \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Applets\\Regedit\" /f /v \"LastKey\" /d \"" + key + "\"");
                p1.WaitForExit();

                var p2 = CLI.runCommand("start \"\" regedit");
                p2.WaitForExit();
            }
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
    }
}
