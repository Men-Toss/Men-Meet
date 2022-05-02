<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html class="fs-6" lang="en">

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no">
    <title>MenMeet</title>
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet"
        href="https://unpkg.com/@bootstrapstudio/bootstrap-better-nav/dist/bootstrap-better-nav.min.css">
    <link rel="stylesheet" href="assets/css/styles.min.css">
</head>

<body style="/*background: url(&quot;assets/img/b4.png&quot;) top / cover no-repeat, #ffffff;*/">
    <section id="menmeet"
        style="width: 100%;height: 100vh;background: url(&quot;assets/img/b4.png&quot;) top / cover no-repeat;">
        <div>
            <nav class="navbar navbar-light navbar-expand-md">
                <div class="container-fluid"><a class="navbar-brand" href="Menmeet_main.jsp"
                        style="width: 150px;background: url(&quot;assets/img/logo1.png&quot;) center / cover no-repeat;height: 50px;">&nbsp;</a><button
                        data-bs-toggle="collapse" class="navbar-toggler" data-bs-target="#navcol-1"><span
                            class="visually-hidden">Toggle navigation</span><span
                            class="navbar-toggler-icon"></span></button>
                    <div class="collapse navbar-collapse" id="navcol-1">
                        <ul class="navbar-nav">
                            <li class="nav-item"><a class="nav-link active" href="Menmeet_main.jsp"
                                    style="color: #2969b4;font-size: 13px;padding: 10px;margin-left: -4px;padding-left: 15px;padding-right: 48px;"><strong>Home</strong></a>
                            </li>
                            <li class="nav-item"><a class="nav-link" href="Menmeet_mentoring.jsp"
                                    style="color: #2969b4;font-size: 13px;padding: 10px;padding-right: 48px;padding-left: 15px;"><strong>Mentoring</strong></a>
                            </li>
                            <li class="nav-item"><a class="nav-link" href="Menmeet_Metaverse.jsp"
                                    style="color: #2969b4;font-size: 13px;padding: 10px;padding-right: 48px;padding-left: 15px;"><strong>Metaverse</strong></a>
                            </li>
                        </ul>
                        <ul class="navbar-nav">
                            <li class="nav-item"><a class="nav-link active" href="http://hm.seoil.ac.kr/"
                                    style="color: #2969b4;font-size: 13px;padding: 10px;padding-right: 48px;padding-left: 15px;"><strong>Seoil</strong></a>
                            </li>
                            <li class="nav-item"><a class="nav-link" href="Menmeet_qna.jsp"
                                    style="color: #2969b4;font-size: 13px;padding: 10px;padding-right: 48px;padding-left: 15px;"><strong>Q&amp;A</strong></a>
                            </li>
                            <li class="nav-item"><a class="nav-link" href="Menmeet_mypage.jsp"
                                    style="color: #2969b4;font-size: 13px;padding: 10px;padding-right: 48px;padding-left: 15px;"><strong>Mypage</strong></a>
                            </li>
                        </ul>
                        <ul class="navbar-nav ms-auto" style="font-size: 12px;width: 120px;height: 50px;">
                            <li class="nav-item"></li>
                            <li class="nav-item"></li>
                            <li class="nav-item"><a class="nav-link" href="Menmeet_login.jsp" style="padding-top: 15px;">로그인을 해주세요.</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
        </div>
        <header></header>
        <aside></aside>
        <section class="flex-column" id="login">
            <div id="login-one" class="login-one" style="background: rgba(0,0,0,0);">
                <form class="login-one-form">
                    <div class="col">
                        <div class="form-group mb-3">
                            <div></div><input class="form-control" type="text" id="input-1" placeholder="ID"
                                style="padding: 5px 12px;padding-bottom: 8px;margin-bottom: 12px;"><input
                                class="form-control" type="password" id="input-2" placeholder="Password"><button
                                class="btn btn-primary" id="button" style="background-color:#007ac9;" type="submit">Log
                                in</button>
                        </div>
                    </div>
                </form>
            </div>
        </section>
    </section>
    <div class="col"><img id="metBack" src="assets/img/metback.png"></div>
    <footer class="text-center"><span style="color: rgb(198,210,221);font-size: 12px;">Copyright 2022.Men-Toss.All
            rights reserved.</span></footer>
    <script src="assets/bootstrap/js/bootstrap.min.js"></script>
    <script src="https://unpkg.com/@bootstrapstudio/bootstrap-better-nav/dist/bootstrap-better-nav.min.js"></script>
</body>

</html>