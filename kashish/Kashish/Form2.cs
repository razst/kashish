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
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void UrlTxb_TextChanged(object sender, EventArgs e)
        {

        }

        private async void movieTxb_TextChanged(object sender, EventArgs e)
        {
            
            DocumentReference docRef = Program.db.Collection("timetable").Document();
            DocumentSnapshot docSnep = await docRef.GetSnapshotAsync();

            linkInfo li = docSnep.ConvertTo<linkInfo>();

        }
    }
}
