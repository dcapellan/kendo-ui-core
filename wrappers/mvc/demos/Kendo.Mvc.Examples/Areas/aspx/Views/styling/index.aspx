﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/aspx/Views/Shared/Web.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
    
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="example">
    <div class="demo-section k-header">
        <div class="box-col">
            <ul class="forms">
                <li>
                    <%: Html.Kendo().TextBox().Name("textbox").Value("Input") %>
                </li>

                <li>
                    <%: Html.TextBox("textbox", "Input like AutoComplete", new  { @class="k-textbox" }) %>
                </li>
                <li>
                    <%: Html.TextArea("textarea", "Textarea", new { @class="k-textbox" }) %>
                </li>
            </ul>
        </div>
        <div class="box-col">
            <ul class="forms">
                <li>
                    <%: Html.Kendo().Button().Name("button").Content("Button") %>
                </li>
                <li>
                    <a href="http://www.google.com" class="k-button">Link to Google.com</a>
                </li>
                <li>
                    <span class="k-textbox k-space-left">
                        <%: Html.TextBox("textbox", "Input with icon left") %>
                        <a href="#" class="k-icon k-i-search">&nbsp;</a>
                    </span>
                </li>
                <li>
                    <span class="k-textbox k-space-right">
                        <%: Html.TextBox("textbox", "Input with icon right") %>
                        <a href="#" class="k-icon k-i-search">&nbsp;</a>
                    </span>
                </li>
            </ul>
        </div>
    </div>
    <style>
        .forms li > * {
            width: 200px;
        }
    </style>
</div>
</asp:Content>