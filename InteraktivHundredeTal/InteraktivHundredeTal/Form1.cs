﻿using System;
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
      _logicNumberGenerator = new LogicHundredeTal();
      InitializeTimerEvent();
      InitializeKeyPressEvents();
      ResetGameTimer();
      NewGame();
    }
    LogicHundredeTal _logicNumberGenerator = null;
    private const int _gameTime = 120;
    private int _remainingSeconds = _gameTime;
    private bool _inGame = true;
    private void InitializeKeyPressEvents()
    {
      textBox_AddOne.KeyPress += textBox_KeyPress;
      textBox_AddTwo.KeyPress += textBox_KeyPress;
      textBox_AddTen.KeyPress += textBox_KeyPress;
      textBox_Add20.KeyPress += textBox_KeyPress;

      textBox_SubOne.KeyPress += textBox_KeyPress;
      textBox_SubTen.KeyPress += textBox_KeyPress;
      textBox_SubOne.KeyPress += textBox_KeyPress;
      textBox_SubTen.KeyPress += textBox_KeyPress;
      // ... og så videre for de resterende textboxes
    }

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

    private void Timer1_Tick(object sender, EventArgs e)
    {
      _remainingSeconds--;
      label1.Text = $"{_remainingSeconds} sekunder tilbage";

      if (_remainingSeconds <= 0)
      {
        CheckAnswers();
        DialogResult result = MessageBox.Show("Tiden er udløbet!\nØnsker du at prøve igen?", "Prøv igen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.No) Environment.Exit(1);

        ResetGame();
      }
    }

    private void ResetGame()
    {
      timer2_resetGame.Stop();
      _remainingSeconds = _gameTime;
      timer1.Start();
      NewGame();
      SetAllTextBoxesReadOnly(false);
    }

    private void ResetGame(object sender, EventArgs e)
    {
      ResetGame();
    }

    private void SetAllTextBoxesReadOnly(bool result)
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

    private void NewGame()
    {
      Label_Center.Text = _logicNumberGenerator.GetNewNumber();

      // Nulstil farver til brugerinput
      SeTextBoxBackColor(Color.White);

      // Nulstil tekstfelter til brugerinput
      textBox_AddTen.Text = "";
      textBox_Add20.Text = "";
      textBox_AddOne.Text = "";
      textBox_AddTwo.Text = "";

      textBox_SubTen.Text = "";
      textBox_Sub20.Text = "";
      textBox_SubOne.Text = "";
      textBox_SubTwo.Text = "";
    }

    private void buttonCheckAnswer_Click(object sender, EventArgs e)
    {
      // Tjek om brugerens svar er korrekte
      // ... (Implementer logikken her)
      // Vis en besked til brugeren om, hvor mange svar der var korrekte
      CheckAnswers();
      timer2_resetGame.Start();
    }

    private void CheckAnswers()
    {
      // Set all text boxes to read-only state
      SetAllTextBoxesReadOnly(true);

      // Stop the timer
      timer1.Stop();

      // Check answers for all eight and place them in a list 
      var answers = new Dictionary<TextBox, bool>()
      {
        { textBox_AddTen, _logicNumberGenerator.IsCorrectAddition(textBox_AddTen.Text, 10) },
        { textBox_Add20, _logicNumberGenerator.IsCorrectAddition(textBox_Add20.Text, 20) },
        { textBox_AddOne, _logicNumberGenerator.IsCorrectAddition(textBox_AddOne.Text, 1) },
        { textBox_AddTwo, _logicNumberGenerator.IsCorrectAddition(textBox_AddTwo.Text, 2) },

        { textBox_SubOne, _logicNumberGenerator.IsCorrectSubtraction(textBox_SubOne.Text, -1) },
        { textBox_SubTwo, _logicNumberGenerator.IsCorrectSubtraction(textBox_SubTwo.Text, -2) },
        { textBox_SubTen, _logicNumberGenerator.IsCorrectSubtraction(textBox_SubTen.Text, -10) },
        { textBox_Sub20, _logicNumberGenerator.IsCorrectSubtraction(textBox_Sub20.Text, -20) }
      };

      SetBackColorBasedOnAnswer(answers);
    }

    //Set background color for each text box based on answers
    private void SetBackColorBasedOnAnswer(Dictionary<TextBox, bool> answers)
    {
      foreach (var item in answers)
      {
        TextBox textBox = item.Key;
        bool correctAnswer = item.Value;

        textBox.BackColor = correctAnswer ? Color.Green : Color.Red;
      }
    }

    private void SeTextBoxBackColor(Color color)
    {
      textBox_AddTen.BackColor = color;
      textBox_Add20.BackColor =  color;
      textBox_AddOne.BackColor = color;
      textBox_AddTwo.BackColor = color;
                                 
      textBox_SubTen.BackColor = color;
      textBox_Sub20.BackColor =  color;
      textBox_SubOne.BackColor = color;
      textBox_SubTwo.BackColor = color;
    }

    private void button_PasueStart_Click(object sender, EventArgs e)
    {
      if (_inGame)
      {
        timer1.Stop();
        _inGame = false;
        button_PasueStart.Text = "Start Spil";
        SetAllTextBoxesReadOnly(true);
        SeTextBoxBackColor(Color.LightGray);
      }
      else
      {
        timer1.Start();
        _inGame = true;
        button_PasueStart.Text = "Pause Spil";
        SetAllTextBoxesReadOnly(false);
        SeTextBoxBackColor(Color.White);
      }
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }
  }
}
