namespace lab2B
{
    /*
    * Your Name: Omar Zahraoui
    * Student Number: 000905815
    * Statement of Authorship: I, Omar Zahraoui, certify that this material is my original work. No other person's work has been used without due acknowledgement.
    */

    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the Form1 class and sets up event handlers.
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            // Set up event handlers for buttons
            calculatebutton.Click += calculatebutton_Click;
            clearbutton.Click += clearbutton_Click;
            exitbutton.Click += exitbutton_Click;
        }

        /// <summary>
        /// Calculates the total cost for the customer based on the hairdresser, services, and client type.
        /// </summary>
        private void calculatebutton_Click(object sender, EventArgs e)
        {
            // Check if visits is a valid integer and greater than zero
            if (!int.TryParse(visitstextBox.Text, out int visits) || visits < 1)
            {
                MessageBox.Show("Please enter a valid number of visits.");
                visitstextBox.Focus();
                return;
            }

            // Determine hairdresser price
            int hairdresserPrice = 0;
            if (janebutton.Checked) hairdresserPrice = 30;
            else if (patbutton.Checked) hairdresserPrice = 45;
            else if (ronbutton.Checked) hairdresserPrice = 40;
            else if (suebutton.Checked) hairdresserPrice = 50;
            else if (laurabutton.Checked) hairdresserPrice = 55;

            // Determine service charges
            int serviceCharge = 0;
            if (cutcheck.Checked) serviceCharge += 30;
            if (colourcheck.Checked) serviceCharge += 40;
            if (highlightscheck.Checked) serviceCharge += 50;
            if (extensionscheck.Checked) serviceCharge += 200;

            // Ensure at least one service is selected
            if (serviceCharge == 0)
            {
                MessageBox.Show("Please select at least one service.");
                return;
            }

            // Determine discount based on client type
            double discount = 0;
            if (childradio.Checked) discount = 0.10;
            else if (Studentradio.Checked) discount = 0.05;
            else if (Seniorradio.Checked) discount = 0.15;

            // Calculate the total cost
            double totalCost = (hairdresserPrice + serviceCharge) * visits;
            totalCost -= totalCost * discount; // Apply discount

            // Display the total cost in totaltextBox
            totaltextBox.Text = totalCost.ToString("C"); // "C" formats as currency
        }

        /// <summary>
        /// Clears all selections and text fields on the form.
        /// </summary>
        private void clearbutton_Click(object sender, EventArgs e)
        {
            // Reset radio buttons
            janebutton.Checked = false;
            patbutton.Checked = false;
            ronbutton.Checked = false;
            suebutton.Checked = false;
            laurabutton.Checked = false;

            // Reset checkboxes
            cutcheck.Checked = false;
            colourcheck.Checked = false;
            highlightscheck.Checked = false;
            extensionscheck.Checked = false;

            // Reset client type radio buttons
            adultradio.Checked = false;
            childradio.Checked = false;
            Studentradio.Checked = false;
            Seniorradio.Checked = false;

            // Clear text fields
            visitstextBox.Clear();
            totaltextBox.Clear();
        }

        /// <summary>
        /// Exits the application when the Exit button is clicked.
        /// </summary>
        private void exitbutton_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Closes the application
        }

        // The following methods are unused event handlers that were likely auto-generated.
        // You can remove them if not needed, or leave them if you plan to add logic later.

        private void groupBox1_Enter(object sender, EventArgs e) { }

        private void groupBox2_Enter(object sender, EventArgs e) { }

        private void groupBox3_Enter(object sender, EventArgs e) { }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) { }

        private void radioButton5_CheckedChanged(object sender, EventArgs e) { }

        private void radioButton4_CheckedChanged(object sender, EventArgs e) { }

        private void label3_Click(object sender, EventArgs e) { }
    }
}
