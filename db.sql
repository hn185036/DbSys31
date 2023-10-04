create database DBSYS

use DBSYS

--Creates the user account table
CREATE TABLE UserAccount (
userId integer primary key,
userName varchar (50) not null,
userPassword varchar (50) not null,
userStatus varchar (10) not NULL default 'ACTIVE',
);
--To view the user account table

--Creates the user information table
CREATE TABLE userInformation (
userInfoId integer primary key,
userInfLname varchar (50) not null,
userInfFname varchar (50) not null,
userInfAddress varchar (50) not null default 'No Address',
userInfEmail varchar not null,
userId int
);
