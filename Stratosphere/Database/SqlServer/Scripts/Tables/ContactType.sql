/*
	sqlserver inserts

	description: 
	Simple table to store what options are available for a given contact definition.
*/

create table [Stratosphere].[ContactType] (
	[CreatedBy] varchar(255) not null,
	[CreatedDate] datetime2(7) not null,
	[ModifiedBy] varchar(255) null,
	[ModifiedDate] datetime2(7) null
);