<%@ Page Title="Formulario Aereo" Language="C#" MasterPageFile="~/Site.Master" ValidateRequest="false"
    AutoEventWireup="true" CodeBehind="FormularioAereo.aspx.cs" Inherits="ImportSystem.FormularioAereo" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="PanelUsuario" Width="900px" Height="630px" runat="server" CssClass="intropanel"
                meta:resourcekey="PanelUsuarioResource1">
                <div class="blocoGrupoCampos" style="margin-left: 25px; width: 900px;">
                    <fieldset class="bordaFieldset" style="width: 856px; margin: 5px; padding: 17px;
                        padding-left: 0px; padding-right: 0px; padding-top: 2px;">
                        <legend>Import System</legend>
                        <div class="blocoGrupoCampos" style="border-bottom-color: transparent; border-bottom-width: medium;
                            border-bottom-style: solid; padding-bottom: 20px; margin-bottom: 20px; height: auto">
                            &nbsp;
                            <fieldset style="width: 220px; display: block; float: left; margin: 10px;">
                                <legend>Aéreo<label style="font-size: x-small; color: Red;">
                                </label>
                                </legend>
                                <%--  <div class="blocoeditor" style="margin-left: 0px">--%>
                                <label style="margin-left: 0px">
                                    PWCE</label>
                                <br />
                                <asp:TextBox ID="txtPwce" runat="server" Width="150px" meta:resourcekey="txtPwceResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPwce" ValidationGroup="btnGerarRelatorio"
                                    Text="*" ControlToValidate="txtPwce" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                                <%-- </div>--%>
                                <br />
                                <br />
                                <asp:Button ID="btnGerarRelatorio" runat="server" Text="Gerar Formulário" ValidationGroup="btnGerarRelatorio"
                                    Width="125px" OnClick="btnGerarRelatorio_Click" />
                            </fieldset>
                            <div class="blocoGrupoCampos">
                                <div class="blocoeditor">
                                    <div class="blocoeditor" style="margin-left: 0px;">
                                        <asp:Button ID="btnVoltar" runat="server" Width="120px" Height="40px" Style="background-image: url(imagens/icon/back.png);
                                            background-repeat: no-repeat; background-position: center;" BackColor="White"
                                            ForeColor="Black" Text=" Voltar " ToolTip="Voltar" meta:resourcekey="btnVoltarResource1"
                                            OnClick="btnVoltar_Click" />
                                    </div>
                                </div>
                                <div class="blocoeditor" style="margin: 10px;">
                                    <asp:Label ID="lblAviso" runat="server" ForeColor="Red" Font-Size="X-Large" Font-Bold="false"></asp:Label>
                                </div>
                                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
                                    <ProgressTemplate>
                                        <div class="blocoGrupoCampos">
                                            <div class="blocoeditor" style="margin: 10px;">
                                                <asp:Label ID="lblCarrega" runat="server" ForeColor="Red" Text="Gerando Formulário..."
                                                    Font-Bold="false"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="blocoGrupoCampos">
                                            <div class="blocoeditor" style="margin: 10px;">
                                                <asp:Image ID="imgCarrega1" runat="server" Style="margin: 0px;" ImageUrl="~/imagens/icon/carregando.gif" />
                                            </div>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>
                        <div class="blocoGrupoCampos" style="margin-left: 15px;">
                            <rsweb:ReportViewer ID="RelatorioAereo" runat="server" Height="300px" Width="800px"
                                Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana"
                                WaitMessageFont-Size="14pt" OnLoad="RelatorioAereo_Load">
                                <LocalReport ReportPath="vazio.rdlc">
                                </LocalReport>
                            </rsweb:ReportViewer>
                            <asp:ObjectDataSource ID="ObjectDataSourceAereo" runat="server" SelectMethod="ListaFormularioAereo"
                                TypeName="Classes.Relatorios">
                                <SelectParameters>
                                    <%--  <asp:ControlParameter ControlID="cboMaterial" Name="IdItem" PropertyName="SelectedValue"
                                    Type="String" />--%>
                                    <asp:RouteParameter Name="IdAereo" RouteKey="id" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </div>
                    </fieldset>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
