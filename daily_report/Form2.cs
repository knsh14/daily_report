﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace daily_report
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void show_content(String content)
        {
            //なんか表示できるようなコードを書く
            this.listBox1.Items.Add(content);
        }

        public int get_items_num()
        {
            return this.listBox1.Items.Count;
        }

        public void delete_all_items()
        {
            for (int i = 0; i >= this.listBox1.Items.Count; i++ )
            {
                this.listBox1.Items.RemoveAt(i);
            }
        }
    }
}
