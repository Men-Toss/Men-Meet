<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>


<nav class="navbar navbar-light navbar-expand-md">
	<div class="container-fluid">
		<a class="navbar-brand" href="/Menmeet_Main.jsp"
			style="width: 150px; background: url(/assets/img/logo1.png) center/cover no-repeat; height: 50px;">&nbsp;</a>
		<button data-bs-toggle="collapse" class="navbar-toggler"
			data-bs-target="#navcol-1">
			<span class="visually-hidden">Toggle navigation</span><span
				class="navbar-toggler-icon"></span>
		</button>
		<div class="collapse navbar-collapse" id="navcol-1">
			<ul class="navbar-nav">
				<li class="nav-item"><a class="nav-link active"
					data-bss-hover-animate="swing" href="/Menmeet_Main.jsp"
					style="color: #2969b4; font-size: 13px; padding: 10px; margin-left: -4px; padding-left: 15px; padding-right: 48px;"><strong>Home</strong></a>
				</li>
				<li class="nav-item"><a class="nav-link"
					data-bss-hover-animate="swing"
					href="/MentoringListProc"
					style="color: #2969b4; font-size: 13px; padding: 10px; padding-right: 48px; padding-left: 15px;"><strong>Mentoring</strong></a>
				</li>
				<li class="nav-item"><a class="nav-link"
					data-bss-hover-animate="swing"
					href="/Menmeet_Main.jsp#portfolio"
					style="color: #2969b4; font-size: 13px; padding: 10px; padding-right: 48px; padding-left: 15px;"><strong>Metaverse</strong></a>
				</li>
			</ul>
			<ul class="navbar-nav">
				<li class="nav-item"><a class="nav-link active"
					data-bss-hover-animate="swing" href="/Seoil/Menmeet_Seoil.jsp"
					style="color: #2969b4; font-size: 13px; padding: 10px; padding-right: 48px; padding-left: 15px;"><strong>Seoil</strong></a>
				</li>
				<li class="nav-item"><a class="nav-link"
					data-bss-hover-animate="swing" href="/MyPageProc"
					style="color: #2969b4; font-size: 13px; padding: 10px; padding-right: 48px; padding-left: 15px;"><strong>Mypage</strong></a>
				</li>
			</ul>
			<ul class="navbar-nav ms-auto"
				style="font-size: 12px; height: 50px; width: 60px; margin-right: 15px;"></ul>
			<ul class="navbar-nav">
<c:choose>
	<c:when test="${USER == null }">
				<li class="nav-item"></li>
				<li class="nav-item"><a class="nav-link"
					href="/Login/Menmeet_Login.jsp"
					style="font-size: 13px; margin-right: 10px;"><span
						style="text-decoration: underline;">로그인</span></a></li>
				<li class="nav-item"><a class="nav-link"
					href="/Signup/Menmeet_Signup.jsp"
					style="font-size: 13px; margin-right: 10px;"><span
						style="text-decoration: underline;">회원가입</span></a></li>
	</c:when>
	<c:otherwise>
			<li class="nav-item"></li>
				<li class="nav-item"><a class="nav-link"
					href="/MyPageProc"
					style="font-size: 13px; margin-right: 10px;"><span
						style="text-decoration: underline;">${USER.name }님</span></a></li>
				<li class="nav-item"><a class="nav-link"
					href="/LogoutProc"
					style="font-size: 13px; margin-right: 10px;"><span
						style="text-decoration: underline;">로그아웃</span></a></li>
	</c:otherwise>
</c:choose>
			</ul>
		</div>
	</div>
</nav>