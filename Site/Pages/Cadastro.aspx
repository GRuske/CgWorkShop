<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="Site.Pages.Cadastro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cadastro</title>
    <link type="text/css" rel="stylesheet" href="Content/bootstrap.css" />
</head>
    <script src ="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="span10 offset1">
                <div class="row">
                    <h3 class="well"> Cadastro de Cliente</h3>
                    <br />
                    Nome do Cliente: <br />
                    <asp:TextBox ID="txtNome" runat="server" placeholder="Nome Completo" Width="45%" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqiredNome" runat="server" ControlToValidate="txtNome"
                        ErrorMessage="Por favor, digite o seu nome."
                        ForeColor="Red"/>
                    <br /><br />

                    Endereço do Cliente: <br />
                    <asp:TextBox ID="TxtEndereco" runat="server" placeholder="Enderço" Width="50%" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtEndereco"
                        ErrorMessage="Por favor, digite o seu Enderço."
                        ForeColor="Red"/>
                    <br /><br />

                    Email do Cliente: <br />
                    <asp:TextBox ID="TxtEmail" runat="server" placeholder="Email" Width="25%" CssClass="form-control" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtEmail"
                        ErrorMessage="Por favor, digite o seu Email."
                        ForeColor="Red"/>
                    <br /><br />

                    <p>
                        <asp:Label ID="lblMensagem" runat="server"></asp:Label>
                    </p>

                    <asp:Button ID="btnCadastro" runat ="server" Text="Cadastrar" CssClass="btn btn-success btn-lg" OnClick="btnCadastrarCliente" />
                    <a href="/Default.aspx" class="btn btn-default btn-lg">Voltar</a>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
