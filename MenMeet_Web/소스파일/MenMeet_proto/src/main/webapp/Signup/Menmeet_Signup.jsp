<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@include file="/Encording.jsp"%>
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no">
    <title>MenMeet</title>
    <link rel="stylesheet" href="/assets/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Aguafina+Script&amp;display=swap">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Akronim&amp;display=swap">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Allan&amp;display=swap">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Annie+Use+Your+Telescope&amp;display=swap">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Beth+Ellen&amp;display=swap">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Bungee+Inline&amp;display=swap">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Bungee+Shade&amp;display=swap">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Butcherman&amp;display=swap">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Chilanka&amp;display=swap">
    <link rel="stylesheet" href="/assets/fonts/fontawesome-all.min.css">
    <link rel="stylesheet" href="/assets/css/styles.min.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.5.2/animate.min.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/aos/2.3.4/aos.css">
    <link rel="stylesheet"
        href="https://unpkg.com/@bootstrapstudio/bootstrap-better-nav/dist/bootstrap-better-nav.min.css">
</head>

<body style="background: #ffffff;">
    <section id="sSignup">
<%@include file="/navbar.jsp" %>
        <section id="sSignup" class="position-relative py-4 py-xl-5">
			<div class="container position-relative">
				<div class="row">
					<div class="col-7 text-center" id="colTrain"
						style="height: 700px; background: url(&quot;/assets/img/sign3.gif&quot;) no-repeat; background-size: cover; margin-left: 35px;">
						<div class="row" id="rowBicycle">
							<div class="col offset-xl-0 text-center" id="colLogo">
								<img id="Menmeet_Signup_img_logo" src="/assets/img/logo1.png"
									style="width: 60%; height: 100%; margin-top: 8px;">
							</div>
						</div>
					</div>
					<div class="col-md-6 col-xl-4" data-aos="fade-down" id="colSignup"
						style="background: rgb(255, 255, 255); border: 4px solid rgb(33, 113, 194); box-shadow: 10px 10px 15px 0px rgb(135, 140, 145); margin-top: 27px;">
						<div>
							<form name="formSignup" id="formSignup" class="p-3 p-xl-4" method="post" action="/SignupProc" onsubmit="return checkSignupForm()">
								<h4 class="text-center"
									style="color: var(- -bs-dark); font-family: 'Annie Use Your Telescope', serif; font-size: 30px; margin-right: 20px;">
									<i class="far fa-user"></i><strong>&nbsp;Sign Up</strong>
								</h4>
								<p class="text-center text-muted"
									style="font-size: 12px; margin-top: 15px;">
									<em>Welcome to MenMeet!</em><br>
									<em>Please fill it out according to the form.</em><br>
									<b style="color:red;">${param.msg }</b>
								</p>
									
								<div class="text-start mb-3">
									<label class="form-label" for="name"
										style="font-family: 'Annie Use Your Telescope', serif; font-weight: bold; font-size: 18px;">ID</label><label
										class="form-label" id="labelUsableID" onload="duplicationColor()"
										style="font-size: 10px; margin-left: 3%; width: 150px; color: red;">
									${param.IdIs }
									</label>
									<button class="btn btn-primary float-end" id="btnID"
										type="button" onclick="checkId()"
										style="width: 70px; height: 27px; margin-left: 5%; font-size: 10px; background: rgb(254, 254, 255); color: rgb(126, 122, 122); border-color: rgb(0, 0, 0, 0);">
										중복확인</button>
									<input class="shadow-sm form-control" type="text"
										id="txtInputID" name="txtInputId" value="${param.txtInputId }" minlength="5" maxlength="15" required="">
									<p
										style="font-size: 10px; color: rgb(173, 176, 180); margin-top: 5px;">(
										5~15자 이내 )</p>
								</div>
								<div class="mb-3">
									<label class="form-label" for="email"
										style="font-family: 'Annie Use Your Telescope', serif; font-size: 18px;"><strong>Password</strong>
										</label>
										<input
										class="form-control" type="password" id="pwInputPw" name="txtInputPassword" 
										minlength="8" maxlength="20" required="">
									<p 
										style="font-size: 10px; color: rgb(173, 176, 180); margin-top: 5px;">(
										특수 문자,영문,숫자를 조합하여 8~20자 이내 )</p>
									<input class="form-control" type="password" id="pwInputrRePw" name="txtInputRePassword"
										style="margin-top: 10px;" minlength="8" maxlength="20" onkeyup="checkPassword()"
										required="">
									<p id="pwdCheckPtag" 
										style="font-size: 10px; color: rgb(173, 176, 180); margin-top: 5px;">
										( 패스워드 확인 )</p>
								</div>
								<div class="mb-3">
									<label class="form-label" for="message"
										style="font-size: 18px; font-family: 'Annie Use Your Telescope', serif;"><strong>Name</strong></label>
										<label
										class="form-label" id="labelUsableName" onload="duplicationColor()"
										style="font-size: 10px; margin-left: 3%; width: 150px; color: red;">
										${param.NameIs }
										</label>
									<button class="btn btn-primary float-end" id="btnName"
										type="button" onclick="checkName()"
										style="width: 70px; height: 27px; margin-left: 5%; font-size: 10px; background: rgb(254, 254, 255); color: rgb(126, 122, 122); border-color: rgb(0, 0, 0, 0);">
										중복확인</button>
									<input class="form-control" type="text" id="txtInputName" name="txtInputName" value="${param.txtInputName }"
										minlength="1" maxlength="10" required="" >
									<p
										style="font-size: 10px; color: rgb(173, 176, 180); margin-top: 5px;">(
										10자 이내 )</p>
								</div>
								
								<input type="hidden" name="passowrdCheck" value="false">
								<input type="hidden" name="IdIs" value="${param.IdIs }">
								<input type="hidden" name="NameIs" value="${param.NameIs }">
								<input type="hidden" name="DuplicationId" value="${param.DuplicationId }">
								<input type="hidden" name="DuplicationName" value="${param.DuplicationName }">
								<div class="text-center mb-3">
									<button class="btn btn-primary" id="btnSignup" type="submit"
										style="font-size: 14px; background: rgb(105, 195, 234); border-color: rgb(105, 195, 234); padding-right: 15px; padding-left: 15px; margin-top: 10px; padding-bottom: 7px; padding-top: 7px;">
										<em>Sign up</em>
									</button>
								</div>
							</form>
						</div>
					</div>
				</div>
			</div>
		</section>
	</section>
<%@include file="/footer.jsp" %>
    <script src="/assets/bootstrap/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/aos/2.3.4/aos.js"></script>
    <script src="https://unpkg.com/@bootstrapstudio/bootstrap-better-nav/dist/bootstrap-better-nav.min.js"></script>
    <script src="/assets/js/script.min.js"></script>
    <script src="/assets/js/Menmeet_Signup.js"></script>
</body>
</html>