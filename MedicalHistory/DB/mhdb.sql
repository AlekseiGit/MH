drop table dbo.[Patient]
drop procedure if exists [dbo].[p_get_all_patients]

-- //////// TABLES

GO

CREATE TABLE [dbo].[Patient](
	[ID] [uniqueidentifier] DEFAULT NEWSEQUENTIALID(),
	[MedicalCardNumber] [nvarchar](100) NULL,
	[SName] [nvarchar](100) NULL,
	[FName] [nvarchar](100) NULL,
	[MName] [nvarchar](100) NULL,
	[BirthDate] [datetime] NULL,
	[RegistrationDate] [datetime] NULL,
	[AgeCategory] [nvarchar](100) NULL,
	[Sex] [int] NULL,
	[Weight] [int] NULL,
	[Region] [nvarchar](100) NULL,
	[City] [nvarchar](100) NULL,
	[Address] [nvarchar](max) NULL,
	[Phone] [nvarchar](100) NULL,
	[Organization] [nvarchar](100) NULL,
	[Profession] [nvarchar](100) NULL,
	[Position] [nvarchar](100) NULL

CONSTRAINT [PK_Patient] PRIMARY KEY CLUSTERED
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

-- //////// INSERTS

GO

insert into [dbo].[Patient] (MedicalCardNumber, SName, FName, MName, BirthDate, RegistrationDate, AgeCategory, Sex, Weight, Region, City, Address, Phone, Organization, Profession, Position)
values ('12345', 'qwe', 'asd', 'zxc', '19850319', '20150118', 'zxc', 2, 78, 'shfdjh', 'dfgsd', 'jdgjfkskgydkgsykjsgdj', '1234567', 'hsgdvfhsgadvhf', 'dgsfg', 'hsagdfhgshd')

-- //////// PROCEDURES

GO

CREATE PROCEDURE [dbo].[p_get_all_patients]

AS
BEGIN
	select
		[ID],
		[MedicalCardNumber],
		[SName],
		[FName],
		[MName],
		[BirthDate],
		[RegistrationDate],
		[AgeCategory],
		[Sex],
		[Weight],
		[Region],
		[City],
		[Address],
		[Phone],
		[Organization],
		[Profession],
		[Position]
	from
		[dbo].[Patient] (nolock)
	order by
		[SName] desc
END;