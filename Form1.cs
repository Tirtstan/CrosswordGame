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

            richtxtClues.Lines = clues;
            lblCompletionMessage.Text = "";

            ChangeTextboxStatus();
        }

        private void ChangeTextboxStatus()
        {
            // sets relevant text boxes to black or white
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
                    if (!string.IsNullOrEmpty(guess))
                    {
                        if (guess == Crossword[i, j])
                        {
                            textBoxes[i, j].BackColor = Color.Green;
                        }
                        else if (guess != Crossword[i, j])
                        {
                            textBoxes[i, j].BackColor = Color.Red;
                        }
                    }
                }
            }
        }

        private void btnCheckGuesses_Click(object sender, EventArgs e)
        {
            ChangeTextboxStatus();
        }

        #region Reference List
        // https://stackoverflow.com/questions/4260207/how-do-you-get-the-width-and-height-of-a-multi-dimensional-array
        #endregion
    }
}
