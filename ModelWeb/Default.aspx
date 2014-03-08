<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ModelWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <p class="well well-sm">This is an introductory paragraph!</p>
    <div class="input-group">
        <asp:Label ID="lblModelName" runat="server" Text="Full name: "></asp:Label>
        <asp:TextBox ID="txtModelName" runat="server" MaxLength="255" CssClass="form-control"></asp:TextBox>
        <br />
        <asp:Label ID="lblModelMail" runat="server" Text="Email address: "></asp:Label>
        <asp:TextBox ID="txtModelMail" runat="server" AutoCompleteType="Email" MaxLength="255" TextMode="Email" CssClass="form-control"></asp:TextBox>
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="submit_Click" CssClass="btn btn-default form-control" />
    </div>
</asp:Content>
