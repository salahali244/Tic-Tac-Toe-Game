using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toe_Game.Properties;

namespace Tic_Tac_Toe_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool PlayerTurn = false;
        byte Counter_X = 0;
        byte Counter_O = 0;
        string WinnerName = null;

        private bool ResetButton(GunaButton btn)
        {
            btn.BaseColor = Color.SlateGray;
            btn.OnHoverBaseColor = Color.LightSlateGray;

            btn.Tag = null;
            btn.Image = null;

            return true;
        }

        private bool Reset()
        {
            ResetButton(btn1);
            ResetButton(btn2);
            ResetButton(btn3);
            ResetButton(btn4);
            ResetButton(btn5);
            ResetButton(btn6);
            ResetButton(btn7);
            ResetButton(btn8);
            ResetButton(btn9);

            PlayerTurn = false;
            Counter_X = 0;
            Counter_O = 0;
            WinnerName = null;

            return true;
        }

        private bool FillButtonsTag()
        {
            //So The Player Can't Play In Any Box After Game Over
            btn1.Tag = " ";
            btn2.Tag = " ";
            btn3.Tag = " ";
            btn4.Tag = " ";
            btn5.Tag = " ";
            btn6.Tag = " ";
            btn7.Tag = " ";
            btn8.Tag = " ";
            btn9.Tag = " ";

            return true;
        }

        private bool CheckIfThereIsWinner()
        {
            if (CheckIf_X_Win())
            {
                WinnerName = "x";
                MessageBox.Show("Player X Is The Winneeeeer");
                FillButtonsTag();
                return true;
            }
            else if (CheckIf_O_Win())
            {
                WinnerName = "o";
                MessageBox.Show("Player O Is The Winneeeeer");
                FillButtonsTag();
                return true;
            }

            return false;
        }

        private bool CheckIfDraw()
        {
            if (WinnerName == null)
            {
                MessageBox.Show("Its A Draw");
                return true;
            }

            return false;
        }

        private bool CheckButtonsValue(GunaButton btn1, GunaButton btn2, GunaButton btn3, string letter)
        {
            if ((string)btn1.Tag == letter && (string)btn2.Tag == letter && (string)btn3.Tag == letter)
            {
                btn1.OnHoverBaseColor = Color.DarkSeaGreen;
                btn2.OnHoverBaseColor = Color.DarkSeaGreen;
                btn3.OnHoverBaseColor = Color.DarkSeaGreen;

                btn1.BaseColor = Color.DarkSeaGreen;
                btn2.BaseColor = Color.DarkSeaGreen;
                btn3.BaseColor = Color.DarkSeaGreen;
                return true;
            }

            return false;
        }

        private bool CheckIf_X_Win()
        {
            //Check All The Buttons That Include button 5
            if ((string)btn5.Tag == "x")
            {
                if (CheckButtonsValue(btn4, btn5, btn6, "x"))
                {
                    return true;
                }
                else if (CheckButtonsValue(btn2, btn5, btn8, "x"))
                {
                    return true;
                }
                else if (CheckButtonsValue(btn1, btn5, btn9, "x"))
                {
                    return true;
                }
                else if (CheckButtonsValue(btn3, btn5, btn7, "x"))
                {
                    return true;
                }
            }

            //Check All The Buttons That Include button 1
            if ((string)btn1.Tag == "x")
            {
                if (CheckButtonsValue(btn1, btn2, btn3, "x"))
                {
                    return true;
                }
                else if (CheckButtonsValue(btn1, btn4, btn7, "x"))
                {
                    return true;
                }
            }

            //Check All The Buttons That Include button 9
            if ((string)btn9.Tag == "x")
            {
                if (CheckButtonsValue(btn7, btn8, btn9, "x"))
                {
                    return true;
                }
                else if (CheckButtonsValue(btn3, btn6, btn9, "x"))
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckIf_O_Win()
        {
            //Check All The Buttons That Include button 5
            if ((string)btn5.Tag == "o")
            {
                if (CheckButtonsValue(btn4, btn5, btn6, "o"))
                {
                    return true;
                }
                else if (CheckButtonsValue(btn2, btn5, btn8, "o"))
                {
                    return true;
                }
                else if (CheckButtonsValue(btn1, btn5, btn9, "o"))
                {
                    return true;
                }
                else if (CheckButtonsValue(btn3, btn5, btn7, "o"))
                {
                    return true;
                }
            }

            //Check All The Buttons That Include button 1
            if ((string)btn1.Tag == "o")
            {
                if (CheckButtonsValue(btn1, btn2, btn3, "o"))
                {
                    return true;
                }
                else if (CheckButtonsValue(btn1, btn4, btn7, "o"))
                {
                    return true;
                }
            }

            //Check All The Buttons That Include button 9
            if ((string)btn9.Tag == "o")
            {
                if (CheckButtonsValue(btn7, btn8, btn9, "o"))
                {
                    return true;
                }

                else if (CheckButtonsValue(btn3, btn6, btn9, "o"))
                {
                    return true;
                }
            }

            return false;
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (((GunaButton)sender).Tag == null)
            {

                if (PlayerTurn == false)
                {
                    ((GunaButton)sender).Image = imageList1.Images[0];
                    ((GunaButton)sender).Tag = "x";
                    PlayerTurn = true;
                    Counter_X++;

                    if (Counter_X >= 3)
                    {
                        CheckIfThereIsWinner();
                    }
                }

                else
                {
                    ((GunaButton)sender).Image = imageList1.Images[1];
                    ((GunaButton)sender).Tag = "o";
                    PlayerTurn = false;
                    Counter_O++;

                    if (Counter_O >= 3)
                    {
                        CheckIfThereIsWinner();
                    }
                }

                //If The Game End
                if (Counter_X + Counter_O == 9)
                {
                    CheckIfDraw();
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void gunaLabel1_MouseHover(object sender, EventArgs e)
        {
            gunaLabel1.ForeColor = Color.LightSlateGray;
        }

        private void gunaLabel1_MouseLeave(object sender, EventArgs e)
        {
            gunaLabel1.ForeColor = Color.Silver;
        }
    }
}
