namespace BoggleGame
{
    partial class WordShuffleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.JumbledLetterPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ControlButtonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.ShuffleButton = new System.Windows.Forms.Button();
            this.NewRoundButton = new System.Windows.Forms.Button();
            this.SelectedLettersTB = new System.Windows.Forms.TextBox();
            this.InfoPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ScoreLabel = new System.Windows.Forms.TextBox();
            this.TimerLabel = new System.Windows.Forms.TextBox();
            this.WordsFoundBox = new System.Windows.Forms.ListBox();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.ControlButtonPanel.SuspendLayout();
            this.InfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // JumbledLetterPanel
            // 
            this.JumbledLetterPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.JumbledLetterPanel.Location = new System.Drawing.Point(0, 38);
            this.JumbledLetterPanel.Margin = new System.Windows.Forms.Padding(0);
            this.JumbledLetterPanel.Name = "JumbledLetterPanel";
            this.JumbledLetterPanel.Size = new System.Drawing.Size(584, 47);
            this.JumbledLetterPanel.TabIndex = 0;
            // 
            // ControlButtonPanel
            // 
            this.ControlButtonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ControlButtonPanel.Controls.Add(this.SubmitButton);
            this.ControlButtonPanel.Controls.Add(this.ClearButton);
            this.ControlButtonPanel.Controls.Add(this.ShuffleButton);
            this.ControlButtonPanel.Controls.Add(this.NewRoundButton);
            this.ControlButtonPanel.Location = new System.Drawing.Point(0, 126);
            this.ControlButtonPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ControlButtonPanel.Name = "ControlButtonPanel";
            this.ControlButtonPanel.Size = new System.Drawing.Size(584, 30);
            this.ControlButtonPanel.TabIndex = 1;
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(3, 3);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitButton.TabIndex = 0;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(84, 3);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 1;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            // 
            // ShuffleButton
            // 
            this.ShuffleButton.Location = new System.Drawing.Point(165, 3);
            this.ShuffleButton.Name = "ShuffleButton";
            this.ShuffleButton.Size = new System.Drawing.Size(75, 23);
            this.ShuffleButton.TabIndex = 3;
            this.ShuffleButton.Text = "Shuffle";
            this.ShuffleButton.UseVisualStyleBackColor = true;
            // 
            // NewRoundButton
            // 
            this.NewRoundButton.Location = new System.Drawing.Point(246, 3);
            this.NewRoundButton.Name = "NewRoundButton";
            this.NewRoundButton.Size = new System.Drawing.Size(75, 23);
            this.NewRoundButton.TabIndex = 2;
            this.NewRoundButton.Text = "New Round";
            this.NewRoundButton.UseVisualStyleBackColor = true;
            // 
            // SelectedLettersTB
            // 
            this.SelectedLettersTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectedLettersTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedLettersTB.Location = new System.Drawing.Point(0, 88);
            this.SelectedLettersTB.Name = "SelectedLettersTB";
            this.SelectedLettersTB.ReadOnly = true;
            this.SelectedLettersTB.Size = new System.Drawing.Size(584, 35);
            this.SelectedLettersTB.TabIndex = 3;
            // 
            // InfoPanel
            // 
            this.InfoPanel.Controls.Add(this.ScoreLabel);
            this.InfoPanel.Controls.Add(this.TimerLabel);
            this.InfoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.InfoPanel.Location = new System.Drawing.Point(0, 0);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(584, 37);
            this.InfoPanel.TabIndex = 4;
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreLabel.Location = new System.Drawing.Point(3, 3);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.ReadOnly = true;
            this.ScoreLabel.Size = new System.Drawing.Size(156, 29);
            this.ScoreLabel.TabIndex = 0;
            this.ScoreLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TimerLabel
            // 
            this.TimerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerLabel.Location = new System.Drawing.Point(165, 3);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.ReadOnly = true;
            this.TimerLabel.Size = new System.Drawing.Size(407, 29);
            this.TimerLabel.TabIndex = 1;
            this.TimerLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // WordsFoundBox
            // 
            this.WordsFoundBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.WordsFoundBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WordsFoundBox.FormattingEnabled = true;
            this.WordsFoundBox.ItemHeight = 20;
            this.WordsFoundBox.Location = new System.Drawing.Point(0, 157);
            this.WordsFoundBox.Margin = new System.Windows.Forms.Padding(0);
            this.WordsFoundBox.MultiColumn = true;
            this.WordsFoundBox.Name = "WordsFoundBox";
            this.WordsFoundBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.WordsFoundBox.Size = new System.Drawing.Size(584, 404);
            this.WordsFoundBox.TabIndex = 5;
            // 
            // Timer
            // 
            this.Timer.Interval = 1000;
            // 
            // WordShuffleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.WordsFoundBox);
            this.Controls.Add(this.InfoPanel);
            this.Controls.Add(this.SelectedLettersTB);
            this.Controls.Add(this.ControlButtonPanel);
            this.Controls.Add(this.JumbledLetterPanel);
            this.Name = "WordShuffleForm";
            this.Text = "Word Shuffle";
            this.ControlButtonPanel.ResumeLayout(false);
            this.InfoPanel.ResumeLayout(false);
            this.InfoPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel JumbledLetterPanel;
        private System.Windows.Forms.FlowLayoutPanel ControlButtonPanel;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.TextBox SelectedLettersTB;
        private System.Windows.Forms.FlowLayoutPanel InfoPanel;
        private System.Windows.Forms.TextBox ScoreLabel;
        private System.Windows.Forms.ListBox WordsFoundBox;
        private System.Windows.Forms.TextBox TimerLabel;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Button NewRoundButton;
        private System.Windows.Forms.Button ShuffleButton;


    }
}

