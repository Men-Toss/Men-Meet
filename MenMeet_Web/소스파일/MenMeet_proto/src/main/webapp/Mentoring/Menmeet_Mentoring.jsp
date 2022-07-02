<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>
<%@ taglib prefix="fmt" uri="http://java.sun.com/jsp/jstl/fmt"%>
<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="utf-8">
<meta name="viewport"
	content="width=device-width, initial-scale=1.0, shrink-to-fit=no">
<title>MenMeet</title>
<link rel="stylesheet" href="/assets/bootstrap/css/bootstrap.min.css">
<link rel="stylesheet"
	href="https://fonts.googleapis.com/css?family=ABeeZee&amp;display=swap">
<link rel="stylesheet"
	href="https://fonts.googleapis.com/css?family=Aguafina+Script&amp;display=swap">
<link rel="stylesheet"
	href="https://fonts.googleapis.com/css?family=Akaya+Kanadaka&amp;display=swap">
<link rel="stylesheet"
	href="https://fonts.googleapis.com/css?family=Akronim&amp;display=swap">
<link rel="stylesheet"
	href="https://fonts.googleapis.com/css?family=Allan&amp;display=swap">
<link rel="stylesheet"
	href="https://fonts.googleapis.com/css?family=Allerta&amp;display=swap">
<link rel="stylesheet"
	href="https://fonts.googleapis.com/css?family=Amiko&amp;display=swap">
<link rel="stylesheet"
	href="https://fonts.googleapis.com/css?family=Andika+New+Basic&amp;display=swap">
<link rel="stylesheet"
	href="https://fonts.googleapis.com/css?family=Annie+Use+Your+Telescope&amp;display=swap">
<link rel="stylesheet"
	href="https://fonts.googleapis.com/css?family=Beth+Ellen&amp;display=swap">
<link rel="stylesheet"
	href="https://fonts.googleapis.com/css?family=Bungee+Inline&amp;display=swap">
<link rel="stylesheet"
	href="https://fonts.googleapis.com/css?family=Bungee+Shade&amp;display=swap">
<link rel="stylesheet"
	href="https://fonts.googleapis.com/css?family=Butcherman&amp;display=swap">
<link rel="stylesheet"
	href="https://fonts.googleapis.com/css?family=Chilanka&amp;display=swap">
<link rel="stylesheet" href="/assets/fonts/fontawesome-all.min.css">
<link rel="stylesheet" href="/assets/css/styles.min.css">
<link rel="stylesheet"
	href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.5.2/animate.min.css">
<link rel="stylesheet"
	href="https://unpkg.com/@bootstrapstudio/bootstrap-better-nav/dist/bootstrap-better-nav.min.css">
</head>

<body>
<input id="loginInfo" type ="hidden" value="${USER.id}">
<input id="pageMentoringWho" type="hidden" value="${mentoringWho}">
<c:choose>
	<c:when test="${mentoringWho==0 }">
		<c:set var="mento" value="nav-link active"/>
		<c:set var="mentee" value="nav-link "/>
	</c:when>
	<c:otherwise>
		<c:set var="mento" value="nav-link "/>
		<c:set var="mentee" value="nav-link active"/>
	</c:otherwise>
</c:choose>

	<section
		style="height: 100vh; background: url(/assets/img/94032-metaverse.gif) right/contain no-repeat;">
		<%@include file="/navbar.jsp"%>
		<div class="container" style="margin-top: 25px;">
			<div class="row">
				<div class="col-md-12" style="width: 60%;">

<!-- 검색 태그 -->
					<form id="formKeyword" name="formKeyword"
						class="d-xl-flex d-xxl-flex justify-content-xl-end justify-content-xxl-end">
						<div class="form-group mb-3" style="width: 400px;">
							<div class="input-group" style="width: 380px; margin-left: 7px;">
								<input class="form-control" type="search"
									id="searchInputKeyword" name="search" placeholder="키워드를 입력하세요."
									style="width: 30px;"><span class="input-group-addon"
									style="margin-top: 6px; margin-right: 18px; margin-left: 10px;">
									<i class="fa fa-search"></i>
								</span>
							</div>
						</div>
					</form>

<!-- 글쓰기 -->			<button id="btnWrite" class="btn btn-primary float-end"
						type="button" onClick="mentoringPopup()"
						style="font-size: 12px; margin-top: 3.8px;">글쓰기</button>
<!-- 멘토-멘티 -->
					<div>
						<ul class="nav nav-tabs">
							<li class="nav-item" >
								<a class="${mento}"
									id="linkMento" href="#" onclick="javascript:changeMento_Mentee('0')"
									style="font-family: Amiko, sans-serif; 
									font-size: 15px; 
									font-weight: bold; - -bs-primary: 
									#0d62fe; - -bs-primary-rgb: 13, 98, 254; 
									transform: translate(0px) scale(1); 
									filter: brightness(100%) sepia(0%);"
									>
								Mento
								</a>
							</li>
							<li class="nav-item" >
								<a class="${mentee}"
										 id="linkMenti" href="#" onclick="javascript:changeMento_Mentee('1')"
										style="font-family: Amiko, sans-serif; font-size: 15px; 
										font-weight: bold;">
								Menti
								</a>
							</li>
							<li>
							
<!-- 카테고리 박스 --> 			<select id="comboMentoringCategory"
								name="comboMentoringCategory" onchange="changeCategory()"
								style="margin-top: 5px; height: 30px; background: rgb(255, 255, 255); color: rgb(0, 0, 0); 
								border: 2px solid rgb(111, 169, 237); margin-left: 10px; width: 150px;">
						<c:forEach var="i" items="${categoryList}" varStatus="status">
									<option 
									value="${status.index}"
										<c:if test="${ mentoringCategory == status.index}" >
											selected = "selected"
										</c:if>
									>${i}</option>
						</c:forEach>
									
							</select>
							</li>
						</ul>
						<div class="tab-content">
<!-- 게시물 리스트 -->
							<div class="tab-pane active" id="tab-1">
								<ul class="thread-list">
									<c:forEach var="ListDTO" items="${MentoringList }">
										<li class="thread">
											<span class="time" style="font-size: 15px;">
											<fmt:formatDate value="${ListDTO.date }" pattern="MM.dd."/>
											<%-- ${ListDTO.date } --%>
											</span>
											<span class="title" onClick="javascript:contentPopup('<fmt:formatDate value="${ListDTO.date }" pattern="yyyy-MM-dd HH:mm:ss"/>','${ListDTO.userName}')" style="font-size: 15px;">
											${ListDTO.title}
											</span> 
											<span class="float-end icon" style="font-size: 12.5px; padding-top: 5.4px; color: rgb(112, 112, 112);">
											${ListDTO.userName }
											</span>
										</li>
									</c:forEach>
								</ul>
								<nav class="d-xl-flex thread-pages"
									style="width: 235px; margin-left: 35%;">
<!--  페이지 넘버링 -->
									<c:set var="startPage" value="${1 }" />
									<c:choose>
										<c:when test="${currentPage%5 != 0 }">
											 <fmt:parseNumber var="pagecalc" value="${currentPage/5}" integerOnly="true"/> 
											<c:set var="startPage" value="${pagecalc+1}" />
										</c:when>
										<c:otherwise>
											<c:set var="startPage" value="${(pagecalc -1)*5+1}" />
										</c:otherwise>
									</c:choose>
									
									<c:set var="endPage" value="${startPage+5-1}" scope="request"/>
									
									<c:if test="${endPage> pageCount}">
										<c:set var="endPage" value="${pageCount}" scope="request"/>
									</c:if>
									
									<ul class="pagination">
	<!-- 이전페이지 -->
									<c:if test="${startPage>5}">
										<li class="page-item" >
											<a class="page-link" aria-label="Previous"
												href="javascript:pageItemSubmit(${currentPage-1},${endPostNum+10})">
												<span aria-hidden="true">«</span>
											</a>
										</li>
									</c:if>
										<c:forEach var="i" begin="${startPage}" end="${endPage}">
											<li class="page-item">
													<c:if test="${i==currentPage }">
														<b>
													</c:if>
												<a class="page-link" 
													href="javascript:pageItemSubmit(${i},${endPostNum- 10*(i-currentPage)})">
												${i }
												</a>
													<c:if test="${i==currentPage }">
														</b>
													</c:if>
											</li>
										</c:forEach>
										
	<!-- 다음페이지 목록 -->
									<c:if test="${endPage<pageCount}">
										<li class="page-item">
											<a class="page-link" aria-label="Next"
												href="javascript:pageItemSubmit(${currentPage+1},${endPostNum-10})">
												<span aria-hidden="true">»</span>
											</a>
										</li>
									</c:if>
									</ul>
								</nav>
<!-- end 페이지넘버링 -->
							</div>
						</div>
					</div>
				</div>
				<div class="col">
					<span
						style="font-size: 28px; font-family: 'Bungee Inline', serif; color: #000000; margin-left: 35%;"><i
						class="fas fa-trophy" style="color: rgb(210, 213, 69);"></i>&nbsp;<strong>RANKING
							!</strong></span>
				</div>
			</div>
		</div>
	</section>
	<script src="/assets/bootstrap/js/bootstrap.min.js"></script>
	<script src="https://unpkg.com/@bootstrapstudio/bootstrap-better-nav/dist/bootstrap-better-nav.min.js"></script>
	<script src="/assets/js/script.min.js"></script>
	<script src="/assets/js/Menmeet_Mentoring.js"></script>
</body>
	<%@include file="/footer.jsp"%>

</html>