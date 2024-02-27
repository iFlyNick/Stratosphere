/*
	postgres inserts

	description: 
	reference table to store queue feeds created by the referenced cloudamqp service. 
*/

create table if not exists Stratosphere.Queue (
	QueueId int generated always as identity,
	QueueName varchar(255) not null,
	VirtualHostId int not null,
	EnvironmentId int not null,
	CreatedBy varchar(255) not null,
	CreatedDate timestamp not null,
	ModifiedBy varchar(255) null,
	ModifiedDate timestamp null,
	primary key (QueueId, VirtualHostId, EnvironmentId),
	foreign key (VirtualHostId) references Stratosphere.VirtualHost(VirtualHostId),
	foreign key (EnvironmentId) references Stratosphere.Environment(EnvironmentId)
);