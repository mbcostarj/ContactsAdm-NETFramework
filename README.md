# ContactsAdm

_Configurações de DB:_

Virtualização Docker:
`https://learn.microsoft.com/pt-br/sql/linux/quickstart-install-connect-docker?view=sql-server-ver16&tabs=cli&pivots=cs1-bash`

Configurações de login estão no arquivo `appsettings.Development.json`


*Criação da tabela:*
```
CREATE TABLE dbo.Contacts (
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR(100) NULL,
    [Email] NVARCHAR(150) NOT NULL,
    [CreatedDate] DATETIME NULL,
    [UpdatedDate] DATETIME null 
    CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED ([Id] ASC)  
)
```

