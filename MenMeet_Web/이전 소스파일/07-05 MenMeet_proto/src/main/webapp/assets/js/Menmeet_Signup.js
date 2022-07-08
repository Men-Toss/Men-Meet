//ID중복체크 js
function checkId() {
	var form = document.formSignup;
	form.action = "/SignupCheckId";
	form.submit();
}
//닉네임 중복 체크 js
function checkName() {
	var form = document.formSignup;
	form.action = "/SignupCheckName";
	form.submit();
}
//중복체크시 색상 변경 js
function duplicationColor() {
	var form = document.formSignup;
	if (form.DuplicationId.value == false) {
		document.getElementById("labelUsableID").style = "font-size: 10px; margin-left: 3%; width: 150px; color: green;";
	}
	if (form.DuplicationName.value == false) {
		document.getElementById("labelUsableName").style = "font-size: 10px; margin-left: 3%; width: 150px; color: green;";
	}

}
//비밀번호 작명 규칙 js
function checkPassword() {
	var form = document.formSignup;
	var pwdCheck = /^(?=.*[a-zA-Z])(?=.*[!@#$%^*+=-])(?=.*[0-9]).{8,20}$/;
	var pTag = document.getElementById("pwdCheckPtag");
	//비밀번호 작명규칙을 어겼을 때
	if (!pwdCheck.test(form.txtInputPassword.value + "")) {
		pTag.style = "font-size: 10px; color:red; margin-top: 5px;";
		pTag.innerText = "비밀번호는 영문+숫자+특수문자 조합으로 8~20자리로 입력해야 합니다.";
		form.passowrdCheck.value = "false";
		return false;
	}
	//정상적으로 비밀번호 입력시
	else {
		//비밀번호 확인 값이 안맞을 때
		if (form.txtInputRePassword.value !== form.txtInputPassword.value) {
			pTag.style = "font-size: 10px; color:red; margin-top: 5px;";
			pTag.innerText = "비밀번호가 일치하지 않습니다.";
			form.passowrdCheck.value = "false";
			return false;
		}
		//비밀번호 확인 값이 일치할 때
		if (form.txtInputRePassword.value == form.txtInputPassword.value) {
			pTag.style = "font-size: 10px; color:green; margin-top: 5px;";
			pTag.innerText = "비밀번호가 일치합니다.";
			form.passowrdCheck.value = "true";
			return false;
		}
	}

}
//회원가입 입력사항 체크 js
function checkSignupForm() {
	var form = document.formSignup;
	if (!form.txtInputId.value || !form.txtInputPassword || !form.txtInputName.value) {
		alert("가입할 회원정보를 입력해주세요.");
		return false;
	} else if (form.passowrdCheck.value == "false") {
		alert("비밀번호 입력정보를 확인해주세요.");
		return false;
	}
	else if (form.DuplicationId.value == "true" || formDuplicationName.value == "true") {
		alert("중복된 회원정보를 사용하실 수 없습니다. 다시 시도해 주세요.");
		return false;
	}
	else {
		form.action = "/SignupProc";
		return true;
	}
}