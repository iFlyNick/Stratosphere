/*
	postgres inserts

	description: 
	Simple table to store what options are supported for how a service operates. mainly server information.
*/

create table if not exists Stratosphere.Asset (
	AssetId int generated always as identity,
	AssetTypeId int not null,
	Description varchar(255) not null,
	ConnectionName varchar(255) not null,
	EnvironmentId int not null,
	CreatedBy varchar(255) not null,
	CreatedDate timestamp not null,
	ModifiedBy varchar(255) null,
	ModifiedDate timestamp null,
	primary key (AssetId),
	foreign key (AssetTypeId) references Stratosphere.AssetType(AssetTypeId),
	foreign key (EnvironmentId) references Stratosphere.Environment(EnvironmentId)
);