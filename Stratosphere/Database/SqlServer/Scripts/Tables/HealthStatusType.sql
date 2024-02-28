/*
	sqlserver inserts

	description: 
	simple table to hold status id's and their definitions
*/

create table [Stratosphere].[HealthStatusType] (
	[CreatedBy] varchar(255) not null,
	[CreatedDate] datetime2(7) not null,
	[ModifiedBy] varchar(255) null,
	[ModifiedDate] datetime2(7) null
);