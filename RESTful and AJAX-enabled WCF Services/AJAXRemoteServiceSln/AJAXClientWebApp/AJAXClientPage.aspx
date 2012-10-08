<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AJAXClientPage.aspx.cs" Inherits="AJAXClientWebApp.AJAXClientPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="Scripts/jquery-1.4.1.js"></script> 
    <script type="text/javascript" src="Scripts/jquery-1.4.1-vsdoc.js"></script>



    <script type="text/javascript">

        function CallRemoteService() {
            var inputVal = $("#txtInput").val();

            $.ajax({
                type: "GET",
                url: "http://localhost:33309/DataService.svc/GetData?val=" + inputVal,
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (returnData) {

                    alert(returnData);
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Input Integer: <input type="text" id="txtInput" /><br />
    <input type="button" value="submit" onclick="CallRemoteService();" />
    </div>
    </form>
</body>
</html>
