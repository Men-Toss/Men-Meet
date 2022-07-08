package control.Function_Signup;

import java.io.IOException;
import java.net.URLEncoder;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import DAO.UserDAO;
import DTO.UserDTO;


@WebServlet("/SignupProc")
public class SignupProc extends HttpServlet {
	private static final long serialVersionUID = 1L;
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		request.setCharacterEncoding("UTF-8");
		
		UserDAO UDAO = new UserDAO();
		UserDTO inputUser = new UserDTO();
		inputUser.setId(request.getParameter("txtInputId").trim());
		inputUser.setPassword(request.getParameter("txtInputPassword").trim());
//		inputUser.setGrade(Integer.parseInt(request.getParameter("txtGrade")));
		inputUser.setName(request.getParameter("txtInputName").trim());
//		inputUser.setId(request.getParameter("txtImage"));
		
		boolean enrollConfirm = UDAO.enrollUser(inputUser);
		
		if(enrollConfirm) {
			RequestDispatcher dispatcher = request.getRequestDispatcher("/Menmeet_Main.jsp");
			request.setAttribute("signup", "OK");
			dispatcher.forward(request, response);
		}else {
			RequestDispatcher dispatcher = request.getRequestDispatcher("/Signup/Menmeet_Signup.jsp");
			request.setAttribute("msg", "회원 가입 실패, 다시 시도해주세요.");
			dispatcher.forward(request, response);
		}
	}

}
