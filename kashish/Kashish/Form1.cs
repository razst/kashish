using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Firestore;

namespace Kashish
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private DataTable timeTable = new DataTable();
        static public Form1 frm1 = null;
        private void Form1_Load(object sender, EventArgs e)
        {


            frm1 = this;

            timeTable.Columns.Add("שם סרט", typeof(string));
            timeTable.Columns.Add("תאריך", typeof(string));
            timeTable.Columns.Add("שעה", typeof(string));
            timeTable.Columns.Add("ID", typeof(string));

            

            timeTableView.DataSource = timeTable;
            timeTableView.Columns[3].Visible = false;


            showLast();
        }
        public async void showLast()
        {
            timeTable.Rows.Clear();
            Query capitalQuery = Program.db.Collection("timetable").Limit(100).WhereGreaterThanOrEqualTo("startTime",DateTime.Today.ToUniversalTime());
            QuerySnapshot capitalQuerySnapshot = await capitalQuery.GetSnapshotAsync();
            foreach (DocumentSnapshot documentSnapshot in capitalQuerySnapshot.Documents)
            {
                linkInfo temp = documentSnapshot.ConvertTo<linkInfo>();

                timeTable.Rows.Add(temp.name, temp.startTime.ToString("dd/MM/yyyy"), temp.startTime.ToString("HH:mm"), temp.DocID);
                //Console.WriteLine("{0} , {1} , {2}",temp.URL,temp.desc,temp.startTime);
            }
            timeTableView.AutoResizeColumns();
            timeTableView.Sort(timeTableView.Columns["תאריך"], ListSortDirection.Ascending);
        }



        private Form2 f;
        private void timeTableView_DoubleClick(object sender, EventArgs e)
        {
            if (timeTableView.SelectedRows.Count > 0)
            {
                f = new Form2();

                f.ShowData(timeTableView.Rows[timeTableView.SelectedRows[0].Index].Cells[3].Value.ToString());
                f.ShowDialog();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            f = new Form2();

            f.ShowDialog();
        }
    }
}
