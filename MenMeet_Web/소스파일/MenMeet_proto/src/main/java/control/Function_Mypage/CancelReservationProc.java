package control.Function_Mypage;

import java.io.IOException;
import java.io.PrintWriter;
import java.text.ParseException;
import java.text.SimpleDateFormat;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import DAO.MyPageDAO;
@WebServlet("/CancelReservationProc")
public class CancelReservationProc extends HttpServlet {
	private static final long serialVersionUID = 1L;
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		CancelReservation(request, response);
	}
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		CancelReservation(request, response);
	}
	protected void CancelReservation(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		request.setCharacterEncoding("UTF-8");
		response.setContentType("text/html; charset=UTF-8");
		PrintWriter out = response.getWriter();
		SimpleDateFormat fmt = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
		String postMento = request.getParameter("mento");
		String postMentee = request.getParameter("mentee");
		String postDate = request.getParameter("reservationTime");
		java.util.Date time = new java.util.Date();//long형으로 시간을 받기위해 초기화한 Date클래스
		try {
			time = fmt.parse(postDate);
		} catch (ParseException e) {
			e.printStackTrace();
		}
		
		MyPageDAO MPDAO = new MyPageDAO();
		boolean confirmReservationDelete = MPDAO.deleteReservation(postMento, postMentee, time);
		if(confirmReservationDelete) {
			out.print("<script>"
					+ "alert('예약을 취소하였습니다.');"
					+ "history.go(-1);"
					+ "</script>");
		}else {
			out.print("<script>"
					+ "alert('예약 취소를 실패하였습니다. 다시 시도해주세요.');"
					+ "history.go(-1);"
					+ "</script>");
		}
	}
}
