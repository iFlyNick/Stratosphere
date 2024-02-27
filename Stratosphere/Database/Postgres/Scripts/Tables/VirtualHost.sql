/*
	postgres inserts

	description: 
	reference table to store vhosts created by the referenced cloudamqp service.
*/

create table if not exists Stratosphere.VirtualHost (
	VirtualHostId int generated always as identity,
	VirtualHostName varchar(255) not null,
	EnvironmentId int not null,
	CreatedBy varchar(255) not null,
	CreatedDate timestamp not null,
	ModifiedBy varchar(255) null,
	ModifiedDate timestamp null,
	primary key (VirtualHostId),
	foreign key (EnvironmentId) references Stratosphere.Environment(EnvironmentId)
);