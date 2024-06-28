/*
	postgres inserts

	description: 
	relates to the service table and is reponsible for tracking what assets a given service operates on

	notes:
	defining environmentid here is beneficial as this doesn't box one asset into one environment.
	defining an override name here allows for an individual service to not fully depend on it's core name and 
	be different when deployed for any given reason. for example a docker service could have a different name
	on a given asset compared to it's core name.
*/

create table if not exists Stratosphere.ServiceAsset (
	ServiceId uuid not null,
	AssetId uuid not null,
	CreatedBy varchar(255) not null,
	CreatedDate timestamp not null,
	ModifiedBy varchar(255) null,
	ModifiedDate timestamp null,
	EnvironmentId uuid not null, 
	OverrideName varchar(255) null,
	primary key (ServiceId, AssetId),
	foreign key (ServiceId) references Stratosphere.Service(ServiceId),
	foreign key (AssetId) references Stratosphere.Asset(AssetId),
	foreign key (EnvironmentId) references Stratosphere.Environment(EnvironmentId)
);