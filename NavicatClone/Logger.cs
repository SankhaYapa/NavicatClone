using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavicatClone
{
    internal class Logger
    {
        private string logFilePath;

        public Logger(string logFilePath)
        {
            this.logFilePath = logFilePath;
        }

        public void LogToRichTextBox(string message, RichTextBox richTextBox)
        {
            try
            {
                // Get the current text in the RichTextBox
                string currentText = richTextBox.Text;

                // Append the new log message
                richTextBox.Text = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}\n{currentText}";
            }
            catch (Exception ex)
            {
                // Handle any exceptions related to logging (e.g., display an error message).
                Console.WriteLine($"Error logging message: {ex.Message}");
            }
        }

    }
}
