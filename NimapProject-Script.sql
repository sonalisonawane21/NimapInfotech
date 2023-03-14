create table Category(
categoryID int primary key identity(1,1),
categoryName varchar(20) not null
)

create table product(
productID int primary key identity(1,1),
productName varchar(40),
categoryID int,
constraint pk_fk_catprod foreign key(categoryID) references category(categoryID)
)
select * from product
select * from Category
