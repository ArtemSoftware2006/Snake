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
        List<int> recordsList = new List<int>();
        private int level;

        public int Level
        {
            get { return level; }
            set { level = value; }
        }

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
            Properties.Settings.Default.First_result = recordsList[0];
            Properties.Settings.Default.Second_result = recordsList[1];
            Properties.Settings.Default.Third_result = recordsList[2];
            Properties.Settings.Default.Fourth_Result = recordsList[3];
            Properties.Settings.Default.Fifth_result = recordsList[4];
            Properties.Settings.Default.Level = level;
            Properties.Settings.Default.Save();
        }
        void LoadRecords()
        {
            recordsList.Add(Properties.Settings.Default.First_result);
            recordsList.Add(Properties.Settings.Default.Second_result);
            recordsList.Add(Properties.Settings.Default.Third_result);
            recordsList.Add(Properties.Settings.Default.Fourth_Result);
            recordsList.Add(Properties.Settings.Default.Fifth_result);
            level = Properties.Settings.Default.Level;
        }
        public void SetRecord(int result)
        {
            for (int i = 0; i < recordsList.Count ; i++)
            {
                if (result > recordsList[i])
                {
                    recordsList.Insert(i, result);
                    recordsList.RemoveAt(recordsList.Count - 1);
                    break;
                }
            }
        }
        public List<int> GetRecords()
        {
            return recordsList;
        }
    }
}
