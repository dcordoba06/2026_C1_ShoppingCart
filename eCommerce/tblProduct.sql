/****** Object:  Table [dbo].[tblProduct]    Script Date: 2/5/2026 9:25:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblProduct](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NULL,
	[Description] [nvarchar](250) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_tblProduct] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


