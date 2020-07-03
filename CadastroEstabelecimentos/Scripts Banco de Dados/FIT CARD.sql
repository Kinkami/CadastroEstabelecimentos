
CREATE DATABASE [TesteFernando]

USE [TesteFernando]

CREATE TABLE [dbo].[Estabelecimento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Razao_Social] [varchar](100) NOT NULL,
	[Nome_Fantasia] [varchar](100) NULL,
	[CNPJ] [varchar](13) NOT NULL,
	[Email] [varchar](30) NULL,
	[Endereço] [varchar](100) NULL,
	[Cidade] [varchar](100) NULL,
	[Estado] [varchar](50) NULL,
	[Telefone] [varchar](10) NULL,
	[Data_de_Cadastro] [datetime] NULL,
	[Categoria] [varchar](100) NULL,
	[Status] [varchar](30) NULL,
	[Agencia] [varchar](10) NULL,
	[Conta] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
) ON [PRIMARY]
GO

GO
CREATE PROCEDURE USP_BuscaTodosRegistros
AS
BEGIN
SELECT * FROM [TesteFernando].dbo.Estabelecimento
END
GO

CREATE PROCEDURE USP_InsereNovoEstabelecimento
(
 @Razao_Social VARCHAR(100)= ''
,@Nome_Fantasia VARCHAR(100)= ''
,@CNPJ VARCHAR(13)= ''
,@Email VARCHAR(30)= ''
,@Endereço VARCHAR(100)= ''
,@Cidade VARCHAR(100)= ''
,@Estado VARCHAR(50)= ''
,@Telefone VARCHAR(10)= ''
,@Data_de_Cadastro DATETIME= ''
,@Categoria VARCHAR(100)= ''
,@Status VARCHAR(100)= ''
,@Agencia VARCHAR(10)= ''
,@Conta VARCHAR(10)= ''
)
AS
BEGIN
INSERT INTO [TesteFernando].dbo.Estabelecimento ( Razao_Social,Nome_Fantasia,CNPJ,Email,Endereço,Cidade,Estado,Telefone,Data_de_Cadastro,Categoria,Status,Agencia ,Conta)
Values(@Razao_Social,@Nome_Fantasia,@CNPJ,@Email,@Endereço,@Cidade,@Estado,@Telefone,@Data_de_Cadastro,@Categoria,@Status,@Agencia ,@Conta)
END
GO

CREATE PROCEDURE USP_AtualizaEstabelecimento
(
 @Id int = 0
,@Razao_Social VARCHAR(100)= ''
,@Nome_Fantasia VARCHAR(100)= ''
,@CNPJ VARCHAR(13)= ''
,@Email VARCHAR(30)= ''
,@Endereço VARCHAR(100)= ''
,@Cidade VARCHAR(100)= ''
,@Estado VARCHAR(50)= ''
,@Telefone VARCHAR(10)= ''
,@Data_de_Cadastro DATETIME= ''
,@Categoria VARCHAR(100)= ''
,@Status VARCHAR(30)= ''
,@Agencia VARCHAR(10)= ''
,@Conta VARCHAR(10)= ''
)
AS
BEGIN
UPDATE [TesteFernando].dbo.Estabelecimento SET 
 Razao_Social = @Razao_Social
,Nome_Fantasia = @Nome_Fantasia
,CNPJ = @CNPJ
,Email = @Email
,Endereço = @Endereço
,Cidade = @Cidade
,Estado = @Estado
,Telefone = @Telefone
,Data_de_Cadastro = @Data_de_Cadastro
,Categoria = @Categoria
,Status = @Status
,Agencia = @Agencia
,Conta = @Conta
WHERE Id = @Id

END
GO

CREATE PROCEDURE USP_DeletaEstabelecimento
(
 @Id int = 0
)
AS
BEGIN
DELETE FROM [TesteFernando].dbo.Estabelecimento WHERE Id = @Id
END
GO

CREATE PROCEDURE USP_SelecionaEstabelecimentoPorId
(
 @Id int = 0
)
AS
BEGIN
SELECT * FROM [TesteFernando].dbo.Estabelecimento WHERE Id = @Id
END
GO