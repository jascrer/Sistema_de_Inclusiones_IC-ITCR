INSERT INTO SIFSolicitud (txt_comentario, txt_curso, txt_motivo, txt_estado, fec_creacion, grupo_aceptado, 
							FK_Estudiante_carnet, FK_Periodo_idPeriodo)
		    VALUES('Solicitud 1','ALGORITMOS Y ESTRUCTURAS DE DATOS I','Llenado','PENDIENTE',GETDATE(),0,'200966799', 1)
INSERT INTO SIFSolicitud (txt_comentario, txt_curso, txt_motivo, txt_estado, fec_creacion, grupo_aceptado, 
							FK_Estudiante_carnet, FK_Periodo_idPeriodo)
		    VALUES('Solicitud 2','OCLE','Llenado','PENDIENTE',GETDATE(),0,'200966799', 1)
INSERT INTO SIFSolicitud (txt_comentario, txt_curso, txt_motivo, txt_estado, fec_creacion, grupo_aceptado, 
							FK_Estudiante_carnet, FK_Periodo_idPeriodo)
		    VALUES('Solicitud 3','INTELIGENCIA ARTIFICIAL','Llenado','ANULADA',GETDATE(),0,'200966799', 1)
INSERT INTO SIFSolicitud (txt_comentario, txt_curso, txt_motivo, txt_estado, fec_creacion, grupo_aceptado, 
							FK_Estudiante_carnet, FK_Periodo_idPeriodo)
		    VALUES('Solicitud 4','REDES LOCALES','Llenado','ANULADA',GETDATE(),0,'200966799', 1)
INSERT INTO SIFSolicitud (txt_comentario, txt_curso, txt_motivo, txt_estado, fec_creacion, grupo_aceptado, 
							FK_Estudiante_carnet, FK_Periodo_idPeriodo)
		    VALUES('Solicitud 5','REQUERIMIENTOS DE SOFTWARE','Llenado','APROBADA',GETDATE(),0,'200966799', 1)
INSERT INTO SIFSolicitud (txt_comentario, txt_curso, txt_motivo, txt_estado, fec_creacion, grupo_aceptado, 
							FK_Estudiante_carnet, FK_Periodo_idPeriodo)
		    VALUES('Solicitud 6','ADMINISTRACION DE LA FUNCION DE INFORMACION','Llenado','REPROBADA',GETDATE(),0,'200966799', 1)
		    
SELECT * FROM SIFSolicitud