package control.Function_Signup;

import java.io.IOException;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import DAO.UserDAO;

@WebServlet("/SignupCheckId")
public class SignupCheckId extends HttpServlet {

	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		request.setCharacterEncoding("UTF-8");
		response.setContentType("text/html;charset=UTF-8");
		UserDAO UDAO = new UserDAO();
		String userId = request.getParameter("txtInputId");
		RequestDispatcher dispatcher;
		
		//중복여부
		boolean duplication = UDAO.hasUserId(userId);
		
		
		if(duplication) {
			dispatcher = request.getRequestDispatcher("/Signup/Menmeet_Signup.jsp?IdIs=이미 존재하는 아이디입니다.&DuplicationId=true");
			dispatcher.forward(request, response);
		}else {
			dispatcher = request.getRequestDispatcher("/Signup/Menmeet_Signup.jsp?IdIs=사용가능한 아이디입니다.&DuplicationId=false");
			dispatcher.forward(request, response);
		}
	}

}
