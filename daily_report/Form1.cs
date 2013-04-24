using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace daily_report
{
    public partial class Form1 : Form
    {
        today_report today;
        public Form1()
        {
            InitializeComponent();
            this.today = new today_report();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "")//一応入力のチェックはする
            {
                MessageBox.Show("なんもしてねえのかよ！");
            }
            else
            {
                this.today.add_content(this.textBox1.Text);
            }

            this.textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter w = new StreamWriter("path\\to\\directory" + DateTime.Now.ToString("yyyymmdd") + "_daily_report.txt");
            w.WriteLine(this.today.report());
            w.Close();
            MessageBox.Show("出力しました！");
        }
    }

    //今日なにしたかをまとめておくクラス
    public class today_report
    {
        what_i_did[] contents;

        public today_report()
        {
            this.contents = new what_i_did[0];
        }

        public void add_content(String contents)
        {
            int length = this.contents.Length;
            Array.Resize(ref this.contents, length+1);
            this.contents[length] = new what_i_did(contents);

        }

        public string report()
        {
            string rtn_str = "";

            foreach(what_i_did content in this.contents)
            {
                rtn_str += content.show_what_did();
            }

            return rtn_str;
        }
    }

    //この時間に何をしたか，時間とした内容をまとめておくクラス
    public class what_i_did
    {
        String content;
        DateTime dt;

        public what_i_did(String input_content)
        {
            this.content = input_content;
            dt = DateTime.Now;
        }

        public String show_what_did()
        {
            return this.dt.ToString("yyyy年MM月dd日 HH時mm分ss秒 :: ") + this.content + "\n";
        }
    }
}
