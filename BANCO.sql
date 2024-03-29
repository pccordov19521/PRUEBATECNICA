USE [BANCO]
GO
USE [BANCO]
GO
/****** Object:  Sequence [dbo].[Secuencia]    Script Date: 28/1/2024 15:53:25 ******/
IF NOT EXISTS (SELECT * FROM sys.sequences WHERE name = N'Secuencia' AND schema_id = SCHEMA_ID(N'dbo'))
BEGIN
CREATE SEQUENCE [dbo].[Secuencia] 
 AS [bigint]
 START WITH 1
 INCREMENT BY 1
 MINVALUE -9223372036854775808
 MAXVALUE 9223372036854775807
 CACHE 
END
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 28/1/2024 15:53:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cliente]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Cliente](
	[clienteid] [int] IDENTITY(1,1) NOT NULL,
	[contrasenia] [nvarchar](max) NOT NULL,
	[estado] [bit] NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[genero] [nvarchar](max) NULL,
	[edad] [int] NOT NULL,
	[identificacion] [nvarchar](max) NOT NULL,
	[direccion] [nvarchar](max) NULL,
	[telefono] [nvarchar](max) NULL,
	[personaid] [int] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[clienteid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Cuenta]    Script Date: 28/1/2024 15:53:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cuenta]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Cuenta](
	[cuentaid] [int] IDENTITY(1,1) NOT NULL,
	[numerocuenta] [nvarchar](max) NOT NULL,
	[tipocuenta] [nvarchar](max) NOT NULL,
	[saldoinicial] [decimal](18, 2) NOT NULL,
	[estado] [bit] NOT NULL,
	[clienteid] [int] NOT NULL,
	[saldofinal] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Cuenta] PRIMARY KEY CLUSTERED 
(
	[cuentaid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Movimientos]    Script Date: 28/1/2024 15:53:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Movimientos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Movimientos](
	[movimientosid] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime2](7) NOT NULL,
	[tipomovimiento] [nvarchar](max) NOT NULL,
	[valor] [decimal](18, 2) NOT NULL,
	[saldo] [decimal](18, 2) NOT NULL,
	[cuentaid] [int] NOT NULL,
 CONSTRAINT [PK_Movimientos] PRIMARY KEY CLUSTERED 
(
	[movimientosid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Index [IX_Cuenta_clienteid]    Script Date: 28/1/2024 15:53:25 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Cuenta]') AND name = N'IX_Cuenta_clienteid')
CREATE NONCLUSTERED INDEX [IX_Cuenta_clienteid] ON [dbo].[Cuenta]
(
	[clienteid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Movimientos_cuentaid]    Script Date: 28/1/2024 15:53:25 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Movimientos]') AND name = N'IX_Movimientos_cuentaid')
CREATE NONCLUSTERED INDEX [IX_Movimientos_cuentaid] ON [dbo].[Movimientos]
(
	[cuentaid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Cliente__persona__29221CFB]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cliente] ADD  DEFAULT (NEXT VALUE FOR [Secuencia]) FOR [personaid]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cuenta_Cliente_clienteid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cuenta]'))
ALTER TABLE [dbo].[Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_Cliente_clienteid] FOREIGN KEY([clienteid])
REFERENCES [dbo].[Cliente] ([clienteid])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cuenta_Cliente_clienteid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cuenta]'))
ALTER TABLE [dbo].[Cuenta] CHECK CONSTRAINT [FK_Cuenta_Cliente_clienteid]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Movimientos_Cuenta_cuentaid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Movimientos]'))
ALTER TABLE [dbo].[Movimientos]  WITH CHECK ADD  CONSTRAINT [FK_Movimientos_Cuenta_cuentaid] FOREIGN KEY([cuentaid])
REFERENCES [dbo].[Cuenta] ([cuentaid])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Movimientos_Cuenta_cuentaid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Movimientos]'))
ALTER TABLE [dbo].[Movimientos] CHECK CONSTRAINT [FK_Movimientos_Cuenta_cuentaid]
GO
/****** Object:  StoredProcedure [dbo].[PRO_OBTENER_REPORTE_MOV]    Script Date: 28/1/2024 15:53:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PRO_OBTENER_REPORTE_MOV]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PRO_OBTENER_REPORTE_MOV] AS' 
END
GO
ALTER PROCEDURE [dbo].[PRO_OBTENER_REPORTE_MOV]
   @fechainicio DATE,
   @fechafin DATE
AS
BEGIN

   SELECT FECHA
          ,NOMBRE AS CLIENTE
		  ,NUMEROCUENTA AS NUMERODECUENTA
		  ,TIPOCUENTA AS TIPOCUENTA
		  ,SALDOINICIAL AS SALDOINICIAL
		  ,CU.ESTADO AS ESTADO
		  ,M.VALOR AS MOVIMIENTO
          ,M.SALDO AS SALDODISPONIBLE
   FROM CLIENTE C
   JOIN CUENTA CU ON C.clienteid=CU.clienteid
   JOIN MOVIMIENTOS M ON CU.cuentaid=M.cuentaid
   WHERE CAST(FECHA AS DATE) >= @fechainicio AND CAST(FECHA AS DATE) <= @fechafin
   ORDER BY M.FECHA 

END
GO
