using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mysz
{
    public partial class MoodWindow : Form
    {
        ThingsGameMenuWindow ThingsWindow;
        ReflexGameMenuWindow ReflexWindow;
        ColorsGameMenuWindow ColorsWindow;
        Mood mood;
        string userName;
        GameType type;
        public MoodWindow(GameType type, string userName)
        {
            InitializeComponent();
            this.type = type;
            this.userName = userName;
        }

        public enum GameType
        {
            ThingsWindow = 1,
            ReflexWindow = 2,
            ColorsWindow = 3
        };

        public enum Mood
        {
            Very_Happy = 1,
            Happy = 2,
            Normal = 3,
            Sad = 4,
            Very_Sad = 5
        };


        private void veryHappyButton_Click(object sender, EventArgs e)
        {
            mood = Mood.Very_Happy;
            openGame(mood);
        }

        private void openGame(Mood moodKind)
        {
            if (type == GameType.ColorsWindow)
            {
                ColorsWindow = new ColorsGameMenuWindow(moodKind, userName);
            }
            else if (type == GameType.ReflexWindow)
            {
                ReflexWindow = new ReflexGameMenuWindow(moodKind, userName);
            }
            else
            {
                ThingsWindow = new ThingsGameMenuWindow(moodKind, userName);
            }
            this.Close();
        }

        private void happyButton_Click(object sender, EventArgs e)
        {
            mood = Mood.Happy;
            openGame(mood);
        }

        private void normalButton_Click(object sender, EventArgs e)
        {
            mood = Mood.Normal;
            openGame(mood);
        }

        private void sadButton_Click(object sender, EventArgs e)
        {
            mood = Mood.Sad;
            openGame(mood);
        }

        private void verySadButton_Click(object sender, EventArgs e)
        {
            mood = Mood.Very_Sad;
            openGame(mood);
        }

    }
}
