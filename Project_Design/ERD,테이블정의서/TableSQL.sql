CREATE TABLE `mentoss123`.`Alert_Table`
(
 `Alert_Alertnumber`       int NOT NULL AUTO_INCREMENT ,
 `Alert_ReservationNumber` int NOT NULL ,
 `Alert_User_ID`           varchar(20) NOT NULL ,
 `Alert_Contents`          varchar(100) NOT NULL ,
 `Alert_Time`              datetime NOT NULL ,
 `Alert_Check`             bit NOT NULL ,

PRIMARY KEY (`Alert_Alertnumber`),
KEY `FK_84` (`Alert_ReservationNumber`),
CONSTRAINT `FK_82` FOREIGN KEY `FK_84` (`Alert_ReservationNumber`) REFERENCES `mentoss123`.`Reservation_Table` (`Reservation_ReservationNumber`),
KEY `FK_87` (`Alert_User_ID`),
CONSTRAINT `FK_85` FOREIGN KEY `FK_87` (`Alert_User_ID`) REFERENCES `mentoss123`.`User_Table` (`User_ID`)
);

CREATE TABLE `mentoss123`.`Mentoring_Table`
(
 `Mentoring_User_ID`     varchar(20) NOT NULL ,
 `Mentoring_Number`      int NOT NULL AUTO_INCREMENT ,
 `Mentoring_Category`    tinyint NOT NULL ,
 `Mentoring_Explanation` varchar(300) NULL ,
 `Mentoring_Title`       varchar(20) NOT NULL ,
 `Mentoring_Time`        datetime NOT NULL ,
 `Mentoring_Who`         bit NOT NULL ,

PRIMARY KEY (`Mentoring_User_ID`, `Mentoring_Number`),
KEY `FK_30` (`Mentoring_User_ID`),
CONSTRAINT `FK_28` FOREIGN KEY `FK_30` (`Mentoring_User_ID`) REFERENCES `mentoss123`.`User_Table` (`User_ID`)
);

CREATE TABLE `mentoss123`.`QnA_Table`
(
 `QnA_Post_Number`       bigint NOT NULL AUTO_INCREMENT ,
 `QnA_Category`          varchar(45) NOT NULL ,
 `QnA_QuestionerID`      varchar(20) NOT NULL ,
 `QnA_RespondentID`      varchar(20) NULL ,
 `QnA_Question_Title`    varchar(50) NOT NULL ,
 `QnA_Question_Contents` varchar(300) NULL ,
 `QnA_Answer_Contents`   varchar(300) NOT NULL ,
 `QnA_PW`                varchar(10) NULL ,
 `QnA_Is_Secret`         bit NOT NULL ,

PRIMARY KEY (`QnA_Post_Number`),
KEY `FK_65` (`QnA_Category`),
CONSTRAINT `FK_63` FOREIGN KEY `FK_65` (`QnA_Category`) REFERENCES `mentoss123`.`School_Table` (`School_Department`),
KEY `FK_68` (`QnA_RespondentID`),
CONSTRAINT `FK_66` FOREIGN KEY `FK_68` (`QnA_RespondentID`) REFERENCES `mentoss123`.`User_Table` (`User_ID`),
KEY `FK_71` (`QnA_QuestionerID`),
CONSTRAINT `FK_69` FOREIGN KEY `FK_71` (`QnA_QuestionerID`) REFERENCES `mentoss123`.`User_Table` (`User_ID`)
);

CREATE TABLE `mentoss123`.`Reservation_Table`
(
 `Reservation_ReservationNumber` int NOT NULL AUTO_INCREMENT ,
 `Reservation_Mento_ID`          varchar(20) NOT NULL ,
 `Reservation_Menti_ID`          varchar(20) NOT NULL ,
 `Reservation_StartTime`         datetime NOT NULL ,
 `Reservation_EndTime`           datetime NULL ,
 `Reservation_Category`          tinyint NOT NULL ,
 `Reservation_PostNumber`        int NOT NULL ,

PRIMARY KEY (`Reservation_ReservationNumber`),
KEY `FK_93` (`Reservation_Mento_ID`),
CONSTRAINT `FK_91` FOREIGN KEY `FK_93` (`Reservation_Mento_ID`) REFERENCES `mentoss123`.`User_Table` (`User_ID`),
KEY `FK_96` (`Reservation_Menti_ID`),
CONSTRAINT `FK_94` FOREIGN KEY `FK_96` (`Reservation_Menti_ID`) REFERENCES `mentoss123`.`User_Table` (`User_ID`)
);

CREATE TABLE `mentoss123`.`Review_Table`
(
 `Reservation_ReservationNumber` int NOT NULL ,
 `Review_Score`                  tinyint NOT NULL ,
 `Review_Contents`               varchar(100) NULL ,

PRIMARY KEY (`Reservation_ReservationNumber`),
KEY `FK_54` (`Reservation_ReservationNumber`),
CONSTRAINT `FK_52` FOREIGN KEY `FK_54` (`Reservation_ReservationNumber`) REFERENCES `mentoss123`.`Reservation_Table` (`Reservation_ReservationNumber`)
);

CREATE TABLE `mentoss123`.`School_Table`
(
 `School_Department`           varchar(45) NOT NULL ,
 `School_Department_Introduce` varchar(1000) NOT NULL ,

PRIMARY KEY (`School_Department`)
);

CREATE TABLE `mentoss123`.`User_Char_Table`
(
 `User_Char_User_ID`  varchar(20) NOT NULL ,
 `User_Char_Hat`      tinyint NOT NULL ,
 `User_Char_Eyes`     tinyint NOT NULL ,
 `User_Char_Face`     tinyint NOT NULL ,
 `User_Char_Color`    varchar(20) NOT NULL ,
 `User_Char_Size`     tinyint NOT NULL ,
 `User_Char_Place`    varchar(45) NULL ,
 `User_Char_LastUser` varchar(45) NULL ,

PRIMARY KEY (`User_Char_User_ID`),
KEY `FK_26` (`User_Char_User_ID`),
CONSTRAINT `FK_24` FOREIGN KEY `FK_26` (`User_Char_User_ID`) REFERENCES `mentoss123`.`User_Table` (`User_ID`)
);

CREATE TABLE `mentoss123`.`User_Table`
(
 `User_ID`    varchar(20) NOT NULL ,
 `User_PW`    varchar(20) NOT NULL ,
 `User_Grade` tinyint NULL ,
 `User_Name`  varchar(15) NOT NULL ,
 `User_Image` varchar(100) NULL ,

PRIMARY KEY (`User_ID`)
);