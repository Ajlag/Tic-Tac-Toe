using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace X_O
{
    public partial class Form1 : Form
    {
        bool red = true; // true= X red; false= Y red;
        int red_broj = 0;
        // static String player1, player2;
        bool komp = false;

        public Form1()
        {
            InitializeComponent();
        }

        //public static void setPlayerName(String n1, String n2) {
        //    player1 = n1;
        //    player2 = n2;
        //}

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Radila Ajla", "Igrica X-O");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            if ((p1.Text == "Igrac 1") || (p2.Text == "Igrac 2"))
            {
                MessageBox.Show("Moras upisti ime pre pocetka igre");

            }
            else
            {
                Button b = (Button)sender;
                if (red)
                    b.Text = "X";
                else
                    b.Text = "O";

                red = !red;
                b.Enabled = false;

                red_broj++;
                label2.Focus();
                ProveraPobednika();

            }
            if((!red) && (komp)){
                computer_make_move();
            }
        }

        private void computer_make_move()
        {
            //priority 1:  get tick tac toe
            //priority 2:  block x tic tac toe
            //priority 3:  go for corner space
            //priority 4:  pick open space

            Button move = null;

            //look for tic tac toe opportunities
            move = look_for_win_or_block("O"); //look for win
            if (move == null)
            {
                move = look_for_win_or_block("X"); //look for block
                if (move == null)
                {
                    move = look_for_corner();
                    if (move == null)
                    {
                        move = look_for_open_space();
                    }//end if
                }//end if
            }//end if

            move.PerformClick();
        }

        private Button look_for_win_or_block(string mark)
        {
            Console.WriteLine("Looking for win or block:  " + mark);
            //HORIZONTAL TESTS
            if ((A1.Text == mark) && (A2.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A2.Text == mark) && (A3.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (A3.Text == mark) && (A2.Text == ""))
                return A2;

            if ((B1.Text == mark) && (B2.Text == mark) && (B3.Text == ""))
                return B3;
            if ((B2.Text == mark) && (B3.Text == mark) && (B1.Text == ""))
                return B1;
            if ((B1.Text == mark) && (B3.Text == mark) && (B2.Text == ""))
                return B2;

            if ((C1.Text == mark) && (C2.Text == mark) && (C3.Text == ""))
                return C3;
            if ((C2.Text == mark) && (C3.Text == mark) && (C1.Text == ""))
                return C1;
            if ((C1.Text == mark) && (C3.Text == mark) && (C2.Text == ""))
                return C2;

            //VERTICAL TESTS
            if ((A1.Text == mark) && (B1.Text == mark) && (C1.Text == ""))
                return C1;
            if ((B1.Text == mark) && (C1.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (C1.Text == mark) && (B1.Text == ""))
                return B1;

            if ((A2.Text == mark) && (B2.Text == mark) && (C2.Text == ""))
                return C2;
            if ((B2.Text == mark) && (C2.Text == mark) && (A2.Text == ""))
                return A2;
            if ((A2.Text == mark) && (C2.Text == mark) && (B2.Text == ""))
                return B2;

            if ((A3.Text == mark) && (B3.Text == mark) && (C3.Text == ""))
                return C3;
            if ((B3.Text == mark) && (C3.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A3.Text == mark) && (C3.Text == mark) && (B3.Text == ""))
                return B3;

            //DIAGONAL TESTS
            if ((A1.Text == mark) && (B2.Text == mark) && (C3.Text == ""))
                return C3;
            if ((B2.Text == mark) && (C3.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (C3.Text == mark) && (B2.Text == ""))
                return B2;

            if ((A3.Text == mark) && (B2.Text == mark) && (C1.Text == ""))
                return C1;
            if ((B2.Text == mark) && (C1.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A3.Text == mark) && (C1.Text == mark) && (B2.Text == ""))
                return B2;

            return null;
        }

        private Button look_for_corner()
        {
            Console.WriteLine("Looking for corner");
            if (A1.Text == "O")
            {
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
            }

            if (A3.Text == "O")
            {
                if (A1.Text == "")
                    return A1;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
            }

            if (C3.Text == "O")
            {
                if (A1.Text == "")
                    return A3;
                if (A3.Text == "")
                    return A3;
                if (C1.Text == "")
                    return C1;
            }

            if (C1.Text == "O")
            {
                if (A1.Text == "")
                    return A3;
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
            }

            if (A1.Text == "")
                return A1;
            if (A3.Text == "")
                return A3;
            if (C1.Text == "")
                return C1;
            if (C3.Text == "")
                return C3;

            return null;
        }

        private Button look_for_open_space()
        {
            Console.WriteLine("Looking for open space");
            Button b = null;
            foreach (Control c in Controls)
            {
                b = c as Button;
                if (b != null)
                {
                    if (b.Text == "")
                        return b;
                }//end if
            }//end if

            return null;
        }

        //Provera pobednika
        private void ProveraPobednika()
        {
            bool pobednik = false;

            //horizontalna provera
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                pobednik = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                pobednik = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                pobednik = true;

            //vertikalna provera
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                pobednik = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                pobednik = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                pobednik = true;

            //dijagonala provera
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                pobednik = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                pobednik = true;
           


            if (pobednik)
            {
                onemoguciDugme();
                String pobeda = "";
                if (red)
                {
                    pobeda = p2.Text; ;
                    O_broj.Text = (Int32.Parse(O_broj.Text) + 1).ToString();
                }
                else
                { pobeda = p1.Text;
                    x_broj.Text = (Int32.Parse(x_broj.Text) + 1).ToString();


                }
                MessageBox.Show(pobeda + " pobedio", "Yay!");
            }
            else {
                if (red_broj == 9)
                {
                    nereseno_broj.Text = (Int32.Parse(nereseno_broj.Text) + 1).ToString();
                    MessageBox.Show("Sve je popunjeno!Nereseno!", "Kraj");
                }
            }

        }

        private void onemoguciDugme()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            red = true;
            red_broj = 0;
            foreach (Control c in Controls) {
            try
            {
              
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }

            
            catch { }
            }
        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (red)
                    b.Text = "X";
                else
                    b.Text = "O";
            }
            

        }

        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = "";
            }
        }

        private void resetWinCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            O_broj.Text = "0";
            x_broj.Text = "0";
            nereseno_broj.Text = "0";
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {
            //Form2 f2 = new Form2();
            //f2.ShowDialog();
            //label1.Text = player1;
            //label3.Text = player2;

            setPlayerDefaultToolStripMenuItem.PerformClick();
        }

        private void p2_TextChanged(object sender, EventArgs e)
        {
            if (p2.Text.ToUpper() == "COMPUTER")
                komp = true;
            else
                komp = false;
        }

        private void setPlayerDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            p1.Text = "Ajla";
            p2.Text = "Computer";

        }
    }
}
