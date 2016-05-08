using System;
using Belatrix.Utilities;

namespace Belatrix.Exercice
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLog_Click(object sender, EventArgs e)
        {
            bool logToDatabase = ckLogToDatabase.Checked;
            bool logToTextfile = ckLogToTextfile.Checked;
            bool logToConsole = ckLogToConsole.Checked;

            bool logMessage = rbLogMessage.Checked;
            bool logWarning = rbLogWarning.Checked;
            bool logError = rbLogError.Checked;

            try
            {
                if (!logToDatabase && !logToTextfile && !logToConsole)
                {
                    throw new Exception("No log registered.");
                }

                if (logMessage) JobLogger.LogMessage(txtMessage.Text, logToDatabase, logToTextfile, logToConsole);
                else if (logWarning) JobLogger.LogWarning(txtMessage.Text, logToDatabase, logToTextfile, logToConsole);
                else if (logError) JobLogger.LogError(txtMessage.Text, logToDatabase, logToTextfile, logToConsole);

                lblMessage.ForeColor = System.Drawing.Color.DarkGreen;
                lblMessage.Text = "Log successfully registered.";
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = ex.Message;
            }
        }
    }
}