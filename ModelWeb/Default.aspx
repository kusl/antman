<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ModelWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:TextBox id="txtModelName" runat="server"></asp:TextBox>
    <asp:TextBox id="txtModelMail" runat="server" AutoCompleteType="Email"></asp:TextBox>
    <asp:Button id="btnSubmit" runat="server" Text="Submit" OnClick="submit_Click" />
</asp:Content>
