/*
	sqlserver inserts

	description: 
	Base information around supported service types. ie) Docker, IIS Application, Windows Service, etc.
*/

create table [Stratosphere].[ServiceType] (
	[CreatedBy] varchar(255) not null,
	[CreatedDate] datetime2(7) not null,
	[ModifiedBy] varchar(255) null,
	[ModifiedDate] datetime2(7) null
);