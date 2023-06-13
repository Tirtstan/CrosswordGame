namespace CrosswordGame
{
    public partial class frmCrossword : Form
    {
        private TextBox[,] crossword;

        public frmCrossword()
        {
            InitializeComponent();
        }

        private void frmCrossword_Activated(object sender, EventArgs e)
        {
            // created on application launch due to not having access to the text boxes in global
            crossword = new TextBox[5, 5]
            {
                { txt00, txt01, txt02, txt03, txt04 },
                { txt10, txt11, txt12, txt13, txt14 },
                { txt20, txt21, txt22, txt23, txt24 },
                { txt30, txt31, txt32, txt33, txt34 },
                { txt40, txt41, txt42, txt43, txt44 }
            };
        }
    }
}
