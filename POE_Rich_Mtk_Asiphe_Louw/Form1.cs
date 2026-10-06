using System.Windows.Forms;

namespace POE_Rich_Mtk_Asiphe_Louw
{
    public partial class Form1 : Form
    {
        private GameEngine gameEngine;

        public Form1()
        {
            InitializeComponent();
            gameEngine = new GameEngine(10);
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            lblDisplay.Text = gameEngine.ToString();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Direction movementDirection = Direction.None;
            Direction attackDirection = Direction.None;

            switch (e.KeyCode)
            {
                case Keys.W:
                    movementDirection = Direction.Up;
                    break;
                case Keys.D:
                    movementDirection = Direction.Right;
                    break;
                case Keys.S:
                    movementDirection = Direction.Down;
                    break;
                case Keys.A:
                    movementDirection = Direction.Left;
                    break;
                case Keys.Up:
                    attackDirection = Direction.Up;
                    break;
                case Keys.Right:
                    attackDirection = Direction.Right;
                    break;
                case Keys.Down:
                    attackDirection = Direction.Down;
                    break;
                case Keys.Left:
                    attackDirection = Direction.Left;
                    break;
            }

            if (movementDirection != Direction.None)
            {
                gameEngine.TriggerMovement(movementDirection);
                UpdateDisplay();
                e.Handled = true;
            }
            else if (attackDirection != Direction.None)
            {
                gameEngine.TriggerAttack(attackDirection);
                UpdateDisplay();
                e.Handled = true;
            }
        }
    }
}
