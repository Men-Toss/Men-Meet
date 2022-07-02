<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
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
	<form id="formWrite" name="formWrite" action="/MentoringProc" method="post"
		style="margin-top: 12px; background: url(/assets/img/back8.gif) bottom/auto, rgba(0, 0, 0, 0);">
		<span
			style="margin-left: 32%; margin-bottom: 15px; font-weight: bold; font-size: 18px;">
			<i class="far fa-edit"></i> 
			멘토링 게시글쓰기
		</span>
		<br> 
<!-- 멘토멘티 -->
			<select name="mentoringWho" style="margin-top: 15px; background: rgb(255, 255, 255);
				color: rgb(0, 0, 0); border: 2px solid rgb(111, 169, 237);
				margin-left: 55px; width: 220px;">
				<option value="0">멘토가 되고싶어요</option>
				<option value="1">멘티가 되고싶어요</option>
			</select> 
<!-- 카테고리 -->
		<select id="comboPopupCategory" name="mentoringCategory"
			style="margin-top: 10px; margin-bottom: 15px; background: rgb(255, 255, 255); color: rgb(0, 0, 0);
			 border: 2px solid rgb(111, 169, 237); margin-left: 10px; width: 150px;">
			<option value="0">전공</option>
			<option value="1">진로</option>
			<option value="2">연애</option>
			<option value="3">학교생활</option>
			<option value="4">기타</option>
		</select>
		<br> 
<!-- 제목 -->
		<input class="form-control" placeholder="제목을 입력해주세요."
			name="Mentoring_Title" type="text" style="width: 385px; margin-left: 55px;">
<!-- 글 -->
		<textarea class="form-control"
			id="txtareawContent" name="mentoring_Explanation"
			placeholder="내용을 입력해주세요."
			style="width: 385px; height: 240px; margin-bottom: 10px; margin-left: 55px; margin-top: 10px;"></textarea>

		<div class="row">
			<div class="col" style="width: 60%">
				<span style="margin-left: 55px; font-size: 13.5px;">
				예약날짜와 시간을 선택하세요.<br>
				</span>
<!-- 멘토링 날짜 -->
				<input class="form-control" type="date" id="sDate" name="mentoringDay"
					style="width: 240px; margin-left: 55px; margin-bottom: 10px; 
					margin-top: 15px; border-width: 2px; border-color: rgb(111, 169, 237);">
<!-- 멘토링 시간 -->
				<input type="time" id="sTime" name="mentoringTime"
					style="width: 240px; margin-left: 55px; margin-top: 15px; 
					border-width: 2px; border-color: rgb(111, 169, 237);">
			</div>
			
			<div class="col"></div>
			
			<button id="btnRegister" name="mentoringSubmit" class="btn btn-primary"
				type="submit"
				style="width: 100px; margin-right: 78px; margin-top: 20px;">등록</button>
		</div>
	</form>
	<script src="/assets/bootstrap/js/bootstrap.min.js"></script>
	<script src="https://cdnjs.cloudflare.com/ajax/libs/aos/2.3.4/aos.js"></script>
	<script
		src="https://unpkg.com/@bootstrapstudio/bootstrap-better-nav/dist/bootstrap-better-nav.min.js"></script>
	<script src="/assets/js/script.min.js"></script>
</body>

</html>