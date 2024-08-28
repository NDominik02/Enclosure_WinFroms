using Bekerites.Model;
using Bekerites.Persistence;

namespace Bekerites.WinForms
{
    public partial class GameForm : Form
    {
        #region Fields
        private IBekeritesDataAccess _dataAccess = null!; //adatelérés
        private BekeritesGameModel _model = null!; //játékmodell
        private Button[,] _buttonGrid = null!; //gombrács
        private Button? currentButton = null;

        private Button? previouslyPainted = null;


        #endregion

        #region Constructors
        public GameForm()
        {
            InitializeComponent();

            _dataAccess = new BekeritesFileDataAccess();
            KeyPreview = true;

            //modell lérehozása és az eseménykezelõk társítása
            _model = new BekeritesGameModel(_dataAccess);
            _model.FieldChanged += new EventHandler<FieldChangedEventArgs>(Game_FieldChanged);
            _model.GameAdvanced += new EventHandler<BekeritesEventArgs>(Game_GameAdvanced);
            _model.GameWon += new EventHandler<GameWonEventArgs>(Game_GameWon);
            _model.GameOver += new EventHandler(Game_GameOver);
            _model.RotatedSecondBlock += new EventHandler<FieldChangedEventArgs>(Game_RotatedSecondBlock);
            // játéktábla és menük inicializálása
            GenerateTable();
            SetupMenus();

            // új játék indítása
            _model.NewGame();
            SetupTable();


        }
        #endregion

        #region Game event handlers

        private void Game_FieldChanged(object? sender, FieldChangedEventArgs e)
        {
            switch (e.Player)
            {
                case Player.PlayerRed:
                    _buttonGrid[e.X, e.Y].BackColor = Color.Red;
                    break;
                case Player.PlayerBlue:
                    _buttonGrid[e.X, e.Y].BackColor = Color.Blue;
                    break;
                case Player.NoPlayer:
                    _buttonGrid[e.X, e.Y].BackColor = Color.White;
                    break;
            }
        }

        private void Game_GameWon(object? sender, GameWonEventArgs e)
        {
            _menuFileSaveGame.Enabled = false;

            switch (e.Player)
            {
                case Player.PlayerRed:
                    MessageBox.Show("A piros játékos gyõzött!", "Játék vége!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;
                case Player.PlayerBlue:
                    MessageBox.Show("A kék játékos gyõzött!", "Játék vége!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;
            }
            _model.NewGame();
            SetupTable();
        }

        private void Game_GameAdvanced(object? sender, BekeritesEventArgs e)
        {
            _model.OccupiedAreaR = 0;
            _model.OccupiedAreaB = 0;

            foreach (var coordinate in e.Coordinates)
            {
                _buttonGrid[coordinate.Key, coordinate.Value].BackColor = _model.Table.CurrentPlayer == Player.PlayerRed ? Color.IndianRed : Color.DeepSkyBlue;

            }

            for (int i = 0; i < _model.Table.Size - 1; i++)
            {
                for (int j = 0; j < _model.Table.Size - 1; j++)
                {
                    if (_buttonGrid[i, j].BackColor == Color.IndianRed)
                    {
                        _model.OccupiedAreaR++;
                    }
                    else if (_buttonGrid[i, j].BackColor == Color.DeepSkyBlue)
                    {
                        _model.OccupiedAreaB++;
                    }
                }
            }

            _toolLabelRedPoints.Text  = _model.OccupiedAreaR.ToString();
            _toolLabelBluePoints.Text = _model.OccupiedAreaB.ToString();
            // pontok frissítése
        }

        private void Game_GameOver(object? sender, EventArgs e)
        {
            _menuFileSaveGame.Enabled = false;

            MessageBox.Show("Döntetlen játék!", "Játék vége!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            _model.NewGame();
            SetupTable();
        }

        private void Game_RotatedSecondBlock(object? sender, FieldChangedEventArgs e)
        {
            _buttonGrid[e.X, e.Y].BackColor = _model.Table.CurrentPlayer == Player.PlayerRed ? Color.Red : Color.Blue;

            if (previouslyPainted != null)
            {
                Int32 x = (previouslyPainted.TabIndex - 100) / _model.Table.Size;
                Int32 y = (previouslyPainted.TabIndex - 100) % _model.Table.Size;

                previouslyPainted.BackColor = Color.White;

            }

            previouslyPainted = _buttonGrid[e.X, e.Y];
        }

        #endregion

        #region Grid event handlers

        private void ButtonGrid_MouseClick(object? sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                Int32 x = (button.TabIndex - 100) / _model.Table.Size;
                Int32 y = (button.TabIndex - 100) % _model.Table.Size;

                if (_model.Table[x, y] != Player.NoPlayer)
                {
                    return;
                }

                if (currentButton == button) // ugyanarra a blokkra kattint
                {
                    _model.SecondBlock(x, y);
                }
                else
                {
                    if (currentButton != null)
                    {
                        currentButton.BackColor = Color.White;
                    }
                    if (previouslyPainted != null)
                    {
                        previouslyPainted.BackColor = Color.White;
                    }
                    previouslyPainted = null;
                    button.BackColor = _model.Table.CurrentPlayer == Player.PlayerRed ? Color.Red : Color.Blue;
                    _model.RotateCount = 0;
                }

                currentButton = button;

            }
        }

        #endregion

        #region Menu event handlers

        private void MenuFileNewGame_Click(object sender, EventArgs e)
        {
            _menuFileSaveGame.Enabled = true;

            foreach (Button button in _buttonGrid)
            {
                Controls.Remove(button);
            }

            _model.NewGame();

            GenerateTable();

            SetupTable();
            SetupMenus();
        }

        private async void MenuFileLoadGame_Click(object sender, EventArgs e)
        {
            if (_openFileDialog.ShowDialog() == DialogResult.OK) //ha kiválasztottunk egy fájlt
            {
                try
                {
                    //játék betöltése
                    await _model.LoadGameAsync(_openFileDialog.FileName);
                    _menuFileSaveGame.Enabled = true;
                }
                catch (BekeritesDataException)
                {
                    MessageBox.Show("Játék betöltése sikertelen!" + Environment.NewLine + "Hibás az elérési út vagy a fájlformátum.");

                    _model.NewGame();
                    _menuFileSaveGame.Enabled = true;
                }
                GenerateTable();
                SetupTable();
            }
        }


        private async void MenuFileSaveGame_Click(object sender, EventArgs e)
        {
            if (_saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //játék mentése
                    await _model.SaveGameAsync(_saveFileDialog.FileName);
                }
                catch (BekeritesDataException)
                {
                    MessageBox.Show("Játék mentése sikertelen!" + Environment.NewLine + "Hibás az elérési út, vagy a könyvtár nem írható.", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MenuFileExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Biztosan ki szeretne lépni?", "Bekerítés játék", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void MenuGameSix_Click(object sender, EventArgs e)
        {
            _model.GameMode = GameMode.x6;
        }

        private void MenuGameEight_Click(object sender, EventArgs e)
        {
            _model.GameMode = GameMode.x8;
        }

        private void MenuGameTen_Click(object sender, EventArgs e)
        {
            _model.GameMode = GameMode.x10;
        }


        #endregion

        #region Private methods

        private void GenerateTable()
        {
            if (_buttonGrid != null)
            {
                foreach (Button button in _buttonGrid)
                {
                    Controls.Remove(button);
                }
            }

            switch (_model.GameMode)
            {
                case GameMode.x6:
                    Size = new Size(450, 565);
                    break;
                case GameMode.x8:
                    Size = new Size(590, 710);
                    break;
                case GameMode.x10:
                    Size = new Size(725, 850);
                    break;
            }

            _buttonGrid = new Button[_model.Table.Size, _model.Table.Size];
            for (Int32 i = 0; i < _model.Table.Size; i++)
            {
                for (Int32 j = 0; j < _model.Table.Size; j++)
                {
                    _buttonGrid[i, j] = new Button();
                    _buttonGrid[i, j].Location = new Point(5 + 70 * j, 35 + 70 * i);
                    _buttonGrid[i, j].Size = new Size(70, 70);
                    _buttonGrid[i, j].TabIndex = 100 + i * _model.Table.Size + j;
                    _buttonGrid[i, j].FlatStyle = FlatStyle.Flat;
                    _buttonGrid[i, j].MouseClick += new MouseEventHandler(ButtonGrid_MouseClick);

                    Controls.Add(_buttonGrid[i, j]);
                }
            }
        }

        private void SetupTable()
        {
            for (Int32 i = 0; i < _buttonGrid.GetLength(0); i++)
            {
                for (Int32 j = 0; j < _buttonGrid.GetLength(1); j++)
                {
                    switch (_model.Table[i, j])
                    {
                        case Player.NoPlayer:
                            _buttonGrid[i, j].BackColor = Color.White;
                            break;
                        case Player.PlayerRed:
                            _buttonGrid[i, j].BackColor = Color.Red;
                            break;
                        case Player.PlayerBlue:
                            _buttonGrid[i, j].BackColor = Color.Blue;
                            break;
                    }
                }
            }

            _toolLabelBluePoints.Text = _model.OccupiedAreaB.ToString();
            _toolLabelRedPoints.Text = _model.OccupiedAreaR.ToString();
        }

        private void SetupMenus()
        {
            _menuGameSix.Checked = (_model.GameMode == GameMode.x6);
            _menuGameEight.Checked = (_model.GameMode == GameMode.x8);
            _menuGameTen.Checked = (_model.GameMode == GameMode.x10);
        }

        private void GameForm_KeyDown(object? sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Space && currentButton != null)
            {
                if (previouslyPainted == null)
                {
                    return;
                }

                Int32 x = (currentButton.TabIndex - 100) / _model.Table.Size;
                Int32 y = (currentButton.TabIndex - 100) % _model.Table.Size;

                currentButton = null;
                previouslyPainted = null;

                _model.StepGame(x, y); //lépés a játékban

            }

        }




        #endregion

        private void GameForm_Load(object sender, EventArgs e)
        {

        }

    }

}