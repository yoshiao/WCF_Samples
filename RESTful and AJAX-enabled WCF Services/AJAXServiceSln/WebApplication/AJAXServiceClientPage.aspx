<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AJAXServiceClientPage.aspx.cs" Inherits="WebApplication.AJAXServiceClientPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function OnLogin() {
            var username = document.getElementById("txtUsername").value;
            var password = document.getElementById("txtPassword").value;

            var as = new AccountService.AccountSVC();
            as.ValidateUser(username, password,     /*function parameters*/
                            OnComplete,     /*operation finish callback */
                            OnError,        /*operation error callback */
                            null);      /* context object */
        }
        
        function OnComplete(result) {
            if (result == true) alert("Login Succeeded!");
            else alert("Login failed!");
        }
 
        function OnError(result) {
            alert(result.get_message());
        } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left:auto;margin-right:auto">
        <div id="divLogin">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
                <Services>
                    <asp:ServiceReference Path="~/AccountService.svc" />
                </Services>
            </asp:ScriptManager>


            Username: <input type="text" id="txtUsername" /><br />
            Password: <input type="password" id="txtPassword" /><br />
            <input type="button" value="Login" onclick="OnLogin();" />
        </div>
    </div>
    </form>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</body>
</html>
