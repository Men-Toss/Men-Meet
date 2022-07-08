<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@include file="/Encording.jsp" %>
<!DOCTYPE html>
<html class="fs-6" lang="en">
<head>
<meta charset="utf-8">
<meta name="viewport"
	content="width=device-width, initial-scale=1.0, shrink-to-fit=no">
<title>MenMeet</title>
<link rel="stylesheet" href="/assets/bootstrap/css/bootstrap.min.css">
<link rel="stylesheet"
	href="https://fonts.googleapis.com/css?family=Aguafina+Script&amp;display=swap">
<link rel="stylesheet"
	href="https://fonts.googleapis.com/css?family=Akronim&amp;display=swap">
<link rel="stylesheet"
	href="https://fonts.googleapis.com/css?family=Allan&amp;display=swap">
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
<body class="text-center"
	style="background: url(/assets/img/b4.png) top/cover no-repeat, #ffffff;">
	<section class="text-center" id="sMenmeet"
		style="width: 100%; height: 100vh;">
		<header>
			<div>
				<%@include file="/navbar.jsp" %>
			</div>
		</header>
		<section class="flex-column" id="sLoginForm">
			<div id="dLogin" class="login-one"
				style="background: rgba(0, 0, 0, 0);">
				<form class="text-center login-one-form" id="loginForm" action="/LoginProc" method="post" accept-charset="utf-8"
					style="background: rgba(0, 0, 0, 0);">
					<div class="col">
						<div class="form-group mb-3" style="height: 165px;">
							<span style="color: red;">${param.msg }</span>
							<input class="form-control" type="text" id="txtId" name="txtId"
								placeholder="ID"
								style="padding: 5px 12px; padding-bottom: 8px; margin-bottom: 12px;"
								minlength="5" maxlength="15" required=""><input
								class="form-control" type="password" id="txtPassword" name="txtPassword"
								placeholder="Password" minlength="8" maxlength="20" required="">
							<button class="btn btn-primary" data-bss-hover-animate="pulse"
								id="btnLogin"
								style="background-color: #007ac9; margin-top: 20px;"
								type="submit">Log in</button>
						</div>
					</div>
					<span id="spanAccount"
						style="font-size: 12px; color: rgb(132, 138, 145);">계정이
						필요하신가요?</span><span id="spanSignup"
						style="padding-right: 15px; padding-left: 10px; font-size: 13px; color: var(- -bs-blue);"><i
						class="far fa-hand-point-right"></i><span
						style="text-decoration: underline;"><a href="/Signup/Menmeet_Signup.jsp">
								회원가입</a></span></span>
				</form>
			</div>
		</section>
	</section>
	<%@include file="/footer.jsp" %>
	<script src="/assets/bootstrap/js/bootstrap.min.js"></script>
	<script src="https://cdnjs.cloudflare.com/ajax/libs/aos/2.3.4/aos.js"></script>
	<script
		src="https://unpkg.com/@bootstrapstudio/bootstrap-better-nav/dist/bootstrap-better-nav.min.js"></script>
	<script src="/assets/js/script.min.js"></script>
</body>
</html>