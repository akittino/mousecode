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
        Mood mood = 0;
        public MoodWindow()
        {
            InitializeComponent();
            
        }

        public enum Mood
        {
            Not_Decided = 0,
            Very_Happy = 1,
            Happy = 2,
            Normal = 3,
            Sad = 4,
            Very_Sad = 5
        };


        private void veryHappyButton_Click(object sender, EventArgs e)
        {
            mood = Mood.Very_Happy;
            this.Close();
        }

        private void happyButton_Click(object sender, EventArgs e)
        {
            mood = Mood.Happy;
            this.Close();
        }

        private void normalButton_Click(object sender, EventArgs e)
        {
            mood = Mood.Normal;
            this.Close();
        }

        private void sadButton_Click(object sender, EventArgs e)
        {
            mood = Mood.Sad;
            this.Close();
        }

        private void verySadButton_Click(object sender, EventArgs e)
        {
            mood = Mood.Very_Sad;
            this.Close();
        }

        public Mood GetMood()
        { 
            Mood get = mood;
            return get;
        }

    }
}
