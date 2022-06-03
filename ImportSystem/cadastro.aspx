<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadastro.aspx.cs" EnableEventValidation="false"
    Inherits="ImportSystem.cadastro" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadastro</title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="Styles/outro/demo.css" rel="stylesheet" type="text/css" />
    <link href="Styles/outro/component2.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/modernizr-2.6.2.min.js" type="text/javascript"></script>
    <link href="Styles/treeview.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="Scriptmanager1" EnableScriptGlobalization="True" runat="server">
    </asp:ScriptManager>
    <div class="codrops-top clearfix">
        <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="White" Text="" Font-Bold="true"
            Font-Overline="false" NavigateUrl="Home" ToolTip="Inicio"><<</asp:HyperLink>
        <asp:Label ID="lbUsuario" runat="server" Text="Usuário" ForeColor="White"></asp:Label>
        <span class="right"><a class="codrops-icon codrops-icon-drop" href="sair.aspx"><span>
            Sair</span></a></span>
    </div>
    <%--<div class="main">
        <div class="blocoGrupoCampos">
            <div class="blocoeditor">
                <asp:TreeView ID="tv1" runat="server" Height="300px" Width="300px" Font-Bold="True"
                    Font-Size="X-Large">
                </asp:TreeView>
            </div>
            <div class="blocoeditor">
                <asp:Panel ID="Panel1" runat="server">
                </asp:Panel>
            </div>
        </div>
    </div>--%>
    <table>
        <tr>
            <td>
                <%-- <div class="css-treeview">--%>
                <asp:TreeView ID="tv1" ExpandDepth="0" runat="server" Height="455px" Width="300px"
                    Font-Bold="True" NodeStyle-CssClass="node" Font-Size="X-Large" Style="top: 0px;
                    left: 0px" BorderStyle="None" ImageSet="WindowsHelp" CssClass="treeNode">
                    <HoverNodeStyle Font-Underline="True" ForeColor="#00688B" />
                    <LeafNodeStyle />
                    <NodeStyle CssClass="node" Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black"
                        HorizontalPadding="15px" NodeSpacing="0px" VerticalPadding="1px" />
                    <ParentNodeStyle Font-Bold="False" />
                    <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
                        VerticalPadding="0px" />
                </asp:TreeView>
                <%--</div>--%>
            </td>
            <td>
                <asp:Panel ID="PanelVazio" Visible="true" Width="800px" Height="630px" runat="server">
                </asp:Panel>
                <asp:UpdatePanel ID="UpdatePanelUsuario" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="PanelUsuario" Visible="false" Width="800px" Height="630px" runat="server"
                            CssClass="intropanel" ScrollBars="None">
                            <div class="blocoGrupoCampos" style="margin-left: 18px; width: 800px;">
                                <fieldset class="bordaFieldset" style="width: 737px;">
                                    <legend>Cadastar Usuário</legend>
                                    <div class="blocoGrupoCampos">
                                        <div class="blocoeditor" style="margin-left: 0px">
                                            <label style="margin-left: 0px">
                                                Login</label>
                                            <br />
                                            <asp:TextBox ID="txtLogin" runat="server" Width="150px"> </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="btnUsuarioSalvar"
                                                Text="*" ControlToValidate="txtLogin" ForeColor="Red" runat="server"> </asp:RequiredFieldValidator>
                                        </div>
                                        <div class="blocoeditor" style="margin-left: 0px">
                                            <label style="margin-left: 0px">
                                                Senha</label>
                                            <br />
                                            <asp:TextBox ID="txtSenha" runat="server" Width="150px"> </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="btnUsuarioSalvar"
                                                Text="*" ControlToValidate="txtSenha" ForeColor="Red" runat="server"> </asp:RequiredFieldValidator>
                                        </div>
                                        <div class="blocoeditor" style="margin-left: 0px">
                                            <label style="margin-left: 0px">
                                                E-Mail</label>
                                            <br />
                                            <asp:TextBox ID="txtEMail" runat="server" Width="300px"> </asp:TextBox>
                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" ValidationGroup="btnUsuarioSalvar"
                                        Text="*" ControlToValidate="txtEMail" ForeColor="Red" runat="server"> </asp:RequiredFieldValidator>--%>
                                            <br />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server"
                                                ValidationGroup="btnUsuarioSalvar" ErrorMessage="Email inválido" ForeColor="Red"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEMail"></asp:RegularExpressionValidator>
                                        </div>
                                        <div class="blocoeditor" style="margin-left: 0px">
                                            <label style="margin-left: 0px">
                                                Ativo?</label>
                                            <br />
                                            <asp:CheckBox ID="chkAtivo" runat="server" Checked="True" />
                                        </div>

                                        <div class="blocoeditor" style="margin-left: 0px">
                                           
                                            <asp:CheckBox ID="chkAdministrador" runat="server" Checked="false" 
                                                Text="Administrador?" />
                                        </div>

                                    </div>
                                    <div class="blocoGrupoCampos">
                                        <div class="blocoeditor" style="margin-left: 0px;">
                                            <asp:Button ID="btnUsuarioSalvar" ValidationGroup="btnUsuarioSalvar" runat="server"
                                                Width="120px" Height="40px" Style="background-image: url(imagens/ic_ok.png);
                                                background-repeat: no-repeat; background-position: center;" BackColor="White"
                                                ForeColor="Black" OnClientClick='return confirm("Tem certeza que deseja SALVAR?");'
                                                Text="        Salvar" ToolTip="Salvar" OnClick="btnUsuarioSalvar_Click" />
                                        </div>
                                        <div class="blocoeditor" style="margin-left: 8px;">
                                            <asp:Button ID="btnUsuarioCancelar" runat="server" Width="120px" Height="40px" Style="background-image: url('imagens/icon/back.png');
                                                background-repeat: no-repeat; background-position: center; top: 0px; left: 0px;"
                                                BackColor="White" ForeColor="Black" Text="          Voltar " ToolTip="Voltar"
                                                OnClick="btnUsuarioCancelar_Click" />
                                        </div>
                                        <div class="blocoeditor">
                                            <asp:Label ID="lbUsuarioAviso" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                            <div class="blocoGrupoCampos" style="margin-left: 18px; width: 750px;">
                                <fieldset class="bordaFieldset" style="width: 737px; height: 375px;">
                                    <legend>Lista de Usuários</legend>
                                    <asp:GridView ID="GridUsuario" Width="735px" runat="server" AutoGenerateColumns="False"
                                      AlternatingRowStyle-BackColor="#B4EEB4" PageSize="10" CellPadding="4" ForeColor="#333333"
                                        AllowPaging="True" GridLines="None" DataKeyNames="id" OnPageIndexChanging="GridUsuario_PageIndexChanging"
                                        OnRowCommand="GridUsuario_RowCommand">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbId" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="id" HeaderText="Id">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Login">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtUsuario" runat="server" Text='<%# Eval("usuario") %>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Senha">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtSenha" runat="server" Width="80px" TextMode="Password" Text='<%# Eval("senha") %>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="E-mail">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtEmail" runat="server" Width="300px" Text='<%# Eval("email") %>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <%--  <asp:BoundField DataField="status" HeaderText="Ativo">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Ativo?">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkAtivo" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Admin?">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkAdministrador" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnEditar" runat="server" AlternateText="Editar" ImageUrl="~/imagens/ic_ok.png"
                                                        CommandName="editar" ToolTip="Editar" CommandArgument='<%#Eval("id")%>' Style="text-decoration: underline;
                                                        top: 0px; left: 2px; height: 22px; width: 28px" OnClientClick='return confirm("Confirmar Alteração?");' />
                                                </ItemTemplate>
                                                <%-- <ItemTemplate>--%>
                                                <%--tirado  CommandArgument='<%#Eval("id")%>' pra rowComand pegar indice do grid e nao id--%>
                                                <%-- <asp:ImageButton ID="btnEditar" runat="server" AlternateText="Editar" ImageUrl="~/imagens/ic_ok.png"
                                                        CommandName="editar" ToolTip="Editar" CommandArgument='<%#Container.DataItemIndex %>'
                                                        Style="text-decoration: underline; top: 0px; left: 2px; height: 22px; width: 28px"
                                                        OnClientClick='return confirm("Confirmar Alteração?");' />--%>
                                                <%-- </ItemTemplate>--%>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnDeletar" runat="server" AlternateText="Deletar" ImageUrl="~/imagens/delete.png"
                                                        CommandName="remover" ToolTip="Excluir" CommandArgument='<%#Eval("id")%>' Style="text-decoration: underline;"
                                                        OnClientClick='return confirm("Confirmar Exclusão?");' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <EmptyDataTemplate>
                                            <label>
                                                Sem Registros.</label>
                                        </EmptyDataTemplate>
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#5D7B9D" ForeColor="Red" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    </asp:GridView>
                                </fieldset>
                            </div>
                        </asp:Panel>
                        <%--<iframe id="frm1" src="http://localhost/NetShopping/Home.aspx" width="800px"  ></iframe>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanelFornecedor" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="panelFornecedor" Visible="false" Width="800px" Height="630px" runat="server"
                            CssClass="intropanel" ScrollBars="None">
                            <div class="blocoGrupoCampos" style="margin-left: 18px; width: 800px; top: 0px; left: 0px;">
                                <fieldset class="bordaFieldset" style="width: 737px;">
                                    <legend>Cadastar Fornecedor</legend>
                                    <div class="blocoGrupoCampos">
                                        <div class="blocoeditor" style="margin-left: 0px">
                                            <label style="margin-left: 0px">
                                                Fornecedor</label>
                                            <br />
                                            <asp:TextBox ID="txtFornecedor" runat="server" Width="300px"> </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="btnFornecedorSalvar"
                                                Text="*" ControlToValidate="txtFornecedor" ForeColor="Red" runat="server"> </asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="blocoGrupoCampos">
                                        <div class="blocoeditor" style="margin-left: 0px;">
                                            <asp:Button ID="btnFornecedorSalvar" ValidationGroup="btnFornecedorSalvar" runat="server"
                                                Width="120px" Height="40px" Style="background-image: url(imagens/ic_ok.png);
                                                background-repeat: no-repeat; background-position: center;" BackColor="White"
                                                ForeColor="Black" OnClientClick='return confirm("Tem certeza que deseja SALVAR?");'
                                                Text="        Salvar" ToolTip="Salvar" OnClick="btnFornecedorSalvar_Click" />
                                        </div>
                                        <div class="blocoeditor" style="margin-left: 8px;">
                                            <asp:Button ID="btnFornecedorCancelar" runat="server" Width="120px" Height="40px"
                                                Style="background-image: url('imagens/icon/back.png'); background-repeat: no-repeat;
                                                background-position: center; top: 0px; left: 0px;" BackColor="White" ForeColor="Black"
                                                Text="          Voltar " ToolTip="Voltar" OnClick="btnFornecedorCancelar_Click" />
                                        </div>
                                        <div class="blocoeditor">
                                            <asp:Label ID="lbFornecedorAviso" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                            <div class="blocoGrupoCampos" style="margin-left: 18px; width: 750px;">
                                <fieldset class="bordaFieldset" style="width: 737px; height:390px;">
                                    <legend>Lista de Fornecedores</legend>
                                    <asp:GridView ID="GridFornecedor" Width="735px" runat="server" AutoGenerateColumns="False"                                        
                                    AlternatingRowStyle-BackColor="#B4EEB4" PageSize="10" CellPadding="4" ForeColor="#333333"
                                        AllowPaging="True" GridLines="None" DataKeyNames="id" OnPageIndexChanging="GridFornecedor_PageIndexChanging"
                                        OnRowCommand="GridFornecedor_RowCommand">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbId" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="id" HeaderText="Id">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Fornecedor">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtFornecedor" Width="400px" runat="server" Text='<%# Eval("nome") %>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnEditar" runat="server" AlternateText="Editar" ImageUrl="~/imagens/ic_ok.png"
                                                        CommandName="editar" ToolTip="Editar" CommandArgument='<%#Eval("id")%>' Style="text-decoration: underline;
                                                        top: 0px; left: 2px; height: 22px; width: 28px" OnClientClick='return confirm("Confirmar Alteração?");' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnDeletar" runat="server" AlternateText="Deletar" ImageUrl="~/imagens/delete.png"
                                                        CommandName="remover" ToolTip="Excluir" CommandArgument='<%#Eval("id")%>' Style="text-decoration: underline;"
                                                        OnClientClick='return confirm("Confirmar Exclusão?");' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <EmptyDataTemplate>
                                            <label>
                                                Sem Registros.</label>
                                        </EmptyDataTemplate>
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />                                       
                                        <PagerStyle BackColor="#5D7B9D" ForeColor="Red" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    </asp:GridView>
                                </fieldset>
                            </div>
                        </asp:Panel>
                        <%--<iframe id="frm1" src="http://localhost/NetShopping/Home.aspx" width="800px"  ></iframe>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanelLocal" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="panelLocal" Visible="false" Width="800px" Height="630px" runat="server"
                            CssClass="intropanel" ScrollBars="None">
                            <div class="blocoGrupoCampos" style="margin-left: 18px; width: 800px;">
                                <fieldset class="bordaFieldset" style="width: 737px;">
                                    <legend>Cadastar Local</legend>
                                    <div class="blocoGrupoCampos">
                                        <div class="blocoeditor" style="margin-left: 0px">
                                            <label style="margin-left: 0px">
                                                Local</label>
                                            <br />
                                            <asp:TextBox ID="txtLocal" runat="server" Width="300px"> </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="btnLocalSalvar"
                                                Text="*" ControlToValidate="txtLocal" ForeColor="Red" runat="server"> </asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="blocoGrupoCampos">
                                        <div class="blocoeditor" style="margin-left: 0px;">
                                            <asp:Button ID="btnLocalSalvar" ValidationGroup="btnLocalSalvar" runat="server" Width="120px"
                                                Height="40px" Style="background-image: url(imagens/ic_ok.png); background-repeat: no-repeat;
                                                background-position: center;" BackColor="White" ForeColor="Black" OnClientClick='return confirm("Tem certeza que deseja SALVAR?");'
                                                Text="        Salvar" ToolTip="Salvar" OnClick="btnLocalSalvar_Click" />
                                        </div>
                                        <div class="blocoeditor" style="margin-left: 8px;">
                                            <asp:Button ID="btnLocalCancelar" runat="server" Width="120px" Height="40px" Style="background-image: url('imagens/icon/back.png');
                                                background-repeat: no-repeat; background-position: center; top: 0px; left: 0px;"
                                                BackColor="White" ForeColor="Black" Text="          Voltar " ToolTip="Voltar"
                                                OnClick="btnLocalCancelar_Click" />
                                        </div>
                                        <div class="blocoeditor">
                                            <asp:Label ID="lbLocalAviso" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                            <div class="blocoGrupoCampos" style="margin-left: 18px; width: 750px;">
                                <fieldset class="bordaFieldset" style="width: 737px; height: 390px">
                                    <legend>Lista de Locais</legend>
                                    <asp:GridView ID="GridLocal" Width="735px" runat="server" AutoGenerateColumns="False"
                                       AlternatingRowStyle-BackColor="#B4EEB4" PageSize="10" CellPadding="4" ForeColor="#333333"
                                        AllowPaging="True" GridLines="None" DataKeyNames="id" OnPageIndexChanging="GridLocal_PageIndexChanging"
                                        OnRowCommand="GridLocal_RowCommand">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbId" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="id" HeaderText="Id">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Local">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtLocal" Width="300px" runat="server" Text='<%# Eval("nome") %>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnEditar" runat="server" AlternateText="Editar" ImageUrl="~/imagens/ic_ok.png"
                                                        CommandName="editar" ToolTip="Editar" CommandArgument='<%#Eval("id")%>' Style="text-decoration: underline;
                                                        top: 0px; left: 2px; height: 22px; width: 28px" OnClientClick='return confirm("Confirmar Alteração?");' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnDeletar" runat="server" AlternateText="Deletar" ImageUrl="~/imagens/delete.png"
                                                        CommandName="remover" ToolTip="Excluir" CommandArgument='<%#Eval("id")%>' Style="text-decoration: underline;"
                                                        OnClientClick='return confirm("Confirmar Exclusão?");' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <EmptyDataTemplate>
                                            <label>
                                                Sem Registros.</label>
                                        </EmptyDataTemplate>
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#5D7B9D" ForeColor="Red" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    </asp:GridView>
                                </fieldset>
                            </div>
                        </asp:Panel>
                        <%--<iframe id="frm1" src="http://localhost/NetShopping/Home.aspx" width="800px"  ></iframe>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanelModelo" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="panelModelo" Visible="false" Width="800px" Height="630px" runat="server"
                            CssClass="intropanel" ScrollBars="None">
                            <div class="blocoGrupoCampos" style="margin-left: 18px; width: 800px;">
                                <fieldset class="bordaFieldset" style="width: 737px;">
                                    <legend>Cadastar Modelo</legend>
                                    <div class="blocoGrupoCampos">
                                        <div class="blocoeditor" style="margin-left: 0px">
                                            <label style="margin-left: 0px">
                                                Modelo</label>
                                            <br />
                                            <asp:TextBox ID="txtModelo" runat="server" Width="300px"> </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="btnModeloSalvar"
                                                Text="*" ControlToValidate="txtModelo" ForeColor="Red" runat="server"> </asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="blocoGrupoCampos">
                                        <div class="blocoeditor" style="margin-left: 0px;">
                                            <asp:Button ID="btnModeloSalvar" ValidationGroup="btnModeloSalvar" runat="server"
                                                Width="120px" Height="40px" Style="background-image: url(imagens/ic_ok.png);
                                                background-repeat: no-repeat; background-position: center;" BackColor="White"
                                                ForeColor="Black" OnClientClick='return confirm("Tem certeza que deseja SALVAR?");'
                                                Text="        Salvar" ToolTip="Salvar" OnClick="btnModeloSalvar_Click" />
                                        </div>
                                        <div class="blocoeditor" style="margin-left: 8px;">
                                            <asp:Button ID="btnModeloCancelar" runat="server" Width="120px" Height="40px" Style="background-image: url('imagens/icon/back.png');
                                                background-repeat: no-repeat; background-position: center; top: 0px; left: 0px;"
                                                BackColor="White" ForeColor="Black" Text="          Voltar " ToolTip="Voltar"
                                                OnClick="btnModeloCancelar_Click" />
                                        </div>
                                        <div class="blocoeditor">
                                            <asp:Label ID="lbModeloAviso" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                            <div class="blocoGrupoCampos" style="margin-left: 18px; width: 750px;">
                                <fieldset class="bordaFieldset" style="width: 737px; height: 390px">
                                    <legend>Lista de Modelos</legend>
                                    <asp:GridView ID="GridModelo" Width="735px" runat="server" AutoGenerateColumns="False"
                                       AlternatingRowStyle-BackColor="#B4EEB4" PageSize="10" CellPadding="4" ForeColor="#333333"
                                        AllowPaging="True" GridLines="None" DataKeyNames="id" OnPageIndexChanging="GridModelo_PageIndexChanging"
                                        OnRowCommand="GridModelo_RowCommand">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbId" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="id" HeaderText="Id">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Modelo">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtModelo" Width="300px" runat="server" Text='<%# Eval("nome") %>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnEditar" runat="server" AlternateText="Editar" ImageUrl="~/imagens/ic_ok.png"
                                                        CommandName="editar" ToolTip="Editar" CommandArgument='<%#Eval("id")%>' Style="text-decoration: underline;
                                                        top: 0px; left: 2px; height: 22px; width: 28px" OnClientClick='return confirm("Confirmar Alteração?");' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnDeletar" runat="server" AlternateText="Deletar" ImageUrl="~/imagens/delete.png"
                                                        CommandName="remover" ToolTip="Excluir" CommandArgument='<%#Eval("id")%>' Style="text-decoration: underline;"
                                                        OnClientClick='return confirm("Confirmar Exclusão?");' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <EmptyDataTemplate>
                                            <label>
                                                Sem Registros.</label>
                                        </EmptyDataTemplate>
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#5D7B9D" ForeColor="Red" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    </asp:GridView>
                                </fieldset>
                            </div>
                        </asp:Panel>
                        <%--<iframe id="frm1" src="http://localhost/NetShopping/Home.aspx" width="800px"  ></iframe>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanelExportador" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="panelExportador" Visible="false" Width="800px" Height="630px" runat="server"
                            CssClass="intropanel" ScrollBars="None">
                            <div class="blocoGrupoCampos" style="margin-left: 18px; width: 800px;">
                                <fieldset class="bordaFieldset" style="width: 737px;">
                                    <legend>Cadastar Exportador</legend>
                                    <div class="blocoGrupoCampos">
                                        <div class="blocoeditor" style="margin-left: 0px">
                                            <label style="margin-left: 0px">
                                                Exportador</label>
                                            <br />
                                            <asp:TextBox ID="txtExportador" runat="server" Width="300px"> </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="btnExportadorSalvar"
                                                Text="*" ControlToValidate="txtExportador" ForeColor="Red" runat="server"> </asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="blocoGrupoCampos">
                                        <div class="blocoeditor" style="margin-left: 0px;">
                                            <asp:Button ID="btnExportadorSalvar" ValidationGroup="btnExportadorSalvar" runat="server"
                                                Width="120px" Height="40px" Style="background-image: url(imagens/ic_ok.png);
                                                background-repeat: no-repeat; background-position: center;" BackColor="White"
                                                ForeColor="Black" OnClientClick='return confirm("Tem certeza que deseja SALVAR?");'
                                                Text="        Salvar" ToolTip="Salvar" OnClick="btnExportadorSalvar_Click" />
                                        </div>
                                        <div class="blocoeditor" style="margin-left: 8px;">
                                            <asp:Button ID="btnExportadorCancelar" runat="server" Width="120px" Height="40px"
                                                Style="background-image: url('imagens/icon/back.png'); background-repeat: no-repeat;
                                                background-position: center; top: 0px; left: 0px;" BackColor="White" ForeColor="Black"
                                                Text="          Voltar " ToolTip="Voltar" OnClick="btnExportadorCancelar_Click" />
                                        </div>
                                        <div class="blocoeditor">
                                            <asp:Label ID="lbExportadorAviso" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                            <div class="blocoGrupoCampos" style="margin-left: 18px; width: 750px;">
                                <fieldset class="bordaFieldset" style="width: 737px; height: 390px">
                                    <legend>Lista de Exportadores</legend>
                                    <asp:GridView ID="GridExportador" Width="735px" runat="server" AutoGenerateColumns="False"
                                      AlternatingRowStyle-BackColor="#B4EEB4" PageSize="10" CellPadding="4" ForeColor="#333333"
                                        AllowPaging="True" GridLines="None" DataKeyNames="id" OnPageIndexChanging="GridExportador_PageIndexChanging"
                                        OnRowCommand="GridExportador_RowCommand">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbId" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="id" HeaderText="Id">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Exportador">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtExportador" Width="300px" runat="server" Text='<%# Eval("nome") %>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnEditar" runat="server" AlternateText="Editar" ImageUrl="~/imagens/ic_ok.png"
                                                        CommandName="editar" ToolTip="Editar" CommandArgument='<%#Eval("id")%>' Style="text-decoration: underline;
                                                        top: 0px; left: 2px; height: 22px; width: 28px" OnClientClick='return confirm("Confirmar Alteração?");' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnDeletar" runat="server" AlternateText="Deletar" ImageUrl="~/imagens/delete.png"
                                                        CommandName="remover" ToolTip="Excluir" CommandArgument='<%#Eval("id")%>' Style="text-decoration: underline;"
                                                        OnClientClick='return confirm("Confirmar Exclusão?");' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <EmptyDataTemplate>
                                            <label>
                                                Sem Registros.</label>
                                        </EmptyDataTemplate>
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#5D7B9D" ForeColor="Red" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    </asp:GridView>
                                </fieldset>
                            </div>
                        </asp:Panel>
                        <%--<iframe id="frm1" src="http://localhost/NetShopping/Home.aspx" width="800px"  ></iframe>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanelDespachante" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="panelDespachante" Visible="false" Width="800px" Height="630px" runat="server"
                            CssClass="intropanel" ScrollBars="None">
                            <div class="blocoGrupoCampos" style="margin-left: 18px; width: 800px;">
                                <fieldset class="bordaFieldset" style="width: 737px;">
                                    <legend>Cadastar Despachante</legend>
                                    <div class="blocoGrupoCampos">
                                        <div class="blocoeditor" style="margin-left: 0px">
                                            <label style="margin-left: 0px">
                                                Despachante</label>
                                            <br />
                                            <asp:TextBox ID="txtDespachante" runat="server" Width="300px"> </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="btnDespachanteSalvar"
                                                Text="*" ControlToValidate="txtDespachante" ForeColor="Red" runat="server"> </asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="blocoGrupoCampos">
                                        <div class="blocoeditor" style="margin-left: 0px;">
                                            <asp:Button ID="btnDespachanteSalvar" ValidationGroup="btnDespachanteSalvar" runat="server"
                                                Width="120px" Height="40px" Style="background-image: url(imagens/ic_ok.png);
                                                background-repeat: no-repeat; background-position: center;" BackColor="White"
                                                ForeColor="Black" OnClientClick='return confirm("Tem certeza que deseja SALVAR?");'
                                                Text="        Salvar" ToolTip="Salvar" OnClick="btnDespachanteSalvar_Click" />
                                        </div>
                                        <div class="blocoeditor" style="margin-left: 8px;">
                                            <asp:Button ID="btnDespachanteCancelar" runat="server" Width="120px" Height="40px"
                                                Style="background-image: url('imagens/icon/back.png'); background-repeat: no-repeat;
                                                background-position: center; top: 0px; left: 0px;" BackColor="White" ForeColor="Black"
                                                Text="          Voltar " ToolTip="Voltar" OnClick="btnDespachanteCancelar_Click" />
                                        </div>
                                        <div class="blocoeditor">
                                            <asp:Label ID="lbDespachanteAviso" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                            <div class="blocoGrupoCampos" style="margin-left: 18px; width: 750px;">
                                <fieldset class="bordaFieldset" style="width: 737px; height: 390px">
                                    <legend>Lista de Despachantes</legend>
                                    <asp:GridView ID="GridDespachante" Width="735px" runat="server" AutoGenerateColumns="False"
                                        AlternatingRowStyle-BackColor="#B4EEB4" PageSize="10" CellPadding="4" ForeColor="#333333"
                                        AllowPaging="True" GridLines="None" DataKeyNames="id" OnPageIndexChanging="GridDespachante_PageIndexChanging"
                                        OnRowCommand="GridDespachante_RowCommand">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbId" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="id" HeaderText="Id">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Despachante">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtDespachante" Width="300px" runat="server" Text='<%# Eval("nome") %>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnEditar" runat="server" AlternateText="Editar" ImageUrl="~/imagens/ic_ok.png"
                                                        CommandName="editar" ToolTip="Editar" CommandArgument='<%#Eval("id")%>' Style="text-decoration: underline;
                                                        top: 0px; left: 2px; height: 22px; width: 28px" OnClientClick='return confirm("Confirmar Alteração?");' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnDeletar" runat="server" AlternateText="Deletar" ImageUrl="~/imagens/delete.png"
                                                        CommandName="remover" ToolTip="Excluir" CommandArgument='<%#Eval("id")%>' Style="text-decoration: underline;"
                                                        OnClientClick='return confirm("Confirmar Exclusão?");' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <EmptyDataTemplate>
                                            <label>
                                                Sem Registros.</label>
                                        </EmptyDataTemplate>
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                       <PagerStyle BackColor="#5D7B9D" ForeColor="Red" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    </asp:GridView>
                                </fieldset>
                            </div>
                        </asp:Panel>
                        <%--<iframe id="frm1" src="http://localhost/NetShopping/Home.aspx" width="800px"  ></iframe>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanelForwarder" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="panelForwarder" Visible="false" Width="800px" Height="630px" runat="server"
                            CssClass="intropanel" ScrollBars="None">
                            <div class="blocoGrupoCampos" style="margin-left: 18px; width: 800px;">
                                <fieldset class="bordaFieldset" style="width: 737px;">
                                    <legend>Cadastar Forwarder</legend>
                                    <div class="blocoGrupoCampos">
                                        <div class="blocoeditor" style="margin-left: 0px">
                                            <label style="margin-left: 0px">
                                                Forwarder</label>
                                            <br />
                                            <asp:TextBox ID="txtForwarder" runat="server" Width="300px"> </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="btnForwarderSalvar"
                                                Text="*" ControlToValidate="txtForwarder" ForeColor="Red" runat="server"> </asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="blocoGrupoCampos">
                                        <div class="blocoeditor" style="margin-left: 0px;">
                                            <asp:Button ID="btnForwarderSalvar" ValidationGroup="btnForwarderSalvar" runat="server"
                                                Width="120px" Height="40px" Style="background-image: url(imagens/ic_ok.png);
                                                background-repeat: no-repeat; background-position: center;" BackColor="White"
                                                ForeColor="Black" OnClientClick='return confirm("Tem certeza que deseja SALVAR?");'
                                                Text="        Salvar" ToolTip="Salvar" OnClick="btnForwarderSalvar_Click" />
                                        </div>
                                        <div class="blocoeditor" style="margin-left: 8px;">
                                            <asp:Button ID="btnForwarderCancelar" runat="server" Width="120px" Height="40px"
                                                Style="background-image: url('imagens/icon/back.png'); background-repeat: no-repeat;
                                                background-position: center; top: 0px; left: 0px;" BackColor="White" ForeColor="Black"
                                                Text="          Voltar " ToolTip="Voltar" OnClick="btnForwarderCancelar_Click" />
                                        </div>
                                        <div class="blocoeditor">
                                            <asp:Label ID="lbForwarderAviso" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                            <div class="blocoGrupoCampos" style="margin-left: 18px; width: 750px;">
                                <fieldset class="bordaFieldset" style="width: 737px; height: 390px">
                                    <legend>Lista de Forwarder</legend>
                                    <asp:GridView ID="GridForwarder" Width="735px" runat="server" AutoGenerateColumns="False"
                                        AlternatingRowStyle-BackColor="#B4EEB4" PageSize="10" CellPadding="4" ForeColor="#333333"
                                        AllowPaging="True" GridLines="None" DataKeyNames="id" OnPageIndexChanging="GridForwarder_PageIndexChanging"
                                        OnRowCommand="GridForwarder_RowCommand">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbId" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="id" HeaderText="Id">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Forwarder">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtForwarder" Width="300px" runat="server" Text='<%# Eval("nome") %>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnEditar" runat="server" AlternateText="Editar" ImageUrl="~/imagens/ic_ok.png"
                                                        CommandName="editar" ToolTip="Editar" CommandArgument='<%#Eval("id")%>' Style="text-decoration: underline;
                                                        top: 0px; left: 2px; height: 22px; width: 28px" OnClientClick='return confirm("Confirmar Alteração?");' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnDeletar" runat="server" AlternateText="Deletar" ImageUrl="~/imagens/delete.png"
                                                        CommandName="remover" ToolTip="Excluir" CommandArgument='<%#Eval("id")%>' Style="text-decoration: underline;"
                                                        OnClientClick='return confirm("Confirmar Exclusão?");' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <EmptyDataTemplate>
                                            <label>
                                                Sem Registros.</label>
                                        </EmptyDataTemplate>
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#5D7B9D" ForeColor="Red" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    </asp:GridView>
                                </fieldset>
                            </div>
                        </asp:Panel>
                        <%--<iframe id="frm1" src="http://localhost/NetShopping/Home.aspx" width="800px"  ></iframe>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanelTranpLocal" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="panelTranspLocal" Visible="false" Width="800px" Height="630px" runat="server"
                            CssClass="intropanel" ScrollBars="None">
                            <div class="blocoGrupoCampos" style="margin-left: 18px; width: 800px;">
                                <fieldset class="bordaFieldset" style="width: 737px;">
                                    <legend>Cadastar Transporte Local</legend>
                                    <div class="blocoGrupoCampos">
                                        <div class="blocoeditor" style="margin-left: 0px">
                                            <label style="margin-left: 0px">
                                                Transp. Local</label>
                                            <br />
                                            <asp:TextBox ID="txtTranspLocal" runat="server" Width="300px"> </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="btnTranspLocalSalvar"
                                                Text="*" ControlToValidate="txtTranspLocal" ForeColor="Red" runat="server"> </asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="blocoGrupoCampos">
                                        <div class="blocoeditor" style="margin-left: 0px;">
                                            <asp:Button ID="btnTranspLocalSalvar" ValidationGroup="btnTranspLocalSalvar" runat="server"
                                                Width="120px" Height="40px" Style="background-image: url(imagens/ic_ok.png);
                                                background-repeat: no-repeat; background-position: center;" BackColor="White"
                                                ForeColor="Black" OnClientClick='return confirm("Tem certeza que deseja SALVAR?");'
                                                Text="        Salvar" ToolTip="Salvar" OnClick="btnTranspLocalSalvar_Click" />
                                        </div>
                                        <div class="blocoeditor" style="margin-left: 8px;">
                                            <asp:Button ID="btnTranspLocalCancelar" runat="server" Width="120px" Height="40px"
                                                Style="background-image: url('imagens/icon/back.png'); background-repeat: no-repeat;
                                                background-position: center; top: 0px; left: 0px;" BackColor="White" ForeColor="Black"
                                                Text="          Voltar " ToolTip="Voltar" OnClick="btnTranspLocalCancelar_Click" />
                                        </div>
                                        <div class="blocoeditor">
                                            <asp:Label ID="lbTranspLocalAviso" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                            <div class="blocoGrupoCampos" style="margin-left: 18px; width: 750px;">
                                <fieldset class="bordaFieldset" style="width: 737px; height: 390px">
                                    <legend>Lista de Transpote Local</legend>
                                    <asp:GridView ID="GridTranspLocal" Width="735px" runat="server" AutoGenerateColumns="False"
                                     AlternatingRowStyle-BackColor="#B4EEB4" PageSize="10" CellPadding="4" ForeColor="#333333"
                                        AllowPaging="True" GridLines="None" DataKeyNames="id" OnPageIndexChanging="GridTranspLocal_PageIndexChanging"
                                        OnRowCommand="GridTranspLocal_RowCommand">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbId" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="id" HeaderText="Id">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Tranporte Local">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtTranpLocal" Width="300px" runat="server" Text='<%# Eval("nome") %>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnEditar" runat="server" AlternateText="Editar" ImageUrl="~/imagens/ic_ok.png"
                                                        CommandName="editar" ToolTip="Editar" CommandArgument='<%#Eval("id")%>' Style="text-decoration: underline;
                                                        top: 0px; left: 2px; height: 22px; width: 28px" OnClientClick='return confirm("Confirmar Alteração?");' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnDeletar" runat="server" AlternateText="Deletar" ImageUrl="~/imagens/delete.png"
                                                        CommandName="remover" ToolTip="Excluir" CommandArgument='<%#Eval("id")%>' Style="text-decoration: underline;"
                                                        OnClientClick='return confirm("Confirmar Exclusão?");' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <EmptyDataTemplate>
                                            <label>
                                                Sem Registros.</label>
                                        </EmptyDataTemplate>
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                       <PagerStyle BackColor="#5D7B9D" ForeColor="Red" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    </asp:GridView>
                                </fieldset>
                            </div>
                        </asp:Panel>
                        <%--<iframe id="frm1" src="http://localhost/NetShopping/Home.aspx" width="800px"  ></iframe>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanelRecinto" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="panelRecinto" Visible="false" Width="800px" Height="630px" runat="server"
                            CssClass="intropanel" ScrollBars="None">
                            <div class="blocoGrupoCampos" style="margin-left: 18px; width: 800px;">
                                <fieldset class="bordaFieldset" style="width: 737px;">
                                    <legend>Cadastar Recinto</legend>
                                    <div class="blocoGrupoCampos">
                                        <div class="blocoeditor" style="margin-left: 0px">
                                            <label style="margin-left: 0px">
                                                Recinto</label>
                                            <br />
                                            <asp:TextBox ID="txtRecinto" runat="server" Width="300px"> </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ValidationGroup="btnRecintoSalvar"
                                                Text="*" ControlToValidate="txtRecinto" ForeColor="Red" runat="server"> </asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="blocoGrupoCampos">
                                        <div class="blocoeditor" style="margin-left: 0px;">
                                            <asp:Button ID="btnRecintoSalvar" ValidationGroup="btnRecintoSalvar" runat="server"
                                                Width="120px" Height="40px" Style="background-image: url(imagens/ic_ok.png);
                                                background-repeat: no-repeat; background-position: center;" BackColor="White"
                                                ForeColor="Black" OnClientClick='return confirm("Tem certeza que deseja SALVAR?");'
                                                Text="        Salvar" ToolTip="Salvar" OnClick="btnRecintoSalvar_Click" />
                                        </div>
                                        <div class="blocoeditor" style="margin-left: 8px;">
                                            <asp:Button ID="btnRecintoCancelar" runat="server" Width="120px" Height="40px" Style="background-image: url('imagens/icon/back.png');
                                                background-repeat: no-repeat; background-position: center; top: 0px; left: 0px;"
                                                BackColor="White" ForeColor="Black" Text="          Voltar " ToolTip="Voltar"
                                                OnClick="btnRecintoCancelar_Click" />
                                        </div>
                                        <div class="blocoeditor">
                                            <asp:Label ID="lbRecintoAviso" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                            <div class="blocoGrupoCampos" style="margin-left: 18px; width: 750px;">
                                <fieldset class="bordaFieldset" style="width: 737px; height: 390px">
                                    <legend>Lista de Recintos</legend>
                                    <asp:GridView ID="GridRecinto" Width="735px" runat="server" AutoGenerateColumns="False"
                                      AlternatingRowStyle-BackColor="#B4EEB4" PageSize="10" CellPadding="4" ForeColor="#333333"
                                        AllowPaging="True" GridLines="None" DataKeyNames="id" OnRowCommand="GridRecinto_RowCommand"
                                        OnPageIndexChanging="GridRecinto_PageIndexChanging">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbId" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="id" HeaderText="Id">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Recinto">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtRecinto" Width="300px" runat="server" Text='<%# Eval("nome") %>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnEditar" runat="server" AlternateText="Editar" ImageUrl="~/imagens/ic_ok.png"
                                                        CommandName="editar" ToolTip="Editar" CommandArgument='<%#Eval("id")%>' Style="text-decoration: underline;
                                                        top: 0px; left: 2px; height: 22px; width: 28px" OnClientClick='return confirm("Confirmar Alteração?");' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnDeletar" runat="server" AlternateText="Deletar" ImageUrl="~/imagens/delete.png"
                                                        CommandName="remover" ToolTip="Excluir" CommandArgument='<%#Eval("id")%>' Style="text-decoration: underline;"
                                                        OnClientClick='return confirm("Confirmar Exclusão?");' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <EmptyDataTemplate>
                                            <label>
                                                Sem Registros.</label>
                                        </EmptyDataTemplate>
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#5D7B9D" ForeColor="Red" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    </asp:GridView>
                                </fieldset>
                            </div>
                        </asp:Panel>
                        <%--<iframe id="frm1" src="http://localhost/NetShopping/Home.aspx" width="800px"  ></iframe>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanelMoeda" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="panelMoeda" Visible="false" Width="800px" Height="630px" runat="server"
                            CssClass="intropanel" ScrollBars="None">
                            <div class="blocoGrupoCampos" style="margin-left: 18px; width: 800px;">
                                <fieldset class="bordaFieldset" style="width: 737px;">
                                    <legend>Cadastar Moeda</legend>
                                    <div class="blocoGrupoCampos">
                                        <div class="blocoeditor" style="margin-left: 0px">
                                            <label style="margin-left: 0px">
                                                Moeda</label>
                                            <br />
                                            <asp:TextBox ID="txtMoeda" runat="server" Width="300px"> </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ValidationGroup="btnMoedaSalvar"
                                                Text="*" ControlToValidate="txtMoeda" ForeColor="Red" runat="server"> </asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="blocoGrupoCampos">
                                        <div class="blocoeditor" style="margin-left: 0px;">
                                            <asp:Button ID="btnMoedaSalvar" ValidationGroup="btnMoedaSalvar" runat="server" Width="120px"
                                                Height="40px" Style="background-image: url(imagens/ic_ok.png); background-repeat: no-repeat;
                                                background-position: center;" BackColor="White" ForeColor="Black" OnClientClick='return confirm("Tem certeza que deseja SALVAR?");'
                                                Text="        Salvar" ToolTip="Salvar" OnClick="btnMoedaSalvar_Click" />
                                        </div>
                                        <div class="blocoeditor" style="margin-left: 8px;">
                                            <asp:Button ID="btnMoedaCancelar" runat="server" Width="120px" Height="40px" Style="background-image: url('imagens/icon/back.png');
                                                background-repeat: no-repeat; background-position: center; top: 0px; left: 0px;"
                                                BackColor="White" ForeColor="Black" Text="          Voltar " ToolTip="Voltar"
                                                OnClick="btnMoedaCancelar_Click" />
                                        </div>
                                        <div class="blocoeditor">
                                            <asp:Label ID="lbMoedaAviso" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                            <div class="blocoGrupoCampos" style="margin-left: 18px; width: 750px;">
                                <fieldset class="bordaFieldset" style="width: 737px; height: 390px">
                                    <legend>Lista de Moedas</legend>
                                    <asp:GridView ID="GridMoeda" Width="735px" runat="server" AutoGenerateColumns="False"
                                     AlternatingRowStyle-BackColor="#B4EEB4" PageSize="10" CellPadding="4" ForeColor="#333333"
                                        AllowPaging="True" GridLines="None" DataKeyNames="id" OnPageIndexChanging="GridMoeda_PageIndexChanging"
                                        OnRowCommand="GridMoeda_RowCommand">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbId" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="id" HeaderText="Id">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Moeda">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtMoeda" Width="300px" runat="server" Text='<%# Eval("nome") %>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnEditar" runat="server" AlternateText="Editar" ImageUrl="~/imagens/ic_ok.png"
                                                        CommandName="editar" ToolTip="Editar" CommandArgument='<%#Eval("id")%>' Style="text-decoration: underline;
                                                        top: 0px; left: 2px; height: 22px; width: 28px" OnClientClick='return confirm("Confirmar Alteração?");' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnDeletar" runat="server" AlternateText="Deletar" ImageUrl="~/imagens/delete.png"
                                                        CommandName="remover" ToolTip="Excluir" CommandArgument='<%#Eval("id")%>' Style="text-decoration: underline;"
                                                        OnClientClick='return confirm("Confirmar Exclusão?");' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <EmptyDataTemplate>
                                            <label>
                                                Sem Registros.</label>
                                        </EmptyDataTemplate>
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#5D7B9D" ForeColor="Red" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    </asp:GridView>
                                </fieldset>
                            </div>
                        </asp:Panel>
                        <%--<iframe id="frm1" src="http://localhost/NetShopping/Home.aspx" width="800px"  ></iframe>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanelSuframa" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="panelSuframa" Visible="false" Width="800px" Height="630px" runat="server"
                            CssClass="intropanel" ScrollBars="None">
                            <div class="blocoGrupoCampos" style="margin-left: 18px; width: 800px;">
                                <fieldset class="bordaFieldset" style="width: 737px;">
                                    <legend>Cadastar Produto Suframa</legend>
                                    <div class="blocoGrupoCampos">
                                        <div class="blocoeditor" style="margin-left: 0px">
                                            <label style="margin-left: 0px">
                                                Produto</label>
                                            <br />
                                            <asp:TextBox ID="txtProduto" runat="server" Width="300px"> </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ValidationGroup="btnProdutoSalvar"
                                                Text="*" ControlToValidate="txtProduto" ForeColor="Red" runat="server"> </asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="blocoGrupoCampos">
                                        <div class="blocoeditor" style="margin-left: 0px;">
                                            <asp:Button ID="btnProdutoSalvar" ValidationGroup="btnProdutoSalvar" runat="server"
                                                Width="120px" Height="40px" Style="background-image: url(imagens/ic_ok.png);
                                                background-repeat: no-repeat; background-position: center;" BackColor="White"
                                                ForeColor="Black" OnClientClick='return confirm("Tem certeza que deseja SALVAR?");'
                                                Text="        Salvar" ToolTip="Salvar" OnClick="btnProdutoSalvar_Click" />
                                        </div>
                                        <div class="blocoeditor" style="margin-left: 8px;">
                                            <asp:Button ID="btnProdutoCancelar" runat="server" Width="120px" Height="40px" Style="background-image: url('imagens/icon/back.png');
                                                background-repeat: no-repeat; background-position: center; top: 0px; left: 0px;"
                                                BackColor="White" ForeColor="Black" Text="          Voltar " ToolTip="Voltar"
                                                OnClick="btnProdutoCancelar_Click" />
                                        </div>
                                        <div class="blocoeditor">
                                            <asp:Label ID="lbProdutoAviso" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                            <div class="blocoGrupoCampos" style="margin-left: 18px; width: 750px;">
                                <fieldset class="bordaFieldset" style="width: 737px; height: 390px">
                                    <legend>Lista de Produtos Suframa</legend>
                                    <asp:GridView ID="GridProduto" Width="735px" runat="server" AutoGenerateColumns="False"
                                     AlternatingRowStyle-BackColor="#B4EEB4" PageSize="10" CellPadding="4" ForeColor="#333333"
                                        AllowPaging="True" GridLines="None" DataKeyNames="id" OnPageIndexChanging="GridProduto_PageIndexChanging"
                                        OnRowCommand="GridProduto_RowCommand">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbId" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="id" HeaderText="Id">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Produto">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtProduto" Width="300px" runat="server" Text='<%# Eval("produto") %>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnEditar" runat="server" AlternateText="Editar" ImageUrl="~/imagens/ic_ok.png"
                                                        CommandName="editar" ToolTip="Editar" CommandArgument='<%#Eval("id")%>' Style="text-decoration: underline;
                                                        top: 0px; left: 2px; height: 22px; width: 28px" OnClientClick='return confirm("Confirmar Alteração?");' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnDeletar" runat="server" AlternateText="Deletar" ImageUrl="~/imagens/delete.png"
                                                        CommandName="remover" ToolTip="Excluir" CommandArgument='<%#Eval("id")%>' Style="text-decoration: underline;"
                                                        OnClientClick='return confirm("Confirmar Exclusão?");' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <EmptyDataTemplate>
                                            <label>
                                                Sem Registros.</label>
                                        </EmptyDataTemplate>
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#5D7B9D" ForeColor="Red" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    </asp:GridView>
                                </fieldset>
                            </div>
                        </asp:Panel>
                        <%--<iframe id="frm1" src="http://localhost/NetShopping/Home.aspx" width="800px"  ></iframe>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanelIco_Term" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="panelIco_term" Visible="false" Width="800px" Height="630px" runat="server"
                            CssClass="intropanel" ScrollBars="None">
                            <div class="blocoGrupoCampos" style="margin-left: 18px; width: 800px;">
                                <fieldset class="bordaFieldset" style="width: 737px;">
                                    <legend>Cadastar IcoTerm</legend>
                                    <div class="blocoGrupoCampos">
                                        <div class="blocoeditor" style="margin-left: 0px">
                                            <label style="margin-left: 0px">
                                                IcoTerm</label>
                                            <br />
                                            <asp:TextBox ID="txtIconTerm" runat="server" Width="300px"> </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ValidationGroup="btnIcoTermSalvar"
                                                Text="*" ControlToValidate="txtIconTerm" ForeColor="Red" runat="server"> </asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="blocoGrupoCampos">
                                        <div class="blocoeditor" style="margin-left: 0px;">
                                            <asp:Button ID="btnIcoTermSalvar" ValidationGroup="btnIcoTermSalvar" runat="server"
                                                Width="120px" Height="40px" Style="background-image: url(imagens/ic_ok.png);
                                                background-repeat: no-repeat; background-position: center;" BackColor="White"
                                                ForeColor="Black" OnClientClick='return confirm("Tem certeza que deseja SALVAR?");'
                                                Text="        Salvar" ToolTip="Salvar" OnClick="btnIcoTermSalvar_Click" />
                                        </div>
                                        <div class="blocoeditor" style="margin-left: 8px;">
                                            <asp:Button ID="btnIcoTermCancelar" runat="server" Width="120px" Height="40px" Style="background-image: url('imagens/icon/back.png');
                                                background-repeat: no-repeat; background-position: center; top: 0px; left: 0px;"
                                                BackColor="White" ForeColor="Black" Text="          Voltar " ToolTip="Voltar"
                                                OnClick="btnIcoTermCancelar_Click" />
                                        </div>
                                        <div class="blocoeditor">
                                            <asp:Label ID="lbIcoTermAviso" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                            <div class="blocoGrupoCampos" style="margin-left: 18px; width: 750px;">
                                <fieldset class="bordaFieldset" style="width: 737px; height: 390px">
                                    <legend>Lista de IcoTerm</legend>
                                    <asp:GridView ID="GridIcoTerm" Width="735px" runat="server" AutoGenerateColumns="False"
                                       AlternatingRowStyle-BackColor="#B4EEB4" PageSize="10" CellPadding="4" ForeColor="#333333"
                                        AllowPaging="True" GridLines="None" DataKeyNames="id" OnPageIndexChanging="GridIcoTerm_PageIndexChanging"
                                        OnRowCommand="GridIcoTerm_RowCommand">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbId" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="id" HeaderText="Id">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="IcoTerm">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtIcoTerm" Width="300px" runat="server" Text='<%# Eval("nome") %>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnEditar" runat="server" AlternateText="Editar" ImageUrl="~/imagens/ic_ok.png"
                                                        CommandName="editar" ToolTip="Editar" CommandArgument='<%#Eval("id")%>' Style="text-decoration: underline;
                                                        top: 0px; left: 2px; height: 22px; width: 28px" OnClientClick='return confirm("Confirmar Alteração?");' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnDeletar" runat="server" AlternateText="Deletar" ImageUrl="~/imagens/delete.png"
                                                        CommandName="remover" ToolTip="Excluir" CommandArgument='<%#Eval("id")%>' Style="text-decoration: underline;"
                                                        OnClientClick='return confirm("Confirmar Exclusão?");' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <EmptyDataTemplate>
                                            <label>
                                                Sem Registros.</label>
                                        </EmptyDataTemplate>
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#5D7B9D" ForeColor="Red" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    </asp:GridView>
                                </fieldset>
                            </div>
                        </asp:Panel>
                        <%--<iframe id="frm1" src="http://localhost/NetShopping/Home.aspx" width="800px"  ></iframe>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanelArmador" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="panelArmador" Visible="false" Width="800px" Height="630px" runat="server"
                            CssClass="intropanel" ScrollBars="None">
                            <div class="blocoGrupoCampos" style="margin-left: 18px; width: 800px;">
                                <fieldset class="bordaFieldset" style="width: 737px;">
                                    <legend>Cadastar Armador</legend>
                                    <div class="blocoGrupoCampos">
                                        <div class="blocoeditor" style="margin-left: 0px">
                                            <label style="margin-left: 0px">
                                                Armador</label>
                                            <br />
                                            <asp:TextBox ID="txtArmador" runat="server" Width="300px"> </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ValidationGroup="btnArmadorSalvar"
                                                Text="*" ControlToValidate="txtArmador" ForeColor="Red" runat="server"> </asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="blocoGrupoCampos">
                                        <div class="blocoeditor" style="margin-left: 0px;">
                                            <asp:Button ID="btnArmadorSalvar" ValidationGroup="btnArmadorSalvar" runat="server"
                                                Width="120px" Height="40px" Style="background-image: url(imagens/ic_ok.png);
                                                background-repeat: no-repeat; background-position: center;" BackColor="White"
                                                ForeColor="Black" OnClientClick='return confirm("Tem certeza que deseja SALVAR?");'
                                                Text="        Salvar" ToolTip="Salvar" OnClick="btnArmadorSalvar_Click" />
                                        </div>
                                        <div class="blocoeditor" style="margin-left: 8px;">
                                            <asp:Button ID="btnAramadorCancelar" runat="server" Width="120px" Height="40px" Style="background-image: url('imagens/icon/back.png');
                                                background-repeat: no-repeat; background-position: center; top: 0px; left: 0px;"
                                                BackColor="White" ForeColor="Black" Text="          Voltar " ToolTip="Voltar"
                                                OnClick="btnAramadorCancelar_Click" />
                                        </div>
                                        <div class="blocoeditor">
                                            <asp:Label ID="lbArmadorAviso" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                            <div class="blocoGrupoCampos" style="margin-left: 18px; width: 750px;">
                                <fieldset class="bordaFieldset" style="width: 737px; height: 390px">
                                    <legend>Lista de Armadores</legend>
                                    <asp:GridView ID="GridArmador" Width="735px" runat="server" AutoGenerateColumns="False"
                                        AlternatingRowStyle-BackColor="#B4EEB4" PageSize="10" CellPadding="4" ForeColor="#333333"
                                        AllowPaging="True" GridLines="None" DataKeyNames="id" OnPageIndexChanging="GridArmador_PageIndexChanging"
                                        OnRowCommand="GridArmador_RowCommand">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbId" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="id" HeaderText="Id">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Armador">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtArmador" Width="300px" runat="server" Text='<%# Eval("nome") %>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnEditar" runat="server" AlternateText="Editar" ImageUrl="~/imagens/ic_ok.png"
                                                        CommandName="editar" ToolTip="Editar" CommandArgument='<%#Eval("id")%>' Style="text-decoration: underline;
                                                        top: 0px; left: 2px; height: 22px; width: 28px" OnClientClick='return confirm("Confirmar Alteração?");' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnDeletar" runat="server" AlternateText="Deletar" ImageUrl="~/imagens/delete.png"
                                                        CommandName="remover" ToolTip="Excluir" CommandArgument='<%#Eval("id")%>' Style="text-decoration: underline;"
                                                        OnClientClick='return confirm("Confirmar Exclusão?");' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <EmptyDataTemplate>
                                            <label>
                                                Sem Registros.</label>
                                        </EmptyDataTemplate>
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#5D7B9D" ForeColor="Red" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    </asp:GridView>
                                </fieldset>
                            </div>
                        </asp:Panel>
                        <%--<iframe id="frm1" src="http://localhost/NetShopping/Home.aspx" width="800px"  ></iframe>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <div class="footer">
        <asp:Label ID="lbRodape" runat="server" ForeColor="White"></asp:Label>
    </div>
    </form>
</body>
</html>
