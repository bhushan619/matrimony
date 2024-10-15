-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 182.50.133.88:3306
-- Generation Time: Dec 08, 2015 at 11:53 PM
-- Server version: 5.5.43-37.2-log
-- PHP Version: 5.5.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `anuvaa_matrimony`
--

-- --------------------------------------------------------

--
-- Table structure for table `hitscount`
--

CREATE TABLE `hitscount` (
  `intId` bigint(20) NOT NULL,
  `Hits` int(11) NOT NULL,
  `ex1` int(11) NOT NULL,
  `ex2` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Dumping data for table `hitscount`
--

INSERT INTO `hitscount` (`intId`, `Hits`, `ex1`, `ex2`) VALUES
(1, 1932, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `tblamcommunication`
--

CREATE TABLE `tblamcommunication` (
  `intId` bigint(20) NOT NULL,
  `varMsgFrom` longtext NOT NULL,
  `varMsgFromDesig` longtext NOT NULL,
  `varMsgFromStatus` longtext NOT NULL,
  `varMsgFromName` longtext NOT NULL,
  `varMsgto` longtext NOT NULL,
  `varMsgToDesig` longtext NOT NULL,
  `varMsgToStatus` longtext NOT NULL,
  `varMsgtoName` longtext NOT NULL,
  `varStatus` longtext NOT NULL,
  `ex1` longtext NOT NULL,
  `ex2` longtext NOT NULL,
  `ex3` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

-- --------------------------------------------------------

--
-- Table structure for table `tblamconversation`
--

CREATE TABLE `tblamconversation` (
  `intId` bigint(20) NOT NULL,
  `varMessageId` bigint(20) NOT NULL,
  `varMsgFrom` longtext NOT NULL,
  `varMsgText` longtext NOT NULL,
  `varDate` longtext NOT NULL,
  `varTime` longtext NOT NULL,
  `ex1` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

-- --------------------------------------------------------

--
-- Table structure for table `tblamemailpreferences`
--

CREATE TABLE `tblamemailpreferences` (
  `intId` bigint(20) NOT NULL,
  `varMemberId` longtext NOT NULL,
  `varEmailType` longtext NOT NULL,
  `varSubscribeData` longtext NOT NULL,
  `varSubscribe` longtext NOT NULL,
  `ex3` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `tblamemberpartnercaste`
--

CREATE TABLE `tblamemberpartnercaste` (
  `intId` bigint(20) NOT NULL,
  `varMemberId` longtext NOT NULL,
  `varCaste` longtext NOT NULL,
  `ex1` longtext NOT NULL,
  `ex2` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Dumping data for table `tblamemberpartnercaste`
--

INSERT INTO `tblamemberpartnercaste` (`intId`, `varMemberId`, `varCaste`, `ex1`, `ex2`) VALUES
(1, 'SMM7919144', 'Bhoi', '', ''),
(2, 'SMM4357628', 'Padmasali', '', ''),
(4, 'SMF1282963', 'Devanga', '', ''),
(5, 'SMM2221179', 'Catholic', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblamemberpartnerlanguages`
--

CREATE TABLE `tblamemberpartnerlanguages` (
  `intId` bigint(20) NOT NULL,
  `varMemberId` longtext NOT NULL,
  `varLanguages` longtext NOT NULL,
  `ex1` longtext NOT NULL,
  `ex2` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

-- --------------------------------------------------------

--
-- Table structure for table `tblamemberpartnermothertongue`
--

CREATE TABLE `tblamemberpartnermothertongue` (
  `intId` bigint(20) NOT NULL,
  `varMemberId` longtext NOT NULL,
  `varMotherTongue` longtext NOT NULL,
  `ex1` longtext NOT NULL,
  `ex2` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Dumping data for table `tblamemberpartnermothertongue`
--

INSERT INTO `tblamemberpartnermothertongue` (`intId`, `varMemberId`, `varMotherTongue`, `ex1`, `ex2`) VALUES
(1, 'SMM7919144', 'Marathi', '', ''),
(2, 'SMM4357628', 'Telugu', '', ''),
(4, 'SMF1282963', 'Marathi', '', ''),
(5, 'SMM2221179', 'Marathi', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblamemberpartnersubcaste`
--

CREATE TABLE `tblamemberpartnersubcaste` (
  `intId` bigint(20) NOT NULL,
  `varMemberId` longtext NOT NULL,
  `varSubcaste` longtext NOT NULL,
  `ex1` longtext NOT NULL,
  `ex2` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

-- --------------------------------------------------------

--
-- Table structure for table `tblamemberview`
--

CREATE TABLE `tblamemberview` (
  `intId` bigint(20) NOT NULL,
  `varMemberId` longtext NOT NULL,
  `varViewedMemberId` longtext NOT NULL,
  `varDate` longtext NOT NULL,
  `varTime` longtext NOT NULL,
  `ex1` longtext NOT NULL,
  `ex2` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Dumping data for table `tblamemberview`
--

INSERT INTO `tblamemberview` (`intId`, `varMemberId`, `varViewedMemberId`, `varDate`, `varTime`, `ex1`, `ex2`) VALUES
(1, 'SMF2163628', 'SMM3188117', '31-10-2015', '11 : 03 : 26', '', ''),
(2, 'SMM3188117', 'SMF2163628', '25-11-2015', '12 : 36 : 34', '', ''),
(3, 'SMF2163628', 'SMM4866917', '31-10-2015', '11 : 08 : 25', '', ''),
(4, 'SMM4866917', 'SMF2163628', '04-12-2015', '03 : 43 : 11', '', ''),
(5, 'SMM4866917', 'SMM4866917', '05-12-2015', '09 : 30 : 58', '', ''),
(6, 'SMF2266742', 'SMM3188117', '03-11-2015', '06 : 18 : 29', '', ''),
(7, 'SMM3188117', 'SMF2266742', '24-11-2015', '01 : 43 : 31', '', ''),
(8, 'SMF2163628', 'SMM7954118', '10-11-2015', '06 : 11 : 54', '', ''),
(9, 'SMM4357628', 'SMM4357628', '16-11-2015', '01 : 15 : 43', '', ''),
(10, 'SMM3188117', 'SMM3188117', '18-11-2015', '02 : 05 : 52', '', ''),
(11, 'SMM4866917', 'SMF1282963', '04-12-2015', '12 : 43 : 07', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblamloginentry`
--

CREATE TABLE `tblamloginentry` (
  `intId` bigint(20) NOT NULL,
  `varLoginId` longtext NOT NULL,
  `varDesignation` longtext NOT NULL,
  `varLoginDate` longtext NOT NULL,
  `varLoginTime` longtext NOT NULL,
  `ex1` longtext NOT NULL,
  `ex2` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

-- --------------------------------------------------------

--
-- Table structure for table `tblammembercontactdetails`
--

CREATE TABLE `tblammembercontactdetails` (
  `intId` bigint(20) NOT NULL,
  `varMemberId` longtext NOT NULL,
  `varParentMobile` longtext NOT NULL,
  `varParentLandline` longtext NOT NULL,
  `varMemberAlternateMobile1` longtext NOT NULL,
  `varMemberAlternateMobile2` longtext NOT NULL,
  `varMemberAlternateEmail1` longtext NOT NULL,
  `varMemberAlternateEmail2` longtext NOT NULL,
  `varPermanantAddress` longtext NOT NULL,
  `varAlternateAddress` longtext NOT NULL,
  `varContactPersonName` longtext NOT NULL,
  `varContactPersonMobile` longtext NOT NULL,
  `varRelationOfContactPerson` longtext NOT NULL,
  `ex1` longtext NOT NULL,
  `ex2` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Dumping data for table `tblammembercontactdetails`
--

INSERT INTO `tblammembercontactdetails` (`intId`, `varMemberId`, `varParentMobile`, `varParentLandline`, `varMemberAlternateMobile1`, `varMemberAlternateMobile2`, `varMemberAlternateEmail1`, `varMemberAlternateEmail2`, `varPermanantAddress`, `varAlternateAddress`, `varContactPersonName`, `varContactPersonMobile`, `varRelationOfContactPerson`, `ex1`, `ex2`) VALUES
(1, 'SMM3188117', '', '', '', '', '', '', '', '', '', '', '', '', ''),
(2, 'SMF2163628', '', '', '', '', '', '', '', '', '', '', '', '', ''),
(3, 'SMM4866917', '', '', '', '', '', '', '', '', '', '', '', '', ''),
(4, 'SMF2266742', '', '', '', '', '', '', '', '', '', '', '', '', ''),
(5, 'SMM4357628', '9028589687', '', '', '8087903858', '31raulsagar@gmail.com', '', 'Solapur', 'solapur', 'Siddhu', '9373666768', 'Friend ', '', ''),
(6, 'SMM7954118', '9890025445', '0', '9890568783', '', 'shubhamgarje8@gmail.com', '', '202 Shukrawar Peth Manik chook Soplapur. 413002', 'Shukrawar peth solapur.', 'Pratik Kamble', '9028575761', 'Friend ', '', ''),
(7, 'SMM7919144', '8485872562', '', '9890568783', '', '', '', '295 SHUKRAWAR PETH SOLAPUR', '', 'shubham garje', '9890568783', 'Myself ', '', ''),
(8, 'SMM9225535', '', '', '', '', '', '', 'Akshay Chambers', '', '', '', '', '', ''),
(9, 'SMF1282963', '9850291099', '022652389', '9856236670', '8087903858', 'goutamimishra22@gmail.com', 'goutamimishra40@gmail.com', 'lakshmi residance, park chowk, new mumbai 413005', 'golden residance, near bhai khala , west mumbai 413005', 'Siddhu', '8055505050', 'Myself ', '', ''),
(10, 'SMM2221179', '9695558032', '02172326618', '9856236670', '8856885822', 'pitterfranandise20@gmail.com', 'franandisepitter30@gmail.com', 'sidhi vinayak complex, talegao dabade, pune 413002', 'gold complex, laxmi nagar, hadapsar pune 413201', 'piter ', '9028575761', 'Myself ', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblammemberemailcode`
--

CREATE TABLE `tblammemberemailcode` (
  `intId` bigint(20) NOT NULL,
  `varMemberId` longtext NOT NULL,
  `varEmailCode` longtext NOT NULL,
  `ex1` longtext NOT NULL,
  `ex2` longtext NOT NULL,
  `ex3` longtext NOT NULL,
  `ex4` longtext NOT NULL,
  `ex5` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Dumping data for table `tblammemberemailcode`
--

INSERT INTO `tblammemberemailcode` (`intId`, `varMemberId`, `varEmailCode`, `ex1`, `ex2`, `ex3`, `ex4`, `ex5`) VALUES
(1, 'SMM3188117', '876916252931647', '', '', '', '', ''),
(2, 'SMF2163628', '793885652825713', '', '', '', '', ''),
(3, 'SMM4866917', '286243636211477', '', '', '', '', ''),
(4, 'SMF2266742', '698599611725565', '', '', '', '', ''),
(5, 'SMM4357628', '256588685479413', '', '', '', '', ''),
(6, 'SMM7954118', '124364853821621', '', '', '', '', ''),
(7, 'SMM7919144', '782991473824961', '', '', '', '', ''),
(8, 'SMM9225535', '588567754852787', '', '', '', '', ''),
(9, 'SMF1282963', '437889715623594', '', '', '', '', ''),
(10, 'SMM2221179', '211442159191516', '', '', '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblammemberfamily`
--

CREATE TABLE `tblammemberfamily` (
  `intId` bigint(20) NOT NULL,
  `varMemberId` longtext NOT NULL,
  `varFatherName` longtext NOT NULL,
  `varFatherOccupation` longtext NOT NULL,
  `varMotherName` longtext NOT NULL,
  `varMotherOccupation` longtext NOT NULL,
  `varNoOfBrother` longtext NOT NULL,
  `varBrotherMarried` longtext NOT NULL,
  `varNoOfSister` longtext NOT NULL,
  `varSisterMarried` longtext NOT NULL,
  `varLiveWithParent` longtext NOT NULL,
  `varFamilystatus` longtext NOT NULL,
  `varFamilytype` longtext NOT NULL,
  `varFamilyvalue` longtext NOT NULL,
  `varAboutfamily` longtext NOT NULL,
  `ex1` longtext NOT NULL,
  `ex2` longtext NOT NULL,
  `ex3` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Dumping data for table `tblammemberfamily`
--

INSERT INTO `tblammemberfamily` (`intId`, `varMemberId`, `varFatherName`, `varFatherOccupation`, `varMotherName`, `varMotherOccupation`, `varNoOfBrother`, `varBrotherMarried`, `varNoOfSister`, `varSisterMarried`, `varLiveWithParent`, `varFamilystatus`, `varFamilytype`, `varFamilyvalue`, `varAboutfamily`, `ex1`, `ex2`, `ex3`) VALUES
(1, 'SMM3188117', '', '', '', '', '', '', '', '', '', 'Middle class', 'Joint', 'Orthodox', '', '', '', ''),
(2, 'SMF2163628', '', '', '', '', '', '', '', '', '', 'Middle class', 'Joint', 'Orthodox', '', '', '', ''),
(3, 'SMM4866917', '', '', '', '', '', '', '', '', '', 'Middle class', 'Joint', 'Traditional', '', '', '', ''),
(4, 'SMF2266742', '', '', '', '', '', '', '', '', '', 'Middle class', 'Joint', 'Orthodox', '', '', '', ''),
(5, 'SMM4357628', 'Nagnath Narayan Raul', 'Fashion Designer', 'Padmavati Nagnath Raul', 'Housewife', 'none', 'none', '2', '2', 'Yes', 'Middle class', 'Nuclear', 'Traditional', 'Nice and better my family and I also love my family very much.', '', '', ''),
(6, 'SMM7954118', 'Devidas Shankarrao Garje', 'Business Analyst', 'Sangeta Devidas Garje', 'Housewife', 'none', 'none', '3', '3', 'Yes', 'Middle class', 'Nuclear', 'Traditional', 'My family is very loveble family.... & I LOve my family', '', '', ''),
(7, 'SMM7919144', 'Rajkumar goverdhan kamble', 'Supervisor', 'ujjwala', 'Housewife', 'none', 'none', '2', '1', 'Yes', 'Middle class', 'Nuclear', 'Traditional', 'nice helpful  and always care for me', '', '', ''),
(8, 'SMM9225535', '', '', '', '', '', '', '', '', '', 'Upper middle class', 'Nuclear', 'Moderate', '', '', '', ''),
(9, 'SMF1282963', 'goutam mishra', 'Interior Designer', 'urmila mishra', 'Architect', '1', '1', 'none', 'none', 'Yes', 'Middle class', 'Nuclear', 'Traditional', 'join family an over all five member in family', '', '', ''),
(10, 'SMM2221179', 'johan farnandise', 'Agriculture & Farming Professional', 'khristina farnandise', 'Airline Professional', 'none', 'none', 'none', 'none', 'No', 'Upper middle class', 'Nuclear', 'Liberal', 'over all three membar no doesn''t matter', '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblammemberinformation`
--

CREATE TABLE `tblammemberinformation` (
  `intId` bigint(20) NOT NULL,
  `varMemberId` longtext NOT NULL,
  `varAgeDate` int(11) NOT NULL,
  `varAgeMonth` longtext NOT NULL,
  `varYearMonth` int(11) NOT NULL,
  `varAgeToday` int(11) NOT NULL,
  `varMaritalStatus` longtext NOT NULL,
  `varChildrenStatus` longtext NOT NULL,
  `varChildrenNo` int(11) NOT NULL,
  `varAbout` longtext NOT NULL,
  `ex1` longtext NOT NULL,
  `ex2` longtext NOT NULL,
  `ex3` longtext NOT NULL,
  `ex4` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Dumping data for table `tblammemberinformation`
--

INSERT INTO `tblammemberinformation` (`intId`, `varMemberId`, `varAgeDate`, `varAgeMonth`, `varYearMonth`, `varAgeToday`, `varMaritalStatus`, `varChildrenStatus`, `varChildrenNo`, `varAbout`, `ex1`, `ex2`, `ex3`, `ex4`) VALUES
(1, 'SMM3188117', 1, 'August', 1989, 27, 'Never Married', 'NA', 0, 'Myself', '', '', '', ''),
(2, 'SMF2163628', 16, 'March', 1983, 33, 'Never Married', 'NA', 0, 'I am Happy person', '', '', '', ''),
(3, 'SMM4866917', 16, 'August', 1989, 27, 'Never Married', 'NA', 0, ' I am myself', '', '', '', ''),
(4, 'SMF2266742', 1, 'December', 1989, 26, 'Never Married', 'NA', 0, 'Hh', '', '', '', ''),
(5, 'SMM4357628', 31, 'December', 1990, 25, 'Never Married', 'NA', 0, 'I am Very Cool Person,I want Correct Jodi ', '', '', '', ''),
(6, 'SMM7954118', 31, 'August', 1994, 22, 'Never Married', 'NA', 0, 'I am cool & friendly Person', '', '', '', ''),
(7, 'SMM7919144', 17, 'June', 1991, 25, 'Never Married', 'NA', 0, 'i m cool person with littel attitute', '', '', '', ''),
(8, 'SMM9225535', 22, 'July', 1989, 27, 'Never Married', 'NA', 0, 'i m mayur', '', '', '', ''),
(9, 'SMF1282963', 4, 'March', 1993, 23, 'Never Married', 'NA', 0, 'working women', '', '', '', ''),
(10, 'SMM2221179', 7, 'October', 1988, 28, 'Never Married', 'NA', 0, 'Goverment servant an self depend person\r\n', '', '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblammemberinterests`
--

CREATE TABLE `tblammemberinterests` (
  `intId` bigint(20) NOT NULL,
  `varInterestOfId` longtext NOT NULL,
  `varInterestInId` longtext NOT NULL,
  `varDate` longtext NOT NULL,
  `varTime` longtext NOT NULL,
  `ex1` longtext NOT NULL,
  `ex2` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Dumping data for table `tblammemberinterests`
--

INSERT INTO `tblammemberinterests` (`intId`, `varInterestOfId`, `varInterestInId`, `varDate`, `varTime`, `ex1`, `ex2`) VALUES
(1, 'SMF2266742', 'SMM3188117', '03-11-2015', '06 : 18 : 03', '', ''),
(2, 'SMM7954118', 'SMF2163628', '03-11-2015', '09 : 20 : 09', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblammemberlifestyle`
--

CREATE TABLE `tblammemberlifestyle` (
  `intId` bigint(20) NOT NULL,
  `varMemberId` longtext NOT NULL,
  `varEatingHabits` longtext NOT NULL,
  `varSmoke` longtext NOT NULL,
  `varDrink` longtext NOT NULL,
  `varFavouriteMusic` longtext NOT NULL,
  `varFavouriteDestination` longtext NOT NULL,
  `varFavouriteBook` longtext NOT NULL,
  `varFavouriteAuthor` longtext NOT NULL,
  `varHobbyInterest` longtext NOT NULL,
  `varSpokenLanguages` longtext NOT NULL,
  `ex1` longtext NOT NULL,
  `ex2` longtext NOT NULL,
  `ex3` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Dumping data for table `tblammemberlifestyle`
--

INSERT INTO `tblammemberlifestyle` (`intId`, `varMemberId`, `varEatingHabits`, `varSmoke`, `varDrink`, `varFavouriteMusic`, `varFavouriteDestination`, `varFavouriteBook`, `varFavouriteAuthor`, `varHobbyInterest`, `varSpokenLanguages`, `ex1`, `ex2`, `ex3`) VALUES
(1, 'SMM3188117', 'Vegetarian', 'No', 'No', '', '', '', '', '', '', '', '', ''),
(2, 'SMF2163628', 'Vegetarian', 'No', 'No', '', '', '', '', '', '', '', '', ''),
(3, 'SMM4866917', 'Non-Vegetarian', 'Yes', 'Yes', '', '', '', '', '', '', '', '', ''),
(4, 'SMF2266742', 'Vegetarian', 'Yes', 'No', '', '', '', '', '', '', '', '', ''),
(5, 'SMM4357628', 'Non-Vegetarian', 'No', 'No', 'Indian / Classical Music;Watching TV', '', '', '', 'Cooking;Internet Surfing;Movies;Photography;Traveling;', 'English;Hindi;Marathi;Telugu;Tamil;Kannada;', '', '', ''),
(6, 'SMM7954118', 'Non-Vegetarian', 'No', 'No', 'Film songs;Indian / Classical Music;', 'Success Business Man', 'Raja Shiv Chatrapati ', 'chetan bhagat', 'Cooking;Dancing;Gardening / Landscaping;Internet Surfing;Movies;Photography;Playing Musical Instruments;Traveling;', 'English;Hindi;Marathi;', '', '', ''),
(7, 'SMM7919144', 'Non-Vegetarian', 'No', 'No', 'Film songs;', 'become a class 1 officer', 'five point someone', 'chetan bhagat', 'Art / Handicraft;Internet Surfing;Movies;making friend', 'English;Hindi;Marathi;', '', '', ''),
(8, 'SMM9225535', 'Non-Vegetarian', 'No', 'No', '', '', '', '', '', '', '', '', ''),
(9, 'SMF1282963', 'Non-Vegetarian', 'Yes', 'Yes', 'Indian / Classical Music;Western Music;italin ', 'maleshia', 'adalf hitler', 'stive jobs', 'Cooking;Dancing;Internet Surfing;Listening to Music;Movies;Painting;Pets;Photography;Playing Musical Instruments;Traveling;sky diving', 'English;Hindi;Gujrathi;dutch', '', '', ''),
(10, 'SMM2221179', 'Non-Vegetarian', 'No', 'Yes', 'Film songs;Indian / Classical Music;Western Music;italiyan music', 'maleshiya', 'adalf hitler', 'mahatma gandi', 'Art / Handicraft;Cooking;Dancing;Gardening / Landscaping;Internet Surfing;Listening to Music;Movies;Painting;Pets;Photography;Playing Musical Instruments;Traveling;sky diving', 'English;Hindi;Marathi;duche', '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblammemberlivingin`
--

CREATE TABLE `tblammemberlivingin` (
  `intId` bigint(20) NOT NULL,
  `varMemberId` longtext NOT NULL,
  `varCountry` longtext NOT NULL,
  `varCitizenship` longtext NOT NULL,
  `varState` longtext NOT NULL,
  `varCity` longtext NOT NULL,
  `ex1` longtext NOT NULL,
  `ex2` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Dumping data for table `tblammemberlivingin`
--

INSERT INTO `tblammemberlivingin` (`intId`, `varMemberId`, `varCountry`, `varCitizenship`, `varState`, `varCity`, `ex1`, `ex2`) VALUES
(1, 'SMM3188117', 'India', 'India', 'Maharashtra', 'Solapur', '', ''),
(2, 'SMF2163628', 'India', 'India', 'Maharashtra', 'Solapur', '', ''),
(3, 'SMM4866917', 'India', 'India', 'Maharashtra', 'Jalgaon', '', ''),
(4, 'SMF2266742', 'India', 'India', 'Maharashtra', 'Bhandara', '', ''),
(5, 'SMM4357628', 'India', 'India', 'Maharashtra', 'Solapur', '', ''),
(6, 'SMM7954118', 'India', 'India', 'Maharashtra', 'Solapur', '', ''),
(7, 'SMM7919144', 'India', 'India', 'Maharashtra', 'Solapur', '', ''),
(8, 'SMM9225535', 'India', 'India', 'Maharashtra', 'Jalgaon', '', ''),
(9, 'SMF1282963', 'British Indian Ocean Territory', 'Bahamas', 'Mizoram', 'Aizawl', '', ''),
(10, 'SMM2221179', 'India', 'India', 'Maharashtra', 'Pune', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblammemberpartnerarea`
--

CREATE TABLE `tblammemberpartnerarea` (
  `intId` bigint(20) NOT NULL,
  `varMemberId` longtext,
  `varFinctionalArea` longtext,
  `ex1` longtext,
  `ex2` longtext,
  `ex3` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Dumping data for table `tblammemberpartnerarea`
--

INSERT INTO `tblammemberpartnerarea` (`intId`, `varMemberId`, `varFinctionalArea`, `ex1`, `ex2`, `ex3`) VALUES
(1, 'SMM7919144', 'Manager', '', '', ''),
(2, 'SMM4357628', 'Manager', '', '', ''),
(3, 'SMM4357628', 'Executive', '', '', ''),
(4, 'SMM4357628', 'Clerk', '', '', ''),
(6, 'SMF1282963', 'Manager', '', '', ''),
(7, 'SMF1282963', 'Supervisor', '', '', ''),
(8, 'SMM2221179', 'Manager', '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblammemberpartnerbasic`
--

CREATE TABLE `tblammemberpartnerbasic` (
  `intId` bigint(20) NOT NULL DEFAULT '0',
  `varMemberid` longtext,
  `varAgefrom` longtext,
  `varAgeto` longtext,
  `varMaritalStatus` longtext,
  `varHaveChildren` longtext,
  `varChildLive` longtext NOT NULL,
  `varHeightfrom` longtext,
  `varHeightto` longtext,
  `varWeightfrom` longtext,
  `varWeightto` longtext,
  `varComplexion` longtext,
  `varBodytype` longtext,
  `varSpecialCase` longtext,
  `varLivingwithparents` longtext,
  `varFamilyvalues` longtext,
  `varFamilytype` longtext,
  `varFamilystatus` longtext,
  `varSmoking` longtext,
  `varDrinking` longtext,
  `varEating` longtext,
  `varAboutPartner` longtext,
  `ex2` longtext,
  `ex3` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Dumping data for table `tblammemberpartnerbasic`
--

INSERT INTO `tblammemberpartnerbasic` (`intId`, `varMemberid`, `varAgefrom`, `varAgeto`, `varMaritalStatus`, `varHaveChildren`, `varChildLive`, `varHeightfrom`, `varHeightto`, `varWeightfrom`, `varWeightto`, `varComplexion`, `varBodytype`, `varSpecialCase`, `varLivingwithparents`, `varFamilyvalues`, `varFamilytype`, `varFamilystatus`, `varSmoking`, `varDrinking`, `varEating`, `varAboutPartner`, `ex2`, `ex3`) VALUES
(1, 'SMM3188117', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', ''),
(2, 'SMF2163628', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', ''),
(3, 'SMM4866917', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', ''),
(4, 'SMF2266742', '18', '49', 'Never Married', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', ''),
(5, 'SMM4357628', '20', '22', 'Never Married', '', '', '5ft 5in', '5ft 6in', '45Kg', '53Kg', 'Fair', 'Slim', 'None', 'Yes', 'Traditional', 'Joint', 'Middle class', 'No', 'No', 'Non-Vegetarian', 'Looking Little Beautiful girl,with traditional family .\r\nmixing with all.', '', ''),
(6, 'SMM7954118', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', ''),
(7, 'SMM7919144', '23', '25', 'Never Married', '', '', '5ft 11in', '6ft', '52Kg', 'Select', 'Fair', 'Average', 'None', 'Yes', 'Traditional', 'Nuclear', 'Upper middle class', 'No', 'No', 'Does Not Matter', '', '', ''),
(8, 'SMM9225535', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', ''),
(9, 'SMF1282963', '22', '22', 'Never Married', '', '', '6ft', '6ft 1in', '64Kg', 'Select', 'Very Fair', 'Athletic', 'None', 'No', 'Moderate', 'Nuclear', 'Upper middle class', 'Yes ', 'No', 'Non-Vegetarian', 'fair & handsome person', '', ''),
(10, 'SMM2221179', '24', '24', 'Never Married', '', '', '6ft', '6ft 1in', '61Kg', '61Kg', 'Fair', 'Average', 'None', 'No', 'Moderate', 'Nuclear', 'Rich', 'No', 'Yes ', 'Non-Vegetarian', 'fair an good looking person an educated person\r\n', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblammemberpartnereducation`
--

CREATE TABLE `tblammemberpartnereducation` (
  `intId` bigint(20) NOT NULL,
  `varMemberId` longtext,
  `varEducation` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Dumping data for table `tblammemberpartnereducation`
--

INSERT INTO `tblammemberpartnereducation` (`intId`, `varMemberId`, `varEducation`) VALUES
(1, 'SMM7919144', 'BE'),
(2, 'SMM4357628', 'BCA'),
(3, 'SMM4357628', 'BE'),
(4, 'SMM4357628', 'MCA'),
(5, 'SMM4357628', 'MBA'),
(7, 'SMF1282963', 'BE'),
(8, 'SMM2221179', 'Aeronautical Engineering'),
(9, 'SMM2221179', 'BE');

-- --------------------------------------------------------

--
-- Table structure for table `tblammemberpartneremploy`
--

CREATE TABLE `tblammemberpartneremploy` (
  `intId` bigint(20) NOT NULL,
  `varMemberId` longtext,
  `varEmployedSector` longtext,
  `ex1` longtext,
  `ex2` longtext,
  `ex3` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Dumping data for table `tblammemberpartneremploy`
--

INSERT INTO `tblammemberpartneremploy` (`intId`, `varMemberId`, `varEmployedSector`, `ex1`, `ex2`, `ex3`) VALUES
(1, 'SMM7919144', 'Private Sector', '', '', ''),
(2, 'SMM4357628', 'State Government', '', '', ''),
(3, 'SMM4357628', 'Private Sector', '', '', ''),
(4, 'SMM4357628', 'Public Sector', '', '', ''),
(5, 'SMM2221179', 'State Government', '', '', ''),
(6, 'SMF1282963', 'Not Working', '', '', ''),
(7, 'SMF1282963', 'Not Working', '', '', ''),
(8, 'SMM2221179', 'State Government', '', '', ''),
(9, 'SMM2221179', 'State Government', '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblammemberpartnerincome`
--

CREATE TABLE `tblammemberpartnerincome` (
  `intId` bigint(20) NOT NULL,
  `varMemberId` longtext,
  `varCurrency` longtext,
  `varAnnualIncome` longtext,
  `ex1` longtext,
  `ex2` longtext,
  `ex3` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Dumping data for table `tblammemberpartnerincome`
--

INSERT INTO `tblammemberpartnerincome` (`intId`, `varMemberId`, `varCurrency`, `varAnnualIncome`, `ex1`, `ex2`, `ex3`) VALUES
(1, 'SMM3188117', '', '', '', '', ''),
(2, 'SMF2163628', '', '', '', '', ''),
(3, 'SMM4866917', '', '', '', '', ''),
(4, 'SMF2266742', '', '', '', '', ''),
(5, 'SMM4357628', 'INR - Indian Rupee', '200000', '', '', ''),
(6, 'SMM7954118', '', '', '', '', ''),
(7, 'SMM7919144', 'INR - Indian Rupee', '500000', '', '', ''),
(8, 'SMM9225535', '', '', '', '', ''),
(9, 'SMF1282963', 'INR - Indian Rupee', '40000', '', '', ''),
(10, 'SMM2221179', 'INR - Indian Rupee', '35000', '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblammemberpartnerreligious`
--

CREATE TABLE `tblammemberpartnerreligious` (
  `intId` bigint(20) NOT NULL,
  `varMemberId` longtext,
  `varReligion` longtext,
  `varManglik` longtext,
  `varNakshatra` longtext,
  `varRaasiMoonSign` longtext,
  `ex1` longtext,
  `ex2` longtext,
  `ex3` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Dumping data for table `tblammemberpartnerreligious`
--

INSERT INTO `tblammemberpartnerreligious` (`intId`, `varMemberId`, `varReligion`, `varManglik`, `varNakshatra`, `varRaasiMoonSign`, `ex1`, `ex2`, `ex3`) VALUES
(1, 'SMM3188117', '', '', '', '', '', '', ''),
(2, 'SMF2163628', '', '', '', '', '', '', ''),
(3, 'SMM4866917', '', '', '', '', '', '', ''),
(4, 'SMF2266742', '', '', '', '', '', '', ''),
(5, 'SMM4357628', 'Hindu', 'No', 'Swathi', 'Kumbha (Aquarius)', '', '', ''),
(6, 'SMM7954118', '', '', '', '', '', '', ''),
(7, 'SMM7919144', 'Hindu', 'No', '', '', '', '', ''),
(8, 'SMM9225535', '', '', '', '', '', '', ''),
(9, 'SMF1282963', 'Hindu', 'Yes', 'Asilesha', 'Karka (Cancer)', '', '', ''),
(10, 'SMM2221179', 'Christian', 'Does not matter', 'Visaka', 'Meena (Pisces)', '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblammemberphysicalinformation`
--

CREATE TABLE `tblammemberphysicalinformation` (
  `intId` bigint(20) NOT NULL,
  `varMemberId` longtext NOT NULL,
  `varHeightFt` varchar(10) NOT NULL,
  `varHeightCm` varchar(10) NOT NULL,
  `varWeight` varchar(10) NOT NULL,
  `varBodyType` longtext NOT NULL,
  `varComplexion` longtext NOT NULL,
  `varBloodGroup` varchar(10) NOT NULL,
  `varSpecialCase` longtext NOT NULL,
  `varWeightlbs` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Dumping data for table `tblammemberphysicalinformation`
--

INSERT INTO `tblammemberphysicalinformation` (`intId`, `varMemberId`, `varHeightFt`, `varHeightCm`, `varWeight`, `varBodyType`, `varComplexion`, `varBloodGroup`, `varSpecialCase`, `varWeightlbs`) VALUES
(1, 'SMM3188117', '5ft 5in', '165Cms', '60Kg', 'Slim', 'Wheatish', 'B+', 'None ', '133Lbs'),
(2, 'SMF2163628', '5ft 5in', '165Cms', '60Kg', 'Slim', 'Wheatish', 'B+', 'None ', '133Lbs'),
(3, 'SMM4866917', '5ft 5in', '165Cms', '60Kg', 'Average', 'Fair', 'B+', 'None ', '133Lbs'),
(4, 'SMF2266742', '5ft 6in', '167Cms', '45Kg', 'Average', 'Fair', 'O+', 'None ', '100Lbs'),
(5, 'SMM4357628', '5ft 9in', '175Cms', '61Kg', 'Average', 'Wheatish Medium', 'O+', 'None', '135Lbs'),
(6, 'SMM7954118', '5ft 11in', '180Cms', '52Kg', 'Average', 'Fair', 'B+', 'None', '115Lbs'),
(7, 'SMM7919144', '6ft', '183Cms', '55Kg', 'Slim', 'Wheatish', 'A+', 'None', '122Lbs'),
(8, 'SMM9225535', '5ft 5in', '165Cms', '72Kg', 'Average', 'Wheatish Medium', 'B+', 'None ', '159Lbs'),
(9, 'SMF1282963', '5ft 3in', '160Cms', '50Kg', 'Slim', 'Fair', 'O+', 'None', '111Lbs'),
(10, 'SMM2221179', '6ft', '183Cms', '65Kg', 'Average', 'Fair', 'AB+', 'Does not Matter', '144Lbs');

-- --------------------------------------------------------

--
-- Table structure for table `tblammemberprofessionalinfo`
--

CREATE TABLE `tblammemberprofessionalinfo` (
  `intId` bigint(20) NOT NULL,
  `varMemberId` longtext NOT NULL,
  `varEducation` longtext NOT NULL,
  `varAdditionalDegree` longtext NOT NULL,
  `varCollegeOrInstitution` longtext NOT NULL,
  `varEducationDetail` longtext NOT NULL,
  `varEmployeeIn` longtext NOT NULL,
  `varOccupation` longtext NOT NULL,
  `varOccupationDetail` longtext NOT NULL,
  `varAnnualIncome` bigint(20) NOT NULL,
  `varIncomeCurrency` longtext NOT NULL,
  `varExperience` longtext NOT NULL,
  `varExperienceIn` longtext NOT NULL,
  `ex1` longtext NOT NULL,
  `ex2` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Dumping data for table `tblammemberprofessionalinfo`
--

INSERT INTO `tblammemberprofessionalinfo` (`intId`, `varMemberId`, `varEducation`, `varAdditionalDegree`, `varCollegeOrInstitution`, `varEducationDetail`, `varEmployeeIn`, `varOccupation`, `varOccupationDetail`, `varAnnualIncome`, `varIncomeCurrency`, `varExperience`, `varExperienceIn`, `ex1`, `ex2`) VALUES
(1, 'SMM3188117', 'MBA', '', '', '', '--Select Employee In--', 'Manager', '', 12000, 'INR - Indian Rupee', '', 'Month', '', ''),
(2, 'SMF2163628', 'BE', '', '', '', 'Private Sector ', 'Manager', '', 800000, 'INR - Indian Rupee', '', '', '', ''),
(3, 'SMM4866917', 'MCA', '', '', '', 'Private Sector ', 'Administrative Professional', '', 12000, 'INR - Indian Rupee', '', '', '', ''),
(4, 'SMF2266742', 'Aeronautical Engineering', '', '', '', 'Public Sector ', 'Supervisor', '', 112, 'INR - Indian Rupee', '', '', '', ''),
(5, 'SMM4357628', 'MBA', 'BCA', 'BMIT Solapur', 'BCA & MBA ', 'Private Sector', 'Executive', 'EMRS INDIA SOLAPUR', 200000, 'INR - Indian Rupee', '5', 'Year', '', ''),
(6, 'SMM7954118', 'BE', 'MSCIT, DIPLOMA ELECTRICAL ENGG', 'Vidhya Vikas Pratisthan', 'BE ELECTRICAL ENGG', 'Private Sector', 'Technician', 'private secter', 300000, 'INR - Indian Rupee', '1', 'Year', '', ''),
(7, 'SMM7919144', 'BE', 'CCNA', 'A.G.PATIL INSTITUTE OF TECHNOLOGY', '2014 PASSOUT', 'Not Working', 'Student', 'NA', 100000, 'INR - Indian Rupee', '3', 'Month', '', ''),
(8, 'SMM9225535', 'M.Sc.', '', '', '', 'Self Employed ', 'Chairman', '', 500000, 'INR - Indian Rupee', '', '', '', ''),
(9, 'SMF1282963', 'BE', 'niit (core java)', 'university of mumbai', 'BE in mechanical', 'Central Government', 'Administrative Professional', 'first year appear', 30000, 'INR - Indian Rupee', '2', 'Year', '', ''),
(10, 'SMM2221179', 'B.Sc IT/ Computer Science', 'NA', 'sihagad vadgao butruk, pune', 'electronics & telecommunication  B E', 'State Government', 'Business Analyst', 'civil services ', 35000, 'INR - Indian Rupee', '5', 'Year', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblammemberregistration`
--

CREATE TABLE `tblammemberregistration` (
  `intId` bigint(20) NOT NULL,
  `varMemberId` longtext NOT NULL,
  `varMembershipType` longtext NOT NULL,
  `varMemberFor` longtext NOT NULL,
  `varMemberName` longtext NOT NULL,
  `varGender` longtext NOT NULL,
  `varMobile` bigint(20) NOT NULL,
  `varMobileVerification` longtext NOT NULL,
  `varEmail` longtext NOT NULL,
  `varEmailVerification` longtext NOT NULL,
  `varMemberStatus` longtext NOT NULL,
  `varFranchiseeId` longtext NOT NULL,
  `varAdminId` longtext NOT NULL,
  `varCreatorDesignation` longtext NOT NULL,
  `varDate` longtext NOT NULL,
  `varTime` longtext NOT NULL,
  `varPassword` longtext NOT NULL,
  `varPhoto` longtext NOT NULL,
  `varPhotoApprove` longtext NOT NULL,
  `ex3` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Dumping data for table `tblammemberregistration`
--

INSERT INTO `tblammemberregistration` (`intId`, `varMemberId`, `varMembershipType`, `varMemberFor`, `varMemberName`, `varGender`, `varMobile`, `varMobileVerification`, `varEmail`, `varEmailVerification`, `varMemberStatus`, `varFranchiseeId`, `varAdminId`, `varCreatorDesignation`, `varDate`, `varTime`, `varPassword`, `varPhoto`, `varPhotoApprove`, `ex3`) VALUES
(1, 'SMM3188117', 'Paid', 'Myself', 'Siddheshwar Kadam', 'Male', 8055505050, '31881175', 'om21kadam@gmail.com', 'true', 'Verified', 'NA', 'NA', 'Member', '31-10-2015', '10 : 30 : 21', 'om21kadam', 'MaleNoProfile.jpg', 'Approved', 'NA'),
(2, 'SMF2163628', 'Paid', 'Daughter', 'Amrapali Navnath Manjare', 'Female', 9028553339, '21636285', 'manjare.amrapali@gmail.com', 'true', 'Verified', 'NA', 'NA', 'Member', '31-10-2015', '10 : 50 : 56', 'tesy123', 'FemaleNoProfile.jpg', 'Approved', 'NA'),
(3, 'SMM4866917', 'Unpaid', 'Myself', 'Bhushan Savale', 'Male', 0, '48669177', 'savalebd@gmail.com', 'true', 'Verified', 'Member', 'NA', 'Member', '31-10-2015', '10 : 56 : 27', '48669177', 'MaleNoProfile.jpg', 'Approved', 'NA'),
(4, 'SMF2266742', 'Unpaid', 'Myself', 'Jyoti Patil', 'Female', 0, '22667423', 'patiljyoti612@gmail.com', 'true', 'Verified', 'Member', 'NA', 'Member', '03-11-2015', '06 : 12 : 05', '22667423', 'FemaleNoProfile.jpg', 'Approved', 'NA'),
(5, 'SMF7454248', 'Unpaid', 'Myself', 'Priyanka Ashok Parande', 'Female', 7709258463, '74542485', 'priyankaparande59@gmail.com', '74542485', 'VerifiedFirstTime', 'NA', 'NA', 'Member', '03-11-2015', '07 : 44 : 36', '7777', 'FemaleNoProfile.jpg', 'Approved', 'NA'),
(6, 'SMM4357628', 'Unpaid', 'Myself', 'Sagar Naganath Raul', 'Male', 9028589687, '43576287', '31raulsagar@gmail.com', 'true', 'Verified', 'NA', 'NA', 'Member', '03-11-2015', '08 : 08 : 26', '9028589687', 'SMM4357628.jpg', 'Approved', 'Viewable'),
(7, 'SMM7954118', 'Unpaid', 'Myself', 'Shubham Devidas Garje', 'Male', 9890568783, '79541188', 'shubhamgarje8@gmail.com', 'true', 'Verified', 'NA', 'NA', 'Member', '03-11-2015', '08 : 33 : 58', 'Shubham@86', 'SMM7954118.jpg', 'Approved', 'Viewable'),
(8, 'SMM7919144', 'Unpaid', 'Myself', 'pratik rajkumar kamble', 'Male', 9028575761, '79191445', 'kpratik575761@gmail.com', 'true', 'Verified', 'NA', 'NA', 'Member', '03-11-2015', '08 : 39 : 31', 'pratikkp', 'SMM7919144.jpg', 'UnApproved', 'Viewable'),
(9, 'SMM2981538', 'Unpaid', 'Myself', 'sagar sudhir Mahindrakar', 'Male', 9637645082, '29815384', 'sgmahindrakar92@gmail.com', '29815384', 'VerifiedFirstTime', 'NA', 'NA', 'Member', '08-11-2015', '08 : 19 : 44', 'sagar8158', 'MaleNoProfile.jpg', 'Approved', 'NA'),
(10, 'SMM9225535', 'Unpaid', 'Myself', 'Mayur potdar ', 'Male', 9620961818, '92255358', 'potdarmayur79@gmail.com', '92255358', 'Verified', 'NA', 'NA', 'Member', '08-11-2015', '09 : 15 : 12', '123456', 'SMM9225535.jpg', 'Approved', 'Viewable'),
(11, 'SMF1146886', 'Unpaid', 'Daughter', 'Khushi Nikate', 'Female', 7768965410, '11468864', 'rupkiranvk@rediffmail.com', '11468864', 'VerifiedFirstTime', 'NA', 'NA', 'Member', '14-11-2015', '12 : 51 : 08', '7768965410', 'FemaleNoProfile.jpg', 'Approved', 'NA'),
(12, 'SMF2695285', 'Unpaid', 'Daughter', 'Khushi Nikate', 'Female', 7768965410, '26952853', 'rupkiran444@gmail.com', '26952853', 'VerifiedFirstTime', 'NA', 'NA', 'Member', '14-11-2015', '03 : 07 : 10', '7768965410', 'FemaleNoProfile.jpg', 'Approved', 'NA'),
(13, 'SMF7763141', 'Unpaid', 'Daughter', 'sandhya kumar chavan', 'Female', 7620212555, '77631418', 'mona26chavan@gmail.com', '77631418', 'VerifiedFirstTime', 'NA', 'NA', 'Member', '14-11-2015', '05 : 09 : 35', 'chavansk', 'FemaleNoProfile.jpg', 'Approved', 'NA'),
(14, 'SMF6693688', 'Unpaid', 'Sister', 'Aarti pawar ', 'Female', 7620212555, '66936889', 'emrsindia@gmail.com', '66936889', 'VerifiedFirstTime', 'NA', 'NA', 'Member', '14-11-2015', '05 : 11 : 38', 'emrsindia', 'FemaleNoProfile.jpg', 'Approved', 'NA'),
(15, 'SMM6641452', 'Unpaid', 'Myself', 'Pravin', 'Male', 9763056618, '66414529', 'siddheshwargroup@outlook.com', '66414529', 'VerifiedFirstTime', 'NA', 'NA', 'Member', '15-11-2015', '08 : 29 : 51', 'om21kadam', 'MaleNoProfile.jpg', 'Approved', 'NA'),
(16, 'SMM6127267', 'Unpaid', 'Myself', 'Siddhu', 'Male', 9763056618, '61272672', 'om21kadam@rediffmail.com', '61272672', 'Unverified', 'NA', 'NA', 'Member', '18-11-2015', '02 : 17 : 00', 'OmKadam@2015', 'MaleNoProfile.jpg', 'Approved', 'NA'),
(17, 'SMF1282963', 'Unpaid', 'Myself', 'shriya mishra', 'Female', 8055505050, '12829638', 'madhurikale57@gmail.com', 'true', 'Verified', 'NA', 'NA', 'Member', '02-12-2015', '12 : 05 : 29', '99999999', 'FemaleNoProfile.jpg', 'UnApproved', 'NA'),
(18, 'SMM2221179', 'Unpaid', 'Myself', 'josaf farnandise', 'Male', 8055505050, '22211794', 'dikshachopda22@gmail.com', 'true', 'Verified', 'NA', 'NA', 'Member', '02-12-2015', '02 : 07 : 04', '11113333', 'MaleNoProfile.jpg', 'Approved', 'NA'),
(19, 'SMF7898345', 'Unpaid', 'Myself', 'ketrina joy', 'Female', 9028589687, '78983455', 'kalemadhuri1@gmail.com', 'true', 'VerifiedFirstTime', 'NA', 'NA', 'Member', '03-12-2015', '03 : 02 : 58', '00000000', 'FemaleNoProfile.jpg', 'Approved', 'NA');

-- --------------------------------------------------------

--
-- Table structure for table `tblammemberreligiousinfo`
--

CREATE TABLE `tblammemberreligiousinfo` (
  `intId` bigint(20) NOT NULL,
  `varMemberId` longtext NOT NULL,
  `varMotherTongue` longtext NOT NULL,
  `varReligion` longtext NOT NULL,
  `varCasteDivision` longtext NOT NULL,
  `varSubcaste` longtext NOT NULL,
  `varGotraGothram` longtext NOT NULL,
  `varStar` longtext NOT NULL,
  `varRaasiMoonSign` longtext NOT NULL,
  `varManglik` longtext NOT NULL,
  `intHourOfBirth` int(11) NOT NULL,
  `intMinOfBirth` int(11) NOT NULL,
  `ex1` longtext NOT NULL,
  `ex2` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Dumping data for table `tblammemberreligiousinfo`
--

INSERT INTO `tblammemberreligiousinfo` (`intId`, `varMemberId`, `varMotherTongue`, `varReligion`, `varCasteDivision`, `varSubcaste`, `varGotraGothram`, `varStar`, `varRaasiMoonSign`, `varManglik`, `intHourOfBirth`, `intMinOfBirth`, `ex1`, `ex2`) VALUES
(1, 'SMM3188117', 'Marathi', 'Hindu', 'Maratha', '', '', '', '', 'No', 0, 0, '', ''),
(2, 'SMF2163628', 'Marathi', 'Hindu', 'Maratha', '', '', '', '', 'No', 0, 0, '', ''),
(3, 'SMM4866917', 'Marathi', 'Buddhist', 'Caste no bar', '', '', '', '', 'No', 0, 0, '', ''),
(4, 'SMF2266742', 'Marathi', 'Hindu', 'Ad Dharmi', '', '', '', '', 'No', 0, 0, '', ''),
(5, 'SMM4357628', 'Telugu', 'Hindu', 'Padmasali', 'Hindu padmshali', 'Pavan maharushi', 'Swathi', 'Mithun (Gemini)', 'Do not know', 6, 20, 'AM', ''),
(6, 'SMM7954118', 'Marathi', 'Hindu', 'Bhavasar Kshatriya', 'hindu bhavasar', 'NA', '', 'Mithun (Gemini)', 'Do not know', 1, 30, 'AM', ''),
(7, 'SMM7919144', 'Marathi', 'Hindu', 'Bhoi', 'raj bhoi', 'NA', '', '', 'Do not know', 9, 10, 'PM', ''),
(8, 'SMM9225535', 'Marathi', 'Hindu', 'Sonar', 'malavi', 'kashyap', '', '', 'No', 0, 0, '', ''),
(9, 'SMF1282963', 'Gujarati', 'Hindu', 'Boyar', 'Hindu padmshali', 'kashap', 'Hastha', 'Simha / Sinh (Leo)', 'Do not know', 10, 17, 'AM', ''),
(10, 'SMM2221179', 'English', 'Christian', 'Catholic', 'na', 'na', 'Jyeshta', 'Karka (Cancer)', 'Do not know', 12, 18, 'PM', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblammembershortlist`
--

CREATE TABLE `tblammembershortlist` (
  `intId` bigint(20) NOT NULL,
  `varMemberId` longtext NOT NULL,
  `varShortListMemberId` longtext NOT NULL,
  `varDate` longtext NOT NULL,
  `varTime` longtext NOT NULL,
  `ex1` longtext NOT NULL,
  `ex2` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Dumping data for table `tblammembershortlist`
--

INSERT INTO `tblammembershortlist` (`intId`, `varMemberId`, `varShortListMemberId`, `varDate`, `varTime`, `ex1`, `ex2`) VALUES
(1, 'SMF2266742', 'SMM3188117', '03-11-2015', '06 : 18 : 15', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblammembersociallogin`
--

CREATE TABLE `tblammembersociallogin` (
  `intId` bigint(20) NOT NULL,
  `varGoogleId` longtext NOT NULL,
  `varFbId` longtext NOT NULL,
  `varGEmail` longtext NOT NULL,
  `varFEmail` longtext NOT NULL,
  `varIdentityCode` longtext NOT NULL,
  `varFullname` longtext NOT NULL,
  `varsocialLink` longtext NOT NULL,
  `varGender` longtext NOT NULL,
  `varPhotoLink` longtext NOT NULL,
  `ex1` longtext NOT NULL,
  `rx2` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tblammembertransactions`
--

CREATE TABLE `tblammembertransactions` (
  `intId` bigint(20) NOT NULL,
  `varOrderNo` longtext NOT NULL,
  `varMemberId` longtext NOT NULL,
  `varMemberName` longtext NOT NULL,
  `varMemberCity` longtext NOT NULL,
  `varMemberAddress` longtext NOT NULL,
  `varMemberState` longtext NOT NULL,
  `varPackageId` longtext NOT NULL,
  `varPurchaseDate` longtext NOT NULL,
  `varPurchaseTime` longtext NOT NULL,
  `varPaymentAmount` longtext NOT NULL,
  `varPaymentStatus` longtext NOT NULL,
  `varTransactionId` longtext NOT NULL,
  `varTransactionStatus` longtext NOT NULL,
  `varPaymode` longtext NOT NULL,
  `varOrderStatus` longtext NOT NULL,
  `varFranchiseeId` longtext NOT NULL,
  `ex2` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Dumping data for table `tblammembertransactions`
--

INSERT INTO `tblammembertransactions` (`intId`, `varOrderNo`, `varMemberId`, `varMemberName`, `varMemberCity`, `varMemberAddress`, `varMemberState`, `varPackageId`, `varPurchaseDate`, `varPurchaseTime`, `varPaymentAmount`, `varPaymentStatus`, `varTransactionId`, `varTransactionStatus`, `varPaymode`, `varOrderStatus`, `varFranchiseeId`, `ex2`) VALUES
(1, '995312', 'SMF2163628', 'Amrapali Navnath Manjare', 'Solapur', '', 'Maharashtra', '472', '31-10-2015', '11 : 01 : 37', '15000', 'Paid', '123123123', 'Success', 'Cash Payment', 'Confirmed', '1', '13'),
(2, '357788', 'SMM3188117', 'Siddheshwar Kadam', 'Solapur', '', 'Maharashtra', '472', '03-11-2015', '08 : 38 : 08', '15000', 'Unpaid', '', '', 'NA', 'Started', '', '13'),
(3, '842265', 'SMM3188117', 'Siddheshwar Kadam', 'Solapur', '', 'Maharashtra', '217', '05-11-2015', '06 : 33 : 30', '1000', 'Unpaid', '', '', 'NA', 'Started', '', '1'),
(4, '815937', 'SMM3188117', 'Siddheshwar Kadam', 'Solapur', '', 'Maharashtra', '217', '08-11-2015', '08 : 39 : 00', '1000', 'Unpaid', '', '', 'NA', 'Started', '', '1'),
(5, '116768', 'SMM3188117', 'Siddheshwar Kadam', 'Solapur', '', 'Maharashtra', '832', '08-11-2015', '08 : 45 : 13', '8000', 'Unpaid', '', '', 'NA', 'Started', '', '11'),
(6, '861546', 'SMM3188117', 'Siddheshwar Kadam', 'Solapur', '', 'Maharashtra', '217', '13-11-2015', '05 : 25 : 03', '1000', 'Unpaid', '', '', 'NA', 'Started', '', '1'),
(7, '927215', 'SMM4357628', 'Sagar Naganath Raul', 'Solapur', '', 'Maharashtra', '217', '14-11-2015', '05 : 57 : 08', '1000', 'Unpaid', '', '', 'NA', 'Started', '', '1'),
(8, '954239', 'SMM9225535', 'Mayur potdar ', 'Jalgaon', '', 'Maharashtra', '217', '18-11-2015', '11 : 26 : 41', '1000', 'Unpaid', '', '', 'NA', 'Started', '', '1'),
(9, '553283', 'SMM3188117', 'Siddheshwar Kadam', 'Solapur', '', 'Maharashtra', '217', '18-11-2015', '02 : 04 : 56', '1000', 'Unpaid', '', '', 'NA', 'Started', '', '1'),
(10, '616876', 'SMM3188117', 'Siddheshwar Kadam', 'Solapur', '', 'Maharashtra', '217', '24-11-2015', '01 : 38 : 05', '1000', 'Paid', '104019582896', 'Success', 'Online Payment', 'Confirmed', '', '1');

-- --------------------------------------------------------

--
-- Table structure for table `tblammemberuploads`
--

CREATE TABLE `tblammemberuploads` (
  `intId` bigint(20) NOT NULL,
  `varMemberId` longtext NOT NULL,
  `varUploadType` longtext NOT NULL,
  `varCaption` longtext NOT NULL,
  `varPhotoType` longtext NOT NULL,
  `varUploadPath` longtext NOT NULL,
  `varVisibility` longtext NOT NULL,
  `varApproval` longtext NOT NULL,
  `ex3` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Dumping data for table `tblammemberuploads`
--

INSERT INTO `tblammemberuploads` (`intId`, `varMemberId`, `varUploadType`, `varCaption`, `varPhotoType`, `varUploadPath`, `varVisibility`, `varApproval`, `ex3`) VALUES
(1, 'SMM4357628', 'Photo', 'nothing', 'LifeStyle', 'SMM43576284.jpg', 'Viewable', 'Approved', 'NA'),
(2, 'SMM4357628', 'Photo', 'superb', 'LifeStyle', 'SMM43576281.jpg', 'Viewable', 'Approved', 'NA'),
(3, 'SMM4357628', 'Photo', 'Funtion pic', 'LifeStyle', 'SMM435762812036869_908272719267235_6197424225835904703_n.jpg', 'Viewable', 'Approved', 'NA'),
(4, 'SMM7954118', 'Photo', 'superb', 'LifeStyle', 'SMM7954118888.jpg', 'Viewable', 'Approved', 'NA'),
(5, 'SMM7954118', 'Photo', 'TRIP PIC', 'LifeStyle', 'SMM7954118888888.jpg', 'Viewable', 'Approved', 'NA'),
(6, 'SMM7954118', 'Photo', 'Funtion pic', 'LifeStyle', 'SMM795411888888.jpg', 'Viewable', 'Approved', 'NA'),
(7, 'SMF1282963', 'Photo', '', 'Selfie', 'SMF1282963Chrysanthemum.jpg', 'Hidden', 'UnApproved', 'NA'),
(8, 'SMF1282963', 'Photo', 'devi', 'Selfie', 'SMF1282963Hydrangeas.jpg', 'Protected', 'UnApproved', 'NA'),
(9, 'SMF1282963', 'Photo', '', 'Selfie', 'SMF1282963Chrysanthemum.jpg', 'Viewable', 'UnApproved', 'NA'),
(10, 'SMF1282963', 'Photo', '', 'Selfie', 'SMF1282963Tulips.jpg', 'Protected', 'UnApproved', 'NA');

-- --------------------------------------------------------

--
-- Table structure for table `tblammsendemaildetails`
--

CREATE TABLE `tblammsendemaildetails` (
  `intId` bigint(20) NOT NULL,
  `varEmailType` longtext NOT NULL,
  `varEmailTo` longtext NOT NULL,
  `varSubject` longtext NOT NULL,
  `varContentTpye` longtext NOT NULL,
  `varTextMatter` longtext NOT NULL,
  `varimg` longtext NOT NULL,
  `varDate` longtext NOT NULL,
  `varTime` longtext NOT NULL,
  `ex1` longtext NOT NULL,
  `ex2` longtext NOT NULL,
  `ex3` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tblamnotifications`
--

CREATE TABLE `tblamnotifications` (
  `intId` bigint(20) NOT NULL,
  `varNotType` longtext NOT NULL,
  `intNotFromId` longtext NOT NULL,
  `varNotFromName` longtext NOT NULL,
  `varNotFromDesig` longtext NOT NULL,
  `intNotToId` longtext NOT NULL,
  `varNotToDesig` longtext NOT NULL,
  `varNotText` longtext NOT NULL,
  `varLink` longtext NOT NULL,
  `varSession` longtext NOT NULL,
  `varStatus` longtext NOT NULL,
  `varRemark` longtext NOT NULL,
  `ex1` longtext NOT NULL,
  `ex2` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `tblamnotifications`
--

INSERT INTO `tblamnotifications` (`intId`, `varNotType`, `intNotFromId`, `varNotFromName`, `varNotFromDesig`, `intNotToId`, `varNotToDesig`, `varNotText`, `varLink`, `varSession`, `varStatus`, `varRemark`, `ex1`, `ex2`) VALUES
(2, 'Session', 'SMM3188117', 'Siddheshwar Kadam', 'Member', 'SMF2163628', 'Member', 'Your Profile is Recently Viewed By: Siddheshwar Kadam', '~/Members/SearchMatches/ViewProfile.aspx', 'SMF2163628', 'Unread', '', '', ''),
(3, 'Session', 'SMF2163628', 'Amrapali Navnath Manjare', 'Member', 'SMM4866917', 'Member', 'Your Profile is Recently Viewed By: Amrapali Navnath Manjare', '~/Members/SearchMatches/ViewProfile.aspx', 'SMM4866917', 'Read', '', '', ''),
(4, 'Session', 'SMM4866917', 'Bhushan Savale', 'Member', 'SMF2163628', 'Member', 'Your Profile is Recently Viewed By: Bhushan Savale', '~/Members/SearchMatches/ViewProfile.aspx', 'SMF2163628', 'Unread', '', '', ''),
(5, 'Session', 'SMM4866917', 'Bhushan Savale', 'Member', 'SMF2163628', 'Member', 'Your Profile is Recently Viewed By: Bhushan Savale', '~/Members/SearchMatches/ViewProfile.aspx', 'SMF2163628', 'Unread', '', '', ''),
(11, 'Session', 'SMM3188117', 'Siddheshwar Kadam', 'Member', 'SMF2266742', 'Member', 'Your Profile is Recently Viewed By: Siddheshwar Kadam', '~/Members/SearchMatches/ViewProfile.aspx', 'SMF2266742', 'Unread', '', '', ''),
(12, 'Session', 'SMM3188117', 'Siddheshwar Kadam', 'Member', 'SMF2266742', 'Member', 'Your Profile is Recently Viewed By: Siddheshwar Kadam', '~/Members/SearchMatches/ViewProfile.aspx', 'SMF2266742', 'Unread', '', '', ''),
(13, 'Session', 'SMM3188117', 'Siddheshwar Kadam', 'Member', 'SMF2163628', 'Member', 'Your Profile is Recently Viewed By: Siddheshwar Kadam', '~/Members/SearchMatches/ViewProfile.aspx', 'SMF2163628', 'Unread', '', '', ''),
(14, 'Session', 'SMM3188117', 'Siddheshwar Kadam', 'Member', 'SMF2163628', 'Member', 'Your Profile is Recently Viewed By: Siddheshwar Kadam', '~/Members/SearchMatches/ViewProfile.aspx', 'SMF2163628', 'Unread', '', '', ''),
(15, 'Session', 'SMM3188117', 'Siddheshwar Kadam', 'Member', 'SMF2163628', 'Member', 'Your Profile is Recently Viewed By: Siddheshwar Kadam', '~/Members/SearchMatches/ViewProfile.aspx', 'SMF2163628', 'Unread', '', '', ''),
(16, 'Session', 'SMM4357628', 'Sagar Naganath Raul', 'Member', '1', 'Admin', 'New Photo Uploaded...Please Approve It...', '~/Admin/Member/ApproveMembersPictures.aspx', 'SMM4357628', 'Read', '', '', ''),
(17, 'Session', 'SMM4357628', 'Sagar Naganath Raul', 'Member', '1', 'Admin', 'New Photo Uploaded...Please Approve It...', '~/Admin/Member/ApproveMembersPictures.aspx', 'SMM4357628', 'Read', '', '', ''),
(18, 'Session', 'SMM7954118', 'Shubham Devidas Garje', 'Member', '1', 'Admin', 'New Photo Uploaded...Please Approve It...', '~/Admin/Member/ApproveMembersPictures.aspx', 'SMM7954118', 'Read', '', '', ''),
(19, 'Session', 'SMM7919144', 'pratik rajkumar kamble', 'Member', '1', 'Admin', 'New Photo Uploaded...Please Approve It...', '~/Admin/Member/ApproveMembersPictures.aspx', 'SMM7919144', 'Read', '', '', ''),
(20, 'Session', 'SMM7954118', 'Shubham Devidas Garje', 'Member', 'SMF2163628', 'Member', 'New Interest from : Shubham Devidas Garje', '~/Members/SearchMatches/ViewProfile.aspx', 'SMF2163628', 'Unread', '', '', ''),
(21, 'Session', 'SMM3188117', 'Siddheshwar Kadam', 'Member', 'SMF2266742', 'Member', 'Your Profile is Recently Viewed By: Siddheshwar Kadam', '~/Members/SearchMatches/ViewProfile.aspx', 'SMF2266742', 'Unread', '', '', ''),
(22, 'Session', 'SMF2163628', 'Amrapali Navnath Manjare', 'Member', 'SMM7954118', 'Member', 'Your Profile is Recently Viewed By: Amrapali Navnath Manjare', '~/Members/SearchMatches/ViewProfile.aspx', 'SMM7954118', 'Unread', '', '', ''),
(23, 'Session', 'SMM3188117', 'Siddheshwar Kadam', 'Member', 'SMF2163628', 'Member', 'Your Profile is Recently Viewed By: Siddheshwar Kadam', '~/Members/SearchMatches/ViewProfile.aspx', 'SMF2163628', 'Unread', '', '', ''),
(24, 'Session', 'SMM3188117', 'Siddheshwar Kadam', 'Member', 'SMF2266742', 'Member', 'Your Profile is Recently Viewed By: Siddheshwar Kadam', '~/Members/SearchMatches/ViewProfile.aspx', 'SMF2266742', 'Unread', '', '', ''),
(25, 'Session', 'SMM9225535', 'Mayur potdar ', 'Member', '1', 'Admin', 'New Photo Uploaded...Please Approve It...', '~/Admin/Member/ApproveMembersPictures.aspx', 'SMM9225535', 'Read', '', '', ''),
(27, 'Session', 'SMM3188117', 'Siddheshwar Kadam', 'Member', 'SMF2163628', 'Member', 'Your Profile is Recently Viewed By: Siddheshwar Kadam', '~/Members/SearchMatches/ViewProfile.aspx', 'SMF2163628', 'Unread', '', '', ''),
(28, 'Session', 'SMM3188117', 'Siddheshwar Kadam', 'Member', 'SMF2266742', 'Member', 'Your Profile is Recently Viewed By: Siddheshwar Kadam', '~/Members/SearchMatches/ViewProfile.aspx', 'SMF2266742', 'Unread', '', '', ''),
(29, 'Session', 'SMM3188117', 'Siddheshwar Kadam', 'Member', 'SMF2163628', 'Member', 'Your Profile is Recently Viewed By: Siddheshwar Kadam', '~/Members/SearchMatches/ViewProfile.aspx', 'SMF2163628', 'Unread', '', '', ''),
(30, 'Session', 'SMM3188117', 'Siddheshwar Kadam', 'Member', 'SMF2163628', 'Member', 'Your Profile is Recently Viewed By: Siddheshwar Kadam', '~/Members/SearchMatches/ViewProfile.aspx', 'SMF2163628', 'Unread', '', '', ''),
(31, 'Message', '1', 'Siddha Matrimony', 'Admin', 'SMFR8757762', 'Franchisee', 'Packages are Upgraded,Please Inform the Members...Siddha Matrimony', '', '', 'Unread', '', '', ''),
(32, 'Message', '1', 'Siddha Matrimony', 'Admin', 'SMFR8757762', 'Franchisee', 'Packages are Upgraded,Please Inform the Members...Siddha Matrimony', '', '', 'Unread', '', '', ''),
(33, 'Message', '1', 'Siddha Matrimony', 'Admin', 'SMFR8757762', 'Franchisee', 'Packages are Upgraded,Please Inform the Members...Siddha Matrimony', '', '', 'Unread', '', '', ''),
(34, 'Message', '1', 'Siddha Matrimony', 'Admin', 'SMFR8757762', 'Franchisee', 'Packages are Upgraded,Please Inform the Members...Siddha Matrimony', '', '', 'Unread', '', '', ''),
(35, 'Message', '1', 'Siddha Matrimony', 'Admin', 'SMFR8757762', 'Franchisee', 'Packages are Upgraded,Please Inform the Members...Siddha Matrimony', '', '', 'Unread', '', '', ''),
(36, 'Message', '1', 'Siddha Matrimony', 'Admin', 'SMFR8757762', 'Franchisee', 'Packages are Upgraded,Please Inform the Members...Siddha Matrimony', '', '', 'Unread', '', '', ''),
(37, 'Message', '1', 'Siddha Matrimony', 'Admin', 'SMFR8757762', 'Franchisee', 'Packages are Upgraded,Please Inform the Members...Siddha Matrimony', '', '', 'Unread', '', '', ''),
(38, 'Message', '1', 'Siddha Matrimony', 'Admin', 'SMFR8757762', 'Franchisee', 'Packages are Upgraded,Please Inform the Members...Siddha Matrimony', '', '', 'Unread', '', '', ''),
(39, 'Message', '1', 'Siddha Matrimony', 'Admin', 'SMM9225535', 'Member', 'Congratulations !!! Your Profile Photo is Approved...', '', '', 'Unread', '', '', ''),
(40, 'Message', '1', 'Siddha Matrimony', 'Admin', 'SMM4357628', 'Member', 'Congratulations !!! Your Profile Photo is Approved...', '', '', 'Unread', '', '', ''),
(41, 'Page', '1', 'Siddha Matrimony', 'Admin', 'SMM4357628', 'Member', 'Congratulations !!! Your Photo SMM435762812036869_908272719267235_6197424225835904703_n.jpg is Approved...', '~/members/Photo/InfoUpload.aspx', '', 'Unread', '', '', ''),
(42, 'Page', '1', 'Siddha Matrimony', 'Admin', 'SMM4357628', 'Member', 'Congratulations !!! Your Photo SMM43576281.jpg is Approved...', '~/members/Photo/InfoUpload.aspx', '', 'Unread', '', '', ''),
(43, 'Page', '1', 'Siddha Matrimony', 'Admin', 'SMM4357628', 'Member', 'Congratulations !!! Your Photo SMM43576284.jpg is Approved...', '~/members/Photo/InfoUpload.aspx', '', 'Unread', '', '', ''),
(44, 'Page', '1', 'Siddha Matrimony', 'Admin', 'SMM7954118', 'Member', 'Congratulations !!! Your Photo SMM7954118888.jpg is Approved...', '~/members/Photo/InfoUpload.aspx', '', 'Unread', '', '', ''),
(45, 'Page', '1', 'Siddha Matrimony', 'Admin', 'SMM7954118', 'Member', 'Congratulations !!! Your Photo SMM7954118888888.jpg is Approved...', '~/members/Photo/InfoUpload.aspx', '', 'Unread', '', '', ''),
(46, 'Page', '1', 'Siddha Matrimony', 'Admin', 'SMM7954118', 'Member', 'Congratulations !!! Your Photo SMM795411888888.jpg is Approved...', '~/members/Photo/InfoUpload.aspx', '', 'Unread', '', '', ''),
(47, 'Message', '1', 'Siddha Matrimony', 'Admin', 'SMM7954118', 'Member', 'Congratulations !!! Your Profile Photo is Approved...', '', '', 'Unread', '', '', ''),
(48, 'Session', 'SMM4866917', 'Bhushan Savale', 'Member', 'SMF2163628', 'Member', 'Your Profile is Recently Viewed By: Bhushan Savale', '~/Members/SearchMatches/ViewProfile.aspx', 'SMF2163628', 'Unread', '', '', ''),
(53, 'Message', 'SMF1282963', 'shriya mishra', 'Member', 'SMF1282963', 'Member', 'You recently changed your Password if not please contact support', '', '', 'Read', '', '', ''),
(54, 'Session', 'SMFR2842719', '1', 'Franchisee', '1', 'Admin', 'New Franchisee registeres', '~/Admin/Franchisee/ViewFranchiseeProfile.aspx', 'SMFR2842719', 'Unread', '', '', ''),
(55, 'Session', 'SMM4866917', 'Bhushan Savale', 'Member', 'SMF1282963', 'Member', 'Your Profile is Recently Viewed By: Bhushan Savale', '~/Members/SearchMatches/ViewProfile.aspx', 'SMF1282963', 'Unread', '', '', ''),
(56, 'Session', 'SMM4866917', 'Bhushan Savale', 'Member', 'SMF2163628', 'Member', 'Your Profile is Recently Viewed By: Bhushan Savale', '~/Members/SearchMatches/ViewProfile.aspx', 'SMF2163628', 'Unread', '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblampackages`
--

CREATE TABLE `tblampackages` (
  `intId` bigint(20) NOT NULL,
  `varPackageId` longtext NOT NULL,
  `varPackageName` longtext NOT NULL,
  `ex2` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Dumping data for table `tblampackages`
--

INSERT INTO `tblampackages` (`intId`, `varPackageId`, `varPackageName`, `ex2`) VALUES
(1, '217', 'Silver', ''),
(2, '621', 'Gold', ''),
(3, '813', 'Platinum', ''),
(4, '832', 'Dimond', ''),
(5, '472', 'Super Dimond', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblampackagesdetails`
--

CREATE TABLE `tblampackagesdetails` (
  `intId` bigint(20) NOT NULL,
  `varPackageId` longtext NOT NULL,
  `varPackageDescription` longtext NOT NULL,
  `varPackageDuration` longtext NOT NULL,
  `varPackageDurationTime` longtext NOT NULL,
  `varPackagePrice` longtext NOT NULL,
  `varBenifits` longtext NOT NULL,
  `ex1` longtext NOT NULL,
  `ex2` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Dumping data for table `tblampackagesdetails`
--

INSERT INTO `tblampackagesdetails` (`intId`, `varPackageId`, `varPackageDescription`, `varPackageDuration`, `varPackageDurationTime`, `varPackagePrice`, `varBenifits`, `ex1`, `ex2`) VALUES
(1, '217', '30 contact List and Unlimited Mail and messages \r\n', '3', 'Month', '1000', '30 contact List and Unlimited Mail and messages \r\n', '30', ''),
(2, '217', '50 contact List and Unlimited Mail and messages\r\n', '6', 'Month', '2500', '50 contact List and Unlimited Mail and messages\r\n', '50', ''),
(3, '217', '80 contact List and Unlimited Mail and messages\r\n', '9', 'Month', '4500', '80 contact List and Unlimited Mail and messages\r\n', '80', ''),
(4, '621', '40 contact List and Unlimited Mail and messages Highlight profile for 1 month\r\n', '3', 'Month', '1500', '40 contact List and Unlimited Mail and messages Highlight profile for 1 month\r\n', '40', ''),
(5, '621', '60 contact List and Unlimited Mail and messages Highlight profile for 1 month\r\n', '6', 'Month', '3500', '60 contact List and Unlimited Mail and messages Highlight profile for 1 month\r\n', '60', ''),
(6, '621', '100 contact List and Unlimited Mail and messages Highlight profile for 1 month\r\n', '9', 'Month', '5000', '100 contact List and Unlimited Mail and messages Highlight profile for 1 month\r\n', '100', ''),
(7, '813', '50 contact List and Unlimited Mail and messages Highlight profile for 2 month\r\n', '3', 'Year', '2000', '50 contact List and Unlimited Mail and messages Highlight profile for 2 month\r\n', '50', ''),
(8, '813', '75 contact List and Unlimited Mail and messages Highlight profile for 2 month\r\n', '6', 'Month', '4000', '75 contact List and Unlimited Mail and messages Highlight profile for 2 month\r\n', '75', ''),
(9, '813', '150 contact List and Unlimited Mail and messages Highlight profile for 2 month\r\n', '9', 'Month', '5500', '150 contact List and Unlimited Mail and messages Highlight profile for 2 month\r\n', '150', ''),
(10, '832', '150 Cantactand unlimited Email and messages.Highlight profile for 3 month\r\n', '3', 'Month', '6000', '150 Cantactand unlimited Email and messages.Highlight profile for 3 month\r\n', '150', ''),
(11, '832', '250 Cantact and unlimited Email and messages.Highlight profile for 6 month\r\n', '6', 'Month', '8000', '250 Cantact and unlimited Email and messages.Highlight profile for 6 month\r\n', '250', ''),
(12, '832', '300 Cantact, Unlimited Email and messages..Highlight profile for 9 month\r\n', '9', 'Month', '10000', '300 Cantact, Unlimited Email and messages..Highlight profile for 9 month\r\n', '300', ''),
(13, '472', '1 year: Unlimited contact mails and Messages and highlight profile for 9 months			\r\n', '1', 'Year', '15000', '1 year: Unlimited contact mails and Messages and highlight profile for 9 months		\r\n', '10000', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblampersonnel`
--

CREATE TABLE `tblampersonnel` (
  `intId` bigint(20) NOT NULL,
  `varFranchiseeId` longtext NOT NULL,
  `varName` longtext NOT NULL,
  `varDesignation` longtext NOT NULL,
  `varAddress` longtext NOT NULL,
  `varCity` longtext NOT NULL,
  `varState` longtext NOT NULL,
  `varCountry` longtext NOT NULL,
  `varPinCode` longtext NOT NULL,
  `varEmail` longtext NOT NULL,
  `varEmailVerify` longtext NOT NULL,
  `varMobile` longtext NOT NULL,
  `varMobileVerify` longtext NOT NULL,
  `varLandline` longtext NOT NULL,
  `varPassword` longtext NOT NULL,
  `varRegDate` longtext NOT NULL,
  `varRegTime` longtext NOT NULL,
  `varStatus` longtext NOT NULL,
  `varProfilePic` longtext NOT NULL,
  `ex2` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Dumping data for table `tblampersonnel`
--

INSERT INTO `tblampersonnel` (`intId`, `varFranchiseeId`, `varName`, `varDesignation`, `varAddress`, `varCity`, `varState`, `varCountry`, `varPinCode`, `varEmail`, `varEmailVerify`, `varMobile`, `varMobileVerify`, `varLandline`, `varPassword`, `varRegDate`, `varRegTime`, `varStatus`, `varProfilePic`, `ex2`) VALUES
(1, 'ADM111111', 'Siddha Matrimony', 'Admin', 'jalgaon', 'Jalgaon', 'Maharashtra', 'India', '65757', 'swapnpurtimatrimony@gmail.com', 'true', '8055505050', 'true', '4546556', 'Siddha@2015', '08-09-2015', '02 : 49 : 50', 'Active', 'matrimony logo heart.png', ''),
(2, 'SMFR8757762', 'Mayuri Potdar', 'Franchisee', '', '', '', '', '', 'patiljyoti612@gmail.com', 'true', '9561421489', '87577627', '', 'aaaaaa', '27-10-2015', '12 : 19 : 59', 'Approve', 'NoProfile.jpg', ''),
(3, 'SMFR2842719', '1', 'Franchisee', '', '', '', '', '', '1', '28427198', '1', '28427198', '', '1', '03-12-2015', '03 : 45 : 41', 'Inactive', 'NoProfile.jpg', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblampersonnelbankdetails`
--

CREATE TABLE `tblampersonnelbankdetails` (
  `intId` bigint(20) NOT NULL,
  `varFranchiseeId` bigint(20) NOT NULL,
  `varBankName` longtext NOT NULL,
  `varBankCity` longtext NOT NULL,
  `varBankBranch` longtext NOT NULL,
  `varBankIfsc` longtext NOT NULL,
  `varBankMcir` longtext NOT NULL,
  `varAccountHolderName` longtext NOT NULL,
  `varAccountNumber` longtext NOT NULL,
  `varAccountType` longtext NOT NULL,
  `ex1` longtext NOT NULL,
  `ex2` longtext NOT NULL,
  `ex3` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `tblamprofilestatus`
--

CREATE TABLE `tblamprofilestatus` (
  `intId` bigint(20) NOT NULL,
  `varLoginId` longtext NOT NULL,
  `varDesignation` longtext NOT NULL,
  `varStatus` longtext NOT NULL,
  `varReason` longtext NOT NULL,
  `varDateOfMarriage` longtext NOT NULL,
  `varExperience` longtext NOT NULL,
  `varDate` longtext NOT NULL,
  `varTime` longtext NOT NULL,
  `ex1` longtext NOT NULL,
  `ex2` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

-- --------------------------------------------------------

--
-- Table structure for table `tblamrequests`
--

CREATE TABLE `tblamrequests` (
  `intId` bigint(20) NOT NULL,
  `varFromMemberId` longtext NOT NULL,
  `varFromMembarName` longtext NOT NULL,
  `varFromMemberStatus` longtext NOT NULL,
  `varToMemberId` longtext NOT NULL,
  `varToMembarName` longtext NOT NULL,
  `varToMemberStatus` longtext NOT NULL,
  `varRequestType` longtext NOT NULL,
  `varStatus` longtext NOT NULL,
  `varDate` longtext NOT NULL,
  `varTime` longtext NOT NULL,
  `varRequestShortType` longtext NOT NULL,
  `ex2` longtext NOT NULL,
  `ex3` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

-- --------------------------------------------------------

--
-- Table structure for table `tblamsuccessstories`
--

CREATE TABLE `tblamsuccessstories` (
  `intId` bigint(20) NOT NULL,
  `varMemberId` longtext NOT NULL,
  `varPartnerId` longtext NOT NULL,
  `varMemberName` longtext NOT NULL,
  `varPartnerName` longtext NOT NULL,
  `varUploaderId` longtext NOT NULL,
  `varUploaderDesignation` longtext NOT NULL,
  `varEngagementDate` longtext NOT NULL,
  `varWeddingDate` longtext NOT NULL,
  `varWeddingLocation` longtext NOT NULL,
  `varCurrentAdddress` longtext NOT NULL,
  `vaCurrentrCountry` longtext NOT NULL,
  `varCurrentState` longtext NOT NULL,
  `varCurrentCity` longtext NOT NULL,
  `varCurrentContact` longtext NOT NULL,
  `varDescription` longtext NOT NULL,
  `varPhoto` longtext NOT NULL,
  `varStatus` longtext NOT NULL,
  `varEmail` longtext NOT NULL,
  `ex2` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

-- --------------------------------------------------------

--
-- Table structure for table `tblmembercontactviewscount`
--

CREATE TABLE `tblmembercontactviewscount` (
  `intId` bigint(20) NOT NULL,
  `varMemberId` longtext NOT NULL,
  `varToView` longtext NOT NULL,
  `varViewed` longtext NOT NULL,
  `ex1` longtext NOT NULL,
  `ex2` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `tblmembercontactviewscount`
--

INSERT INTO `tblmembercontactviewscount` (`intId`, `varMemberId`, `varToView`, `varViewed`, `ex1`, `ex2`) VALUES
(1, 'SMM3188117', '30', '26', '', ''),
(2, 'SMF2163628', '10000', '10000', '', ''),
(3, 'SMM4866917', '0', '0', '', ''),
(4, 'SMF2266742', '0', '0', '', ''),
(5, 'SMM4357628', '0', '0', '', ''),
(6, 'SMM7954118', '0', '0', '', ''),
(7, 'SMM7919144', '0', '0', '', ''),
(8, 'SMM9225535', '0', '0', '', ''),
(9, 'SMF1282963', '0', '0', '', ''),
(10, 'SMM2221179', '0', '0', '', '');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tblamcommunication`
--
ALTER TABLE `tblamcommunication`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblamconversation`
--
ALTER TABLE `tblamconversation`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblamemberpartnercaste`
--
ALTER TABLE `tblamemberpartnercaste`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblamemberpartnerlanguages`
--
ALTER TABLE `tblamemberpartnerlanguages`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblamemberpartnermothertongue`
--
ALTER TABLE `tblamemberpartnermothertongue`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblamemberpartnersubcaste`
--
ALTER TABLE `tblamemberpartnersubcaste`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblamemberview`
--
ALTER TABLE `tblamemberview`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblamloginentry`
--
ALTER TABLE `tblamloginentry`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblammembercontactdetails`
--
ALTER TABLE `tblammembercontactdetails`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblammemberemailcode`
--
ALTER TABLE `tblammemberemailcode`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblammemberfamily`
--
ALTER TABLE `tblammemberfamily`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblammemberinformation`
--
ALTER TABLE `tblammemberinformation`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblammemberinterests`
--
ALTER TABLE `tblammemberinterests`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblammemberlifestyle`
--
ALTER TABLE `tblammemberlifestyle`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblammemberlivingin`
--
ALTER TABLE `tblammemberlivingin`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblammemberpartnerarea`
--
ALTER TABLE `tblammemberpartnerarea`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblammemberpartnerbasic`
--
ALTER TABLE `tblammemberpartnerbasic`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblammemberpartnereducation`
--
ALTER TABLE `tblammemberpartnereducation`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblammemberpartneremploy`
--
ALTER TABLE `tblammemberpartneremploy`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblammemberpartnerincome`
--
ALTER TABLE `tblammemberpartnerincome`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblammemberpartnerreligious`
--
ALTER TABLE `tblammemberpartnerreligious`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblammemberphysicalinformation`
--
ALTER TABLE `tblammemberphysicalinformation`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblammemberprofessionalinfo`
--
ALTER TABLE `tblammemberprofessionalinfo`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblammemberregistration`
--
ALTER TABLE `tblammemberregistration`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblammemberreligiousinfo`
--
ALTER TABLE `tblammemberreligiousinfo`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblammembershortlist`
--
ALTER TABLE `tblammembershortlist`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblammembersociallogin`
--
ALTER TABLE `tblammembersociallogin`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblammembertransactions`
--
ALTER TABLE `tblammembertransactions`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblammemberuploads`
--
ALTER TABLE `tblammemberuploads`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblammsendemaildetails`
--
ALTER TABLE `tblammsendemaildetails`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblamnotifications`
--
ALTER TABLE `tblamnotifications`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblampackages`
--
ALTER TABLE `tblampackages`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblampackagesdetails`
--
ALTER TABLE `tblampackagesdetails`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblampersonnel`
--
ALTER TABLE `tblampersonnel`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblampersonnelbankdetails`
--
ALTER TABLE `tblampersonnelbankdetails`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblamprofilestatus`
--
ALTER TABLE `tblamprofilestatus`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblamrequests`
--
ALTER TABLE `tblamrequests`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblamsuccessstories`
--
ALTER TABLE `tblamsuccessstories`
  ADD PRIMARY KEY (`intId`);

--
-- Indexes for table `tblmembercontactviewscount`
--
ALTER TABLE `tblmembercontactviewscount`
  ADD PRIMARY KEY (`intId`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
