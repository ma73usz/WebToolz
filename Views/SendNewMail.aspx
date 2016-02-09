<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="SendNewMail.aspx.cs" Inherits="WebToolz.Views.SendNewMail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        #myDiv {
            position: fixed;
            top: 50%;
            left: 50%;
            width: 30em;
            height: 30em;
            margin-top: -15em; /*set to a negative number 1/2 of your height*/
            margin-left: -15em; /*set to a negative number 1/2 of your width*/   
        }
    </style>
    <div id="myDiv">
        <div class="panel panel-success">
            <div class="panel-heading">Mail Info</div>
            <div class="panel-body">
                <asp:Label ID="Label1" runat="server" Text="Title" CssClass="label label-success"></asp:Label>
                <asp:TextBox ID="TitleTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                <br />
                <asp:Label ID="Label2" runat="server" Text="NickName" CssClass="label label-success"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="CharacterIdx"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Server01ConnectionString %>" SelectCommand="SELECT [CharacterIdx], [Name] FROM [cabal_character_table]"></asp:SqlDataSource>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Alz Amount" CssClass="label label-success"></asp:Label>
                <asp:TextBox ID="AlzTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                <br />
                <asp:Label ID="Label4" runat="server" Text="Message" CssClass="label label-success"></asp:Label>
                <asp:TextBox ID="MessageTextBox" runat="server" CssClass="form-control" OnTextChanged="MessageTextBox_TextChanged"></asp:TextBox>
                <br />
                <asp:Button ID="Button1" runat="server" Text="Button" CssClass="btn btn-success" OnClick="Button1_Click" />
            </div>
        </div>
    </div>
</asp:Content>
