-- ************************************** `Men_Meet_Schema`.`Location_Table`

CREATE TABLE `Men_Meet_Schema`.`Location_Table`
(
 `Location_User_ID`  varchar(20) NOT NULL ,
 `Location_Place1`   bit NOT NULL ,
 `Location_Place2`   bit NOT NULL ,
 `Location_Place3`   bit NOT NULL ,
 `Location_Place4`   bit NOT NULL ,
 `Location_Place5`   bit NOT NULL ,
 `Location_Place6`   bit NOT NULL ,
 `Location_Place7`   bit NOT NULL ,
 `Location_Place8`   bit NOT NULL ,
 `Location_Place9`   bit NOT NULL ,
 `Location_Place10`  bit NOT NULL ,
 `Location_LastUser` varchar(100) NOT NULL ,

PRIMARY KEY (`Location_User_ID`),
KEY `FK_154` (`Location_User_ID`),
CONSTRAINT `FK_User_Location` FOREIGN KEY `FK_154` (`Location_User_ID`) REFERENCES `Men_Meet_Schema`.`User_Table` (`User_ID`)
);


-- ************************************** `Men_Meet_Schema`.`Manager_Table`

CREATE TABLE `Men_Meet_Schema`.`Manager_Table`
(
 `Manager_ID`    varchar(20) NOT NULL ,
 `Manager_PW`    varchar(20) NOT NULL ,
 `Manager_Name`  varchar(15) NOT NULL ,
 `Manager_Image` varchar(100) NOT NULL ,

PRIMARY KEY (`Manager_ID`)
);



-- ************************************** `Men_Meet_Schema`.`Menti_Table`

CREATE TABLE `Men_Meet_Schema`.`Menti_Table`
(
 `Menti_User_ID`     varchar(20) NOT NULL ,
 `Menti_Number`      int NOT NULL AUTO_INCREMENT ,
 `Menti_Category`    varchar(20) NOT NULL ,
 `Menti_Explanation` varchar(300) NULL ,
 `Menti_Title`       varchar(20) NOT NULL ,

PRIMARY KEY (`Menti_User_ID`, `Menti_Number`),
KEY `FK_48` (`Menti_User_ID`),
CONSTRAINT `FK_USER_MENTI` FOREIGN KEY `FK_48` (`Menti_User_ID`) REFERENCES `Men_Meet_Schema`.`User_Table` (`User_ID`)
);




-- ************************************** `Men_Meet_Schema`.`Mento_Table`

CREATE TABLE `Men_Meet_Schema`.`Mento_Table`
(
 `Mento_User_ID`     varchar(20) NOT NULL ,
 `Mento_Number`      int NOT NULL AUTO_INCREMENT ,
 `Mento_Category`    varchar(20) NOT NULL ,
 `Mento_Explanation` varchar(300) NULL ,
 `Mento_Title`       varchar(20) NOT NULL ,

PRIMARY KEY (`Mento_User_ID`, `Mento_Number`),
KEY `FK_35` (`Mento_User_ID`),
CONSTRAINT `FK_User_Mento` FOREIGN KEY `FK_35` (`Mento_User_ID`) REFERENCES `Men_Meet_Schema`.`User_Table` (`User_ID`)
);



-- ************************************** `Men_Meet_Schema`.`QnA_Table`

CREATE TABLE `Men_Meet_Schema`.`QnA_Table`
(
 `QnA_User_ID`           varchar(20) NOT NULL ,
 `QnA_Post_Number`       bigint NOT NULL AUTO_INCREMENT ,
 `QnA_Manager_ID`        varchar(20) NULL ,
 `QnA_Question_Title`    varchar(50) NOT NULL ,
 `QnA_Question_Contents` varchar(300) NULL ,
 `QnA_Answer_Contents`   varchar(300) NOT NULL ,
 `QnA_PW`                varchar(10) NOT NULL ,
 `QnA_Is_Secret`         tinyint NOT NULL ,
 `QnA_Category`          tinyint NOT NULL ,

PRIMARY KEY (`QnA_User_ID`, `QnA_Post_Number`),
KEY `FK_149` (`QnA_Manager_ID`),
CONSTRAINT `FK_Mnager_QnA` FOREIGN KEY `FK_149` (`QnA_Manager_ID`) REFERENCES `Men_Meet_Schema`.`Manager_Table` (`Manager_ID`),
KEY `FK_65` (`QnA_User_ID`),
CONSTRAINT `FK_User_QnA` FOREIGN KEY `FK_65` (`QnA_User_ID`) REFERENCES `Men_Meet_Schema`.`User_Table` (`User_ID`)
);



-- ************************************** `Men_Meet_Schema`.`Reservation_Table`

CREATE TABLE `Men_Meet_Schema`.`Reservation_Table`
(
 `Reservation_Number`    int NOT NULL AUTO_INCREMENT ,
 `Reservation_Mento_ID`  varchar(20) NOT NULL ,
 `Reservation_Menti_ID`  varchar(20) NOT NULL ,
 `Reservation_StartTime` datetime NOT NULL ,
 `Reservation_EndTime`   datetime NOT NULL ,
 `Reservation_Place`     varchar(45) NOT NULL ,
 `Reservation_Category`  varchar(20) NOT NULL ,

PRIMARY KEY (`Reservation_Number`, `Reservation_Mento_ID`, `Reservation_Menti_ID`),
KEY `FK_182` (`Reservation_Mento_ID`),
CONSTRAINT `FK_User_Reservation_Mento` FOREIGN KEY `FK_182` (`Reservation_Mento_ID`) REFERENCES `Men_Meet_Schema`.`User_Table` (`User_ID`),
KEY `FK_186` (`Reservation_Menti_ID`),
CONSTRAINT `FK_User_Reservation_Menti` FOREIGN KEY `FK_186` (`Reservation_Menti_ID`) REFERENCES `Men_Meet_Schema`.`User_Table` (`User_ID`)
);


-- ************************************** `Men_Meet_Schema`.`Review_Table`

CREATE TABLE `Men_Meet_Schema`.`Review_Table`
(
 `Review_Number`             integer unsigned NOT NULL AUTO_INCREMENT ,
 `Review_Reservation_Number` int NOT NULL ,
 `Review_Mento_ID`           varchar(20) NOT NULL ,
 `Review_Menti_ID`           varchar(20) NOT NULL ,
 `Review_Score`              tinyint unsigned NOT NULL ,
 `Review_Contents`           varchar(300) NULL ,

PRIMARY KEY (`Review_Number`, `Review_Reservation_Number`, `Review_Mento_ID`, `Review_Menti_ID`),
KEY `FK_125` (`Review_Reservation_Number`, `Review_Mento_ID`, `Review_Menti_ID`),
CONSTRAINT `FK_Reservation_Review` FOREIGN KEY `FK_125` (`Review_Reservation_Number`, `Review_Mento_ID`, `Review_Menti_ID`) REFERENCES `Men_Meet_Schema`.`Reservation_Table` (`Reservation_Number`, `Reservation_Mento_ID`, `Reservation_Menti_ID`)
);



-- ************************************** `Men_Meet_Schema`.`School_Table`

CREATE TABLE `Men_Meet_Schema`.`School_Table`
(
 `School_Department`           varchar(45) NOT NULL ,
 `School_Department_Introduce` varchar(1000) NOT NULL ,

PRIMARY KEY (`School_Department`)
);




-- ************************************** `Men_Meet_Schema`.`User_Char_Table`

CREATE TABLE `Men_Meet_Schema`.`User_Char_Table`
(
 `User_Char_User_ID` varchar(20) NOT NULL ,
 `User_Char_Hat`     int NOT NULL ,
 `User_Char_Eyes`    int NOT NULL ,
 `User_Char_Face`    int NOT NULL ,
 `User_Char_Color`   varchar(20) NOT NULL ,
 `User_Char_Size`    int NOT NULL ,

PRIMARY KEY (`User_Char_User_ID`),
KEY `FK_130` (`User_Char_User_ID`),
CONSTRAINT `FK_User_User_Char` FOREIGN KEY `FK_130` (`User_Char_User_ID`) REFERENCES `Men_Meet_Schema`.`User_Table` (`User_ID`)
);



-- ************************************** `Men_Meet_Schema`.`User_Table`

CREATE TABLE `Men_Meet_Schema`.`User_Table`
(
 `User_ID`    varchar(20) NOT NULL ,
 `User_PW`    varchar(20) NOT NULL ,
 `User_Grade` tinyint NULL ,
 `User_Name`  varchar(15) NOT NULL ,
 `User_Image` varchar(100) NOT NULL ,

PRIMARY KEY (`User_ID`)
);