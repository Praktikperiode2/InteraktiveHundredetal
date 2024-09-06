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
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      InitializeTimerEvent();
      InitializeKeyPressEvents();
      ResetGameTimer();
      NyOpgave();
    }

    private void InitializeKeyPressEvents()
    {
      textBox_AddOne.KeyPress += textBox_KeyPress;
      textBox_AddTen.KeyPress += textBox_KeyPress;
      // ... og så videre for de resterende textboxes
    }

    private int remainingSeconds = 35; // Start med 60 sekunder

    private void InitializeTimerEvent()
    {
      timer1.Interval = 1000; // 1 sekund
      timer1.Tick += Timer1_Tick;
      timer1.Start();
    }

    private void ResetGameTimer()
    {
      timer2_resetGame.Interval = 5000; // 5 sekund
      timer2_resetGame.Tick += ResetGame;
    }


    //private Timer timer1 = new Timer();

    private void Timer1_Tick(object sender, EventArgs e)
    {
      remainingSeconds--;
      label1.Text = $"{remainingSeconds} sekunder tilbage";

      if (remainingSeconds <= 0)
      {
        timer1.Stop();
        SetAllTextBoxsReadOnlyStateTo(true);
        DialogResult result = MessageBox.Show("Tiden er udløbet!\nØnsker du at prøve igen?", "Prøv igen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.No) Environment.Exit(1);

        ResetGame();
      }
    }

    private void ResetGame()
    {
      SetAllTextBoxsReadOnlyStateTo(false);
      remainingSeconds = 60;
      timer1.Start();
      NyOpgave();
    }

    private void SetAllTextBoxsReadOnlyStateTo(bool result)
    {
      textBox_AddTen.ReadOnly = result;
      textBox_Add20.ReadOnly = result;
      textBox_AddOne.ReadOnly = result;
      textBox_AddTwo.ReadOnly = result;

      textBox_SubTen.ReadOnly = result;
      textBox_Sub20.ReadOnly = result;
      textBox_SubOne.ReadOnly = result;
      textBox_SubTwo.ReadOnly = result;
    }

    private void textBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      // Tillad kun tal og backspace
      if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
      {
        e.Handled = true;
      }
    }

    private void NyOpgave()
    {

      var logic = new LogicHundredeTal();
      Label_Center.Text = logic.GetNewCenterNumber();

      // Nulstil farver til brugerinput
      ResetColorToWhite();

      // Nulstil tekstfelter til brugerinput
      textBox_AddTen.Text = "";
      textBox_Add20.Text = "";
      textBox_AddOne.Text = "";
      textBox_AddTwo.Text = "";
    }

    private void buttonCheckAnswer_Click(object sender, EventArgs e)
    {
      // Tjek om brugerens svar er korrekte
      // ... (Implementer logikken her)
      // Vis en besked til brugeren om, hvor mange svar der var korrekte
      timer1.Stop();
      CheckAnswers();
      timer2_resetGame.Start();
    }

    private void CheckAnswers()
    {

      var succes = textBox_AddTen.Text == (Int32.Parse(Label_Center.Text) + 10).ToString();
      SetBackColorBasedOnAnswer(textBox_AddTen, succes);

      succes = textBox_Add20.Text == (Int32.Parse(Label_Center.Text) + 20).ToString();
      SetBackColorBasedOnAnswer(textBox_Add20, succes);

      succes = textBox_AddOne.Text == (Int32.Parse(Label_Center.Text) + 1).ToString();
      SetBackColorBasedOnAnswer(textBox_AddOne, succes);

    }

    private void SetBackColorBasedOnAnswer(TextBox textBox, bool correctAnswer)
    {
      if (correctAnswer)
      {
        textBox.BackColor = Color.Green;
      }
      else
      {
        textBox.BackColor = Color.Red;
      }
    }

    private void ResetGame(object sender, EventArgs e)
    {
      remainingSeconds = 35;
      NyOpgave();
      timer2_resetGame.Stop();
      timer1.Start();
      //
    }

    private void ResetColorToWhite()
    {
      textBox_AddTen.BackColor = Color.White;
      textBox_Add20.BackColor = Color.White;
      textBox_AddOne.BackColor = Color.White;
      textBox_AddTwo.BackColor = Color.White;

      textBox_SubTen.BackColor = Color.White;
      textBox_Sub20.BackColor = Color.White;
      textBox_SubOne.BackColor = Color.White;
      textBox_SubTwo.BackColor = Color.White;
    }
  }
}
