<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RemainderOfHours.aspx.cs" Inherits="Time_Management_Web_Application.RemainderOfHours" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<section id="main content">
        <section id="wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        <header class="panel-heading">
                            <div class="col-md-4 col-md-offset-4">
                                <h1>Hours Remaining</h1>
                            </div>
                        </header>

         <div class="panel-body">
             <div class="row">
                 <div class="col-md-4 col-md-offset-4">
                     <asp:Label ID="moduleName" runat="server" Text="Enter Module Name:"></asp:Label>
                     <asp:TextBox CssClass="form-control input-sm" ID="txtmodName" Enabled="true" placeholder="Module Name" runat="server"></asp:TextBox>
                 </div>
             </div>
             <div class="row">
                 <div class="col-md-4 col-md-offset-4">
                     <asp:Label ID="hoursDoneLbl" runat="server" Text="Hours Done:"></asp:Label>
                     <asp:TextBox CssClass="form-control input-sm" ID="txtHoursDone" Enabled="true" placeholder="eg.5" runat="server"></asp:TextBox>
                 </div>
             </div>
             <div class="row">
                 <div class="col-md-4 col-md-offset-4">
                     <asp:Label ID="dateUpdatedLbl" runat="server" Text="Date Updated:"></asp:Label>
                     <asp:TextBox CssClass="form-control input-sm" TextMode="Date" ID="txtDateUpdated" Enabled="true" placeholder="eg.5" runat="server"></asp:TextBox>
                 </div>
             </div>
             </div>
             <div class="panel-button">
                 <div class="row">
                 <div class="col-md-8 col-md-offset-4">
                   <asp:Button ID="btnSubmitHours" runat="server" CssClass="btn btn-primary" Width="200px" Text="Submit" OnClick="BtnSubmitHours_Click"  />
                   <asp:Button ID="btnViewGraph" runat="server" CssClass="btn btn-primary" Width="200px" Text="View Graph" OnClick="BtnViewGraph_Click"/>
                 </div>
             </div>
         </div>
        <div class="panel-dataView">
             <div class="row">
                <div class="col-md-4 col-md-offset-2">
                    <div class="form-group">
                     <asp:Chart ID="hoursRemChart" runat="server" Width="488px">
                        <series>
                            <asp:Series Name="Series1" XValueMember="0" YValueMembers="2"></asp:Series>
                        </series>
                        <chartareas>
                            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                        </chartareas>
                    </asp:Chart>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:STUDENT_MODULESConnectionString %>" SelectCommand="SELECT * FROM [HOURS_REMAINDER]"></asp:SqlDataSource>
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
