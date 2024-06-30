If Not Exists(Select * From sys.databases Where name = 'AracKiralamaDB')
	Create Database AracKiralamaDB
Go
Use AracKiralamaDB
Go
If Not Exists(Select * From INFORMATION_SCHEMA.TABLES Where TABLE_NAME = 'ArabaMarkalari')
	Create Table ArabaMarkalari
	(
		ArabaMarkaID	int identity,
		ArabaMarkaAdi	varchar(50),
		constraint pk_ArabaMarkalari_ArabaMarkaID primary key(ArabaMarkaID)
	)
Go
If Not Exists(Select * From INFORMATION_SCHEMA.TABLES Where TABLE_NAME = 'ArabaModelleri')
	Create Table ArabaModelleri
	(
		ArabaModelID	int identity,
		ArabaMarkaID	int,
		ArabaModelAdi	varchar(50),
		constraint pk_ArabaModelleri_ArabaModelID primary key(ArabaModelID),
		Constraint FK_ArabaModelleri_ArabaMarkaID Foreign Key(ArabaMarkaID) References ArabaMarkalari(ArabaMarkaID),

	)
Go
If Not Exists(Select * From INFORMATION_SCHEMA.TABLES Where TABLE_NAME = 'ArabaVitesTurleri')
	Create Table ArabaVitesTurleri
	(
		ArabaVitesTurID	int identity,
		ArabaVitesTurAdi	varchar(50),
		constraint pk_ArabaVitesTurleri_ArabaVitesTurID primary key(ArabaVitesTurID)
	)
Go
If Not Exists(Select * From INFORMATION_SCHEMA.TABLES Where TABLE_NAME = 'ArabaTurleri')
	Create Table ArabaTurleri
	(
		ArabaTurID	int identity,
		ArabaTurAdi	varchar(50),
		constraint pk_ArabaTurleri_ArabaTurID primary key(ArabaTurID)
	)
Go
If Not Exists(Select * From INFORMATION_SCHEMA.TABLES Where TABLE_NAME = 'Kullanicilar')
CREATE TABLE Kullanicilar (
   KullaniciID INT IDENTITY,
   KullaniciAdi VARCHAR(50) NOT NULL UNIQUE,
   Sifre VARCHAR(50) NOT NULL,
   Kullanýcý_Tipi VARCHAR(50) NOT NULL,
   Constraint PK_MusteriKullanicilari_KullaniciID Primary Key(KullaniciID),
);
Go
If Not Exists(Select * From INFORMATION_SCHEMA.TABLES Where TABLE_NAME = 'ArabaResimleri')
CREATE TABLE ArabaResimleri (
   ArabaResimID INT IDENTITY,
   Resim VARCHAR(MAX) NOT NULL,
   Constraint PK_ArabaResimleri_ArabaResimID Primary Key(ArabaResimID)
);
Go
If Not Exists(Select * From INFORMATION_SCHEMA.TABLES Where TABLE_NAME = 'Arabalar')
CREATE TABLE Arabalar (
   ArabaID INT IDENTITY, 
   ArabaMarkaID INT,
   ArabaModelID INT,
   ArabaVitesTurID INT,
   ArabaTurID INT,
   ArabaResimID INT,
   Plaka VARCHAR(10) NOT NULL,
   YakitTuru VARCHAR(20) NOT NULL,
   Fiyat VARCHAR(10)NOT NULL,
   Yýl VARCHAR(10)NOT NULL,
   KoltukSayisi INT NOT NULL,
   BagajHacmi DECIMAL(5, 2) NOT NULL,
   MotorHacmi VARCHAR(10)NOT NULL,
   MotorGucu INT NOT NULL,
   Klima BIT NOT NULL,
   Navigasyon BIT NOT NULL,
   GeriGorusKamerasi BIT NOT NULL,
   ParkSensoru BIT NOT NULL,
   Bluetooth BIT NOT NULL,
   USBPortu BIT NOT NULL,
   Sunroof BIT NOT NULL,
   Constraint pk_Arabalar_ArabaID primary key(ArabaID),
   Constraint FK_Arabalar_ArabaMarkaID Foreign Key(ArabaMarkaID) References ArabaMarkalari(ArabaMarkaID),
   Constraint FK_Arabalar_ArabaModelID Foreign Key(ArabaModelID) References ArabaModelleri(ArabaModelID),
   Constraint FK_Arabalar_ArabaVitesTurID Foreign Key(ArabaVitesTurID) References ArabaVitesTurleri(ArabaVitesTurID),
   Constraint FK_Arabalar_ArabaTurID Foreign Key(ArabaTurID) References ArabaTurleri(ArabaTurID),
   Constraint FK_Arabalar_ArabaResimID Foreign Key(ArabaResimID) References ArabaResimleri(ArabaResimID)
);
Go
If Not Exists(Select * From INFORMATION_SCHEMA.TABLES Where TABLE_NAME = 'Cinsiyetler')
	Create Table Cinsiyetler
	(
		CinsiyetID	int identity,
		CinsiyetAdi	varchar(50),
		Constraint PK_Cinsiyetler_CinsiyetID Primary Key(CinsiyetID),
		Constraint AN_Cinsiyetler_CinsiyetID Unique(CinsiyetID)
	)
Go
If Not Exists(Select * From INFORMATION_SCHEMA.TABLES Where TABLE_NAME = 'Adminler')
CREATE TABLE Adminler (
   AdminID INT IDENTITY,    
   KullaniciAdi VARCHAR(50) NOT NULL UNIQUE,
   Sifre VARCHAR(50) NOT NULL,
   Kullanýcý_Tipi VARCHAR(50) NOT NULL,
   Ad VARCHAR(50) NOT NULL,
   Soyad VARCHAR(50) NOT NULL,
   CinsiyetID INT,
   Email VARCHAR(50) NOT NULL UNIQUE,
   TelefonNo VARCHAR(20) NOT NULL,
   Ýl NVARCHAR(20) NOT NULL,
   Ýlce NVARCHAR(20) NOT NULL,
   Adres VARCHAR(100) NOT NULL,
   Constraint PK_Adminler_AdminID Primary Key(AdminID),
   Constraint FK_Adminler_CinsiyetID Foreign Key(CinsiyetID) References Cinsiyetler(CinsiyetID)
);
Go
If Not Exists(Select * From INFORMATION_SCHEMA.TABLES Where TABLE_NAME = 'Musteriler')
CREATE TABLE Musteriler (
    MusteriID INT IDENTITY,
	KullaniciAdi VARCHAR(50) NOT NULL UNIQUE,
    Sifre VARCHAR(50) NOT NULL,
    Kullanýcý_Tipi VARCHAR(50) NOT NULL,
    Adi NVARCHAR(50) NOT NULL,
    Soyadi NVARCHAR(50) NOT NULL,
	CinsiyetID INT,
    DogumTarihi DATE NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    TelefonNo NVARCHAR(20) NOT NULL,
   	Ýl NVARCHAR(20) NOT NULL,
	Ýlce NVARCHAR(20) NOT NULL,
	Adres NVARCHAR(200) NOT NULL,	
    EhliyetNo NVARCHAR(50) NOT NULL,
    EhliyetAlýmTarihi DATE NOT NULL,  
    AcilDurumKisiAdi NVARCHAR(100) NOT NULL,
    AcilDurumKisiNO NVARCHAR(20) NOT NULL,
    AcilDurumYakýnlýkDerecesi NVARCHAR(50) NOT NULL,
	Constraint PK_Musteriler_MusteriID Primary Key(MusteriID),
	Constraint FK_Musteriler_CinsiyetID Foreign Key(CinsiyetID) References Cinsiyetler(CinsiyetID)

)
Go

If Not Exists(Select * From INFORMATION_SCHEMA.TABLES Where TABLE_NAME = 'Kiralamalar')
CREATE TABLE Kiralamalar (
   KiralamaID INT IDENTITY,
   MusteriID INT NOT NULL,
   ArabaID INT NOT NULL,
   KiraTarihi DATE NOT NULL,
   KiraDurumu BIT NOT NULL,
   Constraint PK_Kiralamalar_KiralamaID Primary Key(KiralamaID),
   Constraint FK_Kiralamalar_MusteriID Foreign Key(MusteriID) References Musteriler(MusteriID),
   Constraint FK_Kiralamalar_ArabaID Foreign Key(ArabaID) References Arabalar(ArabaID)
);
GO
Create TRIGGER müsterilereklemee on dbo.Musteriler AFTER INSERT 
AS 
 SET NOCOUNT ON 
 INSERT INTO dbo.Kullanicilar(KullaniciAdi,Sifre,Kullanýcý_Tipi) Select KullaniciAdi,Sifre,Kullanýcý_Tipi  FROM inserted
Go 
Create TRIGGER adminlereklemee on dbo.Adminler AFTER INSERT 
AS 
 SET NOCOUNT ON 
 INSERT INTO dbo.Kullanicilar(KullaniciAdi,Sifre,Kullanýcý_Tipi) Select KullaniciAdi,Sifre,Kullanýcý_Tipi FROM inserted
Go 
