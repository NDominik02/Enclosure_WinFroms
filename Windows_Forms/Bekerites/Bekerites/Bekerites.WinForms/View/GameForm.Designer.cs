namespace Bekerites.WinForms
{
    partial class GameForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _statusStrip = new StatusStrip();
            _toolLabel1 = new ToolStripStatusLabel();
            _toolLabelRedPoints = new ToolStripStatusLabel();
            _toolLabel2 = new ToolStripStatusLabel();
            _toolLabelBluePoints = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            _menuFile = new ToolStripMenuItem();
            _menuFileNewGame = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            _menuFileLoadGame = new ToolStripMenuItem();
            _menuFileSaveGame = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            _menuFileExit = new ToolStripMenuItem();
            _menuSettings = new ToolStripMenuItem();
            _menuGameSix = new ToolStripMenuItem();
            _menuGameEight = new ToolStripMenuItem();
            _menuGameTen = new ToolStripMenuItem();
            _openFileDialog = new OpenFileDialog();
            _saveFileDialog = new SaveFileDialog();
            _statusStrip.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // _statusStrip
            // 
            _statusStrip.ImageScalingSize = new Size(20, 20);
            _statusStrip.Items.AddRange(new ToolStripItem[] { _toolLabel1, _toolLabelRedPoints, _toolLabel2, _toolLabelBluePoints });
            _statusStrip.Location = new Point(0, 737);
            _statusStrip.Name = "_statusStrip";
            _statusStrip.Padding = new Padding(1, 0, 25, 0);
            _statusStrip.Size = new Size(699, 42);
            _statusStrip.TabIndex = 2;
            _statusStrip.Text = "statusStrip1";
            // 
            // _toolLabel1
            // 
            _toolLabel1.Name = "_toolLabel1";
            _toolLabel1.Size = new Size(70, 32);
            _toolLabel1.Text = "Piros:";
            // 
            // _toolLabelRedPoints
            // 
            _toolLabelRedPoints.Name = "_toolLabelRedPoints";
            _toolLabelRedPoints.Size = new Size(27, 32);
            _toolLabelRedPoints.Text = "0";
            // 
            // _toolLabel2
            // 
            _toolLabel2.Name = "_toolLabel2";
            _toolLabel2.Size = new Size(58, 32);
            _toolLabel2.Text = "Kék:";
            // 
            // _toolLabelBluePoints
            // 
            _toolLabelBluePoints.Name = "_toolLabelBluePoints";
            _toolLabelBluePoints.Size = new Size(27, 32);
            _toolLabelBluePoints.Text = "0";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { _menuFile, _menuSettings });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(11, 5, 0, 5);
            menuStrip1.Size = new Size(699, 46);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // _menuFile
            // 
            _menuFile.DropDownItems.AddRange(new ToolStripItem[] { _menuFileNewGame, toolStripSeparator1, _menuFileLoadGame, _menuFileSaveGame, toolStripSeparator2, _menuFileExit });
            _menuFile.Name = "_menuFile";
            _menuFile.Size = new Size(71, 36);
            _menuFile.Text = "File";
            // 
            // _menuFileNewGame
            // 
            _menuFileNewGame.Name = "_menuFileNewGame";
            _menuFileNewGame.Size = new Size(322, 44);
            _menuFileNewGame.Text = "Új játék";
            _menuFileNewGame.Click += MenuFileNewGame_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(319, 6);
            // 
            // _menuFileLoadGame
            // 
            _menuFileLoadGame.Name = "_menuFileLoadGame";
            _menuFileLoadGame.Size = new Size(322, 44);
            _menuFileLoadGame.Text = "Játék betöltése...";
            _menuFileLoadGame.Click += MenuFileLoadGame_Click;
            // 
            // _menuFileSaveGame
            // 
            _menuFileSaveGame.Name = "_menuFileSaveGame";
            _menuFileSaveGame.Size = new Size(322, 44);
            _menuFileSaveGame.Text = "Játék mentése...";
            _menuFileSaveGame.Click += MenuFileSaveGame_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(319, 6);
            // 
            // _menuFileExit
            // 
            _menuFileExit.Name = "_menuFileExit";
            _menuFileExit.Size = new Size(322, 44);
            _menuFileExit.Text = "Kilépés";
            _menuFileExit.Click += MenuFileExit_Click;
            // 
            // _menuSettings
            // 
            _menuSettings.DropDownItems.AddRange(new ToolStripItem[] { _menuGameSix, _menuGameEight, _menuGameTen });
            _menuSettings.Name = "_menuSettings";
            _menuSettings.Size = new Size(147, 36);
            _menuSettings.Text = "Beállítások";
            // 
            // _menuGameSix
            // 
            _menuGameSix.Name = "_menuGameSix";
            _menuGameSix.Size = new Size(224, 44);
            _menuGameSix.Text = "6 x 6";
            _menuGameSix.Click += MenuGameSix_Click;
            // 
            // _menuGameEight
            // 
            _menuGameEight.Name = "_menuGameEight";
            _menuGameEight.Size = new Size(224, 44);
            _menuGameEight.Text = "8 x 8";
            _menuGameEight.Click += MenuGameEight_Click;
            // 
            // _menuGameTen
            // 
            _menuGameTen.Name = "_menuGameTen";
            _menuGameTen.Size = new Size(224, 44);
            _menuGameTen.Text = "10 x 10";
            _menuGameTen.Click += MenuGameTen_Click;
            // 
            // _openFileDialog
            // 
            _openFileDialog.Filter = "Bekerítés tábla (*.stl)|*.stl";
            _openFileDialog.Title = "Bekerítés játék betöltése";
            // 
            // _saveFileDialog
            // 
            _saveFileDialog.Filter = "Bekerítés tábla (*.stl)|*.stl";
            _saveFileDialog.Title = "Bekerítés játék mentése";
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(699, 779);
            Controls.Add(menuStrip1);
            Controls.Add(_statusStrip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "GameForm";
            Text = "Bekerítés játék";
            Load += GameForm_Load;
            KeyDown += GameForm_KeyDown;
            _statusStrip.ResumeLayout(false);
            _statusStrip.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip _statusStrip;
        private ToolStripStatusLabel _toolLabel1;
        private ToolStripStatusLabel _toolLabelRedPoints;
        private ToolStripStatusLabel _toolLabel2;
        private ToolStripStatusLabel _toolLabelBluePoints;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem _menuFile;
        private ToolStripMenuItem _menuFileNewGame;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem _menuFileLoadGame;
        private ToolStripMenuItem _menuFileSaveGame;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem _menuFileExit;
        private ToolStripMenuItem _menuSettings;
        private ToolStripMenuItem _menuGameSix;
        private ToolStripMenuItem _menuGameEight;
        private ToolStripMenuItem _menuGameTen;
        private OpenFileDialog _openFileDialog;
        private SaveFileDialog _saveFileDialog;
    }
}