/*
	sqlserver inserts

	description: 
	helper table to store the settings for a given service by environment. used to support how health checks are treated as example as each env could
	have a different setting value that qualifies it for specific alert details.
*/

create table [Stratosphere].[ServiceEnvironmentDetail] (
	[CreatedBy] varchar(255) not null,
	[CreatedDate] datetime2(7) not null,
	[ModifiedBy] varchar(255) null,
	[ModifiedDate] datetime2(7) null
);