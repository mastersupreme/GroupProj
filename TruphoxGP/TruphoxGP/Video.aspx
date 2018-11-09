﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSupreme.Master" AutoEventWireup="true" CodeBehind="Video.aspx.cs" Inherits="TruphoxGP.Video" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div id="band" class="container text-center">
        <h3>VIDEOS</h3>
        <asp:DataList ID="dlVideoTrending" runat="server" OnItemCommand="dlVideoTrending_ItemCommand">
            <ItemTemplate>
                 <asp:ImageButton ID="imgATrend" runat="server" ImageUrl='<%#Eval("videoLink") %>' />
                <br />
                <asp:Label ID="lblATrend" runat="server" CommandName="Select" Text='<%#Eval("postTitle") %>'></asp:Label>
            </ItemTemplate>
        </asp:DataList>
        <asp:DataList ID="dlVideoRecent" runat="server" OnItemCommand="dlVideoRecent_ItemCommand">
               <ItemTemplate>
                  <asp:ImageButton ID="imgATrend" CommandName="Select" runat="server" ImageUrl='<%#Eval("videoLink") %>' />
                <br />
                <asp:Label ID="lblATrend" runat="server" Text='<%#Eval("postTitle") %>'></asp:Label>
               </ItemTemplate>
        </asp:DataList>
        <asp:DataList ID="dlVideoFav" runat="server" OnItemCommand="dlVideoFav_ItemCommand">
               <ItemTemplate>
                <asp:ImageButton ID="imgATrend" CommandName="Select" runat="server" ImageUrl='<%#Eval("videoLink") %>' />
                <br />
                <asp:Label ID="lblATrend" runat="server" Text='<%#Eval("postTitle") %>'></asp:Label>
               </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>
