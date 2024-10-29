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
            PopulateGrid();
            StyleGrid();
            _logicNumberGenerator = new LogicHundredeTal();
            // Array of all eight textbox
            _textBoxs = new[] { textBox_AddTen, textBox_Add20, textBox_AddOne, textBox_AddTwo, textBox_SubTen, textBox_Sub20, textBox_SubOne, textBox_SubTwo };
            InitializeTextBoxsEvents();
            InitializeTimerEvent();
            ResetGameTimer();
            NewGame(); //Flyttet til metoden onLoadForm
            InitializeDataGridView1();
        }

        private void InitializeDataGridView1()
        {
            dataGridView1.StandardTab = false;
            dataGridView1.Enter += DataGridView1_GotFocus;
            dataGridView1.ReadOnly = true;
            dataGridView1.CurrentCell.ReadOnly = true;
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            HighlightCurrentRandomNumberInGrid();
        }

        private void DataGridView1_GotFocus(object sender, EventArgs e)
        {
            textBox_AddTen.Focus();
        }

        private TextBox[] _textBoxs = null;
        LogicHundredeTal _logicNumberGenerator = null;
        private const int _gameTime = 1000;
        private int _remainingSeconds = _gameTime;
        private bool _inGame = true;
        private void InitializeTextBoxsEvents()
        {
            // Tilknytter Event på hver enkelt tekstboks 
            foreach (var textBox in _textBoxs)
            {
                textBox.KeyPress += textBox_KeyPress;
                textBox.Enter += textBox_Enter;
                textBox.Leave += textBox_Leave;
            }
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = Color.LightBlue;
            textBox.SelectAll();
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = Color.White;
        }

        private void InitializeTimerEvent()
        {
            timer1.Interval = 1000; // 1 sekund
            timer1.Tick += Timer1_Tick;
        }

        private void ResetGameTimer()
        {
            timer2_resetGame.Interval = 10000; // 10 sekund
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
            // Sætter readOnly på hver enkelt tekstboks 
            foreach (var textBox in _textBoxs)
            {
                textBox.ReadOnly = result;
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Get Current TextBox
            TextBox textBox = (TextBox)sender;
            // Only permit digits, backspace, and the negative sign (at the beginning)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !(e.KeyChar == '-' && textBox.Text.Length == 0))
            {
                e.Handled = true;
            }
        }

        private void NewGame()
        {
            Label_Center.Text = _logicNumberGenerator.GetNewNumber();
            HighlightCurrentRandomNumberInGrid();

            // Nulstil farver til brugerinput
            SeTextBoxBackColor(Color.White);

            // Nulstil tekstfelter til bruger input på hver enkelt tekstboks 
            foreach (var textBox in _textBoxs)
            {
                textBox.Text = string.Empty;
            }
        }

        private void buttonCheckAnswer_Click(object sender, EventArgs e)
        {
            // Tjek om brugerens svar er korrekte
            // ... (Implementer logikken her)
            CheckAnswers();
            // TODO: Vis en besked til brugeren om, hvor mange svar der var korrekte
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
            // Sætter farven på hver enkelt tekstboks 
            foreach (var textBox in _textBoxs)
            {
                textBox.BackColor = color;
            }
        }

        private void button_PasueStart_Click(object sender, EventArgs e)
        {
            //dataGridView1.Height //width = 427, Height =302
            if (timer2_resetGame.Enabled) return;

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
            // Create a new instance of the second form
            GameMenuSelectionForm secondForm = new GameMenuSelectionForm();

            // Show the second form as a modal dialog
            if (secondForm.ShowDialog() == DialogResult.OK)
            {
                // Get the name from the second form
                string name = secondForm.EnteredName;

                // Display the name in a message box
                this.Text = $"Lige nu spiller \"{name}\" interaktive hundredtal";
            }
            timer1.Start();
        }

        private void HighlightCurrentRandomNumberInGrid()
        {
            for (int rowindex = 0; rowindex < dataGridView1.Rows.Count; rowindex++)
            {
                for (int columnindex = 0; columnindex < dataGridView1.Rows[rowindex].Cells.Count; columnindex++)
                {
                    string value = dataGridView1.Rows[rowindex].Cells[columnindex].Value.ToString();

                    if (value == _logicNumberGenerator.CurrentRandomNumber.ToString())
                    {
                        dataGridView1.SelectionChanged -= DataGridView1_SelectionChanged;
                        dataGridView1.CurrentCell = dataGridView1.Rows[rowindex].Cells[columnindex];
                        dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
                    }
                }
            }
            //_logicNumberGenerator.CurrentRandomNumber;
        }

        private void PopulateGrid()
        {
            // Indstil antallet af kolonner og rækker
            int rows = 12;
            int columns = 10;

            dataGridView1.ColumnCount = columns;
            dataGridView1.RowCount = rows;

            // Fyld grid'en med tallene 1 til 100
            int number = -19;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    dataGridView1.Rows[row].Cells[col].Value = number++;
                }
            }

            // Juster kolonnebredden
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Width = 35;
            }
        }

        private void StyleGrid()
        {
            // Indstil baggrundsfarven til gul
            dataGridView1.BackgroundColor = Color.FromArgb(255, 253, 208); // Lys gul farve

            // Indstil cellernes stil
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.FromArgb(255, 253, 208); // Lys gul farve
            style.ForeColor = Color.Black;
            style.SelectionBackColor = Color.CadetBlue; //Color.FromArgb(255, 228, 181); // Lysere gul farve ved valg
            style.SelectionForeColor = Color.Black;
            style.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            dataGridView1.DefaultCellStyle = style;
            dataGridView1.ColumnHeadersDefaultCellStyle = style;
            dataGridView1.RowHeadersDefaultCellStyle = style;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Visible = checkBox1.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (!timer1.Enabled) return;
            ResetGame();
        }
    }
}
