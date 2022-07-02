package DAO;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.util.Vector;

import DTO.MyReservationDTO;
import DTO.UserDTO;

public class ReservationDAO {
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
	
	
	public Vector<MyReservationDTO> getSearchUserReservation(UserDTO user) {
		Vector<MyReservationDTO> v = new Vector<>();
		String sql = "select Mentoring_Title, Reservation_Mento_ID, Reservation_Mentee_ID, Reservation_Time"
				+ " from Reservation_Table join Mentoring_Table on Reservation_PostNumber = Mentoring_Number"
				+ " where Reservation_Mento_ID = ? or Reservation_Mentee_ID = ? ";
		try {
			getCon();
			statement = connection.prepareStatement(sql);
			statement.setString(1, user.getId());
			statement.setString(2, user.getId());
			resultset = statement.executeQuery();
			while(resultset.next()) {
				MyReservationDTO MRDTO = new MyReservationDTO();
				MRDTO.setTitle(resultset.getString(1));
				MRDTO.setMento(resultset.getString(2));
				MRDTO.setMentee(resultset.getString(3));
				MRDTO.setReservationTime(new java.util.Date(resultset.getTimestamp(4).getTime()));
				v.add(MRDTO);
			}
			statement.close();
			connection.close();
		} catch (Exception e) {
			e.printStackTrace();
		}
		
		return v;
	}
	
}
