<%@ Page Title="Demurrage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="demurrage.aspx.cs" Inherits="ImportSystem.demurrage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanelUsuario" runat="server">
        <ContentTemplate>
            <asp:Panel ID="PanelUsuario" Width="800px" Height="630px" runat="server" CssClass="intropanel"
                meta:resourcekey="PanelUsuarioResource1">
                <div class="blocoGrupoCampos" style="margin-left: 18px; width: 800px;">
                    <fieldset class="bordaFieldset" style="width: 763px;">
                        <legend>Cadastrar/Editar</legend>
                        <div class="blocoGrupoCampos">
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Origem</label>
                                <br />
                                <asp:TextBox ID="txtOrigem" runat="server" Width="250px" meta:resourcekey="txtOrigemResource1"></asp:TextBox>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Destino</label>
                                <br />
                                <asp:TextBox ID="txtDestino" runat="server" Width="250px" meta:resourcekey="txtDestinoResource1"></asp:TextBox>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    ETA Mao</label>
                                <br />
                                <asp:TextBox ID="txtEta_MAO" Enabled="false" runat="server" Width="80px" BackColor="White"></asp:TextBox>
                            </div>
                        </div>
                        <div class="blocoGrupoCampos">
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    ETA Foxconn</label>
                                <br />
                                <asp:TextBox ID="txtETA_Foxconn" Enabled="false" runat="server" Width="80px" BackColor="White"></asp:TextBox>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Dt.Ideal Devolução</label>
                                <br />
                                <asp:TextBox ID="txtDtIdealDevolucao" Enabled="false" runat="server" Width="80px"
                                    BackColor="White" meta:resourcekey="DtIdealDevolucaoResource1" Font-Bold="True"
                                    ForeColor="#3333FF"></asp:TextBox>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Venc. Demurrage</label>
                                <br />
                                <asp:TextBox ID="txtVencDemurrage" Enabled="false" runat="server" Width="80px" BackColor="White"
                                    meta:resourcekey="VencDemurrageResource1" Font-Bold="True" ForeColor="#CC3300"></asp:TextBox>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Solicitação Retirada</label>
                                <br />
                                <asp:TextBox ID="txtSolRetirada" runat="server" Width="80px" BackColor="White" meta:resourcekey="SolRetiradaResource1"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtenderSolRetirada" runat="server" TargetControlID="txtSolRetirada"
                                    TodaysDateFormat="dd MMMM, yyyy" Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Data Inválida."
                                    ControlToValidate="txtSolRetirada" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/[12][0-9]{3}$"
                                    ForeColor="#CC0000" ValidationGroup="btnSalvar" meta:resourcekey="RegularExpressionValidatorSolRetiradaResource1"></asp:RegularExpressionValidator>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Entrega no DEPOT</label>
                                <br />
                                <asp:TextBox ID="txtEntregaDepot" runat="server" Width="80px" BackColor="White" meta:resourcekey="EntregaDepotResource1"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtenderEntregaDepot" runat="server" TargetControlID="txtEntregaDepot"
                                    TodaysDateFormat="dd MMMM, yyyy" Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Data Inválida."
                                    ControlToValidate="txtEntregaDepot" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/[12][0-9]{3}$"
                                    ForeColor="#CC0000" ValidationGroup="btnSalvar" meta:resourcekey="RegularExpressionEntregaDepotResource1"></asp:RegularExpressionValidator>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px; top: 0px; left: 0px;">
                                <label style="margin-left: 0px">
                                    Qtd Diarias</label>
                                <br />
                                <asp:TextBox ID="txtQtdDiaria" runat="server" Width="50px" ReadOnly="true"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorNumero" ControlToValidate="txtQtdDiaria"
                                    ValidationGroup="btnSalvar" ForeColor="Red" runat="server" ErrorMessage="Somente número"
                                    ValidationExpression="\d+"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="blocoGrupoCampos">
                            <div class="blocoeditor">
                                <asp:Label ID="lbContagem" runat="server" ForeColor="Gray"></asp:Label>
                            </div>
                        </div>
                        <div class="blocoGrupoCampos">
                            <div class="blocoeditor">
                                <asp:Label ID="lbDiaria" runat="server" ForeColor="Gray"></asp:Label>
                            </div>
                        </div>
                        <div class="blocoGrupoCampos">
                            <div class="blocoeditor">
                                <asp:Label ID="lbAviso" runat="server" Visible="False" ForeColor="Red" meta:resourcekey="lbAvisoResource1"></asp:Label>
                            </div>
                        </div>
                    </fieldset>
                    <div class="blocoGrupoCampos" style="margin-left: 0px;">
                        <div class="blocoeditor" style="margin-left: 0px;">
                            <asp:Button ID="btnVoltar" runat="server" Width="120px" Height="40px" Style="background-image: url(imagens/icon/back.png);
                                background-repeat: no-repeat; background-position: center;" BackColor="White"
                                ForeColor="Black" Text="          Voltar " ToolTip="Voltar" meta:resourcekey="btnVoltarResource1"
                                OnClick="btnVoltar_Click" />
                        </div>
                        <div class="blocoeditor" style="margin-left: 0px;">
                            <asp:Button ID="btnSalvar" ValidationGroup="btnSalvar" runat="server" Width="120px"
                                Height="40px" Style="background-image: url(imagens/ic_ok.png); background-repeat: no-repeat;
                                background-position: center;" BackColor="White" ForeColor="Black" OnClientClick='return confirm("Tem certeza que deseja SALVAR?");'
                                Text="        Salvar" ToolTip="Salvar" meta:resourcekey="btnSalvarResource1"
                                OnClick="btnSalvar_Click" />
                        </div>
                    </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
