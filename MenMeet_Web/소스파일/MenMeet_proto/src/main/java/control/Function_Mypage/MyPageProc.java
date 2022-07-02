package control.Function_Mypage;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.Date;
import java.util.Vector;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import DAO.ReservationDAO;
import DTO.MyReservationDTO;
import DTO.UserDTO;

@WebServlet("/MyPageProc")
public class MyPageProc extends HttpServlet {
	private static final long serialVersionUID = 1L;

	protected void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		MypageProc(request, response);
	}

	protected void doPost(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		MypageProc(request, response);
	}

	protected void MypageProc(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		request.setCharacterEncoding("UTF-8");
		response.setContentType("text/html; charset=UTF-8");
		PrintWriter out = response.getWriter();
		RequestDispatcher dispatcher = request.getRequestDispatcher("/Mypage/Menmeet_Mypage.jsp");
		HttpSession session = request.getSession();
		UserDTO user = (UserDTO)session.getAttribute("USER");
		if(user == null) {
			out.print("<script>"
					+ "alert('로그인 후 이용하실 수 있습니다.');"
					+ "history.back();"
					+ "</script>");
		}else {
			ReservationDAO RDAO = new ReservationDAO();
			Vector<MyReservationDTO> VectorMRDTO = RDAO.getSearchUserReservation(user);
			
			request.setAttribute("MentoringInfo", VectorMRDTO);
			
			dispatcher.forward(request, response);
		}
	}
}
