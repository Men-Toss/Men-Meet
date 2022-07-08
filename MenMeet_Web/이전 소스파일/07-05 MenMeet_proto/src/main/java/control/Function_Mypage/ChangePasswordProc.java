package control.Function_Mypage;

import java.io.IOException;
import java.io.PrintWriter;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import DAO.MyPageDAO;

@WebServlet("/ChangePasswordProc")
public class ChangePasswordProc extends HttpServlet {
	private static final long serialVersionUID = 1L;
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		request.setCharacterEncoding("UTF-8");
		response.setContentType("text/html; charset=UTF-8");
		PrintWriter out = response.getWriter();
		String userId = request.getParameter("user");
		String userPassword = request.getParameter("pwInputCurrentPwd");
		String changePassword = request.getParameter("pwInputReChangePwd");
		MyPageDAO MPDAO = new MyPageDAO();
		boolean confirmChange = MPDAO.updateUserPassword(userId, userPassword,changePassword);
		if(confirmChange) {
			out.print("<script>"
					+ "alert('비밀번호 변경이 완료되었습니다. 다시 로그인해주세요.');"
					+ "window.close();"
					+ "</script>");
		}else {
			out.print("<script>"
					+ "alert('비밀번호 변경에 실패하였습니다. 다시 시도해주세요.');"
					+ "window.close();"
					+ "</script>");
		}
	}
}
