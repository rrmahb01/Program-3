// Program 3
// CIS 199-01
// Due: 4/5/2016
// By: Rakesh R. Mahbubani

// This application uses sequential search with arrays to find the users earliest registration date based on their
// last name and number of credit hours.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prog2
{
    public partial class RegForm : Form
    {
        public RegForm()
        {
            InitializeComponent();
        }

        private void findRegTimeBtn_Click(object sender, EventArgs e)
        {
            const float SENIOR_HOURS = 90;    // Min hours for Senior
            const float JUNIOR_HOURS = 60;    // Min hours for Junior
            const float SOPHOMORE_HOURS = 30; // Min hours for Soph.

            const string DAY1 = "March 30";  // 1st day of registration
            const string DAY2 = "March 31";  // 2nd day of registration
            const string DAY3 = "April 1";   // 3rd day of registration
            const string DAY4 = "April 4";   // 4th day of registration
            const string DAY5 = "April 5";   // 5th day of registration
            const string DAY6 = "April 6";   // 6th day of registration

            char[] namesFS = {'A','C','E','G','J','M','P','R','T','W'}; // array holding the low range characters for the
                                                                        // freshman and sophomores

            char[] namesJS = { 'A', 'E', 'J', 'P', 'T' }; // array holding the low range characters for the juniors and
                                                          // seniors

            string[] timeFS = { "2:00 PM", "4:00 PM", "8:30 AM", "10:00 AM", "11:30 AM", "2:00 PM", "4:00 PM", "8:30 AM",
                                "10:00 AM", "11:30 AM" }; // array holding the times for the freshman and sophomores

            string[] timeJS = { "2:00 PM", "4:00 PM", "8:30 AM", "10:00 AM", "11:30 AM" }; // array holding the times for
                                                                                           // the juniors and seniors

            string lastNameStr;       // Entered last name
            char lastNameLetterCh;    // First letter of last name, as char
            string dateStr = "Error"; // Holds date of registration
            string timeStr = "Error"; // Holds time of registration
            float creditHours;       // Entered credit hours
            bool found = false;
            
            if (float.TryParse(creditHrTxt.Text, out creditHours) && creditHours >= 0) // Valid hours
            {
                lastNameStr = lastNameTxt.Text;
                if (lastNameStr.Length > 0) // Empty string?
                {
                    lastNameStr = lastNameStr.ToUpper(); // Ensure upper case
                    lastNameLetterCh = char.ToUpper(lastNameStr[0]);   // First char of last name

                    if (char.IsLetter(lastNameLetterCh)) // Is it a letter?
                    {
                        // Juniors and Seniors share same schedule but different days
                        if (creditHours >= JUNIOR_HOURS)
                        {
                            if (creditHours >= SENIOR_HOURS)
                                dateStr = DAY1;
                            else // Must be juniors
                                dateStr = DAY2;

                            for (int i = 0; !found && i < namesJS.Length - 1; i++) // searches the nameJS array
                            {
                                if (lastNameLetterCh >= namesJS[i]) // determines if the first character of the
                                                                    // entered last name is greater than the character
                                                                    // in the current array position.
                                {
                                    timeStr = timeJS[i]; // assigns the time in the proper position of the timeJS array
                                                         //to timeStr
                                    found = true; // stops the for loop
                                }
                            }
                                
                        }
                        // Sophomores and Freshmen
                        else // Must be soph/fresh
                        {
                            if (creditHours >= SOPHOMORE_HOURS)
                            {
                                // E-Q on one day
                                if ((lastNameLetterCh >= 'E') && // >= E and
                                    (lastNameLetterCh <= 'Q'))   // <= Q
                                    dateStr = DAY3;
                                else // All other letters on next day
                                    dateStr = DAY4;
                            }
                            else // must be freshman
                            {
                                // E-Q on one day
                                if ((lastNameLetterCh >= 'E') && // >= E and
                                    (lastNameLetterCh <= 'Q'))   // <= Q
                                    dateStr = DAY5;
                                else // All other letters on next day
                                    dateStr = DAY6;                           
                            }
                        }
                        for (int i = 0; !found && i < namesFS.Length - 1; i++) // searches the nameJS array
                        {
                            if (lastNameLetterCh >= namesFS[i]) // determines if the first character of the 
                                                                // entered last name is greater than the character
                                                                // in the current array position.
                            {
                                timeStr = timeFS[i]; // assigns the time in the proper position of the timeJS array
                                                     // to timeStr
                                found = true; // stops the for loop
                            }                                
                        }
                        // Output results
                        dateTimeLbl.Text = dateStr + " at " + timeStr;
                    }
                    else // First char not a letter
                        MessageBox.Show("Enter valid last name!");
                }
                else // Empty textbox
                    MessageBox.Show("Enter a last name!");
            }
            else // Can't parse credit hours
                MessageBox.Show("Please enter valid credit hours earned!");
        }
    }
}
