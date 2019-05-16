CREATE TABLE [dbo].[Students] (
    [id]            INT            IDENTITY (1, 1) NOT NULL,
	[dept_id]       INT NOT NULL FOREIGN KEY REFERENCES Department(id),
	[cos_id]        INT  NOT NULL FOREIGN KEY REFERENCES Course(id),
    [Name]          NVARCHAR (MAX) NULL,
    [Surname]       NVARCHAR (MAX) NULL,
    [Age]           INT            NOT NULL,
    [IDNumber]      NVARCHAR (MAX) NULL,
    [Grade]         NVARCHAR (MAX) NULL,
    [Discriminator] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.Students] PRIMARY KEY CLUSTERED ([id] ASC),
	

);

