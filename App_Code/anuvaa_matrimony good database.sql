-- phpMyAdmin SQL Dump
-- version 4.4.14
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Oct 30, 2015 at 01:50 PM
-- Server version: 5.6.26
-- PHP Version: 5.6.12

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

CREATE TABLE IF NOT EXISTS `hitscount` (
  `intId` bigint(20) NOT NULL,
  `Hits` int(11) NOT NULL,
  `ex1` int(11) NOT NULL,
  `ex2` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Dumping data for table `hitscount`
--

INSERT INTO `hitscount` (`intId`, `Hits`, `ex1`, `ex2`) VALUES
(1, 1139, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `tblamcommunication`
--

CREATE TABLE IF NOT EXISTS `tblamcommunication` (
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

CREATE TABLE IF NOT EXISTS `tblamconversation` (
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

CREATE TABLE IF NOT EXISTS `tblamemailpreferences` (
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

CREATE TABLE IF NOT EXISTS `tblamemberpartnercaste` (
  `intId` bigint(20) NOT NULL,
  `varMemberId` longtext NOT NULL,
  `varCaste` longtext NOT NULL,
  `ex1` longtext NOT NULL,
  `ex2` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

-- --------------------------------------------------------

--
-- Table structure for table `tblamemberpartnerlanguages`
--

CREATE TABLE IF NOT EXISTS `tblamemberpartnerlanguages` (
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

CREATE TABLE IF NOT EXISTS `tblamemberpartnermothertongue` (
  `intId` bigint(20) NOT NULL,
  `varMemberId` longtext NOT NULL,
  `varMotherTongue` longtext NOT NULL,
  `ex1` longtext NOT NULL,
  `ex2` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

-- --------------------------------------------------------

--
-- Table structure for table `tblamemberpartnersubcaste`
--

CREATE TABLE IF NOT EXISTS `tblamemberpartnersubcaste` (
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

CREATE TABLE IF NOT EXISTS `tblamemberview` (
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
(1, 'SMM6751741', 'SMM6751741', '24-10-2015', '03 : 50 : 25', '', ''),
(2, 'SMM6751741', 'SMF7682739', '30-10-2015', '09 : 30 : 02', '', ''),
(3, 'SMM6751741', 'SMF5489122', '30-10-2015', '09 : 54 : 17', '', ''),
(4, 'SMF5489122', 'SMM6751741', '31-10-2015', '06 : 13 : 27', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblamloginentry`
--

CREATE TABLE IF NOT EXISTS `tblamloginentry` (
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

CREATE TABLE IF NOT EXISTS `tblammembercontactdetails` (
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
(2, 'SMM6751741', '', '', '', '', '', '', 'Jalgaon', '', '', '', '', '', ''),
(3, 'SMF7682739', '', '', '', '', '', '', '', '', '', '', '', '', ''),
(5, 'SMF5489122', '', '', '', '', '', '', 'sidkheda,dhule', '', '', '', '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblammemberemailcode`
--

CREATE TABLE IF NOT EXISTS `tblammemberemailcode` (
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
(1, 'SMM4528635', '117191919231575', '', '', '', '', ''),
(2, 'SMF7682739', '931845265276669', '', '', '', '', ''),
(3, 'SMF5489122', '748748748748748', '', '', '', '', ''),
(4, 'SMM6751741', '145214521452145', '', '', '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblammemberfamily`
--

CREATE TABLE IF NOT EXISTS `tblammemberfamily` (
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
(2, 'SMM6751741', '', '', '', '', '', '', '', '', '', 'Middle class', 'Joint', 'Orthodox', '', '', '', ''),
(3, 'SMF7682739', '', '', '', '', '', '', '', '', '', 'Middle class', 'Joint', 'Traditional', '', '', '', ''),
(5, 'SMF5489122', '', '', '', '', '', '', '', '', '', 'Middle class', 'Joint', 'Orthodox', '', '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblammemberinformation`
--

CREATE TABLE IF NOT EXISTS `tblammemberinformation` (
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
(2, 'SMM6751741', 6, 'August', 1989, 27, 'Never Married', 'NA', 0, 'ggggg', '', '', '', ''),
(3, 'SMF7682739', 16, 'March', 1983, 33, 'Never Married', 'NA', 0, '', '', '', '', ''),
(5, 'SMF5489122', 6, 'December', 1989, 26, 'Never Married', 'NA', 0, 'hjkj', '', '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblammemberinterests`
--

CREATE TABLE IF NOT EXISTS `tblammemberinterests` (
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
(1, 'SMM6751741', 'SMF5489122', '30-10-2015', '09 : 55 : 18', '', ''),
(2, 'SMF5489122', 'SMM6751741', '30-10-2015', '09 : 55 : 44', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblammemberlifestyle`
--

CREATE TABLE IF NOT EXISTS `tblammemberlifestyle` (
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
(2, 'SMM6751741', 'Vegetarian', 'Yes', 'Yes', '', '', '', '', '', '', '', '', ''),
(3, 'SMF7682739', 'Non-Vegetarian', 'No', 'No', '', '', '', '', '', '', '', '', ''),
(5, 'SMF5489122', 'Vegetarian', 'Yes', 'Yes', '', '', '', '', '', '', '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblammemberlivingin`
--

CREATE TABLE IF NOT EXISTS `tblammemberlivingin` (
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
(2, 'SMM6751741', 'India', 'India', 'Maharashtra', 'Jalgaon', '', ''),
(3, 'SMF7682739', 'India', 'India', 'Maharashtra', 'Solapur', '', ''),
(5, 'SMF5489122', 'India', 'India', 'Maharashtra', 'Dhule', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblammemberpartnerarea`
--

CREATE TABLE IF NOT EXISTS `tblammemberpartnerarea` (
  `intId` bigint(20) NOT NULL,
  `varMemberId` longtext,
  `varFinctionalArea` longtext,
  `ex1` longtext,
  `ex2` longtext,
  `ex3` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

-- --------------------------------------------------------

--
-- Table structure for table `tblammemberpartnerbasic`
--

CREATE TABLE IF NOT EXISTS `tblammemberpartnerbasic` (
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
(2, 'SMM6751741', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', ''),
(3, 'SMF7682739', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', ''),
(5, 'SMF5489122', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblammemberpartnereducation`
--

CREATE TABLE IF NOT EXISTS `tblammemberpartnereducation` (
  `intId` bigint(20) NOT NULL,
  `varMemberId` longtext,
  `varEducation` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

-- --------------------------------------------------------

--
-- Table structure for table `tblammemberpartneremploy`
--

CREATE TABLE IF NOT EXISTS `tblammemberpartneremploy` (
  `intId` bigint(20) NOT NULL,
  `varMemberId` longtext,
  `varEmployedSector` longtext,
  `ex1` longtext,
  `ex2` longtext,
  `ex3` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

-- --------------------------------------------------------

--
-- Table structure for table `tblammemberpartnerincome`
--

CREATE TABLE IF NOT EXISTS `tblammemberpartnerincome` (
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
(2, 'SMM6751741', '', '', '', '', ''),
(3, 'SMF7682739', '', '', '', '', ''),
(5, 'SMF5489122', '', '', '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblammemberpartnerreligious`
--

CREATE TABLE IF NOT EXISTS `tblammemberpartnerreligious` (
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
(2, 'SMM6751741', '', '', '', '', '', '', ''),
(3, 'SMF7682739', '', '', '', '', '', '', ''),
(5, 'SMF5489122', '', '', '', '', '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblammemberphysicalinformation`
--

CREATE TABLE IF NOT EXISTS `tblammemberphysicalinformation` (
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
(2, 'SMM6751741', '5ft 4in', '162Cms', '60Kg', 'Slim', 'Fair', 'B+', 'None ', '133Lbs'),
(3, 'SMF7682739', '5ft 5in', '165Cms', '65Kg', 'Athletic', 'Wheatish', 'B+', 'None ', '143Lbs'),
(5, 'SMF5489122', '5ft 6in', '167Cms', '58Kg', 'Average', 'Wheatish Medium', 'O+', 'None ', '128Lbs');

-- --------------------------------------------------------

--
-- Table structure for table `tblammemberprofessionalinfo`
--

CREATE TABLE IF NOT EXISTS `tblammemberprofessionalinfo` (
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
(2, 'SMM6751741', 'MCA', 'No', '', '', 'Private Sector ', 'Supervisor', '', 10000, 'INR - Indian Rupee', '', '', '', ''),
(3, 'SMF7682739', 'BE', '', '', '', 'Private Sector ', 'Software Professional', '', 800000, 'INR - Indian Rupee', '', '', '', ''),
(5, 'SMF5489122', 'MCA', 'no degree', '', '', 'Private Sector ', 'Software Professional', '', 12000, 'INR - Indian Rupee', '', '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblammemberregistration`
--

CREATE TABLE IF NOT EXISTS `tblammemberregistration` (
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
(1, 'SMM4528635', 'Unpaid', 'Myself', 'Siddheshwar Kadam', 'Male', 8055505050, '45286359', 'om21kadam@gmail.com', 'true', 'VerifiedFirstTime', 'NA', 'NA', 'Member', '13-10-2015', '07 : 31 : 37', 'om21kadam', 'MaleNoProfile.jpg', 'UnApproved', 'Viewable'),
(2, 'SMM6751741', 'Paid', 'Son', 'Bhushan Savale', 'Male', 9561421489, '67517417', 'savalebd@gmail.com', 'true', 'Verified', 'NA', 'NA', 'Member', '14-10-2015', '02 : 45 : 13', '123', 'SMM6751741.jpg', 'Approved', 'Viewable'),
(3, 'SMF7682739', 'Unpaid', 'Daughter', 'Amrapali Navnath Manjare', 'Female', 9028553339, '76827398', 'manjare.amrapali@gmail.com', 'true', 'Verified', 'NA', 'NA', 'Member', '18-10-2015', '03 : 36 : 56', 'tesy123', 'FemaleNoProfile.jpg', 'Approved', 'NA'),
(4, 'SMM8661172', 'Unpaid', 'Myself', 'Mayur Potdar', 'Male', 9620961818, '86611722', 'edmithra@gmail.com', 'true', 'VerifiedFirstTime', 'SMFR8757762', 'NA', 'Franchisee', '27-10-2015', '12 : 22 : 50', '123', 'MaleNoProfile.jpg', 'Approved', 'NA'),
(5, 'SMM7925997', 'Unpaid', 'Myself', 'pramod chandrakant chinchure', 'Male', 9960433051, '79259973', 'pramodchinchure1@gmail.com', 'true', 'VerifiedFirstTime', 'NA', 'NA', 'Member', '27-10-2015', '05 : 26 : 40', '79259973', 'MaleNoProfile.jpg', 'Approved', 'NA'),
(6, 'SMF5489122', 'Unpaid', 'Myself', 'Jyoti Patil', 'Female', 0, '54891224', 'patiljyoti612@gmail.com', 'true', 'Verified', 'Member', 'NA', 'Member', '30-10-2015', '09 : 33 : 56', '123', 'SMF5489122.jpg', 'UnApproved', 'Viewable');

-- --------------------------------------------------------

--
-- Table structure for table `tblammemberreligiousinfo`
--

CREATE TABLE IF NOT EXISTS `tblammemberreligiousinfo` (
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
(2, 'SMM6751741', 'Hindi', 'Hindu', 'Kunbi', 'No', 'No', '', '', 'No', 0, 0, '', ''),
(3, 'SMF7682739', 'Marathi', 'Hindu', 'Maratha', '', '', '', '', 'No', 0, 0, '', ''),
(5, 'SMF5489122', 'Marathi', 'Hindu', 'Kunbi', 'no sub caste', 'no gotra', '', '', 'Do not know', 0, 0, '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblammembershortlist`
--

CREATE TABLE IF NOT EXISTS `tblammembershortlist` (
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
(1, 'SMF5489122', 'SMM6751741', '30-10-2015', '09 : 55 : 32', '', ''),
(2, 'SMM6751741', 'SMF5489122', '30-10-2015', '09 : 58 : 50', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblammembersociallogin`
--

CREATE TABLE IF NOT EXISTS `tblammembersociallogin` (
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

CREATE TABLE IF NOT EXISTS `tblammembertransactions` (
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
(2, '635469', 'SMM6751741', 'Bhushan Savale', 'Jalgaon', '', 'Maharashtra', '217', '14-10-2015', '04 : 33 : 04', '1000', 'Paid', 'dc5372e9e5d63f2b5706', 'Success', 'Online Payment', 'Confirmed', '', '1'),
(5, '131759', 'SMM6751741', 'Bhushan Savale', 'Jalgaon', '', 'Maharashtra', '217', '27-10-2015', '09 : 36 : 49', '1', 'Paid', '104016940953', 'Success', 'Online Payment', 'Confirmed', '', '1'),
(6, '663343', 'SMF7682739', 'Amrapali Navnath Manjare', 'Solapur', '', 'Maharashtra', '217', '27-10-2015', '12 : 43 : 05', '2500', 'Unpaid', '', '', 'NA', 'Started', '', '2'),
(7, '283853', 'SMM8661172', 'Mayur Potdar', '', '', '', '217', '27-10-2015', '12 : 44 : 49', '2500', 'Unpaid', '', '', 'NA', 'Started', '', '2');

-- --------------------------------------------------------

--
-- Table structure for table `tblammemberuploads`
--

CREATE TABLE IF NOT EXISTS `tblammemberuploads` (
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

-- --------------------------------------------------------

--
-- Table structure for table `tblammsendemaildetails`
--

CREATE TABLE IF NOT EXISTS `tblammsendemaildetails` (
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

CREATE TABLE IF NOT EXISTS `tblamnotifications` (
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
(1, 'Message', '1', 'Swapnpurti Matrimony', 'Admin', 'SMFR6954228', 'Franchisee', 'Your Profile is Edited By  :Swapnpurti Matrimony', '', '', 'Unread', '', '', ''),
(2, 'Message', '1', 'Swapnpurti Matrimony', 'Admin', 'SMM6751741', 'Member', 'Congratulations !!! Your Profile Photo is Approved...', '', '', 'Read', '', '', ''),
(3, 'Session', 'SMM6751741', 'Bhushan Savale', 'Member', 'SMF7682739', 'Member', 'Your Profile is Recently Viewed By: Bhushan Savale', '~/Members/SearchMatches/ViewProfile.aspx', 'SMF7682739', 'Unread', '', '', ''),
(4, 'Session', 'SMM6751741', 'Bhushan Savale', 'Member', 'SMF7682739', 'Member', 'Your Profile is Recently Viewed By: Bhushan Savale', '~/Members/SearchMatches/ViewProfile.aspx', 'SMF7682739', 'Unread', '', '', ''),
(5, 'Message', 'SMM6751741', '', 'Member', 'SMM6751741', 'Member', 'You Package Order is Confirmed...!!!', '', '', 'Read', '', '', ''),
(6, 'Page', 'SMFR8757762', 'Mayuri Potdar', 'Franchisee', '1', 'Admin', 'New Franchisee registeres', '~/Admin/Franchisee/ViewFranchisee.aspx', '', 'Read', '', '', ''),
(7, 'Message', '1', 'Swapnpurti Matrimony', 'Admin', 'SMFR8757762', 'Franchisee', ' Congratulations !!! Your Profile is Approved...', '', '', 'Read', '', '', ''),
(8, 'Session', 'SMM6751741', 'Bhushan Savale', 'Member', 'SMF7682739', 'Member', 'Your Profile is Recently Viewed By: Bhushan Savale', '~/Members/SearchMatches/ViewProfile.aspx', 'SMF7682739', 'Unread', '', '', ''),
(9, 'Session', 'SMM6751741', 'Bhushan Savale', 'Member', 'SMF5489122', 'Member', 'Your Profile is Recently Viewed By: Bhushan Savale', '~/Members/SearchMatches/ViewProfile.aspx', 'SMF5489122', 'Read', '', '', ''),
(10, 'Session', 'SMM6751741', 'Bhushan Savale', 'Member', 'SMF5489122', 'Member', 'New Interest from : Bhushan Savale', '~/Members/SearchMatches/ViewProfile.aspx', 'SMF5489122', 'Read', '', '', ''),
(11, 'Session', 'SMF5489122', 'Jyoti Patil', 'Member', 'SMM6751741', 'Member', 'You are Shortlisted by : Jyoti Patil', '~/Members/SearchMatches/ViewProfile.aspx', 'SMM6751741', 'Unread', '', '', ''),
(12, 'Session', 'SMF5489122', 'Jyoti Patil', 'Member', 'SMM6751741', 'Member', 'New Interest from : Jyoti Patil', '~/Members/SearchMatches/ViewProfile.aspx', 'SMM6751741', 'Unread', '', '', ''),
(13, 'Session', 'SMF5489122', 'Jyoti Patil', 'Member', 'SMM6751741', 'Member', 'Your Profile is Recently Viewed By: Jyoti Patil', '~/Members/SearchMatches/ViewProfile.aspx', 'SMM6751741', 'Unread', '', '', ''),
(14, 'Session', 'SMF5489122', 'Jyoti Patil', 'Member', 'SMM6751741', 'Member', 'Your Profile is Recently Viewed By: Jyoti Patil', '~/Members/SearchMatches/ViewProfile.aspx', 'SMM6751741', 'Unread', '', '', ''),
(15, 'Session', 'SMM6751741', 'Bhushan Savale', 'Member', 'SMF5489122', 'Member', 'You are Shortlisted by : Bhushan Savale', '~/Members/SearchMatches/ViewProfile.aspx', 'SMF5489122', 'Unread', '', '', ''),
(16, 'Message', 'SMF5489122', 'Jyoti Patil', 'Member', 'SMF5489122', 'Member', 'You recently changed your Password if not please contact support', '', '', 'Unread', '', '', ''),
(17, 'Session', 'SMF5489122', 'Jyoti Patil', 'Member', 'SMM6751741', 'Member', 'Your Profile is Recently Viewed By: Jyoti Patil', '~/Members/SearchMatches/ViewProfile.aspx', 'SMM6751741', 'Unread', '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblampackages`
--

CREATE TABLE IF NOT EXISTS `tblampackages` (
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

CREATE TABLE IF NOT EXISTS `tblampackagesdetails` (
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

CREATE TABLE IF NOT EXISTS `tblampersonnel` (
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
(1, 'ADM111111', 'Swapnpurti Matrimony', 'Admin', 'jalgaon', 'Jalgaon', 'Maharashtra', 'India', '65757', 'swapnpurtimatrimony@gmail.com', 'true', '8055505050', 'true', '4546556', 'Siddha@2015', '08-09-2015', '02 : 49 : 50', 'Active', 'matrimony logo heart.png', ''),
(2, 'SMFR8757762', 'Mayuri Potdar', 'Franchisee', '', '', '', '', '', 'patiljyoti612@gmail.com', 'true', '9561421489', '87577627', '', 'aaaaaa', '27-10-2015', '12 : 19 : 59', 'Approve', 'NoProfile.jpg', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblampersonnelbankdetails`
--

CREATE TABLE IF NOT EXISTS `tblampersonnelbankdetails` (
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

CREATE TABLE IF NOT EXISTS `tblamprofilestatus` (
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

--
-- Dumping data for table `tblamprofilestatus`
--

INSERT INTO `tblamprofilestatus` (`intId`, `varLoginId`, `varDesignation`, `varStatus`, `varReason`, `varDateOfMarriage`, `varExperience`, `varDate`, `varTime`, `ex1`, `ex2`) VALUES
(1, 'SMM4528635', 'Member', 'Deleted', 'Other Reasons', '', 'sdds', '31-10-2015', '06 : 10 : 53', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tblamrequests`
--

CREATE TABLE IF NOT EXISTS `tblamrequests` (
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

CREATE TABLE IF NOT EXISTS `tblamsuccessstories` (
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

CREATE TABLE IF NOT EXISTS `tblmembercontactviewscount` (
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
(1, 'SMM4528635', '0', '0', '', ''),
(2, 'SMM6751741', '60', '59', '', ''),
(3, 'SMF7682739', '0', '0', '', ''),
(4, 'SMM4528635', '0', '0', '', ''),
(5, 'SMF5489122', '0', '0', '', '');

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
