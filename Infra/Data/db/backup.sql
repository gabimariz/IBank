-- MySQL dump 10.13  Distrib 5.5.62, for Win64 (AMD64)
--
-- Host: localhost    Database: ibank
-- ------------------------------------------------------
-- Server version	5.5.5-10.6.7-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20220411191133_FirstMigration','6.0.3'),('20220411203041_AccountMigration','6.0.3'),('20220411204749_UpdateAccountMigration','6.0.3'),('20220413013356_FixCascadeDelete','6.0.3'),('20220415211051_PixAndRoleMigration','6.0.3'),('20220415212316_UserUniqueKeyMigrationUpdate','6.0.3');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `account`
--

DROP TABLE IF EXISTS `account`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `account` (
  `Id` char(36) CHARACTER SET ascii NOT NULL,
  `Bill` longtext DEFAULT NULL,
  `Agency` longtext DEFAULT NULL,
  `Money` double NOT NULL,
  `UserId` char(36) CHARACTER SET ascii NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_Account_UserId` (`UserId`),
  CONSTRAINT `FK_Account_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `account`
--

LOCK TABLES `account` WRITE;
/*!40000 ALTER TABLE `account` DISABLE KEYS */;
INSERT INTO `account` VALUES ('06feb8d0-80bd-42e6-91db-cc4e8b94b17a','853390354-12','0001',1000,'168a4920-a232-442b-99bb-91dfab7d4897'),('0863d650-5ccc-496b-b87f-bd012aacf1d9','1085274637-18','0001',15000,'9e2a2210-d3f5-4063-895d-7bc6b044f3e9'),('0cc8dcbe-3ac0-4b97-91e7-c04f8bba86f0','2060885708-10','0001',600,'39fcb043-0bab-42bf-93c7-20ed014ed5a3'),('1d336681-2822-4873-948d-aceab0df7dc3','122114727-10','0001',10,'99df1c5a-8b29-4d27-955d-a3253dfc704c'),('2547f4b4-b8bf-494b-8ca2-84800f4fef95','1759486574-4','0001',100,'544718ed-5115-4826-80bc-0c1abb3677fd'),('2d56ae3e-0d14-42d5-a4e8-b1cd6f7afd33','378901332-16','0001',20,'8fe56699-be06-49e3-8334-da0d802a4c12'),('40425163-0d0e-41ae-9451-55c86f2a14d4','411062700-16','0001',0.2,'9ff2a039-624b-40df-ad97-973bd9736280'),('4674297b-fdc8-4ce9-b1cc-3ca5859e609e','1222573634-18','0001',0,'1b40cad1-41bb-49ab-a643-b9fcc7127d35'),('4940d894-3d4d-4703-afef-4b9547fe9b69','714192539-12','0001',10,'96ff06fc-1497-4768-a704-e12f52cef1cb'),('5b3e04be-6f75-4495-bbdd-c45bf621651f','1532962519-14','0001',990,'dbe44bf5-d5f1-44a5-a2a9-0d1d50d306d7'),('6464f70c-933a-4554-b775-cd0c5277a75e','38249897-10','0001',7000,'76e579ac-60e2-4cff-9631-a9e8fe753527'),('7b5e1dbb-d1c7-46d0-8a3a-dc48a724eaaf','1816550264-4','0001',1500,'15561c94-0df2-4804-8230-de0064563ef9'),('8368f051-934d-4588-9325-8161fe2c3afe','657128849-12','0001',550,'27488a08-fca8-4705-a626-23eb21b6a2aa'),('894e2e20-89e5-44ba-9069-c2844741f6d2','409163882-16','0001',800,'8555ec88-5def-475d-83f5-4b5fd9833a11'),('94914ce0-3b4e-4a5f-a5b5-8fa176d30a8f','1659541060-14','0001',50,'0d9e3e5a-de0c-41c5-87f8-b6158c972e2d'),('97677d85-f58c-4c74-a39f-c243c22e4aca','173818189-10','0001',45,'f59dac70-7073-4262-9bfc-3f00f5ba987c'),('a3f81666-f481-4c51-9e6f-37a8f846d41d','2087686848-10','0001',49.9,'839144b9-24d6-4f0b-a7cb-4abd264ab837'),('ae51aea7-a863-41d7-94c3-cc96ce896b3e','550092402-6','0001',57.67,'dfaa215f-78cb-40b0-af84-d42e73432969'),('b1fba666-81f0-4f13-8c4c-0b364456f4b5','1431286300-8','0001',0,'c4e29e5f-26fe-488b-af4f-a59ace404b80'),('b3030de0-216d-4a63-b32b-ce4627689af8','1411576093-8','0001',99,'28810613-51f9-4196-9c5e-757237cc1a83'),('b319165b-eb72-4d83-828b-70283405736e','2141121015-10','0001',100.1,'679f3a4a-07bf-46ca-bebf-659c8e4aface'),('b32b6f0b-c8c8-4879-9ccd-03ad4b6f0891','1354512403-8','0001',0.9,'67f1a144-96f9-4893-8e86-4d1d49d66fc9'),('b90934e5-b0a1-47e2-b5b8-9b4ef5b5d4e9','1518612540-14','0001',1,'78de539d-da5c-498a-91da-4551e4961f9a'),('b95742ad-8380-4014-9cb6-1953230481f7','1028210947-2','0001',1.5,'164acdbb-7182-4e2e-b3e6-0a77ceebbdaa'),('ca2eb5a0-64d2-41b8-9d70-2732fd418f94','983598418-2','0001',7,'2e368ffc-cb2d-4db7-bc31-0cba293c7a32'),('d25e68e8-3c87-40bf-8f24-4a56b7331de2','1386673771-8','0001',146.65,'df31e63a-12f7-469d-9fff-8b7e7ded6491'),('d7f6e58e-6b7b-4c53-9ece-db931229306d','521560557-6','0001',90,'e55e3d93-2acf-4c00-adb9-79bdc9c5c512'),('dae412ab-293b-4be1-9abb-c99a0b3545be','1648820604-14','0001',1000,'bf815c23-4cfc-4f5d-a217-fda2ba8f48ae'),('e18d8dd4-089e-406c-b0ed-679eba5e95a8','1208223655-18','0001',15100,'06d8cad5-cb02-4682-9b67-6b0e0f5271ab'),('ec85491b-a976-4e4c-8533-f9962b4584a1','464496867-6','0001',0,'7a242221-ac87-417d-a938-cee9a38ba4d9'),('f3af8ba6-6a28-4262-b6c2-3aa3a48e0a88','1991370857-10','0001',60,'6238fe8e-9bbb-4525-96d4-21e31ae5d014'),('f91517fc-ad01-4061-85d8-909a89e8aa14','405702472-16','0001',67,'9a224989-4469-4ad2-970d-d6a2c19bc5f1');
/*!40000 ALTER TABLE `account` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pixtransfers`
--

DROP TABLE IF EXISTS `pixtransfers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pixtransfers` (
  `Id` char(36) CHARACTER SET ascii NOT NULL,
  `Money` double NOT NULL,
  `To` char(36) CHARACTER SET ascii NOT NULL,
  `From` char(36) CHARACTER SET ascii NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pixtransfers`
--

LOCK TABLES `pixtransfers` WRITE;
/*!40000 ALTER TABLE `pixtransfers` DISABLE KEYS */;
/*!40000 ALTER TABLE `pixtransfers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `Id` char(36) CHARACTER SET ascii NOT NULL,
  `FullName` longtext DEFAULT NULL,
  `Cpf` varchar(255) DEFAULT NULL,
  `Email` varchar(255) DEFAULT NULL,
  `Password` longtext DEFAULT NULL,
  `Role` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_Users_Cpf` (`Cpf`),
  UNIQUE KEY `IX_Users_Email` (`Email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES ('06d8cad5-cb02-4682-9b67-6b0e0f5271ab','Daiane Luiza Barbosa','850.809.078-19','daiane_barbosa@villalobos.mu.br','$2a$11$PhD363zCPzoG1nq5BK913O7dbAmAMExduoTzU.IBA4K/HqYYJACpq',1),('0d9e3e5a-de0c-41c5-87f8-b6158c972e2d','Bento Benjamin Calebe Brito','128.780.258-30','bento_brito@mixfmmanaus.com.br','$2a$11$dOXU86rYhM37j4V5FkY0qe2VFoyTzWGM463dDZt0M/KrkvJhVDmDu',1),('15561c94-0df2-4804-8230-de0064563ef9','Stefany Alícia Assunção','260.954.829-09','stefany_assuncao@numero.com.br','$2a$11$ABvIXe2ky19vMymvvwCLj.rsaXlD5M1txePU22uw1pyGlMOrZbIeq',1),('164acdbb-7182-4e2e-b3e6-0a77ceebbdaa','Heloise Alana Maya Almada','554.829.823-27','heloise.alana.almada@jetstar.com.br','$2a$11$lrTS7eSlh7tifLURkGXgROeFuui0pO7CpuyDO.3Lx5TKnwQ8kBKZm',1),('168a4920-a232-442b-99bb-91dfab7d4897','Lúcia Julia Farias','635.414.695-01','lucia_julia_farias@leoshehtman.com.br','$2a$11$/Fy4dHkiHiiXtfcKgMzQy.51sBYprUOXUBhTbnI6V2B5ArlIP6FhS',1),('1b40cad1-41bb-49ab-a643-b9fcc7127d35','Antonio Antonio Carlos Eduardo Figueiredo','421.868.349-28','antonio_figueiredo@novaface.com.br','$2a$11$vIJycx5lMSP5SgEUE.e7q.fLMAGKlh9dRZ4uvgqeyvKPgvp7iJ/HW',1),('27488a08-fca8-4705-a626-23eb21b6a2aa','Débora Regina Rebeca Vieira','363.967.923-70','deborareginavieira@manjubinhafilmes.com.br','$2a$11$dgn0uzPFhc34A29i50XPgeytEjQ7lXBNkqUnOemCxMsMaYs16maS2',1),('28810613-51f9-4196-9c5e-757237cc1a83','Priscila Rosângela Lopes','756.866.688-33','priscila-lopes97@yahoo.com','$2a$11$sk1LHz0TaqfzcmHmgeBs5uXyXfL2GWaxmrXO6JBy1rIASduwBLtyW',1),('2e368ffc-cb2d-4db7-bc31-0cba293c7a32','Clarice Elisa Nascimento','948.125.813-03','clarice-nascimento95@eguia.com.br','$2a$11$ndH7OwIK1rn1sqS1pvYQJOY5g7/fY9V9R0B6gMejiuQtMeSAr6H9e',1),('39fcb043-0bab-42bf-93c7-20ed014ed5a3','Sara Aurora Baptista','054.841.910-84','sara_aurora_baptista@rj.net','$2a$11$S5KsL96FuWneud2ieIsXZuFbISYlzqbyrgCWPbp8u//MkTbaIQ/Fy',1),('544718ed-5115-4826-80bc-0c1abb3677fd','Renato Enzo Roberto Caldeira','931.109.599-09','renato_enzo_caldeira@integrasjc.com.br','$2a$11$ETlEuJEFbifQFPOfZLCRf.9022Am8Fpg6hlktRSrq76ZlGoL6ePs2',1),('6238fe8e-9bbb-4525-96d4-21e31ae5d014','Lavínia Sarah Mendes','578.661.259-70','lavinia_sarah_mendes@grupoarteoficio.com.br','$2a$11$BtubwPc6VNgzQkKIQ.VyE.dWLMXwsbTkeKQB7Km0v5mTH/WUw0Q9i',1),('679f3a4a-07bf-46ca-bebf-659c8e4aface','Cauã Cauê Mendes','453.964.089-52','caua_caue_mendes@mciimoveis.com.br','$2a$11$KzX978figRa/j3adTHQRaehg7yGuPwU55n0aVaIlvd4fLiEVnb7r2',1),('67f1a144-96f9-4893-8e86-4d1d49d66fc9','Davi Pietro Moraes','174.280.839-58','davi_pietro_moraes@myself.com','$2a$11$u9sFSrWoMO22yPsuNf.mT.6ri3NdJ.JIn64hiCh8EusLUuwhkbxe6',1),('76e579ac-60e2-4cff-9631-a9e8fe753527','Emanuel Paulo Moraes','045.959.395-15','emanuel.paulo.moraes@tursi.com.br','$2a$11$3xPpZxWtZdkGloxAMg9mue0p7styinTT2ItPUdl7ZFOEi492WSbv.',1),('78de539d-da5c-498a-91da-4551e4961f9a','Benjamin Severino Daniel Moreira','765.980.328-06','benjamin-moreira80@edepbr.com.br','$2a$11$gG9qJ9P8z6UmNiu58gZi7Oqapl3RqfyMZr6azqcvPkMgsfFJtQDyW',1),('7a242221-ac87-417d-a938-cee9a38ba4d9','Sophia Sabrina da Mota','999.848.836-20','sophia-damota73@raioazul.com.br','$2a$11$FPJAgIhdVffeXPKWhCpmCe.apyHX.utM3amKRFjJLsQu5Jd5EJaHq',1),('839144b9-24d6-4f0b-a7cb-4abd264ab837','Márcio Marcos Vinicius Oliver Almeida','892.838.512-18','marcio_marcos_almeida@macaubas.com','$2a$11$dKYBDjJdYQEGj9QkSKfI4.adu9FWGT4Cs8P6TwQZGEPa2vxtJw1vu',1),('8555ec88-5def-475d-83f5-4b5fd9833a11','Sophie Daiane Beatriz Monteiro','643.625.341-64','sophie.daiane.monteiro@realbit.com.br','$2a$11$TouvaauQXw2NTZRlUbDIyOmyB0XmyG/1aI3AbXeJqHxs1h3agHrJy',1),('8fe56699-be06-49e3-8334-da0d802a4c12','Analu Raquel da Luz','153.300.115-40','analuraqueldaluz@alcoa.com.br','$2a$11$apQGZH5iDX.3jBfUSP9AP.JhGtAAwlKlS.5HbnoPg90FTqPuqa2jm',1),('96ff06fc-1497-4768-a704-e12f52cef1cb','Juliana Fabiana Sebastiana Costa','544.141.161-98','julianafabianacosta@gabiaatelier.com.br','$2a$11$HJZUXQdguhTsClHCFtgrc.vvGeQkIVBzuntRMJ2gHT5V.BcHXsjUi',1),('99df1c5a-8b29-4d27-955d-a3253dfc704c','Daniela Eduarda Isabella Alves','134.747.673-30','daniela_alves@reval.net','$2a$11$MFHhrDsL8yPiFn6jhjMtueAgg4Kho.scHUn94tUNCEnPXiA0Y4Alq',1),('9a224989-4469-4ad2-970d-d6a2c19bc5f1','Teresinha Fátima Moreira','738.012.913-91','teresinha_moreira@cielo.com.br','$2a$11$Hy9YexWnhavFh2yx5L0HAONR5KQI8Sjv3s7xiVpc9RN.OxKABrwmG',1),('9e2a2210-d3f5-4063-895d-7bc6b044f3e9','Gabriela Daiane Olivia Barros','058.653.189-00','gabrieladaianebarros@itau-unibanco.com.br','$2a$11$g8ggdRtXMp5ANEZb1bqsFusUgHw/g53C3k9Bt.VwyJuSAfog.kDJO',1),('9ff2a039-624b-40df-ad97-973bd9736280','Julia Jennifer Bernardes','835.272.732-04','juliajenniferbernardes@cbaidiomas.com','$2a$11$jqwxuJ.Y5Lk6PiEqtAHHiuOi7fwhCM4a2yvhrMcXcBeY0ioycoDSq',1),('bf815c23-4cfc-4f5d-a217-fda2ba8f48ae','Gabrielly Andrea Campos','748.321.909-20','gabrielly.andrea.campos@globomail.com','$2a$11$0yXlJM5D8xBb6ZyfmDiDauXCh7xXbGEQJOSYRmnJ1fYlwLW6tG1Uq',1),('c4e29e5f-26fe-488b-af4f-a59ace404b80','Fernando Rafael Guilherme Costa','961.882.521-30','fernando_costa@truckeixo.com.br','$2a$11$MFdYoSyfxFlcbaxmk9xFhe20/tz8fCybZcgNLDFlZ0B55Bq96nov6',1),('dbe44bf5-d5f1-44a5-a2a9-0d1d50d306d7','Sérgio Lucca Victor Figueiredo','877.252.551-76','sergio.lucca.figueiredo@mmetalica.com.br','$2a$11$cL2QpU5kPQ5eCtjLfuSRUOZqITXS/h8ixZ8EpsVEIJDnHNrfIwzpK',1),('df31e63a-12f7-469d-9fff-8b7e7ded6491','Sebastião Elias Davi Ramos','930.686.242-31','sebastiao.elias.ramos@agenziamarketing.com.br','$2a$11$Q2NheKfTngtkiuBuPseFV.BdDy9Jp3cHIaqFdmZ8sYsimGDLDfBlu',1),('dfaa215f-78cb-40b0-af84-d42e73432969','Sandra Emily Novaes','828.583.496-49','sandra.emily.novaes@teofilorezende.com.br','$2a$11$0O5.voDQH2BtYTGdJaLv9uJy3QEhXD4LrlGMjQzgO0eq/zzOt4CKi',1),('e55e3d93-2acf-4c00-adb9-79bdc9c5c512','Julio Gabriel Marcos Vinicius Pires','583.204.297-22','julio-pires94@yahool.com','$2a$11$.UlWUzA/yn1BakNGnH2NsOP6sD7mqh2Z/4Gw.pYEF1C0WR1dwx6eS',1),('f59dac70-7073-4262-9bfc-3f00f5ba987c','Cecília Isabella Antonella Drumond','790.801.523-90','cecilia-drumond93@anfip.org.br','$2a$11$1aHC.Nqey3XCZa0gu3pbiOGjq9FgG.6Kzks3eb/Hi3wDU1JkD2viq',1);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'ibank'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-04-16 19:14:24
