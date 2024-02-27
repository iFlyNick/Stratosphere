/*
	postgres inserts

	description: 
	Historical information about the queues and their counts on a given interval. This table will need to be maintained
	from a data perspective to track changes in counts over time to keep the footprint small. good for a historical view
	of queue counts that go back further than the current cloudamqp retention policy.
*/

create table if not exists Stratosphere.QueueSnapshot (
	QueueSnapshotId int generated always as identity,
	QueueId int not null,
	VirtualHostId int not null,
	EnvironmentId int not null,
	MessageCount int not null,
	CreatedBy varchar(255) not null,
	CreatedDate timestamp not null,
	ModifiedBy varchar(255) null,
	ModifiedDate timestamp null,
	primary key (QueueSnapshotId),
	foreign key (QueueId) references Stratosphere.Queue(QueueId),
	foreign key (VirtualHostId) references Stratosphere.VirtualHost(VirtualHostId),
	foreign key (EnvironmentId) references Stratosphere.Environment(EnvironmentId)
);