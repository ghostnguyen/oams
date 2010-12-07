﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<OAMS.Models.ClientContactDetail>" %>
<div id='<%= "divClientContactDetail_" + Model.ID.ToString() %>' style="float:left;">
    <div style="width:120px;float:left;border:1px solid #000000;margin-right:2px;padding:2px;">
        <%: Model.ContactType!=null?Model.ContactType:"_"%>
    </div>
    <div style="width:200px;float:left;border:1px solid #000000;margin-right:2px;padding:2px;">
        <%: Model.Value != null ? Model.Value : "_"%>
    </div>
    <div style="width:120px;float:left;border:1px solid #000000;margin-right:2px;padding:2px;">
        <%: Model.Note != null ? Model.Note : "_"%>
    </div>
    <div style="width:120px;float:left;border:1px solid #000000;margin-right:2px;padding:2px;">
        <%: Html.ActionLink("Edit", "Edit", "ClientContactDetail", new { href = string.Format("javascript:AjaxEdit({0},'{1}','{2}');", Model.ID, "divClientContactDetail_" + Model.ID.ToString(), Url.Content("~/ClientContactDetail/Edit")) })%>
        |
        <%: Html.ActionLink("Delete", "Delete", "ClientContactDetail", new { href = string.Format("javascript:AjaxDelete({0},'{1}','{2}');", Model.ID, "divClientContactDetail_" + Model.ID.ToString(), Url.Content("~/ClientContactDetail/Delete")) })%>
    </div>
</div>
<div style="clear:both;"></div>