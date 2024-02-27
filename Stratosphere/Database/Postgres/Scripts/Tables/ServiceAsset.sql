/*
	postgres inserts

	description: 
	relates to the service table and is reponsible for tracking what assets a given service operates on
*/

create table if not exists Stratosphere.ServiceAsset (
	CreatedBy varchar(255) not null,
	CreatedDate timestamp not null,
	ModifiedBy varchar(255) null,
	ModifiedDate timestamp null
);