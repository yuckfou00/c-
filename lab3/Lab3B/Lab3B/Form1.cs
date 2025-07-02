/**000905815 Omar Zahraoui certify that this material is my original work.  No other person's work has been used without due acknowledgement **/

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace lab3B
{

    //  user will select a hairdresser and services
 
    public partial class MainForm : Form
    {
        // choose the hairdraiser
        private Dictionary<string, decimal> hairdresserRates = new Dictionary<string, decimal>
        {
            { "Jane Samley", 30m },
            { "Pat Johnson", 45m },
            { "Ron Chambers", 40m },
            { "Sue Pallon", 50m },
            { "Laura Renkins", 55m }
        };

        // choose the service
        private Dictionary<string, decimal> serviceRates = new Dictionary<string, decimal>
        {
            { "Cut", 30m },
            { "Wash, blow-dry, and style", 20m },
            { "Colour", 40m },
            { "Highlights", 50m },
            { "Extensions", 200m },
            { "Up-do", 60m }
        };

        private bool firstServiceAdded = false;


        public MainForm()
        {
            InitializeComponent();
        }

 
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Populate the hairdresser ComboBox with names from the dictionary
            foreach (var hairdresser in hairdresserRates.Keys)
            {
                comboBoxHairdressers.Items.Add(hairdresser);
            }
            comboBoxHairdressers.SelectedIndex = 0;

            // Populate the services ListBox with names from the dictionary
            foreach (var service in serviceRates.Keys)
            {
                listBoxServices.Items.Add(service);
            }

            // Initially disable the Add Service and Calculate Total Price buttons
            buttonAddService.Enabled = false;
            buttonCalculateTotalPrice.Enabled = false;
        }


        // enables the services ListBox when a hairdresser is selected
        private void comboBoxHairdressers_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxServices.Enabled = true;
        }


        // Enables the Add Service button when a service is selected

        private void listBoxServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonAddService.Enabled = true;
        }

        private void buttonAddService_Click(object sender, EventArgs e)
        {
            if (!firstServiceAdded)
            {
                // Add selected hairdresser to Charged Items ListBox
                string selectedHairdresser = comboBoxHairdressers.SelectedItem.ToString();
                listBoxChargedItems.Items.Add(selectedHairdresser);
                listBoxPrices.Items.Add(hairdresserRates[selectedHairdresser].ToString("C"));

                // Set flag to true and disable the hairdresser ComboBox
                firstServiceAdded = true;
                comboBoxHairdressers.Enabled = false;
            }

            // Add selected service to Charged Items ListBox
            string selectedService = listBoxServices.SelectedItem.ToString();
            listBoxChargedItems.Items.Add(selectedService);
            listBoxPrices.Items.Add(serviceRates[selectedService].ToString("C"));

            // Enable the Calculate Total Price button
            buttonCalculateTotalPrice.Enabled = true;
        }



        // Calculates the total prix

        private void buttonCalculateTotalPrice_Click(object sender, EventArgs e)
        {
            decimal totalPrice = 0m;
            // Calculate the total price by summing up the prices in the Prices ListBox
            foreach (string price in listBoxPrices.Items)
            {
                totalPrice += decimal.Parse(price, System.Globalization.NumberStyles.Currency);
            }
            // display the total price 
            labelTotalPrice.Text = totalPrice.ToString("C");
        }


        // clear everything

        private void buttonReset_Click(object sender, EventArgs e)
        {
            comboBoxHairdressers.SelectedIndex = 0;
            listBoxChargedItems.Items.Clear();
            listBoxPrices.Items.Clear();
            labelTotalPrice.Text = string.Empty;

           // Disable buttons and enable hairdresser ComboBox
            buttonAddService.Enabled = false;
            buttonCalculateTotalPrice.Enabled = false;
            comboBoxHairdressers.Enabled = true;
            firstServiceAdded = false;
        }
        // Exits the application.
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
