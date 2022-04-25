
/****** Object: Table [dbo].[Products] Script Date: 2/26/2022 5:43:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER TABLE dbo.Paramters DROP CONSTRAINT [FK_CompanyParameters];
GO
 
ALTER TABLE dbo.Persons DROP CONSTRAINT FK_PersonTypeId;
GO
ALTER TABLE dbo.Persons DROP CONSTRAINT FK_PreferedCurrencyId;
GO


ALTER TABLE dbo.[Products] DROP CONSTRAINT FK_UnitPriceCurrencyId;
GO
ALTER TABLE dbo.[Products] DROP CONSTRAINT FK_UnitCostCurrency;
GO
ALTER TABLE dbo.[Products] DROP CONSTRAINT FK_CompanyProducts;
GO
ALTER TABLE dbo.[Products] DROP CONSTRAINT FK_UnitPriceCurrencyId;
GO 


DROP TABLE [dbo].[Currencys];
GO
DROP TABLE [dbo].[Companies];
GO
DROP TABLE [dbo].[Parameters];
GO
DROP TABLE [dbo].[PersonType];
GO
DROP TABLE [dbo].[Products];
GO

DROP TABLE [dbo].[DocumentTypes];
GO
DROP TABLE [dbo].[Persons];
GO
DROP TABLE [dbo].[MovementsDebtsToPay];
GO
DROP TABLE [dbo].[MovementsAccountsReceivable]
GO
DROP TABLE [dbo].[TipoCambio];
GO
DROP TABLE [dbo].[MovementsInventory];
GO
DROP TABLE [dbo].[RolUsers];
GO

DROP TABLE [dbo].[Users];
GO


-- Propósito: Almacenar monedas que se utilizan en el sistema  
-- Valores por defecto: 
--      [CurrencyId]: 1 / [Name]:Colones 
--      [CurrencyId]: 2 / [Name]:Dolares
-- Autor: Jesús Arroyo Murillo
-- Modificaciones: N/A
-- Notas: ** No desarrollar ni diseñar, solo para parametrizacion INICIAL.
CREATE TABLE [dbo].[Currencys] (
    [CurrencyId]            SMALLINT        IDENTITY (1, 1) NOT NULL ,
    [Name]                  VARCHAR (100)    NOT NULL,
    CONSTRAINT PK_Currency PRIMARY KEY NONCLUSTERED ([CurrencyId])
);

-- Propósito: Almacenar empresas que adquieren o utilizan el sistema 
-- Valores por defecto: 
--      [CompanyId] = 1 ,[Name] = 'Compañia TEST', [Active] = 1, [Mision] = '',[Vision]= '',[PrincipalEmail] = 'jesarro88@gmail.com'
-- Autor: Jesús Arroyo Murillo
-- Modificaciones: N/A
-- Notas: ** No desarrollar ni diseñar, solo para parametrizacion INICIAL.
CREATE TABLE [dbo].[Companies] (
    [CompanyId]             INT             IDENTITY(1,1) NOT NULL,
    [Name]                  VARCHAR (100)      NOT NULL,
    [Mision]                VARCHAR (MAX)      NOT NULL,
    [Vision]                VARCHAR (MAX)      NOT NULL,
    [PrincipalEmail]        VARCHAR (100)      NOT NULL,
    [Active]                BIT      NOT NULL
    CONSTRAINT PK_Company PRIMARY KEY NONCLUSTERED (CompanyId)
);

-- Propósito: Almacenar parametros generales.
-- Valores por defecto: Parametrizar valores importantes del sistema ejemplo : Logo del sistema
-- Autor: Jesús Arroyo Murillo
-- Modificaciones: N/A
-- Notas: ** No desarrollar ni diseñar, solo para parametrizacion INICIAL, Insertar valores que se requieren.
CREATE TABLE [dbo].[Parameters] (
    [CompanyId]             INT             NOT NULL ,
    [ParameterId]           INT             IDENTITY (1, 1) NOT NULL,
    [Name]                  VARCHAR (100)   NOT NULL,
    [Value]                 VARCHAR (MAX)   NOT NULL,
    [Details]               VARCHAR (MAX)   NOT NULL,
    CONSTRAINT PK_CompanyParameters  PRIMARY KEY NONCLUSTERED ([ParameterId]),
    CONSTRAINT FK_CompanyParameters  FOREIGN KEY ([CompanyId])
                                    REFERENCES [dbo].[Companies] ([CompanyId])
);


-- Propósito: Clasificar tipos de personas segun el tipo de identificacion que se registra.
-- Autor: Jesús Arroyo Murillo
-- Modificaciones: N/A 
-- Valores por defecto:
--      [PersonTypeId] = 1 ,[Name] = 'Física'.
--      [PersonTypeId] = 2 ,[Name] = 'Jurídica'.
-- Notas: **  UTILIZAR PARA NO QUEMAR VALORES EN EL CODIGO
CREATE TABLE [dbo].[PersonType] (
    [PersonTypeId]          SMALLINT        IDENTITY (1, 1) NOT NULL,
    [Name]                  VARCHAR (100)    NOT NULL,
    CONSTRAINT PK_PersonType  PRIMARY KEY NONCLUSTERED ([PersonTypeId])
);

 
-- Propósito: Insertar personas/clientes/proveedores para referenciar en los movimientos del sistema
-- Autor: Jesús Arroyo Murillo
-- Modificaciones: N/A 
-- Valores por defecto: N/A
-- Notas: **  
CREATE TABLE [dbo].[Persons] (    
    [PersonId]              BIGINT          IDENTITY (1, 1) NOT NULL,
    [FirstName]             VARCHAR (100)   NOT NULL,
    [LastName]              VARCHAR (100)   NOT NULL,
    [BirthDay]              DATETIME        NULL,
    [NumberId]              VARCHAR (100)   NULL,
    [PersonTypeId]          SMALLINT        NULL,
    [PreferedCurrencyId]    SMALLINT        NULL, 


    CONSTRAINT PK_PersonId  PRIMARY KEY NONCLUSTERED ([PersonId]),

    CONSTRAINT FK_PersonTypeId FOREIGN KEY (PersonTypeId)
                                    REFERENCES [dbo].PersonType ([PersonTypeId])
                                    --ON DELETE CASCADE
                                    ON UPDATE CASCADE,
    CONSTRAINT FK_PreferedCurrencyId FOREIGN KEY ([PreferedCurrencyId])
                                    REFERENCES [dbo].Currencys ([CurrencyId])
                                    --ON DELETE CASCADE
                                    ON UPDATE CASCADE

);

-- Propósito: Productos del sistema de inventario
-- Autor: Jesús Arroyo Murillo
-- Modificaciones: N/A 
-- Valores por defecto:  Insertar productos que la compania vende o comercializa
-- Notas: **   
CREATE TABLE [dbo].[Products] (
    [CompanyId]             INT             NOT NULL,
    [ProductId]             BIGINT          IDENTITY (1, 1) NOT NULL,    
    [Name]                  VARCHAR (100)    NOT NULL,
    [UnitPrice]             DECIMAL (18, 4) NOT NULL,
    [UnitCost]              DECIMAL (18, 4) NOT NULL,
    [UnitCostCurrencyId]        SMALLINT        NULL,
    [UnitPriceCurrencyId]   SMALLINT        NULL,
     
    CONSTRAINT PK_ProductId  PRIMARY KEY NONCLUSTERED ([ProductId]),

    CONSTRAINT FK_UnitPriceCurrencyId FOREIGN KEY ([UnitPriceCurrencyId])
                                    REFERENCES [dbo].Currencys ([CurrencyId]),
    CONSTRAINT FK_UnitCostCurrency  FOREIGN KEY ([UnitCostCurrencyId])
                                    REFERENCES [dbo].Currencys ([CurrencyId]),
                                    
    CONSTRAINT FK_CompanyProducts  FOREIGN KEY ([CompanyId])
                                    REFERENCES [dbo].[Companies] ([CompanyId])
);

-- Propósito: Productos del sistema de inventario
-- Autor: Jesús Arroyo Murillo
-- Modificaciones: N/A 
-- Valores por defecto:  Insertar valores del servicio de tipo de cambio. 
-- Notas: ** 
CREATE TABLE [dbo].[TipoCambio] (  
    [Consecutivo]           BIGINT          NOT NULL,
    [Cod_IndicadorInterno]  INT             NOT NULL,
    [Des_Fecha]             DATETIME        NOT NULL,
    [Num_Valor]             DECIMAL (18, 4) NOT NULL
);

-- Propósito: Referenciar cuentas donde se almacenan los datos contables y clasificar el tipo de documento
-- Autor: Jesús Arroyo Murillo
-- Modificaciones: N/A 
-- Valores por defecto:  Insertar valores del servicio de tipo de cambio. 
-- Notas: ** se debe referenciar las cuentas [DebitAccountId] y [CreditAccountId] 
CREATE TABLE [dbo].[DocumentTypes] ( 
    [DocumentTypeId]        SMALLINT        IDENTITY (1, 1)     NOT NULL,
    [Name]                  VARCHAR (100)   NOT NULL,
    [DebitAccountId]        SMALLINT        NOT NULL,
    [CreditAccountId]       SMALLINT        NOT NULL,

    CONSTRAINT PK_DocumentTypeId  PRIMARY KEY NONCLUSTERED ([DocumentTypeId])
);
 

-- Propósito: Almacenar los documentos de cuentas por pagar
-- Autor: Jesús Arroyo Murillo
-- Modificaciones: N/A 
-- Valores por defecto:  Insertar valores del servicio de tipo de cambio. 
-- Notas: ** 
CREATE TABLE [dbo].[MovementsDebtsToPay] (    
    [CompanyId]             INT             NOT NULL,
    [DebtsToPayId]          BIGINT          IDENTITY (1, 1) NOT NULL,
    [PersonId]              BIGINT          NULL,
    [CurrencyId]            SMALLINT        NULL,
    [Amount]                DECIMAL (18, 4) NULL,
    [DocumentTypeId]        SMALLINT        NOT NULL,
    
    CONSTRAINT PK_MovementsDebtsToPay  PRIMARY KEY NONCLUSTERED ([DebtsToPayId]),

    CONSTRAINT FK_CompanyMovementsDebtsToPay  FOREIGN KEY ([CompanyId])
                                        REFERENCES [dbo].[Companies] ([CompanyId]),
    CONSTRAINT FK_MovementsDebtsToPayCurrency  FOREIGN KEY ([CurrencyId])
                                    REFERENCES [dbo].Currencys ([CurrencyId]),

    CONSTRAINT FK_MovementsDebtsToPayDocumentTypes  FOREIGN KEY ([DocumentTypeId])
                                    REFERENCES [dbo].[DocumentTypes] ([DocumentTypeId]),
                                    
);

-- Propósito: Almacenar los documentos de cuentas por cobrar
-- Autor: Jesús Arroyo Murillo
-- Modificaciones: N/A 
-- Valores por defecto:   documentos del sistema de cuentas por cobrar
-- Notas: ** 
 
CREATE TABLE [dbo].[MovementsAccountsReceivable] (
    [CompanyId]             INT             NOT NULL,
    [AccountsReceivableId]  BIGINT          IDENTITY (1, 1) NOT NULL,
    [PersonId]              BIGINT          NULL,
    [CurrencyId]            SMALLINT        NULL,
    [Amount]                DECIMAL (18, 4) NULL,
    [DocumentTypeId]        SMALLINT        NOT NULL,

    CONSTRAINT PK_MovementsAccountsReceivable  PRIMARY KEY NONCLUSTERED ([AccountsReceivableId]),

    CONSTRAINT FK_CompanyMovementsAccountsReceivable  FOREIGN KEY ([CompanyId])
                                        REFERENCES [dbo].[Companies] ([CompanyId]),
    CONSTRAINT FK_MovementsAccountsReceivableCurrency  FOREIGN KEY ([CurrencyId])
                                    REFERENCES [dbo].Currencys ([CurrencyId]),

    CONSTRAINT FK_MovementsAccountsReceivableDocumentTypes  FOREIGN KEY ([DocumentTypeId])
                                    REFERENCES [dbo].[DocumentTypes] ([DocumentTypeId]),
);

-- Propósito: Almacenar los documentos de inventario
-- Autor: Jesús Arroyo Murillo
-- Modificaciones: N/A 
-- Valores por defecto:   documentos del sistema de inventario
-- Notas: ** 
 
CREATE TABLE [dbo].[MovementsInventory] (
    [CompanyId]             INT             NOT NULL,
    [InventoryMovementId]   BIGINT          IDENTITY (1, 1) NOT NULL,
    [DocumentTypeId]        SMALLINT        NOT NULL,
    [ProductId]             BIGINT          NOT NULL, 
    [Quantity]              DECIMAL (18, 4) NOT NULL,
    [MovementDate]          DATE            NOT NULL,
    [MovementLogDate]       DATE            NOT NULL,
    [UnitPrice]             DECIMAL (18, 4) NOT NULL,
    [UnitCost]              DECIMAL (18, 4) NOT NULL,
    [CostCurrencyId]        SMALLINT        NULL,
    [UnitPriceCurrencyId]   SMALLINT        NULL, 


    CONSTRAINT PK_InventoryMovement  PRIMARY KEY NONCLUSTERED (InventoryMovementId),

    CONSTRAINT FK_CompanyMovementsInventory  FOREIGN KEY ([CompanyId])
                                        REFERENCES [dbo].[Companies] ([CompanyId]),
    CONSTRAINT FK_MovementsInventoryUnitCostCurrency  FOREIGN KEY ([CostCurrencyId])
                                    REFERENCES [dbo].Currencys ([CurrencyId]),
    CONSTRAINT FK_MovementsInventoryUnitPriceCurrency  FOREIGN KEY ([UnitPriceCurrencyId])
                                    REFERENCES [dbo].Currencys ([CurrencyId]),
                                    
    CONSTRAINT FK_MovementsInventoryDocumentTypes  FOREIGN KEY ([DocumentTypeId])
                                    REFERENCES [dbo].[DocumentTypes] ([DocumentTypeId]),
    
    CONSTRAINT FK_Products  FOREIGN KEY ([ProductId])
                                    REFERENCES [dbo].[Products] ([ProductId]),

);

CREATE TABLE [dbo].[RolUsers] ( 
    [RolId]        INT        IDENTITY (1, 1)   NOT NULL,
    [TypeRol]                  VARCHAR (100)   NOT NULL,

	 CONSTRAINT PK_RolId  PRIMARY KEY NONCLUSTERED ([RolId]),
);
 
CREATE TABLE [dbo].[Users] ( 
    [UserId]        INT        IDENTITY (1, 1)  NOT NULL,
    [RolId]          INT       NOT NULL,
	[FirstName]             VARCHAR (100)   NOT NULL,
	[UserName]               NVARCHAR(255) NOT NULL,
	[Email]                  NVARCHAR(255) NOT NULL,
	[Password]               NVARCHAR(255) NOT NULL,

	CONSTRAINT PK_UserId  PRIMARY KEY NONCLUSTERED (UserId),

	CONSTRAINT FK_RolUsers  FOREIGN KEY ([RolId])
                                    REFERENCES [dbo].[RolUsers] ([RolId]),
);