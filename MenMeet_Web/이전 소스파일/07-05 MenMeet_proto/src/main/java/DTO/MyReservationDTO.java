package DTO;

import java.util.Date;

public class MyReservationDTO {
	private String title;
	private String mento;
	private String mentee;
	private Date reservationTime;
	public String getTitle() {
		return title;
	}
	public void setTitle(String title) {
		this.title = title;
	}
	public String getMento() {
		return mento;
	}
	public void setMento(String mento) {
		this.mento = mento;
	}
	public String getMentee() {
		return mentee;
	}
	public void setMentee(String mentee) {
		this.mentee = mentee;
	}
	public Date getReservationTime() {
		return reservationTime;
	}
	public void setReservationTime(Date reservationTime) {
		this.reservationTime = reservationTime;
	}
	
	
}
