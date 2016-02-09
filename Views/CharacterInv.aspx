<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="CharacterInv.aspx.cs" Inherits="WebToolz.Views.CharacterInv" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="nav nav-tabs">
        <li role="presentation"><a href="CharactersInfo.aspx">Character Table</a></li>
        <li role="presentation" class="active"><a href="CharacterInv.aspx">Character Inventory</a></li>
        <li role="presentation"><a href="BanList.aspx">Ban List</a></li>
    </ul>
 <asp:DropDownList ID="DDL_Char" runat="server" DataSourceID="CharacterInvDS" DataTextField="Name" DataValueField="CharacterIdx"></asp:DropDownList>
    <asp:SqlDataSource ID="CharacterInvDS" runat="server" ConnectionString="<%$ ConnectionStrings:Server01ConnectionString %>" SelectCommand="SELECT [CharacterIdx], [Name] FROM [cabal_character_table]"></asp:SqlDataSource>
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    <br />
    <asp:GridView ID="GridView1" runat="server" Height="80%" Width="80%" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" CssClass="table table-hover table-striped">
        <Columns>
            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
             <asp:BoundField DataField="grade" HeaderText="grade" SortExpression="grade" />
             <asp:BoundField DataField="craft" HeaderText="craft" SortExpression="craft" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getItems" TypeName="WebToolz.Views.CharacterInv"></asp:ObjectDataSource>
</asp:Content>
