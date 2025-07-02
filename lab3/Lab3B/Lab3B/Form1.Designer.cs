/**000905815 Omar Zahraoui certify that this material is my original work.  No other person's work has been used without due acknowledgement **/
namespace lab3B
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            comboBoxHairdressers = new ComboBox();
            listBoxServices = new ListBox();
            listBoxChargedItems = new ListBox();
            listBoxPrices = new ListBox();
            buttonAddService = new Button();
            buttonCalculateTotalPrice = new Button();
            buttonReset = new Button();
            buttonExit = new Button();
            labelTotalPrice = new Label();
            labelHairdresser = new Label();
            labelService = new Label();
            labelChargedItems = new Label();
            labelPrices = new Label();
            labelTotal = new Label();
            SuspendLayout();
            // 
            // comboBoxHairdressers
            // 
            comboBoxHairdressers.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxHairdressers.FormattingEnabled = true;
            comboBoxHairdressers.Location = new Point(12, 25);
            comboBoxHairdressers.Name = "comboBoxHairdressers";
            comboBoxHairdressers.Size = new Size(150, 28);
            comboBoxHairdressers.TabIndex = 0;
            comboBoxHairdressers.SelectedIndexChanged += comboBoxHairdressers_SelectedIndexChanged;
            // 
            // listBoxServices
            // 
            listBoxServices.Enabled = false;
            listBoxServices.FormattingEnabled = true;
            listBoxServices.Location = new Point(168, 25);
            listBoxServices.Name = "listBoxServices";
            listBoxServices.SelectionMode = SelectionMode.MultiExtended;
            listBoxServices.Size = new Size(150, 84);
            listBoxServices.TabIndex = 1;
            listBoxServices.SelectedIndexChanged += listBoxServices_SelectedIndexChanged;
            // 
            // listBoxChargedItems
            // 
            listBoxChargedItems.FormattingEnabled = true;
            listBoxChargedItems.Location = new Point(324, 25);
            listBoxChargedItems.Name = "listBoxChargedItems";
            listBoxChargedItems.Size = new Size(150, 84);
            listBoxChargedItems.TabIndex = 2;
            // 
            // listBoxPrices
            // 
            listBoxPrices.FormattingEnabled = true;
            listBoxPrices.Location = new Point(480, 25);
            listBoxPrices.Name = "listBoxPrices";
            listBoxPrices.Size = new Size(90, 84);
            listBoxPrices.TabIndex = 3;
            // 
            // buttonAddService
            // 
            buttonAddService.Location = new Point(12, 126);
            buttonAddService.Name = "buttonAddService";
            buttonAddService.Size = new Size(150, 33);
            buttonAddService.TabIndex = 4;
            buttonAddService.Text = "Add Service";
            buttonAddService.UseVisualStyleBackColor = true;
            buttonAddService.Click += buttonAddService_Click;
            // 
            // buttonCalculateTotalPrice
            // 
            buttonCalculateTotalPrice.Location = new Point(168, 126);
            buttonCalculateTotalPrice.Name = "buttonCalculateTotalPrice";
            buttonCalculateTotalPrice.Size = new Size(150, 33);
            buttonCalculateTotalPrice.TabIndex = 5;
            buttonCalculateTotalPrice.Text = "Calculate Total Price";
            buttonCalculateTotalPrice.UseVisualStyleBackColor = true;
            buttonCalculateTotalPrice.Click += buttonCalculateTotalPrice_Click;
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(324, 126);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(90, 33);
            buttonReset.TabIndex = 6;
            buttonReset.Text = "Reset";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += buttonReset_Click;
            // 
            // buttonExit
            // 
            buttonExit.Location = new Point(420, 126);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(90, 33);
            buttonExit.TabIndex = 7;
            buttonExit.Text = "Exit";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += buttonExit_Click;
            // 
            // labelTotalPrice
            // 
            labelTotalPrice.BorderStyle = BorderStyle.Fixed3D;
            labelTotalPrice.Location = new Point(321, 183);
            labelTotalPrice.Name = "labelTotalPrice";
            labelTotalPrice.Size = new Size(246, 23);
            labelTotalPrice.TabIndex = 8;
            labelTotalPrice.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelHairdresser
            // 
            labelHairdresser.AutoSize = true;
            labelHairdresser.Location = new Point(12, 9);
            labelHairdresser.Name = "labelHairdresser";
            labelHairdresser.Size = new Size(143, 20);
            labelHairdresser.TabIndex = 9;
            labelHairdresser.Text = "Select a Hairdresser:";
            // 
            // labelService
            // 
            labelService.AutoSize = true;
            labelService.Location = new Point(165, 9);
            labelService.Name = "labelService";
            labelService.Size = new Size(115, 20);
            labelService.TabIndex = 10;
            labelService.Text = "Select a Service:";
            // 
            // labelChargedItems
            // 
            labelChargedItems.AutoSize = true;
            labelChargedItems.Location = new Point(321, 9);
            labelChargedItems.Name = "labelChargedItems";
            labelChargedItems.Size = new Size(108, 20);
            labelChargedItems.TabIndex = 11;
            labelChargedItems.Text = "Charged Items:";
            // 
            // labelPrices
            // 
            labelPrices.AutoSize = true;
            labelPrices.Location = new Point(477, 9);
            labelPrices.Name = "labelPrices";
            labelPrices.Size = new Size(44, 20);
            labelPrices.TabIndex = 12;
            labelPrices.Text = "Price:";
            // 
            // labelTotal
            // 
            labelTotal.AutoSize = true;
            labelTotal.Location = new Point(234, 183);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(81, 20);
            labelTotal.TabIndex = 13;
            labelTotal.Text = "Total Price:";
            // 
            // MainForm
            // 
            ClientSize = new Size(584, 215);
            Controls.Add(labelTotal);
            Controls.Add(labelPrices);
            Controls.Add(labelChargedItems);
            Controls.Add(labelService);
            Controls.Add(labelHairdresser);
            Controls.Add(labelTotalPrice);
            Controls.Add(buttonExit);
            Controls.Add(buttonReset);
            Controls.Add(buttonCalculateTotalPrice);
            Controls.Add(buttonAddService);
            Controls.Add(listBoxPrices);
            Controls.Add(listBoxChargedItems);
            Controls.Add(listBoxServices);
            Controls.Add(comboBoxHairdressers);
            Name = "MainForm";
            Text = "Perfect Cut Hair Salon";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.ComboBox comboBoxHairdressers;
        private System.Windows.Forms.ListBox listBoxServices;
        private System.Windows.Forms.ListBox listBoxChargedItems;
        private System.Windows.Forms.ListBox listBoxPrices;
        private System.Windows.Forms.Button buttonAddService;
        private System.Windows.Forms.Button buttonCalculateTotalPrice;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelTotalPrice;
        private System.Windows.Forms.Label labelHairdresser;
        private System.Windows.Forms.Label labelService;
        private System.Windows.Forms.Label labelChargedItems;
        private System.Windows.Forms.Label labelPrices;
        private System.Windows.Forms.Label labelTotal;
    }
}
