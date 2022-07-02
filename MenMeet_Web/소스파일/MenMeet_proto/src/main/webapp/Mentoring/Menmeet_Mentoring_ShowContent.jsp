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
	href="https://cdnjs.cloudflare.com/ajax/libs/aos/2.3.4/aos.css">
<link rel="stylesheet"
	href="https://unpkg.com/@bootstrapstudio/bootstrap-better-nav/dist/bootstrap-better-nav.min.css">
</head>

<body>
	<form id="formContent" name="formContent" action="/ReservationProc" method="post"
		style="margin-top: 12px; background: url(/assets/img/back8.gif) bottom/auto, rgba(0, 0, 0, 0);">
		
		<span style="margin-left: 34%; margin-bottom: 15px; font-weight: bold; font-size: 18px;">
			<i class="far fa-edit"></i> 멘토링 게시글 </span>	<br><br> 
		<span style="margin-left: 55px; font-weight: bold; font-size: 14px;">
			구분 : 
		</span> 
		
		<label id="labelgPost" style="font-size: 14px;">
			<c:choose>
				<c:when test="${MCDTO.who == 0 }">
					Mentee를 구해요
				</c:when>
				<c:otherwise>
					Mento를 구해요
				</c:otherwise>
			</c:choose> 
		</label> 
			
		<span style="margin-left: 55px; font-weight: bold; font-size: 14px;">
			카테고리 : 
		</span> 
		
		<label id="labelSelectedCategory" style="font-size: 14px;"> 
			<c:choose>
				<c:when test="${MCDTO.category == 0 }">전공</c:when>
				<c:when test="${MCDTO.category == 1 }">진로</c:when>
				<c:when test="${MCDTO.category == 2 }">연애</c:when>
				<c:when test="${MCDTO.category == 3 }">학교생활</c:when>
				<c:otherwise>기타</c:otherwise>
			</c:choose> 
		</label> 
		<input class="form-control" value="${MCDTO.title}" type="text"
			style="width: 385px; margin-top: 5px; margin-left: 55px;"readonly>
		<textarea class="form-control" id="txtInputwTitle"
			id="txtareawContent" 
			style="width: 385px; height: 240px; margin-bottom: 10px; margin-left: 55px; margin-top: 10px;" readonly>${MCDTO.content}</textarea>

		<div class="row" >
			<div class="col" style="margin-left: 55px;">
				<span style=" width: 250pxhheight: 40px">
					<input style=" width: 240px;"  type="text" value="예약일 : <fmt:formatDate value="${MCDTO.reserveTime }" pattern="yyyy-MM-dd HH:mm"/>" readonly/>
				</span>
				<span style="width: 100px;margin-left: 10px">
				
				<input type="hidden" name = "mcNum" value="${MCDTO.num}">
				<input type="hidden" name = "mcWho" value="${MCDTO.who}">
				<input type="hidden" name = "mcWriter" value="${MCDTO.writer}">
				<input type="hidden" name = "mcCategory" value="${MCDTO.category}">
				<input type="hidden" name = "mcReservationTime" value="<fmt:formatDate value="${MCDTO.reserveTime }" pattern="yyyy-MM-dd HH:mm:ss"/>">
				
				
					<button id="btnRequest" name="btnRequest" class="btn btn-primary"
						type="submit" >
						<c:choose>
							<c:when test="${MCDTO.who==0 }">멘티 신청하기</c:when>
							<c:otherwise >멘토 신청하기</c:otherwise>
						</c:choose>
					</button>
				</span>
			</div>
		</div>
	</form>
	<script src="/assets/bootstrap/js/bootstrap.min.js"></script>
	<script src="https://cdnjs.cloudflare.com/ajax/libs/aos/2.3.4/aos.js"></script>
	<script
		src="https://unpkg.com/@bootstrapstudio/bootstrap-better-nav/dist/bootstrap-better-nav.min.js"></script>
	<script src="/assets/js/script.min.js"></script>
</body>

</html>