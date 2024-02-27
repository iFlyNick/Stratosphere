/*
	sqlserver inserts

	description: 
	relates to the service table and is reponsible for tracking what queues a given service is related to. not all
	services will have a queue.
*/

create table [Stratosphere].[ServiceQueue] (
	[CreatedBy] varchar(255) not null,
	[CreatedDate] datetime2(7) not null,
	[ModifiedBy] varchar(255) null,
	[ModifiedDate] datetime2(7) null
);