package control.Function_Mentoring;

import java.io.IOException;
import java.io.PrintWriter;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import DAO.MentoringListDAO;
import DTO.MentoringPostDTO;
import DTO.UserDTO;

@WebServlet("/MentoringProc")
public class MentoringProc extends HttpServlet {
	private static final long serialVersionUID = 1L;
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		ReserveProc(request, response);
	}
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		ReserveProc(request, response);
	}
	protected void ReserveProc(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		request.setCharacterEncoding("UTF-8");
		MentoringListDAO MDAO = new MentoringListDAO();
		SimpleDateFormat fmt = new SimpleDateFormat("yyyy-MM-dd HH:mm");
		HttpSession session = request.getSession();
		UserDTO user =(UserDTO)session.getAttribute("USER");
		//작성한 멘토링 게시물 정보를 변수에 저장
		
		int mentoringWho = Integer.parseInt(request.getParameter("mentoringWho"));
		int mentoringCategory = Integer.parseInt(request.getParameter("mentoringCategory"));
		String mentoring_User = user.getId();
		String mentoring_Title = request.getParameter("Mentoring_Title");
		String mentoring_Explanation = request.getParameter("mentoring_Explanation");
		
		String mentoring_Day = request.getParameter("mentoringDay");
		String mentoring_Time = request.getParameter("mentoringTime");
		String mentoring_DayTime = mentoring_Day+" "+mentoring_Time;
		
		Date mentoring_ReservationTime = new Date(0);
		try {
			mentoring_ReservationTime = fmt.parse(mentoring_DayTime);
		}catch(ParseException e) {
			e.printStackTrace();
		}
		
		
		//현재 게시물 작성시간을 등록
		Date currentTime = new Date(System.currentTimeMillis());
		
		
		
		//게시물DTO객체에 값을 담아줌
		MentoringPostDTO MPDTO = new MentoringPostDTO();
		MPDTO.setId(mentoring_User);
		MPDTO.setCategory(mentoringCategory);
		MPDTO.setExplanation(mentoring_Explanation);
		MPDTO.setTitle(mentoring_Title);
		MPDTO.setCurrentTime(currentTime);
		MPDTO.setWho(mentoringWho);
		MPDTO.setReservationTime(mentoring_ReservationTime);
		//DB에 해당 게시물을 저장
		MDAO.enrollMentoringPost(MPDTO);
		//게시물 등록완료시 알림을 띄워주고 종료
		response.setContentType("text/html; charset=UTF-8");
		PrintWriter out = response.getWriter();
		out.print("<script>"
				+ "alert('게시물이 등록되었습니다.');"
				+ "window.close();"
				+ "</script>");
	
		
	}

}
