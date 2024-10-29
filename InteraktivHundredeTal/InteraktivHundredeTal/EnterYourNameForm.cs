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

    public string EnteredName { get; private set; }
    public GameMenuSelectionForm()
    {
      InitializeComponent();
      textBox1.KeyDown += textBox1_KeyDown;
    }

    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        EnteredName = textBox1.Text;
        DialogResult = DialogResult.OK;
        Close();
      }
    }
  }
}
