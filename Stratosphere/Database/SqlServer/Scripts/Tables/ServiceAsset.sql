/*
	sqlserver inserts

	description: 
	relates to the service table and is reponsible for tracking what assets a given service operates on
*/

create table [Stratosphere].[ServiceAsset] (
	[CreatedBy] varchar(255) not null,
	[CreatedDate] datetime2(7) not null,
	[ModifiedBy] varchar(255) null,
	[ModifiedDate] datetime2(7) null
);