using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Snake
{
    class RecordstManager
    {
        List<int> RecordsList = new List<int>();
        static RecordstManager resManager;
        protected RecordstManager() 
        {
            LoadRecords();
        }
        ~RecordstManager()
        {
            UpdatingRecords();
        }
        static public RecordstManager GetInstance()
        {
            if (resManager == null)
            {
                resManager = new RecordstManager();
            }
            return resManager;
        }
         public void UpdatingRecords()
        {
            Properties.Settings.Default.First_result = RecordsList[0];
            Properties.Settings.Default.Second_result = RecordsList[1];
            Properties.Settings.Default.Third_result = RecordsList[2];
            Properties.Settings.Default.Fourth_Result = RecordsList[3];
            Properties.Settings.Default.Fifth_result = RecordsList[4];
            Properties.Settings.Default.Save();
        }
        void LoadRecords()
        {
            RecordsList.Add(Properties.Settings.Default.First_result);
            RecordsList.Add(Properties.Settings.Default.Second_result);
            RecordsList.Add(Properties.Settings.Default.Third_result);
            RecordsList.Add(Properties.Settings.Default.Fourth_Result);
            RecordsList.Add(Properties.Settings.Default.Fifth_result);
        }
        public void SetRecord(int result)
        {
            for (int i = 0; i < RecordsList.Count ; i++)
            {
                if (result > RecordsList[i])
                {
                    RecordsList.Insert(i, result);
                    RecordsList.RemoveAt(RecordsList.Count - 1);
                    break;
                }
            }
        }
        public List<int> GetRecords()
        {
            return RecordsList;
        }
    }
}
