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

<body
	style="background: url(/assets/img/b4.png) top/cover no-repeat, #ffffff; height: 100vh;">
	<section style="height: 100vh;">
		<header style="height: 320px;">
			<%@include file="/navbar.jsp"%>
		</header>
		<section style="margin-top: 100px; margin-bottom: 50px;">
			<div class="container">
				<div class="row">
					<div class="col-md-12">
						<form>
							<div class="form-group mb-3">
								<div class="input-group">
									<span class="input-group-addon"> </span>
								</div>
							</div>
						</form>
						<div>
							<ul class="nav nav-tabs" role="tablist">
								<li class="nav-item" role="presentation"><a
									class="nav-link active" role="tab" data-bs-toggle="tab"
									href="#tab-1"
									style="font-weight: bold; font-size: 14px; background: #c7effb; margin-right: 7px;">캠퍼스
										안내 </a></li>
								<li class="nav-item" role="presentation"><a
									class="nav-link" role="tab" data-bs-toggle="tab" href="#tab-2"
									style="font-weight: bold; font-size: 14px; background: #c7effb; margin-right: 7px;">행정
										부서</a></li>
								<li class="nav-item" role="presentation"><a
									class="nav-link" role="tab" data-bs-toggle="tab" href="#tab-3"
									style="font-weight: bold; font-size: 14px; background: #c7effb; margin-right: 7px;">학과
										소개 </a></li>
								<li class="nav-item" role="presentation"><a
									class="nav-link" role="tab" data-bs-toggle="tab" href="#tab-4"
									style="font-weight: bold; font-size: 14px; background: #c7effb; margin-right: 7px;">동아리
										안내</a></li>
							</ul>
							<div class="tab-content">
								<div class="tab-pane active" role="tabpanel" id="tab-1"
									align="center">
									<iframe src="http://hm.seoil.ac.kr/115"
										style="margin-top: 100px; width: 900px; height: 750px;">
									</iframe>
								</div>

								<div class="tab-pane" role="tabpanel" id="tab-2" align="center">
									<iframe src="http://hm.seoil.ac.kr/66?group=5"
										style="margin-top: 100px; width: 900px; height: 750px;">
									</iframe>
								</div>
								<div class="tab-pane" role="tabpanel" id="tab-3" align="center">
									<iframe src="http://hm.seoil.ac.kr/66?group=4"
										style="margin-top: 100px; width: 900px; height: 750px;">
									</iframe>
								</div>

								<div class="tab-pane" role="tabpanel" id="tab-4" align="center">
									<iframe src="http://hm.seoil.ac.kr/69#ulife_con10"
										style="margin-top: 100px; width: 900px; height: 750px;">
									</iframe>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</section>
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
</body>

</html>