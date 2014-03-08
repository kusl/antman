<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ModelWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <p class="well">This is an introductory paragraph!</p>
    <asp:Label ID="lblModelName" runat="server" Text="Full name: "></asp:Label>
    <asp:TextBox ID="txtModelName" runat="server" MaxLength="255"></asp:TextBox> 
    <br />
    <asp:Label ID="lblModelMail" runat="server" Text="Email address: "></asp:Label>
    <asp:TextBox ID="txtModelMail" runat="server" AutoCompleteType="Email" MaxLength="255" TextMode="Email"></asp:TextBox>
    <br />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="submit_Click" />
</asp:Content>
