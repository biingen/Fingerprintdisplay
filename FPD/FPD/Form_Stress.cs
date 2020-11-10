using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static FPD.Form_Display;

namespace FPD
{
    public partial class Form_Stress : Form
    {
        public Form_Stress()
        {
            InitializeComponent();
            Viewer.SetPalette();

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            int testitem = comboBox_Testitem.SelectedIndex;
            int delaytime = Int16.Parse(textBox_delay.Text);
            int times = Int32.Parse(textBox_Times.Text);

        }
    }
}
