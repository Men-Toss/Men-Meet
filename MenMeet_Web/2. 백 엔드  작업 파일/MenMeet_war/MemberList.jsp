<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%
request.setCharacterEncoding("UTF-8");
%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>MemberList</title>
</head>
<body>

	<center>
		<h2>모든 회원 보기</h2>
		<table width="800" border="1" bordercolor="gray">
			<tr height="40">
				<td align="center" width="50">ID</td>
				<td align="center" width="50">PASSWORD</td>
				<td align="center" width="50">EMAIL</td>
				<td align="center" width="50">TEL</td>
				<td align="center" width="50">ADDRESS</td>
			</tr>
			
			<c:forEach var="bean" items="${v }">
			<tr height="40">
				<td align="center" width="50">${bean.id }</td>
				<td align="center" width="50">${bean.password }</td>
				<td align="center" width="50"><a href="#">${bean.email }</a></td>
				<td align="center" width="50">${bean.tel }</td>
				<td align="center" width="50">${bean.address }</td>
			</tr>
			
			</c:forEach>
			
		</table>
	</center>


</body>
</html>