/*
	sqlserver inserts

	description: 
	Simple table to store what options are supported for how a service operates. mainly server information.
*/

create table [Stratosphere].[Asset] (
	[CreatedBy] varchar(255) not null,
	[CreatedDate] datetime2(7) not null,
	[ModifiedBy] varchar(255) null,
	[ModifiedDate] datetime2(7) null
);