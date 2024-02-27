/*
	sqlserver inserts

	description: 
	Parent table for AlertProfileDetail. This holds high level information around the purpose of an alert but not
	the specifics of the alert parties themselves.
*/

create table [Stratosphere].[AlertProfile] (
	[CreatedBy] varchar(255) not null,
	[CreatedDate] datetime2(7) not null,
	[ModifiedBy] varchar(255) null,
	[ModifiedDate] datetime2(7) null
);