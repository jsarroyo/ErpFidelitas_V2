﻿CREATE VIEW [dbo].[Inv_ReporteSaldos]
	AS (
	SELECT	A.ProductId		Codigo,
			B.Name			Nombre,
			SUM(CASE WHEN A.DocumentTypeId = 'Entrada Inventario' THEN 1 ELSE -1 END *
					  A.Quantity) AS Saldo
			
	FROM MovementsInventory A
	LEFT JOIN Products B ON A.CompanyId = B.CompanyId 
							AND A.ProductId = B.ProductId 
	LEFT JOIN DocumentTypes C ON A.DocumentTypeId = C.DocumentTypeId
	Group by A.ProductId,B.Name,A.DocumentTypeId)


create VIEW [dbo].[CXC_ReporteSaldosColones]
	AS 
	SELECT  A.PersonId				Codigo,
			B.FirstName + B.LastName Name,
			SUM(CASE WHEN d.Name in( 'Factura CXC','Nota debito') THEN 1 ELSE -1 END *
					  CASE WHEN A.CurrencyId = 1 THEN A.AMOUNT ELSE A.AMOUNT * 650 end ) AS Saldo		
	FROM   MovementsAccountsReceivable A
	LEFT JOIN Persons B ON A.PersonId = B.PersonId	
    LEFT JOIN TipoCambio C ON C.Cod_IndicadorInterno = 316 AND C.Des_Fecha = getdate()
	LEFT JOIN DocumentTypes d ON A.DocumentTypeId = d.DocumentTypeId 
	GROUP BY A.PersonId,
			B.FirstName + B.LastName
	HAVING SUM(CASE WHEN d.Name in( 'Factura CXC','Nota debito')THEN 1 ELSE -1 END *
					  CASE WHEN A.CurrencyId = 1 THEN A.AMOUNT ELSE A.AMOUNT * 650 end ) <> 0

CREATE VIEW [dbo].[CXC_ReporteSaldosDolares]
	AS 
	SELECT  A.PersonId Codigo,
			B.FirstName + B.LastName Name,
			SUM(CASE WHEN d.Name in( 'Factura CXC','Nota debito')THEN 1 ELSE -1 END *
					  CASE WHEN A.CurrencyId = 2 THEN A.AMOUNT ELSE A.AMOUNT / 650 END) AS Saldo		
	FROM   MovementsAccountsReceivable A
	LEFT JOIN Persons B ON A.PersonId = B.PersonId	
    LEFT JOIN TipoCambio C ON C.Cod_IndicadorInterno = 316 AND C.Des_Fecha = getdate()
	LEFT JOIN DocumentTypes d ON A.DocumentTypeId = d.DocumentTypeId 
	GROUP BY A.PersonId,
			B.FirstName + B.LastName
	HAVING SUM(CASE WHEN d.Name in( 'Factura CXC','Nota debito')THEN 1 ELSE -1 END *
					  CASE WHEN A.CurrencyId = 2 THEN A.AMOUNT ELSE A.AMOUNT / 650 END ) <> 0


CREATE VIEW [dbo].[CXP_ReporteSaldosColones]
	AS 
	SELECT  A.PersonId,
			B.FirstName + B.LastName,
			SUM(CASE WHEN d.Name in( 'Factura CXP','Nota debito')THEN 1 ELSE -1 END *
					  CASE WHEN A.CurrencyId = 1 THEN A.AMOUNT ELSE A.AMOUNT * 650 END ) AS Saldo		
	FROM   MovementsDebtsToPay A
	LEFT JOIN Persons B ON A.PersonId = B.PersonId
	GROUP BY A.PersonId,
			B.FirstName + B.LastName
	HAVING SUM(CASE WHEN d.Name in( 'Factura CXP','Nota debito')THEN 1 ELSE -1 END *
					  CASE WHEN A.CurrencyId = 1 THEN A.AMOUNT ELSE A.AMOUNT * 650 END) <> 0


CREATE VIEW [dbo].[CXP_ReporteSaldosDolares]
	AS 
	SELECT  A.PersonId,
			B.FirstName + B.LastName,
			SUM(CASE WHEN d.Name in( 'Factura CXP','Nota credito CXP')THEN 1 ELSE -1 END *
					  CASE WHEN A.CurrencyId = 2 THEN A.AMOUNT ELSE A.AMOUNT / 650 END) AS Saldo		
	FROM   MovementsDebtsToPay A
	LEFT JOIN Persons B ON A.PersonId = B.PersonId
	GROUP BY A.PersonId,
			B.FirstName + B.LastName
	HAVING SUM(CASE WHEN d.Name in( 'Factura CXP','Nota debito')THEN 1 ELSE -1 END *
					  CASE WHEN A.CurrencyId = 1 THEN A.AMOUNT ELSE A.AMOUNT * 650 END) <> 0
	 