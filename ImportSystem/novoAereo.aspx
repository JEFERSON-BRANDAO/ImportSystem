<%@ Page Title="Novo Aereo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="novoAereo.aspx.cs" Inherits="ImportSystem.novoAereo" meta:resourcekey="PageResource1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanelUsuario" runat="server">
        <ContentTemplate>
            <asp:Panel ID="PanelUsuario" Width="800px" Height="700px" runat="server" CssClass="intropanel"
                meta:resourcekey="PanelUsuarioResource1">
                <div class="blocoGrupoCampos" style="margin-left: 18px; width: 800px;">
                    <fieldset class="bordaFieldset" style="width: 737px;">
                        <legend>Cadastrar/Editar</legend>
                        <asp:CheckBox ID="chkCritico" runat="server" Text="CRÍTICO?" />
                        <div class="blocoGrupoCampos">
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    PWCE</label>
                                <br />
                                <asp:TextBox ID="txtPwce" runat="server" Width="150px" meta:resourcekey="txtPwceResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="btnSalvar"
                                    Text="*" ControlToValidate="txtPwce" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    PackList</label>
                                <br />
                                <asp:TextBox ID="txtPackList" runat="server" Width="150px" Height="30px" meta:resourcekey="txtPackListResource1"
                                    TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Pedido</label>
                                <br />
                                <asp:TextBox ID="txtPedido" runat="server" Width="150px" Height="30px" TextMode="MultiLine"
                                    meta:resourcekey="txtPedidoResource1"></asp:TextBox>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Invoice</label>
                                <br />
                                <asp:TextBox ID="txtInvoice" runat="server" Width="150px" Height="30px" meta:resourcekey="txtInvoiceResource1"
                                    TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="btnSalvar"
                                    Text="*" ControlToValidate="txtInvoice" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                            </div>
                            <%--<div class="blocoeditor" style="margin-left: 0px">
                                <br />
                                <asp:CheckBox ID="chkLiberado" Text="Liberado?" runat="server" meta:resourcekey="chkLiberadoResource1" />
                            </div>--%>
                        </div>
                        <div class="blocoGrupoCampos">
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Hawb</label>
                                <br />
                                <asp:TextBox ID="txtHawb" runat="server" Width="150px" meta:resourcekey="txtHawbResource1"></asp:TextBox>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Mawb</label>
                                <br />
                                <asp:TextBox ID="txtMawb" runat="server" Width="150px" meta:resourcekey="txtMawbResource1"></asp:TextBox>
                            </div>
                            <%-- <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    ETD Origin</label>
                                <br />
                                <asp:TextBox ID="txtETDOrigin" runat="server" Width="150px" meta:resourcekey="txtETDOriginResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="btnSalvar"
                                    Text="*" ControlToValidate="txtETDOrigin" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator8Resource1"></asp:RequiredFieldValidator>
                            </div>--%>
                            <%--  <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    ETD Mia</label>
                                <br />
                                <asp:TextBox ID="txtETDMia" runat="server" Width="150px" meta:resourcekey="txtETDMiaResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="btnSalvar"
                                    Text="*" ControlToValidate="txtETDMia" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator9Resource1"></asp:RequiredFieldValidator>
                            </div>--%>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    ETD Origin</label>
                                <br />
                                <asp:TextBox ID="txtETDOrigin" runat="server" Width="80px" BackColor="White" meta:resourcekey="ETDOriginResource1"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtenderETDOrigin" runat="server" TargetControlID="txtETDOrigin"
                                    TodaysDateFormat="dd MMMM, yyyy" Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorETDOrigin" runat="server"
                                    ErrorMessage="Data Inválida." ControlToValidate="txtETDOrigin" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/[12][0-9]{3}$"
                                    ForeColor="#CC0000" ValidationGroup="btnSalvar" meta:resourcekey="RegularExpressionValidatorETDOriginResource1"></asp:RegularExpressionValidator>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    ETD Mia</label>
                                <br />
                                <asp:TextBox ID="txtETDMia" runat="server" Width="80px" BackColor="White" meta:resourcekey="txtETDMiaResource1"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtenderETDMia" runat="server" TargetControlID="txtETDMia"
                                    TodaysDateFormat="dd MMMM, yyyy" Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorETDMia" runat="server"
                                    ErrorMessage="Data Inválida." ControlToValidate="txtETDMia" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/[12][0-9]{3}$"
                                    ForeColor="#CC0000" ValidationGroup="btnSalvar" meta:resourcekey="RegularExpressionValidatortxtETDMiaResource1"></asp:RegularExpressionValidator>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Modelo</label>
                                <br />
                                <asp:DropDownList ID="cboModelo" Width="110px" runat="server" meta:resourcekey="cboModeloResource1">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="btnSalvar"
                                    Text="*" ControlToValidate="cboModelo" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator16Resource1"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="blocoGrupoCampos">
                            <%--   <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    ETA Mao</label>
                                <br />
                                <asp:TextBox ID="txtEtaMao" runat="server" Width="150px" meta:resourcekey="txtEtaMaoResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ValidationGroup="btnSalvar"
                                    Text="*" ControlToValidate="txtEtaMao" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator10Resource1"></asp:RequiredFieldValidator>
                            </div>--%>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    ETA MAO</label>
                                <br />
                                <asp:TextBox ID="txtEtaMao" runat="server" Width="80px" BackColor="White" meta:resourcekey="txtEtaMaoResource1"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtenderEtaMAO" runat="server" TargetControlID="txtEtaMao"
                                    TodaysDateFormat="dd MMMM, yyyy" Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorEtaMAO" runat="server"
                                    ErrorMessage="Data Inválida." ControlToValidate="txtEtaMao" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/[12][0-9]{3}$"
                                    ForeColor="#CC0000" ValidationGroup="btnSalvar" meta:resourcekey="RegularExpressionValidatorEtaMaoResource1"></asp:RegularExpressionValidator>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    DI</label>
                                <br />
                                <asp:TextBox ID="txtDI" runat="server" Width="150px" meta:resourcekey="txtDIResource1"></asp:TextBox>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Data DI</label>
                                <br />
                                <asp:TextBox ID="txtDataDI" runat="server" Width="80px" BackColor="White" meta:resourcekey="txtDataDIResource1"></asp:TextBox>
                                <asp:CalendarExtender ID="clnDataDI" runat="server" TargetControlID="txtDataDI" TodaysDateFormat="dd MMMM, yyyy"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorDataDI" runat="server"
                                    ErrorMessage="Data Inválida." ControlToValidate="txtDataDI" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/[12][0-9]{3}$"
                                    ForeColor="#CC0000" ValidationGroup="btnSalvar" meta:resourcekey="RegularExpressionValidatorDataDIResource1"></asp:RegularExpressionValidator>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Canal RF</label>
                                <br />
                                <asp:DropDownList ID="cboCanalRF" runat="server" Width="110px" meta:resourcekey="cboCanalRFResource1">
                                </asp:DropDownList>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Valor FOB</label>
                                <br />
                                <asp:TextBox ID="txtValorFOB" runat="server" Width="80px" meta:resourcekey="txtValorFOBResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="btnSalvar"
                                    Text="*" ControlToValidate="txtValorFOB" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator5Resource1"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="blocoGrupoCampos">
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Canal SEFAZ</label>
                                <br />
                                <asp:DropDownList ID="cboCanalSEFAZ" runat="server" Width="110px" meta:resourcekey="cboCanalSEFAZResource1">
                                </asp:DropDownList>
                            </div>
                            <%--<div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    ETA Foxconn</label>
                                <br />
                                <asp:TextBox ID="txtEtaFoxconn" runat="server" Width="150px" meta:resourcekey="txtEtaFoxconnResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ValidationGroup="btnSalvar"
                                    Text="*" ControlToValidate="txtEtaFoxconn" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator13Resource1"></asp:RequiredFieldValidator>
                            </div>--%>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    ETA Foxconn</label>
                                <br />
                                <asp:TextBox ID="txtEtaFoxconn" runat="server" Width="80px" BackColor="White" meta:resourcekey="txtEtaFoxconnResource1"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtenderEtaFoxconn" runat="server" TargetControlID="txtEtaFoxconn"
                                    TodaysDateFormat="dd MMMM, yyyy" Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorEtaFoxconn" runat="server"
                                    ErrorMessage="Data Inválida." ControlToValidate="txtEtaFoxconn" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/[12][0-9]{3}$"
                                    ForeColor="#CC0000" ValidationGroup="btnSalvar" meta:resourcekey="RegularExpressionValidatorEtaFoxconnResource1"></asp:RegularExpressionValidator>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Liberação</label>
                                <br />
                                <asp:TextBox ID="txtLiberacao" runat="server" Width="80px" BackColor="White" meta:resourcekey="txtLiberacaoResource1"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtenderLiberacao" runat="server" TargetControlID="txtLiberacao"
                                    TodaysDateFormat="dd MMMM, yyyy" Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorLiberacao" runat="server"
                                    ErrorMessage="Data Inválida." ControlToValidate="txtLiberacao" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/[12][0-9]{3}$"
                                    ForeColor="#CC0000" ValidationGroup="btnSalvar" meta:resourcekey="RegularExpressionValidatorLiberacaoResource1"></asp:RegularExpressionValidator>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Data Envio</label>
                                <br />
                                <asp:TextBox ID="txtDataEnvio" runat="server" Width="80px" BackColor="White" meta:resourcekey="txtDataEnvioResource1"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtenderDtEnvio" runat="server" TargetControlID="txtDataEnvio"
                                    TodaysDateFormat="dd MMMM, yyyy" Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorDataEnvio" runat="server"
                                    ErrorMessage="Data Inválida." ControlToValidate="txtDataEnvio" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/[12][0-9]{3}$"
                                    ForeColor="#CC0000" ValidationGroup="btnSalvar" meta:resourcekey="RegularExpressionValidatorDataEnvioResource1"></asp:RegularExpressionValidator>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Quantidade</label>
                                <br />
                                <%-- <asp:TextBox ID="txtQuantidade" runat="server" Width="50px" TextMode="Number" 
                                    meta:resourcekey="txtQuantidadeResource1"></asp:TextBox>--%>
                                <asp:TextBox ID="txtQuantidade" runat="server" Width="80px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="btnSalvar"
                                    Text="*" ControlToValidate="txtQuantidade" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator4Resource1"></asp:RequiredFieldValidator>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorNumero" ControlToValidate="txtQuantidade"
                                    ValidationGroup="btnSalvar" ForeColor="Red" runat="server" ErrorMessage="Somente número"
                                    ValidationExpression="\d+"></asp:RegularExpressionValidator>
                            </div>
                            <div class="blocoGrupoCampos">
                                <div class="blocoeditor" style="margin-left: 0px">
                                    <label style="margin-left: 0px">
                                        Material</label>
                                    <br />
                                    <asp:TextBox ID="txtMaterial" runat="server" Width="200px" TextMode="MultiLine" meta:resourcekey="txtMaterialResource1"
                                        Height="20px"></asp:TextBox>
                                </div>
                                <div class="blocoeditor" style="margin-left: 0px">
                                    <label style="margin-left: 0px">
                                        Fornecedor</label>
                                    <br />
                                    <asp:DropDownList ID="cboFornecedor" Width="300px" runat="server" meta:resourcekey="cboFornecedorResource1">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ValidationGroup="btnSalvar"
                                        Text="*" ControlToValidate="cboFornecedor" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator16Resource1"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="blocoGrupoCampos">
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Local</label>
                                <br />
                                <asp:DropDownList ID="cboLocal" Width="130px" runat="server" meta:resourcekey="cboLocalResource1">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" ValidationGroup="btnSalvar"
                                    Text="*" ControlToValidate="cboLocal" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator17Resource1"></asp:RequiredFieldValidator>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Moeda</label>
                                <br />
                                <asp:DropDownList ID="cboMoeda" Width="90px" runat="server" meta:resourcekey="cboMoedaResource1">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" ValidationGroup="btnSalvar"
                                    Text="*" ControlToValidate="cboMoeda" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator18Resource1"></asp:RequiredFieldValidator>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Icoterm</label>
                                <br />
                                <asp:DropDownList ID="cboIcoterm" Width="90px" runat="server" meta:resourcekey="cboIcotermResource1">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" ValidationGroup="btnSalvar"
                                    Text="*" ControlToValidate="cboIcoterm" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator19Resource1"></asp:RequiredFieldValidator>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Forwarder</label>
                                <br />
                                <asp:DropDownList ID="cboForwarder" Width="210px" runat="server" meta:resourcekey="cboForwarderResource1">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" ValidationGroup="btnSalvar"
                                    Text="*" ControlToValidate="cboForwarder" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator20Resource1"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="blocoGrupoCampos">
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Recinto</label>
                                <br />
                                <asp:DropDownList ID="cboRecinto" Width="110px" runat="server" meta:resourcekey="cboRecintoResource1">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" ValidationGroup="btnSalvar"
                                    Text="*" ControlToValidate="cboRecinto" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator21Resource1"></asp:RequiredFieldValidator>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Despachante</label>
                                <br />
                                <asp:DropDownList ID="cboDespachante" Width="130px" runat="server" meta:resourcekey="cboDespachanteResource1">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" ValidationGroup="btnSalvar"
                                    Text="*" ControlToValidate="cboDespachante" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator22Resource1"></asp:RequiredFieldValidator>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    EMBARQUE</label>
                                <br />
                                <asp:TextBox ID="txtEmbarque" runat="server" Width="130px"></asp:TextBox>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Cliente</label>
                                <br />
                                <asp:DropDownList ID="cboCliente" runat="server" Width="110px" meta:resourcekey="cboClienteResource1">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCboCliente" ValidationGroup="btnSalvar"
                                    Text="*" ControlToValidate="cboCliente" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidatorcboCliente"></asp:RequiredFieldValidator>
                            </div>
                            <%--<div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Liberação</label>
                                <br />
                                <asp:TextBox ID="txtLiberacao" runat="server" Width="200px" TextMode="MultiLine"
                                    meta:resourcekey="txtLiberacaoResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ValidationGroup="btnSalvar"
                                    Text="*" ControlToValidate="txtLiberacao" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator12Resource1"></asp:RequiredFieldValidator>
                            </div>--%>
                        </div>
                        <div class="blocoeditor" style="margin-left: 0px">
                            <label style="margin-left: 0px">
                                Remark</label>
                            <br />
                            <asp:TextBox ID="txtRemark" runat="server" Width="500px" meta:resourcekey="txtRemarkResource1"
                                Height="30px" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ValidationGroup="btnSalvar"
                                Text="*" ControlToValidate="txtRemark" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator14Resource1"></asp:RequiredFieldValidator>
                        </div>
                        <div id="divFormulario" runat="server" visible="false" class="blocoeditor">
                            <label style="margin-left: 0px">
                                Formulário:</label>
                            <br />
                            <asp:ImageButton ID="btnFormulario" runat="server" ImageUrl="~/imagens/icon/RELATORIO.png"
                                ToolTip="Gerar formulário" OnClick="btnFormulario_Click" />
                        </div>
                        <%-- <div class="blocoGrupoCampos">--%>
                        <div class="blocoeditor">
                            <asp:Label ID="lbAviso" runat="server" Visible="False" ForeColor="Red" meta:resourcekey="lbAvisoResource1"></asp:Label>
                            <%-- </div>--%>
                        </div>
                    </fieldset>
                    <%--   <div class="blocoGrupoCampos" style="margin-left: 0px;">--%>
                    <div class="blocoeditor" style="margin-left: 0px;">
                        <asp:Button ID="btnVoltar" runat="server" Width="120px" Height="40px" Style="background-image: url(imagens/icon/back.png);
                            background-repeat: no-repeat; background-position: center;" BackColor="White"
                            ForeColor="Black" Text=" Voltar " ToolTip="Voltar" OnClick="btnVoltar_Click"
                            meta:resourcekey="btnVoltarResource1" />
                    </div>
                    <div class="blocoeditor" style="margin-left: 0px;">
                        <asp:Button ID="btnSalvar" ValidationGroup="btnSalvar" runat="server" Width="120px"
                            Height="40px" Style="background-image: url(imagens/ic_ok.png); background-repeat: no-repeat;
                            background-position: center;" BackColor="White" ForeColor="Black" OnClientClick='return confirm("Tem certeza que deseja SALVAR?");'
                            Text=" Salvar" ToolTip="Salvar" OnClick="btnSalvar_Click" meta:resourcekey="btnSalvarResource1" />
                    </div>
                    <%--  </div>--%>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
