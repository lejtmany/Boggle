﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoggleGame
{
    public partial class Form1 : Form
    {
        GameModel gm;
        IList<Button> letterButtonList;

        public Form1(GameModel gm)
        {
            InitializeComponent();
            this.gm = gm;
            letterButtonList = new List<Button>();
            AddButtonsToPanel(gm.RoundLetters);
            ClearButton.Click += ClearButton_Click;
            SubmitButton.Click += SubmitButton_Click;
        }

        void SubmitButton_Click(object sender, EventArgs e)
        {
            gm.SubmitString(SelectedLettersTB.Text);
            ScoreLabel.Text = gm.Score.ToString();
            ClearButton_Click(sender, e);
            WordsFoundBox.DataSource = gm.MatchesFound.ToList();
        }

        void ClearButton_Click(object sender, EventArgs e)
        {
            SelectedLettersTB.Text = "";
            foreach (var button in letterButtonList)
            {
                button.Enabled = true;
            }
        }

        private void AddButtonsToPanel(string letterString)
        {
            letterButtonList.Clear();
            foreach (char letter in letterString)
            {
                var button = new Button();
                button.Text = letter.ToString();
                button.Height = JumbledLetterPanel.Height;
                button.Width = JumbledLetterPanel.Width / letterString.Length;
                button.Padding = new Padding(0);
                button.Margin = new Padding(0);
                button.Click += LetterButton_Click;
                letterButtonList.Add(button);
                JumbledLetterPanel.Controls.Add(button);
            }

        }

        void LetterButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            SelectedLettersTB.AppendText(button.Text);
            button.Enabled = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void WordsFoundBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
