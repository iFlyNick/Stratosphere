/*
	sqlserver inserts

	description: 
	Child table for AlertProfile. Responsible for storing contact specific details for a given profile.
*/

create table [Stratosphere].[AlertProfileDetail] (
	[CreatedBy] varchar(255) not null,
	[CreatedDate] datetime2(7) not null,
	[ModifiedBy] varchar(255) null,
	[ModifiedDate] datetime2(7) null
);