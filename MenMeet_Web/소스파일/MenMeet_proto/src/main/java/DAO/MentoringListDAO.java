package DAO;

import java.sql.Connection;
import java.sql.Date;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.Timestamp;
import java.text.SimpleDateFormat;
import java.util.Vector;

import DTO.MentoringContentDTO;
import DTO.MentoringListDTO;
import DTO.MentoringPostDTO;
import DTO.MentoringReservationDTO;

public class MentoringListDAO {
	Connection connection;
	PreparedStatement statement;
	ResultSet resultset;

	public void getCon() {
		try {
			Class.forName("com.mysql.jdbc.Driver");
			connection = DriverManager.getConnection(
					"jdbc:mysql://mentoss123.cafe24.com/mentoss123?useUnicode=true&characterEncoding=UTF-8",
					"mentoss123", "menmeet456");
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	public int getMentoringListCount(int who, int category) {
		int count = 0;
		String sql = "select count(*) from " + "(select * from Mentoring_Table "
				+ "where Mentoring_Who = ? and Mentoring_Category = ?)searchedList";
		try {
			getCon();
			statement = connection.prepareStatement(sql);
			statement.setInt(1, who);
			statement.setInt(2, category);
			resultset = statement.executeQuery();
			if (resultset.next()) {
				count = resultset.getInt(1);
			}
			statement.close();
			connection.close();
		} catch (Exception e) {
			e.printStackTrace();
		}

		return count;
	}

	public void enrollMentoringPost(MentoringPostDTO post) {
		try {
			getCon();
			String sql = "insert into Mentoring_Table("
					+ "Mentoring_User_ID, Mentoring_Category, Mentoring_Explanation, Mentoring_Title, Mentoring_Time, Mentoring_Who, Mentoring_ReservationTime) "
					+ "values(?,?,?,?,?,?,?);";
			statement = connection.prepareStatement(sql);
			statement.setString(1, post.getId());
			statement.setInt(2, post.getCategory());
			statement.setString(3, post.getExplanation());
			statement.setString(4, post.getTitle());
			statement.setTimestamp(5, new Timestamp(post.getCurrentTime().getTime()));
			statement.setInt(6, post.getWho());
			statement.setTimestamp(7, new Timestamp(post.getReservationTime().getTime()));

			statement.executeUpdate();
			statement.close();
			connection.close();
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	public Vector<MentoringListDTO> getMentoringList(int who, int category, int startNum, int endNum) {
		Vector<MentoringListDTO> mentoringList = new Vector<>();
		String sql = "select  Mentoring_Time, Mentoring_Title, User_Name " + "from"
				+ "(select @ROWNUM:=@ROWNUM+1 as NUM, searchedList.* " + "from " + "(select * from Mentoring_Table "
				/* who, category */ + "where Mentoring_Who = ? and Mentoring_Category = ?)searchedList "
				+ " , (select @ROWNUM:=0) rownum " + "order by Mentoring_Number asc " + ")numberedList "
				+ "            ,User_Table " + "where  Mentoring_User_ID = User_ID "
				/* 첫번째게시물, 마지막게시물 */ + "and NUM >= ? and NUM <= ? " + "order by  NUM desc";
		try {
			getCon();
			statement = connection.prepareStatement(sql);
			statement.setInt(1, who);
			statement.setInt(2, category);
			statement.setInt(3, startNum);
			statement.setInt(4, endNum);

			resultset = statement.executeQuery();
			while (resultset.next()) {
				MentoringListDTO MDTO = new MentoringListDTO();
				long time = resultset.getTimestamp(1).getTime();
				MDTO.setDate(new java.util.Date(time));
				MDTO.setTitle(resultset.getString(2));
				MDTO.setUserName(resultset.getString(3));
				mentoringList.add(MDTO);
			}
			statement.close();
			connection.close();
		} catch (Exception e) {
			e.printStackTrace();
		}
		return mentoringList;
	}

	public MentoringContentDTO getPostContent(String postUserName, Timestamp postDate) {
		MentoringContentDTO MCDTO = new MentoringContentDTO();
		String sql = "select Mentoring_Number, Mentoring_User_ID, Mentoring_Who, Mentoring_Category, Mentoring_Title, Mentoring_Explanation, Mentoring_ReservationTime "
				+ " from Mentoring_Table join User_Table on Mentoring_Table.Mentoring_User_ID = User_Table.User_ID"
				+ " where Mentoring_Time=? and User_Name=?";
		try {
			getCon();
			statement = connection.prepareStatement(sql);
			statement.setTimestamp(1, postDate);
			statement.setString(2, postUserName);

			resultset = statement.executeQuery();

			if (resultset.next()) {
				MCDTO.setNum(resultset.getInt(1));
				MCDTO.setWriter(resultset.getString(2));
				MCDTO.setWho(resultset.getInt(3));
				MCDTO.setCategory(resultset.getInt(4));
				MCDTO.setTitle(resultset.getString(5));
				MCDTO.setContent(resultset.getString(6));
				MCDTO.setReserveTime(new java.util.Date(resultset.getTimestamp(7).getTime()));

			}
			statement.close();
			connection.close();
		} catch (Exception e) {
			e.printStackTrace();
			MCDTO.setTitle(e.getMessage());
		}
		return MCDTO;
	}


	
	public boolean enrollReservation(MentoringReservationDTO mrdto) {
		String sql = "insert into Reservation_Table"
				+ " (Reservation_Mento_ID, Reservation_Mentee_ID, Reservation_Time, Reservation_Category, Reservation_PostNumber)"
				+ " values ( ? , ? , ? , ? , ? );";

		try {
			getCon();
			statement = connection.prepareStatement(sql);
			statement.setString(1, mrdto.getMentoId());
			statement.setString(2, mrdto.getMenteeId());
			statement.setTimestamp(3, new Timestamp(mrdto.getReservationTime().getTime()));
			statement.setInt(4, mrdto.getCategory());
			statement.setInt(5, mrdto.getPostNum());
			statement.executeUpdate();
			statement.close();
			connection.close();
		} catch (Exception e) {
			e.printStackTrace();
			return false;
		}
		return true;
	}

}// endDAO
