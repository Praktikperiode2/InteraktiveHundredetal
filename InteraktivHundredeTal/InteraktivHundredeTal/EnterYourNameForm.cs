using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InteraktivHundredeTal
{
    public partial class GameMenuSelectionForm : Form
    {
        UserProfileDto _userProfile;
        public string EnteredName { get; private set; }
        public GameMenuSelectionForm()
        {
            InitializeComponent();
            textBox1.KeyDown += textBox1_KeyDown;
            _userProfile = new UserProfileDto();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InteraktivHundredetal_btn_Click(sender, e);
            }
        }

        private void InteraktivHundredetal_btn_Click(object sender, EventArgs e)
        {
            var hundredetalForm = new Form1(_userProfile, () => { Show(); });
            this.Hide();
            hundredetalForm.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _userProfile.UserName = textBox1.Text;
        }
    }
}
