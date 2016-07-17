<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update_publications.aspx.cs" Inherits="WebApplication1.Update_publications" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<link href="Director-free/Director-free/css/bootstrap.css" rel="stylesheet" type="text/css">
	<link href="Director-free/Director-free/css/style.css" rel="stylesheet" type="text/css">
	<link href="Director-free/Director-free/css/ionicons.css" rel="stylesheet" type="text/css">
	 <link href="Director-free/Director-free/css/morris/morris.css" rel="stylesheet" type="text/css" />
	
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
	<script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
	
	<link rel="stylesheet" href="http://cdnjs.cloudflare.com/ajax/libs/morris.js/0.5.1/morris.css">
	<script src="http://cdnjs.cloudflare.com/ajax/libs/raphael/2.1.0/raphael-min.js"></script>
	<script src="http://cdnjs.cloudflare.com/ajax/libs/morris.js/0.5.1/morris.min.js"></script>
	
	<link href="main.css" rel="stylesheet" type="text/css">
    <title>
        Update Publications
    </title>
	
	<script>
		function checkFunction(){
			$('#update-form').show();
		}
	</script>
</head>
<body>
<!-- Header -->
	<header class="header">
		<div class="container-fluid">
			<div class="row" id="main-header">
			<div class="col-md-6" >
				<h1 class="col-md-offset-1">KFUPM Research Repository</h1>
			</div>
			</div>			
					
		</div>
	<!-- 	<div style="margin-left:0;">
			<a>Update Records</a>
			<a>Admin login</a>
		</div> -->
	</header>
<!-- End: Header -->

<!-- Sidebar -->
	<div class="container-fluid">
		<div class="row-fluid">	
			<div class="col-md-3 col-lg-2">
                <asp:Literal>
				<div  id="sidebar-list" class="panel">
					<ul  id="listCollege" class="list-unstyled" runat="server">
						<li class="text-center"><a href="main2.html">Home</a></li>
                        
						<%--<span class="panel">
						<li data-toggle="collapse" href="#dept-list1"  data-parent="#accordion"><a>College of Applied & Supporting Studies</a></li>
						<ul id="dept-list1" class="collapse list-unstyled">						
							<li><a>English Language Department</a></li>
							<li><a>General Studies</a></li>
							<li><a>Islamic and Arabic Studies</a></li>
							<li><a>Physical Education</a></li>
							<li><a>Prepratory Year</a></li>
						</ul>
						</span>
						<span class="panel">
						    <li data-toggle="collapse" href="#dept-list2"  data-parent="#accordion"><a>College of Computer Science & Engineering</a></li>
						    <asp:Literal>
                                <ul id="deptlist2" class="collapse list-unstyled" runat="server">--%>	
							<%--<li><a>Computer Engineering</a></li>
							<li><a>Information & Computer Science</a></li>
							<li><a>Systems Engineering</a></li>--%>
                        
						       <%-- </ul>
                            </asp:Literal>
						</span>
						<li><a>College of Engineering Sciences</a></li>
						<li><a>College of Environmental Design</a></li>
						<li><a>College of Industrial Management</a></li>
						<li><a>College of Petroleum Engineering & Geoscience</a></li>
						<li><a>College of Sciences</a></li>
						<li><a>Dammam Community College</a></li>
						<li><a>Harf Al-Batin Community College</a></li>
						<li><a>Research Institute</a></li>
						<li><a>Vice Rector Applied Research</a></li>
						<li style="background-color:black;"><a href="update_publications.html">Update Records</a></li>--%>
					</ul>					
				</div>
                    </asp:Literal>
			</div>
<!-- End: Sidebar -->

<!-- Page content -->
	<div class="col-lg-9" style="padding-left:0 !important;" id="content">
	
	<!-- Breadcrumb -->
		<div class="panel panel-default">
			<ol	class="breadcrumb">
				<li><a href="#">Home</a></li>
				<li><a href="#">Update Records</a></li>
			</ol>
		</div>
	<!-- End: Breadcrumb -->
	
		<div class="panel">
			<header class="panel-heading">
				Verify & Update Records
			</header>
				<div class="panel-body">
					<div style="color:#aaaaaa">
						You can update our Repository in case of missing publications by filling this form. The Deanship with verify your entry and update the Respository accordingly.
					</div>
					<br/>
					<form class="form-horizontal tasi-form" id="id-form">
						<div class="form-group has-success">
							<label class="col-sm-offset-1 col-sm-3 control-label col-lg-3" for="inputID">Enter your KFUPM ID:</label>
							<div class="col-sm-5">
								<input type="text" class="form-control" id="inputID" placeholder="e.g. 201264180")>									
							</div>
							<div class="col-sm-offset-1 col-sm-1">
								<button id="checkId-btn" type="button" class="btn btn-info">Search</button>
							</div>
						</div>
						</br>
						<div class="row">
							<div class="col-sm-offset-1 col-sm-3 text-left">
								<span class="h4">Full name: </span>
							</div>
							<div class="col-sm-3 text-center">
								<span class="h4">Department: </span>
							</div>
							<div class="col-sm-3 text-right">
								<span class="h4">Researcher ID: </span>
							</div>							
						</div>
						<br/>
						<div class="text-center">                            
                                <%--<a>If the data above is incorrect or Research ID is empty, click here to Update your Information</a>--%>                            
                            <asp:Repeater id="repeaterBooks" runat="server">
                                <HeaderTemplate>
                                    <ul>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <%#Eval("BookTitle")%>
                                    </li>        
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ul>
                                </FooterTemplate>
                            </asp:Repeater>
						</div>
					</form>
					<form id="update-form" class="form-horizontal tasi-form" style="display:none">
						<div class="form-group" style="border-bottom:1px solid #eeeeee; padding-bottom:10px">
							<div class="col-lg-2">
								<label class="radio-inline">
									<input type="radio" name="record-type" checked>
									Publication
								</label>
							</div>
							<div class="col-lg-2">
								<label class="radio-inline">
									<input type="radio" name="record-type">
									Book
								</label>
							</div>
						</div>
						<div class="form-group">
							<label class="col-sm-2 control-label col-lg-2" for="pub-type">Publication type:</label>
							<div class="col-lg-1">
								<label class="radio-inline">
									<input type="radio" name="pub-type" id="ISI" value="0" checked>
									ISI
								</label>
							</div>
							<div class="col-lg-1">
								<label class="radio-inline">
									<input type="radio" name="pub-type" id="non-ISI" value="1">
									non-ISI
								</label>
							</div>
						</div>
						<div class="form-group">
							<label class="col-sm-1 control-label col-lg-1" for="title">Title:</label>
							<div class="col-md-9 col-lg-10">
								<input id="title" type="text" class="form-control">
							</div>
						</div>
						<div class="form-group">
							<label class="col-sm-1 control-label col-lg-1" for="journal">Journal:</label>
							<div class="col-md-9 col-lg-10">
								<input id="journal" type="text" class="form-control">
							</div>
						</div>
						<div class="form-group">													
							<label class="col-sm-1 control-label col-lg-1" for="authors">Author(s):</label>
							<div class="col-md-9 col-lg-10">
								<!-- <input id="authors" type="text" class="form-control" placeholder="separated by semi-colon"> -->
								<textarea class="form-control" rows="10" placeholder="Separate author names by a semi-colon (;) or a new line" ></textarea>
							</div>							
						</div>
						<div class="form-group">													
							<label class="col-sm-2 control-label col-lg-2" for="year-published">Year published:</label>
							<div class="col-md-3 col-lg-3">
								<input id="year-published" type="number" class="form-control" placeholder="e.g. 2016">
							</div>							
						</div>
						<div class="form-group">													
							<label id="url-label" class="col-sm-2 control-label col-lg-2" for="url">Web of Science</label>
							<div class="col-md-9 col-lg-10">
								<input id="url" type="text" class="form-control" placeholder="URL">
							</div>							
						</div>
						<button class="btn btn-success center-block">Save</button>
					</form>
				</div>
			</div>
		</div>
	<!-- <section class="container" id="content"> -->
	</div>
<!-- End: page content -->
<script>
	$('input[name=pub-type]').change(function () {
		if ($('input[name=pub-type]:checked').val()==0){
			$('#url-label').html("Web of Science: ");
		}
		if ($('input[name=pub-type]:checked').val()==1){
			$('#url-label').html("Google Scholar: ");
		}
	});	

	document.getElementById("checkId-btn").addEventListener("click", function(){$('#update-form').show();});
</script>
</body>
</html>
