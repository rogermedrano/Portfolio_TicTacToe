using BoardLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Portfolio_TicTacGUI
{
    public partial class Form1 : Form
    {
        Board game = new Board();
        Button[] buttons = new Button[9];
        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            game = new Board();

            buttons[0] = button1;
            buttons[1] = button2;
            buttons[2] = button3;
            buttons[3] = button4;
            buttons[4] = button5;
            buttons[5] = button6;
            buttons[6] = button7;
            buttons[7] = button8;
            buttons[8] = button9;

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Click += handleButtonClick;
                buttons[i].Tag = i;
            }
        }



        private void handleButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button) sender;

            int gameSquareNumber = (int)clickedButton.Tag;
            game.Grid[gameSquareNumber] = 1;

            updateBoard();

            //check for winner BEFORE check if board is full
            if (game.checkForWinner() == 1)
            {
                MessageBox.Show("Congratulations, you won!");
                disableSquares();
            }
            else if (game.isBoardFull() == true)
            {
                MessageBox.Show("The board is full! This game is a DRAW!");
                disableSquares();
            }
            else
            {
                computerChoose();
            }
        }

        private void disableSquares()
        {
            foreach (var item in buttons)
            {
                item.Enabled = false;
            }
        }

        private void computerChoose()
        {
            int opponentTurn = rand.Next(9);
            //don't let computer pick an invalid square
            while (opponentTurn == -1 || game.Grid[opponentTurn] != 0)
            {
                opponentTurn = rand.Next(9);
                Console.WriteLine("Your opponent chooses " + opponentTurn);
            }

            game.Grid[opponentTurn] = 2;
            updateBoard();
            
            if (game.isBoardFull() == true)
            {
                MessageBox.Show("This game is a DRAW.");
                disableSquares();
            }
            else if (game.checkForWinner() == 2)
            {
                MessageBox.Show("Your opponent won! Better luck next time.");
                disableSquares();
            }            
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            updateBoard();
        }

        private void updateBoard()
        {
            //assign Xs or Os
            for (int i = 0; i < game.Grid.Length; i++)
            {
                if (game.Grid[i] == 0)
                {
                    buttons[i].Text = "";
                    buttons[i].Enabled = true;
                    buttons[i].ForeColor = Color.Black;
                }
                else if (game.Grid[i] == 1)
                {
                    buttons[i].Text = "X";
                    buttons[i].Enabled = false;
                }
                else if (game.Grid[i] == 2)
                {
                    buttons[i].Text = "O";
                    buttons[i].Enabled = false;                    
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            game = new Board();
            enableAllButtons();
        }

        private void enableAllButtons()
        {
            foreach (var item in buttons)
            {
                item.Enabled = true;
            }

            updateBoard();
        }
    }
}
