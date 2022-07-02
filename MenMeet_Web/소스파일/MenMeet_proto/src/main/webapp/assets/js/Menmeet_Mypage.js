//마이페이지 js
function nameChangePopup() {
	window.open("/Mypage/Menmeet_Mypage_NameChange.jsp", "닉네임 변경 팝업창", "width=380, height=180, left=450, top=300");
}

function pwdChangePopup() {
	window.open("/Mypage/Menmeet_Mypage_PasswordChange.jsp", "비밀번호 변경 팝업창", "width=380, height=320, left=450, top=250");
}
function changePasswordForm() {
	var form = document.formChangePwd;
	var pwdCheck = /^(?=.*[a-zA-Z])(?=.*[!@#$%^*+=-])(?=.*[0-9]).{8,20}$/;
	if (form.pwInputChangePwd.value !== form.pwInputReChangePwd.value) {
		alert("변경하시는 비밀번호가 일치하지 않습니다. 다시 확인해주세요.");
		return false;
	} else if (!pwdCheck.test(form.pwInputChangePwd.value + "")) {
		alert("비밀번호는 영문+숫자+특수문자 조합으로 8~20자리로 입력해야 합니다.");
		return false;
	} else if (form.pwInputCurrentPwd == form.pwInputChangePwd) {
		alert("이전 비밀번호와 일치합니다. 다시 확인해주세요.")
		return false;
	} else {
		return true;
	}
}

