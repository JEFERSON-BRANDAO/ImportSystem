<%@ Page Title="Air Shipment" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="aereo.aspx.cs" Inherits="ImportSystem.aereo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .modalBackground
        {
            top: 0px !important;
            left: 0px !important;
            position: absolute !important;
        }
        .modalPopup
        {
            background-color: #87CEEB;
            padding: 3px;
            z-index: 10001;
        }
    </style>
   <%-- <script type="text/javascript" language="javascript">
        function s() {
            var t = document.getElementById("<%=GridAereo.ClientID%>");
            var t2 = t.cloneNode(true)
            for (i = t2.rows.length - 1; i > 0; i--)
                t2.deleteRow(i)
            t.deleteRow(0)
            a.appendChild(t2)
        }
        window.onload = s
    </script>--%>


    <script language="javascript" type="text/javascript">
        function MakeStaticHeader(gridId, height, width, headerHeight, isFooter) {
            var tbl = document.getElementById(gridId);
            if (tbl) {
                var DivHR = document.getElementById('DivHeaderRow');
                var DivMC = document.getElementById('DivMainContent');
                var DivFR = document.getElementById('DivFooterRow');

                //*** Set divheaderRow Properties ****
                DivHR.style.height = headerHeight + 'px';
                DivHR.style.width = (parseInt(width) - 16) + 'px';
                DivHR.style.position = 'relative';
                DivHR.style.top = '0px';
                DivHR.style.zIndex = '10';
                DivHR.style.verticalAlign = 'top';

                //*** Set divMainContent Properties ****
                DivMC.style.width = width + 'px';
                DivMC.style.height = height + 'px';
                DivMC.style.position = 'relative';
                DivMC.style.top = -headerHeight + 'px';
                DivMC.style.zIndex = '1';

                //*** Set divFooterRow Properties ****
                DivFR.style.width = (parseInt(width) - 16) + 'px';
                DivFR.style.position = 'relative';
                DivFR.style.top = -headerHeight + 'px';
                DivFR.style.verticalAlign = 'top';
                DivFR.style.paddingtop = '2px';

                if (isFooter) {
                    var tblfr = tbl.cloneNode(true);
                    tblfr.removeChild(tblfr.getElementsByTagName('tbody')[0]);
                    var tblBody = document.createElement('tbody');
                    tblfr.style.width = '100%';
                    tblfr.cellSpacing = "0";
                    tblfr.border = "0px";
                    tblfr.rules = "none";
                    //*****In the case of Footer Row *******
                    tblBody.appendChild(tbl.rows[tbl.rows.length - 1]);
                    tblfr.appendChild(tblBody);
                    DivFR.appendChild(tblfr);
                }
                //****Copy Header in divHeaderRow****
                DivHR.appendChild(tbl.cloneNode(true));
            }
        }



        function OnScrollDiv(Scrollablediv) {
            document.getElementById('DivHeaderRow').scrollLeft = Scrollablediv.scrollLeft;
            document.getElementById('DivFooterRow').scrollLeft = Scrollablediv.scrollLeft;
        }


    </script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanelUsuario" runat="server">
        <ContentTemplate>
            <asp:Panel ID="PanelAereo" Width="900px" Height="630px" runat="server" CssClass="intropanel"
                ScrollBars="None">
                <div class="blocoGrupoCampos" style="margin-left: 18px; width: 880px;">
                    <fieldset class="bordaFieldset" style="width: 837px;">
                        <legend>Consultar</legend>
                        <div class="blocoGrupoCampos">
                            <asp:CheckBox ID="chkLiberado" runat="server" Text="Liberado?" />
                        </div>
                        <div class="blocoGrupoCampos">
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Pwce</label>
                                <br />
                                <asp:TextBox ID="txtPwce" runat="server" Width="150px"> </asp:TextBox>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Invoice</label>
                                <br />
                                <asp:TextBox ID="txtInvoice" runat="server" Width="120px"> </asp:TextBox>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    PackList</label>
                                <br />
                                <asp:TextBox ID="txtPackList" runat="server" Width="110px"> </asp:TextBox>
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px">
                                <label style="margin-left: 0px">
                                    Cliente</label>
                                <br />
                                <asp:DropDownList ID="cboCliente" runat="server" Width="110px" meta:resourcekey="cboClienteResource1">
                                </asp:DropDownList>
                            </div>
                            <div class="blocoeditor">
                                <%--  <asp:ImageButton ID="btnPesquisa" runat="server" Height="64px" ImageUrl="~/imagens/icbusca.png"
                                    Width="101px" ToolTip="Consultar" OnClick="btnPesquisa_Click" />--%>
                                <asp:Button ID="btnPesquisa" runat="server" Width="120px" Height="40px" Style="background-image: url(imagens/icon/3105lupa.ico);
                                    background-repeat: no-repeat; background-position: center;" BackColor="White"
                                    ForeColor="Black" Text="    " ToolTip="Pesquisar" OnClick="btnPesquisa_Click" />
                            </div>
                        </div>
                        <div class="blocoGrupoCampos">
                            <div class="blocoeditor" style="margin-left: 0px;">
                                <asp:Button ID="btnCancelar" runat="server" Width="120px" Height="40px" Style="background-image: url(imagens/icon/back.png);
                                    background-repeat: no-repeat; background-position: center;" BackColor="White"
                                    ForeColor="Black" Text="              Voltar" ToolTip="Voltar" OnClick="btnCancelar_Click" />
                            </div>
                            <div class="blocoeditor" style="margin-left: 0px;">
                                <asp:Button ID="btnSalvar" ValidationGroup="btnSalvar" runat="server" Width="120px"
                                    Height="40px" Style="background-image: url(imagens/icon/Add-button.jpg); background-repeat: no-repeat;
                                    background-position: center;" BackColor="White" ForeColor="Black" Text="    Novo"
                                    ToolTip="Novo" OnClick="btnSalvar_Click" />
                            </div>
                            <div class="blocoeditor">
                                <asp:Label ID="lbAviso" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                    </fieldset>
                </div>
                <div class="blocoGrupoCampos" style="margin-left: 18px; width: 850px;">
                    <div class="blocoeditor" style="margin-left: 0px">
                        <label style="margin-left: 0px">
                            Total de registro(s):</label>
                        <asp:Label ID="lbTotalRegistros" runat="server" CssClass="footer"></asp:Label>
                    </div>
                    <div class="blocoeditor" style="margin-left: 0px;">
                        <asp:Button ID="btnExportarExcel" runat="server" Width="120px" Height="40px" Style="background-image: url(imagens/excel2.png);
                            background-repeat: no-repeat; background-position: center;" BackColor="White"
                            ForeColor="Black" Text="" ToolTip="Exportar para excel" OnClick="btnExportarExcel_Click" />
                    </div>
                    <fieldset class="bordaFieldset" style="width: 837px; height: 318px">
                        <legend>Lista de Importação Aerea</legend>
                       
                        <%--<asp:Panel ID="PanelGrid" runat="Server" HorizontalAlign="Center">
                            <div id="a" style="width: 100%">
                            </div>
                            <div style="overflow-y: scroll; overflow-y: scroll; height: 300px; width: 100%">--%>

                             <div id="DivRoot" align="left">
                            <div style="overflow: hidden;" id="DivHeaderRow">
                            </div>
                            <div style="overflow: scroll;" onscroll="OnScrollDiv(this)" id="DivMainContent">
                                <asp:GridView ID="GridAereo" Width="825px" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                                    PageSize="8" CellPadding="4" DataKeyNames="id" BackColor="#003399" BorderColor="#003399"
                                    BorderStyle="None" BorderWidth="1px" OnRowCommand="GridAereo_RowCommand">
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Center" />
                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Pwce">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="HyperLinkPwce" ToolTip="Editar" Text='<%# Eval("pwce") %>' runat="server"
                                                    NavigateUrl='<%# "novoAereo/" + Eval("Id") %>' Font-Underline="True"></asp:HyperLink>
                                            </ItemTemplate>
                                            <HeaderStyle Height="30px" />
                                            <ItemStyle HorizontalAlign="Center" Font-Underline="False" Width="200px" />
                                        </asp:TemplateField>
                                        <%--  <asp:TemplateField HeaderText="Pedido">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLinkPedido" ToolTip="Editar" Text='<%# Eval("pedido") %>'
                                                runat="server" NavigateUrl='<%# "novoAereo?id=" + Eval("Id") %>' Font-Underline="True"></asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Underline="False" />
                                    </asp:TemplateField>--%>
                                        <asp:BoundField DataField="Pedido" HeaderText="Pedido">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Invoice">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkBtnInvoice" ToolTip="Detalhes" Text='<%# Eval("Invoice") %>'
                                                    runat="server" CommandName="selecionar" CommandArgument='<%#Eval("Id")%>' Font-Underline="True"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Font-Underline="False" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="vlr_fob" HeaderText="Vlr Fob">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="hawb" HeaderText="Hawb">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="di" HeaderText="DI">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <%-- <asp:BoundField DataField="canal_rf" HeaderText="Canal RF">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="canal_sefaz" HeaderText="Canal Sefaz">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>--%>
                                        <asp:TemplateField HeaderText="Canal RF">
                                            <ItemTemplate>
                                                <asp:Image ID="imgCanal_rf" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Canal Sefaz">
                                            <ItemTemplate>
                                                <asp:Image ID="imgCanal_sefaz" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <%--  <asp:BoundField DataField="liberacao" HeaderText="Liberação" DataFormatString="{0:dd/MM/yyyy}">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>--%>
                                        <asp:BoundField DataField="etaMao" HeaderText="Eta-MAO" DataFormatString="{0:dd/MM/yyyy}">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Crítico">
                                            <ItemTemplate>
                                                <asp:Image ID="imgCritico" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <%-- <asp:BoundField DataField="liberado" HeaderText="Liberado?">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>--%>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <label>
                                            Sem Registros.</label>
                                    </EmptyDataTemplate>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>

                                 </div>
                            <div id="DivFooterRow" style="overflow: hidden">
                            </div>
                        </div>

                        <%--    </div>
                        </asp:Panel>--%>



                        <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" Style="display: table">
                            <div class="modalPopup" style="width: 825px; overflow-y: scroll; height: 200px">
                                <table style="width: 270px">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbInvoice" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="White"></asp:Label>
                                            <br />
                                            <asp:ImageButton ID="imgBtnCancelar" runat="server" ImageUrl="~/imagens/icon/close.png"
                                                ToolTip="Fechar" />
                                            <br />
                                            <asp:GridView ID="GridInformacao" runat="server" Width="800px" AutoGenerateColumns="False"
                                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                                CellPadding="3">
                                                <Columns>
                                                    <asp:BoundField DataField="fornecedor" HeaderText="Fornecedor">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="packlist" HeaderText="PackList">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="local" HeaderText="Local">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="material" HeaderText="Material">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="forwarder" HeaderText="Forwarder">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="etdOrigin" HeaderText="ETD Origin" DataFormatString="{0:dd/MM/yyyy}">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <%-- <asp:BoundField DataField="etaMao" HeaderText="ETA Mao" DataFormatString="{0:dd/MM/yyyy}">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>--%>
                                                    <asp:BoundField DataField="liberacao" HeaderText="Liberação" DataFormatString="{0:dd/MM/yyyy}">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="dataDi" HeaderText="Data DI" DataFormatString="{0:dd/MM/yyyy}">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="etaFoxconn" HeaderText="ETA Foxconn" DataFormatString="{0:dd/MM/yyyy}">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="recinto" HeaderText="Recinto">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="remark" HeaderText="Remark">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="despachante" HeaderText="Despachante">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="dtEnvio" HeaderText="Dt.Envio Despachante" DataFormatString="{0:dd/MM/yyyy}">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                <RowStyle ForeColor="#000066" />
                                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                <EmptyDataTemplate>
                                                    <label>
                                                        Nenhum item encontrado.</label>
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                        <asp:GridView ID="GridExcel" Width="855px" runat="server" AutoGenerateColumns="False"
                            Visible="false" AlternatingRowStyle-BackColor="#B4EEB4" CellPadding="4" ForeColor="#333333"
                            GridLines="None">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="PWCE" HeaderText="PWCE">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PEDIDO" HeaderText="PEDIDO">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="invoice" HeaderText="INVOICE">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="packlist" HeaderText="PACKLIST">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="material" HeaderText="MATERIAL">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="liberado" HeaderText="LIBERADO">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="vlr_fob" HeaderText="VLR FOB">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="hawb" HeaderText="HAWB">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="mawb" HeaderText="MAWB">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="etd_origin" HeaderText="ETD ORIGIN" NullDisplayText="-"
                                    DataFormatString="{0:dd/MM/yyyy}">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="eta_mao" HeaderText="ETA MAO" NullDisplayText="-" DataFormatString="{0:dd/MM/yyyy}">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="di" HeaderText="DI">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="data_di" HeaderText="DATA DI" NullDisplayText="-" DataFormatString="{0:dd/MM/yyyy}">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="canal_rf" HeaderText="CANAL RF">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="canal_sefaz" HeaderText="CANAL SEFAZ">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="eta_foxconn" HeaderText="ETA FOXCONN" NullDisplayText="-"
                                    DataFormatString="{0:dd/MM/yyyy}">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="remark" HeaderText="REMARK">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="data_envio" HeaderText="DATA ENVIO" NullDisplayText="-"
                                    DataFormatString="{0:dd/MM/yyyy}">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="liberacao" HeaderText="LIBERAÇÃO" NullDisplayText="-"
                                    DataFormatString="{0:dd/MM/yyyy}">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="quantidade" HeaderText="QUANTIDADE">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="etd_mia" HeaderText="ETD MIA" NullDisplayText="-" DataFormatString="{0:dd/MM/yyyy}">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="fornecedor" HeaderText="FORNECEDOR" NullDisplayText="-">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="local" HeaderText="LOCAL" NullDisplayText="-">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="moeda" HeaderText="MOEDA" NullDisplayText="-">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="icoterm" HeaderText="ICOTERM" NullDisplayText="-">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="forwarder" HeaderText="FORWARDER" NullDisplayText="-">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="recinto" HeaderText="RECINTO" NullDisplayText="-">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="despachante" HeaderText="DESPACHANTE" NullDisplayText="-">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <EmptyDataTemplate>
                                <label>
                                    Nenhuma solicitação encontrada.</label>
                            </EmptyDataTemplate>
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                        <asp:ModalPopupExtender ID="ModalPopupExtenderItem" runat="server" PopupControlID="Panel1"
                            BackgroundCssClass="modalBackground" DropShadow="true" TargetControlID="lbTotalRegistros"
                            CancelControlID="imgBtnCancelar" />
                    </fieldset>
                </div>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <%--para corrigir erro na exportação do GridView para excel Sys.WebForms.PageRequestManagerParserErrorException: The message received from the server could not be parsed.--%>
            <asp:PostBackTrigger ControlID="btnExportarExcel"></asp:PostBackTrigger>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
