<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ImportSystem.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <%--<meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">--%>
    <title>Default</title>
    <%-- <meta name="description" content="Circular Navigation Styles - Building a Circular Navigation with CSS Transforms | Codrops " />
    <meta name="keywords" content="css transforms, circular navigation, round navigation, circular menu, tutorial" />
    <meta name="author" content="Sara Soueidan for Codrops" />--%>
    <%--<link rel="shortcut icon" href="../favicon.ico">   --%>
    <%-- <link href="Styles/normalize.css" rel="stylesheet" type="text/css" />--%>
    <%--   <link href="Styles/outro/main.css" rel="stylesheet" type="text/css" />--%>
    <link href="Styles/outro/demo.css" rel="stylesheet" type="text/css" />
    <link href="Styles/outro/component2.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/modernizr-2.6.2.min.js" type="text/javascript"></script>
    <%--  <script type="text/javascript">
        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-7243260-2']);
        _gaq.push(['_trackPageview']);
        (function () {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();
    </script>--%>
</head>
<body>
    <div class="container">
        <!-- Top Navigation -->
        <div class="codrops-top clearfix">
            <asp:Label ID="lbUsuario" runat="server" Text="Usuário" ForeColor="White"></asp:Label>
            <span class="right"><a class="codrops-icon codrops-icon-drop" id="LinkSair" runat="server"
                ><span>Sair</span></a></span>
        </div>
        <header>
				<h1>LOGISTIC FOXCONN-FBRLA <span>
                </span></h1>	
				<%--<nav class="codrops-demos">
					<a href="index.html">Cadastro</a>
					<a class="current-demo" href="index2.html">Demo 2</a>
					<a href="interactivedemo/index.html">Intractive demo</a>
				</nav>--%>
			</header>
        <div class="component">
            <h2>
                Import System</h2>
            <!-- Start Nav Structure -->
            <button class="cn-button" id="cn-button">
                Menu</button>
            <div class="cn-wrapper" id="cn-wrapper">
                <ul>
                    <li><a href="aereo"><span>AÉREO</span></a></li>
                    <li><a href="maritimo"><span>MARÍTIMO</span></a></li>
                    <li><a href="cadastro"><span>CADASTRO</span></a></li>
                    <%-- <li><a href="#"><span>
                        <asp:Image ID="Image1" runat="server"  ImageUrl="~/imagens/navio.png" /></span></a></li>
                    <li><a href="#"><span>
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/imagens/aviao.png" /></span></a></li>--%>
                    <%--  <li><a href="#"><span>
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/imagens/icone_cadastro.png" /></span></a></li>--%>
                </ul>
            </div>
            <!-- End of Nav Structure -->
        </div>
    </div>
    <!-- /container -->
    <script src="Scripts/polyfills.js" type="text/javascript"></script>
    <!--<script src="js/polyfills.js"></script>-->
    <script src="Scripts/demo2.js" type="text/javascript"></script>
    <!-- For the demo ad only -->
    <%--  <script src="http://tympanus.net/codrops/adpacks/demoad.js"></script>--%>
    <br />
    <br />
    <div class="footer">
        <asp:Label ID="lbRodape" runat="server" ForeColor="White"></asp:Label>
    </div>
</body>
</html>
