package control.Function_Signup;

import java.io.IOException;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import DAO.UserDAO;

@WebServlet("/SignupCheckName")
public class SignupCheckName extends HttpServlet {
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		request.setCharacterEncoding("UTF-8");
		response.setContentType("text/html;charset=UTF-8");
		UserDAO UDAO = new UserDAO();
		String userName = request.getParameter("txtInputName");
		RequestDispatcher dispatcher ;
		
		//중복여부
		boolean duplication = UDAO.hasUserName(userName);
		
		
		if(duplication) {
			dispatcher= request.getRequestDispatcher("/Signup/Menmeet_Signup.jsp?NameIs=이미 존재하는 이름입니다.&DuplicationName=true");
			dispatcher.forward(request, response);
		}else {
			dispatcher= request.getRequestDispatcher("/Signup/Menmeet_Signup.jsp?NameIs=사용가능한 이름입니다.&DuplicationName=false");
			dispatcher.forward(request, response);
		}
	}

}

