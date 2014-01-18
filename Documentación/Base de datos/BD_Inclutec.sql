USE [master]
GO
/****** Object:  Database [Inclutec_BD]    Script Date: 12/21/2013 17:09:46 ******/
CREATE DATABASE [Inclutec_BD]
GO

ALTER DATABASE [Inclutec_BD] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Inclutec_BD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Inclutec_BD] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Inclutec_BD] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Inclutec_BD] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Inclutec_BD] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Inclutec_BD] SET ARITHABORT OFF
GO
ALTER DATABASE [Inclutec_BD] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Inclutec_BD] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Inclutec_BD] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Inclutec_BD] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Inclutec_BD] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Inclutec_BD] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Inclutec_BD] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Inclutec_BD] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Inclutec_BD] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Inclutec_BD] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Inclutec_BD] SET  DISABLE_BROKER
GO
ALTER DATABASE [Inclutec_BD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Inclutec_BD] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Inclutec_BD] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Inclutec_BD] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Inclutec_BD] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Inclutec_BD] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Inclutec_BD] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Inclutec_BD] SET  READ_WRITE
GO
ALTER DATABASE [Inclutec_BD] SET RECOVERY FULL
GO
ALTER DATABASE [Inclutec_BD] SET  MULTI_USER
GO
ALTER DATABASE [Inclutec_BD] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Inclutec_BD] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'Inclutec_BD', N'ON'
GO
USE [Inclutec_BD]
GO
/****** Object:  Table [dbo].[SIFGrupo]    Script Date: 12/21/2013 17:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SIFGrupo](
	[id_Grupo] [int] IDENTITY(1,1) NOT NULL,
	[num_grupo] [int] NOT NULL,
	[num_cupos] [int] NOT NULL,
	[num_cupos_extra] [int] NOT NULL,
	[FK_Curso_idCurso] int NOT NULL,
	[FK_Profesor_idProfesor] [varchar](9) NOT NULL,
 CONSTRAINT [PK_Grupo] PRIMARY KEY CLUSTERED 
(
	[id_Grupo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SIFEstudiante]    Script Date: 12/21/2013 17:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIFEstudiante](
	[id_Carnet] [varchar](15) NOT NULL,
	[nom_nombre] [varchar](40) NOT NULL,
	[txt_apellido_1] [varchar](20) NOT NULL,
	[txt_apellido_2] [varchar](20) NULL,
	[num_telefono] [nchar](8) NOT NULL,
	[num_celular] [nchar](8) NOT NULL,
	[dir_email] [varchar](60) NOT NULL,
	[FK_PlanEstudios_idPlanEstudios] [int] NOT NULL,
 CONSTRAINT [PK_Estudiante] PRIMARY KEY CLUSTERED 
(
	[id_Carnet] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIFPeriodo]    Script Date: 12/21/2013 17:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIFPeriodo](
	[id_Periodo] [int] IDENTITY(1,1) NOT NULL,
	[fec_inicio] [datetime] NOT NULL,
	[fec_fin] [datetime] NOT NULL,
	[txt_estado] [varchar](10) NOT NULL,
	[txt_modalidad] [varchar](15) NOT NULL,
	[num_anno] [int] NOT NULL,
	[num_periodo] [int] NULL,
 CONSTRAINT [PK_Periodo] PRIMARY KEY CLUSTERED 
(
	[id_Periodo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIFSolicitud]    Script Date: 12/21/2013 17:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIFSolicitud](
	[id_Solicitud] [int] IDENTITY(1,1) NOT NULL,
	[txt_comentario] [varchar](350) NULL,
	[txt_curso] [varchar](50) NOT NULL,
	[txt_motivo] [varchar](50) NULL,
	[txt_estado] [varchar](10) NOT NULL,
	[fec_creacion] [datetime] NOT NULL,
	[grupo_aceptado] [int] NOT NULL,
	[FK_Estudiante_carnet] [varchar](15) NOT NULL,
	[FK_Periodo_idPeriodo] [int] NOT NULL,
 CONSTRAINT [PK_Solicitud] PRIMARY KEY CLUSTERED 
(
	[id_Solicitud] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIFGrupo_Por_Solicitud]    Script Date: 12/21/2013 17:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIFGrupo_Por_Solicitud](
	[id_Grupo_Por_Solicitud] [int] IDENTITY(1,1) NOT NULL,
	[num_prioridad] [int] NOT NULL,
	[FK_Grupo_idGrupo] [int] NOT NULL,
	[FK_Solicitud_idSolicitud] [int] NOT NULL,
 CONSTRAINT [PK_Grupo_Por_Solicitud] PRIMARY KEY CLUSTERED 
(
	[id_Grupo_Por_Solicitud] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SITExcepcion]    Script Date: 12/21/2013 17:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SITExcepcion](
	[id_Excepcion] [int] IDENTITY(1,1) NOT NULL,
	[FK_Estudiante_carnet] [varchar](15) NOT NULL,
	[FK_Curso_idCurso] [int] NOT NULL,
	[FK_Grupo_idGrupo] [int] NOT NULL,
	[FK_Periodo_idPeriodo] [int] NOT NULL,
 CONSTRAINT [PK_Excepcion] PRIMARY KEY CLUSTERED 
(
	[id_Excepcion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIFCurso]    Script Date: 12/21/2013 17:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIFCurso](
	[id_Curso] [int] IDENTITY(1,1) NOT NULL,
	[cod_Curso] [varchar](8) NOT NULL,
	[nom_Curso] [varchar](60) NOT NULL,
 CONSTRAINT [PK_Curso] PRIMARY KEY CLUSTERED 
(
	[id_Curso] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIFProfesor]    Script Date: 12/21/2013 17:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIFProfesor](
	[id_Profesor] [varchar](9) NOT NULL,
	[nom_profesor] [varchar](50) NOT NULL,
	[dir_correo] [varchar](40) NOT NULL,
 CONSTRAINT [PK_Profesor] PRIMARY KEY CLUSTERED 
(
	[id_Profesor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SITHorario]    Script Date: 12/21/2013 17:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SITHorario](
	[id_Horario] [int] NOT NULL,
	[txt_dia] [varchar](1) NOT NULL,
	[tim_hora_inicio] [time] NOT NULL,
	[tim_hora_fin] [time] NOT NULL,
	[FK_Grupo_idGrupo] [int] NOT NULL,
 CONSTRAINT [PK_Horario] PRIMARY KEY CLUSTERED 
(
	[id_Horario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIFPlanEstudios]    Script Date: 12/21/2013 17:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIFPlanEstudios](
	[id_PlanEstudios] [int] NOT NULL,
	[nom_carrera] [varchar](50) NOT NULL,
 CONSTRAINT [PK_PlanEstudios] PRIMARY KEY CLUSTERED 
(
	[id_PlanEstudios] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SITDatos_Estudiante]    Script Date: 12/21/2013 17:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SITDatos_Estudiante](
	[id_Datos_Estudiante] [int] IDENTITY(1,1) NOT NULL,
	[num_cursosfaltantes] [int] NOT NULL,
	[num_creditosactuales] [int] NOT NULL,
	[tim_horamatricula] [time] NOT NULL,
	[txt_diamatricula] [varchar](1) NOT NULL,
	[FK_Estudiante_idEstudiante] [varchar](15) NOT NULL,
 CONSTRAINT [PK_Datos_Estudiante] PRIMARY KEY CLUSTERED 
(
	[id_Datos_Estudiante] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIFRegla]    Script Date: 12/21/2013 17:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIFRegla](
	[id_Regla] [int] IDENTITY(1,1) NOT NULL,
	[txt_nombre] [varchar](25) NOT NULL,
	[txt_script] [varchar](500),
	[num_prioridad] [int] NOT NULL,
	[txt_estado] [varchar](15) NOT NULL
 CONSTRAINT [PK_Regla] PRIMARY KEY CLUSTERED 
(
	[id_Regla] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


/****** Object:  ForeignKey [FK_Grupo_Curso]    Script Date: 12/21/2013 17:09:46 ******/
ALTER TABLE [dbo].[SIFGrupo]  WITH CHECK ADD  CONSTRAINT [FK_Grupo_Curso] FOREIGN KEY([FK_Curso_idCurso])
REFERENCES [dbo].[SIFCurso] ([id_Curso])
GO
ALTER TABLE [dbo].[SIFGrupo] CHECK CONSTRAINT [FK_Grupo_Curso]
GO
/****** Object:  ForeignKey [FK_Grupo_Profesor]    Script Date: 12/21/2013 17:09:46 ******/
ALTER TABLE [dbo].[SIFGrupo]  WITH CHECK ADD  CONSTRAINT [FK_Grupo_Profesor] FOREIGN KEY([FK_Profesor_idProfesor])
REFERENCES [dbo].[SIFProfesor] ([id_Profesor])
GO
ALTER TABLE [dbo].[SIFGrupo] CHECK CONSTRAINT [FK_Grupo_Profesor]
GO

/****** Object:  ForeignKey [FK_Estudiante_PlanEstudio]    Script Date: 12/21/2013 17:09:46 ******/
ALTER TABLE [dbo].[SIFEstudiante]  WITH CHECK ADD  CONSTRAINT [FK_Estudiante_PlanEstudios] FOREIGN KEY([FK_PlanEstudios_idPlanEstudios])
REFERENCES [dbo].[SIFPlanEstudios] ([id_PlanEstudios])
GO
ALTER TABLE [dbo].[SIFEstudiante] CHECK CONSTRAINT [FK_Estudiante_PlanEstudios]
GO

/****** Object:  ForeignKey [FK_Solicitud_Estudiante]    Script Date: 12/21/2013 17:09:46 ******/
ALTER TABLE [dbo].[SIFSolicitud]  WITH CHECK ADD  CONSTRAINT [FK_Solicitud_Estudiante] FOREIGN KEY([FK_Estudiante_carnet])
REFERENCES [dbo].[SIFEstudiante] ([id_Carnet])
GO
ALTER TABLE [dbo].[SIFSolicitud] CHECK CONSTRAINT [FK_Solicitud_Estudiante]
GO
/****** Object:  ForeignKey [FK_Solicitud_Periodo]    Script Date: 12/21/2013 17:09:46 ******/
ALTER TABLE [dbo].[SIFSolicitud]  WITH CHECK ADD  CONSTRAINT [FK_Solicitud_Periodo] FOREIGN KEY([FK_Periodo_idPeriodo])
REFERENCES [dbo].[SIFPeriodo] ([id_Periodo])
GO
ALTER TABLE [dbo].[SIFSolicitud] CHECK CONSTRAINT [FK_Solicitud_Periodo]
GO

/****** Object:  ForeignKey [FK_Grupo_Por_Solicitud_Grupo]    Script Date: 12/21/2013 17:09:46 ******/
ALTER TABLE [dbo].[SIFGrupo_Por_Solicitud]  WITH CHECK ADD  CONSTRAINT [FK_Grupo_Por_Solicitud_Grupo] FOREIGN KEY([FK_Grupo_idGrupo])
REFERENCES [dbo].[SIFGrupo] ([id_Grupo])
GO
ALTER TABLE [dbo].[SIFGrupo_Por_Solicitud] CHECK CONSTRAINT [FK_Grupo_Por_Solicitud_Grupo]
GO
/****** Object:  ForeignKey [FK_Grupo_Por_Solicitud_Solicitud]    Script Date: 12/21/2013 17:09:46 ******/
ALTER TABLE [dbo].[SIFGrupo_Por_Solicitud]  WITH CHECK ADD  CONSTRAINT [FK_Grupo_Por_Solicitud_Solicitud] FOREIGN KEY([FK_Solicitud_idSolicitud])
REFERENCES [dbo].[SIFSolicitud] ([id_Solicitud])
GO
ALTER TABLE [dbo].[SIFGrupo_Por_Solicitud] CHECK CONSTRAINT [FK_Grupo_Por_Solicitud_Solicitud]
GO

/****** Object:  ForeignKey [FK_Excepcion_Estudiante]    Script Date: 12/21/2013 17:09:46 ******/
ALTER TABLE [dbo].[SITExcepcion]  WITH CHECK ADD  CONSTRAINT [FK_Excepcion_Estudiante] FOREIGN KEY([FK_Estudiante_carnet])
REFERENCES [dbo].[SIFEstudiante] ([id_Carnet])
GO
ALTER TABLE [dbo].[SITExcepcion] CHECK CONSTRAINT [FK_Excepcion_Estudiante]
GO
/****** Object:  ForeignKey [FK_Excepcion_Curso]    Script Date: 12/21/2013 17:09:46 ******/
ALTER TABLE [dbo].[SITExcepcion]  WITH CHECK ADD  CONSTRAINT [FK_Excepcion_Curso] FOREIGN KEY([FK_Curso_idCurso])
REFERENCES [dbo].[SIFCurso] ([id_Curso])
GO
ALTER TABLE [dbo].[SITExcepcion] CHECK CONSTRAINT [FK_Excepcion_Curso]
GO
/****** Object:  ForeignKey [FK_Excepcion_Grupo]    Script Date: 12/21/2013 17:09:46 ******/
ALTER TABLE [dbo].[SITExcepcion]  WITH CHECK ADD  CONSTRAINT [FK_Excepcion_Grupo] FOREIGN KEY([FK_Grupo_idGrupo])
REFERENCES [dbo].[SIFGrupo] ([id_Grupo])
GO
ALTER TABLE [dbo].[SITExcepcion] CHECK CONSTRAINT [FK_Excepcion_Grupo]
GO
/****** Object:  ForeignKey [FK_Excepcion_Periodo]    Script Date: 12/21/2013 17:09:46 ******/
ALTER TABLE [dbo].[SITExcepcion]  WITH CHECK ADD  CONSTRAINT [FK_Excepcion_Periodo] FOREIGN KEY([FK_Periodo_idPeriodo])
REFERENCES [dbo].[SIFPeriodo] ([id_Periodo])
GO
ALTER TABLE [dbo].[SITExcepcion] CHECK CONSTRAINT [FK_Excepcion_Periodo]
GO

/****** Object:  ForeignKey [FK_Horario_Grupo]    Script Date: 12/21/2013 17:09:46 ******/
ALTER TABLE [dbo].[SITHorario]  WITH CHECK ADD  CONSTRAINT [FK_Horario_Grupo] FOREIGN KEY([FK_Grupo_idGrupo])
REFERENCES [dbo].[SIFGrupo] ([id_Grupo])
GO
ALTER TABLE [dbo].[SITHorario] CHECK CONSTRAINT [FK_Horario_Grupo]
GO

/****** Object:  ForeignKey [FK_Datos_Estudiante_Estudiante]    Script Date: 12/21/2013 17:09:46 ******/
ALTER TABLE [dbo].[SITDatos_Estudiante]  WITH CHECK ADD  CONSTRAINT [FK_Datos_Estudiante_Estudiante] FOREIGN KEY([FK_Estudiante_idEstudiante])
REFERENCES [dbo].[SIFEstudiante] ([id_Carnet])
GO
ALTER TABLE [dbo].[SITDatos_Estudiante] CHECK CONSTRAINT [FK_Datos_Estudiante_Estudiante]
GO