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
import DTO.MentoringReservationDTO;
import DTO.UserDTO;

@WebServlet("/ReservationProc")
public class ReservationProc extends HttpServlet {
	private static final long serialVersionUID = 1L;
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		request.setCharacterEncoding("UTF-8");
		SimpleDateFormat fmt = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
		MentoringListDAO MDAO = new MentoringListDAO();
		MentoringReservationDTO MRDTO = new MentoringReservationDTO();
		HttpSession session = request.getSession();
		
//MRDTO에 예약정보를 담아주는 과정
		//게시글번호와 카테고리를 담아줌
		int postNum = Integer.parseInt(request.getParameter("mcNum"));
		int postCategory = Integer.parseInt(request.getParameter("mcCategory"));
		MRDTO.setPostNum(postNum);
		MRDTO.setCategory(postCategory);
		
		//문자형인 시간값을 담아주는 과정
		String MentoringTime = request.getParameter("mcReservationTime");
		java.util.Date time = new java.util.Date();//long형으로 시간을 받기위해 초기화한 Date클래스
		try {//simpledateformat으로 문자를 날짜로 변환시 예외발생 처리
			time = fmt.parse(MentoringTime);
		} catch (ParseException e) {
			e.printStackTrace();
		}
		MRDTO.setReservationTime(time);
		
		//멘토 멘티 id DTO객체에 담아줌
		UserDTO user = (UserDTO)session.getAttribute("USER");
		int who = Integer.parseInt(request.getParameter("mcWho"));
		//게시물의 작성자가 멘토일 경우
		if(who==0) {
			MRDTO.setMentoId(request.getParameter("mcWriter"));
			MRDTO.setMenteeId(user.getId());
		}
		//게시물의 작성자가 멘티일 경우
		else {
			MRDTO.setMentoId(user.getId());
			MRDTO.setMenteeId(request.getParameter("mcWriter"));
		}
//end MRDTO
		boolean enroll = MDAO.enrollReservation(MRDTO);

		response.setContentType("text/html; charset=UTF-8");
		PrintWriter out = response.getWriter();
		if(enroll) {
			out.print("<script>"
					+ "alert('멘토링 예약에 성공하였습니다.');"
					+ "window.close();"
					+ "</script>");
		}else {
			out.print("<script>"
					+ "alert('멘토링 예약에 실패하였습니다. 다시 시도해 주세요.');"
					+ "window.close();"
					+ "</script>");
			
		}
		
	}

}
