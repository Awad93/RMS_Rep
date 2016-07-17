<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      <section id="timespan" name="timespan">
                <div class="criteria-item">
                    <h4 class="title5-timespan">
                        <a data-toggle="collapse" href="#collapseTimeSpan">Timespan</a>
                    </h4>
                </div>
                <div id="collapseTimeSpan" class="collapse in">
                    <div class="criteria-item">
                        <label>
                            <input name="period" id="rbPeriod" type="radio" value="Range Selection" checked="true" runat="server">
                            <asp:DropDownList ID="ddlTimeSpan" class="timespan-allyears" name="range" runat="server" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlTimeSpan_SelectedIndexChanged">
                                <asp:ListItem Value="All" Selected="True">All years</asp:ListItem>
                                <asp:ListItem Value="Last5Years">Last 5 years</asp:ListItem>
                                <asp:ListItem Value="LastYear">Last Year only</asp:ListItem>
                            </asp:DropDownList>
                        </label>

                    </div>
                    <div class="criteria-item">
                        <p>
                            <label>
                                <input name="period" id="rbPeriodRange" type="radio" value="Year Range" runat="server">
                                <span>
                                    <label for="periodRange">From</label></span>
                                <asp:DropDownList id="ddlFromYear" runat="server" CssClass="timespan-allyears">
                                </asp:DropDownList>

                                <span>to</span>

                                <asp:DropDownList id="ddlToYear" runat="server" CssClass="timespan-allyears">
                                </asp:DropDownList>
                            </label>
                        </p>
                    </div>
                </div>
            </section>

            <!-- MORE -->
            <section id="more" name="more">
                <div class="criteria-item">
                    <h4 class="title5-timespan">
                        <a data-toggle="collapse" href="#collapseMore">More</a>
                    </h4>
                </div>
                <div id="collapseMore" class="collapse in">
                    <div class="criteria-item">
                        <p>
                            <span>
                                <label for="ddlCollege">College</label>
                            </span>
                            <asp:DropDownList ID="ddlCollege" runat="server" CssClass="timespan-allyears" AutoPostBack="true" required
                                OnSelectedIndexChanged="ddlCollege_SelectedIndexChanged">
                            </asp:DropDownList>
                        </p>
                    </div>

                    <div class="criteria-item">
                        <p>
                            <span>
                                <label for="ddlDepartment">Department</label>
                            </span>

                            <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="timespan-allyears" required Enabled="false">
                            </asp:DropDownList>
                        </p>
                    </div>

                    <div class="criteria-item">
                        <p style="display: inline-block;">
                            <span>
                                <label style="display: table-caption;" for="ddlDepartment">Class</label>
                            </span>
                            <asp:RadioButtonList ID="rblClass" runat="server" RepeatDirection="Horizontal" CellPadding="5" Style="display: inline; vertical-align: middle"
                                OnSelectedIndexChanged="rblClass_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="ISI" Value="ISI" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Non-ISI" Value="NonISI"></asp:ListItem>
                            </asp:RadioButtonList>
                        </p>
                    </div>

                    <div class="criteria-item show" runat="server" id="divType_ISI">
                        <p style="display: inline-block;">
                            <span>
                                <label style="display: table-caption;" for="ddlDepartment">Type</label>
                            </span>
                            <asp:CheckBoxList ID="cblType_ISI" runat="server" RepeatDirection="Horizontal" CellPadding="3" RepeatColumns="4" Style="display: inline; vertical-align: middle">
                                <asp:ListItem Text="All" Value="All" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Articles / Reviews" Value="Articles"></asp:ListItem>
                                <asp:ListItem Text="Conference / Proceedings" Value="Conference"></asp:ListItem>
                            </asp:CheckBoxList>
                        </p>
                    </div>

                    <div class="criteria-item hide" runat="server" id="divType_NonISI">
                        <p style="display: inline-block;">
                            <span>
                                <label style="display: table-caption;" for="ddlDepartment">Type</label>
                            </span>
                            <asp:RadioButtonList ID="rblType_NonISI" runat="server" RepeatDirection="Horizontal" CellPadding="5" Style="display: inline; vertical-align: middle">
                                <asp:ListItem Text="Approved" Value="Approved" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="All" Value="All"></asp:ListItem>
                            </asp:RadioButtonList>
                        </p>
                    </div>
                </fieldset>
            </section>
    </form>
</body>
</html>
