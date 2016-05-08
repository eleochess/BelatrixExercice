using System;
using Belatrix.Utilities;

namespace Belatrix.Exercice
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnToDatabse_Click(object sender, EventArgs e)
        {
            JobLogger.LogMessage(txtMessage.Text, true, false, false);
        }

        protected void btnToTextfile_Click(object sender, EventArgs e)
        {
            JobLogger.LogMessage(txtMessage.Text, false, true, false);
        }

        protected void btnToConsole_Click(object sender, EventArgs e)
        {
            JobLogger.LogMessage(txtMessage.Text, false, false, true);
        }
    }
}