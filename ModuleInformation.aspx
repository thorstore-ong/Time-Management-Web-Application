<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModuleInformation.aspx.cs" Inherits="Time_Management_Web_Application.ModuleInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section id="main content">
        <section id="wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        <header class="panel-heading">
                            <div class="col-md-4 col-md-offset-4">
                                <h1>Time Management</h1>
                            </div>
                        </header>

         <div class="panel-subHeading">
             <div class="row">
                 <div class="col-md-4 col-md-offset-1">
                      <h3>Module Information:</h3>
                 </div>
             </div>
         </div>

         <div class="panel-body">
             <div class="row">
                 <div class="col-md-4 col-md-offset-1">
                     <div class="form-group">
                     <asp:Label ID="moduleCodeLbl" runat="server" Text="Enter your Module Code:"></asp:Label>
                     <asp:TextBox CssClass="form-control input-sm" ID="txtMCode" Enabled="true" placeholder="ModuleCode" runat="server"></asp:TextBox>
                     </div>
                  </div>
                 <div class="col-md-4 col-md-offset-1">
                    <div class="form-group">
                   <asp:Label ID="modNameLbl" runat="server" Text="Enter your Module Name:"></asp:Label>
                     <asp:TextBox CssClass="form-control input-sm" ID="txtMName" Enabled="true" placeholder="ModuleName" runat="server"></asp:TextBox>
                    </div>
                 </div>
           </div>


             <div class="row">
                 <div class="col-md-4 col-md-offset-1">
                     <div class="form-group">
                     <asp:Label ID="modNumCredLbl" runat="server" Text="Module Credits:"></asp:Label>
                     <asp:TextBox CssClass="form-control input-sm" ID="txtMCred" Enabled="true" placeholder="ModuleCredits" runat="server"></asp:TextBox>
                 </div>
                 </div>
                 <div class="col-md-4 col-md-offset-1">
                     <div class="form-group">
                     <asp:Label ID="classHoursLbl" runat="server" Text="Class Hours Per Week:"></asp:Label>
                     <asp:TextBox CssClass="form-control input-sm" ID="txtClassHours" Enabled="true" placeholder="ClassHours" runat="server"></asp:TextBox>
                     </div>
                 </div>
             </div>
        
        
             <div class="row">
                 <div class="col-md-4 col-md-offset-1">
                     <div class="form-group">
                     <asp:Label ID="semesterLbl" runat="server" Text="Choose Semester:"></asp:Label>
                     <asp:DropDownList CssClass="form-control input-sm" ID="ddSemester" runat="server">
                         <asp:ListItem Text="First"/>
                         <asp:ListItem Text="Second"/>
                     </asp:DropDownList>
                     </div>
                 </div>
                 <div class="col-md-4 col-md-offset-1">
                     <div class="form-group">
                     <asp:Label ID="numOfWeeksLbl" runat="server" Text="Number of Weeks in Semester:"></asp:Label>
                     <asp:TextBox CssClass="form-control input-sm" ID="txtNumOfWeeks" Enabled="true" placeholder="eg. 20" runat="server"></asp:TextBox>
                     </div>
                 </div>
             </div>

             
             <div class="row">
                 <div class="col-md-4 col-md-offset-1">
                     <div class="form-group">
                     <asp:Label ID="Label1" runat="server" Text="Enter Semester Start Date:"></asp:Label>
                      <asp:TextBox CssClass="form-control input-sm" TextMode="Date" ID="txtStartDate" Enabled="true"  runat="server"></asp:TextBox>
                     </div>
                </div>
            </div>
         </div>
            <div class="panel-Buttons">
             <div class="row">
                 <div class="col-md-8 col-md-offset-2">
                     <asp:Button CssClass="btn btn-primary" Width="200px" ID="btnAdd" runat="server" Text="ADD MODULE" OnClick="BtnAdd_Click" />
                     <asp:Button CssClass="btn btn-primary" Width="200px" ID="btnView" runat="server" Text="VIEW MODULES" OnClick="BtnView_Click" />
                     <asp:Button CssClass="btn btn-primary" Width="200px" ID="btnHoursRem" runat="server" Text="HOURS REMAINING" OnClick="BtnHoursRem_Click" />
                 </div>
             </div>
             </div>
           <div class="panel-dataView">
             <div class="row">
                <div class="col-md-4 col-md-offset-2">
                    <div class="form-group">
                    <asp:GridView ID="GridView1" runat="server" ></asp:GridView>
                   </div>
                 </div>
              </div>
           </div>
                    </section>
                </div>
            </div>
        </section>
    </section>
</asp:Content>
