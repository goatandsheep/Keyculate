﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Keygulate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int numLines = 0;
        public Stack<string> actionLine = new Stack<string>();
        

        public MainWindow()
        {
            InitializeComponent();

        }

        //GlobalKeyboardHook keyLog;

        /*maybe I'll add stuff to the input that will be printed upon key press,
         * but only actually make a new line when buttons are released. I'll also only append changes
         * when keys are changed that don't include the modifier keys CTRL, SHIFT, and ALT.
         * Also implement a stack for each action. Let it be a 4-element array to be easier.*/
        private void printAction()
        {
            printToTextbox("\n" + actionLine.ToString());
        }

        //this function is probably done
        private void printToTextbox(string input)
        {            
            
            /*Remove everything up until and including the first new line before adding the next line.
             * If there are less than 20 lines, then you don't want to remove any. This queue works,
             * such that the maximum size is 20 and after that, elements will be removed */
            if (numLines == 20)
            {

                int indexOfLine = actionsList.Text.IndexOf("\n");   //returns the index of 'n'
                actionsList.Text = actionsList.Text.Substring(indexOfLine + 1);
                /* The +1 is to make sure the substring function retrieves everything starting at
                 * one element AFTER the 'n' and NOT everything from the 'n' because we don't
                 * want the 'n'*/
                numLines = 19;  /* Which is the same as, but less computation than:
                numLines--;     */
            }

            actionsList.Text = (actionsList.Text + input);
            numLines++;
        }

        //implement a function that deals with global key-presses that adds commands to the stack
        private void keyPressed(object sender, KeyPressEventArgs e)
        {
            actionLine.Push("CTRL");
        }

        //implement a function that deals with global key-releases that calls printAction() and removes commands from the stack
        private void keyReleased(object sender)
        {
            actionLine.Pop();
        }

        //the following functions are functions that deal witht the layout

        private void ClickExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ClickExit_MouseEnter(object sender, EventArgs e)
        {
            //change image to hover image
        }

        private void ClickExit_MouseLeave(object sender, EventArgs e)
        {
            //change image back to original
        }

        private void ClickExit_MouseLeftButtonDown(object sender, EventArgs e)
        {
            //change image to click image
        }
    }

    /*public class Stack
    {
        //blah
    }*/
}
