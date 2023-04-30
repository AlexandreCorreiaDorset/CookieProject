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

select commands.Id, clients.name, delivery_date, adress,
                            vanilla_cookie_number, double_chocolate_cookie_number,
                            classic_cookie_number, lemon_cookie_number from commands
                        inner join clients on clients.Id = commands.Id_client where clients.name like '%%';

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
CREATE TABLE stocks(
    Id int NOT NULL AUTO_INCREMENT,
    denomination varchar(255) NOT NULL,
    associated_final_product varchar(255),
    numberof int,
	price int,
    PRIMARY KEY (Id)
);

select Id from ingredients;
drop table ingredients;

CREATE TABLE ingredients(
    Id int NOT NULL AUTO_INCREMENT,
    ingredient_name varchar(255) NOT NULL,
    quantity int,    
    PRIMARY KEY (Id)
);
insert into ingredients (ingredient_name,quantity) values
 ('salt',1),
 ('white_chocolate_chip',1),
 ('vanilla_extract',1),
('sugar',1),
('salt',1),
('milk',1),
('macadamia_nuts',1),
('lemon_flavour',1),
('chocolate_chip',1),
('canola_oil',1),
('all_purpose_flour',1);
select * from ingredients;
CREATE TABLE delivery(
    Id int NOT NULL AUTO_INCREMENT,
    delivery_date date,
    product_id int,
    numberof int,
	price int,
    PRIMARY KEY (Id),
    FOREIGN KEY (product_id) REFERENCES ingredients(Id)
);
drop table delivery;
Select * from ingredients where ingredient_name like '%av%'
union
Select * from ingredients where found_rows() =0
 and ingredient_name like '%%';
 
 Select * from ingredients where ingredient_name like '%al%'
union Select* from ingredients where found_rows() = 0 and ingredient_name like '%%';
 
 select delivery.Id, ingredients.ingredient_name, delivery_date,numberof, price from delivery
 inner join ingredients on ingredients.Id = delivery.product_id where ingredients.ingredient_name = '%%';

select * from delivery;

select * from ingredients;
update delivery set numberof = 5,price = 100,delivery_date = '2222-12-22' ORDER BY Id DESC LIMIT 1; 
Select * from delivery where Id= (select Id from delivery order by Id desc limit 1 );
 insert into delivery (delivery_date,product_id,numberof,price)
 values
 ('2222-01-01',1,2,5),
('2222-01-01',2,2,5) ,
('2222-01-01',3,2,5) ,
('2222-01-01',4,2,5),
('2222-01-01',5,2,5),
('2222-01-01',6,2,5),
('2222-01-01',7,2,5),
('2222-01-01',8,2,5)
