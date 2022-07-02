<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ taglib prefix="fmt" uri="http://java.sun.com/jsp/jstl/fmt"%>
<%@include file="/Encording.jsp"%>
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

<body
	style="background: url(/assets/img/b4.png) top/cover no-repeat, #ffffff;">
	<section style="height: 100vh;">
		<header style="height: 320px;">
			<%@include file="/navbar.jsp"%>
		</header>
		<div class="container" style="margin-top: 10%; margin-bottom: 20px;">
			<div class="row" id="rowProfile" style="margin-left: 10px;">
				<div class="col-md-6"
					style="height: 400px; background: url(/assets/img/post.png) no-repeat; background-size: auto;">
					<label class="form-label"
						style="font-weight: bold; font-family: Chilanka, serif; margin-left: 100px; padding-bottom: 0px; font-size: 25px;">
						<i class="far fa-file-alt"></i>&nbsp; Profile
					</label>
					<form
						style="margin-top: 25px; margin-left: 86px; border-radius: 40px; width: 350px; height: 220px; border: 3.5px none rgb(165, 199, 232);">
						<label class="form-label"
							style="margin-left: 40px; margin-top: 30px; margin-right: 18px; color: rgba(0, 0, 0, 0.7); font-size: 16px; font-weight: bold;"><i
							class="far fa-user"> </i>&nbsp; ${USER.name } 님<br></label>
						<button class="btn btn-primary btn-sm" type="button"
							style="font-size: 11px; margin-bottom: 3px; background: rgb(187, 187, 187); border-style: none;"
							onClick="nameChangePopup()">변경</button>
						<ul
							style="width: 350px; margin-left: 28px; margin-top: 15px; font-size: 14px;">
							<li style="margin-bottom: 10px; width: 250px;">ID :&nbsp;<span>${USER.id}</span></li>
							<li style="width: 250px;"><span onClick="pwdChangePopup()"
								style="cursor: pointer; text-decoration: underline;">비밀번호
									변경하기</span></li>
						</ul>
						<label class="form-label"
							style="margin-left: 40px; margin-top: 10px; font-size: 14px; margin-bottom: 20px;"><i
							class="fas fa-search-location"></i>&nbsp;</label>
					</form>
				</div>
				<div class="col-md-6"
					style="background: url(/assets/img/post3.png) no-repeat; background-size: auto;">
					<label class="form-label"
						style="font-weight: bold; font-family: Chilanka, serif; margin-left: 100px; padding-bottom: 0px; font-size: 25px; padding-top: 0px;"><i
						class="far fa-file-alt"></i>&nbsp; Mentoring</label>
					<div style="margin-top: 25px; margin-left: 86px; border-radius: 40px; width: 350px; height: 220px; border: 3.5px none rgb(165, 199, 232);">
						<label class="form-label"
							style="margin-left: 40px; margin-top: 30px; margin-right: 18px; margin-bottom: 15px; color: rgba(0, 0, 0, 0.7); font-size: 16px; font-weight: bold;"><i
							class="far fa-copy"></i>  멘토링 정보<br /></label><br>
						<ul style="width: 350px; margin-left: 28px; margin-top: 15px; font-size: 14px;">
					<c:choose>
						<c:when test="${empty MentoringInfo }">
							<li style="margin-bottom: 10px; width: 280px;">등록된 멘토링 예약정보가 없습니다.</li>
						</c:when>
						<c:otherwise>
						<c:forEach var="MyReservationDTO" items="${MentoringInfo}">
							<li style="margin-bottom: 10px; width: 280px;">
							${MyReservationDTO.title} <br> 멘토링 예약일 : 
							<fmt:formatDate var ="day" value="${MyReservationDTO.reservationTime }" pattern="yyyy-MM-dd HH:mm" />
							<c:out value="${day }"/>
								<form action="/CancelReservationProc" method="post">
									<input type="hidden" name ="mento" value="${ MyReservationDTO.mento}">
									<input type="hidden" name ="mentee" value="${ MyReservationDTO.mentee}">
									<input type="hidden" name ="reservationTime" value="<fmt:formatDate value="${MyReservationDTO.reservationTime }" pattern="yyyy-MM-dd HH:mm:ss"/>">
									<button class="btn btn-primary btn-sm float-end" type="submit"
										style="font-size: 11px; margin-right: 5px; background: rgb(187, 187, 187); border-style: none;">
										취소하기
									</button>
								</form>
							</li>
	</c:forEach>
	</c:otherwise>
</c:choose>
						</ul>
					</div>
				</div>
			</div>
		</div>
		<footer class="text-center">
			<span style="color: rgb(198, 210, 221); font-size: 12px;">Copyright
				2022.Men-Toss.All rights reserved.</span>
		</footer>
	</section>
	<script src="/assets/bootstrap/js/bootstrap.min.js"></script>
	<script src="https://cdnjs.cloudflare.com/ajax/libs/aos/2.3.4/aos.js"></script>
	<script
		src="https://unpkg.com/@bootstrapstudio/bootstrap-better-nav/dist/bootstrap-better-nav.min.js"></script>
	<script src="/assets/js/script.min.js"></script>
	<script src="/assets/js/Menmeet_Mypage.js"></script>
</body>

</html>