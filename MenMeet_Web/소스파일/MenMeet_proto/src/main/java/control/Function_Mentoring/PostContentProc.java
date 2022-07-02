package control.Function_Mentoring;

import java.io.IOException;
import java.sql.Timestamp;
import java.text.ParseException;
import java.text.SimpleDateFormat;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import DAO.MentoringListDAO;
import DTO.MentoringContentDTO;

@WebServlet("/PostContentProc")
public class PostContentProc extends HttpServlet {
	private static final long serialVersionUID = 1L;

	protected void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		request.setCharacterEncoding("UTF-8");
		MentoringListDAO MDAO = new MentoringListDAO();

//		sql 조회를 위한 처리
		String postUserName = request.getParameter("postName");
		String pDate = request.getParameter("postDate");
		//request에서 받아온 String형 값을 timestamp형으로 변환
		SimpleDateFormat fmt = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
		java.util.Date time = new java.util.Date();//long형으로 시간을 받기위해 초기화한 Date클래스
		try {//simpledateformat으로 문자를 날짜로 변환시 예외발생 처리
			time = fmt.parse(pDate);
		} catch (ParseException e) {
			e.printStackTrace();
		}
		Timestamp ts = new Timestamp(time.getTime());
//
		//DB에서 게시물 내용 정보를 받아 DTO객체에 담아줌
		MentoringContentDTO MCDTO = MDAO.getPostContent(postUserName, ts);
		//request에 담아서 넣어줌
		request.setAttribute("MCDTO", MCDTO);

		RequestDispatcher dispatcher = request.getRequestDispatcher("/Mentoring/Menmeet_Mentoring_ShowContent.jsp");
		dispatcher.forward(request, response);

	}

}
