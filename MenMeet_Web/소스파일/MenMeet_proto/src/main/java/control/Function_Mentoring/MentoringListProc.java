package control.Function_Mentoring;

import java.io.IOException;
import java.util.Vector;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import DAO.MentoringListDAO;
import DTO.MentoringListDTO;

@WebServlet("/MentoringListProc")
public class MentoringListProc extends HttpServlet {
	private static final long serialVersionUID = 1L;

	protected void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		listProc(request, response);
	}

	protected void doPost(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		listProc(request, response);
	}

	protected void listProc(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		// 한글 설정
		request.setCharacterEncoding("UTF-8");
		response.setContentType("text/html;charset=UTF-8");
		MentoringListDAO MLDAO = new MentoringListDAO();
		HttpSession session = request.getSession();
		//카테고리 리스트가 없으면 생성해서 넣어줌
		if(session.getAttribute("categoryList")==null) {
		String[] categoryList = new String[5];
		categoryList[0] = "전공";
		categoryList[1] = "진로";
		categoryList[2] = "연애";
		categoryList[3] = "학교생활";
		categoryList[4] = "기타";
		session.setAttribute("categoryList", categoryList);
		}

		// 멘토-티 종류와 카테고리 값이 없을 경우 첫 멘토링페이지로 온 것으로 판단
		if (request.getParameter("mentoringWho") == null || request.getParameter("mentoringCategory") == null) {
			//디폴트 멘토링종류, 카테고리 설정
			// mentoringWho [0-멘토, 1-멘티]
			//mentoringCategory [0-전공, 1-진로, 2-연애, 3-학교생활, 4-기타]
			request.setAttribute("mentoringWho", 0);
			request.setAttribute("mentoringCategory", 0);
			//전체 게시물수
			int totalPosts = MLDAO.getMentoringListCount(0, 0);
			
			//10개씩 묶여진 페이지 카운트 설정 
			int pageCount = 0;
			
			//게시물이 0개 일때
			if (totalPosts == 0) {
				pageCount = 1;
			} 
			//게시물이 있을 때
			else {
				if (totalPosts % 10 == 0) {
					pageCount = totalPosts / 10;
				} else {
					pageCount = totalPosts / 10 + 1;
				}
			}
			//현재 페이지넘버
			int currentPage = 1;
			//해당 페이지 게시물 시작-끝
			int endPostNum = totalPosts;
			int startPostNum = endPostNum-9;
			//DB에서 값을 담아온 Vector객체
			Vector<MentoringListDTO> MentoringList = MLDAO.getMentoringList(0, 0, startPostNum, endPostNum);
			
			request.setAttribute("endPostNum", endPostNum);
			request.setAttribute("pageCount", pageCount);
			request.setAttribute("currentPage", currentPage);
			request.setAttribute("MentoringList", MentoringList);

		}//end of Main if
		//기존 멘토링페이지에서 요청이 왔을 경우
		else {
			//기존 페이지에서 보낸 정보
			int mentoringWho = Integer.parseInt(request.getParameter("mentoringWho"));
			int mentoringCategory = Integer.parseInt(request.getParameter("mentoringCategory"));
			int currentPage = Integer.parseInt(request.getParameter("currentPage"));
			int endPostNum = Integer.parseInt(request.getParameter("endPostNum"));
			//전체 게시물수
			int totalPosts = MLDAO.getMentoringListCount(mentoringWho, mentoringCategory);
			//카테고리가 바뀌면 endPostNum을 0을 리턴하게 했으므로 0이면 해당하는 조건의 전체 갯수를 받아옴
			if(endPostNum==0) {
				endPostNum = totalPosts;
			}
			if(currentPage==0) {
				currentPage=1;
			}
			
			int startNum = endPostNum - 9;
			
			//10개씩 묶여진 페이지 카운트 설정 
			int pageCount = 0;
			//게시물이 0개 일때
			if (totalPosts == 0) {
				pageCount = 1;
			} 
			//게시물이 있을 때
			else {
				if (totalPosts % 10 == 0) {
					pageCount = totalPosts / 10;
				} else {
					pageCount = totalPosts / 10 + 1;
				}
			}
			
			Vector<MentoringListDTO> MentoringList = MLDAO.getMentoringList(mentoringWho, mentoringCategory, startNum, endPostNum);

			request.setAttribute("mentoringWho", mentoringWho);
			request.setAttribute("mentoringCategory", mentoringCategory);
			request.setAttribute("pageCount", pageCount);
			request.setAttribute("endPostNum", endPostNum);
			request.setAttribute("currentPage", currentPage);
			request.setAttribute("MentoringList", MentoringList);
		}//end of Main else

		//if/else문 수행후 입력된 정보를 넘겨줌
		RequestDispatcher dispatcher = request.getRequestDispatcher("/Mentoring/Menmeet_Mentoring.jsp");
		dispatcher.forward(request, response);
	}

}