using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
/*
 * Your Name: Omar Zahraoui
 * Student Number: 000905815
 * Statement of Authorship: I, Omar Zahraoui, certify that this material is my original work. No other person's work has been used without due acknowledgement.
 */
namespace Lab4b
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Stores the content of the loaded HTML file.
        /// </summary>
        private string htmlContent = string.Empty; // Initialize with an empty string

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the loadToolStripMenuItem control.
        /// Opens a dialog to load an HTML file and displays a processed message.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "HTML files (*.html)|*.html|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                htmlContent = File.ReadAllText(filePath);
                label1.Text = $"Loaded: {Path.GetFileName(filePath)}";
                richTextBox1.Text = "File processed."; // Display message instead of HTML content
            }
        }

        /// <summary>
        /// Handles the Click event of the checkTagsToolStripMenuItem control.
        /// Checks if the HTML tags are balanced and displays the result.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkTagsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(htmlContent))
            {
                MessageBox.Show("Please load an HTML file first.");
                return;
            }

            bool balanced = CheckTags(htmlContent, out string detailedResult);
            MessageBox.Show(balanced ? "Tags are balanced." : "Tags are not balanced.");
            label1.Text += balanced ? " has balanced tags" : " does not have balanced tags";
            richTextBox1.Text = detailedResult; // Show detailed results in RichTextBox
        }

        /// <summary>
        /// Checks if the HTML tags in the given content are balanced.
        /// </summary>
        /// <param name="htmlContent">The HTML content to check.</param>
        /// <param name="detailedResult">The detailed result of the tag checking.</param>
        /// <returns><c>true</c> if the tags are balanced; otherwise, <c>false</c>.</returns>
        private bool CheckTags(string htmlContent, out string detailedResult)
        {
            Stack<string> tagStack = new Stack<string>();
            var tags = GetTags(htmlContent);
            HashSet<string> nonContainerTags = new HashSet<string> { "img", "hr", "br" };
            detailedResult = string.Empty;

            foreach (var tag in tags)
            {
                if (nonContainerTags.Contains(tag.Item1))
                {
                    detailedResult += $"Found non-container tag: <{tag.Item1}>\n";
                    continue;
                }

                if (tag.Item2 == "open")
                {
                    tagStack.Push(tag.Item1);
                    detailedResult += $"Found opening tag: <{tag.Item1}>\n";
                }
                else if (tag.Item2 == "close")
                {
                    if (tagStack.Count == 0 || tagStack.Pop() != tag.Item1)
                    {
                        detailedResult += $"Unmatched closing tag: </{tag.Item1}>\n";
                        return false;
                    }
                    detailedResult += $"Found closing tag: </{tag.Item1}>\n";
                }
            }

            return tagStack.Count == 0;
        }

        /// <summary>
        /// Extracts all HTML tags from the given content.
        /// </summary>
        /// <param name="htmlContent">The HTML content to extract tags from.</param>
        /// <returns>A list of tuples containing the tag name and type (open/close).</returns>
        private List<Tuple<string, string>> GetTags(string htmlContent)
        {
            List<Tuple<string, string>> tags = new List<Tuple<string, string>>();
            Regex tagPattern = new Regex(@"<\s*(?<closing>/?)\s*(?<tag>\w+)[^>]*>");
            var matches = tagPattern.Matches(htmlContent);

            foreach (Match match in matches)
            {
                string tagName = match.Groups["tag"].Value.ToLower();
                string tagType = match.Groups["closing"].Value == "/" ? "close" : "open";
                tags.Add(new Tuple<string, string>(tagName, tagType));
            }

            return tags;
        }
    }
}
