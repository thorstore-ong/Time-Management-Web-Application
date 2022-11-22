<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Time_Management_Web_Application.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       
    <section id="main content">
        <section id="wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        <header class="panel-heading">
                            <div class="col-md-4 col-md-offset-4">
                                <h1>Sign Up</h1>
                            </div>
                        </header>

         <div class="panel-body">
             <div class="row">
                 <div class="col-md-4 col-md-offset-4">
                     <asp:Label ID="usernameLabel" runat="server" Text="USERNAME:"></asp:Label>
                     <asp:TextBox CssClass="form-control input-sm" ID="txtUsername" Enabled="true" placeholder="eg. Jeny123" runat="server"></asp:TextBox>
                 </div>
             </div>
         </div>

        <div class="panel-body">
             <div class="row">
                 <div class="col-md-4 col-md-offset-4">
                     <asp:Label ID="passwordLabel" runat="server" Text="PASSWORD:"></asp:Label>
                     <asp:TextBox CssClass="form-control input-sm" ID="txtPassword" Enabled="true" placeholder="eg. %eMNyy456" runat="server"></asp:TextBox>
                 </div>
             </div>
         </div>

          <div class="panel-body">
             <div class="row">
                 <div class="col-md-4 col-md-offset-4">
                     <asp:Label ID="conPassLbl" runat="server" Text="CONFIRM PASSWORD:"></asp:Label>
                     <asp:TextBox CssClass="form-control input-sm" ID="txtconPass" Enabled="true" placeholder="eg. %eMNyy456" runat="server"></asp:TextBox>
                 </div>
             </div>
         </div>
                        
         <div class="panel-body">
             <div class="row">
                 <div class="col-md-4 col-md-offset-4">
                   <asp:Button ID="btnCreate" runat="server" CssClass="btn btn-primary" Width="300px" Text="Create Account" OnClick="BtnCreate_Click" />
                 </div>
             </div>
         </div>
                    </section>
                </div>
            </div>
        </section>
    </section>

</asp:Content>
