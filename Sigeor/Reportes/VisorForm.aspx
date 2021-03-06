﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisorForm.aspx.cs" Inherits="Sigeor.VisorForm" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type='text/javascript'>
        $(document).ready(function () {

            $(document)[0].oncontextmenu = function () { return false; }

        }); 
    </script>
    <script type="text/javascript">
        function MostrarMensajeSuccess(mensaje) {
            $().toastmessage('showSuccessToast', mensaje);
        }
        function MostrarMensajeInfo(mensaje) {
            $().toastmessage('showNoticeToast', mensaje);
        }
        function MostrarMensajeWarning(mensaje) {
            $().toastmessage('showWarningToast', mensaje);
        }
        function MostrarMensajeError(mensaje) {
            $().toastmessage('showErrorToast', mensaje);
        }
    </script>
</head>
<body >
    <script src="../Resources/Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
    <link href="../Resources/Styles/jquery.toastmessage.css" rel="stylesheet" />
    <script src="../Resources/Scripts/jquery.toastmessage.js" type="text/javascript"></script>
    <form autocomplete="on"  id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
 

            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" ProcessingMode="Local"
        PageCountMode="Actual" AsyncRendering="True" SizeToReportContent="True" ShowRefreshButton="False">
                <ServerReport Timeout="-1"/>

            </rsweb:ReportViewer>
       
    </form>
</body>
</html>
