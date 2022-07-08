package control.Function_Mypage;

import java.io.IOException;
import java.io.PrintWriter;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import DAO.MyPageDAO;
import DTO.UserDTO;

@WebServlet("/ChangeNameProc")
public class ChangeNameProc extends HttpServlet {
	private static final long serialVersionUID = 1L;
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		request.setCharacterEncoding("UTF-8");
		response.setContentType("text/html; charset=UTF-8");
		PrintWriter out = response.getWriter();
		String changeName = request.getParameter("txtInputChangeName");
		String user = request.getParameter("user");
		MyPageDAO MPDAO = new MyPageDAO();
		boolean confirmChange = MPDAO.updateUserName(user, changeName);
		if(confirmChange) {
			out.print("<script>"
					+ "alert('입력하신 내용으로 이름이 변경되었습니다. 다시 로그인해주세요.');"
					+ "window.close();"
					+ "</script>");
		}else {
			out.print("<script>"
					+ "alert('이름 변경에 실패하였습니다. 다시 시도해주세요.');"
					+ "window.close();"
					+ "</script>");
		}
		
	}

}
