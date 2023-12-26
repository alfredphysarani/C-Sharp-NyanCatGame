using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CIS329_NyanCatAdv
{
    public partial class LeaderBoard : Form
    {
        // To retrieve class object from game screen
        private gameScreen gameScreen;
        public LeaderBoard(gameScreen parentForm)
        {
            InitializeComponent();
            gameScreen = parentForm;   
        }

        private void LeaderBoard_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'leaderBoardDBDataSet.Table' table. You can move, or remove it, as needed.
            this.tableTableAdapter.Fill(this.leaderBoardDBDataSet.Table);
            tableDataGridView.Sort(tableDataGridView.Columns[2], ListSortDirection.Descending);
            // TODO: This line of code loads data into the 'database1DataSet.Table' table. You can move, or remove it, as needed
            scoreDisplay.Text = "Your Score: " + Convert.ToString(gameScreen.score);
        }

        private void leaderboardSubmit_Click(object sender, EventArgs e)
        {
            DataRow row = this.leaderBoardDBDataSet.Table.NewRow();
            if (nameInput.Text == "")
            {
                row["name"] = "Anonymouns";
            } else
            {
                row["name"] = nameInput.Text;
            }
            
            row["score"] = Convert.ToString(gameScreen.score);
            row["date"] = Convert.ToString(DateTime.Now);
            this.leaderBoardDBDataSet.Table.Rows.Add(row);
            this.Validate();
            this.tableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.leaderBoardDBDataSet);

            leaderboardSubmit.Enabled = false;
        }

        private void tableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.leaderBoardDBDataSet);
        }
    }
}
