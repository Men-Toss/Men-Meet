package DTO;

import java.util.Date;

public class MentoringContentDTO {
	private int Num;
	private int Who;
	private  int Category;
	private String Writer;
	private String Title;
	private String Content;
	private Date ReserveTime;
	
	public int getNum() {
		return Num;
	}
	public void setNum(int num) {
		Num = num;
	}
	public int getWho() {
		return Who;
	}
	public void setWho(int who) {
		Who = who;
	}
	public int getCategory() {
		return Category;
	}
	public void setCategory(int category) {
		Category = category;
	}
	public String getWriter() {
		return Writer;
	}
	public void setWriter(String user) {
		Writer = user;
	}
	public String getTitle() {
		return Title;
	}
	public void setTitle(String title) {
		Title = title;
	}
	public String getContent() {
		return Content;
	}
	public void setContent(String content) {
		Content = content;
	}
	public Date getReserveTime() {
		return ReserveTime;
	}
	public void setReserveTime(Date reserveTime) {
		ReserveTime = reserveTime;
	}
	
}
