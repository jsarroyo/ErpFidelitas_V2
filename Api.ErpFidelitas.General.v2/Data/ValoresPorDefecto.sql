INSERT INTO Currencys VALUES('Colones');
INSERT INTO Currencys VALUES('Dolares');

 
INSERT INTO [Companies] VALUES('Companía TEST','','','jesarro88@gmail.com',1); 


INSERT INTO [Parameters] VALUES(1,'Logo sistema','D:\Chus\Fidelitas\2022\ERP\LOGOPRINCIPAL.JPG','Logo para identificacion de la marca');

--TRUNCATE TABLE [PersonType]
INSERT INTO [PersonType] VALUES('Física'); 
INSERT INTO [PersonType] VALUES('Jurídica');

--TRUNCATE TABLE [Persons]
INSERT INTO [Persons] VALUES('Jesus','Arroyo','04/08/1988','999999',1,1); 

--TRUNCATE TABLE [Products]
INSERT INTO [Products] VALUES(1,'Teclado',1000,600,1,1); 
INSERT INTO [Products] VALUES(1,'Monitor',50600,99600,1,1); 
INSERT INTO [Products] VALUES(1,'Mouse',5600,17600,1,1);

--TRUNCATE TABLE [DocumentTypes]
INSERT INTO [DocumentTypes] VALUES('Factura de venta' ,1,2); --****corregir las cuentas por el id de la cuenta que corresponde
INSERT INTO [DocumentTypes] VALUES('Anulacion de venta' ,1,2); --****corregir las cuentas por el id de la cuenta que corresponde
INSERT INTO [DocumentTypes] VALUES('Nota Crédito'     ,1,2); --****corregir las cuentas por el id de la cuenta que corresponde
INSERT INTO [DocumentTypes] VALUES('Nota Débito'      ,1,2); --****corregir las cuentas por el id de la cuenta que corresponde
INSERT INTO [DocumentTypes] VALUES('Entrada inventario',1,2); --****corregir las cuentas por el id de la cuenta que corresponde
INSERT INTO [DocumentTypes] VALUES('Salida  inventario',1,2); --****corregir las cuentas por el id de la cuenta que corresponde
INSERT INTO [DocumentTypes] VALUES('Cheques'          ,1,2); --****corregir las cuentas por el id de la cuenta que corresponde
INSERT INTO [DocumentTypes] VALUES('Transferencia'    ,1,2); --****corregir las cuentas por el id de la cuenta que corresponde
INSERT INTO [DocumentTypes] VALUES('Recibo de dinero',1,2); --****corregir las cuentas por el id de la cuenta que corresponde
INSERT INTO [DocumentTypes] VALUES('Anulacion Recibo de dinero',1,2); --****corregir las cuentas por el id de la cuenta que corresponde
 
--TRUNCATE TABLE [RolUsers]
INSERT INTO [RolUsers] VALUES('Administrador'); 
INSERT INTO [RolUsers] VALUES('Usuario'); 


--TRUNCATE TABLE [Users]
INSERT INTO [Users] VALUES(1,'Yislim','Yislim01','yis@gmail.com','Yis0123or'); 
INSERT INTO [Users] VALUES(2,'Dennis','Dennis01','dennis@gmail.com','dennis0123'); 

 