<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="oficinas_y_mas.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Inicia Sesión</title>
    <link href="https://fonts.googleapis.com/css?family=Karla:400,700&display=swap" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.materialdesignicons.com/4.8.95/css/materialdesignicons.min.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../assets/css/login.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-sm-3 login-section-wrapper">
                    <div class="logoImageWrapper">
                        <img class="logoImage" src="../assets/images/logo.png" alt=""/>
                    </div>
                    <div class="login-wrapper">
                        <h1 class="login-title">Inicia Sesión</h1>
                        <div>
                            <div class="form-group">
                                <label for="email">Usuario</label>
                                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="Usuario" TextMode="Email"/>
                            </div>
                            <div class="form-group mb-4">
                                <label for="password">Contraseña</label>
                                <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" placeholder="Contraseña" TextMode="Password"/>
                            </div>
                            <asp:Button Text="Iniciar sesión" runat="server" ID="btnLogin" CssClass="btn btn-block login-btn" OnClick="btnLogin_Click"/>
                        </div>
                        <a href="" class="forgot-password-link" style="color: rgb(52,136,200);">Olvidaste tu Contraseña?</a>
                    </div>
                </div>
                <div class="col-sm-9 px-0 d-none d-sm-block">
                    <img src="../assets/images/login.jpg" alt="login image" class="login-img">
                </div>
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
</body>
</html>
