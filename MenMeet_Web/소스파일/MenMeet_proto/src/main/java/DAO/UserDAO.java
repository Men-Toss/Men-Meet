package DAO;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;

import DTO.UserDTO;

public class UserDAO {
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

	// 해당 id에 해당하는 사용자 데이터를 반환하는 메서드
	public UserDTO getOneUserInfo(String id) {
		// 데이터를 담아서 반환할 DTO객체 생성
		UserDTO user = new UserDTO();

		// User_Table에 해당 id 튜플을 받아오는 sql문
		String sql = "select * from User_Table where User_ID = ?";

		try {
			getCon();
			statement = connection.prepareStatement(sql);
			statement.setString(1, id);
			resultset = statement.executeQuery();
			// select문으로 받은 유저 데이터를 DTO객체에 저장
			while (resultset.next()) {
				user.setId(resultset.getString(1));
				user.setPassword(resultset.getString(2));
				user.setGrade(resultset.getInt(3));
				user.setName(resultset.getString(4));
				user.setImage(resultset.getString(5));
			}
			// 커넥션 연결종료
			connection.close();
		} catch (Exception e) {
			e.printStackTrace();
		}
		// 데이터를 담은 DTO객체 반환
		return user;
	}// end getOneUserInfo

	//해당 ID가 DB에 있는지 조회하는 메서드
	public boolean hasUserId(String id) {
		//해당하는 이름이 있는지 반환해주는 변수
		boolean result=false;
		try {
			getCon();
			String sql = "select User_ID from User_Table where User_ID=?";
			statement = connection.prepareStatement(sql);
			statement.setString(1, id);
			resultset = statement.executeQuery();
			if (resultset.next()) {
				result = true;
			} else {
				result = false;
			}
			connection.close();
		} catch (Exception e) {
			e.printStackTrace();
		}
		return result;
	}
	
	//해당 이름이 DB에 있는지 조회하는 메서드
	public boolean hasUserName(String name) {
		//해당하는 이름이 있는지 반환해주는 변수
		boolean result=false;
		try {
			getCon();
			String sql = "select User_ID from User_Table where User_Name=?";
			statement = connection.prepareStatement(sql);
			statement.setString(1, name);
			resultset = statement.executeQuery();
			//해당하는 이름이 있을 경우 true리턴
			if (resultset.next()) {
				result = true;
			} 
			//없을 경우 false리턴
			else {
				result = false;
			}
			connection.close();
		} catch (Exception e) {
			e.printStackTrace();
		}
		return result;
	}

	public boolean enrollUser(UserDTO user) {
		//id나 이름이 중복될 경우 false리턴  해당 정보를 등록하지 않음
		if(hasUserId(user.getId())||hasUserName(user.getName())) {
			return false;
		}
		
		try {
			getCon();
			String insertSql = "insert into User_Table values(?,?,?,?,?)";
			statement = connection.prepareStatement(insertSql);
			statement.setString(1, user.getId());
			statement.setString(2, user.getPassword());
			statement.setInt(3, user.getGrade());
			statement.setString(4, user.getName());
			statement.setString(5, user.getImage());
			statement.executeUpdate();
			connection.close();
		} catch (Exception e) {
			e.printStackTrace();
		}
		return true;
	}
	
	
	
}
