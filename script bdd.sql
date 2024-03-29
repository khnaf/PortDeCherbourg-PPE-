USE [master]
GO
/****** Object:  Database [GEscale]    Script Date: 05/04/2019 17:12:40 ******/
CREATE DATABASE [GEscale]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GEscale', FILENAME = N'D:\Microsoft SQL Server\MSSQL13.SIOI\MSSQL\DATA\GEscale.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GEscale_log', FILENAME = N'D:\Microsoft SQL Server\MSSQL13.SIOI\MSSQL\DATA\GEscale_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [GEscale] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GEscale].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GEscale] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GEscale] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GEscale] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GEscale] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GEscale] SET ARITHABORT OFF 
GO
ALTER DATABASE [GEscale] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GEscale] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GEscale] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GEscale] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GEscale] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GEscale] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GEscale] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GEscale] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GEscale] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GEscale] SET  ENABLE_BROKER 
GO
ALTER DATABASE [GEscale] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GEscale] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GEscale] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GEscale] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GEscale] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GEscale] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GEscale] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GEscale] SET RECOVERY FULL 
GO
ALTER DATABASE [GEscale] SET  MULTI_USER 
GO
ALTER DATABASE [GEscale] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GEscale] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GEscale] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GEscale] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GEscale] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GEscale] SET QUERY_STORE = OFF
GO
USE [GEscale]
GO
/****** Object:  User [PRINCE\tdealmeida]    Script Date: 05/04/2019 17:12:40 ******/
CREATE USER [PRINCE\tdealmeida] FOR LOGIN [PRINCE\tdealmeida] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [PRINCE\kguillermin]    Script Date: 05/04/2019 17:12:40 ******/
CREATE USER [PRINCE\kguillermin] FOR LOGIN [PRINCE\kguillermin] WITH DEFAULT_SCHEMA=[PRINCE\kguillermin]
GO
/****** Object:  User [PRINCE\gbartolo]    Script Date: 05/04/2019 17:12:40 ******/
CREATE USER [PRINCE\gbartolo] FOR LOGIN [PRINCE\gbartolo] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [PRINCE\aduvois]    Script Date: 05/04/2019 17:12:40 ******/
CREATE USER [PRINCE\aduvois] FOR LOGIN [PRINCE\aduvois] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [PRINCE\2sioslam]    Script Date: 05/04/2019 17:12:40 ******/
CREATE USER [PRINCE\2sioslam] FOR LOGIN [PRINCE\2sioslam]
GO
/****** Object:  User [anonyme]    Script Date: 05/04/2019 17:12:40 ******/
CREATE USER [anonyme] FOR LOGIN [anonyme] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [PRINCE\tdealmeida]
GO
ALTER ROLE [db_owner] ADD MEMBER [PRINCE\gbartolo]
GO
ALTER ROLE [db_owner] ADD MEMBER [PRINCE\aduvois]
GO
ALTER ROLE [db_owner] ADD MEMBER [PRINCE\2sioslam]
GO
ALTER ROLE [db_datareader] ADD MEMBER [PRINCE\2sioslam]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [PRINCE\2sioslam]
GO
ALTER ROLE [db_datareader] ADD MEMBER [anonyme]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [anonyme]
GO
/****** Object:  Schema [PRINCE\kguillermin]    Script Date: 05/04/2019 17:12:40 ******/
CREATE SCHEMA [PRINCE\kguillermin]
GO
/****** Object:  UserDefinedFunction [dbo].[DureeEscale]    Script Date: 05/04/2019 17:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[DureeEscale](@NumeroEscale int) RETURNS int
AS
BEGIN

Declare @Duree integer

Select @Duree=datediff(DAY,DatArr,DatDep) from ESCALE WHERE NumEsc=@NumeroEscale

	RETURN @Duree

END



GO
/****** Object:  Table [dbo].[ESCALE]    Script Date: 05/04/2019 17:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ESCALE](
	[NumEsc] [int] IDENTITY(1,1) NOT NULL,
	[DatArr] [date] NULL,
	[HeureArr] [time](7) NULL,
	[DatDep] [date] NULL,
	[HeureDep] [time](7) NULL,
	[QteFre] [decimal](18, 0) NULL,
	[ConEsc] [bit] NULL,
	[CTyCar] [nchar](5) NULL,
	[CodAge] [nchar](5) NULL,
	[NumLlo] [nchar](7) NULL,
	[CodPavProv] [nchar](3) NULL,
	[CodPorProv] [nchar](2) NULL,
	[CodPavDest] [nchar](3) NULL,
	[CodPorDest] [nchar](2) NULL,
	[NumPilEntree] [nchar](5) NULL,
	[NumPilSortie] [nchar](5) NULL,
 CONSTRAINT [PK_ESCALE] PRIMARY KEY CLUSTERED 
(
	[NumEsc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TYPE-NAVIRE]    Script Date: 05/04/2019 17:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TYPE-NAVIRE](
	[CTyNav] [nchar](2) NOT NULL,
	[LibTyp] [nchar](30) NULL,
 CONSTRAINT [PK_TYPE-NAVIRE] PRIMARY KEY CLUSTERED 
(
	[CTyNav] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NAVIRE]    Script Date: 05/04/2019 17:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NAVIRE](
	[NumLlo] [nchar](7) NOT NULL,
	[NomNav] [nchar](30) NULL,
	[AnnCon] [smallint] NULL,
	[DatDre] [date] NULL,
	[LarNav] [decimal](18, 0) NULL,
	[LongNav] [decimal](18, 0) NULL,
	[TirEau] [decimal](18, 0) NULL,
	[ProNav] [bit] NULL,
	[CapNav] [int] NULL,
	[NumArm] [int] NULL,
	[CTyNav] [nchar](2) NULL,
	[CodPav] [nchar](3) NULL,
	[CodPor] [nchar](2) NULL,
	[NumCom] [int] NULL,
 CONSTRAINT [PK_NAVIRE] PRIMARY KEY CLUSTERED 
(
	[NumLlo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[NaviresDansPort]    Script Date: 05/04/2019 17:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[NaviresDansPort]
AS
SELECT        dbo.NAVIRE.NumLlo, dbo.NAVIRE.NomNav, dbo.[TYPE-NAVIRE].LibTyp, dbo.ESCALE.DatArr, dbo.ESCALE.DatDep
FROM            dbo.ESCALE INNER JOIN
                         dbo.NAVIRE ON dbo.ESCALE.NumLlo = dbo.NAVIRE.NumLlo INNER JOIN
                         dbo.[TYPE-NAVIRE] ON dbo.NAVIRE.CTyNav = dbo.[TYPE-NAVIRE].CTyNav
WHERE        (GETDATE() BETWEEN dbo.ESCALE.DatArr AND dbo.ESCALE.DatDep)
GO
/****** Object:  UserDefinedFunction [dbo].[ListeArrivee]    Script Date: 05/04/2019 17:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[ListeArrivee] (@DateArrive as date, @TrancheHorraireDebut as time(7), @TrancheHorraireFin as time(7)) returns table as
return select NAVIRE.[NumLlo] as 'N° Lloyds', [NomNav] as 'Nom du bateau', [HeureArr] as 'Heure arrivé prévue'
from ESCALE, NAVIRE
Where NAVIRE.[NumLlo]=ESCALE.[NumLlo] and @DateArrive=[DatArr] and [HeureArr] between @TrancheHorraireDebut and @TrancheHorraireFin
GO
/****** Object:  UserDefinedFunction [dbo].[ListeDepart]    Script Date: 05/04/2019 17:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[ListeDepart] (@DateDep as date, @TrancheHorraireDebut as time(7), @TrancheHorraireFin as time(7)) returns table as
return select NAVIRE.[NumLlo] as 'N° Lloyds', [NomNav] as 'Nom du bateau', [HeureDep] as 'Heure départ prévue'
from ESCALE, NAVIRE
Where NAVIRE.[NumLlo]=ESCALE.[NumLlo] and @DateDep=[DatDep] and [HeureDep] between @TrancheHorraireDebut and @TrancheHorraireFin
GO
/****** Object:  Table [dbo].[AGENT]    Script Date: 05/04/2019 17:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AGENT](
	[CodAge] [nchar](5) NOT NULL,
	[PrenAge] [nchar](25) NULL,
	[NomAge] [nchar](30) NULL,
	[TelAge] [nchar](10) NULL,
	[EMaAgent] [nchar](30) NULL,
 CONSTRAINT [PK_AGENT] PRIMARY KEY CLUSTERED 
(
	[CodAge] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ARMATEUR]    Script Date: 05/04/2019 17:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ARMATEUR](
	[NumArm] [int] NOT NULL,
	[NomArm] [nchar](35) NULL,
	[AdrArm] [nchar](40) NULL,
	[CPoArm] [nchar](5) NULL,
	[VilArm] [nchar](35) NULL,
	[TelArm] [nchar](10) NULL,
	[FaxArm] [nchar](10) NULL,
	[EmaArm] [nchar](25) NULL,
	[CodPav] [nchar](3) NULL,
 CONSTRAINT [PK_ARMATEUR] PRIMARY KEY CLUSTERED 
(
	[NumArm] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[COMMANDANT]    Script Date: 05/04/2019 17:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COMMANDANT](
	[NumCom] [int] NOT NULL,
	[NomCom] [nchar](35) NULL,
	[TelCom] [nchar](10) NULL,
	[MelCom] [nchar](35) NULL,
 CONSTRAINT [PK_COMMANDANT] PRIMARY KEY CLUSTERED 
(
	[NumCom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[COMMANDER]    Script Date: 05/04/2019 17:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COMMANDER](
	[NumCom] [int] NOT NULL,
	[DateDebutComm] [date] NOT NULL,
	[NumLlo] [nchar](7) NOT NULL,
	[DateFinComm] [date] NULL,
 CONSTRAINT [PK__COMMANDE__B2901A51127CE2AA] PRIMARY KEY CLUSTERED 
(
	[NumCom] ASC,
	[DateDebutComm] ASC,
	[NumLlo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DATE-DEBUT-COMM]    Script Date: 05/04/2019 17:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DATE-DEBUT-COMM](
	[DateDebutComm] [date] NOT NULL,
 CONSTRAINT [PK_DATE-DEBUT-COMM] PRIMARY KEY CLUSTERED 
(
	[DateDebutComm] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EMPLOYE]    Script Date: 05/04/2019 17:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EMPLOYE](
	[NumEmp] [nchar](5) NOT NULL,
	[NomEmp] [nchar](35) NULL,
	[TelEmp] [nchar](10) NULL,
	[MelEmp] [nchar](35) NULL,
	[MdpEmp] [nchar](25) NULL,
 CONSTRAINT [PK_EMPLOYE] PRIMARY KEY CLUSTERED 
(
	[NumEmp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GERER]    Script Date: 05/04/2019 17:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GERER](
	[NumArm] [int] NOT NULL,
	[CodAge] [nchar](5) NOT NULL,
 CONSTRAINT [PK_GERER] PRIMARY KEY CLUSTERED 
(
	[NumArm] ASC,
	[CodAge] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PAVILLON]    Script Date: 05/04/2019 17:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PAVILLON](
	[CodPav] [nchar](3) NOT NULL,
	[LibPav] [nchar](30) NULL,
 CONSTRAINT [PK_PAVILLON] PRIMARY KEY CLUSTERED 
(
	[CodPav] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PILOTE]    Script Date: 05/04/2019 17:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PILOTE](
	[NumPil] [nchar](5) NOT NULL,
	[NomPil] [nchar](35) NULL,
	[TelPil] [nchar](10) NULL,
	[MelPil] [nchar](35) NULL,
	[PrenPil] [nchar](35) NULL,
	[CodPav] [nchar](3) NULL,
	[NumEsc] [int] NULL,
 CONSTRAINT [PK_PILOTE] PRIMARY KEY CLUSTERED 
(
	[NumPil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PORT]    Script Date: 05/04/2019 17:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PORT](
	[CodPav] [nchar](3) NOT NULL,
	[CodPor] [nchar](2) NOT NULL,
	[NomPor] [nchar](30) NULL,
 CONSTRAINT [PK_PORT_1] PRIMARY KEY CLUSTERED 
(
	[CodPor] ASC,
	[CodPav] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TYPE-CARGAISON]    Script Date: 05/04/2019 17:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TYPE-CARGAISON](
	[CTyCar] [nchar](5) NOT NULL,
	[LibCar] [nchar](10) NULL,
	[DanCar] [bit] NULL,
	[CTyNav] [nchar](2) NULL,
 CONSTRAINT [PK_TYPE-CARGAISON] PRIMARY KEY CLUSTERED 
(
	[CTyCar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AGENT] ([CodAge], [PrenAge], [NomAge], [TelAge], [EMaAgent]) VALUES (N'1    ', N'Rafael                   ', N'Nadal                         ', N'0612345678', N'rafael.nadal@gmail.com        ')
INSERT [dbo].[AGENT] ([CodAge], [PrenAge], [NomAge], [TelAge], [EMaAgent]) VALUES (N'16   ', N'fezefzeafd               ', N'ecfersgfrebg                  ', N'3061518495', N'fezaffegbhtybj                ')
INSERT [dbo].[AGENT] ([CodAge], [PrenAge], [NomAge], [TelAge], [EMaAgent]) VALUES (N'2    ', N'Roger                    ', N'Federer                       ', N'0201020102', N'roger@federer.fr              ')
INSERT [dbo].[AGENT] ([CodAge], [PrenAge], [NomAge], [TelAge], [EMaAgent]) VALUES (N'3    ', N'Kylian                   ', N'Mbappe                        ', N'0651525354', N'kylian.mbappe@gmail.com       ')
INSERT [dbo].[AGENT] ([CodAge], [PrenAge], [NomAge], [TelAge], [EMaAgent]) VALUES (N'4    ', N'Lionel                   ', N'Messi                         ', N'0621222324', N'lionel.messi@gmail.com        ')
INSERT [dbo].[AGENT] ([CodAge], [PrenAge], [NomAge], [TelAge], [EMaAgent]) VALUES (N'5    ', N'Cristiano                ', N'Ronaldo                       ', N'0631323334', N'cristiano.ronaldo@gmail.com   ')
INSERT [dbo].[AGENT] ([CodAge], [PrenAge], [NomAge], [TelAge], [EMaAgent]) VALUES (N'6    ', N'Robert                   ', N'Michel                        ', N'0658695847', N'michel.robert@gmail.com       ')
INSERT [dbo].[AGENT] ([CodAge], [PrenAge], [NomAge], [TelAge], [EMaAgent]) VALUES (N'7    ', N'duihzeuidzd              ', N'dezbdzeyd                     ', N'0632549861', N'fbzeubfze@hie.fr              ')
INSERT [dbo].[ARMATEUR] ([NumArm], [NomArm], [AdrArm], [CPoArm], [VilArm], [TelArm], [FaxArm], [EmaArm], [CodPav]) VALUES (0, N'sfde                               ', N'sfd                                     ', N'sdf  ', N'sdf                                ', N'sfd       ', N'sdf       ', N'sfd                      ', N'11 ')
INSERT [dbo].[ARMATEUR] ([NumArm], [NomArm], [AdrArm], [CPoArm], [VilArm], [TelArm], [FaxArm], [EmaArm], [CodPav]) VALUES (1, N'Jackson                            ', N'1 rue des poulets                       ', N'83600', N'Frejus                             ', N'0681828384', N'0125487896', N'michael.jackson@gmail.com', N'001')
INSERT [dbo].[ARMATEUR] ([NumArm], [NomArm], [AdrArm], [CPoArm], [VilArm], [TelArm], [FaxArm], [EmaArm], [CodPav]) VALUES (2, N'deded                              ', N'2 rue des haltères                      ', N'83700', N'Saint-Raphael                      ', N'0612457889', N'0154789632', N'tibo.inshape@gmail.com   ', N'015')
INSERT [dbo].[ARMATEUR] ([NumArm], [NomArm], [AdrArm], [CPoArm], [VilArm], [TelArm], [FaxArm], [EmaArm], [CodPav]) VALUES (3, N'Hallyday                           ', N'3 rue du Rock                           ', N'83700', N'Saint-Raphael                      ', N'0645781263', N'0136478596', N'johnny.hallyday@gmail.com', N'010')
INSERT [dbo].[ARMATEUR] ([NumArm], [NomArm], [AdrArm], [CPoArm], [VilArm], [TelArm], [FaxArm], [EmaArm], [CodPav]) VALUES (4, N'Trump                              ', N'4 rue du Mexique                        ', N'13001', N'Marseille                          ', N'0652416398', N'0178451254', N'donald.trump@gmail.com   ', N'005')
INSERT [dbo].[ARMATEUR] ([NumArm], [NomArm], [AdrArm], [CPoArm], [VilArm], [TelArm], [FaxArm], [EmaArm], [CodPav]) VALUES (5, N'5                                  ', N'5                                       ', N'5    ', N'5                                  ', N'5         ', N'5         ', N'5                        ', N'002')
INSERT [dbo].[ARMATEUR] ([NumArm], [NomArm], [AdrArm], [CPoArm], [VilArm], [TelArm], [FaxArm], [EmaArm], [CodPav]) VALUES (55, N'KEKEtest                           ', N'Adresse de KEKE                         ', N'83600', N'KEKELAND                           ', N'0654789652', N'012548698 ', N'KEKE@KEKE.KEKE           ', N'012')
INSERT [dbo].[COMMANDANT] ([NumCom], [NomCom], [TelCom], [MelCom]) VALUES (0, N'jack                               ', N'0625412398', N'jjjj@gmx.fr                        ')
INSERT [dbo].[COMMANDANT] ([NumCom], [NomCom], [TelCom], [MelCom]) VALUES (1, N'Maxime                             ', N'0654789632', N'maxime.colle@gmail.com             ')
INSERT [dbo].[COMMANDANT] ([NumCom], [NomCom], [TelCom], [MelCom]) VALUES (2, N'Bartololo                          ', N'0645658965', N'test@hotmail.fr                    ')
INSERT [dbo].[COMMANDANT] ([NumCom], [NomCom], [TelCom], [MelCom]) VALUES (3, N'Lesdema                            ', N'0654859675', N'jojo@hotmail.fr                    ')
INSERT [dbo].[COMMANDANT] ([NumCom], [NomCom], [TelCom], [MelCom]) VALUES (4, N'John                               ', N'0625144587', N'yolo@gmail.com                     ')
INSERT [dbo].[COMMANDANT] ([NumCom], [NomCom], [TelCom], [MelCom]) VALUES (5, N'Rick                               ', N'0625451232', N'bigflo@gmail.com                   ')
INSERT [dbo].[COMMANDANT] ([NumCom], [NomCom], [TelCom], [MelCom]) VALUES (6, N'MacronPresidentOuPas               ', N'0600000000', N'macronpresident@gmail.com          ')
INSERT [dbo].[EMPLOYE] ([NumEmp], [NomEmp], [TelEmp], [MelEmp], [MdpEmp]) VALUES (N'1    ', N'Auproux                            ', N'0524785963', N'agathe.auproux@gmail.com           ', N'mdpagathe                ')
INSERT [dbo].[EMPLOYE] ([NumEmp], [NomEmp], [TelEmp], [MelEmp], [MdpEmp]) VALUES (N'2    ', N'Damso                              ', N'0631547896', N'damso@gmail.com                    ', N'mdpdamso                 ')
INSERT [dbo].[EMPLOYE] ([NumEmp], [NomEmp], [TelEmp], [MelEmp], [MdpEmp]) VALUES (N'3    ', N'Booba                              ', N'0666666666', N'booba@gmail.com                    ', N'mdpbooba                 ')
INSERT [dbo].[EMPLOYE] ([NumEmp], [NomEmp], [TelEmp], [MelEmp], [MdpEmp]) VALUES (N'4    ', N'Hanni                              ', N'0687055192', N'ewenhanni@hotmail.fr               ', N'mdpewen                  ')
INSERT [dbo].[EMPLOYE] ([NumEmp], [NomEmp], [TelEmp], [MelEmp], [MdpEmp]) VALUES (N'5    ', N'euQuatre                           ', N'0404040404', N'monsieur.e4@e4.com                 ', N'epreuvee4                ')
INSERT [dbo].[EMPLOYE] ([NumEmp], [NomEmp], [TelEmp], [MelEmp], [MdpEmp]) VALUES (N'6    ', N'Ademo                              ', N'0644121212', N'au.dd@pnl.lemondechico             ', N'audd                     ')
SET IDENTITY_INSERT [dbo].[ESCALE] ON 

INSERT [dbo].[ESCALE] ([NumEsc], [DatArr], [HeureArr], [DatDep], [HeureDep], [QteFre], [ConEsc], [CTyCar], [CodAge], [NumLlo], [CodPavProv], [CodPorProv], [CodPavDest], [CodPorDest], [NumPilEntree], [NumPilSortie]) VALUES (1, CAST(N'2018-11-10' AS Date), CAST(N'01:25:00' AS Time), CAST(N'2019-04-30' AS Date), CAST(N'19:00:00' AS Time), CAST(0 AS Decimal(18, 0)), 0, N'1    ', N'1    ', N'01     ', N'001', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ESCALE] ([NumEsc], [DatArr], [HeureArr], [DatDep], [HeureDep], [QteFre], [ConEsc], [CTyCar], [CodAge], [NumLlo], [CodPavProv], [CodPorProv], [CodPavDest], [CodPorDest], [NumPilEntree], [NumPilSortie]) VALUES (2, CAST(N'2017-11-30' AS Date), CAST(N'14:16:00' AS Time), CAST(N'2017-12-30' AS Date), CAST(N'19:00:00' AS Time), CAST(20 AS Decimal(18, 0)), 1, N'3    ', N'2    ', N'01     ', N'001', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ESCALE] ([NumEsc], [DatArr], [HeureArr], [DatDep], [HeureDep], [QteFre], [ConEsc], [CTyCar], [CodAge], [NumLlo], [CodPavProv], [CodPorProv], [CodPavDest], [CodPorDest], [NumPilEntree], [NumPilSortie]) VALUES (3, CAST(N'2018-11-30' AS Date), CAST(N'09:20:00' AS Time), CAST(N'2018-12-01' AS Date), CAST(N'08:00:00' AS Time), CAST(0 AS Decimal(18, 0)), 1, N'1    ', N'2    ', N'02     ', N'001', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ESCALE] ([NumEsc], [DatArr], [HeureArr], [DatDep], [HeureDep], [QteFre], [ConEsc], [CTyCar], [CodAge], [NumLlo], [CodPavProv], [CodPorProv], [CodPavDest], [CodPorDest], [NumPilEntree], [NumPilSortie]) VALUES (4, CAST(N'2018-11-30' AS Date), CAST(N'10:13:00' AS Time), CAST(N'2018-12-01' AS Date), CAST(N'09:25:00' AS Time), CAST(10 AS Decimal(18, 0)), 0, N'2    ', N'1    ', N'01     ', N'001', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ESCALE] ([NumEsc], [DatArr], [HeureArr], [DatDep], [HeureDep], [QteFre], [ConEsc], [CTyCar], [CodAge], [NumLlo], [CodPavProv], [CodPorProv], [CodPavDest], [CodPorDest], [NumPilEntree], [NumPilSortie]) VALUES (5, CAST(N'2018-11-30' AS Date), CAST(N'11:05:00' AS Time), CAST(N'2018-12-01' AS Date), CAST(N'09:42:00' AS Time), CAST(11 AS Decimal(18, 0)), 0, N'3    ', N'1    ', N'01     ', N'001', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ESCALE] ([NumEsc], [DatArr], [HeureArr], [DatDep], [HeureDep], [QteFre], [ConEsc], [CTyCar], [CodAge], [NumLlo], [CodPavProv], [CodPorProv], [CodPavDest], [CodPorDest], [NumPilEntree], [NumPilSortie]) VALUES (6, CAST(N'2018-11-30' AS Date), CAST(N'09:45:00' AS Time), CAST(N'2018-11-30' AS Date), CAST(N'10:50:00' AS Time), CAST(20 AS Decimal(18, 0)), 1, N'2    ', N'2    ', N'02     ', N'001', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ESCALE] ([NumEsc], [DatArr], [HeureArr], [DatDep], [HeureDep], [QteFre], [ConEsc], [CTyCar], [CodAge], [NumLlo], [CodPavProv], [CodPorProv], [CodPavDest], [CodPorDest], [NumPilEntree], [NumPilSortie]) VALUES (7, CAST(N'2018-12-13' AS Date), CAST(N'20:25:00' AS Time), CAST(N'2019-02-03' AS Date), CAST(N'10:23:00' AS Time), CAST(0 AS Decimal(18, 0)), 0, N'1    ', N'1    ', N'02     ', N'001', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ESCALE] ([NumEsc], [DatArr], [HeureArr], [DatDep], [HeureDep], [QteFre], [ConEsc], [CTyCar], [CodAge], [NumLlo], [CodPavProv], [CodPorProv], [CodPavDest], [CodPorDest], [NumPilEntree], [NumPilSortie]) VALUES (8, CAST(N'2018-12-14' AS Date), CAST(N'16:33:00' AS Time), CAST(N'2019-05-04' AS Date), CAST(N'16:00:00' AS Time), CAST(10 AS Decimal(18, 0)), 1, N'2    ', N'3    ', N'02     ', N'001', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ESCALE] ([NumEsc], [DatArr], [HeureArr], [DatDep], [HeureDep], [QteFre], [ConEsc], [CTyCar], [CodAge], [NumLlo], [CodPavProv], [CodPorProv], [CodPavDest], [CodPorDest], [NumPilEntree], [NumPilSortie]) VALUES (13, CAST(N'2019-05-04' AS Date), CAST(N'14:33:00' AS Time), CAST(N'2019-05-04' AS Date), CAST(N'17:00:00' AS Time), NULL, NULL, NULL, NULL, N'01     ', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ESCALE] ([NumEsc], [DatArr], [HeureArr], [DatDep], [HeureDep], [QteFre], [ConEsc], [CTyCar], [CodAge], [NumLlo], [CodPavProv], [CodPorProv], [CodPavDest], [CodPorDest], [NumPilEntree], [NumPilSortie]) VALUES (19, CAST(N'2018-06-05' AS Date), CAST(N'14:00:00' AS Time), CAST(N'2019-05-04' AS Date), CAST(N'12:00:00' AS Time), NULL, NULL, NULL, NULL, N'04     ', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ESCALE] ([NumEsc], [DatArr], [HeureArr], [DatDep], [HeureDep], [QteFre], [ConEsc], [CTyCar], [CodAge], [NumLlo], [CodPavProv], [CodPorProv], [CodPavDest], [CodPorDest], [NumPilEntree], [NumPilSortie]) VALUES (20, CAST(N'2018-01-01' AS Date), CAST(N'12:00:00' AS Time), CAST(N'2019-12-12' AS Date), CAST(N'12:00:00' AS Time), NULL, NULL, NULL, NULL, N'04     ', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ESCALE] ([NumEsc], [DatArr], [HeureArr], [DatDep], [HeureDep], [QteFre], [ConEsc], [CTyCar], [CodAge], [NumLlo], [CodPavProv], [CodPorProv], [CodPavDest], [CodPorDest], [NumPilEntree], [NumPilSortie]) VALUES (23, CAST(N'0001-01-01' AS Date), CAST(N'00:00:00' AS Time), CAST(N'0001-01-01' AS Date), CAST(N'00:00:00' AS Time), CAST(0 AS Decimal(18, 0)), 0, N'2    ', N'3    ', N'04     ', N'9  ', N'27', N'005', N'15', NULL, NULL)
INSERT [dbo].[ESCALE] ([NumEsc], [DatArr], [HeureArr], [DatDep], [HeureDep], [QteFre], [ConEsc], [CTyCar], [CodAge], [NumLlo], [CodPavProv], [CodPorProv], [CodPavDest], [CodPorDest], [NumPilEntree], [NumPilSortie]) VALUES (28, CAST(N'2000-01-01' AS Date), CAST(N'01:00:00' AS Time), CAST(N'2011-02-06' AS Date), CAST(N'06:00:00' AS Time), NULL, NULL, NULL, NULL, N'04     ', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ESCALE] ([NumEsc], [DatArr], [HeureArr], [DatDep], [HeureDep], [QteFre], [ConEsc], [CTyCar], [CodAge], [NumLlo], [CodPavProv], [CodPorProv], [CodPavDest], [CodPorDest], [NumPilEntree], [NumPilSortie]) VALUES (29, CAST(N'2002-02-02' AS Date), CAST(N'02:00:00' AS Time), CAST(N'2003-03-04' AS Date), CAST(N'05:04:06' AS Time), NULL, NULL, NULL, NULL, N'25     ', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ESCALE] ([NumEsc], [DatArr], [HeureArr], [DatDep], [HeureDep], [QteFre], [ConEsc], [CTyCar], [CodAge], [NumLlo], [CodPavProv], [CodPorProv], [CodPavDest], [CodPorDest], [NumPilEntree], [NumPilSortie]) VALUES (30, CAST(N'2018-12-14' AS Date), CAST(N'00:00:00' AS Time), CAST(N'2018-12-28' AS Date), CAST(N'00:00:00' AS Time), CAST(0 AS Decimal(18, 0)), 0, N'1111 ', N'3    ', N'04     ', N'9  ', N'27', N'005', N'15', NULL, NULL)
INSERT [dbo].[ESCALE] ([NumEsc], [DatArr], [HeureArr], [DatDep], [HeureDep], [QteFre], [ConEsc], [CTyCar], [CodAge], [NumLlo], [CodPavProv], [CodPorProv], [CodPavDest], [CodPorDest], [NumPilEntree], [NumPilSortie]) VALUES (33, CAST(N'2018-12-28' AS Date), CAST(N'12:12:00' AS Time), CAST(N'2019-01-27' AS Date), CAST(N'12:12:00' AS Time), CAST(123 AS Decimal(18, 0)), 1, N'2    ', N'3    ', N'01     ', N'005', N'15', N'002', N'3 ', N'2    ', N'4    ')
SET IDENTITY_INSERT [dbo].[ESCALE] OFF
INSERT [dbo].[GERER] ([NumArm], [CodAge]) VALUES (1, N'1    ')
INSERT [dbo].[GERER] ([NumArm], [CodAge]) VALUES (2, N'1    ')
INSERT [dbo].[GERER] ([NumArm], [CodAge]) VALUES (2, N'4    ')
INSERT [dbo].[GERER] ([NumArm], [CodAge]) VALUES (3, N'3    ')
INSERT [dbo].[GERER] ([NumArm], [CodAge]) VALUES (4, N'5    ')
INSERT [dbo].[GERER] ([NumArm], [CodAge]) VALUES (4, N'6    ')
INSERT [dbo].[NAVIRE] ([NumLlo], [NomNav], [AnnCon], [DatDre], [LarNav], [LongNav], [TirEau], [ProNav], [CapNav], [NumArm], [CTyNav], [CodPav], [CodPor], [NumCom]) VALUES (N'01     ', N'Violet                        ', 2001, CAST(N'2018-12-11' AS Date), CAST(9 AS Decimal(18, 0)), CAST(9 AS Decimal(18, 0)), CAST(9 AS Decimal(18, 0)), 0, 9, 3, N'5 ', N'010', N'14', 1)
INSERT [dbo].[NAVIRE] ([NumLlo], [NomNav], [AnnCon], [DatDre], [LarNav], [LongNav], [TirEau], [ProNav], [CapNav], [NumArm], [CTyNav], [CodPav], [CodPor], [NumCom]) VALUES (N'02     ', N'Titanic                       ', 2013, CAST(N'2017-08-15' AS Date), CAST(3 AS Decimal(18, 0)), CAST(15 AS Decimal(18, 0)), CAST(2 AS Decimal(18, 0)), 0, 2, 2, N'1 ', N'002', N'3 ', 3)
INSERT [dbo].[NAVIRE] ([NumLlo], [NomNav], [AnnCon], [DatDre], [LarNav], [LongNav], [TirEau], [ProNav], [CapNav], [NumArm], [CTyNav], [CodPav], [CodPor], [NumCom]) VALUES (N'03     ', N'Maestrolm                     ', 2015, CAST(N'2017-07-15' AS Date), CAST(5 AS Decimal(18, 0)), CAST(21 AS Decimal(18, 0)), CAST(2 AS Decimal(18, 0)), 0, 3, 1, N'1 ', N'002', N'3 ', 3)
INSERT [dbo].[NAVIRE] ([NumLlo], [NomNav], [AnnCon], [DatDre], [LarNav], [LongNav], [TirEau], [ProNav], [CapNav], [NumArm], [CTyNav], [CodPav], [CodPor], [NumCom]) VALUES (N'04     ', N'JeanMarc                      ', 2017, CAST(N'2017-01-01' AS Date), CAST(5 AS Decimal(18, 0)), CAST(16 AS Decimal(18, 0)), CAST(4 AS Decimal(18, 0)), 0, 4, 1, N'2 ', N'001', N'1 ', 1)
INSERT [dbo].[NAVIRE] ([NumLlo], [NomNav], [AnnCon], [DatDre], [LarNav], [LongNav], [TirEau], [ProNav], [CapNav], [NumArm], [CTyNav], [CodPav], [CodPor], [NumCom]) VALUES (N'15     ', N'Violet                        ', 2001, CAST(N'2018-12-11' AS Date), CAST(10 AS Decimal(18, 0)), CAST(9 AS Decimal(18, 0)), CAST(9 AS Decimal(18, 0)), 0, 9, 3, N'5 ', N'010', N'14', 1)
INSERT [dbo].[NAVIRE] ([NumLlo], [NomNav], [AnnCon], [DatDre], [LarNav], [LongNav], [TirEau], [ProNav], [CapNav], [NumArm], [CTyNav], [CodPav], [CodPor], [NumCom]) VALUES (N'16     ', N'Rouge                         ', 2001, CAST(N'2018-12-11' AS Date), CAST(9 AS Decimal(18, 0)), CAST(9 AS Decimal(18, 0)), CAST(9 AS Decimal(18, 0)), 0, 9, 3, N'5 ', N'010', N'14', 1)
INSERT [dbo].[NAVIRE] ([NumLlo], [NomNav], [AnnCon], [DatDre], [LarNav], [LongNav], [TirEau], [ProNav], [CapNav], [NumArm], [CTyNav], [CodPav], [CodPor], [NumCom]) VALUES (N'24     ', N'Violet                        ', 2001, CAST(N'2018-12-11' AS Date), CAST(9 AS Decimal(18, 0)), CAST(9 AS Decimal(18, 0)), CAST(9 AS Decimal(18, 0)), 0, 9, 3, N'5 ', N'010', N'14', 1)
INSERT [dbo].[PAVILLON] ([CodPav], [LibPav]) VALUES (N'001', N'France                        ')
INSERT [dbo].[PAVILLON] ([CodPav], [LibPav]) VALUES (N'002', N'Belgique                      ')
INSERT [dbo].[PAVILLON] ([CodPav], [LibPav]) VALUES (N'003', N'Pays-Bas                      ')
INSERT [dbo].[PAVILLON] ([CodPav], [LibPav]) VALUES (N'004', N'Espagne                       ')
INSERT [dbo].[PAVILLON] ([CodPav], [LibPav]) VALUES (N'005', N'Italie                        ')
INSERT [dbo].[PAVILLON] ([CodPav], [LibPav]) VALUES (N'006', N'Angleterre                    ')
INSERT [dbo].[PAVILLON] ([CodPav], [LibPav]) VALUES (N'007', N'Pays-de-Galle                 ')
INSERT [dbo].[PAVILLON] ([CodPav], [LibPav]) VALUES (N'008', N'Ecosse                        ')
INSERT [dbo].[PAVILLON] ([CodPav], [LibPav]) VALUES (N'009', N'Islande                       ')
INSERT [dbo].[PAVILLON] ([CodPav], [LibPav]) VALUES (N'010', N'Portugal                      ')
INSERT [dbo].[PAVILLON] ([CodPav], [LibPav]) VALUES (N'011', N'Grèce                         ')
INSERT [dbo].[PAVILLON] ([CodPav], [LibPav]) VALUES (N'012', N'Japon                         ')
INSERT [dbo].[PAVILLON] ([CodPav], [LibPav]) VALUES (N'013', N'Etats-Unis                    ')
INSERT [dbo].[PAVILLON] ([CodPav], [LibPav]) VALUES (N'014', N'Mexique                       ')
INSERT [dbo].[PAVILLON] ([CodPav], [LibPav]) VALUES (N'015', N'Brésil                        ')
INSERT [dbo].[PAVILLON] ([CodPav], [LibPav]) VALUES (N'016', N'Australie                     ')
INSERT [dbo].[PAVILLON] ([CodPav], [LibPav]) VALUES (N'11 ', N'barque                        ')
INSERT [dbo].[PAVILLON] ([CodPav], [LibPav]) VALUES (N'13 ', N'barque                        ')
INSERT [dbo].[PAVILLON] ([CodPav], [LibPav]) VALUES (N'7  ', N'Barque                        ')
INSERT [dbo].[PAVILLON] ([CodPav], [LibPav]) VALUES (N'8  ', N'Barque                        ')
INSERT [dbo].[PAVILLON] ([CodPav], [LibPav]) VALUES (N'9  ', N'yaunprobleme                  ')
INSERT [dbo].[PAVILLON] ([CodPav], [LibPav]) VALUES (N'99 ', N'xwcxwcxwcw                    ')
INSERT [dbo].[PILOTE] ([NumPil], [NomPil], [TelPil], [MelPil], [PrenPil], [CodPav], [NumEsc]) VALUES (N'1    ', N'Loeb                               ', N'0645789632', N'seb.loeb@gmail.com                 ', N'Sebastien                          ', N'001', NULL)
INSERT [dbo].[PILOTE] ([NumPil], [NomPil], [TelPil], [MelPil], [PrenPil], [CodPav], [NumEsc]) VALUES (N'2    ', N'Hamilton                           ', N'0612457852', N'lewis.hamilton@gmail.com           ', N'Lewis                              ', N'001', NULL)
INSERT [dbo].[PILOTE] ([NumPil], [NomPil], [TelPil], [MelPil], [PrenPil], [CodPav], [NumEsc]) VALUES (N'3    ', N'Ferrari                            ', N'063874912 ', N'laurence.ferrari@gmail.com         ', N'Laurence                           ', N'002', NULL)
INSERT [dbo].[PILOTE] ([NumPil], [NomPil], [TelPil], [MelPil], [PrenPil], [CodPav], [NumEsc]) VALUES (N'4    ', N'Pitt                               ', N'0614782364', N'brad.pitt@gmail.com                ', N'Brad                               ', N'002', NULL)
INSERT [dbo].[PILOTE] ([NumPil], [NomPil], [TelPil], [MelPil], [PrenPil], [CodPav], [NumEsc]) VALUES (N'5    ', N'Mansoif                            ', N'0625874136', N'gerard.mansoif@gmail.com           ', N'Gerard                             ', N'001', NULL)
INSERT [dbo].[PORT] ([CodPav], [CodPor], [NomPor]) VALUES (N'001', N'1 ', N'Cherbourg                     ')
INSERT [dbo].[PORT] ([CodPav], [CodPor], [NomPor]) VALUES (N'010', N'14', N'Test                          ')
INSERT [dbo].[PORT] ([CodPav], [CodPor], [NomPor]) VALUES (N'005', N'15', N'Port de KEKE                  ')
INSERT [dbo].[PORT] ([CodPav], [CodPor], [NomPor]) VALUES (N'001', N'2 ', N'Umtiti                        ')
INSERT [dbo].[PORT] ([CodPav], [CodPor], [NomPor]) VALUES (N'9  ', N'27', N'AllezLesBleus                 ')
INSERT [dbo].[PORT] ([CodPav], [CodPor], [NomPor]) VALUES (N'002', N'3 ', N'Noufnouf12                    ')
INSERT [dbo].[PORT] ([CodPav], [CodPor], [NomPor]) VALUES (N'001', N'4 ', N'Iniesta                       ')
INSERT [dbo].[PORT] ([CodPav], [CodPor], [NomPor]) VALUES (N'002', N'5 ', N'Attila                        ')
INSERT [dbo].[PORT] ([CodPav], [CodPor], [NomPor]) VALUES (N'002', N'6 ', N'CesarLeRoi                    ')
INSERT [dbo].[TYPE-CARGAISON] ([CTyCar], [LibCar], [DanCar], [CTyNav]) VALUES (N'1    ', N'Blé       ', 0, NULL)
INSERT [dbo].[TYPE-CARGAISON] ([CTyCar], [LibCar], [DanCar], [CTyNav]) VALUES (N'11   ', N'popo      ', 0, NULL)
INSERT [dbo].[TYPE-CARGAISON] ([CTyCar], [LibCar], [DanCar], [CTyNav]) VALUES (N'1111 ', N'lou       ', 1, NULL)
INSERT [dbo].[TYPE-CARGAISON] ([CTyCar], [LibCar], [DanCar], [CTyNav]) VALUES (N'1141 ', N'jjjjjj    ', 0, NULL)
INSERT [dbo].[TYPE-CARGAISON] ([CTyCar], [LibCar], [DanCar], [CTyNav]) VALUES (N'15   ', N'kiio      ', 0, NULL)
INSERT [dbo].[TYPE-CARGAISON] ([CTyCar], [LibCar], [DanCar], [CTyNav]) VALUES (N'2    ', N'Poison    ', 1, NULL)
INSERT [dbo].[TYPE-CARGAISON] ([CTyCar], [LibCar], [DanCar], [CTyNav]) VALUES (N'22   ', N'gfggf     ', 0, NULL)
INSERT [dbo].[TYPE-CARGAISON] ([CTyCar], [LibCar], [DanCar], [CTyNav]) VALUES (N'2222 ', N'ouloulou  ', 1, NULL)
INSERT [dbo].[TYPE-CARGAISON] ([CTyCar], [LibCar], [DanCar], [CTyNav]) VALUES (N'3    ', N'Pétrole   ', 1, NULL)
INSERT [dbo].[TYPE-CARGAISON] ([CTyCar], [LibCar], [DanCar], [CTyNav]) VALUES (N'333  ', N'hlkl      ', 0, NULL)
INSERT [dbo].[TYPE-CARGAISON] ([CTyCar], [LibCar], [DanCar], [CTyNav]) VALUES (N'4    ', N'Riz       ', 0, NULL)
INSERT [dbo].[TYPE-CARGAISON] ([CTyCar], [LibCar], [DanCar], [CTyNav]) VALUES (N'454  ', N'Keke      ', 1, NULL)
INSERT [dbo].[TYPE-CARGAISON] ([CTyCar], [LibCar], [DanCar], [CTyNav]) VALUES (N'482  ', N'TEST482   ', 1, NULL)
INSERT [dbo].[TYPE-CARGAISON] ([CTyCar], [LibCar], [DanCar], [CTyNav]) VALUES (N'483  ', N'test483   ', 0, NULL)
INSERT [dbo].[TYPE-CARGAISON] ([CTyCar], [LibCar], [DanCar], [CTyNav]) VALUES (N'5    ', N'vhhhj     ', 0, NULL)
INSERT [dbo].[TYPE-CARGAISON] ([CTyCar], [LibCar], [DanCar], [CTyNav]) VALUES (N'52   ', N'oula      ', 0, NULL)
INSERT [dbo].[TYPE-CARGAISON] ([CTyCar], [LibCar], [DanCar], [CTyNav]) VALUES (N'58   ', N'tyt       ', 0, NULL)
INSERT [dbo].[TYPE-CARGAISON] ([CTyCar], [LibCar], [DanCar], [CTyNav]) VALUES (N'8    ', N'ffddfdfd  ', 0, NULL)
INSERT [dbo].[TYPE-NAVIRE] ([CTyNav], [LibTyp]) VALUES (N'1 ', N'Cargot                        ')
INSERT [dbo].[TYPE-NAVIRE] ([CTyNav], [LibTyp]) VALUES (N'11', N'trimaran                      ')
INSERT [dbo].[TYPE-NAVIRE] ([CTyNav], [LibTyp]) VALUES (N'15', N'hsfu                          ')
INSERT [dbo].[TYPE-NAVIRE] ([CTyNav], [LibTyp]) VALUES (N'18', N'qdqqd                         ')
INSERT [dbo].[TYPE-NAVIRE] ([CTyNav], [LibTyp]) VALUES (N'19', N'zqdqd                         ')
INSERT [dbo].[TYPE-NAVIRE] ([CTyNav], [LibTyp]) VALUES (N'2 ', N'Yacht                         ')
INSERT [dbo].[TYPE-NAVIRE] ([CTyNav], [LibTyp]) VALUES (N'3 ', N'Porte-Avion                   ')
INSERT [dbo].[TYPE-NAVIRE] ([CTyNav], [LibTyp]) VALUES (N'4 ', N'Pétrolier                     ')
INSERT [dbo].[TYPE-NAVIRE] ([CTyNav], [LibTyp]) VALUES (N'5 ', N'Gazier                        ')
INSERT [dbo].[TYPE-NAVIRE] ([CTyNav], [LibTyp]) VALUES (N'6 ', N'Roulier                       ')
INSERT [dbo].[TYPE-NAVIRE] ([CTyNav], [LibTyp]) VALUES (N'7 ', N'kayak                         ')
INSERT [dbo].[TYPE-NAVIRE] ([CTyNav], [LibTyp]) VALUES (N'8 ', N'canoe                         ')
INSERT [dbo].[TYPE-NAVIRE] ([CTyNav], [LibTyp]) VALUES (N'9 ', N'Bulle                         ')
ALTER TABLE [dbo].[ARMATEUR]  WITH CHECK ADD  CONSTRAINT [FK_ARMATEUR_PAVILLON] FOREIGN KEY([CodPav])
REFERENCES [dbo].[PAVILLON] ([CodPav])
GO
ALTER TABLE [dbo].[ARMATEUR] CHECK CONSTRAINT [FK_ARMATEUR_PAVILLON]
GO
ALTER TABLE [dbo].[COMMANDER]  WITH CHECK ADD  CONSTRAINT [FK__COMMANDER__DateD__65370702] FOREIGN KEY([DateDebutComm])
REFERENCES [dbo].[DATE-DEBUT-COMM] ([DateDebutComm])
GO
ALTER TABLE [dbo].[COMMANDER] CHECK CONSTRAINT [FK__COMMANDER__DateD__65370702]
GO
ALTER TABLE [dbo].[COMMANDER]  WITH CHECK ADD  CONSTRAINT [FK__COMMANDER__NumCo__6442E2C9] FOREIGN KEY([NumCom])
REFERENCES [dbo].[COMMANDANT] ([NumCom])
GO
ALTER TABLE [dbo].[COMMANDER] CHECK CONSTRAINT [FK__COMMANDER__NumCo__6442E2C9]
GO
ALTER TABLE [dbo].[COMMANDER]  WITH CHECK ADD  CONSTRAINT [FK__COMMANDER__NumLl__662B2B3B] FOREIGN KEY([NumLlo])
REFERENCES [dbo].[NAVIRE] ([NumLlo])
GO
ALTER TABLE [dbo].[COMMANDER] CHECK CONSTRAINT [FK__COMMANDER__NumLl__662B2B3B]
GO
ALTER TABLE [dbo].[ESCALE]  WITH CHECK ADD  CONSTRAINT [FK_ESCALE_AGENT] FOREIGN KEY([CodAge])
REFERENCES [dbo].[AGENT] ([CodAge])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[ESCALE] CHECK CONSTRAINT [FK_ESCALE_AGENT]
GO
ALTER TABLE [dbo].[ESCALE]  WITH NOCHECK ADD  CONSTRAINT [FK_ESCALE_NAVIRE] FOREIGN KEY([NumLlo])
REFERENCES [dbo].[NAVIRE] ([NumLlo])
GO
ALTER TABLE [dbo].[ESCALE] NOCHECK CONSTRAINT [FK_ESCALE_NAVIRE]
GO
ALTER TABLE [dbo].[ESCALE]  WITH CHECK ADD  CONSTRAINT [FK_ESCALE_PILOTE] FOREIGN KEY([NumPilEntree])
REFERENCES [dbo].[PILOTE] ([NumPil])
GO
ALTER TABLE [dbo].[ESCALE] CHECK CONSTRAINT [FK_ESCALE_PILOTE]
GO
ALTER TABLE [dbo].[ESCALE]  WITH CHECK ADD  CONSTRAINT [FK_ESCALE_PILOTE1] FOREIGN KEY([NumPilSortie])
REFERENCES [dbo].[PILOTE] ([NumPil])
GO
ALTER TABLE [dbo].[ESCALE] CHECK CONSTRAINT [FK_ESCALE_PILOTE1]
GO
ALTER TABLE [dbo].[ESCALE]  WITH CHECK ADD  CONSTRAINT [FK_ESCALE_PORT] FOREIGN KEY([CodPorProv], [CodPavProv])
REFERENCES [dbo].[PORT] ([CodPor], [CodPav])
GO
ALTER TABLE [dbo].[ESCALE] CHECK CONSTRAINT [FK_ESCALE_PORT]
GO
ALTER TABLE [dbo].[ESCALE]  WITH CHECK ADD  CONSTRAINT [FK_ESCALE_PORT1] FOREIGN KEY([CodPorDest], [CodPavDest])
REFERENCES [dbo].[PORT] ([CodPor], [CodPav])
GO
ALTER TABLE [dbo].[ESCALE] CHECK CONSTRAINT [FK_ESCALE_PORT1]
GO
ALTER TABLE [dbo].[ESCALE]  WITH CHECK ADD  CONSTRAINT [FK_ESCALE_TYPE-CARGAISON] FOREIGN KEY([CTyCar])
REFERENCES [dbo].[TYPE-CARGAISON] ([CTyCar])
GO
ALTER TABLE [dbo].[ESCALE] CHECK CONSTRAINT [FK_ESCALE_TYPE-CARGAISON]
GO
ALTER TABLE [dbo].[GERER]  WITH CHECK ADD  CONSTRAINT [FK_GERER_AGENT] FOREIGN KEY([CodAge])
REFERENCES [dbo].[AGENT] ([CodAge])
GO
ALTER TABLE [dbo].[GERER] CHECK CONSTRAINT [FK_GERER_AGENT]
GO
ALTER TABLE [dbo].[GERER]  WITH CHECK ADD  CONSTRAINT [FK_GERER_ARMATEUR] FOREIGN KEY([NumArm])
REFERENCES [dbo].[ARMATEUR] ([NumArm])
GO
ALTER TABLE [dbo].[GERER] CHECK CONSTRAINT [FK_GERER_ARMATEUR]
GO
ALTER TABLE [dbo].[NAVIRE]  WITH NOCHECK ADD  CONSTRAINT [FK_NAVIRE_ARMATEUR] FOREIGN KEY([NumArm])
REFERENCES [dbo].[ARMATEUR] ([NumArm])
GO
ALTER TABLE [dbo].[NAVIRE] CHECK CONSTRAINT [FK_NAVIRE_ARMATEUR]
GO
ALTER TABLE [dbo].[NAVIRE]  WITH CHECK ADD  CONSTRAINT [FK_NAVIRE_COMMANDANT] FOREIGN KEY([NumCom])
REFERENCES [dbo].[COMMANDANT] ([NumCom])
GO
ALTER TABLE [dbo].[NAVIRE] CHECK CONSTRAINT [FK_NAVIRE_COMMANDANT]
GO
ALTER TABLE [dbo].[NAVIRE]  WITH NOCHECK ADD  CONSTRAINT [FK_NAVIRE_PORT] FOREIGN KEY([CodPor], [CodPav])
REFERENCES [dbo].[PORT] ([CodPor], [CodPav])
GO
ALTER TABLE [dbo].[NAVIRE] CHECK CONSTRAINT [FK_NAVIRE_PORT]
GO
ALTER TABLE [dbo].[NAVIRE]  WITH NOCHECK ADD  CONSTRAINT [FK_NAVIRE_TYPE-NAVIRE] FOREIGN KEY([CTyNav])
REFERENCES [dbo].[TYPE-NAVIRE] ([CTyNav])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[NAVIRE] CHECK CONSTRAINT [FK_NAVIRE_TYPE-NAVIRE]
GO
ALTER TABLE [dbo].[PORT]  WITH CHECK ADD  CONSTRAINT [FK_PORT_PAVILLON] FOREIGN KEY([CodPav])
REFERENCES [dbo].[PAVILLON] ([CodPav])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PORT] CHECK CONSTRAINT [FK_PORT_PAVILLON]
GO
ALTER TABLE [dbo].[TYPE-CARGAISON]  WITH CHECK ADD  CONSTRAINT [FK_TYPE-CARGAISON_TYPE-NAVIRE] FOREIGN KEY([CTyNav])
REFERENCES [dbo].[TYPE-NAVIRE] ([CTyNav])
GO
ALTER TABLE [dbo].[TYPE-CARGAISON] CHECK CONSTRAINT [FK_TYPE-CARGAISON_TYPE-NAVIRE]
GO
/****** Object:  StoredProcedure [PRINCE\kguillermin].[NombreArmateurParPavillon]    Script Date: 05/04/2019 17:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [PRINCE\kguillermin].[NombreArmateurParPavillon]( @LibellePav as nchar(30))
as 
declare @nbArmateur as int
Select @nbArmateur = count(*)
From PAVILLON, ARMATEUR
where PAVILLON.CodPav = ARMATEUR.CodPav AND PAVILLON.LibPav = @LibellePav

return @nbArmateur
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ESCALE"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 247
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "NAVIRE"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 268
               Right = 247
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "TYPE-NAVIRE"
            Begin Extent = 
               Top = 270
               Left = 38
               Bottom = 366
               Right = 247
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'NaviresDansPort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'NaviresDansPort'
GO
USE [master]
GO
ALTER DATABASE [GEscale] SET  READ_WRITE 
GO
