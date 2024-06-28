/*
	postgres inserts

	description: 
	relates to the service table and is reponsible for tracking what queues a given service is related to. not all
	services will have a queue.
*/

create table if not exists Stratosphere.ServiceQueue (
	ServiceId uuid not null,
	QueueId uuid not null,
	CreatedBy varchar(255) not null,
	CreatedDate timestamp not null,
	ModifiedBy varchar(255) null,
	ModifiedDate timestamp null,
	primary key (ServiceId, QueueId),
	foreign key (ServiceId) references Stratosphere.Service(ServiceId),
	foreign key (QueueId) references Stratosphere.Queue(QueueId)
);