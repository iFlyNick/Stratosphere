/*
	sqlserver inserts

	description: 
	reference table to store queue feeds created by the referenced cloudamqp service. 
*/

create table [Stratosphere].[Queue] (
	[CreatedBy] varchar(255) not null,
	[CreatedDate] datetime2(7) not null,
	[ModifiedBy] varchar(255) null,
	[ModifiedDate] datetime2(7) null
);