function checkId(){
    var form = document.formSignup;
    form.action="/SignupCheckId";
    form.submit();
}
function checkName(){
    var form = document.formSignup;
    form.action="/SignupCheckName";
    form.submit();
}
function checkPassword(){
    var form = document.formSignup;

}
function checkDuplication(){
    var form = document.formSignup;
    if(!form.txtInputId.value||!form.txtInputPassword||!form.txtInputName.value){
        alert("가입할 회원 정보를 입력해주세요.");
    }
    else if(form.txtInputPassword != form.txtInputRePassword){ // 다시하기
        alert("비밀번호가 일치하지 않습니다. 다시 확인해 주세요.")
    }
    else if(form.DuplicationId.value=="true"||formDuplicationName.value=="true"){
        alert("중복된 회원정보를 사용하실 수 없습니다. 다시 시도해 주세요.");
    }
}