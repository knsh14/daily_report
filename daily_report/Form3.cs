using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Timers;

namespace daily_report
{
    public partial class Form3 : Form
    {

        String history_file;


        public Form3(int x, int y, int width)
        {
            InitializeComponent();

            //このフォームを表示するときに本体とかぶらないように開始位置を指定する
            this.StartPosition = FormStartPosition.Manual;
            this.DesktopLocation = new Point((int)Math.Ceiling(x + width * 1.1), y);

            this.history_file = "C:\\Users\\kenshi\\Documents\\versioning_area\\daily_report\\daily_report\\history_data\\History_1";
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + this.history_file))
            {
                conn.Open();
                using (SQLiteCommand command = conn.CreateCommand())
                {

                    long ticks = (DateTime.Parse(DateTime.Now.AddDays(-80).ToString("yyyy/MM/dd"))).Ticks - DateTime.Parse("01/01/1970 00:00:00").Ticks;
                    //ticks /= 10000000; //Convert windows ticks to seconds
                    string timestamp = ticks.ToString();
                   //MessageBox.Show(timestamp);
                    //command.CommandText = "select distinct title from urls";// where last_visit_time > " + timestamp;
                    command.CommandText = "select distinct last_visit_time from urls";
                    //command.CommandText = "select distinct title from urls where title like '%google 検索%' AND last_visit_time > " + timestamp;
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //this.listBox1.Items.Add(reader["title"].ToString().Replace(" - Google 検索", ""));
                            this.listBox1.Items.Add((new TimeSpan(0,0,(int)reader["last_visit_time"])).ToString());
                        }
                    }
                }
                conn.Close();
            }
        }

    }
}
