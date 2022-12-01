CREATE TABLE clients(
    Id int NOT NULL AUTO_INCREMENT,
    name varchar(255) NOT NULL,
    main_adress varchar(255),
    tel varchar(255),
	email varchar(255),
    PRIMARY KEY (Id)
);
insert into clients (name,main_adress,tel,email) values ('ter2ze1fofo','15216rtg1po','555216113215','pzfefek@ezfzf.epfm');
select * from clients; 
select * from commands;
CREATE TABLE commands(
    Id int NOT NULL AUTO_INCREMENT,
    delivery_date date NOT NULL,
    adress varchar(255),
    Id_client int,
	vanilla_cookie_number int,
	double_chocolate_cookie_number int,
	classic_cookie_number int,
	lemon_cookie_number int,
    PRIMARY KEY (Id)
);
delete from commands where double_chocolate_cookie_number=0;