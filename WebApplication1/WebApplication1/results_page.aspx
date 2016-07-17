<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="results_page.aspx.cs" Inherits="WebApplication1.results_page" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <link href="Director-free/Director-free/css/bootstrap.css" rel="stylesheet" type="text/css">
    <link href="Director-free/Director-free/css/style.css" rel="stylesheet" type="text/css">
    <link href="Director-free/Director-free/css/ionicons.css" rel="stylesheet" type="text/css">

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>

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
                                        <div id="year" class="tab-pane fade">
                                            <h4>Year</h4>
                                        </div>
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
</html>
