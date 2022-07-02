package DTO;

import java.util.Date;

public class MentoringReservationDTO {
	private String MentoId;
	private String MenteeId;
	private Date ReservationTime;
	private int Category;
	private int PostNum;
	public String getMentoId() {
		return MentoId;
	}
	public void setMentoId(String mentoId) {
		MentoId = mentoId;
	}
	public String getMenteeId() {
		return MenteeId;
	}
	public void setMenteeId(String menteeId) {
		MenteeId = menteeId;
	}
	public Date getReservationTime() {
		return ReservationTime;
	}
	public void setReservationTime(Date reservationTime) {
		ReservationTime = reservationTime;
	}
	public int getCategory() {
		return Category;
	}
	public void setCategory(int category) {
		Category = category;
	}
	public int getPostNum() {
		return PostNum;
	}
	public void setPostNum(int postNum) {
		PostNum = postNum;
	}
	
	
}
