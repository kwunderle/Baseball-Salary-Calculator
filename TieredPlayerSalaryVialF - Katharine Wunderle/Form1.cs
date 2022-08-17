using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TieredPlayerSalaryVialF___Katharine_Wunderle
{
    //Author: Katharine Wunderle
    //ID: 623748
    //Date: 03/06/2021
    //Goal: Calculate players tier and salary based on number of hits
    public partial class salaryCalc : Form
    {
        public salaryCalc()
        {
            InitializeComponent();
        }
        //Tier Constants
        const decimal tier1 = 17500m;
        const decimal tier2 = 20000m;
        const decimal tier3 = 22500m;
        const decimal tier4 = 25000m;
        //Declare variables
        //Name label variable
        string name;
        //Input variable
        decimal hitNo = 0;
        //Output variables
        decimal salary = 0m;
        decimal tier = 0;
        bool tryParseResultBool;
        //Highest hit variable
        decimal highScore = 0;

        private void calcBtn_Click(object sender, EventArgs e)
        {

            //INPUT
            //Receive and verify player name input by user
            name = nameInpt.Text;
            if (nameInpt.Text == "")
            {
                MessageBox.Show("Please enter Player's Name.");
                return;
            }
            //Receive and verify hit count input from user
            tryParseResultBool = decimal.TryParse(hitInpt.Text, out hitNo);
            if (tryParseResultBool == false || hitNo <= 0)
            {
                MessageBox.Show("Error: Please enter a positive numeric value");
                return;
            }
            else if (hitNo > 300)
            {
                MessageBox.Show("Error: Too Many Hits");
                return;
            }
            //Calculate and display tier based on hit number
            if (hitNo <= 49)
            {
                tier = tier1;
                tierOtpt.Text = "1";
            }
            if (hitNo >= 50)
            {
                tier = tier2;
                tierOtpt.Text = "2";
            }

            if (hitNo >= 100)
            {
                tier = tier3;
                tierOtpt.Text = "3";
            }

            if (hitNo >= 150)
            {
                tier = tier4;
                tierOtpt.Text = "4";
            }

            //Calculate salary
            salary = hitNo * tier;
            //Add 25% if both mvp and all star boxes checked
            if (allStarChkBx.Checked && mvpChkBx.Checked)
            {
                salary += salary * .25m;
            }
            //Add 20% to salary if either mvp or all star is checked
            else if (allStarChkBx.Checked || mvpChkBx.Checked)
            {
                salary += salary * .20m;
            }
            //Calculate highest hit
            if (hitNo > highScore)
            {
                //Display leading player information
                highScore = hitNo;
                leadName.Text = name;
                leadHit.Text = hitNo.ToString();
                leadSalary.Text = salary.ToString("c");
                leadTier.Text = tierOtpt.Text;
            }
            //Display current player
            nameOtptLbl.Text = name;
            //Display current player's salary
            salaryOtpt.Text = salary.ToString("c");
        }

        private void clrBtn_Click(object sender, EventArgs e)
        {
            //Clear input text boxes
            nameInpt.Text = "";
            hitInpt.Text = "";
            //Clear checkboxes if checked
            allStarChkBx.Checked = false;
            mvpChkBx.Checked = false;
            //Clear currentn player name and info
            nameOtptLbl.Text = "Current Player";
            tierOtpt.Text = "";
            salaryOtpt.Text = "";
            //Clear leading player info
            leadName.Text = "";
            leadHit.Text = "";
            leadSalary.Text = "";
            leadTier.Text = "";
            //Reset high score variable
            highScore = 0;
        }
    }
}
