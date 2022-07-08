package DAO;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.Timestamp;

import DTO.UserDTO;

public class MyPageDAO {
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
	
	public boolean updateUserName(String userId, String newName) {
		String sql = "UPDATE User_Table SET User_Name = ? WHERE User_ID = ?";
		try {
			getCon();
			statement = connection.prepareStatement(sql);
			statement.setString(1, newName);
			statement.setString(2, userId);
			statement.executeUpdate();
			statement.close();
			connection.close();
		} catch (Exception e) {
			e.printStackTrace();
			return false;
		}
		return true;
	}
	
	public boolean updateUserPassword(String userId, String userPassword, String changePassword) {
		String sql = "update User_Table set User_PW = ? where User_ID = ? and User_PW = ?";
		try {
			getCon();
			statement = connection.prepareStatement(sql);
			statement.setString(1, changePassword);
			statement.setString(2, userId);
			statement.setString(3, userPassword);
			statement.executeUpdate();
			statement.close();
			connection.close();
		} catch (Exception e) {
			e.printStackTrace();
			return false;
		}
		return true;
	}
	
	
	public boolean deleteReservation(String postMento, String postMentee, java.util.Date postDate) {
		String sql ="delete from Reservation_Table where Reservation_Mento_ID= ? and Reservation_Mentee_ID = ? and  Reservation_Time =?";
		try {
			getCon();
			statement = connection.prepareStatement(sql);
			statement.setString(1, postMento);
			statement.setString(2, postMentee);
			Timestamp ts = new Timestamp(postDate.getTime());
			statement.setTimestamp(3, ts);
			statement.executeUpdate();
			statement.close();
			connection.close();
		} catch (Exception e) {
			e.printStackTrace();
			return false;
		}
		
		return true;
	}
}
