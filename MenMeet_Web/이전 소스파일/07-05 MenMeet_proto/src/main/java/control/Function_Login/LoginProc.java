package control.Function_Login;

import java.io.IOException;
import java.net.URLEncoder;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import DAO.UserDAO;
import DTO.UserDTO;
@WebServlet("/LoginProc")
public class LoginProc extends HttpServlet {
	
	//post방식으로만 처리
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		//한글 설정
		request.setCharacterEncoding("UTF-8");
		response.setContentType("text/html;charset=UTF-8");
		
		//입력한 id, password를 String변수로 담아줌
		String userId = request.getParameter("txtId");
		String userPassword = request.getParameter("txtPassword");
		
		UserDAO UDAO = new UserDAO();
		UserDTO user;
		
		//UserDTO객체에 입력한 id에 해당하는 정보를 가져옴
		user = UDAO.getOneUserInfo(userId);
		//해당 id의 비밀번호가 같다면 로그인 처리
		if(userPassword.equals(user.getPassword())) {
			//회원정보일치시 메인페이지로 이동할 디스페쳐 생성
			RequestDispatcher dispatcher = request.getRequestDispatcher("/Menmeet_Main.jsp");
			//세션객체 생성
			HttpSession session = request.getSession();
			//세션에 해당 아이디 값과 해당 아이디의 DTO변수를 키와 값으로 세션에 넣어줌
			session.setAttribute("USER", user);
			dispatcher.forward(request, response);
		}
		else {
			String msg= URLEncoder.encode("일치하는 회원정보가 없습니다.",java.nio.charset.StandardCharsets.UTF_8.toString());
			response.sendRedirect("/Login/Menmeet_Login.jsp?msg="+msg);
		}
	}

}
