using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Fm_main : Form
    {
        Button BackToMenu;
        Label lbRecord;
        Label[] labelRecordsArr;
        RecordstManager records = RecordstManager.GetInstance();
        public Fm_main()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            Fm_game_place f2 = new Fm_game_place();
            WindowState = FormWindowState.Minimized;
            f2.ShowDialog();
        }

        private void buttonRecords_Click(object sender, EventArgs e)
        {
            buttonClose.Visible = false;
            buttonLevelHard.Visible = false;
            buttonRecords.Visible = false;
            buttonStartGame.Visible = false;

           labelRecordsArr = new Label[5];
            for (int i = 0; i < labelRecordsArr.Length; i++)
            {
                labelRecordsArr[i] = new Label();
                labelRecordsArr[i].Location = new Point(120, 76 + i * 32);
                labelRecordsArr[i].AutoSize = true;
                labelRecordsArr[i].Font = new Font("Segoe", 16.0F);
                labelRecordsArr[i].Text = Convert.ToString(i + 1) + ". " + Convert.ToString( records.GetRecords()[i] );
                this.Controls.Add( labelRecordsArr[i] );
            }
            lbRecord = new Label();
            lbRecord.AutoSize = true;
            lbRecord.Location = new Point(84, 36);
            lbRecord.Font = new Font("Segoe", 20.0F);
            lbRecord.Text = "Рекорды";
            this.Controls.Add(lbRecord);

            BackToMenu = new Button();
            BackToMenu.Width = 200;
            BackToMenu.Height = 45;
            BackToMenu.Location = new Point(this.Width / 2 - BackToMenu.Width / 2, labelRecordsArr[labelRecordsArr.Length - 1].Location.Y + 70);
            BackToMenu.BackColor = Color.Gainsboro;
            BackToMenu.Text = "Назад";
            BackToMenu.Click += new EventHandler(this.BackToMenu_click);
            this.Controls.Add(BackToMenu);

        }

        void BackToMenu_click(object sender, EventArgs e)
        {
            foreach (var item in labelRecordsArr)
            {
                item.Dispose();
            }
            BackToMenu.Dispose();
            lbRecord.Dispose();
            buttonClose.Visible = true;
            buttonLevelHard.Visible = true;
            buttonRecords.Visible = true;
            buttonStartGame.Visible = true;
        }
       
    }
}
