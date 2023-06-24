using System;

namespace CrosswordGame
{
    public partial class frmCrossword : Form
    {
        private TextBox[,] textBoxes = new TextBox[5, 5];
        private string[,] Crossword = new string[5, 5]
        {
            { "B", "E", "A", "R", "" },
            { "I", "", "", "U", "" },
            { "N", "", "O", "N", "E" },
            { "G", "", "", "", "A" },
            { "E", "M", "B", "E", "R" }
        };
        private string[] clues = new string[6]
        {
            "Across     LARGE BROWN MAMMAL",
            "Across     A SINGLE DIGIT NUMBER",
            "Across     A SMALL PIECE OF HOT COAL",
            "Down       TO WATCH A LOT OF SOMETHING",
            "Down       FASTER THAN WALKING",
            "Down       WE USE IT TO HEAR"
        };
        int row;
        int column;

        public frmCrossword()
        {
            InitializeComponent();
        }

        // called on application launch
        private void frmCrossword_Activated(object sender, EventArgs e)
        {
            // created on application launch due to not having access to the text boxes in global
            textBoxes = new TextBox[5, 5]
            {
                { txt00, txt01, txt02, txt03, txt04 },
                { txt10, txt11, txt12, txt13, txt14 },
                { txt20, txt21, txt22, txt23, txt24 },
                { txt30, txt31, txt32, txt33, txt34 },
                { txt40, txt41, txt42, txt43, txt44 }
            };

            for (int i = 0; i < clues.Length; i++)
            {
                cmbClues.Items.Add(clues[i]);
            }

            lblCompletionMessage.Text = "";

            ChangeTextboxStatus();
        }

        private void ShowHint()
        {
            Random num1 = new Random();
            Random num2 = new Random();
            do
            {
                column = num1.Next(0, 5);
                row = num2.Next(0, 5);
            } while (
                !string.IsNullOrEmpty(textBoxes[row, column].Text)
                || textBoxes[row, column].BackColor == Color.Black
            );

            textBoxes[row, column].BackColor = Color.Yellow;
            textBoxes[row, column].Text = Crossword[row, column];
        }

        private void ChangeTextboxStatus()
        {
            // sets relevant text boxes to black or white

            // juFo (2013) demonstrates how...
            for (int i = 0; i < Crossword.GetLength(0); i++)
            {
                for (int j = 0; j < Crossword.GetLength(1); j++)
                {
                    if (string.IsNullOrEmpty(Crossword[i, j]))
                    {
                        textBoxes[i, j].ReadOnly = true;
                        textBoxes[i, j].BackColor = Color.Black;
                    }
                    else
                    {
                        textBoxes[i, j].ReadOnly = false;
                        textBoxes[i, j].BackColor = Color.White;
                        textBoxes[i, j].MaxLength = 1;
                    }
                }
            }

            // checks if entered info is correct
            for (int i = 0; i < Crossword.GetLength(0); i++)
            {
                for (int j = 0; j < Crossword.GetLength(1); j++)
                {
                    string guess = textBoxes[i, j].Text.ToUpper();
                    textBoxes[i, j].Text = guess;
                    if (!string.IsNullOrEmpty(guess))
                    {
                        if (guess == Crossword[i, j])
                        {
                            textBoxes[i, j].BackColor = Color.LightGreen;
                        }
                        else if (guess != Crossword[i, j])
                        {
                            textBoxes[i, j].BackColor = Color.PaleVioletRed;
                        }
                    }
                }
            }
        }

        private void Finish()
        {
            for (int i = 0; i < Crossword.GetLength(0); i++)
            {
                for (int j = 0; j < Crossword.GetLength(1); j++)
                {
                    string guess = textBoxes[i, j].Text.ToUpper();
                    textBoxes[i, j].Text = guess;
                    if (textBoxes[i, j].BackColor != Color.Black)
                    {
                        if (guess == Crossword[i, j])
                        {
                            textBoxes[i, j].BackColor = Color.LightGreen;
                        }
                        else if (guess != Crossword[i, j])
                        {
                            textBoxes[i, j].BackColor = Color.PaleVioletRed;
                        }
                    }
                }
            }

            DetermineOutcome();
        }

        private void DetermineOutcome()
        {
            bool isWinner = true;
            for (int i = 0; i < Crossword.GetLength(0); i++)
            {
                for (int j = 0; j < Crossword.GetLength(1); j++)
                {
                    if (textBoxes[i, j].BackColor == Color.PaleVioletRed)
                    {
                        isWinner = false;
                        break;
                    }
                }
            }

            lblCompletionMessage.Text = isWinner ? "Congratulations!" : "Incorrect Submission";
            btnShowHint.Enabled = false;
            btnCheckGuesses.Enabled = false;
            btnFinished.Enabled = false;
        }

        private void btnCheckGuesses_Click(object sender, EventArgs e)
        {
            ChangeTextboxStatus();
        }

        private void btnShowHint_Click(object sender, EventArgs e)
        {
            ShowHint();
        }

        private void btnFinished_Click(object sender, EventArgs e)
        {
            Finish();
        }

        #region Reference List
        /*
        juFo. 2013. How do you get the width and height of a multi-dimensional array? [duplicate] [Source code]. https://stackoverflow.com/questions/4260207/how-do-you-get-the-width-and-height-of-a-multi-dimensional-array (Accessed 21 June 2023).
        */
        #endregion
    }
}
