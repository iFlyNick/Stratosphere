/*
	sqlserver inserts

	description: 
	Historical information about the queues and their counts on a given interval. This table will need to be maintained
	from a data perspective to track changes in counts over time to keep the footprint small. good for a historical view
	of queue counts that go back further than the current cloudamqp retention policy.
*/

create table [Stratosphere].[QueueSnapshot] (
	[CreatedBy] varchar(255) not null,
	[CreatedDate] datetime2(7) not null,
	[ModifiedBy] varchar(255) null,
	[ModifiedDate] datetime2(7) null
);