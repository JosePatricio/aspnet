<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Sigeor.Login.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Resources/Scripts/jqueryvalidaciondenavegador.js" type="text/javascript"></script>
    <script src="//code.jquery.com/jquery-1.11.3.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            if (!window.chrome) {
                if (!window.opera) {
                    if (!{}.toString.call(window.HTMLElement).indexOf('Constructor') + 1) {
                        window.location.href = "Control/Compatibilidad.aspx";
                    }
                }
            }
        });
        
    </script>
</head>
<body>
    <form autocomplete="on"  id="form1" runat="server">
    <div>
    </div>
    </form>
</body>
</html>
