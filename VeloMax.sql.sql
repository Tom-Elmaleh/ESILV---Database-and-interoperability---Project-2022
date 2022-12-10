drop database if exists VeloMax; 
create database if not exists VeloMax; 
use VeloMax;
drop table if exists modele;

create table if not exists modele (
numM int not null,
nomVelo varchar(20) null,
grandeur varchar(10) null,
prix int null,
ligne varchar(20) null,
date_introV varchar(10) null,
date_sortieV varchar(10) null,
stockM int null,
primary key(numM) );

drop table if exists piece;
create table if not exists piece (
numP varchar(10) not null,
descriptionP varchar(40) null,
num_catalogue int null,
delai int null,
stock int null,
prixP int null,
primary key(numP) );

drop table if exists entreprise;
create table if not exists entreprise (
nomE varchar(20) not null,
telephoneE varchar(20) null,
addresseE varchar(30) null,
courrielE varchar(20) null,
contactE varchar(20) null,
volume_achat int null,
remise float null, 
primary key(nomE) );

drop table if exists fournisseur;
create table if not exists fournisseur (
siret varchar(20) not null,
nomF varchar(20) null,
adresseF varchar(30) null,
contactF varchar(20) null,
libelle int null,
stockF int null,
primary key(siret) );

drop table if exists fidelio;
create table if not exists fidelio(
numero int not null,
descriptionf varchar(40),
cout int null,
duree int null,
rabais int null, 
primary key(numero));

drop table if exists individu;
create table if not exists individu (
id int not null,
nomI varchar(20)  null,
prenom varchar(20) null,
telephoneI varchar(20) null,
adresseI varchar(30) null,
courrielI varchar(40) null,
numero int null,
date_adhesion varchar(10) null,
primary key(id) ,
foreign key(numero)
	references fidelio(numero)
    on delete no action);

drop table if exists commande;
create table if not exists commande (
numC int not null,
dateC varchar(10)  null,
dateLivraison varchar(10) null,
adresseC varchar(30) null,
nomE varchar(30) null,
id int null,
primary key(numC),
foreign key(nomE) 
	references entreprise(nomE)
    on delete no action ,
foreign key(id)
	references individu(id)
    on delete no action);

    
drop table if exists contenu_modele;
create table if not exists contenu_modele(
quantiteM int null,
numM int not null,
numC int not null,
primary key(numM,numC),
foreign key(numM)
	references modele(numM)
    on delete no action
    on update no action,
foreign key(numC)
	references commande(numC)
     on delete no action
    on update no action);
    
drop table if exists contenu_Piece;
create table if not exists contenu_Piece(
quantiteP int null,
numP varchar(10) not null,
numC int not null,
primary key(numP,numC),
foreign key(numP)
	references piece(numP)
    on delete no action 
    on update no action ,
foreign key(numC)
	references commande(numC)
	on delete no action
    on update no action
    );
    
drop table if exists assemblage;
create table if not exists assemblage(
numM int not null,
numP varchar(10) not null,
primary key(numM,numP),
foreign key(numM)
	references modele(numM)
    on delete no action
    on update no action,
foreign key(numP)
	references piece(numP)
    on delete  no action
    on update no action);

drop table if exists production;
create table if not exists production(
date_introP varchar(10)  null,
date_sortieP varchar(10) not null,
numP varchar(10) not null,
siret varchar(20) not null,
primary key(numP,siret),
foreign key(numP)
	references piece(numP)
    on delete no action
    on update no action,
foreign key(siret)
	references fournisseur(siret));
    
drop table if exists livraison;
create table if not exists livraison(
numP varchar(10) not null,
siret varchar(20) not null,
primary key(numP,siret),
foreign key(numP)
	references piece(numP)
    on delete no action
    on update no action,
foreign key(siret)
	references fournisseur(siret));
    
    
insert into modele values (101, 'Kilimandjaro','Adultes',569,'VTT','10/11/18','10/11/20',2);
insert into modele values (102,	'NorthPole',	'Adultes',	329 ,	'VTT','10/12/18','10/12/20',1);
insert into modele values (103	,'MontBlanc',	'Jeunes',	399, 	'VTT','10/01/18','10/01/20',10);
insert into modele values (104	,'Hooligan',	'Jeunes',199 ,'VTT','10/05/18','10/05/20',30);
insert into modele values (105	,'Orléans',	'Hommes',	229 ,	'Vélo de course','10/12/18','10/12/20',2);
insert into modele values (106	,'Orléans',	'Dames',	229 ,	'Vélo de course', '10/06/19','10/06/21',10);
insert into modele values (107	,'BlueJay',	'Hommes',	349 ,	'Vélo de course','10/12/19','10/12/21',100);
insert into modele values (108	,'BlueJay',	'Dames',	349 ,	'Vélo de course','10/02/19','10/12/21',2);
insert into modele values (109	,'Trail Explorer',	'Filles',	129 ,	'Classique','10/07/19','10/07/21',1);
insert into modele values (110	,'Trail Explorer',	'Garçons',	129 ,	'Classique','10/04/19','10/04/21',10);
insert into modele values (111	,'Night Hawk',	'Jeunes',	189 ,	'Classique','10/01/21','10/01/22',0);
insert into modele values (112	,'Tierra Verde',	'Hommes',	199,	'Classique','10/03/20','10/03/22',30);
insert into modele values (113	,'Tierra Verde',	'Dames',	199 ,	'Classique','10/05/20','10/05/22',20);
insert into modele values (114	,'Mud Zinger I',	'Jeunes',	279 ,	'BMX','10/08/20','10/08/22',0);
insert into modele values (115	,'Mud Zinger II',	'Adultes',	359 ,	'BMX','10/11/20','10/11/22',30);

insert into fidelio values(0,	"Pas d'abonnement",0,0,0);
insert into fidelio values(1,	'Fidélio',	15 ,	1,	5 );
insert into fidelio values(2,	'Fidélio Or',	25 ,	2 	,8 );
insert into fidelio values(3,	'Fidélio Platine',	60 ,	2 ,	10 );
insert into fidelio values(4,	'Fidélio Max',	100 ,	3 , 12 );

insert into fournisseur values('123 456 789 00011', 'Generation Velo','Courbevoie','0611866902',4,70);
insert into fournisseur values('122 456 799 00009', 'Cyclotron','Neuilly','0611098902',3,5);
insert into fournisseur values('173 459 789 00056', 'Pedalo','Ormesson','0611898955',2,8);
insert into fournisseur values('123 450 787 00067', 'Velociraptor','Saint-Denis','0617598902',1,3);

insert into individu values(1,'ELMALEH','Tom','0699146786','Ormesson','tom.elmaleh@edu.devinci.fr',1,'19/04/18');
insert into individu values(2,'ERIC','Thessa','0699246786','Courbevoie','thessa.eric@edu.devinci.fr',2,'18/08/19');
insert into individu values(3,'FELZINES','Geraud','0699346786','Neuilly','geraud.felzines@edu.devinci.fr',3,'14/01/20');
insert into individu values(4,'DORLEANS','Felicity','0699446786','Suresnes','felicity.dorleans@edu.devinci.fr',4,'16/05/21');
insert into individu values(5,'GUILIERON','Amadeo','0699546786','Passy','amadeo.guilieron@edu.devinci.fr',1,'11/04/22');
insert into individu values(6,'ESNOUX','Augustin','0699646786','Saint-Denis','augustin.esnoux@edu.devinci.fr',2,'05/02/19');
insert into individu values(7,'GARNIL','Victoria','0699746786','Versailles','victoria.garnil@edu.devinci.fr',3,'25/09/21');
insert into individu values(8,'FAELLI','Lorenzo','0699846786','Melun','lorenzo.faelli@edu.devinci.fr',4,'12/08/20');
insert into individu values(9,'ASSADI','Melodi','0699946786','Evry','melodi.assadi@edu.devinci.fr',1,'09/04/17');
insert into individu values(10,'FAYETTE','Pierre-Marie','069906786','Pontoise','pierremarie.fayette@edu.devinci.fr',2,'15/06/19');

insert into entreprise values('Decathlon','0696459653','La Defense','decathlon@gmail.com','0777430089',16,20);
insert into entreprise values('Sport2000','0696879653','La Defense','sport2000@gmail.com','0777430189',8,10);
insert into entreprise values('Courir','0696450553','Courbevoie','courir@gmail.com','0777430289',18,22);
insert into entreprise values('FootLocker','0694359653','Neuilly','footlocker@gmail.com','0777430389',4,5);
insert into entreprise values('GoSport','0096459653','Saint-Denis','gosport@gmail.com','0770435689',13,17);

insert into commande values(34, '16/11/18','16/12/18','Courbevoie',null,1);
insert into commande values(56, '18/05/18','18/06/18','Champs-sur-Marne','Decathlon',null);
insert into commande values(79, '20/01/19','20/02/19','Ormesson','Sport2000',null);
insert into commande values(88, '02/04/20','02/05/20','Saint-Denis',null,8);
insert into commande values(92, '22/12/21','22/01/22','Neuilly',null,10);

insert into piece values('C32','cadres',100,2,1,7);
insert into piece values('C34','cadres',110,2,10,7);
insert into piece values('C76','cadres',120,2,10,7);
insert into piece values('C43','cadres',130,2,10,7);
insert into piece values('C44f','cadres',140,2,10,7);
insert into piece values('C43f','cadres',160,2,10,7);
insert into piece values('C01','cadres',170,2,10,7);
insert into piece values('C02','cadres',180,2,10,7);
insert into piece values('C15','cadres',190,2,10,7);
insert into piece values('C87','cadres',101,2,10,7);
insert into piece values('C87f','cadres',102,2,10,7);
insert into piece values('C25','cadres',103,2,10,7);
insert into piece values('C26','cadres',104,2,10,7);
insert into piece values('G7','guidon',200,3,0,6);
insert into piece values('G9','guidon',210,3,20,6);
insert into piece values('G12','guidon',230,3,20,6);
insert into piece values('F3','freins',300,2,30,5);
insert into piece values('F9','freins',310,2,30,5);
insert into piece values('S88','selle',400,4,10,7);
insert into piece values('S37','selle',410,4,10,7);
insert into piece values('S35','selle',420,4,10,7);
insert into piece values('S02','selle',430,4,2,7);
insert into piece values('S03','selle',440,4,10,7);
insert into piece values('S36','selle',450,4,10,7);
insert into piece values('S34','selle',460,4,10,7);
insert into piece values('S87','selle',470,4,2,7);
insert into piece values('DV133','dérailleur avant',500,1,20,6);
insert into piece values('DV17','dérailleur avant',510,1,20,6);
insert into piece values('DV87','dérailleur avant',520,1,20,6);
insert into piece values('DV57','dérailleur avant',530,1,20,6);
insert into piece values('DV15','dérailleur avant',540,1,20,6);
insert into piece values('DV41','dérailleur avant',550,1,20,6);
insert into piece values('DV132','dérailleur avant',560,1,2,6);
insert into piece values('DR56','dérailleur arrière',600,4,30,5);
insert into piece values('DR87','dérailleur arrière',610,4,30,5);
insert into piece values('DR86','dérailleur arrière',620,4,30,5);
insert into piece values('DR23','dérailleur arrière',640,4,1,5);
insert into piece values('DR76','dérailleur arrière',650,4,30,5);
insert into piece values('DR52','dérailleur arrière',670,1,10,10);
insert into piece values('R45','roue avant',700,2,20,11);
insert into piece values('R48','roue avant',710,2,20,11);
insert into piece values('R12','roue avant / roue arrière',720,2,2,11);
insert into piece values('R19','roue avant',730,2,20,11);
insert into piece values('R1','roue avant',740,2,20,11);
insert into piece values('R44','roue avant',750,2,20,11);
insert into piece values('R11','roue avant',760,2,0,11);
insert into piece values('R46','roue arrière',800,2,20,11);
insert into piece values('R47','roue arrière',810,2,20,11);
insert into piece values('R32','roue arrière',820,2,2,11);
insert into piece values('R18','roue arrière',830,2,20,11);
insert into piece values('R2','roue arrière',840,2,20,11);
insert into piece values('R02','réflecteur',870,3,30,12);
insert into piece values('R09','réflecteur',880,3,2,12);
insert into piece values('R10','réflecteur',890,3,30,12);
insert into piece values('P12','pédalier',900,2,10,10);
insert into piece values('P34','pédalier',910,2,10,10);
insert into piece values('P1','pédalier',920,2,10,10);
insert into piece values('P15','pédalier',930,2,10,10);
insert into piece values('O2','odinateur',1000,1,20,11);
insert into piece values('O4','odinateur',1010,1,2,11);
insert into piece values('S01','panier',1100,4,30,12);
insert into piece values('S05','panier',1110,4,30,12);
insert into piece values('S74','panier',1120,4,30,12);
insert into piece values('S73','panier',1130,4,2,12);

insert into contenu_modele values(4,101,34);
insert into contenu_modele values(2,101,88);
insert into contenu_modele values(1,114,92);
insert into contenu_modele values(3,115,56);
insert into contenu_modele values(4,110,79);

insert into production values('10/11/18','10/11/20','C32','123 456 789 00011');
insert into production values('10/11/18','10/11/20','C34','123 456 789 00011'); 
insert into production values('10/11/18','10/11/20','C76','123 456 789 00011'); 
insert into production values('10/11/18','10/11/20','C43','123 456 789 00011'); 
insert into production values('10/11/18','10/11/20','C44f','123 456 789 00011'); 
insert into production values('10/11/18','10/11/20','C43f','123 456 789 00011'); 
insert into production values('10/11/18','10/11/20','C01','123 456 789 00011'); 
insert into production values('10/11/18','10/11/20','C02','123 456 789 00011'); 
insert into production values('10/11/18','10/11/20','C15','123 456 789 00011'); 
insert into production values('10/11/18','10/11/20','C26','123 456 789 00011'); 
insert into production values('10/11/18','10/11/20','C87','123 456 789 00011');
insert into production values('10/11/18','10/11/20','C25','123 456 789 00011');
insert into production values('10/12/18','10/12/20','C87f','122 456 799 00009');
insert into production values('10/12/18','10/12/20','G7','122 456 799 00009');
insert into production values('10/12/18','10/12/20','G9','122 456 799 00009'); 
insert into production values('10/12/18','10/12/20','G12','173 459 789 00056');
insert into production values('10/01/18','10/01/20','F3','173 459 789 00056');
insert into production values('10/01/18','10/01/20','F9','173 459 789 00056');
insert into production values('10/05/18','10/05/20','S35','123 450 787 00067');
insert into production values('10/05/18','10/05/20','S88','123 450 787 00067');
insert into production values('10/05/18','10/05/20','S37','123 450 787 00067');
insert into production values('10/05/18','10/05/20','S02','123 450 787 00067');
insert into production values('10/05/18','10/05/20','S03','123 450 787 00067');
insert into production values('10/05/18','10/05/20','S36','123 450 787 00067');
insert into production values('10/05/18','10/05/20','S34','123 450 787 00067');
insert into production values('10/05/18','10/05/20','S87','123 450 787 00067');
insert into production values('10/12/18','10/12/20','DV133','123 456 789 00011');
insert into production values('10/12/18','10/12/20','DV17','123 456 789 00011');
insert into production values('10/12/18','10/12/20','DV87','123 456 789 00011');
insert into production values('10/12/18','10/12/20','DV15','123 456 789 00011');
insert into production values('10/12/18','10/12/20','DV41','123 456 789 00011');
insert into production values('10/12/18','10/12/20','DV132','123 456 789 00011');
insert into production values('10/06/19','10/06/21','DV17','122 456 799 00009');
insert into production values('10/06/19','10/06/21','DR56','122 456 799 00009');
insert into production values('10/06/19','10/06/21','DR87','122 456 799 00009');
insert into production values('10/06/19','10/06/21','DR86','122 456 799 00009');
insert into production values('10/06/19','10/06/21','DR23','122 456 799 00009');
insert into production values('10/06/19','10/06/21','DR76','122 456 799 00009');
insert into production values('10/06/19','10/06/21','DR52','122 456 799 00009');
insert into production values('10/12/19','10/12/21','R45','173 459 789 00056');
insert into production values('10/12/19','10/12/21','R48','173 459 789 00056');
insert into production values('10/12/19','10/12/21','R12','173 459 789 00056');
insert into production values('10/12/19','10/12/21','R19','173 459 789 00056');
insert into production values('10/12/19','10/12/21','R1','173 459 789 00056');
insert into production values('10/12/19','10/12/21','R44','173 459 789 00056');
insert into production values('10/12/19','10/12/21','R11','173 459 789 00056');
insert into production values('10/07/19','10/07/21','R46','123 450 787 00067');
insert into production values('10/07/19','10/07/21','R47','123 450 787 00067');
insert into production values('10/07/19','10/07/21','R32','123 450 787 00067');
insert into production values('10/07/19','10/07/21','R18','123 450 787 00067');
insert into production values('10/07/19','10/07/21','R2','123 450 787 00067');
insert into production values('10/04/19','10/04/21','R02','123 456 789 00011');
insert into production values('10/04/19','10/04/21','R09','123 456 789 00011');
insert into production values('10/04/19','10/04/21','R10','123 456 789 00011');
insert into production values('10/01/21','10/01/22','P12','122 456 799 00009');
insert into production values('10/01/21','10/01/22','P34','122 456 799 00009');
insert into production values('10/01/21','10/01/22','P1','122 456 799 00009');
insert into production values('10/01/21','10/01/22','P15','122 456 799 00009');
insert into production values('10/08/20','10/08/22','O2','173 459 789 00056');
insert into production values('10/08/20','10/08/22','O4','173 459 789 00056');
insert into production values('10/11/20','10/11/22','S01','123 450 787 00067');
insert into production values('10/11/20','10/11/22','S05','123 450 787 00067');
insert into production values('10/11/20','10/11/22','S74','123 450 787 00067');
insert into production values('10/11/20','10/11/22','S73','123 450 787 00067');

insert into contenu_piece values(4,'C32',34);
insert into contenu_piece values(6,'F3',88);
insert into contenu_piece values(4,'S73',92);
insert into contenu_piece values(3,'C25',56);
insert into contenu_piece values(6,'C26',79);


insert into livraison values('C32','123 456 789 00011');
insert into livraison values('C34','123 456 789 00011'); 
insert into livraison values('C76','123 456 789 00011'); 
insert into livraison values('C43','123 456 789 00011'); 
insert into livraison values('C44f','123 456 789 00011'); 
insert into livraison values('C43f','123 456 789 00011'); 
insert into livraison values('C01','123 456 789 00011'); 
insert into livraison values('C02','123 456 789 00011'); 
insert into livraison values('C15','123 456 789 00011'); 
insert into livraison values('C26','123 456 789 00011'); 
insert into livraison values('C87','123 456 789 00011');
insert into livraison values('C25','123 456 789 00011');
insert into livraison values('C87f','122 456 799 00009');
insert into livraison values('G7','122 456 799 00009');
insert into livraison values('G9','122 456 799 00009'); 
insert into livraison values('G12','173 459 789 00056');
insert into livraison values('F3','173 459 789 00056');
insert into livraison values('F9','173 459 789 00056');
insert into livraison values('S35','123 450 787 00067');
insert into livraison values('S88','123 450 787 00067');
insert into livraison values('S37','123 450 787 00067');
insert into livraison values('S02','123 450 787 00067');
insert into livraison values('S03','123 450 787 00067');
insert into livraison values('S36','123 450 787 00067');
insert into livraison values('S34','123 450 787 00067');
insert into livraison values('S87','123 450 787 00067');
insert into livraison values('DV133','123 456 789 00011');
insert into livraison values('DV17','123 456 789 00011');
insert into livraison values('DV87','123 456 789 00011');
insert into livraison values('DV15','123 456 789 00011');
insert into livraison values('DV41','123 456 789 00011');
insert into livraison values('DV132','123 456 789 00011');
insert into livraison values('DV17','122 456 799 00009');
insert into livraison values('DR56','122 456 799 00009');
insert into livraison values('DR87','122 456 799 00009');
insert into livraison values('DR86','122 456 799 00009');
insert into livraison values('DR23','122 456 799 00009');
insert into livraison values('DR76','122 456 799 00009');
insert into livraison values('DR52','122 456 799 00009');
insert into livraison values('R45','173 459 789 00056');
insert into livraison values('R48','173 459 789 00056');
insert into livraison values('R12','173 459 789 00056');
insert into livraison values('R19','173 459 789 00056');
insert into livraison values('R1','173 459 789 00056');
insert into livraison values('R44','173 459 789 00056');
insert into livraison values('R11','173 459 789 00056');
insert into livraison values('R46','123 450 787 00067');
insert into livraison values('R47','123 450 787 00067');
insert into livraison values('R32','123 450 787 00067');
insert into livraison values('R18','123 450 787 00067');
insert into livraison values('R2','123 450 787 00067');
insert into livraison values('R02','123 456 789 00011');
insert into livraison values('R09','123 456 789 00011');
insert into livraison values('R10','123 456 789 00011');
insert into livraison values('P12','122 456 799 00009');
insert into livraison values('P34','122 456 799 00009');
insert into livraison values('P1','122 456 799 00009');
insert into livraison values('P15','122 456 799 00009');
insert into livraison values('O2','173 459 789 00056');
insert into livraison values('O4','173 459 789 00056');
insert into livraison values('S01','123 450 787 00067');
insert into livraison values('S05','123 450 787 00067');
insert into livraison values('S74','123 450 787 00067');
insert into livraison values('S73','123 450 787 00067');


-- Kilimandjaro	Adultes	C32	G7	F3	S88	DV133	DR56	R45	R46		P12	O2	
insert into assemblage values(101,'C32');
insert into assemblage values(101,'G7');
insert into assemblage values(101,'F3');
insert into assemblage values(101,'S88');
insert into assemblage values(101,'DV133');
insert into assemblage values(101,'DR56');
insert into assemblage values(101,'R45');
insert into assemblage values(101,'R46');
insert into assemblage values(101,'P12');
insert into assemblage values(101,'O2');

-- NorthPole	Adultes	C34	G7	F3	S88	DV17	DR87	R48	R47		P12		
insert into assemblage values(102,'C34');
insert into assemblage values(102,'G7');
insert into assemblage values(102,'F3');
insert into assemblage values(102,'S88');
insert into assemblage values(102,'DV17');
insert into assemblage values(102,'DR87');
insert into assemblage values(102,'R48');
insert into assemblage values(102,'R47');
insert into assemblage values(102,'P12');
-- MontBlanc	Jeunes	C76	G7	F3	S88	DV17	DR87	R48	R47		P12	O2	
insert into assemblage values(103,'G7');
insert into assemblage values(103,'F3');
insert into assemblage values(103,'S88');
insert into assemblage values(103,'DV17');
insert into assemblage values(103,'DR87');
insert into assemblage values(103,'R48');
insert into assemblage values(103,'R47');
insert into assemblage values(103,'P12');
insert into assemblage values(103,'O2');
-- Hooligan	Jeunes	C76	G7	F3	S88	DV87	DR86	R12	R32		P12		
insert into assemblage values(104,'C76');
insert into assemblage values(104,'G7');
insert into assemblage values(104,'F3');
insert into assemblage values(104,'S88');
insert into assemblage values(104,'DV87');
insert into assemblage values(104,'DR86');
insert into assemblage values(104,'R12');
insert into assemblage values(104,'R32');
insert into assemblage values(104,'P12');
-- Orléans	Hommes	C43	G9	F9	S37	DV57	DR86	R19	R18	R02	P34		
insert into assemblage values(105,'C43');
insert into assemblage values(105,'G9');
insert into assemblage values(105,'F9');
insert into assemblage values(105,'S37');
insert into assemblage values(105,'DV57');
insert into assemblage values(105,'DR86');
insert into assemblage values(105,'R19');
insert into assemblage values(105,'R18');
insert into assemblage values(105,'R02');
insert into assemblage values(105,'P34');
-- Orléans	Dames	C44f	G9	F9	S35	DV57	DR86	R19	R18	R02	P34		
insert into assemblage values(106,'C44f');
insert into assemblage values(106,'G9');
insert into assemblage values(106,'F9');
insert into assemblage values(106,'S35');
insert into assemblage values(106,'DV57');
insert into assemblage values(106,'DR86');
insert into assemblage values(106,'R19');
insert into assemblage values(106,'R18');
insert into assemblage values(106,'R02');
insert into assemblage values(106,'P34');
-- BlueJay	Hommes	C43	G9	F9	S37	DV57	DR87	R19	R18	R02	P34	O4
insert into assemblage values(107,'C43');
insert into assemblage values(107,'G9');
insert into assemblage values(107,'F9');
insert into assemblage values(107,'S37');
insert into assemblage values(107,'DV57');
insert into assemblage values(107,'DR87');
insert into assemblage values(107,'R19');
insert into assemblage values(107,'R18');
insert into assemblage values(107,'R02');
insert into assemblage values(107,'P34');
insert into assemblage values(107,'O4');
-- BlueJay	Dames	C43f	G9	F9	S35	DV57	DR87	R19	R18	R02	P34	O4
insert into assemblage values(108,'C43f');	
insert into assemblage values(108,'G9');
insert into assemblage values(108,'F9');	
insert into assemblage values(108,'S35');	
insert into assemblage values(108,'DV57');	
insert into assemblage values(108,'DR87');	
insert into assemblage values(108,'R19');	
insert into assemblage values(108,'R18');	
insert into assemblage values(108,'R02');	
insert into assemblage values(108,'P34');	
insert into assemblage values(108,'O4');	
-- Trail Explorer	Filles	C01	G12		S02			R1	R2	R09	P1		S01
insert into assemblage values(109,'C01');
insert into assemblage values(109,'G12');
insert into assemblage values(109,'S02');
insert into assemblage values(109,'R1');
insert into assemblage values(109,'R2');
insert into assemblage values(109,'R09');
insert into assemblage values(109,'P1');
insert into assemblage values(109,'S01');
-- Trail Explorer	Garçons	C02	G12		S03			R1	R2	R09	P1		S05
insert into assemblage values(110,'C02');
insert into assemblage values(110,'G12');
insert into assemblage values(110,'S03');
insert into assemblage values(110,'R1');
insert into assemblage values(110,'R2');
insert into assemblage values(110,'R09');
insert into assemblage values(110,'P1');
insert into assemblage values(110,'S05');
-- Night Hawk	Jeunes	C15	G12	F9	S36	DV15	DR23	R11	R12	R10	P15		S74
insert into assemblage values(111,'C15');
insert into assemblage values(111,'G12');
insert into assemblage values(111,'F9');
insert into assemblage values(111,'S36');
insert into assemblage values(111,'DV15');
insert into assemblage values(111,'DR23');
insert into assemblage values(111,'R11');
insert into assemblage values(111,'R12');
insert into assemblage values(111,'R10');
insert into assemblage values(111,'P15');
insert into assemblage values(111,'S74');
-- Tierra Verde	Hommes	C87	G12	F9	S36	DV41	DR76	R11	R12	R10	P15		S74
insert into assemblage values(112,'C87');
insert into assemblage values(112,'G12');
insert into assemblage values(112,'F9');
insert into assemblage values(112,'S36');
insert into assemblage values(112,'DV41');
insert into assemblage values(112,'DR76');
insert into assemblage values(112,'R11');
insert into assemblage values(112,'R12');
insert into assemblage values(112,'R10');
insert into assemblage values(112,'P15');
insert into assemblage values(112,'S74');
-- Tierra Verde	Dames	C87f	G12	F9	S34	DV41	DR76	R11	R12	R10	P15		S73
insert into assemblage values(113,'C87f');
insert into assemblage values(113,'G12');
insert into assemblage values(113,'F9');
insert into assemblage values(113,'S34');
insert into assemblage values(113,'DV41');
insert into assemblage values(113,'DR76');
insert into assemblage values(113,'R11');
insert into assemblage values(113,'R12');
insert into assemblage values(113,'R10');
insert into assemblage values(113,'P15');
insert into assemblage values(113,'S73');
-- Mud Zinger I	Jeunes	C25	G7	F3	S87	DV132	DR52	R44	R47		P12
insert into assemblage values(114,'C25');	
insert into assemblage values(114,'G7');
insert into assemblage values(114,'F3');
insert into assemblage values(114,'S87');
insert into assemblage values(114,'DV132');
insert into assemblage values(114,'DR52');
insert into assemblage values(114,'R44');
insert into assemblage values(114,'R47');
insert into assemblage values(114,'P12');
-- Mud Zinger II	Adultes	C26	G7	F3	S87	DV133	DR52	R44	R47		P12
insert into assemblage values(115,'C26');
insert into assemblage values(115,'G7');
insert into assemblage values(115,'F3');
insert into assemblage values(115,'S87');
insert into assemblage values(115,'DV133');
insert into assemblage values(115,'DR52');
insert into assemblage values(115,'R44');
insert into assemblage values(115,'R47');
insert into assemblage values(115,'P12');
	

select nomI,sum(prixP*quantiteP),sum(prix*quantiteM)from individu natural join contenu_piece 
natural join piece 
natural join commande 
natural join modele
natural join contenu_modele
group by numC;
    
select nomE,sum(prixP*quantiteP),sum(prix*quantiteM)from entreprise natural join contenu_piece 
natural join piece 
natural join commande 
natural join modele
natural join contenu_modele
group by numC;


    
    
    
select * from modele where stockM<=2;

select * from piece where stock<=2;







-- 1.	Produire un rapport statistique présentant les quantités 
-- vendues de chaque item  qui se trouve dans l’inventaire de VéloMax.
select distinct numM,nomVelo,sum(quantiteM),numM from contenu_modele natural join modele group by  numM;
select distinct numP,sum(quantiteP),descriptionP from contenu_piece  natural join piece  group by  numP;

-- 2.	Produire la liste des membres pour chaque programme d’adhésion.
select id,nomI,prenom,descriptionf from individu i join fidelio f on f.numero=i.numero order by descriptionf;

-- 3.	Affichez également la date d’expiration des adhésions # A faire sur C#
select date_adhesion ,id, duree from individu natural join fidelio where date_adhesion is not null;


-- 4.	Retrouvez-le (ou les) meilleur client en fonction
-- des quantités vendues en nombre de pièces vendues ou en cumul en euros
select nomE,volume_achat from entreprise order by volume_achat desc; 

select nomI,prenom,sum(quantiteP) from individu natural join commande natural join contenu_piece group by id
order by sum(quantiteP) desc;

select nomI,prenom,sum(quantiteP) from individu natural join commande natural join contenu_piece group by id
order by sum(quantiteP) desc;

#select nomI,prenom,sum(quantiteP) * prixP,sum(quantiteP)from individu natural join commande natural join contenu_piece  natural join piece group by id
#where sum(quantiteP*PrixP) in (select(max(sum(quantiteP*PrixP) from commande natural join contenu_piece  natural join piece); order by sum(quantiteP) 

	select nomI,prenom,sum(quantiteP*prixP) 
	from individu natural join commande 
	natural join contenu_piece  
	natural join piece group by id order by sum(quantiteP*prixP) desc;

select nomI,prenom,sum(quantiteP*prixP) 
from individu i join commande c on c.id=i.id 
join contenu_piece cp on cp.numC=c.numC
join piece p on p.numP=cp.numP
group by i.id order by sum(quantiteP*prixP) desc;

select nomI,prenom,sum(quantiteM*prix) 
from individu natural join commande 
natural join contenu_modele natural join modele group by id order by sum(quantiteM*prix) desc;

use velomax;
select numP,sum(stock) from piece group by numP;

select siret,stockF from fournisseur;

select ligne,sum(stockM) from modele group by ligne;

select numP,stock from piece;

select nomVelo,sum(stockM) from modele group by nomVelo;

select grandeur,sum(stockM) from modele group by grandeur;

select nomI,prenom,sum(quantiteM) from individu natural join commande 
natural join contenu_modele group by id order by sum(quantiteM) desc;
 
-- 5.	Faîtes une analyse des commandes : moyenne des montants des
--  commandes, moyenne du nombre de pièces ou de vélos par commande.
use velomax;
delete from individu where id=12;

select  nomE,id, sum(prixP*quantiteP),sum(prix*quantiteM) from modele natural join piece
natural join commande natural join contenu_modele natural join contenu_piece group by nomE,id;

select * from individu;
select nomE, sum(prixP * quantiteP) from entreprise natural join contenu_piece
natural join piece natural join commande natural join modele natural join contenu_modele group by numC;


#Noms des clients avec le cumul de toutes ses commandes en euros
select nom,prenom,sum(quantiteP*quantiteP) from individu ;

#5) Nombres de pièces et/ou vélos fournis par fournisseur. 

# Noms des clients avec le cumul de toutes ses commandes en euros Thessa
select nomE, sum(prixP * quantiteP), sum(prix * quantiteM)from entreprise natural join contenu_piece
natural join piece natural join commande natural join modele natural join contenu_modele group by numC;


select nomE,sum(prixP*quantiteP) from entreprise natural join commande natural join contenu_piece;

select id,sum(prix) from commande natural join individu natural join contenu_modele natural join modele group by id;

select nomF,count(*),siret from livraison natural join fournisseur group by siret;
use velomax;
select * from individu;