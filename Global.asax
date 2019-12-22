<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started
        Session.Add("Authenticated", 0);
        Session.Add("EmailID", "Nil");
        Session.Add("AdID", 0);
        Session.Add("PostID", 0);
        Session.Add("Credit", 0);
        Session.Add("Amount", 0);
        Session.Add("search", 0);
        Session.Add("Reply", 0);
		Session.Add("RequestedURL","Nil");
        Session.Add("Name", "Guest");
        Session.Add("ClientID", 0);
        Session.Add("ClientCode", 0);
        Session.Add("ClientName", "Nil");
        Session.Add("UserID", 0);
        Session.Add("CustomerID", 0);
        Session.Add("AARMSUserID", 0);
        Session.Add("JunctionAdID", "Nil");
		Session.Add("LogisticsPlanNo", "Nil");
		  Session.Add("SignID", 0);
    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
