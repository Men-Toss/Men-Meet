//카테고리 변경 js
function changeCategory() {
	var form = document.createElement("form");
	form.setAttribute("method", "post");
	form.setAttribute("action", "/MentoringListProc");
	document.body.appendChild(form);
	//mentoringwho
	var pageMentoringWho = document.getElementById("pageMentoringWho");
	var inputData_Who = document.createElement("input");
	inputData_Who.setAttribute("type", "hidden");
	inputData_Who.setAttribute("name", "mentoringWho");
	inputData_Who.setAttribute("value", pageMentoringWho.value);
	form.appendChild(inputData_Who);
	//category
	var selectedCategory = document.getElementById("comboMentoringCategory");
	var inputData_Category = document.createElement("input");
	inputData_Category.setAttribute("type", "hidden");
	inputData_Category.setAttribute("name", "mentoringCategory");
	inputData_Category.setAttribute("value", selectedCategory.options[selectedCategory.selectedIndex].value);
	form.appendChild(inputData_Category);
	//endPostNum
	var inputData_pageEndPostNum = document.createElement("input");
	inputData_pageEndPostNum.setAttribute("type", "hidden");
	inputData_pageEndPostNum.setAttribute("name", "endPostNum");
	inputData_pageEndPostNum.setAttribute("value", 0);
	form.appendChild(inputData_pageEndPostNum);
	//currentPage
	var inputData_CurrentPage = document.createElement("input");
	inputData_CurrentPage.setAttribute("type", "hidden");
	inputData_CurrentPage.setAttribute("name", "currentPage");
	inputData_CurrentPage.setAttribute("value", 0);
	form.appendChild(inputData_CurrentPage);
	form.submit();
}

//페이지카운터링 js
function pageItemSubmit(changedCurrentPage, changedEndPostNum) {
	//멘토링 서블릿으로 전송하는 form태그 작성
	var form = document.createElement("form");
	form.setAttribute("method", "post");
	form.setAttribute("action", "/MentoringListProc");
	document.body.appendChild(form);
	//멘토멘티 구분 input태그 추가
	var pageMentoringWho = document.getElementById("pageMentoringWho");
	var inputData_Who = document.createElement("input");
	inputData_Who.setAttribute("type", "hidden");
	inputData_Who.setAttribute("name", "mentoringWho");
	inputData_Who.setAttribute("value", pageMentoringWho.value);
	form.appendChild(inputData_Who);
	//선택된 카태고리 input태그 추가
	var selectedCategory = document.getElementById("comboMentoringCategory");
	var inputData_Category = document.createElement("input");
	inputData_Category.setAttribute("type", "hidden");
	inputData_Category.setAttribute("name", "mentoringCategory");
	inputData_Category.setAttribute("value", selectedCategory.options[selectedCategory.selectedIndex].value);
	form.appendChild(inputData_Category);
	//현재 페이지 input태그 추가
	var inputData_CurrentPage = document.createElement("input");
	inputData_CurrentPage.setAttribute("type", "hidden");
	inputData_CurrentPage.setAttribute("name", "currentPage");
	inputData_CurrentPage.setAttribute("value", changedCurrentPage);
	form.appendChild(inputData_CurrentPage);
	//마지막 (최신글)게시물 번호 input태그 추가
	var inputData_EndPostNum = document.createElement("input");
	inputData_EndPostNum.setAttribute("type", "hidden");
	inputData_EndPostNum.setAttribute("name", "endPostNum");
	inputData_EndPostNum.setAttribute("value", changedEndPostNum);
	form.appendChild(inputData_EndPostNum);
	form.submit();
}
//멘토멘티 항목 js
function changeMento_Mentee(Mento_Mentee) {
	//멘토링 서블릿으로 전송하는 form태그 작성
	var form = document.createElement("form");
	form.setAttribute("method", "post");
	form.setAttribute("action", "/MentoringListProc");
	document.body.appendChild(form);
	//멘토멘티 구분 input태그 추가
	var inputData_Who = document.createElement("input");
	inputData_Who.setAttribute("type", "hidden");
	inputData_Who.setAttribute("name", "mentoringWho");
	inputData_Who.setAttribute("value", Mento_Mentee);
	form.appendChild(inputData_Who);
	//category
	var selectedCategory = document.getElementById("comboMentoringCategory");
	var inputData_Category = document.createElement("input");
	inputData_Category.setAttribute("type", "hidden");
	inputData_Category.setAttribute("name", "mentoringCategory");
	inputData_Category.setAttribute("value", selectedCategory.options[selectedCategory.selectedIndex].value);
	form.appendChild(inputData_Category);
	//endPostNum
	var inputData_pageEndPostNum = document.createElement("input");
	inputData_pageEndPostNum.setAttribute("type", "hidden");
	inputData_pageEndPostNum.setAttribute("name", "endPostNum");
	inputData_pageEndPostNum.setAttribute("value", 0);
	form.appendChild(inputData_pageEndPostNum);
	//currentPage
	var inputData_CurrentPage = document.createElement("input");
	inputData_CurrentPage.setAttribute("type", "hidden");
	inputData_CurrentPage.setAttribute("name", "currentPage");
	inputData_CurrentPage.setAttribute("value", 0);
	form.appendChild(inputData_CurrentPage);
	form.submit();
}
//멘토링 팝업 페이지 js
function mentoringPopup() {
	var user = document.getElementById("loginInfo");
	if (user.value != "") {
		window.open("/Mentoring/Menmeet_Mentoring_Reservation.jsp", "멘토링 게시글 작성",
			"width=500, height=560, left=450, top=100");
	} else {
		alert("로그인 후 이용하실 수 있습니다.");
	}
}
//멘토링 게시물보기
function contentPopup(PostDate, PostName) {
	var user = document.getElementById("loginInfo");
	if (user.value != "") {
		window.open("/PostContentProc?postDate="+PostDate+"&postName="+PostName, "멘토링 게시물 정보",
			"width=500, height=540, left=450, top=100");
	} else {
		alert("로그인 후 이용하실 수 있습니다.");
	}
}