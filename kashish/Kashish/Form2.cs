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
    public partial class Form2 : Form
    {
        private string givenId = "";
        public async void ShowData(String docID)
        {

            DocumentReference docRef = Program.db.Collection("timetable").Document(docID);
            DocumentSnapshot docSnep = await docRef.GetSnapshotAsync();

            linkInfo li = docSnep.ConvertTo<linkInfo>();

            UrlTxb.Text = li.URL;
            movieTxb.Text = li.name;
            DeskTxb.Text = li.desk;
            hourTxb.Text = li.startTime.ToString("HH:mm");
            datePicker.Value = li.startTime;

            givenId = docID;
        }

        public Form2()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(datePicker.Value.ToString().Substring(0,11)+hourTxb.Text);
            if (UrlTxb.Text == "" || movieTxb.Text == "" || DeskTxb.Text == "" || hourTxb.Text == "")
            {
                MessageBox.Show("נא למלא את כל השדות");
                return;
            }

            linkInfo t = new linkInfo();
            t.URL = UrlTxb.Text;
            t.name = movieTxb.Text;
            t.desk = DeskTxb.Text;

            var unspecified = DateTime.Parse(datePicker.Value.ToString().Substring(0, 11) + hourTxb.Text);
            var specified = DateTime.SpecifyKind(unspecified, DateTimeKind.Utc);

            t.startTime = specified;

            DocumentReference docRef = null;

            if (givenId == "")
            {
                docRef = Program.db.Collection("timetable").Document();
            }
            else
            {
                docRef = Program.db.Collection("timetable").Document(givenId);
            }


            await docRef.SetAsync(t);

            Form1.frm1.showLast();

            this.Close();
        }

        private async void urlBtn_Click(object sender, EventArgs e)
        {
            await Task.Run(() => {
                try
                {
                    System.Diagnostics.Process.Start(UrlTxb.Text);
                }
                catch
                {
                }
            });  
        }
    }
}
