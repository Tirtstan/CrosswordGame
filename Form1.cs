namespace CrosswordGame
{
    public partial class frmCrossword : Form
    {
        private TextBox[,] textBoxes = new TextBox[5, 5];
        private string[,] Crossword = new string[5, 5]
        {
            { "L", "", "", "", "" },
            { "O", "U", "T", "", "T" },
            { "W", "", "E", "", "O" },
            { "", "", "S", "E", "W" },
            { "S", "I", "T", "", "N" }
        };
        private string[] clues = new string[6]
        {
            "Across     NOT IN",
            "Across     TO JOIN TWO PIECES OF MATERIAL WITH COTTON",
            "Across     NOT LYING DOWN OR STANDING",
            "Down       NOT HIGH",
            "Down       NOT AN EXAM",
            "Down       SMALL CITY"
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

            // add all clues to combo box
            for (int i = 0; i < clues.Length; i++)
            {
                cmbClues.Items.Add(clues[i]);
            }

            lblCompletionMessage.Text = "";
        }
    }
}
