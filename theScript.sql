USE [FPLUG]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[IdEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[DNI] [int] NOT NULL,
	[Puesto] [int] NOT NULL,
	[Salario] [float] NOT NULL,
	[Baja] [bit] NOT NULL,
	[FechaIngreso] [date] NOT NULL,
	[FechaEgreso] [date] NULL,
	[Antiguedad] [int] NOT NULL,
	[Lenguaje_Programacion] [varchar](50) NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[IdEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado_Sucursal]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado_Sucursal](
	[NumSucursal] [int] NOT NULL,
	[NumEmpleado] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Localidades]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Localidades](
	[IdLocalidad] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Localidades] PRIMARY KEY CLUSTERED 
(
	[IdLocalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Puesto]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Puesto](
	[IdPuesto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Puesto] PRIMARY KEY CLUSTERED 
(
	[IdPuesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sucursales]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sucursales](
	[IdSucursal] [int] IDENTITY(1,1) NOT NULL,
	[Localidad] [int] NOT NULL,
	[NombreSuc] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Sucursales] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Empleado] ADD  CONSTRAINT [DF_Empleado_Baja]  DEFAULT ((0)) FOR [Baja]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_Empleado_Puesto] FOREIGN KEY([Puesto])
REFERENCES [dbo].[Puesto] ([IdPuesto])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_Empleado_Puesto]
GO
ALTER TABLE [dbo].[Empleado_Sucursal]  WITH CHECK ADD  CONSTRAINT [FK_Empleado_Sucursal_Empleado1] FOREIGN KEY([NumEmpleado])
REFERENCES [dbo].[Empleado] ([IdEmpleado])
GO
ALTER TABLE [dbo].[Empleado_Sucursal] CHECK CONSTRAINT [FK_Empleado_Sucursal_Empleado1]
GO
ALTER TABLE [dbo].[Empleado_Sucursal]  WITH CHECK ADD  CONSTRAINT [FK_Empleado_Sucursal_Sucursales1] FOREIGN KEY([NumSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO
ALTER TABLE [dbo].[Empleado_Sucursal] CHECK CONSTRAINT [FK_Empleado_Sucursal_Sucursales1]
GO
ALTER TABLE [dbo].[Sucursales]  WITH CHECK ADD  CONSTRAINT [FK_Sucursales_Localidades] FOREIGN KEY([Localidad])
REFERENCES [dbo].[Localidades] ([IdLocalidad])
GO
ALTER TABLE [dbo].[Sucursales] CHECK CONSTRAINT [FK_Sucursales_Localidades]
GO
/****** Object:  StoredProcedure [dbo].[S_Empleado_BajaLogica]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_Empleado_BajaLogica]
	-- Add the parameters for the stored procedure here
	@FechaE date,
	@Cod int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Empleado SET Baja=1, FechaEgreso = @FechaE where IdEmpleado= @Cod
END
GO
/****** Object:  StoredProcedure [dbo].[S_Empleado_GuardarEnSucursal]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_Empleado_GuardarEnSucursal]
	-- Add the parameters for the stored procedure here
	@CodEmpl int,
	@CodSuc int
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into Empleado_Sucursal(NumEmpleado,NumSucursal) values (@CodEmpl,@CodSuc)
END
GO
/****** Object:  StoredProcedure [dbo].[S_Empleado_Listar]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[S_Empleado_Listar] 
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT IdEmpleado, Nombre, Apellido, DNI, Puesto, Salario, Baja, FechaIngreso, FechaEgreso, Antiguedad, Lenguaje_Programacion
	from Empleado
END
GO
/****** Object:  StoredProcedure [dbo].[S_EmpleadoIT_Crear]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_EmpleadoIT_Crear]
	-- Add the parameters for the stored procedure here
	@Nom varchar(50),
	@Ape varchar(50),
	@Dni int,
	@Puesto int,
	@Salario float,
	@Baja bit,
	@FechaI date,
	@FechaE date,
	@Ant int,
	@LP varchar(50)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into Empleado(Nombre,Apellido,DNI,Puesto,Salario,Baja,FechaIngreso,Antiguedad,Lenguaje_Programacion,FechaEgreso) 
	values (@Nom,@Ape,@Dni,@Puesto,@Salario,@Baja,@FechaI,@Ant,@LP,@FechaE)
END
GO
/****** Object:  StoredProcedure [dbo].[S_EmpleadoIT_CrearNOEgresado]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_EmpleadoIT_CrearNOEgresado]
	-- Add the parameters for the stored procedure here
	@Nom varchar(50),
	@Ape varchar(50),
	@Dni int,
	@Puesto int,
	@Salario float,
	@Baja bit,
	@FechaI date,
	@FechaE date,
	@Ant int,
	@LP varchar(50)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    -- Insert statements for procedure here
	Insert into Empleado(Nombre,Apellido,DNI,Puesto,Salario,Baja,FechaIngreso,Antiguedad,Lenguaje_Programacion) 
	values (@Nom,@Ape,@Dni,@Puesto,@Salario,@Baja,@FechaI,@Ant,@LP)
END
GO
/****** Object:  StoredProcedure [dbo].[S_EmpleadoIT_ListarTodo]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_EmpleadoIT_ListarTodo]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select IdEmpleado,Nombre,Apellido,DNI,Puesto,Salario,Baja,FechaIngreso,FechaEgreso,Antiguedad,Lenguaje_Programacion from Empleado
END
GO
/****** Object:  StoredProcedure [dbo].[S_EmpleadoIT_UpdateEgresado]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_EmpleadoIT_UpdateEgresado]
	-- Add the parameters for the stored procedure here
@Cod int,
@Nom varchar(50),
	@Ape varchar(50),
	@Dni int,
	@Puesto int,
	@Salario float,
	@Baja bit,
	@FechaI date,
	@FechaE date,
	@Ant int,
	@LP varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	 UPDATE Empleado SET Nombre=@Nom, Apellido = @Ape, DNI = @Dni, Puesto=@Puesto ,Salario=@Salario,FechaIngreso=@FechaI,
	FechaEgreso=@FechaE,Antiguedad=@Ant,Lenguaje_Programacion=@LP where IdEmpleado=@Cod
END
GO
/****** Object:  StoredProcedure [dbo].[S_EmpleadoIT_UpdateNOEgresado]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_EmpleadoIT_UpdateNOEgresado]
	-- Add the parameters for the stored procedure here
	@Cod int,
    @Nom varchar(50),
	@Ape varchar(50),
	@Dni int,
	@Puesto int,
	@Salario float,
	@Baja bit,
	@FechaI date,
	@Ant int,
	@LP varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
UPDATE Empleado SET Nombre=@Nom, Apellido = @Ape, DNI = @Dni, Puesto=@Puesto ,Salario=@Salario,FechaIngreso=@FechaI,
	Antiguedad=@Ant,Lenguaje_Programacion=@LP where IdEmpleado=@Cod
END
GO
/****** Object:  StoredProcedure [dbo].[S_EmpleadoMedico_Crear]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_EmpleadoMedico_Crear]
	-- Add the parameters for the stored procedure here
	@Nom varchar(50),
	@Ape varchar(50),
	@Dni int,
	@Puesto int,
	@Salario float,
	@Baja bit,
	@FechaI date,
	@FechaE date,
	@Ant int
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into Empleado(Nombre,Apellido,DNI,Puesto,Salario,Baja,FechaIngreso,Antiguedad,FechaEgreso) 
	values (@Nom,@Ape,@Dni,@Puesto,@Salario,@Baja,@FechaI,@Ant,@FechaE)
END
GO
/****** Object:  StoredProcedure [dbo].[S_EmpleadoMedico_CrearNOEgresado]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_EmpleadoMedico_CrearNOEgresado]
	-- Add the parameters for the stored procedure here
	@Nom varchar(50),
	@Ape varchar(50),
	@Dni int,
	@Puesto int,
	@Salario float,
	@Baja bit,
	@FechaI date,
	@Ant int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into Empleado(Nombre,Apellido,DNI,Puesto,Salario,Baja,FechaIngreso,Antiguedad) 
	values (@Nom,@Ape,@Dni,@Puesto,@Salario,@Baja,@FechaI,@Ant)
END
GO
/****** Object:  StoredProcedure [dbo].[S_EmpleadoMedico_UpdateEgresado]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_EmpleadoMedico_UpdateEgresado]
	-- Add the parameters for the stored procedure here
	@Cod int,
@Nom varchar(50),
	@Ape varchar(50),
	@Dni int,
	@Puesto int,
	@Salario float,
	@Baja bit,
	@FechaI date,
	@FechaE date,
	@Ant int
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Empleado SET Nombre=@Nom, Apellido = @Ape, DNI = @Dni, Puesto=@Puesto ,Salario=@Salario,FechaIngreso=@FechaI,
	FechaEgreso=@FechaE,Antiguedad=@Ant where IdEmpleado=@Cod
END
GO
/****** Object:  StoredProcedure [dbo].[S_EmpleadoMedico_UpdateNOEgresado]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_EmpleadoMedico_UpdateNOEgresado]
	-- Add the parameters for the stored procedure here
	@Cod int,
    @Nom varchar(50),
	@Ape varchar(50),
	@Dni int,
	@Puesto int,
	@Salario float,
	@Baja bit,
	@FechaI date,
	@Ant int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
UPDATE Empleado SET Nombre=@Nom, Apellido = @Ape, DNI = @Dni, Puesto=@Puesto ,Salario=@Salario,FechaIngreso=@FechaI,
	Antiguedad=@Ant where IdEmpleado=@Cod
END
GO
/****** Object:  StoredProcedure [dbo].[S_Localidad_Baja]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_Localidad_Baja]
	-- Add the parameters for the stored procedure here
	@Cod int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Localidades where IdLocalidad = @Cod
END
GO
/****** Object:  StoredProcedure [dbo].[S_Localidad_Crear]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_Localidad_Crear]
	-- Add the parameters for the stored procedure here
@Nom varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into Localidades(Nombre) VALUES(@Nom)
END
GO
/****** Object:  StoredProcedure [dbo].[S_Localidad_ListarTodo]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_Localidad_ListarTodo]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select IdLocalidad,Nombre From Localidades
END
GO
/****** Object:  StoredProcedure [dbo].[S_Localidad_SucAsociada]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_Localidad_SucAsociada]
	-- Add the parameters for the stored procedure here
	@Cod int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select count(Localidad) from Sucursales where Localidad = @Cod
END
GO
/****** Object:  StoredProcedure [dbo].[S_Localidad_Update]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_Localidad_Update] 
	-- Add the parameters for the stored procedure here
	@Nom varchar(50),
	@Cod int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Localidades SET Nombre = @Nom where IdLocalidad = @Cod
END
GO
/****** Object:  StoredProcedure [dbo].[S_Puesto_Crear]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_Puesto_Crear]
	-- Add the parameters for the stored procedure here
	@Nom varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into Puesto(Nombre) values(@Nom)
END
GO
/****** Object:  StoredProcedure [dbo].[S_Puesto_ListarTodo]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_Puesto_ListarTodo]
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT IdPuesto,Nombre FROM Puesto
END
GO
/****** Object:  StoredProcedure [dbo].[S_Puesto_Update]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_Puesto_Update]
	-- Add the parameters for the stored procedure here
	@Nom varchar(50),
	@Cod int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Puesto SET Nombre=@Nom where IdPuesto =@Cod
END
GO
/****** Object:  StoredProcedure [dbo].[S_Sucursal_Baja]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_Sucursal_Baja]
	-- Add the parameters for the stored procedure here
	@Cod int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
DELETE FROM Sucursales where IdSucursal = @Cod
END
GO
/****** Object:  StoredProcedure [dbo].[S_Sucursal_Crear]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_Sucursal_Crear]
	-- Add the parameters for the stored procedure here
	@Cod int,
	@Nom varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
Insert into Sucursales (NombreSuc,Localidad) values (@Nom,@Cod)

END
GO
/****** Object:  StoredProcedure [dbo].[S_Sucursal_Empleado]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_Sucursal_Empleado]
	-- Add the parameters for the stored procedure here
	@Cod int,
	@CodEmpleado int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
Insert into Empleado_Sucursal (NumSucursal,NumEmpleado) values (@Cod,@CodEmpleado)

END
GO
/****** Object:  StoredProcedure [dbo].[S_Sucursal_ListarTodo]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_Sucursal_ListarTodo]
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
Select Sucursales.IdSucursal, Sucursales.NombreSuc, Localidades.IdLocalidad,Localidades.Nombre 
from Sucursales,Localidades 
where Sucursales.Localidad = Localidades.IdLocalidad

END
GO
/****** Object:  StoredProcedure [dbo].[S_Sucursal_QuitarEmpleado]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_Sucursal_QuitarEmpleado]
	-- Add the parameters for the stored procedure here
	@Cod int,
	@CodEmpleado int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
Delete from Empleado_Sucursal where NumSucursal = @Cod  and NumEmpleado = @CodEmpleado

END
GO
/****** Object:  StoredProcedure [dbo].[S_Sucursal_Update]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_Sucursal_Update]
	-- Add the parameters for the stored procedure here
	@Cod int,
	@Nom varchar(50),
	@CodLoc int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
UPDATE Sucursales SET NombreSuc = @Nom, Localidad = @CodLoc where IdSucursal = @Cod

END
GO
/****** Object:  StoredProcedure [dbo].[S_Usuario_ExisteUsuario]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_Usuario_ExisteUsuario] 
	-- Add the parameters for the stored procedure here
	@Nom varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select count(Usuario) from Usuarios where Usuario = @Nom
END
GO
/****** Object:  StoredProcedure [dbo].[S_Usuario_Guardar]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_Usuario_Guardar] 
	-- Add the parameters for the stored procedure here
	@Nom varchar(50),
	@Pas varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into Usuarios(Usuario,Password) values (@Nom,@Pas)
END
GO
/****** Object:  StoredProcedure [dbo].[S_Usuario_ListarObjeto]    Script Date: 10/11/2021 11:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_Usuario_ListarObjeto]
	-- Add the parameters for the stored procedure here
	@Nom varchar(50),
	@Pas varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Usuario, Password FROM Usuarios WHERE  Usuario = @Nom AND Password =@Pas
END
GO
