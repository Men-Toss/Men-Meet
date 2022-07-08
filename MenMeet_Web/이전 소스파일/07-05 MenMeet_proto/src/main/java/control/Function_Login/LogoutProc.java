package control.Function_Login;

import java.io.IOException;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

@WebServlet("/LogoutProc")
public class LogoutProc extends HttpServlet {

	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		request.setCharacterEncoding("UTF-8");
		response.setContentType("text/html;charset=UTF-8");
	
		RequestDispatcher dispatcher = request.getRequestDispatcher("/Menmeet_Main.jsp");
		//세션객체 생성
		HttpSession session = request.getSession();
		session.removeAttribute("USER");
		session.setAttribute("logout","true" );
		dispatcher.forward(request, response);
	}

}
