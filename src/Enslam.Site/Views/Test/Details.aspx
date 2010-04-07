<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Enslam.Site.Models.Test>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Heh</div>
        <div class="display-field"><%= Html.Encode(Model.Heh) %></div>
        
        <div class="display-label">Id</div>
        <div class="display-field"><%= Html.Encode(Model.Id) %></div>
        
        <div class="display-label">IsNew</div>
        <div class="display-field"><%= Html.Encode(Model.IsNew) %></div>
        
        <div class="display-label">Version</div>
        <div class="display-field"><%= Html.Encode(Model.Version) %></div>
        
    </fieldset>
    <p>
        <%= Html.ActionLink("Edit", "Edit", new { id=Model.Id }) %> |
        <%= Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

