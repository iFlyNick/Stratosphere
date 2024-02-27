/*
	sqlserver inserts

	description: 
	child to ServiceHealthHistory. this holds the details of the health history for a given service past the basic report.
	examples of additional detail could be the specifics around errors, or reasons the service was down.
*/

create table [Stratosphere].[ServiceHealthHistoryDetail] (
	[CreatedBy] varchar(255) not null,
	[CreatedDate] datetime2(7) not null,
	[ModifiedBy] varchar(255) null,
	[ModifiedDate] datetime2(7) null
);