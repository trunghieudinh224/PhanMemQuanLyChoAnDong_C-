using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYBANQUANAO
{
    public partial class formGioiThieu : Form
    {
        public formGioiThieu()
        {
            InitializeComponent();

            timerForm.Start();

        }

        public int count = 0;
        //HÀM ĐẾM THỜI GIANN ĐỂ TẮT FORM
        private void timerForm_Tick(object sender, EventArgs e)
        {
            count++;
            if (count == 3)
            {
                this.Close();
            }
        }
    }
}
