using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

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

            this.history_file = "path\\to\\history\\file";
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + this.history_file))
            {
                conn.Open();
                using (SQLiteCommand command = conn.CreateCommand())
                {
                    command.CommandText = "select distinct title from urls where title like '%google 検索%'";
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            this.listBox1.Items.Add(reader["title"].ToString().Replace(" - Google 検索", ""));
                        }
                    }
                }
                conn.Close();
            }
        }

    }
}
