<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="admin_page_test2.aspx.cs" Inherits="WebApplication1.admin_page_test2" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <link href="Director-free/Director-free/css/bootstrap.css" rel="stylesheet" type="text/css">
    <link href="Director-free/Director-free/css/style.css" rel="stylesheet" type="text/css">
    <link href="Director-free/Director-free/css/ionicons.css" rel="stylesheet" type="text/css">

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>

    <script src="http://code.highcharts.com/highcharts.js"></script>

    <!-- Google Chart CDN + Script -->

    <!--Load the AJAX API-->
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>

   <%-- <script type="text/javascript">
        // Load the Visualization API and the corechart package.
        google.charts.load('current', { 'packages': ['corechart'] });

        // Set a callback to run when the Google Visualization API is loaded.
        google.charts.setOnLoadCallback(drawChart);

        // Callback that creates and populates a data table,
        // instantiates the pie chart, passes in the data and
        // draws it.
        function drawChart() {

            var data = google.visualization.arrayToDataTable([
             ['Year', 'Sales', 'Expenses'],
             ['2004', 1000, 400],
             ['2005', 1170, 460],
             ['2006', 660, 1120],
             ['2007', 1030, 540]
            ]);

            var options = {
                title: 'Company Performance',
                curveType: 'function',
                legend: { position: 'bottom' }
            };

            var chart = new google.visualization.LineChart(document.getElementById('mychart'));

            chart.draw(data, options);
        }
    </script>--%>
    <script>
        google.charts.load("current", { "packages": ["corechart"] });        
    </script>

    <!-- END: Google Chart -->

    <link href="main.css" rel="stylesheet" type="text/css">
    <title>Results</title>
</head>
<body>
    <!-- Header -->
    <header class="header">
        <div class="container-fluid">
            <div class="row" id="main-header">
                <div class="col-md-6">
                    <h1 class="col-md-offset-1">KFUPM Research Repository</h1>
                </div>
            </div>
        </div>
    </header>
    <!-- End: Header -->

    <!-- Sidebar -->
    <form runat="server">
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="col-md-3 col-lg-2">
                    <%--<asp:Literal runat="server">
				        <div  id="sidebar-list" class="panel">
					        <ul  id="listCollege" class="list-unstyled" runat="server">
						        <li class="text-center"><a href="main2.html">Home</a></li>   						
					        </ul>					
				        </div>
                    </asp:Literal>--%>

                    <asp:Button runat="server" ID="btnDepartment" Style="display: none" OnClick="btnDepartment_OnClick" />
                    <asp:HiddenField runat="server" ID="hfvDepartmentType" />
                    <asp:HiddenField runat="server" ID="hfvDepartmentCode" />
                    <asp:Repeater ID="repeaterColleges" runat="server" OnItemDataBound="repeaterColleges_ItemDataBound">
                        <HeaderTemplate>
                            <div id="sidebar-list" class="panel">
                                <ul id="listCollege" class="list-unstyled">
                                    <li class="text-center"><a href="main2.html">Home</a></li>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <span class="panel">
                                <%--<li id="listcollege" onclick="javascript:collegeClicked('<%#Eval("Department_Code") %>')" data-toggle="collapse" href="#deptID<%#Eval("Department_ID")%>" data-parent="#listCollege">--%>
                                <li onclick="document.getElementById('<%= hfvDepartmentType.ClientID %>').setAttribute('Value','COLLEGE');
                                    document.getElementById('<%= hfvDepartmentCode.ClientID %>').setAttribute('Value','<%#Eval("Department_Code") %>');
                                    document.getElementById('<%= btnDepartment.ClientID %>').click()"
                                    data-toggle="collapse" href="#deptID<%#Eval("Department_ID")%>" data-parent="#listCollege">

                                    <a>
                                        <asp:Literal ID="ltrlCollege" runat="server"></asp:Literal></a>

                                </li>
                                <ul id="deptID<%#Eval("Department_ID")%>" class="collapse list-unstyled">
                                    <asp:Repeater ID="repeaterDepartments" runat="server" OnItemDataBound="repeaterDepartments_ItemDataBound">
                                        <ItemTemplate>
                                            <li onclick="document.getElementById('<%= hfvDepartmentType.ClientID %>').setAttribute('Value','DEPARTMENT');
                                                document.getElementById('<%= hfvDepartmentCode.ClientID %>').setAttribute('Value','<%#Eval("Department_Code") %>');
                                                document.getElementById('<%= btnDepartment.ClientID %>').click()"><a>
                                                    <asp:Literal ID="ltrlDepartment" runat="server"></asp:Literal>
                                                </a></li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </span>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <!-- End: Sidebar -->

                <input id="hfvPill" type="hidden" />
                <!-- Page content -->
                <div class="col-lg-9" style="padding-left: 0 !important;" id="content">
                    <asp:ScriptManager ID="ScriptManager1" runat="server" />
                    <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnDepartment" EventName="Click" />
                            <%--<asp:AsyncPostBackTrigger ControlID="ddlChart" EventName="SelectedIndexChanged" />--%>
                        </Triggers>
                        <ContentTemplate>
                            <!-- Breadcrumb -->
                            <div class="panel panel-default">
                                <ol class="breadcrumb">
                                    <li><a href="#">Home</a></li>
                                    <asp:Literal runat="server" ID="ltrlCollege"></asp:Literal>
                                    <asp:Literal runat="server" ID="ltrlDepartment"></asp:Literal>
                                    <asp:Literal runat="server" ID="ltrlFaculty"></asp:Literal>
                                </ol>
                            </div>
                            <!-- End: Breadcrumb -->

                            <%--Tabs--%>
                            <div class="panel">
                                <header class="panel-heading">
                                    <ul id="pills" class="nav nav-pills">
                                        <li><a data-toggle="pill" href="#all">All</a></li>
                                        <li><a data-toggle="pill" href="#statistics">Statistics</a></li>
                                        <li><a data-toggle="pill" href="#year">By year</a></li>
                                        <li><a data-toggle="pill" href="#faculty">By faculty</a></li>
                                        <li><a data-toggle="pill" href="#area">By area</a></li>
                                    </ul>
                                </header>
                                <div class="panel-body">
                                    <div id="results-tab" class="nav-justified tab-content pull-left">
                                        <div id="all" class="tab-pane fade">
                                            <h4>View all</h4>
                                            <ul class="results-list collapse-arrow" style="padding-left: 0">
                                                <asp:Repeater ID="repeaterISIPublications" runat="server" OnItemDataBound="repeaterISIPublications_ItemDataBound">
                                                    <HeaderTemplate>
                                                        <li>
                                                            <a data-toggle="collapse" href="#journals">ISI Journals
                                                                <asp:Label class="label label-default" ID="lblTotalPublications" runat="server"></asp:Label></a>
                                                        </li>
                                                        <ul class="collapse collapse-arrow results-list" id="journals">
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Literal ID="ltrlYear" runat="server"></asp:Literal>
                                                        <li runat="server" id="ISIEntry" data-toggle="collapse" class="list-bordered">
                                                            <h4 style="color: blue">
                                                                <asp:Literal ID="ltrlPaperTitle" runat="server">                                               
                                                                </asp:Literal></h4>
                                                            <h6 style="color: grey">
                                                                <asp:Literal ID="ltrlAuthors" runat="server">
                                                                </asp:Literal></h6>
                                                            <h6>
                                                                <asp:Literal ID="ltrlWideCategory" runat="server">
                                                                </asp:Literal></h6>
                                                        </li>
                                                        <div runat="server" id="ISIEntry_Showmore" class="well collapse showmore pull-left">
                                                            <p>
                                                                <b>WOS: </b>
                                                                <asp:Literal ID="ltrlWOS" runat="server"></asp:Literal>
                                                            </p>
                                                            <p>
                                                                <b>Date: </b>
                                                                <asp:Literal ID="ltrlDate" runat="server"></asp:Literal>
                                                            </p>
                                                            <p>
                                                                <b>Journal: </b>
                                                                <asp:Literal ID="ltrlJournal" runat="server"></asp:Literal>
                                                            </p>
                                                            <p>
                                                                <b>Area: </b>
                                                                <asp:Literal ID="ltrlArea" runat="server"></asp:Literal>
                                                            </p>
                                                            <p class="keywords">
                                                                <b>Keywords: </b>
                                                                <asp:Literal ID="ltrlKeywords" runat="server"></asp:Literal>
                                                            </p>
                                                            <p>
                                                                <b>Abstract: </b>
                                                                <asp:Literal ID="ltrlAbstract" runat="server"></asp:Literal>
                                                            </p>
                                                        </div>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </ul>
                                                        <asp:Literal runat="server" ID="ltrlDone"></asp:Literal>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                                <%--<asp:Repeater ID="repeaterISIPublicationsYears" runat="server" OnItemDataBound="repeaterISIPublicationsYears_ItemDataBound">
                                                    <HeaderTemplate>
                                                        <li>
                                                            <a data-toggle="collapse" href="#journals">ISI Journals
                                                                <asp:Label class="label label-default" ID="lblTotalPublications" runat="server"></asp:Label></a>
                                                        </li>
                                                        <ul class="collapse collapse-arrow" id="journals">
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <li><a runat="server" id="ISI_Year" data-toggle="collapse">
                                                            <asp:Literal runat="server" ID="ltrlYear"></asp:Literal></a></li>
                                                        <ul runat="server" id="ISI_Year_Entry" class="collapse">
                                                            <asp:Repeater runat="server" ID="repeaterISIPublicationsByYear" OnItemDataBound="repeaterISIPublicationsByYear_ItemDataBound">
                                                                <ItemTemplate>
                                                                    <li runat="server" id="ISIEntry" data-toggle="collapse" class="list-bordered">
                                                                        <h4 style="color: blue">
                                                                            <asp:Literal ID="ltrlPaperTitle" runat="server">                                               
                                                                            </asp:Literal></h4>
                                                                        <h6 style="color: grey">
                                                                            <asp:Literal ID="ltrlAuthors" runat="server">
                                                                            </asp:Literal></h6>
                                                                        <h6>
                                                                            <asp:Literal ID="ltrlPublicationYear" runat="server">
                                                                            </asp:Literal></h6>
                                                                    </li>
                                                                    <div runat="server" id="ISIEntry_Showmore" class="well collapse showmore pull-left">
                                                                        <p><b>WOS: </b>
                                                                            <asp:Literal ID="ltrlWOS" runat="server"></asp:Literal></p>
                                                                        <p><b>Date: </b>
                                                                            <asp:Literal ID="ltrlDate" runat="server"></asp:Literal></p>
                                                                        <p><b>Journal: </b>
                                                                            <asp:Literal ID="ltrlJournal" runat="server"></asp:Literal></p>
                                                                        <p><b>Area: </b>
                                                                            <asp:Literal ID="ltrlArea" runat="server"></asp:Literal></p>
                                                                        <p class="keywords"><b>Keywords: </b>
                                                                            <asp:Literal ID="ltrlKeywords" runat="server"></asp:Literal></p>
                                                                        <p><b>Abstract: </b>
                                                                            <asp:Literal ID="ltrlAbstract" runat="server"></asp:Literal></p>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </ul>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </ul>
                                                    </FooterTemplate>
                                                </asp:Repeater>--%>

                                                <%--<asp:Repeater ID="repeaterISIPublications" runat="server" OnItemDataBound="repeaterISIPublications_ItemDataBound">
                                   <HeaderTemplate>
                                        <li>
								            <a data-toggle="collapse" href="#journals">  ISI Journals <asp:Label class="label label-default" ID="lblTotalPublications" runat="server" ></asp:Label></a>
							            </li>
							            <ul class="collapse collapse-arrow" id="journals">
                                   </HeaderTemplate>
                                   <ItemTemplate>
                                       <asp:Literal ID="ltrlyear" runat="server">
                                       </asp:Literal>
                                       <li runat="server" id="ISIEntry" data-toggle="collapse" class="list-bordered">
                                           <h4 style="color:blue"><asp:Literal ID="ltrlPaperTitle" runat="server">                                               
                                           </asp:Literal></h4>
                                           <h6 style="color:grey"><asp:Literal ID="ltrlAuthors" runat="server">
                                           </asp:Literal></h6>
                                           <h6><asp:Literal ID="ltrlPublicationYear" runat="server">
                                           </asp:Literal></h6>
                                       </li>
                                       <div runat="server" id="ISIEntry_Showmore" class="well collapse showmore pull-left">
                                           <p><b>WOS: </b><asp:Literal ID="ltrlWOS" runat="server"></asp:Literal></p>
                                           <p><b>Date: </b><asp:Literal ID="ltrlDate" runat="server"></asp:Literal></p>
                                           <p><b>Journal: </b><asp:Literal ID="ltrlJournal" runat="server"></asp:Literal></p>
                                           <p><b>Area: </b><asp:Literal ID="ltrlArea" runat="server"></asp:Literal></p>
                                           <p class="keywords"><b>Keywords: </b><asp:Literal ID="ltrlKeywords" runat="server"></asp:Literal></p>
                                           <p><b>Abstract: </b><asp:Literal ID="ltrlAbstract" runat="server"></asp:Literal></p>
                                       </div>                                       
                                   </ItemTemplate>
                                   <FooterTemplate>
                                       </ul>
                                   </FooterTemplate>
							   </asp:Repeater>--%>
                                                <asp:Repeater ID="repeaterNonISIPublications" runat="server" OnItemDataBound="repeaterNonISIPublications_ItemDataBound">
                                                    <HeaderTemplate>
                                                        <li>
                                                            <a data-toggle="collapse" href="#nonisijournals">Non-ISI Journals
                                                                <asp:Label class="label label-default" ID="lblTotalPublications" runat="server"></asp:Label></a>
                                                        </li>
                                                        <ul class="collapse collapse-arrow" id="nonisijournals">
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Literal ID="ltrlyear" runat="server">
                                                        </asp:Literal>
                                                        <li class="list-bordered">
                                                            <h4 style="color: blue">
                                                                <asp:Literal ID="ltrlPaperTitle" runat="server">                                               
                                                                </asp:Literal></h4>
                                                            <h6 style="color: grey">
                                                                <asp:Literal ID="ltrlAuthors" runat="server">
                                                                </asp:Literal></h6>
                                                            <h6>
                                                                <asp:Literal ID="ltrlPublicationYear" runat="server">
                                                                </asp:Literal></h6>
                                                        </li>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </ul>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                                <asp:Repeater ID="repeaterBooks" runat="server" OnItemDataBound="repeaterBooks_ItemDataBound">
                                                    <HeaderTemplate>
                                                        <li>
                                                            <a data-toggle="collapse" href="#books">Books
                                                                <asp:Label class="label label-default" ID="lblTotalBooks" runat="server"></asp:Label></a>
                                                        </li>
                                                        <ul class="collapse" id="books">
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Literal ID="ltrlyear" runat="server">
                                                        </asp:Literal>
                                                        <li class="list-bordered">
                                                            <h4 style="color: blue">
                                                                <asp:Literal ID="ltrlBookTitle" runat="server">                                               
                                                                </asp:Literal></h4>
                                                            <h6 style="color: grey">
                                                                <asp:Literal ID="ltrlAuthors" runat="server">
                                                                </asp:Literal></h6>
                                                            <h6>
                                                                <asp:Literal ID="ltrlPublicationYear" runat="server">
                                                                </asp:Literal></h6>
                                                        </li>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </ul>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                            </ul>
                                        </div>
                                        <div id="statistics" class="tab-pane fade">
                                            <h4>Yearly Statistics</h4>
                                            <form class="form-horizontal tasi-form">
                                                <div class="row form-group">
                                                    <label class="col-sm-2 control-label col-lg-2" style="text-align: left;" for="ddlChart">Show chart for: </label>
                                                    <div class="col-sm-4">
                                                        <asp:DropDownList runat="server" id="ddlChart" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlChart_onChange">
                                                            <asp:ListItem value="pp">Publication Points</asp:ListItem>
                                                            <asp:ListItem value="isi">ISI</asp:ListItem>
                                                            <asp:ListItem>Non-ISI</asp:ListItem>
                                                            <asp:ListItem>Conferences</asp:ListItem>
                                                            <asp:ListItem>Patents</asp:ListItem>
                                                            <asp:ListItem>Books</asp:ListItem>
                                                            <asp:ListItem>Projects</asp:ListItem>
                                                            <asp:ListItem>Short courses funding</asp:ListItem>
                                                            <asp:ListItem>Graduate students</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-md-offset-2 col-md-4">
                                                        <button id="generate-report" type="button" class="btn btn-info" data-toggle="modal" data-target="#report-modal">Create report</button>
                                                    </div>
                                                </div>
                                            </form>
                                            <div id="report-modal" class="modal fade" role="dialog">
                                                <div class="modal-dialog modal-lg">
                                                    <div class="modal-content">
                                                        <div class="modal-header">
                                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                            <h4 class="modal-title">Statistics: All Time</h4>
                                                        </div>
                                                        <div class="modal-body">
                                                            <table class="table table-striped table-bordered">
                                                                <thead>
                                                                    <tr>
                                                                        <th rowspan="2">Year</th>
                                                                        <th rowspan="2">ISI</th>
                                                                        <th rowspan="2">Non-ISI</th>
                                                                        <th rowspan="2">Publication Points (PP)</th>
                                                                        <th rowspan="2">Conferences</th>
                                                                        <th rowspan="2">Patents</th>
                                                                        <th rowspan="2">Books</th>
                                                                        <th colspan="2">Projects</th>
                                                                        <th colspan="2">Funds</th>
                                                                        <th rowspan="2">Short courses funding</th>
                                                                        <th rowspan="2">Graduate students</th>
                                                                    </tr>
                                                                    <tr>
                                                                        <th>Internal</th>
                                                                        <th>NSTP</th>
                                                                        <th>Internal</th>
                                                                        <th>NSTP</th>
                                                                    </tr>
                                                                </thead>
                                                            </table>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <h5>Publication points</h5>
                                            <div>
                                                
                                                <!-- Chart -->
                                                <div>
                                                    <div id="mychart" style="width:100%;"></div>
                                                </div>                                                
                                                <!-- End: Chart -->
                                            </div>
                                            <div id="summary">
                                                <span class="row">
                                                    <h2 class="col-md-4">Summary<small>  of the last 8 years</small></h2>
                                                    <div class="col-md-2">
                                                        <button type="button" class="btn btn-success" style="margin-top: 20px" data-toggle="modal" data-target="#statistics-modal">Show more</button>
                                                    </div>
                                                </span>
                                                <div id="statistics-modal" class="modal fade" role="dialog">
                                                    <div class="modal-dialog modal-lg">
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                                <h4 class="modal-title">Statistics: All Time</h4>
                                                            </div>
                                                            <div class="modal-body">
                                                                <table class="table table-striped table-bordered">
                                                                    <thead>
                                                                        <tr>
                                                                            <th rowspan="2">Year</th>
                                                                            <th rowspan="2">ISI</th>
                                                                            <th rowspan="2">Non-ISI</th>
                                                                            <th rowspan="2">Publication Points (PP)</th>
                                                                            <th rowspan="2">Conferences</th>
                                                                            <th rowspan="2">Patents</th>
                                                                            <th rowspan="2">Books</th>
                                                                            <th colspan="2">Projects</th>
                                                                            <th colspan="2">Funds</th>
                                                                            <th rowspan="2">Short courses funding</th>
                                                                            <th rowspan="2">Graduate students</th>
                                                                        </tr>
                                                                        <tr>
                                                                            <th>Internal</th>
                                                                            <th>NSTP</th>
                                                                            <th>Internal</th>
                                                                            <th>NSTP</th>
                                                                        </tr>
                                                                    </thead>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div style="border-top: 1px solid #eeeeee;">
                                                    <div class="col-md-6" style="border-right: 1px solid #eeeeee;">
                                                        <h4>Publications:</h4>
                                                        <h5>6 total publication in 2016</h5>
                                                        <table class="table table-bordered">
                                                            <thead>
                                                                <tr>
                                                                    <th>Year</th>
                                                                    <th>ISI</th>
                                                                    <th>Non-ISI</th>
                                                                    <th>Publication Points</th>
                                                                    <th>Books</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <tr>
                                                                    <td>2016</td>
                                                                    <td>6</td>
                                                                    <td>0</td>
                                                                    <td>3.5</td>
                                                                    <td>0</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>2015</td>
                                                                    <td>25</td>
                                                                    <td>0</td>
                                                                    <td>15.25</td>
                                                                    <td>2</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>2014</td>
                                                                    <td>6</td>
                                                                    <td>0</td>
                                                                    <td>3.5</td>
                                                                    <td>0</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>2013</td>
                                                                    <td>6</td>
                                                                    <td>0</td>
                                                                    <td>3.5</td>
                                                                    <td>0</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>2012</td>
                                                                    <td>6</td>
                                                                    <td>0</td>
                                                                    <td>3.5</td>
                                                                    <td>0</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>2011</td>
                                                                    <td>6</td>
                                                                    <td>0</td>
                                                                    <td>3.5</td>
                                                                    <td>0</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>2010</td>
                                                                    <td>6</td>
                                                                    <td>0</td>
                                                                    <td>3.5</td>
                                                                    <td>0</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>2009</td>
                                                                    <td>6</td>
                                                                    <td>0</td>
                                                                    <td>3.5</td>
                                                                    <td>0</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>2008</td>
                                                                    <td>6</td>
                                                                    <td>0</td>
                                                                    <td>3.5</td>
                                                                    <td>0</td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <h4>Conferences & Patents:</h4>
                                                        <h5>3 conferences & 5 patents in 2016</h5>
                                                        <table class="table table-bordered">
                                                            <thead>
                                                                <tr>
                                                                    <th>Year</th>
                                                                    <th>Conferences</th>
                                                                    <th>Patents</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <tr>
                                                                    <td>2016</td>
                                                                    <td>0</td>
                                                                    <td>0</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>2015</td>
                                                                    <td>0</td>
                                                                    <td>0</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>2014</td>
                                                                    <td>0</td>
                                                                    <td>0</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>2013</td>
                                                                    <td>0</td>
                                                                    <td>0</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>2012</td>
                                                                    <td>0</td>
                                                                    <td>0</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>2011</td>
                                                                    <td>0</td>
                                                                    <td>0</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>2010</td>
                                                                    <td>0</td>
                                                                    <td>0</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>2009</td>
                                                                    <td>0</td>
                                                                    <td>0</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>2008</td>
                                                                    <td>0</td>
                                                                    <td>0</td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                                <div class="col-md-12" style="border-top: 1px solid #eeeeee;">
                                                    <h4>Projects:</h4>
                                                    <h5>3 total projects funded in 2016</h5>
                                                    <table class="table table-bordered">
                                                        <thead>
                                                            <tr>
                                                                <th rowspan="2">Year</th>
                                                                <th colspan="2">Internal</th>
                                                                <th colspan="2">NSTP</th>
                                                            </tr>
                                                            <tr>
                                                                <th>Projects</th>
                                                                <th>Funds</th>
                                                                <th>Projects</th>
                                                                <th>Funds</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr>
                                                                <td>2016</td>
                                                                <td>2</td>
                                                                <td>45,600 <small>SAR</small></td>
                                                                <td>0</td>
                                                                <td>0</td>
                                                            </tr>
                                                            <tr>
                                                                <td>2015</td>
                                                                <td>2</td>
                                                                <td>45,600 <small>SAR</small></td>
                                                                <td>0</td>
                                                                <td>0</td>
                                                            </tr>
                                                            <tr>
                                                                <td>2014</td>
                                                                <td>2</td>
                                                                <td>45,600 <small>SAR</small></td>
                                                                <td>0</td>
                                                                <td>0</td>
                                                            </tr>
                                                            <tr>
                                                                <td>2013</td>
                                                                <td>2</td>
                                                                <td>45,600 <small>SAR</small></td>
                                                                <td>0</td>
                                                                <td>0</td>
                                                            </tr>
                                                            <tr>
                                                                <td>2012</td>
                                                                <td>2</td>
                                                                <td>45,600 <small>SAR</small></td>
                                                                <td>0</td>
                                                                <td>0</td>
                                                            </tr>
                                                            <tr>
                                                                <td>2011</td>
                                                                <td>2</td>
                                                                <td>45,600 <small>SAR</small></td>
                                                                <td>0</td>
                                                                <td>0</td>
                                                            </tr>
                                                            <tr>
                                                                <td>2010</td>
                                                                <td>2</td>
                                                                <td>45,600 <small>SAR</small></td>
                                                                <td>0</td>
                                                                <td>0</td>
                                                            </tr>
                                                            <tr>
                                                                <td>2009</td>
                                                                <td>2</td>
                                                                <td>45,600 <small>SAR</small></td>
                                                                <td>0</td>
                                                                <td>0</td>
                                                            </tr>
                                                            <tr>
                                                                <td>2008</td>
                                                                <td>2</td>
                                                                <td>45,600 <small>SAR</small></td>
                                                                <td>0</td>
                                                                <td>0</td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                                <div class="col-md-12" style="border-top: 1px solid #eeeeee;">
                                                    <h4>Short courses & Graduate students:</h4>
                                                    <h5>0 short courses funds & 0 graduate students in 2016</h5>
                                                    <table class="table table-bordered">
                                                        <thead>
                                                            <tr>
                                                                <th>Year</th>
                                                                <th>Short courses funding</th>
                                                                <th>Graduate students</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr>
                                                                <td>2016</td>
                                                                <td>0</td>
                                                                <td>0</td>
                                                            </tr>
                                                            <tr>
                                                                <td>2015</td>
                                                                <td>0</td>
                                                                <td>0</td>
                                                            </tr>
                                                            <tr>
                                                                <td>2014</td>
                                                                <td>0</td>
                                                                <td>0</td>
                                                            </tr>
                                                            <tr>
                                                                <td>2013</td>
                                                                <td>0</td>
                                                                <td>0</td>
                                                            </tr>
                                                            <tr>
                                                                <td>2012</td>
                                                                <td>0</td>
                                                                <td>0</td>
                                                            </tr>
                                                            <tr>
                                                                <td>2011</td>
                                                                <td>0</td>
                                                                <td>0</td>
                                                            </tr>
                                                            <tr>
                                                                <td>2010</td>
                                                                <td>0</td>
                                                                <td>0</td>
                                                            </tr>
                                                            <tr>
                                                                <td>2009</td>
                                                                <td>0</td>
                                                                <td>0</td>
                                                            </tr>
                                                            <tr>
                                                                <td>2008</td>
                                                                <td>0</td>
                                                                <td>0</td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                                <table style="visibility: hidden" class="table table-striped table-bordered">
                                                    <thead>
                                                        <tr>
                                                            <th rowspan="2">Year</th>
                                                            <th rowspan="2">ISI</th>
                                                            <th rowspan="2">Non-ISI</th>
                                                            <th rowspan="2">Publication Points (PP)</th>
                                                            <th rowspan="2">Conferences</th>
                                                            <th rowspan="2">Patents</th>
                                                            <th rowspan="2">Books</th>
                                                            <th colspan="2">Projects</th>
                                                            <th colspan="2">Funds</th>
                                                            <th rowspan="2">Short courses funding</th>
                                                            <th rowspan="2">Graduate students</th>
                                                        </tr>
                                                        <tr>
                                                            <th>Internal</th>
                                                            <th>NSTP</th>
                                                            <th>Internal</th>
                                                            <th>NSTP</th>
                                                        </tr>
                                                    </thead>
                                                </table>
                                            </div>
                                        </div>
                                        <div id="year" class="tab-pane fade">
                                            <h4>Year</h4>
                                        </div>
                                        <asp:HiddenField runat="server" ID="hfvIsFaculty" />
                                        <asp:HiddenField runat="server" ID="hfvFacultyID" />
                                        <div id="faculty" class="tab-pane fade">
                                            <div class="row">
                                                <div class="col-lg-3">
                                                    <h4>Faculty</h4>
                                                </div>
                                                <div class="col-lg-6">
                                                    <input runat="server" id="inptSearchBar" type="text" class="form-control" placeholder="Search">
                                                </div>
                                                <div class="col-lg-offset-1 col-lg-1">
                                                    <button runat="server" id="btnSearchFaculty" type="button" class="btn btn-info" onserverclick="btnSearchFaculty_Click">Search</button>
                                                </div>
                                            </div>
                                            <asp:Button runat="server" ID="btnFacultyFilter" Style="display: none" OnClick="btnFacultyFilter_OnClick" />
                                            <asp:HiddenField runat="server" ID="hfvFirstChar" Value="A" />
                                            <div id="div_character_filter" class="row">
                                                <asp:Repeater runat="server" ID="repeaterFaculty_filter" OnItemDataBound="repeaterFaculty_filter_ItemDataBound">
                                                    <HeaderTemplate>
                                                        <ul class="text-center list-unstyled">
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <li style="display: inline">
                                                            <asp:Literal runat="server" ID="ltrlCharacter"></asp:Literal></li>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </ul>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                            </div>
                                            <%--<input runat="server" id="facultyChosen" type="hidden" value="false"/>--%>
                                            <asp:UpdatePanel runat="server" ID="UpdateFacultyPanel" UpdateMode="Conditional">
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnFacultyFilter" EventName="Click" />
                                                </Triggers>
                                                <ContentTemplate>
                                                    <ul class="facultyList list-unstyled">
                                                        <asp:Repeater ID="repeaterFaculty" runat="server" OnItemDataBound="repeaterFaculty_ItemDataBound">
                                                            <ItemTemplate>
                                                                <li>
                                                                    <a runat="server" onserverclick="aFaculty_Click" onclick="changeTab('faculty', 'all');" id="aFaculty" class="h4">
                                                                        <%--<asp:Literal ID="ltrlFaculty" runat="server"></asp:Literal>--%>                                                                       
                                                                    </a>
                                                                    <asp:HiddenField runat="server" ID="hfvKFUPMID" />
                                                                </li>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </ul>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div id="area" class="tab-pane fade">
                                            <h4>Area</h4>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%--End:Tabs--%>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </form>
    <!-- End: page content -->
    <script>
        function changeCharacter(currentCharacter, newCharacter) {
            $()
        }
    </script>
    <script>
        function changeTab(currentTab, newTab) {
            $('#pills a[href="#' + currentTab + '"]').parent().removeClass('active')
            $('#' + currentTab).removeClass('in active');

            $('#pills a[href="#' + newTab + '"]').parent().addClass('active');
            $('#' + newTab).addClass('in active');
            $('#hfvPill').attr('Value', '#' + newTab);

        };

        $(function () {
            $('#pills > li:first-child').addClass('active');
            $('#results-tab > div:first-child').addClass('in active');
            $('#hfvPill').attr('Value', $('#pills>li.active>a').attr('href'));
        });
        $('ul.nav a').on('shown.bs.tab', function (e) {
            $('#hfvPill').attr('Value', $('#pills>li.active>a').attr('href'));
        });

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            var pill_href = $('#hfvPill').attr('Value');
            $('#pills a[href="' + pill_href + '"]').parent().addClass('active');
            $(pill_href).addClass('in active');
            $('ul.nav a').on('shown.bs.tab', function (e) {
                $('#hfvPill').attr('Value', $('#pills>li.active>a').attr('href'));                
            });
            if($('#mychart').children().length > 0)
                $('#mychart').highcharts().reflow();

            //if ($('#facultyChosen').value == "true") {
            //    $('#pills a[href="#faculty"]').hide();
            //    $('#faculty').remove();
            //}
            //else {
            //    $('#pills a[href="#faculty"]').show()
            //};
        });
        
    </script>
</body>
<script>
    
</script>
</html>
