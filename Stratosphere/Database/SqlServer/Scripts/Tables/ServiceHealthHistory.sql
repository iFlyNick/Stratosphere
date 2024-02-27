/*
	sqlserver inserts

	description: 
	parent table for ServiceHealthHistoryDetail. this table is responsible for the overall status of a service that
	has been reported. additional detail reported will be stored in the child table. similar to the queuesnapshot table, 
	this table will need to smartly managed to keep footprint low.
*/

create table [Stratosphere].[ServiceHealthHistory] (
	[CreatedBy] varchar(255) not null,
	[CreatedDate] datetime2(7) not null,
	[ModifiedBy] varchar(255) null,
	[ModifiedDate] datetime2(7) null
);