using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoggleGame
{
    public partial class WordShuffleForm : Form
    {
        private readonly GameModel gm;
        private Random rnd = new Random();
        private uint roundLength;
        private uint secondsLeft;

        public WordShuffleForm(GameModel gm, uint roundLength = 12)
        {
            InitializeComponent();
            this.gm = gm;
            this.roundLength = roundLength;
            this.secondsLeft = roundLength;
            AddButtonsToPanel(gm.RoundLetters);
            ClearButton.Click += ClearButton_Click;
            SubmitButton.Click += SubmitButton_Click;
            NewRoundButton.Click += NewRoundButton_Click;
            ShuffleButton.Click += ShuffleButton_Click;
            RefreshInfo();
            Timer.Tick += Timer_Tick;
            Timer.Enabled = true;
            WordsFoundBox.DrawMode = DrawMode.OwnerDrawFixed;
            NewRoundButton.Enabled = false;
        }

        void ShuffleButton_Click(object sender, EventArgs e)
        {
            ClearButton_Click(sender, e);
            AddButtonsToPanel(String.Concat(gm.RoundLetters.ToCharArray().OrderBy(s => (rnd.Next(2) % 2) == 0)));
        }

        void NewRoundButton_Click(object sender, EventArgs e)
        {
            NewRoundButton.Enabled = false;
            EnableControlButtons(true);
            gm.NewRound();
            AddButtonsToPanel(gm.RoundLetters);
            RefreshInfo();
            secondsLeft = roundLength;
            Timer.Enabled = true;
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            secondsLeft--;
            TimerLabel.Text = "Time Remaining: " + secondsLeft;
            if (secondsLeft <= 0)
            {
                RoundOver();
            }
        }

        private void RoundOver()
        {
            Timer.Enabled = false;
            WordsFoundBox.DataSource = gm.PossibleMatches.OrderBy(s => s.Length).ToList();
            NewRoundButton.Enabled = true;
            EnableControlButtons(false);
        }

        private void EnableControlButtons(bool enable)
        {
            SubmitButton.Enabled = enable;
            ClearButton.Enabled = enable;
            ShuffleButton.Enabled = enable;
        }
        

        void SubmitButton_Click(object sender, EventArgs e)
        {
            gm.SubmitString(SelectedLettersTB.Text);
            ClearButton_Click(sender, e);
            RefreshInfo();
        }

        private void RefreshInfo()
        {
            ScoreLabel.Text = "Score: " + gm.Score.ToString();
            WordsFoundBox.DataSource = GetWordList();
        }

        void ClearButton_Click(object sender, EventArgs e)
        {
            SelectedLettersTB.Text = "";
            foreach (Button button in JumbledLetterPanel.Controls)
            {
                button.Enabled = true;
            }
        }

        private void AddButtonsToPanel(string letterString)
        {
            JumbledLetterPanel.Controls.Clear();
            foreach (char letter in letterString)
            {
                var button = new Button();
                button.Text = letter.ToString();
                button.Height = JumbledLetterPanel.Height;
                button.Width = JumbledLetterPanel.Width / letterString.Length;
                button.Padding = new Padding(0);
                button.Margin = new Padding(0);
                button.Click += LetterButton_Click;
                JumbledLetterPanel.Controls.Add(button);
            }

        }

        private void LetterButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            SelectedLettersTB.AppendText(button.Text);
            button.Enabled = false;
        }

        private IEnumerable<string> GetWordList()
        {
            var list = from s in gm.MatchesNotFound
                       orderby s.Length
                       select String.Concat(Enumerable.Repeat("_ ", s.Length));
            list = list.Concat(gm.MatchesFound);
            return list.OrderBy(s => s.Replace("_ ", "_").Length).ThenBy(s=>s.Replace("_ ", "ZZZZZ")).ToArray();
        }

        private void WordsFoundBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Brush foundColor = Brushes.Black;
            Brush notFoundColor = Brushes.Red;
            Brush brush;
            String itemText = WordsFoundBox.Items[e.Index].ToString();
            if (gm.MatchesFound.Contains(itemText) || !Regex.IsMatch(itemText, @"^[a-zA-Z]+$"))
                brush = foundColor;
            else
                brush = notFoundColor;
            e.Graphics.DrawString(itemText, WordsFoundBox.Font, brush, e.Bounds);
        }

    }
}
