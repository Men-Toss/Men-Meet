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
	<form id="formChangePwd" name="formChangePwd" action="/ChangePasswordProc" method="post" onsubmit="return changePasswordForm()">
		<div align="center">
			<label class="form-label"
				style="font-weight: bold; margin-top: 20px; margin-bottom: 15px;"><i
				class="far fa-edit"></i> 비밀번호 변경</label>
		</div>
		<div class="mb-3" align="center">
			<input class="form-control" type="password" id="pwInputCurrentPwd"
				name="pwInputCurrentPwd" minlength="8" maxlength="20" required=""
				placeholder="현재 비밀번호"
				style="font-size: 14px; width: 320px; margin-left: 30px;">
			<input class="form-control" type="password" id="pwInputChangePwd"
				name="pwInputChangePwd"
				style="margin-top: 20px; width: 320px; font-size: 14px; margin-left: 30px;"
				minlength="8" maxlength="20" required="" placeholder="새 비밀번호">
			<p align="left"
				style="font-size: 10px; color: rgb(173, 176, 180); margin-left: 32px;">(
				특수 문자,영문,숫자를 조합하여 8~20자 이내)</p>
			<input class="form-control" type="password" id="pwInputReChangePwd"
				name="pwInputReChangePwd"
				style="margin-top: 20px; width: 320px; height: 35px; font-size: 14px; margin-left: 30px;"
				minlength="8" maxlength="20" required="" placeholder="새 비밀번호 확인">
		<input type="hidden" name = "user" value="${USER.id }"/>
		</div>
		<div align="center">
			<button id="btnPwdChange" name="btnPwdChange" type="submit"
				style="width: 55px; height: 27px; border: 0px; margin-top: 25px; margin-right: 10px"
				required="">확인</button>
			<button id="btnPwdChangeClose" name="btnPwdChangeClose"
				style="width: 55px; border: 0px; height: 27px;"
				onClick="window.close()">취소</button>
		</div>
	</form>
	<script src="/assets/bootstrap/js/bootstrap.min.js"></script>
	<script src="/assets/js/Menmeet_Mypage.js"></script>
	<script
		src="https://unpkg.com/@bootstrapstudio/bootstrap-better-nav/dist/bootstrap-better-nav.min.js"></script>
</body>

</html>