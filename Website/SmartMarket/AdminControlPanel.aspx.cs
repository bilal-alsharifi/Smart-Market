﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminControlPanel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String loginEmail = HttpContext.Current.User.Identity.Name;
        SmartMarketDataClassesDataContext db = new SmartMarketDataClassesDataContext();
        User user = db.Users.SingleOrDefault(u => u.email.Equals(loginEmail));
        if (user == null || !user.admin)
        {
            String info = Strings.accessDenied;
            Response.Redirect("Info.aspx?info=" + info);
        }
    }
}