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
update commands set Id_client = 2,
 adress = '15216rtg1po'
 ORDER BY Id DESC LIMIT 1;
 update commands set Id_client = (select Id from clients order by Id DESC LIMIT 1,1),
 adress = (select adress from clients order by Id DESC LIMIT 1,1)
 ORDER BY Id DESC LIMIT 1;
delete from commands where Id_client is null;
select * from ingredients;
drop table ingredients;
CREATE TABLE stocks(
    Id int NOT NULL AUTO_INCREMENT,
    denomination varchar(255) NOT NULL,
    associated_final_product varchar(255),
    numberof varchar(255),
	price varchar(255),
    PRIMARY KEY (Id)
);