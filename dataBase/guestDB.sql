DROP TABLE IF EXISTS `tblGuests`;

CREATE TABLE `tblGuests` (
  `firstName` VARCHAR(20),
  `lastName` VARCHAR(20),
  `entryDate` DATETIME,
  `entry` VARCHAR(50)
) ENGINE=myisam DEFAULT CHARSET=utf8;

SET autocommit=1;
INSERT INTO `tblGuests` (`firstName`, `lastName`, `entryDate`, `entry`) VALUES ('Billy', 'Maddison', '2020-05-26', 'We had a fun time');
INSERT INTO `tblGuests` (`firstName`, `lastName`, `entryDate`, `entry`) VALUES ('Wong', 'RingaDing', '1954-05-23', 'We had an awful time');
INSERT INTO `tblGuests` (`firstName`, `lastName`, `entryDate`, `entry`) VALUES ('Sally', 'OhBally', '2021-05-27', 'We had a great time');
