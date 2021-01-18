create database sims
		
		use sims

		create table users (id int PRIMARY KEY IDENTITY (1,1 ), usename varchar(60), password varchar(60), post varchar(60), contact varchar(60))

		INSERT INTO users VALUES ('admin','admin','Admin','03254169854');
		INSERT INTO users VALUES ('saleperson','saleperson','Sales Person','03254876521');
		INSERT INTO users VALUES ('salemanager','salemanager','Sales Manager','02154876351');
		INSERT INTO users VALUES ('invmanager','invmanager','Inventory Manager','02154896512'); 



		create table inventory (id int PRIMARY KEY IDENTITY ( 1,1 ), name varchar(60), quantity int, price int, category varchar(60), measuringunit varchar(60))

		INSERT INTO inventory VALUES ('Bread',99,45,'Eatables','Packets');
		INSERT INTO inventory VALUES ('Eggs',109,8,'Eatables','Peices');
		INSERT INTO inventory VALUES ('Apple',199,10,'Friuts','Peices');
		INSERT INTO inventory VALUES ('Orange',199,12,'Friuts','Peices');
		INSERT INTO inventory VALUES ('PineApple',209,200,'Friuts','Peices');
		INSERT INTO inventory VALUES ('Butter',399,250,'Eatables','Tub');
		INSERT INTO inventory VALUES ('Ice Cream',159,350,'Eatables','Tub');
		INSERT INTO inventory VALUES ('Vegetable Oil',159,180,'Eatables','Bag');
		INSERT INTO inventory VALUES ('Oilive Oil',159,400,'Eatables','Bag');
		INSERT INTO inventory VALUES ('Rice',209,150,'Eatables','Kg');




		create table transactions (id int PRIMARY KEY IDENTITY ( 1,1 ), CustomerName varchar(60), Date DATE, Amount int, PaymentMethod varchar(60) )



		





		create table messages(id int PRIMARY KEY IDENTITY ( 1,1 ), Recepient varchar(60), Sender varchar(60), Date varchar(60), Message varchar(255) )
		

		select * from users

		select * from inventory

		select * from transactions

		select * from messages

		
