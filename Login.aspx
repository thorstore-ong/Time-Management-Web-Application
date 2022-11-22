<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Time_Management_Web_Application.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section id="main content">
        <section id="wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        <header class="panel-heading">
                            <div class="col-md-4 col-md-offset-4">
                                <h1>Log Into Profile</h1>
                            </div>
                        </header>

         <div class="panel-body">
             <div class="row">
                 <div class="col-md-4 col-md-offset-4">
                     <asp:Label ID="usernameLabel" runat="server" Text="USERNAME:"></asp:Label>
                     <asp:TextBox CssClass="form-control input-sm" ID="txtUsername" Enabled="true" placeholder="Username" runat="server"></asp:TextBox>
                 </div>
             </div>
         </div>

        <div class="panel-body">
             <div class="row">
                 <div class="col-md-4 col-md-offset-4">
                     <asp:Label ID="passwordLabel" runat="server" Text="PASSWORD:"></asp:Label>
                     <asp:TextBox CssClass="form-control input-sm" ID="txtPassword" Enabled="true" placeholder="Password" runat="server"></asp:TextBox>
                 </div>
             </div>
         </div>
                        
         <div class="panel-body">
             <div class="row">
                 <div class="col-md-4 col-md-offset-4">
                   <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary" Width="300px" Text="Log In" OnClick="BtnLogin_Click" />
                 </div>
             </div>
         </div>
                    </section>
                </div>
            </div>
        </section>
    </section>
</asp:Content>
