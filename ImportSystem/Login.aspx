<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ImportSystem.Login"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="shortcut icon" type="image/x-icon" href="imagens/icon/icone.ico" />
    <title>Login - Import System</title>
    <link href="~/Styles/Login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <asp:ScriptManager ID="Scriptmanager1" EnableScriptGlobalization="True" runat="server">
            </asp:ScriptManager>
            <div class="container">
                <%-- <a class="links" id="paracadastro"></a><a class="links" id="paralogin"></a>--%>
                <div class="content">
                    <%--   <asp:Panel ID="panelCadastro" runat="server">
                        <!--FORMULÁRIO DE CADASTRO-->
                        <div id="cadastro">
                            <form method="post" action="">
                            <h1>
                                Cadastro</h1>
                            <p>
                                <label for="nome_cad">
                                    Seu nome</label>
                                <input id="nome_cad" runat="server" name="nome_cad" required="required" type="text"
                                    placeholder="nome" />
                            </p>
                            <p>
                                <label for="email_cad">
                                    Seu e-mail</label>
                                <input id="email_cad" runat="server" name="email_cad" required="required" type="text"
                                    placeholder="contato@mail.foxconn.com" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server"
                                    ValidationGroup="btCadastrar" ErrorMessage="Email inválido" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ControlToValidate="email_cad"></asp:RegularExpressionValidator>
                            </p>
                            <p>
                                <label for="senha_cad">
                                    Sua senha</label>
                                <input id="senha_cad" runat="server" name="senha_cad" required="required" type="password"
                                    placeholder="ex. 1234" />
                            </p>
                            <p>
                                <asp:Button ID="btCadastrar" runat="server" Text="Cadastrar" ValidationGroup="email"
                                    OnClick="btCadastrar_Click" />
                                 <input type="submit" value="Cadastrar" />--COMENTADO
                                <br />
                                <label id="lbAvisoCadastrar" runat="server" for="lbAvisoCadastrar" style="color: Red"
                                    visible="false">
                                    Msg de Erro</label>
                            </p>
                            <p id="LinkCadastro" class="link" runat="server" visible="false">
                                  Já tem conta? <a  href="Login.aspx">Ir para Login </a>--COMENTADO
                                Já tem conta? <a href="Login.aspx?p=1#paralogin">Ir para Login </a>
                            </p>
                            </form>
                        </div>
                    </asp:Panel>--%>
                    <asp:Panel ID="panelLogin" runat="server">
                        <!--FORMULÁRIO DE LOGIN-->
                        <div id="login">
                            <form method="post" action="">
                            <h1>
                                Login</h1>
                            <p>
                                <label for="nome_login">
                                    Usuário</label>
                                <input id="nome_login" runat="server" name="nome_login" required="required" type="text"
                                    placeholder="ex. administrador" />
                                <%-- <asp:Label ID="lbLogin" runat="server" Text="Seu nomee"></asp:Label>
                    <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>--%>
                            </p>
                            <p>
                                <label for="senha">
                                    Senha</label>
                                <input id="senha" runat="server" name="senha" required="required" type="password"
                                    placeholder="ex. 1234" />
                                <%-- <label for="email_login">
                        Seu e-mail</label>
                    <input id="email_login" name="email_login" required="required" type="password" placeholder="ex. senha" />--%>
                            </p>
                            <%--  <p>
                                <input type="checkbox" name="manterlogado" id="manterlogado" value="" />
                                <label for="manterlogado">
                                    Manter-me logado</label>
                            </p>--%>
                            <p>
                                <asp:Button ID="btLogar" runat="server" Text="Logar" OnClick="btLogar_Click" />
                                <%-- <input type="submit" value="Logar" />--%>
                                <br />
                                <label id="lbAvisoLogar" runat="server" for="lbAvisoLogar" style="color: Red" visible="false">
                                    Msg de Erro</label>
                                <%-- </p>--%>
                                <%--   <p id="LinkLogin" class="link" runat="server">--%>
                                <%--   Ainda não tem conta? <a href="Login.aspx?p=2#paracadastro">Cadastre-se</a>--%>
                                <%--  Ainda não tem conta? <a href="#paracadastro">Cadastre-se</a>--%>
                                <%-- </p>--%>
                            </form>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
