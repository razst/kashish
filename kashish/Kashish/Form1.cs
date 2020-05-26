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
        private void Form1_Load(object sender, EventArgs e)
        {




            timeTable.Columns.Add("שם סרט", typeof(string));
            timeTable.Columns.Add("תאריך", typeof(string));
            timeTable.Columns.Add("שעה", typeof(string));

            timeTableView.DataSource = timeTable;

            showLast();
        }
        private async void showLast()
        {
            timeTable.Rows.Clear();
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

        private async void okBtn_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(datePicker.Value.ToString().Substring(0,11)+hourTxb.Text);

            
            linkInfo t = new linkInfo();
            t.URL = movieTxb.Text+".com";
            t.desc = movieTxb.Text;

            var unspecified = DateTime.Parse(datePicker.Value.ToString().Substring(0, 11) + hourTxb.Text);
            var specified = DateTime.SpecifyKind(unspecified, DateTimeKind.Utc);

            t.startTime = specified;


            DocumentReference docRef = Program.db.Collection("timetable").Document();


            await docRef.SetAsync(t);

            showLast();
        }
    }
}
