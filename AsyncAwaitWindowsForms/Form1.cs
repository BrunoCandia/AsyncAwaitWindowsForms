using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncAwaitWindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Please wait. Should be 1 second";

            this.Refresh();

            var stringTask = this.CreateStringsForLabel();

            stringTask.Wait();

            label1.Text = stringTask.Result;
        }

        private async Task<string> CreateStringsForLabel()
        {
            var result = "Now done";

            //await Task.Delay(1000);
            await Task.Delay(10000).ConfigureAwait(false);

            return result;
        }

        private async Task<string> DoSomething()
        {
            var result = "test";

            for (int i = 0; i < 10; i++)
            {
                result += result + i.ToString();
            }

            return result;
        }
    }
}
