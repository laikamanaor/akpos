USE [master]
GO
/****** Object:  Database [AKPOS]    Script Date: 05/25/2020 5:50:03 PM ******/
CREATE DATABASE [AKPOS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AKPOS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\AKPOS.mdf' , SIZE = 151552KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AKPOS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\AKPOS_log.ldf' , SIZE = 9036352KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AKPOS] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AKPOS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AKPOS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AKPOS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AKPOS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AKPOS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AKPOS] SET ARITHABORT OFF 
GO
ALTER DATABASE [AKPOS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AKPOS] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [AKPOS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AKPOS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AKPOS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AKPOS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AKPOS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AKPOS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AKPOS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AKPOS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AKPOS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AKPOS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AKPOS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AKPOS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AKPOS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AKPOS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AKPOS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AKPOS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AKPOS] SET RECOVERY FULL 
GO
ALTER DATABASE [AKPOS] SET  MULTI_USER 
GO
ALTER DATABASE [AKPOS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AKPOS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AKPOS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AKPOS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'AKPOS', N'ON'
GO
USE [AKPOS]
GO
/****** Object:  StoredProcedure [dbo].[cancelRecTrans]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cancelRecTrans]
@transnum varchar(255)
AS
BEGIN
UPDATE tblproduction SET status='Cancelled' WHERE transaction_number=@transnum
END
GO
/****** Object:  StoredProcedure [dbo].[getInventory]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getInventory]
@invnum varchar(255)
AS
BEGIN
Select a.invid,a.itemcode,
a.itemname,b.category,a.begbal,
a.produce,a.good,a.charge,
a.productionin,a.itemin,a.supin,
a.adjustmentin,a.convin,a.totalav,
a.transfer,a.ctrout,a.archarge,
a.arsales,a.convout,a.pullout,
a.endbal,a.actualendbal,a.variance,
a.shortover,
Case When a.actualendbal > a.endbal Then ISNULL(SUM(a.actualendbal - endbal),0) * b.price End [over_amt],
ISNULL(SUM(a.ctrout * b.price),0) [ctrout_amt],ISNULL(SUM(a.archarge * b.price),0) [archarge_amt],
ISNULL(SUM(a.arsales * b.price),0) [arsales_amt] FROM tblinvitems a 
INNER JOIN tblitems b On a.itemname = b.itemname WHERE a.invnum=@invnum  AND a.totalav !=0 AND  a.status=1 
GROUP BY a.invid,a.itemcode,a.itemname,b.category,a.begbal,a.produce,a.good,a.charge,a.productionin,a.itemin,a.supin,a.adjustmentin,
a.convin,a.totalav,a.transfer,a.ctrout,a.archarge,a.arsales,a.convout,a.pullout,a.endbal,a.actualendbal,a.variance,a.shortover,b.price 
END
GO
/****** Object:  StoredProcedure [dbo].[getInventory2]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getInventory2]
@invnum varchar(255)
AS
BEGIN
Select a.invid,a.itemcode,
a.itemname,b.category,a.begbal,
a.produce,a.good,a.charge,
a.productionin,a.itemin,a.supin,
a.adjustmentin,a.convin,a.totalav,
a.transfer,a.ctrout,a.archarge,
a.arsales,a.convout,a.pullout,
a.endbal,a.actualendbal,a.variance,
a.shortover,
Case When a.actualendbal > a.endbal Then ISNULL(SUM(a.actualendbal - endbal),0) * b.price End [over_amt],
ISNULL(SUM(a.ctrout * b.price),0) [ctrout_amt],ISNULL(SUM(a.archarge * b.price),0) [archarge_amt],
ISNULL(SUM(a.arsales * b.price),0) [arsales_amt] FROM tblinvitems a 
INNER JOIN tblitems b On a.itemname = b.itemname WHERE a.invnum=@invnum  AND a.totalav =0 AND  a.status=1 
GROUP BY a.invid,a.itemcode,a.itemname,b.category,a.begbal,a.produce,a.good,a.charge,a.productionin,a.itemin,a.supin,a.adjustmentin,
a.convin,a.totalav,a.transfer,a.ctrout,a.archarge,a.arsales,a.convout,a.pullout,a.endbal,a.actualendbal,a.variance,a.shortover,b.price 
END
GO
/****** Object:  StoredProcedure [dbo].[insertBranch]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertBranch]
@code varchar(255),
@name varchar(255),
@gr varchar(255),
@sales varchar(255),
@address varchar(255),
@remarks varchar(255),
@createdby varchar(255),
@status int,
@main int
AS BEGIN
INSERT INTO tblbranch (branchcode,branch,gr,sales,address,remarks,datecreated,createdby,datemodified,modifiedby,status,main)
VALUES (@code,@name,@gr,@sales,@address,@remarks,(SELECT GETDATE()), @createdby,(SELECT GETDATE()),@createdby,@status,@main)
END
GO
/****** Object:  StoredProcedure [dbo].[insertCategory]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertCategory]
@category varchar(255),
@createdby varchar(255),
@status int
AS BEGIN
INSERT INTO tblcat (category,datecreated,createdby,datemodified,modifiedby,status)
VALUES (@category,(SELECT GETDATE()),@createdby,(SELECT GETDATE()),@createdby,@status)
END
GO
/****** Object:  StoredProcedure [dbo].[insertContinueInvItems]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertContinueInvItems]
@itemid int
AS BEGIN
INSERT INTO tblinvitems (invnum,itemcode,itemname,begbal,produce,good,reject,
charge,productionin,itemin,totalav,ctrout,pullout,endbal,actualendbal,variance,
shortover,status,convin,archarge,arsales,convout,transfer,area,arreject,supin,
adjustmentin,reject_convin,reject_convout,reject_archarge,reject_transfer,
reject_totalav,cancelin) VALUES ((Select TOP 1 invnum from tblinvsum WHERE area='Sales' order by invsumid DESC),
(SELECT itemcode FROM tblitems WHERE itemid=@itemid),(SELECT itemname FROM tblitems WHERE itemid=@itemid),
0,0,0,0,0,0,0,0,0,0,0,0,0,'',1,0,0,0,0,0,'Sales',0,0,0,0,0,0,0,0,0)
END
GO
/****** Object:  StoredProcedure [dbo].[insertConvOut]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertConvOut]
@conv_number varchar(255),
@itemname varchar(255),
@quantity float,
@type varchar(255),
@status varchar(255),
@createdby varchar(255),
@area varchar(255),
@typenum varchar(255),
@sapnum varchar(255),
@remarks varchar(255),
@reference varchar(255),
@marks varchar(255)
AS BEGIN
INSERT INTO tblconversion (conv_number,inv_number,item_code,item_name,category,
quantity,type,status,date_created,created_by,area,typenum,sap_id,remarks,
reference_number,marks) VALUES (@conv_number,
(Select TOP 1 invnum from tblinvsum WHERE area='Sales' order by invsumid DESC),
(SELECT itemcode FROM tblitems WHERE itemname=@itemname),@itemname,
(SELECT category FROM tblitems WHERE itemname=@itemname),
@quantity,@type,@status,(SELECT GETDATE()),@createdby,@area,@typenum,@sapnum,
@remarks,@reference,@marks)
END
GO
/****** Object:  StoredProcedure [dbo].[insertCSItems]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertCSItems]
@itemcode varchar(255),
@itemname varchar(255),
@category varchar(255),
@quantity float,
@invnum varchar(255),
@transnum varchar(255),
@username varchar(255)
AS
BEGIN
BEGIN TRY
BEGIN TRANSACTION
UPDATE tblinvitems SET productionin+=@quantity,totalav +=@quantity,
endbal +=@quantity,variance=variance + @quantity WHERE itemname=@itemname And invnum=@invnum

INSERT INTO tblproduction (transaction_number,inv_id,item_code,item_name,category,
quantity,reject,charge,sap_number,remarks,date,processed_by,type,area,status,
transfer_from,transfer_to,from_transnum,typenum,type2) VALUES 
(@transnum,@invnum, @itemcode,@itemname,@category,@quantity,0,0,'To Follow','',(SELECT GETDATE()),
@username,'Received Item','Sales','Completed','','','','','Received From Production')
COMMIT TRANSACTION
END TRY
BEGIN CATCH
ROLLBACK TRANSACTION
END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[insertCustomers]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertCustomers]
@name varchar(255)
,@code varchar(255)
,@contact_number varchar(255)
,@address varchar(255)
,@createdby varchar(255)
,@type varchar(255)
AS
BEGIN
INSERT INTO tblcustomers (name,contact_number,address,date,created_by,status,type,code)
VALUES (@name,@contact_number,@address,(SELECT GETDATE()), @createdby,1,@type,@code)
END
GO
/****** Object:  StoredProcedure [dbo].[insertDepositItem]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertDepositItem]
@price float
AS BEGIN
INSERT INTO tbldepositprice (itemid,price,status) VALUES 
((SELECT TOP 1 itemid FROM tblitems ORDER BY itemid DESC),@price,1)
END
GO
/****** Object:  StoredProcedure [dbo].[insertItem]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertItem]
@category varchar(255),
@itemcode varchar(255),
@itemname varchar(255),
@description varchar(255),
@price float,
@createdby varchar(255),
@deposit int
AS BEGIN
INSERT INTO tblitems (category,itemcode,itemname,description,price,datecreated,
createdby,datemodified,status,discontinued,deposit) VALUES (@category,@itemcode,
@itemname,@description,@price,(SELECT GETDATE()), @createdby,(SELECT GETDATE()),
1,0,@deposit)

INSERT INTO tblinvitems (invnum,itemcode,itemname,begbal,produce,good,
reject,charge,productionin,itemin,totalav,ctrout,pullout,endbal,actualendbal,
variance,shortover,status,convin,archarge,arsales,convout,transfer,area,arreject,
supin,adjustmentin,reject_convin,reject_convout,reject_archarge,reject_transfer,
reject_totalav,cancelin) VALUES ((Select TOP 1 invnum from tblinvsum 
WHERE area='Sales' order by invsumid DESC),@itemcode,@itemname,0,0,0,0,0,0,0,0,0,
0,0,0,0,'',1,0,0,0,0,0,'Sales',0,0,0,0,0,0,0,0,0)

END
GO
/****** Object:  StoredProcedure [dbo].[insertTransaction]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertTransaction]
@ordernum int,
@or varchar(255),
@transnum varchar(255),
@invnum varchar(255),
@cashier varchar(255),
@tendertype varchar(255),
@servicetype varchar(255),
@delcharge float,
@subtotal float,
@disctype varchar(255),
@less float,
@vatsales float,
@vat float,
@amtdue float,
@ar_amtdue float,
@gctotal float,
@tenderamt float,
@change float,
@refund int,
@comment varchar(255),
@remarks varchar(255),
@customer varchar(255),
@tinum varchar(255),
@tablenum varchar(255),
@pax float,
@status int,
@area varchar(255),
@partialamt float,
@typenum varchar(255),
@sap_number varchar(255),
@sap_remarks varchar(255),
@typez varchar(255),
@discamt float,
@salesname varchar(255),
@username varchar(255),
@ar_remarks varchar(255),
@ar_type varchar(255),
@ts int
AS BEGIN
UPDATE tbltransaction2 SET amtdue=@amtdue,gctotal=@gctotal,tenderamt=@tenderamt,
change=@change,customer=@customer,datemodified=(SELECT GETDATE() - @ts),status2='Paid',
transnum=@transnum,subtotal=@subtotal,disctype=@disctype,less=@less,
discamt=@discamt WHERE orderid=@ordernum

Insert into tbltransaction (ornum, transnum, transdate, cashier, tendertype, servicetype, 
delcharge, subtotal, disctype, less, vatsales, vat, amtdue, gctotal, tenderamt, change, 
refund, comment, remarks, customer, tinnum, tablenum, pax, datecreated, datemodified, 
status,area,invnum,partialamt,typenum,sap_number,sap_remarks,typez,discamt,auth_systemid,
salesname) values (@or, @transnum, (select cast(getdate() - @ts as date)),@username, @tendertype, @servicetype,
@delcharge, @subtotal,@disctype,@less, @vatsales,@vat,@amtdue, @gctotal, @tenderamt,@change, @refund,
@comment, @ar_remarks, @customer,@tinum, @tablenum, @pax,(SELECT GETDATE() - @ts),
(SELECT GETDATE() - @ts), @status,@area,@invnum,@partialamt,@typenum,@sap_number,@sap_remarks,
@typez,@discamt,(SELECT systemid FROM tblusers WHERE username=@username),@salesname)

INSERT INTO tblars1 (arnum,transnum,amountdue,name,status,date_created,created_by,
area,invnum,type,balance,typenum,sap_no,remarks,_from) VALUES (@transnum,@transnum,
@ar_amtdue, @customer, 'Unpaid',(SELECT GETDATE() - @ts), @username,@area,@invnum,@ar_type,
@ar_amtdue,@typenum,@sap_number,@ar_remarks,'POS')
END

GO
/****** Object:  StoredProcedure [dbo].[insertUser]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertUser]
@fullname varchar(255),
@username varchar(255),
@password varchar(255),
@workgroup varchar(255),
@createdby varchar(255),
@status int,
@brout varchar(255),
@postype varchar(255)
AS
INSERT INTO tblusers (fullname,username,password,workgroup,datecreated,createdby,datemodified,modifiedby,status,brid,postype)
VALUES (@fullname,@username,@password,@workgroup,(SELECT GETDATE()),@createdby,(SELECT GETDATE()),@createdby,@status,
(SELECT brid FROM tblbranch WHERE branchcode=@brout),@postype)

GO
/****** Object:  StoredProcedure [dbo].[updateBranch]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updateBranch]
@branchcode varchar(255),
@branchname varchar(255),
@gr varchar(255),
@sales varchar(255),
@address varchar(255),
@remarks varchar(255),
@modifiedby varchar(255),
@status int,
@brid int
AS BEGIN
UPDATE tblbranch SET branchcode=@branchcode,branch=@branchname,gr=@gr,sales=@sales,address=@address
,remarks=@remarks,datemodified=(SELECT GETDATE()), modifiedby=@modifiedby,status=@status WHERE brid=@brid
END
GO
/****** Object:  StoredProcedure [dbo].[updateCategory]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updateCategory]
@category varchar(255),
@modifiedby varchar(255),
@status int,
@catid int
AS BEGIN
UPDATE tblcat SET category=@category,status=@status,datemodified=(SELECT GETDATE()),modifiedby=@modifiedby WHERE catid=@catid
END
GO
/****** Object:  StoredProcedure [dbo].[updateDepositItem]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updateDepositItem]
@price float,
@status int,
@itemid int
AS BEGIN
UPDATE tbldepositprice SET price=@price,status=@status WHERE itemid=@itemid
END
GO
/****** Object:  StoredProcedure [dbo].[updateDiscontinued]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updateDiscontinued]
@itemid int,
@discontinued int
AS BEGIN
UPDATE tblitems SET discontinued=@discontinued WHERE itemname=(SELECT itemname FROM tblitems WHERE itemid=@itemid)
END
GO
/****** Object:  StoredProcedure [dbo].[updateInvStatus]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updateInvStatus]
@itemname varchar(255),
@status int
AS BEGIN
UPDATE tblinvitems SET status=@status WHERE itemname=@itemname
AND invnum=(Select TOP 1 invnum from tblinvsum WHERE area='Sales' order by invsumid DESC)

UPDATE tblitems SET status=@status WHERE itemname=@itemname

END
GO
/****** Object:  StoredProcedure [dbo].[updateItems]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updateItems]
@itemid int,
@category varchar(255),
@itemname varchar(255),
@itemcode varchar(255),
@description varchar(255),
@price float,
@modby varchar(255),
@deposit int,
@current_itemcode varchar(255),
@current_itemname varchar(255),
@depositprice float
AS BEGIN

UPDATE tblitems SET category=@category,itemname=@itemname,itemcode=@itemcode,
description=@description,price=@price,datemodified=(SELECT GETDATE()),
modifiedby=@modby,deposit=@deposit WHERE itemid=@itemid

UPDATE tblconversion SET item_code=@itemcode,item_name=@itemname WHERE item_code=@current_itemcode

UPDATE tblinvitems SET itemcode=@itemcode,itemname=@itemname WHERE itemcode=@current_itemcode

UPDATE tblproduction SET item_code=@itemcode,item_name=@itemname WHERE 
item_code=@current_itemcode

UPDATE tblorder SET itemname=@itemname WHERE itemname=@current_itemcode

UPDATE tblorder2 SET itemname=@itemname WHERE itemname=@current_itemcode

UPDATE tblars2 SET description=@description WHERE description=@current_itemname

END
GO
/****** Object:  StoredProcedure [dbo].[updateUser]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updateUser]
@fullname varchar(255),
@username varchar(255),
@password varchar(255),
@workgroup varchar(255),
@modifiedby varchar(255),
@status int,
@brout varchar(255),
@postype varchar(255),
@systemid int
AS BEGIN
UPDATE tblusers SET fullname=@fullname,username=@username,password=@password,workgroup=@workgroup
,modifiedby=@modifiedby,datemodified=(SELECT GETDATE()),status=@status,
brid=(SELECT brid FROM tblbranch WHERE branchcode=@brout),postype=@postype WHERE systemid=@systemid
END
GO
/****** Object:  UserDefinedFunction [dbo].[checkBranchCode]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[checkBranchCode](@code varchar(255))
RETURNS INT
AS BEGIN
DECLARE @result int
SET @result =(SELECT ISNULL(COUNT(brid),0) FROM vLoadBranches WHERE branchcode=@code)
IF @result=0
RETURN 0
RETURN 1
END
GO
/****** Object:  UserDefinedFunction [dbo].[checkCategory]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[checkCategory](@category varchar(255))
RETURNS INT
AS BEGIN
DECLARE @result int
SET @result =(SELECT ISNULL(COUNT(catid),0) FROM vLoadCategories WHERE category=@category)
IF @result=0
RETURN 0
RETURN 1
END
GO
/****** Object:  UserDefinedFunction [dbo].[checkCustomer]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[checkCustomer](@name varchar(255), @type varchar(255))
RETURNS INT
AS
BEGIN
DECLARE @result int
SET @result= (SELECT ISNULL(COUNT(customer_id),0) FROM tblcustomers WHERE name=@name And type=@type)
IF @result = 0
RETURN 0
RETURN 1
END
GO
/****** Object:  UserDefinedFunction [dbo].[checkCutOff]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[checkCutOff](@username varchar(255),@workgroup varchar(255))
RETURNS INT
AS
BEGIN
DECLARE @result int

IF @workgroup='LC Accounting' OR @workgroup='Manager'
SET @result= (SELECT ISNULL(MAX(cid),0) FROM tblcutoff WHERE status='In Active'
AND CAST(date AS date)=(select cast(getdate() as date)))
ELSE
SET @result= (SELECT ISNULL(MAX(cid),0) FROM tblcutoff WHERE 
userid=(SELECT systemid FROM tblusers WHERE username=@username) AND status='In Active'
AND CAST(date AS date)=(select cast(getdate() as date)))
IF @result = 0
RETURN 0;
RETURN 1;
END

GO
/****** Object:  UserDefinedFunction [dbo].[checkDepositItem]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[checkDepositItem](@itemid int)
RETURNS INT
AS BEGIN
DECLARE @result int
SET @result =(SELECT COUNT(depid) FROM tbldepositprice WHERE itemid=@itemid)
IF @result=0
RETURN 0
RETURN 1
END
GO
/****** Object:  UserDefinedFunction [dbo].[checkItemName]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[checkItemName](@itemname varchar(255))
RETURNS INT
AS BEGIN
DECLARE @result int
SET @result =(SELECT ISNULL(COUNT(itemid),0) FROM tblitems WHERE itemname=@itemname)
IF @result=0
RETURN 0
RETURN 1
END
GO
/****** Object:  UserDefinedFunction [dbo].[checkLogin]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[checkLogin](@username varchar(255),@password varchar(255))
RETURNS INT
AS
BEGIN
DECLARE @result int
SET @result= (SELECT ISNULL(COUNT(systemid),0) FROM tblusers WHERE username=@username And password=@password)
IF @result = 0
RETURN 0
RETURN 1
END
GO
/****** Object:  UserDefinedFunction [dbo].[checkOrderNumber]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[checkOrderNumber] (@ordernum varchar(255))
RETURNS INT
AS
BEGIN
DECLARE @result int
SET @result= (SELECT ISNULL(COUNT(orderid),0) FROM tbltransaction2 
WHERE ordernum=@ordernum AND status2 = 'Paid' AND CAST(datecreated AS date)=(select cast(getdate() as date)))
IF @result = 1
RETURN 1;
RETURN 0;
END
GO
/****** Object:  UserDefinedFunction [dbo].[checkSAPNumber]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[checkSAPNumber](@sap_number varchar(255))
RETURNS INT
AS BEGIN
DECLARE @result int
SET @result= (SELECT ISNULL(COUNT(transaction_id),0) FROM tblproduction WHERE sap_number=@sap_number AND status='Completed'
AND type='Received Item')
IF @result = 0
RETURN 0
RETURN 1
END
GO
/****** Object:  UserDefinedFunction [dbo].[checkStock]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[checkStock](@itemname varchar(255))
RETURNS FLOAT
AS
BEGIN
DECLARE @result int

SET @result= (SELECT endbal FROM tblinvitems WHERE  itemname=@itemname AND 
invnum=(Select TOP 1 invnum from tblinvsum WHERE area='Sales' order by invsumid DESC) 
AND area='Sales')

RETURN @result
END
GO
/****** Object:  UserDefinedFunction [dbo].[checkTransactionStatus]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[checkTransactionStatus](@transnum varchar(255))
RETURNS INT
AS BEGIN
DECLARE @result int
SET @result =(SELECT ISNULL(COUNT(transaction_id),0) FROM tblproduction WHERE 
transaction_number=@transnum AND status = 'Cancelled')
IF @result=0
RETURN 0
RETURN 1
END
GO
/****** Object:  UserDefinedFunction [dbo].[checkUsername]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[checkUsername](@username varchar(255))
RETURNS INT
AS BEGIN
DECLARE @result int
SET @result =(SELECT ISNULL(COUNT(systemid),0) FROM vLoadUsers WHERE username=@username)
IF @result=0
RETURN 0
RETURN 1
END
GO
/****** Object:  UserDefinedFunction [dbo].[checkUserStatus]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[checkUserStatus](@username varchar(255))
RETURNS INT
AS
BEGIN
DECLARE @result int
SET @result= (SELECT ISNULL(COUNT(systemid),0) FROM tblusers WHERE username=@username And status=1)
IF @result = 0
RETURN 0
RETURN 1
END
GO
/****** Object:  UserDefinedFunction [dbo].[funcCountInventoryLogs]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[funcCountInventoryLogs](@transnum varchar(255),
@date varchar(255),@type varchar(255))
RETURNS INT
AS BEGIN
DECLARE @result int
SET @result= (
SELECT COUNT(transaction_number) FROM vInventoryLogs
WHERE transaction_number LIKE '%' +	@transnum + '%' AND CAST(date AS date)=@date
AND type=@type AND status='Completed')
return @result;
END
GO
/****** Object:  UserDefinedFunction [dbo].[funcCountLoadItems]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[funcCountLoadItems](@icategory int,@category varchar(255),@itemname varchar(255),@discontinued int)
RETURNS INT
AS BEGIN
DECLARE @result int
IF @icategory = 0 AND @itemname = ''
SET @result= (
SELECT COUNT(a.itemid) FROM tblitems a WHERE a.discontinued=@discontinued)

ELSE IF @icategory !=0 AND  @itemname=''
SET @result= (
SELECT COUNT(a.itemid) FROM tblitems a WHERE a.discontinued=@discontinued AND a.category=@category)

ELSE IF @icategory =0 AND  @itemname!=''
SET @result= (
SELECT COUNT(a.itemid) FROM tblitems a WHERE a.discontinued=@discontinued AND a.itemname LIKE '%' + @itemname + '%')

ELSE IF @icategory !=0 AND  @itemname!=''
SET @result= (
SELECT COUNT(a.itemid) FROM tblitems a WHERE a.discontinued=@discontinued AND a.itemname LIKE '%' + @itemname + '%'
AND a.category=@category)
RETURN @result
END
GO
/****** Object:  UserDefinedFunction [dbo].[funcCountLoadUsers]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[funcCountLoadUsers](@username varchar(255),@workgroup varchar(255),@status int)
RETURNS INT
AS BEGIN
DECLARE @result int
IF @workgroup='All'
SET @result= (
SELECT ISNULL(COUNT(systemid),0) FROM vLoadUsers WHERE status=@status 
AND username LIKE '%' + @username + '%')
ELSE
SET @result= (SELECT ISNULL(COUNT(systemid),0) FROM vLoadUsers 
WHERE status=@status AND username LIKE '%' + @username + '%' AND workgroup=@workgroup)
RETURN @result;
END
GO
/****** Object:  UserDefinedFunction [dbo].[funcLoadCategories]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[funcLoadCategories](@offset int,@rowfetch int)
RETURNS @result TABLE(category varchar(255))
AS BEGIN
INSERT INTO @result
SELECT category FROM vLoadCategories WHERE status=1 ORDER BY category OFFSET @offset ROW FETCH NEXT @rowfetch ROWS ONLY
return;
END
GO
/****** Object:  UserDefinedFunction [dbo].[funcLoadConvOutItems]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[funcLoadConvOutItems](@convnum varchar(255))
RETURNS @result TABLE(item_name varchar(255),category varchar(255),quantity float)
AS BEGIN
INSERT INTO @result
SELECT item_name,category,quantity FROM tblconversion WHERE conv_number=@convnum
RETURN;
END

GO
/****** Object:  UserDefinedFunction [dbo].[funcLoadInventoryItems]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[funcLoadInventoryItems](@datecreated varchar(255),@itemname varchar(255),@category varchar(255))
RETURNS @result TABLE(category varchar(255),itemcode varchar(255),itemname varchar(255))
AS BEGIN

if @category='All'
INSERT INTO @result
SELECT category,itemcode,itemname FROM vLoadInventoryItems 
WHERE CAST(datecreated AS date)=@datecreated AND itemname LIKE '%' + @itemname + '%'
ELSE
INSERT INTO @result
SELECT category,itemcode,itemname FROM vLoadInventoryItems 
WHERE CAST(datecreated AS date)=@datecreated AND itemname LIKE '%' + @itemname + '%' AND category=@category
RETURN;
END
GO
/****** Object:  UserDefinedFunction [dbo].[funcLoadInventoryItemsLogs]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[funcLoadInventoryItemsLogs](@transnum varchar(255),@category varchar(255)
,@itemname varchar(255))
RETURNS @result TABLE(itemname varchar(255),category varchar(255),quantity float)
AS BEGIN
if @category ='All'
INSERT INTO @result
SELECT item_name,category,quantity FROM vInventoryLogs WHERE transaction_number=@transnum
AND item_name LIKE '%' + @itemname + '%'
ELSE
INSERT INTO @result
SELECT item_name,category,quantity FROM vInventoryLogs WHERE transaction_number=@transnum
AND item_name LIKE '%' + @itemname + '%' AND category=@category
return;
END
GO
/****** Object:  UserDefinedFunction [dbo].[funcLoadInventoryLogs]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[funcLoadInventoryLogs](@transnum varchar(255),
@date varchar(255),@type varchar(255),@offset int, @rowfetch int)
RETURNS @result TABLE(transaction_number varchar(255),transfer_to varchar(255),
transfer_from varchar(255),processed_by varchar(255),date datetime)
AS BEGIN
INSERT INTO @result
SELECT DISTINCT transaction_number,transfer_to,transfer_from,processed_by,
(SELECT CONVERT(CHAR(8),date,8)) FROM vInventoryLogs
WHERE transaction_number LIKE '%' +	@transnum + '%' AND CAST(date AS date)=@date
AND type=@type AND status='Completed'
ORDER BY transaction_number OFFSET @offset ROW FETCH NEXT @rowfetch ROWS ONLY
return;
END

GO
/****** Object:  UserDefinedFunction [dbo].[funcLoadItems]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[funcLoadItems](@icategory int,@category varchar(255),@itemname varchar(255),@discontinued int
,@offset int,@rowfetch int)
RETURNS @result TABLE(itemid int,itemcode varchar(255),itemname varchar(255),description varchar(255),
category varchar(255),price float,deposit int,deposit_price float)
AS BEGIN
IF @icategory = 0 AND @itemname = ''
INSERT INTO @result
SELECT a.itemid,a.itemcode,a.itemname,a.description,a.category,a.price,a.deposit,
ISNULL((SELECT price FROM tbldepositprice WHERE itemid=a.itemid AND tbldepositprice.status=1),0)
[deposit_price] FROM tblitems a WHERE a.discontinued=@discontinued ORDER BY a.category,a.itemname
OFFSET @offset ROW FETCH NEXT @rowfetch ROWS ONLY

ELSE IF @icategory !=0 AND  @itemname=''
INSERT INTO @result
SELECT a.itemid,a.itemcode,a.itemname,a.description,a.category,a.price,a.deposit,
ISNULL((SELECT price FROM tbldepositprice WHERE itemid=a.itemid AND tbldepositprice.status=1),0)
[deposit_price] FROM tblitems a WHERE a.discontinued=@discontinued AND a.category=@category ORDER BY a.category,a.itemname
OFFSET @offset ROW FETCH NEXT @rowfetch ROWS ONLY

ELSE IF @icategory =0 AND  @itemname!=''
INSERT INTO @result
SELECT a.itemid,a.itemcode,a.itemname,a.description,a.category,a.price,a.deposit,
ISNULL((SELECT price FROM tbldepositprice WHERE itemid=a.itemid AND tbldepositprice.status=1),0)
[deposit_price] FROM tblitems a WHERE a.discontinued=@discontinued AND a.itemname LIKE '%' + @itemname + '%'
ORDER BY a.category,a.itemname OFFSET @offset ROW FETCH NEXT @rowfetch ROWS ONLY

ELSE IF @icategory !=0 AND  @itemname!=''
INSERT INTO @result
SELECT a.itemid,a.itemcode,a.itemname,a.description,a.category,a.price,a.deposit,
ISNULL((SELECT price FROM tbldepositprice WHERE itemid=a.itemid AND tbldepositprice.status=1),0)
[deposit_price] FROM tblitems a WHERE a.discontinued=@discontinued AND a.itemname LIKE '%' + @itemname + '%'
AND a.category=@category ORDER BY a.category,a.itemname OFFSET @offset ROW FETCH NEXT @rowfetch ROWS ONLY
return;
END
GO
/****** Object:  UserDefinedFunction [dbo].[funcLoadOrderItems]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[funcLoadOrderItems](@ordernum int,@datee varchar(255))
RETURNS @result TABLE (itemname varchar(255),qty float,price float,dscnt float,totalprice float,
request varchar(255),free int,pricebefore float,discamt float,ordernum int,datecreated datetime)
AS BEGIN
INSERT INTO @result
SELECT itemname,qty,price,dscnt,totalprice,request,free,pricebefore,discamt,ordernum,datecreated
FROM dbo.vLoadOrderItems WHERE ordernum=@ordernum AND CAST(datecreated AS date)=@datee
RETURN;
END
GO
/****** Object:  UserDefinedFunction [dbo].[funcLoadOrders]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[funcLoadOrders](@isales int,@itypee int,@iservicetype int,
@area varchar(255),@sales varchar(255),@typee varchar(255),@tendertype varchar(255))
RETURNS @result TABLE (ordernum int,amtdue float,servicetype varchar(255),
tendertype varchar(255),createdby varchar(255),typez varchar(255),datecreated datetime,
orderid int,status2 varchar(255))
AS
BEGIN
IF @isales=0 AND @itypee = 0 AND @iservicetype =0
INSERT INTO @result
SELECT ordernum, amtdue, servicetype, tendertype, createdby,typez,datecreated,orderid,status2
FROM dbo.vOrders WHERE status2='Unpaid' AND area=@area ORDER BY ordernum DESC

ELSE IF @isales=0 AND @itypee!=0 AND @iservicetype=0
INSERT INTO @result
SELECT ordernum, amtdue, servicetype, tendertype, createdby,typez,datecreated,orderid,status2
FROM dbo.vOrders WHERE status2='Unpaid' AND area=@area AND typez=@typee ORDER BY ordernum DESC

ELSE IF @isales=0 AND @itypee=0 AND @iservicetype!=0
INSERT INTO @result
SELECT ordernum, amtdue, servicetype, tendertype, createdby,typez,datecreated,orderid,status2
FROM dbo.vOrders WHERE status2='Unpaid' AND area=@area 
AND tendertype=@tendertype ORDER BY ordernum DESC

ELSE IF @isales=0 AND @itypee!=0 AND @iservicetype!=0
INSERT INTO @result
SELECT ordernum, amtdue, servicetype, tendertype, createdby,typez,datecreated,orderid,status2
FROM dbo.vOrders WHERE status2='Unpaid' AND area=@area AND typez=@typee
AND tendertype=@tendertype ORDER BY ordernum DESC

ELSE IF @isales!=0 AND @itypee=0 AND @iservicetype=0
INSERT INTO @result
SELECT ordernum, amtdue, servicetype, tendertype, createdby,typez,datecreated,orderid,status2
FROM dbo.vOrders WHERE status2='Unpaid' AND area=@area AND cashier=@sales ORDER BY ordernum DESC

ELSE IF @isales!=0 AND @itypee!=0 AND @iservicetype=0
INSERT INTO @result
SELECT ordernum, amtdue, servicetype, tendertype, createdby,typez,datecreated,orderid,status2
FROM dbo.vOrders WHERE status2='Unpaid' AND area=@area AND cashier=@sales AND typez=@typee ORDER BY ordernum DESC

ELSE IF @isales!=0 AND @itypee!=0 AND @iservicetype!=0
INSERT INTO @result
SELECT ordernum, amtdue, servicetype, tendertype, createdby,typez,datecreated,orderid,status2
FROM dbo.vOrders WHERE status2='Unpaid' AND area=@area AND cashier=@sales AND typez=@typee
AND tendertype=@tendertype ORDER BY ordernum DESC

ELSE IF @isales!=0 AND @itypee=0 AND @iservicetype!=0
INSERT INTO @result
SELECT ordernum, amtdue, servicetype, tendertype, createdby,typez,datecreated,orderid,status2
FROM dbo.vOrders WHERE status2='Unpaid' AND area=@area AND cashier=@sales AND tendertype=@tendertype ORDER BY ordernum DESC
RETURN;
END

GO
/****** Object:  UserDefinedFunction [dbo].[funcLoadStockItems]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[funcLoadStockItems](@datecreated varchar(255),@itemname varchar(255),@category varchar(255))
RETURNS @result TABLE(category varchar(255),itemcode varchar(255),itemname varchar(255))
AS BEGIN

if @category='All'
INSERT INTO @result
SELECT category,itemcode,itemname FROM vLoadInventoryItems 
WHERE CAST(datecreated AS date)=@datecreated AND itemname LIKE '%' + @itemname + '%'
AND endbal !=0
ELSE
INSERT INTO @result
SELECT category,itemcode,itemname FROM vLoadInventoryItems 
WHERE CAST(datecreated AS date)=@datecreated AND itemname LIKE '%' + @itemname + '%' 
AND category=@category AND endbal !=0
RETURN;
END

GO
/****** Object:  UserDefinedFunction [dbo].[funcLoadUsers]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[funcLoadUsers](@username varchar(255),@workgroup varchar(255),@status int,@offset int,@rowfetch int)
RETURNS @result TABLE(systemid int,fullname varchar(255),username varchar(255),workgroup varchar(255),
branchcode varchar(255),postype varchar(255),status int)
AS BEGIN
IF @workgroup = 'All'
INSERT INTO @result
SELECT systemid,fullname,username,workgroup,branchcode,postype,status FROM vLoadUsers WHERE status=@status 
AND username LIKE '%' + @username + '%'
ORDER BY username
OFFSET @offset ROW FETCH NEXT @rowfetch ROWS ONLY
ELSE
INSERT INTO @result
SELECT systemid,fullname,username,workgroup,branchcode,postype,status FROM vLoadUsers 
WHERE status=@status AND username LIKE '%' + @username + '%' AND workgroup=@workgroup
ORDER BY username
OFFSET @offset ROW FETCH NEXT @rowfetch ROWS ONLY
RETURN;
END
GO
/****** Object:  UserDefinedFunction [dbo].[getSystemDate]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[getSystemDate]()
RETURNS DATE
AS
BEGIN
RETURN (SELECT GETDATE())
END
GO
/****** Object:  UserDefinedFunction [dbo].[loadConvIn]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[loadConvIn](@type varchar(255),@date varchar(255),
@category varchar(255),@itemname varchar(255),@ref varchar(255))
RETURNS @result TABLE(convnum varchar(255),category varchar(255),
itemname varchar(255),quantity float,timee datetime,sap varchar(255),remarks varchar(255),
outSAP varchar(255),outRemarks varchar(255))
AS BEGIN
if @category = 'All'
INSERT INTO @result
SELECT DISTINCT conv_number,category,item_name,quantity,
(SELECT CONVERT(CHAR(8),date_created,108)) [time],sap_id,remarks
,(SELECT sap_id FROM tblconversion WHERE conv_number=@ref)[outSAP]
,(SELECT remarks FROM tblconversion WHERE conv_number=@ref)[outRemarks]
FROM tblconversion WHERE type=@type AND CAST(date_created AS date)=@date
AND status='Closed' AND item_name LIKE '%' + @itemname + '%'
AND reference_number=@ref

ELSE
INSERT INTO @result
SELECT conv_number,category,item_name,quantity,
(SELECT CONVERT(CHAR(8),date_created,108)) [time],sap_id,remarks
,(SELECT sap_id FROM tblconversion WHERE conv_number=@ref)[outSAP]
,(SELECT remarks FROM tblconversion WHERE conv_number=@ref)[outRemarks]
FROM tblconversion WHERE type=@type AND CAST(date_created AS date)=@date
AND status='Closed' AND item_name LIKE '%' + @itemname + '%'
AND category=@category AND reference_number=@ref

RETURN;
END
GO
/****** Object:  UserDefinedFunction [dbo].[loadConvOut]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[loadConvOut](@type varchar(255),@date varchar(255),
@category varchar(255),@itemname varchar(255))
RETURNS @result TABLE(convnum varchar(255),category varchar(255),
itemname varchar(255),quantity float,timee datetime,sap varchar(255),remarks varchar(255))
AS BEGIN
if @category = 'All'
INSERT INTO @result
SELECT DISTINCT conv_number,category,item_name,quantity,
(SELECT CONVERT(CHAR(8),date_created,108)) [time],sap_id,remarks
FROM tblconversion WHERE type=@type AND CAST(date_created AS date)=@date
AND status='Closed' AND item_name LIKE '%' + @itemname + '%'

ELSE
INSERT INTO @result
SELECT conv_number,category,item_name,quantity,
(SELECT CONVERT(CHAR(8),date_created,108)) [time],sap_id,remarks
FROM tblconversion WHERE type=@type AND CAST(date_created AS date)=@date
AND status='Closed' AND item_name LIKE '%' + @itemname + '%'
AND category=@category

RETURN;
END
GO
/****** Object:  UserDefinedFunction [dbo].[sGetEBShort]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[sGetEBShort](@dateParameter varchar(255))
RETURNS @result TABLE (itemcode varchar(255),itemname varchar(255),charge float,price float)
AS BEGIN
INSERT INTO @result 
SELECT b.itemcode,b.itemname,c.charge,b.price 
FROM tblinvitems a INNER JOIN tblitems b 
ON a.itemname = b.itemname INNER JOIN tblproduction c 
ON a.itemname = c.item_name WHERE 
CAST(c.date AS date)=@dateParameter and 
c.type='Actual Ending Balance' AND 
a.invnum=(SELECT invnum FROM tblinvsum WHERE 
CAST(tblinvsum.datecreated AS date)=@dateParameter) 
AND a.totalav !=0 AND b.category !='Coffee Shop' 
AND c.charge !=0 GROUP BY b.itemcode,b.itemname,c.charge,b.price
RETURN;
END
GO
/****** Object:  UserDefinedFunction [dbo].[sGetName]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[sGetName](@date varchar(255))
RETURNS @result TABLE (name varchar(255),code varchar(255))
AS BEGIN
INSERT INTO @result
SELECT a.name,b.code FROM tblars1 a
INNER JOIN tblcustomers b ON a.name= b.name
WHERE 
CAST(date_created as date)='05/13/2020' AND sap_no='To Follow'
AND a.name !='Short' ORDER BY a.name,b.code
RETURN;
END
GO
/****** Object:  Table [dbo].[tbladvancepayment]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbladvancepayment](
	[ap_id] [int] IDENTITY(1,1) NOT NULL,
	[apnum] [varchar](255) NULL,
	[name] [varchar](255) NULL,
	[amount] [float] NULL,
	[date] [datetime] NULL,
	[type] [varchar](255) NULL,
	[status] [varchar](255) NULL,
	[date_cancelled] [datetime] NULL,
	[cancelled_by] [varchar](255) NULL,
	[remarks] [varchar](255) NULL,
	[from_trans] [varchar](255) NULL,
 CONSTRAINT [PK_tbladvancepayment] PRIMARY KEY CLUSTERED 
(
	[ap_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblakuitems]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblakuitems](
	[transnum] [varchar](255) NULL,
	[itemcode] [varchar](255) NULL,
	[itemname] [varchar](255) NULL,
	[category] [varchar](255) NULL,
	[qty] [float] NULL,
	[sales_qty] [float] NULL,
	[returned_qty] [float] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblakutrans]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblakutrans](
	[lakuid] [int] IDENTITY(1,1) NOT NULL,
	[customer_id] [int] NULL,
	[transnum] [varchar](255) NULL,
	[totalqty] [float] NULL,
	[amt] [float] NULL,
	[datecreated] [datetime] NULL,
	[status] [varchar](255) NULL,
 CONSTRAINT [PK_tblakutrans] PRIMARY KEY CLUSTERED 
(
	[lakuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblars1]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblars1](
	[arnum] [varchar](255) NULL,
	[transnum] [varchar](255) NULL,
	[invnum] [varchar](255) NULL,
	[amountdue] [float] NULL,
	[name] [varchar](255) NULL,
	[status] [varchar](255) NULL,
	[date_created] [datetime] NULL,
	[created_by] [varchar](255) NULL,
	[area] [varchar](255) NULL,
	[type] [varchar](255) NULL,
	[typenum] [varchar](255) NULL,
	[sap_no] [varchar](255) NULL,
	[remarks] [varchar](255) NULL,
	[balance] [float] NULL,
	[_from] [varchar](255) NULL,
	[date_cancelled] [datetime] NULL,
	[cancelled_by] [varchar](255) NULL,
	[from_transnum] [varchar](255) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblars2]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblars2](
	[transnum] [varchar](255) NULL,
	[description] [varchar](255) NULL,
	[quantity] [float] NULL,
	[price] [float] NULL,
	[amount] [float] NULL,
	[area] [varchar](255) NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblbranch]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblbranch](
	[brid] [int] IDENTITY(1,1) NOT NULL,
	[branchcode] [varchar](255) NULL,
	[branch] [nvarchar](max) NULL,
	[gr] [varchar](255) NULL,
	[sales] [varchar](255) NULL,
	[address] [nvarchar](max) NULL,
	[remarks] [nvarchar](max) NULL,
	[datecreated] [datetime] NULL,
	[createdby] [nvarchar](50) NULL,
	[datemodified] [datetime] NULL,
	[modifiedby] [nvarchar](50) NULL,
	[status] [int] NULL,
	[main] [int] NULL,
 CONSTRAINT [PK_tblbranch] PRIMARY KEY CLUSTERED 
(
	[brid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblcat]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblcat](
	[catid] [int] IDENTITY(1,1) NOT NULL,
	[category] [nvarchar](50) NULL,
	[datecreated] [datetime] NULL,
	[createdby] [nvarchar](50) NULL,
	[datemodified] [datetime] NULL,
	[modifiedby] [nvarchar](50) NULL,
	[status] [int] NULL,
 CONSTRAINT [PK_tblcats] PRIMARY KEY CLUSTERED 
(
	[catid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblcategory]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblcategory](
	[catid] [int] IDENTITY(1,1) NOT NULL,
	[category] [varchar](255) NULL,
	[datecreated] [datetime] NULL,
	[createdby] [varchar](255) NULL,
	[datemodified] [datetime] NULL,
	[modifiedby] [varchar](255) NULL,
	[status] [varchar](255) NULL,
 CONSTRAINT [PK_tblcategory] PRIMARY KEY CLUSTERED 
(
	[catid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblconversion]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblconversion](
	[conv_id] [int] IDENTITY(1,1) NOT NULL,
	[inv_number] [varchar](255) NULL,
	[conv_number] [varchar](255) NULL,
	[reference_number] [varchar](255) NULL,
	[item_code] [varchar](255) NULL,
	[item_name] [varchar](255) NULL,
	[category] [varchar](255) NULL,
	[quantity] [float] NULL,
	[type] [varchar](255) NULL,
	[status] [varchar](255) NULL,
	[typenum] [varchar](255) NULL,
	[sap_id] [varchar](255) NULL,
	[remarks] [varchar](255) NULL,
	[date_created] [datetime] NULL,
	[created_by] [varchar](255) NULL,
	[area] [varchar](255) NULL,
	[marks] [varchar](255) NULL,
 CONSTRAINT [PK_tblconversion] PRIMARY KEY CLUSTERED 
(
	[conv_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblcredits]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblcredits](
	[creditid] [int] IDENTITY(1,1) NOT NULL,
	[creditnum] [varchar](255) NULL,
	[systemid] [varchar](50) NULL,
	[amount] [float] NULL,
	[date] [datetime] NULL,
	[status] [varchar](255) NULL,
	[cashout] [float] NULL,
 CONSTRAINT [PK_tblcredits] PRIMARY KEY CLUSTERED 
(
	[creditid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblcreditslogs]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblcreditslogs](
	[logid] [int] IDENTITY(1,1) NOT NULL,
	[creditnum] [varchar](255) NULL,
	[invnum] [varchar](255) NULL,
	[systemid] [int] NULL,
	[available] [float] NULL,
	[amt] [float] NULL,
	[datecreated] [datetime] NULL,
	[processedby] [varchar](255) NULL,
	[type] [varchar](255) NULL,
	[sapdoc] [varchar](255) NULL,
	[sap] [varchar](255) NULL,
	[remarks] [varchar](255) NULL,
	[description] [varchar](255) NULL,
 CONSTRAINT [PK_tblcreditslogs] PRIMARY KEY CLUSTERED 
(
	[logid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblcsbreads]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblcsbreads](
	[breadid] [int] IDENTITY(1,1) NOT NULL,
	[csid] [int] NULL,
	[itemid] [int] NULL,
	[quantity] [float] NULL,
	[datecreated] [datetime] NULL,
	[datemodified] [datetime] NULL,
	[createdby] [int] NULL,
	[modifiedby] [int] NULL,
 CONSTRAINT [PK_tblcsbreads] PRIMARY KEY CLUSTERED 
(
	[breadid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblcsitems]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblcsitems](
	[csid] [int] IDENTITY(1,1) NOT NULL,
	[itemid] [int] NULL,
	[free] [float] NULL,
	[datecreated] [datetime] NULL,
	[datemodified] [datetime] NULL,
	[createdby] [int] NULL,
	[modifiedby] [int] NULL,
 CONSTRAINT [PK_tblcsitems] PRIMARY KEY CLUSTERED 
(
	[csid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblcustomers]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblcustomers](
	[customer_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[contact_number] [varchar](255) NULL,
	[address] [varchar](255) NULL,
	[date] [datetime] NULL,
	[created_by] [varchar](255) NULL,
	[status] [int] NULL,
	[type] [varchar](255) NULL,
	[code] [varchar](255) NULL,
 CONSTRAINT [PK_tblcustomers] PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblcutoff]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblcutoff](
	[cid] [int] IDENTITY(1,1) NOT NULL,
	[userid] [int] NULL,
	[status] [varchar](255) NULL,
	[date] [datetime] NULL,
	[date_cutoff] [datetime] NULL,
 CONSTRAINT [PK_tblcutoff] PRIMARY KEY CLUSTERED 
(
	[cid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbldeliverych]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbldeliverych](
	[delid] [int] IDENTITY(1,1) NOT NULL,
	[range] [nvarchar](max) NULL,
	[charge] [float] NULL,
	[datecreated] [datetime] NULL,
	[createdby] [nvarchar](50) NULL,
	[datemodified] [datetime] NULL,
	[modifiedby] [nvarchar](50) NULL,
	[status] [int] NULL,
 CONSTRAINT [PK_tbldeliverychs] PRIMARY KEY CLUSTERED 
(
	[delid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbldepositprice]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbldepositprice](
	[depid] [int] IDENTITY(1,1) NOT NULL,
	[itemid] [int] NULL,
	[price] [float] NULL,
	[status] [int] NULL,
 CONSTRAINT [PK_tbldepositprice] PRIMARY KEY CLUSTERED 
(
	[depid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbldiscitems]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbldiscitems](
	[discid] [int] IDENTITY(1,1) NOT NULL,
	[itemid] [int] NULL,
 CONSTRAINT [PK_tbldiscitems] PRIMARY KEY CLUSTERED 
(
	[discid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbldiscount]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbldiscount](
	[disid] [int] IDENTITY(1,1) NOT NULL,
	[disname] [nvarchar](max) NULL,
	[amount] [nvarchar](50) NULL,
	[datecreated] [datetime] NULL,
	[createdby] [nvarchar](50) NULL,
	[datemodified] [datetime] NULL,
	[modifiedby] [nvarchar](50) NULL,
	[status] [int] NULL,
 CONSTRAINT [PK_tbldiscounts] PRIMARY KEY CLUSTERED 
(
	[disid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbldiscount_items]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbldiscount_items](
	[discid] [int] IDENTITY(1,1) NOT NULL,
	[itemid] [int] NULL,
	[discount] [float] NULL,
	[datecreated] [datetime] NULL,
	[createdby] [varchar](255) NULL,
 CONSTRAINT [PK_tbldiscount_items] PRIMARY KEY CLUSTERED 
(
	[discid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblemployees]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblemployees](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[firstname] [varchar](255) NULL,
	[lastname] [varchar](255) NULL,
	[age] [varchar](255) NULL,
	[address] [text] NULL,
	[birthdate] [datetime] NULL,
 CONSTRAINT [PK_tblemployees] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblfiles]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblfiles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[filename] [varchar](255) NULL,
	[file] [varbinary](max) NULL,
	[subtype] [varchar](255) NULL,
	[type] [varchar](255) NULL,
	[datecreated] [datetime] NULL,
	[createdby] [varchar](255) NULL,
 CONSTRAINT [PK_tblfiles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblformitems]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblformitems](
	[formitemid] [int] IDENTITY(1,1) NOT NULL,
	[formid] [int] NULL,
	[category] [varchar](255) NULL,
	[itemid] [varchar](255) NULL,
	[itemname] [varchar](255) NULL,
	[value] [varchar](255) NULL,
	[datecreated] [datetime] NULL,
	[createdby] [varchar](255) NULL,
	[datemodified] [datetime] NULL,
	[modifiedby] [varchar](255) NULL,
	[datecancelled] [datetime] NULL,
	[cancelledby] [varchar](255) NULL,
	[version] [int] NULL,
	[status] [int] NULL,
 CONSTRAINT [PK_tblformitems] PRIMARY KEY CLUSTERED 
(
	[formitemid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblgctrans]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblgctrans](
	[gcid] [int] IDENTITY(1,1) NOT NULL,
	[transnum] [nvarchar](max) NULL,
	[transdate] [date] NULL,
	[amt] [float] NULL,
	[serial] [nvarchar](max) NULL,
	[customer] [nvarchar](max) NULL,
	[remarks] [nvarchar](max) NULL,
	[status] [int] NULL,
 CONSTRAINT [PK_tblgctrans] PRIMARY KEY CLUSTERED 
(
	[gcid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblgroupdisc]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblgroupdisc](
	[systemid] [int] IDENTITY(1,1) NOT NULL,
	[itemcode] [nvarchar](50) NULL,
	[itemname] [nvarchar](max) NOT NULL,
	[basedname] [nvarchar](max) NULL,
	[basedprice] [float] NULL,
	[datecreated] [datetime] NULL,
	[createdby] [nvarchar](50) NULL,
	[datemodified] [datetime] NULL,
	[modifiedby] [nvarchar](50) NULL,
	[status] [int] NULL,
 CONSTRAINT [PK_tblgroupdisc] PRIMARY KEY CLUSTERED 
(
	[systemid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblimage]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblimage](
	[imgid] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[img] [image] NOT NULL,
 CONSTRAINT [PK_tblimages] PRIMARY KEY CLUSTERED 
(
	[imgid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblinvitems]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblinvitems](
	[invid] [int] IDENTITY(1,1) NOT NULL,
	[invnum] [nvarchar](max) NULL,
	[itemcode] [nvarchar](50) NULL,
	[itemname] [nvarchar](max) NULL,
	[begbal] [float] NULL,
	[produce] [float] NULL,
	[good] [float] NULL,
	[charge] [float] NULL,
	[productionin] [float] NULL,
	[itemin] [float] NULL,
	[supin] [float] NULL,
	[adjustmentin] [float] NULL,
	[convin] [float] NULL,
	[cancelin] [float] NULL,
	[totalav] [float] NULL,
	[transfer] [float] NULL,
	[ctrout] [float] NULL,
	[archarge] [float] NULL,
	[arsales] [float] NULL,
	[convout] [float] NULL,
	[pullout] [float] NULL,
	[reject] [float] NULL,
	[reject_convin] [float] NULL,
	[reject_totalav] [float] NULL,
	[arreject] [float] NULL,
	[reject_archarge] [float] NULL,
	[reject_convout] [float] NULL,
	[reject_transfer] [float] NULL,
	[endbal] [float] NULL,
	[actualendbal] [float] NULL,
	[variance] [float] NULL,
	[shortover] [nvarchar](50) NULL,
	[shortamt] [float] NULL,
	[overamt] [float] NULL,
	[status] [int] NULL,
	[area] [varchar](255) NULL,
 CONSTRAINT [PK_tblinvitemss_1] PRIMARY KEY CLUSTERED 
(
	[invid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblinvsum]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblinvsum](
	[invsumid] [int] IDENTITY(1,1) NOT NULL,
	[invnum] [nvarchar](max) NULL,
	[invdate] [date] NULL,
	[cashier] [nvarchar](50) NULL,
	[shift] [nvarchar](50) NULL,
	[rems] [nvarchar](max) NULL,
	[verify] [int] NULL,
	[datecreated] [datetime] NULL,
	[datemodified] [datetime] NULL,
	[modifiedby] [nvarchar](50) NULL,
	[status] [int] NULL,
	[area] [varchar](255) NULL,
 CONSTRAINT [PK_tblinvsums_1] PRIMARY KEY CLUSTERED 
(
	[invsumid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblitems]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblitems](
	[itemid] [int] IDENTITY(1,1) NOT NULL,
	[category] [nvarchar](50) NULL,
	[itemcode] [nvarchar](50) NULL,
	[itemname] [nvarchar](max) NULL,
	[description] [nvarchar](max) NULL,
	[price] [float] NULL,
	[datecreated] [datetime] NULL,
	[createdby] [nvarchar](50) NULL,
	[datemodified] [datetime] NULL,
	[modifiedby] [nvarchar](50) NULL,
	[status] [int] NULL,
	[discontinued] [int] NULL,
	[validfrom] [date] NULL,
	[validuntil] [date] NULL,
	[deposit] [int] NULL,
 CONSTRAINT [PK_tblitemss] PRIMARY KEY CLUSTERED 
(
	[itemid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbllogin]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbllogin](
	[systemid] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](max) NULL,
	[login] [nvarchar](50) NULL,
	[logout] [nvarchar](50) NULL,
	[datelogin] [date] NULL,
 CONSTRAINT [PK_tbllogins] PRIMARY KEY CLUSTERED 
(
	[systemid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblmessages]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblmessages](
	[messageid] [int] IDENTITY(1,1) NOT NULL,
	[message] [varchar](255) NULL,
	[fromid] [int] NULL,
	[toid] [int] NULL,
	[datecreated] [datetime] NULL,
	[status] [varchar](255) NULL,
	[datemodified] [datetime] NULL,
	[datecancelled] [datetime] NULL,
	[dateseen] [datetime] NULL,
 CONSTRAINT [PK_tblmessages] PRIMARY KEY CLUSTERED 
(
	[messageid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblorder]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblorder](
	[orderid] [int] IDENTITY(1,1) NOT NULL,
	[transnum] [nvarchar](max) NULL,
	[invnum] [varchar](255) NULL,
	[category] [nvarchar](max) NULL,
	[itemname] [nvarchar](max) NULL,
	[qty] [float] NULL,
	[price] [float] NULL,
	[dscnt] [float] NULL,
	[totalprice] [float] NULL,
	[request] [nvarchar](max) NULL,
	[free] [float] NULL,
	[status] [int] NULL,
	[discprice] [float] NULL,
	[disctrans] [int] NULL,
	[area] [varchar](255) NULL,
	[type] [varchar](255) NULL,
	[gc] [float] NULL,
	[less] [float] NULL,
	[deliver] [float] NULL,
	[pricebefore] [float] NULL,
	[discamt] [float] NULL,
	[endbal_variance] [float] NULL,
 CONSTRAINT [PK_tblorders_1] PRIMARY KEY CLUSTERED 
(
	[orderid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblorder2]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblorder2](
	[orderid] [int] IDENTITY(1,1) NOT NULL,
	[ordernum] [int] NULL,
	[category] [nvarchar](max) NULL,
	[itemname] [nvarchar](max) NULL,
	[qty] [float] NULL,
	[price] [float] NULL,
	[dscnt] [float] NULL,
	[totalprice] [float] NULL,
	[request] [nvarchar](max) NULL,
	[free] [float] NULL,
	[status] [int] NULL,
	[discprice] [float] NULL,
	[disctrans] [int] NULL,
	[area] [varchar](255) NULL,
	[gc] [float] NULL,
	[less] [float] NULL,
	[deliver] [float] NULL,
	[datecreated] [datetime] NULL,
	[pricebefore] [float] NULL,
	[discamt] [float] NULL,
 CONSTRAINT [PK_tblorder2] PRIMARY KEY CLUSTERED 
(
	[orderid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblpendingitems]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblpendingitems](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[transnum] [varchar](255) NULL,
	[itemcode] [varchar](255) NULL,
	[itemname] [varchar](255) NULL,
	[category] [varchar](255) NULL,
	[quantity] [float] NULL,
	[good] [float] NULL,
	[charge] [float] NULL,
 CONSTRAINT [PK_tblpendingitems] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblpendingtrans]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblpendingtrans](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[invnum] [varchar](255) NULL,
	[transnum] [varchar](255) NULL,
	[quantity] [float] NULL,
	[date] [datetime] NULL,
	[createdby] [varchar](255) NULL,
	[status] [varchar](255) NULL,
 CONSTRAINT [PK_tblpendingtrans] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblproduction]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblproduction](
	[transaction_id] [int] IDENTITY(1,1) NOT NULL,
	[transaction_number] [varchar](255) NULL,
	[inv_id] [varchar](255) NULL,
	[transfer_from] [varchar](255) NULL,
	[transfer_to] [varchar](255) NULL,
	[item_code] [varchar](255) NULL,
	[item_name] [varchar](255) NULL,
	[category] [varchar](255) NULL,
	[quantity] [float] NULL,
	[reject] [varchar](255) NULL,
	[charge] [float] NULL,
	[typenum] [varchar](255) NULL,
	[sap_number] [varchar](255) NULL,
	[remarks] [varchar](255) NULL,
	[date] [datetime] NULL,
	[processed_by] [varchar](255) NULL,
	[type] [varchar](255) NULL,
	[type2] [varchar](255) NULL,
	[area] [varchar](255) NULL,
	[status] [varchar](255) NULL,
	[from_transnum] [varchar](255) NULL,
	[attachment] [image] NULL,
 CONSTRAINT [PK_tblproduction] PRIMARY KEY CLUSTERED 
(
	[transaction_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblproduction2]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblproduction2](
	[received_id] [int] NOT NULL,
	[inv_id] [varchar](255) NULL,
	[transaction_number] [varchar](255) NULL,
	[transfer_to] [varchar](255) NULL,
	[item_code] [varchar](255) NULL,
	[item_name] [varchar](255) NULL,
	[category] [varchar](255) NULL,
	[quantity] [float] NULL,
	[sap_number] [varchar](255) NULL,
	[remarks] [varchar](255) NULL,
	[date] [datetime] NULL,
	[processed_by] [varchar](255) NULL,
	[type] [varchar](255) NULL,
	[area] [varchar](255) NULL,
	[status] [varchar](255) NULL,
 CONSTRAINT [PK_tblproduction2] PRIMARY KEY CLUSTERED 
(
	[received_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblreports]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblreports](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](255) NULL,
	[filename] [varchar](255) NULL,
	[rowindex] [int] NULL,
	[status] [int] NULL,
	[datecreated] [datetime] NULL,
 CONSTRAINT [PK_tblreports] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblrequests]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblrequests](
	[requestid] [int] IDENTITY(1,1) NOT NULL,
	[fromid] [int] NULL,
	[toid] [int] NULL,
	[description] [text] NULL,
	[datecreated] [datetime] NULL,
	[datemodified] [datetime] NULL,
	[datedeleted] [datetime] NULL,
	[dateseen] [datetime] NULL,
	[dateapdis] [datetime] NULL,
	[status] [varchar](255) NULL,
 CONSTRAINT [PK_tblrequests] PRIMARY KEY CLUSTERED 
(
	[requestid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblreturns]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblreturns](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[returnum] [varchar](255) NULL,
	[ap_id] [int] NULL,
	[transnum] [varchar](255) NULL,
	[status] [varchar](255) NULL,
	[date] [datetime] NULL,
	[byy] [varchar](255) NULL,
 CONSTRAINT [PK_tblreturns] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblsaplogs]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblsaplogs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[transaction_number] [varchar](255) NULL,
	[sap_number] [varchar](255) NULL,
	[remarks] [varchar](255) NULL,
	[type] [varchar](255) NULL,
	[date] [datetime] NULL,
	[processed_by] [varchar](255) NULL,
 CONSTRAINT [PK_tblsaplogs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblsenior]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblsenior](
	[systemid] [int] IDENTITY(1,1) NOT NULL,
	[transnum] [nvarchar](max) NULL,
	[idno] [nvarchar](max) NULL,
	[name] [nvarchar](max) NULL,
	[disctype] [nvarchar](50) NULL,
	[datedisc] [date] NULL,
	[status] [int] NULL,
 CONSTRAINT [PK_tblseniors] PRIMARY KEY CLUSTERED 
(
	[systemid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbltransaction]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbltransaction](
	[transid] [int] IDENTITY(1,1) NOT NULL,
	[ornum] [nvarchar](max) NULL,
	[transnum] [nvarchar](max) NULL,
	[invnum] [varchar](255) NULL,
	[transdate] [date] NULL,
	[cashier] [nvarchar](50) NULL,
	[tendertype] [nvarchar](50) NULL,
	[servicetype] [nvarchar](50) NULL,
	[delcharge] [float] NULL,
	[subtotal] [float] NULL,
	[disctype] [nvarchar](50) NULL,
	[less] [float] NULL,
	[vatsales] [float] NULL,
	[vat] [float] NULL,
	[amtdue] [float] NULL,
	[gctotal] [float] NULL,
	[tenderamt] [float] NULL,
	[change] [float] NULL,
	[refund] [int] NULL,
	[comment] [nvarchar](max) NULL,
	[remarks] [nvarchar](max) NULL,
	[customer] [nvarchar](max) NULL,
	[tinnum] [nvarchar](max) NULL,
	[tablenum] [nvarchar](50) NULL,
	[pax] [float] NULL,
	[datecreated] [datetime] NULL,
	[datemodified] [datetime] NULL,
	[status] [int] NULL,
	[area] [varchar](255) NULL,
	[partialamt] [float] NULL,
	[typenum] [varchar](255) NULL,
	[sap_number] [varchar](255) NULL,
	[sap_remarks] [varchar](255) NULL,
	[typez] [varchar](255) NULL,
	[discamt] [float] NULL,
	[auth_systemid] [int] NULL,
	[salesname] [varchar](255) NULL,
 CONSTRAINT [PK_tbltransactions_1] PRIMARY KEY CLUSTERED 
(
	[transid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbltransaction_cancel]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbltransaction_cancel](
	[transid] [int] IDENTITY(1,1) NOT NULL,
	[ornum] [nvarchar](max) NULL,
	[transnum] [nvarchar](max) NULL,
	[invnum] [varchar](255) NULL,
	[transdate] [date] NULL,
	[cashier] [nvarchar](50) NULL,
	[tendertype] [nvarchar](50) NULL,
	[servicetype] [nvarchar](50) NULL,
	[delcharge] [float] NULL,
	[subtotal] [float] NULL,
	[disctype] [nvarchar](50) NULL,
	[less] [float] NULL,
	[vatsales] [float] NULL,
	[vat] [float] NULL,
	[amtdue] [float] NULL,
	[gctotal] [float] NULL,
	[tenderamt] [float] NULL,
	[change] [float] NULL,
	[refund] [int] NULL,
	[comment] [nvarchar](max) NULL,
	[remarks] [nvarchar](max) NULL,
	[customer] [nvarchar](max) NULL,
	[tinnum] [nvarchar](max) NULL,
	[tablenum] [nvarchar](50) NULL,
	[pax] [float] NULL,
	[datecreated] [datetime] NULL,
	[datemodified] [datetime] NULL,
	[status] [int] NULL,
	[area] [varchar](255) NULL,
	[partialamt] [float] NULL,
	[typenum] [varchar](255) NULL,
	[sap_number] [varchar](255) NULL,
	[sap_remarks] [varchar](255) NULL,
	[typez] [varchar](255) NULL,
 CONSTRAINT [PK_tbltransaction_cancel] PRIMARY KEY CLUSTERED 
(
	[transid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbltransaction2]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbltransaction2](
	[orderid] [int] IDENTITY(1,1) NOT NULL,
	[ornum] [nvarchar](max) NULL,
	[ordernum] [int] NULL,
	[transdate] [date] NULL,
	[cashier] [nvarchar](50) NULL,
	[tendertype] [nvarchar](50) NULL,
	[servicetype] [nvarchar](50) NULL,
	[delcharge] [float] NULL,
	[subtotal] [float] NULL,
	[disctype] [nvarchar](50) NULL,
	[less] [float] NULL,
	[vatsales] [float] NULL,
	[vat] [float] NULL,
	[amtdue] [float] NULL,
	[gctotal] [float] NULL,
	[tenderamt] [float] NULL,
	[change] [float] NULL,
	[refund] [int] NULL,
	[comment] [nvarchar](max) NULL,
	[remarks] [nvarchar](max) NULL,
	[customer] [nvarchar](max) NULL,
	[tinnum] [nvarchar](max) NULL,
	[tablenum] [nvarchar](50) NULL,
	[pax] [float] NULL,
	[createdby] [varchar](255) NULL,
	[datecreated] [datetime] NULL,
	[datemodified] [datetime] NULL,
	[status] [int] NULL,
	[status2] [varchar](255) NULL,
	[area] [varchar](255) NULL,
	[transnum] [varchar](255) NULL,
	[reason] [varchar](255) NULL,
	[typez] [varchar](255) NULL,
	[discamt] [float] NULL,
 CONSTRAINT [PK_tbltransaction2] PRIMARY KEY CLUSTERED 
(
	[orderid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbltransfer]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbltransfer](
	[trid] [int] IDENTITY(1,1) NOT NULL,
	[transnum] [nvarchar](max) NULL,
	[branch] [nvarchar](max) NULL,
	[remarks] [nvarchar](max) NULL,
	[datecreated] [datetime] NULL,
	[createdby] [nvarchar](50) NULL,
	[datemodified] [datetime] NULL,
	[modifiedby] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbltransfer] PRIMARY KEY CLUSTERED 
(
	[trid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblusers]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblusers](
	[systemid] [int] IDENTITY(1,1) NOT NULL,
	[fullname] [nvarchar](max) NULL,
	[username] [nvarchar](max) NULL,
	[password] [nvarchar](max) NULL,
	[workgroup] [nvarchar](50) NULL,
	[datecreated] [datetime] NULL,
	[createdby] [nvarchar](50) NULL,
	[datemodified] [datetime] NULL,
	[modifiedby] [nvarchar](50) NULL,
	[status] [int] NULL,
	[brid] [int] NULL,
	[postype] [varchar](255) NULL,
 CONSTRAINT [PK_tbluserss] PRIMARY KEY CLUSTERED 
(
	[systemid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblversion]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblversion](
	[systemid] [int] IDENTITY(1,1) NOT NULL,
	[version] [varchar](255) NULL,
	[datecreated] [datetime] NULL,
	[createdby] [varchar](255) NULL,
	[datemodified] [datetime] NULL,
	[modifiedby] [varchar](255) NULL,
	[status] [int] NULL,
 CONSTRAINT [PK_tblversion] PRIMARY KEY CLUSTERED 
(
	[systemid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[vGetInventory]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[vGetInventory]
AS
Select a.invnum,a.invid,a.itemcode,
a.itemname,b.category,a.begbal,
a.produce,a.good,a.charge,
a.productionin,a.itemin,a.supin,
a.adjustmentin,a.convin,a.totalav,
a.transfer,a.ctrout,a.archarge,
a.arsales,a.convout,a.pullout,
a.endbal,a.actualendbal,a.variance,
a.shortover,
Case When a.actualendbal > a.endbal Then ISNULL(SUM(a.actualendbal - endbal),0) * b.price End [over_amt],
ISNULL(SUM(a.ctrout * b.price),0) [ctrout_amt],ISNULL(SUM(a.archarge * b.price),0) [archarge_amt],
ISNULL(SUM(a.arsales * b.price),0) [arsales_amt] FROM tblinvitems a 
INNER JOIN tblitems b On a.itemname = b.itemname WHERE a.totalav !=0 AND  a.status=1 
GROUP BY a.invid,a.itemcode,a.itemname,b.category,a.begbal,a.produce,a.good,a.charge,a.productionin,a.itemin,a.supin,a.adjustmentin,
a.convin,a.totalav,a.transfer,a.ctrout,a.archarge,a.arsales,a.convout,a.pullout,a.endbal,a.actualendbal,a.variance,a.shortover,b.price,a.invnum
GO
/****** Object:  UserDefinedFunction [dbo].[funcgetInventory]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[funcgetInventory] (@invnum varchar(255))
RETURNS TABLE
AS
RETURN
(
 SELECT*
 FROM vgetInventory
 WHERE invnum=@invnum
)
GO
/****** Object:  View [dbo].[vgetInventory2]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vgetInventory2]
AS
Select a.invnum,a.invid,a.itemcode,
a.itemname,b.category,a.begbal,
a.produce,a.good,a.charge,
a.productionin,a.itemin,a.supin,
a.adjustmentin,a.convin,a.totalav,
a.transfer,a.ctrout,a.archarge,
a.arsales,a.convout,a.pullout,
a.endbal,a.actualendbal,a.variance,
a.shortover,
Case When a.actualendbal > a.endbal Then ISNULL(SUM(a.actualendbal - endbal),0) * b.price End [over_amt],
ISNULL(SUM(a.ctrout * b.price),0) [ctrout_amt],ISNULL(SUM(a.archarge * b.price),0) [archarge_amt],
ISNULL(SUM(a.arsales * b.price),0) [arsales_amt] FROM tblinvitems a 
INNER JOIN tblitems b On a.itemname = b.itemname WHERE a.totalav=0 AND  a.status=1 
GROUP BY a.invid,a.itemcode,a.itemname,b.category,a.begbal,a.produce,a.good,a.charge,a.productionin,a.itemin,a.supin,a.adjustmentin,
a.convin,a.totalav,a.transfer,a.ctrout,a.archarge,a.arsales,a.convout,a.pullout,a.endbal,a.actualendbal,a.variance,a.shortover,b.price,a.invnum 
GO
/****** Object:  UserDefinedFunction [dbo].[funcgetInventory2]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[funcgetInventory2] (@invnum varchar(255))
RETURNS TABLE
AS
RETURN
(
 SELECT*
 FROM vgetInventory2
 WHERE invnum=@invnum
)
GO
/****** Object:  View [dbo].[vgetCategories]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vgetCategories]
AS
SELECT category FROM tblcat WHERE status=1

GO
/****** Object:  View [dbo].[vInventoryLogs]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vInventoryLogs]
AS
SELECT transaction_number,transfer_from,transfer_to,type,processed_by,date,status,
item_name,category,quantity
FROM tblproduction
GO
/****** Object:  View [dbo].[vLoadBranches]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vLoadBranches]
AS
SELECT brid,branchcode,branch,gr,sales,status FROM tblbranch
GO
/****** Object:  View [dbo].[vLoadCategories]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vLoadCategories]
AS
SELECT catid,category,status FROM tblcat
GO
/****** Object:  View [dbo].[vLoadInventoryItems]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vLoadInventoryItems]
AS
SELECT b.category,a.itemcode,a.itemname,a.endbal,a.actualendbal,a.invnum,c.datecreated FROM tblinvitems a INNER JOIN tblitems b ON a.itemname = b.itemname
INNER JOIN tblinvsum c ON a.invnum = c.invnum
WHERE a.status=1 AND b.status=1
GO
/****** Object:  View [dbo].[vLoadItems]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vLoadItems]
AS
SELECT * FROM tblitems
GO
/****** Object:  View [dbo].[vLoadOrderItems]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vLoadOrderItems]
AS 
SELECT tblorder2.itemname,tblorder2.qty,tblorder2.price,tblorder2.dscnt,tblorder2.totalprice,
tblorder2.request,tblorder2.free,tblorder2.pricebefore,tblorder2.discamt,ordernum,datecreated FROM tblorder2
GO
/****** Object:  View [dbo].[vLoadUsers]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vLoadUsers]
AS
SELECT a.systemid,a.fullname,a.username,a.workgroup,a.status,b.branchcode,a.postype FROM tblusers a INNER JOIN tblbranch b ON a.brid= b.brid

GO
/****** Object:  View [dbo].[vOrders]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vOrders]
AS
SELECT ordernum,amtdue,servicetype,tendertype,createdby,typez,datecreated,orderid,status2,area,cashier FROM tbltransaction2
GO
/****** Object:  View [dbo].[vPendingConvOut]    Script Date: 05/25/2020 5:50:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vPendingConvOut]
AS
SELECT conv_number FROM tblconversion WHERE inv_number=
(Select TOP 1 invnum from tblinvsum WHERE area='Sales' order by invsumid DESC) 
AND type='Parent' AND status='Open'
GO
USE [master]
GO
ALTER DATABASE [AKPOS] SET  READ_WRITE 
GO
