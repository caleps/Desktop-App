USE [glal]
GO
/****** Object:  Table [dbo].[corrector]    Script Date: 09/09/2018 01:30:31 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[corrector](
	[id_corrector] [int] NOT NULL,
	[name] [nvarchar](20) NOT NULL,
	[certificate] [nvarchar](50) NOT NULL,
	[address] [nvarchar](50) NOT NULL,
	[phone1] [nvarchar](20) NULL,
	[phone2] [nvarchar](20) NULL,
	[ratio] [float] NULL,
	[var] [int] NOT NULL,
 CONSTRAINT [PK_corrector] PRIMARY KEY CLUSTERED 
(
	[id_corrector] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[corrector_paper]    Script Date: 09/09/2018 01:30:31 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[corrector_paper](
	[id_corrector] [int] NOT NULL,
	[id_paper] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_corrector_paper] PRIMARY KEY CLUSTERED 
(
	[id_corrector] ASC,
	[id_paper] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[paper]    Script Date: 09/09/2018 01:30:31 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[paper](
	[id_paper] [nvarchar](20) NOT NULL,
	[exam_date] [date] NULL,
	[date_of_enterring] [date] NULL,
	[date_of_delivering] [date] NULL,
	[price_p] [float] NULL,
	[num_p] [float] NULL,
	[co_per] [float] NULL,
	[money] [float] NULL,
	[co_money] [float] NULL,
	[photo] [image] NULL,
	[path] [nvarchar](50) NULL,
	[groups] [nvarchar](50) NULL,
 CONSTRAINT [PK_paper] PRIMARY KEY CLUSTERED 
(
	[id_paper] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[teacher]    Script Date: 09/09/2018 01:30:31 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[teacher](
	[id_teacher] [int] NOT NULL,
	[name_teacher] [nvarchar](20) NOT NULL,
	[phone1] [nvarchar](15) NULL,
	[phone2] [nvarchar](15) NULL,
	[address] [nvarchar](50) NULL,
	[subject] [nvarchar](20) NULL,
	[preparatory] [nvarchar](20) NULL,
	[secondry] [nvarchar](20) NULL,
	[primare] [nvarchar](50) NULL,
 CONSTRAINT [PK_teacher] PRIMARY KEY CLUSTERED 
(
	[id_teacher] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[teacher_paper]    Script Date: 09/09/2018 01:30:31 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[teacher_paper](
	[id_paper] [nvarchar](20) NOT NULL,
	[id_teacher] [int] NOT NULL,
 CONSTRAINT [PK_teacher_paper] PRIMARY KEY CLUSTERED 
(
	[id_paper] ASC,
	[id_teacher] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[corrector_paper]  WITH CHECK ADD  CONSTRAINT [FK_corrector_paper_corrector] FOREIGN KEY([id_corrector])
REFERENCES [dbo].[corrector] ([id_corrector])
GO
ALTER TABLE [dbo].[corrector_paper] CHECK CONSTRAINT [FK_corrector_paper_corrector]
GO
ALTER TABLE [dbo].[corrector_paper]  WITH CHECK ADD  CONSTRAINT [FK_corrector_paper_paper] FOREIGN KEY([id_paper])
REFERENCES [dbo].[paper] ([id_paper])
GO
ALTER TABLE [dbo].[corrector_paper] CHECK CONSTRAINT [FK_corrector_paper_paper]
GO
ALTER TABLE [dbo].[teacher_paper]  WITH CHECK ADD  CONSTRAINT [FK_teacher_paper_paper] FOREIGN KEY([id_paper])
REFERENCES [dbo].[paper] ([id_paper])
GO
ALTER TABLE [dbo].[teacher_paper] CHECK CONSTRAINT [FK_teacher_paper_paper]
GO
ALTER TABLE [dbo].[teacher_paper]  WITH CHECK ADD  CONSTRAINT [FK_teacher_paper_teacher] FOREIGN KEY([id_teacher])
REFERENCES [dbo].[teacher] ([id_teacher])
GO
ALTER TABLE [dbo].[teacher_paper] CHECK CONSTRAINT [FK_teacher_paper_teacher]
GO
