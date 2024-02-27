/*
	sqlserver inserts

	description: 
	core functionality to track services. responsible for most of the details of a given service.
*/

create table [Stratosphere].[Service] (
	[CreatedBy] varchar(255) not null,
	[CreatedDate] datetime2(7) not null,
	[ModifiedBy] varchar(255) null,
	[ModifiedDate] datetime2(7) null
);