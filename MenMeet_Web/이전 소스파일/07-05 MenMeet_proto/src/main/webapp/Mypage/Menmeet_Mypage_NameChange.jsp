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
	href="https://unpkg.com/@bootstrapstudio/bootstrap-better-nav/dist/bootstrap-better-nav.min.css">
</head>

<body>
	<form id="formChangeName" name="formChangeName" action="/ChangeNameProc" method="post">
		<div align="center">
			<label class="form-label"
				style="font-weight: bold; margin-top: 20px; margin-bottom: 15px;">
				<i class="far fa-edit"> 이름 변경 </i>
			</label>
		</div>
		<div class="mb-3" align="center">
		<input type="hidden" name= "user" value="${USER.id }"/>
			<input class="form-control" type="text" id="txtInputChangeName"
				name="txtInputChangeName" minlength="1" maxlength="10" required=""
				placeholder="변경하실 이름을 입력해주세요."
				style="font-size: 14px; width: 320px; margin-left: 30px;">
			<div align="center">
				<button id="btnNameChange" name="btnNameChange" type="submit"
					style="width: 55px; height: 27px; border: 0px; margin-top: 25px; margin-right: 10px"
					required="">확인</button>
				<button id="btnNameChangeClose" name="btnNameChangeClose"
					style="width: 55px; border: 0px; height: 27px;"
					onClick="window.close()">취소</button>
			</div>
		</div>
	</form>
	<script src="/assets/bootstrap/js/bootstrap.min.js"></script>
	<script
		src="https://unpkg.com/@bootstrapstudio/bootstrap-better-nav/dist/bootstrap-better-nav.min.js"></script>
</body>

</html>