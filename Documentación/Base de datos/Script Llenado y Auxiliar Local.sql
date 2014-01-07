USE [Inclutec_BD]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

---------------------
-- Tabla Requisito --
---------------------
CREATE TABLE SITRequisito
(
	id_Requisito int IDENTITY(1,1) NOT NULL,
	FK_Curso_id_Curso varchar(8) NOT NULL,
	FK_Curso_id_Curso_Requisito varchar(8) NOT NULL
)
GO

------------------------
-- Tabla Correquisito --
------------------------
CREATE TABLE SITCorrequisito
(
	id_Correquisito int IDENTITY(1,1) NOT NULL,
	FK_Curso_id_Curso varchar(8) NOT NULL,
	FK_Curso_id_Curso_Correquisito varchar(8) NOT NULL
)
GO

ALTER TABLE SITRequisito ADD CONSTRAINT PK_Requisito PRIMARY KEY (id_Requisito)
ALTER TABLE SITRequisito ADD CONSTRAINT FK_Requisito_Curso FOREIGN KEY(FK_Curso_id_Curso) REFERENCES SIFCurso(id_Curso)
ALTER TABLE SITRequisito ADD CONSTRAINT FK_Requisito_Curso_Requisito FOREIGN KEY(FK_Curso_id_Curso_Requisito) REFERENCES SIFCurso(id_Curso)
GO

ALTER TABLE SITCorrequisito ADD CONSTRAINT PK_Correquisito PRIMARY KEY (id_Correquisito)
ALTER TABLE SITCorrequisito ADD CONSTRAINT FK_Correquisito_Curso FOREIGN KEY(FK_Curso_id_Curso) REFERENCES SIFCurso(id_Curso)
ALTER TABLE SITCorrequisito ADD CONSTRAINT FK_Correquisito_Curso_Correquisito FOREIGN KEY(FK_Curso_id_Curso_Correquisito) REFERENCES SIFCurso(id_Curso)
GO



CREATE PROCEDURE SIT_SP_Insertar_Auto_Estudiantes
	@Apellido1 varchar(20),
	@Apellido2 varchar(20),
	@Nombre varchar(40)
AS
BEGIN
	SET NOCOUNT ON 
    DECLARE @Anno INT;
    DECLARE @NCarnet INT;
    DECLARE @Ex INT;
    DECLARE @NTelCasa INT;
    DECLARE @NTelCelular INT;
    DECLARE @NPlan INT;
    DECLARE @TelCasa nchar(8);
    DECLARE @TelCelular nchar(8);
    DECLARE @Carnet varchar(15);
    DECLARE @Correo varchar(60);
    DECLARE @Max INT;
	DECLARE @Min INT
	SET @Ex = 0
	
	-- Asignación Automática de Carnet --
	WHILE @Ex = 0
	BEGIN
		SET @Min = 1998
		SET @Max = 2014
		SELECT @Anno = ROUND(((@Max - @Min - 1) * RAND() + @Min), 0)
		IF @Anno < 2000
		BEGIN
			SET @Anno = (@Anno - 1900) * 100000
			SET @Min = 0
			SET @Max = 100000
			SELECT @NCarnet = ROUND(((@Max - @Min - 1) * RAND() + @Min), 0)
			SET @NCarnet = @NCarnet + @Anno
		END
		ELSE
			BEGIN
				IF @Anno = 2013
				BEGIN
					SET @Anno = @Anno * 1000000
					SET @Min = 0
					SET @Max = 1000000
					SELECT @NCarnet = ROUND(((@Max - @Min - 1) * RAND() + @Min), 0)
					SET @NCarnet = @NCarnet + @Anno
				END
				ELSE
					BEGIN
						SET @Anno = @Anno * 100000
						SET @Min = 0
						SET @Max = 100000
						SELECT @NCarnet = ROUND(((@Max - @Min - 1) * RAND() + @Min), 0)
						SET @NCarnet = @NCarnet + @Anno
					END
			END
		SET @Carnet = CAST(@NCarnet AS varchar(15))
		IF NOT EXISTS (SELECT * FROM SIFEstudiante  WHERE SIFEstudiante.id_Carnet = @Carnet)
		BEGIN
			SET @Ex = 1
		END
    END
    
    -- Asignación Automática de Teléfonos --
	SET @Min = 20000000
	SET @Max = 30000000
	SELECT @NTelCasa = ROUND(((@Max - @Min - 1) * RAND() + @Min), 0)
	SET @Min = 50000000
	SET @Max = 90000000
	SELECT @NTelCelular = ROUND(((@Max - @Min - 1) * RAND() + @Min), 0)
	SET @TelCasa = CAST(@NTelCasa AS nchar(8))
	SET @TelCelular = CAST(@NTelCelular AS nchar(8))
	
	-- Asignación Automática de Correos Electrónicos --
	SET @Correo = LOWER(LEFT(@Nombre,1) + @Apellido1 + '.' + @apellido2 + '@ic-itcr.ac.cr')
	
	-- Asignación Automática del Plan de Estudios --
	SET @Min = 409
	SET @Max = 411
	SELECT @NPlan = ROUND(((@Max - @Min - 1) * RAND() + @Min), 0)
	
	-- Guardar Tupla --
	INSERT INTO SIFEstudiante
		( 
			id_Carnet,
			nom_nombre,
			txt_apellido_1,
			txt_apellido_2,
			num_telefono,
			num_celular,
			dir_email,
			FK_PlanEstudios_idPlanEstudios
		) 
	VALUES
		(
			@Carnet,
			@Nombre,
			@Apellido1,
			@Apellido2,
			@TelCasa,
			@TelCelular,
			@Correo,
			@NPlan
		)	
	SET NOCOUNT OFF
END 	
GO

CREATE PROCEDURE SIT_SP_Insertar_Estudiante
	@id_Carnet varchar(15),
	@Nombre varchar(40),
	@Apellido1 varchar(20),
	@Apellido2 varchar(20),
	@TelCasa nchar(8),
	@TelCelular nchar(8),
	@Correo varchar(60),
	@id_Plan int
AS
BEGIN
	BEGIN TRANSACTION
		SET NOCOUNT ON 
		IF NOT EXISTS (SELECT * FROM SIFEstudiante  WHERE SIFEstudiante.id_Carnet = @id_Carnet)
		BEGIN 
			INSERT INTO SIFEstudiante
				( 
					id_Carnet,
					nom_nombre,
					txt_apellido_1,
					txt_apellido_2,
					num_telefono,
					num_celular,
					dir_email,
					FK_PlanEstudios_idPlanEstudios
				) 
			VALUES
				(
					@id_Carnet,
					@Nombre,
					@Apellido1,
					@Apellido2,
					@TelCasa,
					@TelCelular,
					@Correo,
					@id_Plan
				)
			COMMIT TRANSACTION
		END
		ELSE
			BEGIN 
				ROLLBACK TRANSACTION 
				PRINT 'ERROR: Estudiante ya Existente...'
			END
		
		SET NOCOUNT OFF
END 	
GO

CREATE PROCEDURE SIT_SP_Insertar_Auto_Plan
	@id_Plan INT,
	@nom_Carrera varchar(50)
AS
BEGIN
	BEGIN TRANSACTION
		SET NOCOUNT ON 
		IF NOT EXISTS (SELECT * FROM SIFPlanEstudios  WHERE SIFPlanEstudios.id_PlanEstudios = @id_Plan)
		BEGIN 
			INSERT INTO SIFPlanEstudios
				( 
					id_PlanEstudios,
					nom_carrera
				) 
			VALUES
				(
					@id_Plan,
					@nom_Carrera
				)
			COMMIT TRANSACTION
		END
		ELSE
			BEGIN 
				ROLLBACK TRANSACTION 
				PRINT 'ERROR: Plan ya Existente...'
			END
		
		SET NOCOUNT OFF
END 	
GO





---------------------------------------------------------------------------------------------------------
------------------------------------------------- LLENADO -----------------------------------------------
---------------------------------------------------------------------------------------------------------


EXEC SIT_SP_Insertar_Auto_Plan 409,'INGENIERÍA EN COMPUTACIÓN 2007'
EXEC SIT_SP_Insertar_Auto_Plan 410,'INGENIERÍA EN COMPUTACIÓN 2013'

EXEC SIT_SP_Insertar_Estudiante '200813008','JUAN JOSE','ROJAS','VALVERDE','22753942','84033737','juanrojas@ic-itcr.ac.cr',409
EXEC SIT_SP_Insertar_Estudiante '200966799','ANA IRINA','CALVO','CARVAJAL','22222222','85032291','acalvo@ic-itcr.ac.cr',409
EXEC SIT_SP_Insertar_Estudiante '201016317','ANDRES EDUARDO','GONZALEZ','ORTIZ','22222222','87068224','andgonzalez@ic-itcr.ac.cr',409
EXEC SIT_SP_Insertar_Estudiante '201030612','JOSE ARNOLDO','SEGURA','CAMPOS','22222222','83370577','jsegura@ic-itcr.ac.cr',409

EXEC SIT_SP_Insertar_Auto_Estudiantes 'ACOSTA','GOMEZ','KLINSMANN MIGUEL'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'ACOSTA','MEJIAS','PRISCILA MARIA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'AGUILAR','SEGURA','CAROLINA DE LOS ANGELES'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'ALPIZAR','RIVERA','ERICK FRANCISCO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'ALPIZAR','ROJAS','ADRIAN JOSE'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'ALVAREZ','ALCAZAR','HUGO DAVID'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'APELTAUER','','TOMAS'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'ARATA','JIMENEZ','JOSE PABLO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'ARAYA','CALDERON','MARIA JOSE'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'ARAYA','ROJAS','JOSEPH GABRIEL'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'ARCE','ULLOA','ALEJANDRO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'ARGUEDAS','UMAÑA','EDER'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'ARGUELLO','CALVO','JEANCARLO JOSUE'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'ARIAS','CHACON','MARIO ESTEBAN'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'ARIAS','RODRIGUEZ','ANA VERONICA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'ASTORGA','LOPEZ','GEOVANNY EDUARDO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'AVENDAÑO','GUTIERREZ','ENMANUEL'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'AVILA','VENEGAS','DANIEL BERNARDO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'AZOFEIFA','QUIROS','CARLOS JOSUE'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'BALLESTEROS','QUIROS','DAVID'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'BARRANTES','FUENTES','WALTHER GABRIEL'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'BECERRA','BLANCO','LESLIE'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'BLANCO','LARIOS','DIEGO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'BONILLA','VARGAS','PABLO ISAAC'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'BOZA','MONGE','ALEXIS ESTEBAN'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'BRENES','ESPINOZA','MARIANO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'BRENES','SOLANO','ERICK ALBERTO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CALDERON','BADILLA','MARCOS'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CAMPOS','RODRIGUEZ','HENRY'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CAPRA','CHAMORRO','GIANLUCA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CARDOCE','CASTELNAU','FERNANDO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CARMONA','ALVARADO','CARLOS ANDRES'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CARMONA','SALAZAR','DIEGO HUMBERTO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CARRANZA','ZUÑIGA','MELISA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CARRILLO','ALARCON','WILLIAM'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CASTILLO','BRAVO','YASER AUGUSTO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CASTILLO','MENDOZA','WALTER'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CASTILLO','QUESADA','ERICK FRANCISCO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CASTILLO','VARGAS','VALERIA MARIA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CASTRO','KOSCHNY','JOAQUIN LEONARDO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CASTRO','ROJAS','ESTEBAN VERTULIO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CASTRO','VARGAS','IVONNE SELENA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CERDAS','FERNANDEZ','STEVEN'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CERVANTES','RODRIGUEZ','JEAN CARLO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CHACON','BOGARIN','JOSE DANIEL'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CHACON','FAETH','LUIS FELIPE'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CHACON','ORDOÑEZ','ADRIAN'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CHAN','CHON','VICTOR'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CHAN','GONZALEZ','DIEGO AUGUSTO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CHAN','HO','ANA CRISTINA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CHAVARRIA','LEITON','GABRIEL ESTEBAN'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CHAVARRIA','RODRIGUEZ','JORGE ADRIAN'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CHAVERRI','PEREZ','JOSE DAVID'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CHAVERRI','QUIROS','LUIS FELIPE'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CHAVES','BERMUDEZ','RICARDO STEVEN'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CHAVES','CAMPOS','ALEJANDRO JOSE'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CHAVES','VASQUEZ','HUGO ARMANDO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CHING','BALTODANO','WALTER FRANCISCO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CONEJO','MORA','LUIS DIEGO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CORDERO','CALDERON','MARIANELA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'COREA','CHACON','ALEJANDRO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CORRALES','HENRIQUEZ','REBECA GABRIELA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CORRALES','MORALES','FRANCISCO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CORRALES','ROUNDA','CHRISTIAN'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CORTES','SAENZ','DANIEL JOSE'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'COTO','CORDERO','JOHNNY ANTONIO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'COTO','MORALES','MARIA FERNANDA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CRUZ','FONSECA','FRANK YEUDY'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CRUZ','SOLIS','EVELYN'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CUADRA','RODRIGUEZ','WILLIAM JAVIER'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'CUBERO','JIMENEZ','ERICK'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'DELGADO','BARBOZA','SILVIA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'DUARTE','ALVAREZ','MAGDIELL FRANCISCO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'DUARTE','PALMA','BRYAN STEVEN'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'ELIZONDO','BARRIOS','RAQUEL MARIA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'ELIZONDO','ROJAS','ANDRES'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'ELLIS','QUESADA','ERNESTO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'ESPINOZA','CASTRO','AMED'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'ESPINOZA','SEGURA','ERICK EDUARDO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'FALLAS','FUENTES','LUIS EDUARDO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'FALLAS','VICTOR','CARLOS ENRIQUE'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'FALLAS','ZUÑIGA','ALVARO ANDRES'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'FERNANDEZ','ARROYO','OSCAR RODOLFO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'FERNANDEZ','OCAMPO','MARIA FERNANDA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'FERNANDEZ','SERAVALLI','JONATHAN ENRIQUE'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'FERNANDEZ','SIBAJA','DANIEL'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'FIGUEROA','MONTERO','MANUEL ANIBAL'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'FLORES','GOMEZ','PABLO JESUS'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'FLORES','SOLIS','JOSE DAVID'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'FONSECA','NAVARRO','LUIS DIEGO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'GAMBOA','ARROYO','FABIAN'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'GAMBOA','GUTIERREZ','DIEGO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'GAMBOA','MONGE','CARLOS ENRIQUE'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'GARBANZO','CALVO','JOSE PABLO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'GARCIA','BOZA','JOSE ANTONIO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'GARRO','CABEZAS','SERGIO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'GATJENS','SANCHO','OTTO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'GOMEZ','BLANCO','ANNIA JESSICA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'GOMEZ','MADRIGAL','JAVIER MARTIN'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'GOMEZ','TREJOS','ALEJANDRO JOSE'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'GONZALEZ','AGUILAR','ADRIAN MOISES'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'GONZALEZ','MIRANDA','CARLOS'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'GONZALEZ','MONTOYA','LEYDI MARILYN'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'GONZALEZ','SALAS','JASON JESUS'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'GONZALEZ','VARGAS','CAROLINA BEATRIZ'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'GUERRERO','CHAVARRIA','RICARDO JOAQUIN'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'GUTIERREZ','PERAZA','CARLOS GUSTAVO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'HERNANDEZ','BONILLA','JOSHUA MIGUEL'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'HIDALGO','QUIROS','KATTIA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'JIMENEZ','BENAVIDES','SEBASTIAN ANTONIO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'JIMENEZ','WILSON','SANTIAGO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'LEITON','CHAVES','DIANA LAURA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'LEITON','FUENTES','LESMES GIOVANNI'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'LEON','FALLAS','JESSICA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'LOPEZ','AGUILAR','SUSAN PATRICIA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'LOPEZ','CORDERO','REBECA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'LOPEZ','DELGADO','ISAAC'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'LOPEZ','RODRIGUEZ','GILBERTO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'MADRIGAL','ACUÑA','RAUL ERNESTO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'MADRIZ','CHACON','JONATHAN'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'MADRIZ','MASIS','GABRIEL EDUARDO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'MADRIZ','MATA','EVELYN MARIA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'MARIN','BOJORGE','ANDRES LUIS'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'MAROTO','ARIAS','MANFRED ENRIQUE'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'MARTINEZ','MADRIZ','LUIS ADOLFO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'MARTINEZ','MONTERO','KEVIN ALEXANDER'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'MARTINEZ','MORALES','ESTEBAN DE JESUS'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'MATA','JARA','SILVIA MARIA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'MAYNARD','GAMBOA','PATRICK'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'MENDEZ','ARCE','KEVIN ALBERTO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'MENDEZ','ARIAS','OLMAN'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'MENDIETA','MOLINA','ERICK ANTONIO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'MENDOZA','FERNANDEZ','LEONARDO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'MEZA','SCHMIDT','JAVIER ESTEBAN'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'MONGE','ANGULO','ERICK ALONSO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'MONGE','BARBOZA','JEAN CARLO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'MONGE','CORNEJO','JOSEPH ALBERTO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'MONTEALEGRE','CORTES','JOHAN ANDRES'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'MONTERO','BERMUDEZ','DAVID RICARDO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'MONTERO','MADRIGAL','JOSUE DAVID'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'MORA','ALVARADO','ERICK DAVID'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'MORA','ANGULO','ADONIS EFRAIN'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'MORA','MENESES','RUBEN'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'MORERA','CARRANZA','KEVIN JOSE'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'MUÑOZ','VILLALOBOS','BRYAN ALEJANDRO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'MURILLO','GARCIA','LUIS DIEGO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'MURILLO','GONZALEZ','ANDRES'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'MURILLO','PANIAGUA','ERNESTO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'NAVARRO','CENTENO','BRYAN EDUARDO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'ORDOÑEZ','VIALES','FABIAN ERNESTO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'ORTIZ','DELGADO','JOSE LUIS'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'OSEJO','BERMUDEZ','CARLOS AUGUSTO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'OSES','MENDEZ','ROBERT ARTURO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'PANIAGUA','VARGAS','ROBERTO CARLO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'PERALTA','BRENES','RODRIGO ALONSO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'PERALTA','COTO','CESAR ANDRES'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'PEREIRA','COTO','JOSUE'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'PICADO','ARIAS','KEVIN GERARDO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'PIZARRO','MADRIGAL','ERIC JOSE'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'PORTUGUEZ','CASTILLO','BAYRON ANDRES'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'PORTUGUEZ','UREÑA','MARIA LISETH'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'PRADO','RODRIGUEZ','LUIS JOSE'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'QUESADA','RODRIGUEZ','MARIO ALONSO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'QUINTEROS','GUELL','JONATHAN'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'QUIROS','PORRAS','NATALIA MARIA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'RAMIJAN','CARMIOL','SAMANTA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'RAMIREZ','BOLAÑOS','PAMELA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'RAMIREZ','CORDERO','MARIAN'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'RAMIREZ','FUENTES','ANDRES MAURICIO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'RAMIREZ','MADRIGAL','JOSUE DAVID'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'RAMIREZ','MENDEZ','ELIANETH'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'RAMIREZ','RAMIREZ','GABRIEL ENRIQUE'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'RAMIREZ','RODRIGUEZ','SEBASTIAN'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'RAMIREZ','ROJAS','ANDRES ALONSO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'RAMIREZ','SOLANO','ISAAC DANIEL'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'RAMIREZ','SOLORZANO','MARINO ESTEBAN'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'RAMIREZ','TORUÑO','DAHIANNA MANUELA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'RAMIREZ','VIQUEZ','ADRIANA MARIA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'RETANA','ROJAS','MARIO ALBERTO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'RIGGIONI','BOLAÑOS','SOLEDAD VANESSA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'RIVAS','CARVAJAL','LARISSA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'RIVERA','CORDERO','BRYAN STEVENS'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'RIVERA','FUENTES','DIEGO JOSE'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'RODRIGUEZ','ARGUEDAS','DILSON GABRIEL'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'RODRIGUEZ','CASTRO','GLORIANA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'RODRIGUEZ','CORRALES','OSCAR JOSE'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'RODRIGUEZ','GUIDO','ALLAN ANDRES'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'RODRIGUEZ','JIMENEZ','ALEJANDRO JOSE'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'RODRIGUEZ','MARIN','MICHAEL ENRIQUE'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'RODRIGUEZ','ROJAS','JOSE RAUL'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'RODRIGUEZ','VILLALOBOS','ADRIAN'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'ROJAS','BRICEÑO','JOSE MOISES'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'ROJAS','CARRANZA','JOSE PABLO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'ROJAS','CHACON','DIEGO JOSE'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'ROJAS','RODRIGUEZ','ERICK YASSON'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'ROMERO','CASTILLO','TATIANA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'ROMERO','ROMERO','LAURA NATALIA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'RUIZ','BRAN','AARON MAURICIO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'SAENZ','ROJAS','FRANCISCO JAVIER'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'SALAZAR','AGUERO','EMMANUEL RODOLFO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'SALAZAR','ALVAREZ','MICHAEL VIRGILIO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'SALES','CARRETO','OSWALDO JAVIER'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'SANCHEZ','BRENES','DANIEL GUSTAVO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'SANCHEZ','MELENDEZ','CRISTIAN ENRIQUE'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'SANCHEZ','MONGE','DANILO ALBERTO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'SANCHEZ','QUIROS','DIEGO ANDRES'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'SANCHEZ','VALVERDE','BRUNO JOSE'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'SANDOVAL','CALVO','MARCOS ALEJANDRO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'SEGURA','BENAVIDES','JOSE ESTEBAN'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'SEGURA','CAMPOS','JOSE ARNOLDO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'SEGURA','SOTO','GERMAN ALONSO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'SEQUEIRA','RUIZ','LOENGRY DE JESUS'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'SIBAJA','CENTENO','ABRAHAM'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'SIBAJA','SANDI','JORGE ALBERTO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'SILES','MASIS','JOSE ADRIAN'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'SOLANO','ALAN','JUAN ALONSO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'SOLANO','FONSECA','MARIA DEL MILAGRO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'SOLANO','REDONDO','FABIAN'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'SOLERA','JIMENEZ','ESTEBAN'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'SOLIS','BARRANTES','CARLOS FERNANDO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'SOLIS','FERNANDEZ','DANIEL EDUARDO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'SOLIS','HERNANDEZ','MAURO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'SOTO','MORA','ERICK ROBERTO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'TAI','LEE','SHIH CHI'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'UGALDE','VALERIO','RODRIGO JOSE'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'ULLOA','PORRAS','JOSE LEANDRO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'UREÑA','TENCIO','MIGUEL CAYETANO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'VALLE','JUAREZ','ESTEBAN JESUS'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'VALVERDE','LOPEZ','STEVEN FABIAN'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'VALVERDE','SOLANO','KARINA MARIA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'VARELA','SOJO','ALBERTO ESTEBAN'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'VARGAS','RAMIREZ','JOHNNY'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'VARGAS','VARGAS','ALLAN MAURICIO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'VASQUEZ','GOMEZ','JOSE DANIEL'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'VASQUEZ','VALERIO','DIEGO ANDRES'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'VASQUEZ','VASQUEZ','ILENIA MARIA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'VEGA','RAMIREZ','OSCAR'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'VENEGAS','MORA','RICARDO DE JESUS'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'VILLAFUERTE','RAMIREZ','SATCHA MELISSA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'VIQUEZ','VEGA','VICTOR HUGO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'VIVAS','ESCAMILLA','JORGE LUIS'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'WONG','CAMPOS','ANDRES JOSE'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'WONG','SHUM','ANDY'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'WU','FENG','GREIVIN'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'YIP','CHEN','MICHAEL'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'ZAMORA','CASTRO','SAUL ALEXANDER'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'ZHENG','MA','WEI HUA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'ZUMBADO','SOLANO','MARION ALEJANDRA'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'ZUÑIGA','CALDERON','ALEJANDRO'
EXEC SIT_SP_Insertar_Auto_Estudiantes 'ZUÑIGA','CHAVES','TATIANA MARIA'