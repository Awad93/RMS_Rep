<%@ Page Title="" Language="C#" MasterPageFile="~/Repository/RepositoryMaster.Master" AutoEventWireup="true" CodeBehind="Publications.aspx.cs" Inherits="RMS.Repository.Publications" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlTimeSpan" EventName="SelectedIndexChanged" />
        </Triggers>
        <ContentTemplate>
            <!-- TIME SPAN -->
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

            <div class="col-lg-4 ">
            </div>
            <div class="col-lg-4 text-center">
                <asp:Button ID="btnGenerate" runat="server" Text="Generate Report" CssClass="btn-primary btn-lg btn-block" OnClick="btnGenerate_Click" />
            </div>
            <div class="col-lg-4 ">
            </div>
            <br />
            <br />

            <div class="col-lg-12">
                <hr class="hr-separator" />
            </div>

            <div id="divResults" runat="server" style="display: none;">

                <div class="container">
                    <h2>SUMMARY
                    </h2>
                    <div id="container_highchart" style="width: 660px; height: 400px; margin-left: 28%;"></div>
                </div>

                <div>
                    <p>
                        <br />
                    </p>
                </div>

                <div class="container">
                    <h2>RESULTS
                    </h2>
                    <asp:Repeater ID="rptArticles" runat="server" OnItemDataBound="rptArticles_ItemDataBound">
                        <ItemTemplate>
                            <div class="row">
                                <div class="col-sm-12 " role="alert">
                                    <button data-toggle="collapse" id="lblPaperTitle" runat="server" class="alert alert-info btn-block text-left"></button>
                                    <div class="col-sm-11 alert-success" role="alert" id='h<%# DataBinder.Eval(Container, "ItemIndex") %>' style="display: none; margin-left: 35px; margin-bottom: 15px;">
                                        <p>
                                            <b>WOSS # : </b>
                                            <asp:Label ID="lblWOSNumber" runat="server" CssClass="text-primary" />
                                        </p>
                                        <p>
                                            <b>Publication Year : </b>
                                            <asp:Label ID="lblPublicationYear" runat="server" CssClass="text-primary" />
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>

            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

