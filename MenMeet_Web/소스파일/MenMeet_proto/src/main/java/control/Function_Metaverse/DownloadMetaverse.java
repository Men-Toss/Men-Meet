package control.Function_Metaverse;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 * Servlet implementation class DownloadMetaverse
 */
@WebServlet("/DownloadMetaverse")
public class DownloadMetaverse extends HttpServlet {
	protected void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		request.setCharacterEncoding("UTF-8");
		response.setContentType("text/html; charset=UTF-8");
		// 파일 경로
		String root = request.getSession().getServletContext().getRealPath("/");
		String DownloadFile = root + "Download";
		// 서버의 파일명
		String fileName = "MetaversePlatform.exe";

		// 사용자가 받을 파일명
		String downloadName = "MetaversePlatform.exe";

		InputStream inPut = null;
		OutputStream outPut = null;
		File file = null;
		boolean skip = false;
		String client = "";

		try {
			try {
				// 파일 위치와 파일명을 파일객체에 담음
				file = new File(DownloadFile, fileName);
				// 해당 파일 객체를 inputStream에 넣어줌
				inPut = new FileInputStream(file);

			} catch (FileNotFoundException e) {
				skip = true;
			}

			client = request.getHeader("User-Agent");
			
			//파일 다운로드 헤더 지정
			response.reset();
			response.setContentType("application/octet-stream");
			response.setHeader("Content-Description", "");
			
			if(!skip) {
				//IE
				if(client.indexOf("MSIE")!= -1) {
					response.setHeader("Content-Disposition", 
							"attachment; fileName="+
							new String(downloadName.getBytes("KSC5601"),"ISO8859_1"));
				}else {
					downloadName = new String(downloadName.getBytes("UTF-8"),"iso-8859-1");
					response.setHeader("Content-Disposition", "attachment; fileName=\""
										+downloadName+"\"");
					response.setHeader("Content-Type", "application/octet-stream; charset=UTF-8");
				}
				
				response.setHeader("Content-Length", ""+file.length());
				
				outPut = response.getOutputStream();
				byte b[] = new byte[(int)file.length()];
				int leng =0;
				
				while((leng=inPut.read(b))>0) {
					outPut.write(b,0,leng);
				}
			}else {
				response.setContentType("text/html;charset=UTF-8");
				response.sendRedirect("/Metaverse/Menmeet_Metaverse.jsp");
			}
			inPut.close();
			outPut.close();
		} catch (Exception e) {
			e.printStackTrace();
		}

	}
}
