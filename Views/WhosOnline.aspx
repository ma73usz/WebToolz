<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="WhosOnline.aspx.cs" Inherits="WebToolz.Views.WhosOnline" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" CssClass="table table-hover table-striped" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"></asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Server01ConnectionString %>" SelectCommand="SelectChar" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</asp:Content>
