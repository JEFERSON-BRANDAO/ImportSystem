<%@ Page Title="Novo Maritimo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="novoMaritimo.aspx.cs" Inherits="ImportSystem.novoMaritimo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanelUsuario" runat="server">
        <ContentTemplate>
            <asp:Panel ID="PanelUsuario" Width="800px" Height="690px" runat="server" CssClass="intropanel"
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
                                    Packlist</label>
                                <br />
                                <asp:TextBox ID="txtPacklist" runat="server" Width="150px" Height="30px" meta:resourcekey="txtPedidoResource1"
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
                                    B/L</label>
                                <br />
                                <asp:TextBox ID="txtBL" runat="server" Width="150px" meta:resourcekey="txtBLResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="btnSalvar"
                                    Text="*" ControlToValidate="txtBL" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator6Resource1"></asp:RequiredFieldValidator>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    DI</label>
                                <br />
                                <asp:TextBox ID="txtDI" runat="server" Width="150px" meta:resourcekey="txtDIResource1"></asp:TextBox>
                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="btnSalvar"
                                    Text="*" ControlToValidate="txtDI" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator7Resource1"></asp:RequiredFieldValidator>
                                --%>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Canal RF</label>
                                <br />
                                <asp:DropDownList ID="cboCanalRF" runat="server" Width="110px" meta:resourcekey="cboCanalRFResource1"
                                    Style="top: 0px; left: 0px">
                                </asp:DropDownList>
                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidatorCanalRF" ValidationGroup="btnSalvar"
                                    Text="*" ControlToValidate="cboCanalRF" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidatorCanalRFResource1"></asp:RequiredFieldValidator>
                                --%>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Canal SEFAZ</label>
                                <br />
                                <asp:DropDownList ID="cboCanalSEFAZ" runat="server" Width="110px" meta:resourcekey="cboCanalSEFAZResource1">
                                </asp:DropDownList>
                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidatorCanalSefaz" ValidationGroup="btnSalvar"
                                    Text="*" ControlToValidate="cboCanalSEFAZ" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidatorCanalSefazResource1"></asp:RequiredFieldValidator>
                                --%>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Liberação IRF</label>
                                <br />
                                <asp:TextBox ID="txtLibIRF" runat="server" Width="80px" BackColor="White" meta:resourcekey="txtLibIRFResource1"></asp:TextBox>
                                <asp:CalendarExtender ID="clnLibIRF" runat="server" TargetControlID="txtLibIRF" TodaysDateFormat="dd MMMM, yyyy"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorLibIRF" runat="server"
                                    ErrorMessage="Data Inválida." ControlToValidate="txtLibIRF" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/[12][0-9]{3}$"
                                    ForeColor="#CC0000" ValidationGroup="btnSalvar" meta:resourcekey="RegularExpressionValidatorDataDIResource1"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="blocoGrupoCampos">
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Modelo</label>
                                <br />
                                <asp:DropDownList ID="cboModelo" Width="110px" runat="server" meta:resourcekey="cboModeloResource1">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="btnSalvar"
                                    Text="*" ControlToValidate="cboModelo" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator16Resource1"></asp:RequiredFieldValidator>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Exportador</label>
                                <br />
                                <asp:DropDownList ID="cboExportador" Width="110px" runat="server" meta:resourcekey="cboExportadorResource1">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="btnSalvar"
                                    Text="*" ControlToValidate="cboExportador" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator16Resource1"></asp:RequiredFieldValidator>
                            </div>
                            <%-- <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    ETD HK</label>
                                <br />
                                <asp:TextBox ID="txtEtdHK" runat="server" Width="150px" meta:resourcekey="txtEtdHKResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ValidationGroup="btnSalvar"
                                    Text="*" ControlToValidate="txtEtdHK" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator10Resource1"></asp:RequiredFieldValidator>
                            </div>--%>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    ETD HK</label>
                                <br />
                                <asp:TextBox ID="txtEtdHK" runat="server" Width="80px" BackColor="White" meta:resourcekey="txtEtdHKResource1"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtenderEtdHK" runat="server" TargetControlID="txtEtdHK"
                                    TodaysDateFormat="dd MMMM, yyyy" Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorEtdHK" runat="server"
                                    ErrorMessage="Data Inválida." ControlToValidate="txtEtdHK" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/[12][0-9]{3}$"
                                    ForeColor="#CC0000" ValidationGroup="btnSalvar" meta:resourcekey="RegularExpressionValidatorEtdHKResource1"></asp:RegularExpressionValidator>
                            </div>
                            <%--  <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    ETA MAO</label>
                                <br />
                                <asp:TextBox ID="txtEtaMAO" runat="server" Width="60px" meta:resourcekey="txtEtaMAOResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="btnSalvar"
                                    Text="*" ControlToValidate="txtEtaMAO" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator5Resource1"></asp:RequiredFieldValidator>
                            </div>--%>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    ETA MAO</label>
                                <br />
                                <asp:TextBox ID="txtEtaMAO" runat="server" Width="80px" BackColor="White" meta:resourcekey="txtEtaMAOResource1"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtenderEtaMAO" runat="server" TargetControlID="txtEtaMAO"
                                    TodaysDateFormat="dd MMMM, yyyy" Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorEtaMAO" runat="server"
                                    ErrorMessage="Data Inválida." ControlToValidate="txtEtaMAO" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/[12][0-9]{3}$"
                                    ForeColor="#CC0000" ValidationGroup="btnSalvar" meta:resourcekey="RegularExpressionValidatorEtaMAOResource1"></asp:RegularExpressionValidator>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Recinto</label>
                                <br />
                                <asp:DropDownList ID="cboRecinto" Width="110px" runat="server" meta:resourcekey="cboRecintoResource1">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ValidationGroup="btnSalvar"
                                    Text="*" ControlToValidate="cboRecinto" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator16Resource1"></asp:RequiredFieldValidator>
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
                        </div>
                        <div class="blocoGrupoCampos">
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Data DI</label>
                                <br />
                                <asp:TextBox ID="txtDataDI" runat="server" Width="80px" BackColor="White" meta:resourcekey="txtDataDIResource1"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtenderDtEnvio" runat="server" TargetControlID="txtDataDI"
                                    TodaysDateFormat="dd MMMM, yyyy" Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorDataDI" runat="server"
                                    ErrorMessage="Data Inválida." ControlToValidate="txtDataDI" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/[12][0-9]{3}$"
                                    ForeColor="#CC0000" ValidationGroup="btnSalvar" meta:resourcekey="RegularExpressionValidatorDataEnvioResource1"></asp:RegularExpressionValidator>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Armador</label>
                                <br />
                                <asp:DropDownList ID="cboArmador" Width="110px" runat="server" meta:resourcekey="cboArmadorResource1">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ValidationGroup="btnSalvar"
                                    Text="*" ControlToValidate="cboArmador" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator16Resource1"></asp:RequiredFieldValidator>
                            </div>
                            <%--   <div class="blocoeditor" style="margin-left: 0px">
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
                                    Nr.Container</label>
                                <br />
                                <asp:TextBox ID="txtNrContainer" runat="server" Width="150px" meta:resourcekey="txtNrContainerResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ValidationGroup="btnSalvar"
                                    Text="*" ControlToValidate="txtNrContainer" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator14Resource1"></asp:RequiredFieldValidator>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px; top: 0px; left: 0px;">
                                <label style="margin-left: 0px">
                                    Qtd Pallets Comp.</label>
                                <br />
                                <%-- <asp:TextBox ID="txtQuantidade" runat="server" Width="50px" TextMode="Number" 
                                    meta:resourcekey="txtQuantidadeResource1"></asp:TextBox>--%>
                                <asp:TextBox ID="txtQtdPallet" runat="server" Width="50px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="btnSalvar"
                                    Text="*" ControlToValidate="txtQtdPallet" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator4Resource1"></asp:RequiredFieldValidator>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorNumero" ControlToValidate="txtQtdPallet"
                                    ValidationGroup="btnSalvar" ForeColor="Red" runat="server" ErrorMessage="Somente número"
                                    ValidationExpression="\d+"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="blocoGrupoCampos">
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Data Devolução DEPOT</label>
                                <br />
                                <asp:TextBox ID="txtDataDevolucao" runat="server" Width="80px" BackColor="White"
                                    meta:resourcekey="txtDataDIResource1" Style="top: 0px; left: 0px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtenderDataDevolucao" runat="server" TargetControlID="txtDataDevolucao"
                                    TodaysDateFormat="dd MMMM, yyyy" Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Data Inválida."
                                    ControlToValidate="txtDataDevolucao" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/[12][0-9]{3}$"
                                    ForeColor="#CC0000" ValidationGroup="btnSalvar" meta:resourcekey="RegularExpressionValidatorDataEnvioResource1"></asp:RegularExpressionValidator>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Prod. Suframa</label>
                                <br />
                                <asp:DropDownList ID="cboProdSuframa" Width="110px" runat="server" meta:resourcekey="cboProdSuframaResource1">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" ValidationGroup="btnSalvar"
                                    Text="*" ControlToValidate="cboProdSuframa" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator18Resource1"></asp:RequiredFieldValidator>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Trasp. Local</label>
                                <br />
                                <asp:DropDownList ID="cboTranspLocal" Width="110px" runat="server" meta:resourcekey="cboTranspLocalResource1">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" ValidationGroup="btnSalvar"
                                    Text="*" ControlToValidate="cboTranspLocal" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator17Resource1"></asp:RequiredFieldValidator>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px; top: 0px; left: 0px;">
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
                        </div>
                        <div class="blocoGrupoCampos">
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    BL's Oceanus</label>
                                <br />
                                <asp:TextBox ID="txtBLsOceanus" runat="server" Width="200px" TextMode="MultiLine"
                                    meta:resourcekey="txtBLsOceanusResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" ValidationGroup="btnSalvar"
                                    Text="*" ControlToValidate="txtBLsOceanus" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator14Resource1"></asp:RequiredFieldValidator>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    DTA</label>
                                <br />
                                <asp:TextBox ID="txtDTA" runat="server" Width="200px" TextMode="MultiLine" meta:resourcekey="txtDTAResource1"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator23" ValidationGroup="btnSalvar"
                                    Text="*" ControlToValidate="txtDTA" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator14Resource1"></asp:RequiredFieldValidator>
                                --%>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Fob USD</label>
                                <br />
                                <asp:TextBox ID="txtFobUSD" runat="server" Width="150px" meta:resourcekey="txtFobUSDResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="btnSalvar"
                                    Text="*" ControlToValidate="txtFobUSD" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator6Resource1"></asp:RequiredFieldValidator>
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
                        </div>
                        <div class="blocoeditor" style="margin-left: 0px">
                            <label style="margin-left: 0px">
                                Remarks</label>
                            <br />
                            <asp:TextBox ID="txtRemarks" runat="server" Width="500px" Height="30px" meta:resourcekey="txtRemarksResource1"
                                TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ValidationGroup="btnSalvar"
                                Text="*" ControlToValidate="txtRemarks" ForeColor="Red" runat="server" meta:resourcekey="RequiredFieldValidator14Resource1"></asp:RequiredFieldValidator>
                        </div>
                        <div id="divFormulario" runat="server" visible="false" class="blocoeditor">
                            <label style="margin-left: 0px">
                                Formulário:</label>
                            <br />
                            <asp:ImageButton ID="btnFormulario" runat="server" ImageUrl="~/imagens/icon/RELATORIO.png"
                                ToolTip="Gerar formulário" OnClick="btnFormulario_Click" />
                        </div>
                        <%--  <div class="blocoGrupoCampos">--%>
                        <div class="blocoeditor">
                            <asp:Label ID="lbAviso" runat="server" Visible="False" ForeColor="Red" meta:resourcekey="lbAvisoResource1"></asp:Label>
                            <%--  </div>--%>
                        </div>
                    </fieldset>
                    <%-- <div class="blocoGrupoCampos" style="margin-left: 0px;">
                        <div class="blocoeditor" style="margin-left: 0px;">
                            <asp:Button ID="btnSalvar" ValidationGroup="btnSalvar" runat="server" Width="120px"
                                Height="40px" Style="background-image: url('imagens/ic_ok.png'); background-repeat: no-repeat;
                                background-position: center; top: 0px; left: 0px;" BackColor="White" ForeColor="Black"
                                OnClientClick='return confirm("Tem certeza que deseja SALVAR?");' Text="        Salvar"
                                ToolTip="Salvar" meta:resourcekey="btnSalvarResource1" OnClick="btnSalvar_Click" />
                        </div>
                        <div class="blocoeditor" style="margin-left: 0px;">
                            <asp:Button ID="btnVoltar" runat="server" Width="120px" Height="40px" Style="background-image: url(imagens/icon/back.png);
                                background-repeat: no-repeat; background-position: center;" BackColor="White"
                                ForeColor="Black" Text="          Voltar " ToolTip="Voltar" meta:resourcekey="btnVoltarResource1"
                                OnClick="btnVoltar_Click" />
                        </div>
                    </div>--%>
                    <div class="blocoGrupoCampos" style="margin-left: 0px;">
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
                    </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
