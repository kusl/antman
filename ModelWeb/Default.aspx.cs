﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ModelWeb
{
    public partial class _Default : Page
    {
        string myModelName;
        string myModelEmail;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            myModelName = txtModelName.Text;
            myModelEmail = txtModelMail.Text;
        }
    }
}