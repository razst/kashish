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
        private async void Form1_Load(object sender, EventArgs e)
        {
            /*
            linkInfo t = new linkInfo();
            t.URL = "git.com";
            t.desc = "best ever";

            var unspecified = DateTime.Now;
            var specified = DateTime.SpecifyKind(unspecified, DateTimeKind.Utc);

            t.startTime = specified;

            DocumentReference docRef = Program.db.Collection("timetable").Document();


            await docRef.SetAsync(t);
            */



            timeTable.Columns.Add("שם סרט", typeof(string));
            timeTable.Columns.Add("תאריך", typeof(string));
            timeTable.Columns.Add("שעה", typeof(string));

            timeTableView.DataSource = timeTable;

            Query capitalQuery = Program.db.Collection("timetable").Limit(100);
            QuerySnapshot capitalQuerySnapshot = await capitalQuery.GetSnapshotAsync();
            foreach (DocumentSnapshot documentSnapshot in capitalQuerySnapshot.Documents)
            {
                linkInfo temp = documentSnapshot.ConvertTo<linkInfo>();

                timeTable.Rows.Add(temp.desc, temp.startTime.ToString("dd/MM/yyyy"), temp.startTime.ToString("HH:mm"));
                //Console.WriteLine("{0} , {1} , {2}",temp.URL,temp.desc,temp.startTime);
            }
            timeTableView.AutoResizeColumns();
        }

        private void ןגיחגע_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
