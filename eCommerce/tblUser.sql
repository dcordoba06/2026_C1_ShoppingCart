/****** Object:  Table [dbo].[tblUser]    Script Date: 2/5/2026 9:31:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NULL,
	[Name] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[BirthDate] [datetime] NOT NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


