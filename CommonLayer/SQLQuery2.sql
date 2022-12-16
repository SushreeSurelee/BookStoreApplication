--Create table UserTable(        
--    UserId int IDENTITY(1,1) primary key NOT NULL,        
--    FullName varchar(200) NOT NULL,        
--    EmailId varchar(200) NOT NULL,        
--    Password varchar(200) NOT NULL,        
--    MobileNumber varchar(200) NOT NULL        
--);


--Create procedure spAddUserData         
--(        
--    @FullName varchar(200),         
--    @EmailId varchar(200),        
--    @Password varchar(200),        
--    @MobileNumber varchar(200)        
--)        
--as         
--Begin         
--    Insert into UserTable (FullName,EmailId,Password, MobileNumber)         
--    Values (@FullName,@EmailId,@Password, @MobileNumber)         
--End 


--alter procedure spUserLogin         
--(                
--    @EmailId varchar(200),        
--    @Password varchar(200)     
--)        
--as         
--Begin         
--    select UserId,EmailId,Password from UserTable where  EmailId=@EmailId and Password=@Password
--End 


--alter procedure spforgetPW       
--( 
    
--    @EmailId varchar(200)    
--)        
--as         
--Begin         
--    select UserId,EmailId from UserTable where  EmailId=@EmailId
--End 


--Create procedure spResetPW          
--(     
--   @EmailId varchar(200),
--   @Password varchar(200)
--)          
--as          
--begin          
--   Update UserTable           
--   set Password=@Password                    
--   where EmailId=@EmailId          
--End

--create procedure spAdminLogin         
--(                
--    @EmailId varchar(200),        
--    @Password varchar(200)     
--)        
--as         
--Begin         
--    select UserId,EmailId,Password from UserTable where  EmailId=@EmailId and Password=@Password
--End 


--Create table BooksTable(        
--    BookId int IDENTITY(1,1) primary key NOT NULL,        
--    BookName varchar(200),        
--    Author varchar(200),        
--    BookImage varchar(200),        
--    BookRating varchar(200),
--    RatingCount varchar(200),
--    DiscountPrice varchar(200),
--    ActualPrice varchar(200),
--    BookDetail varchar(200),
--    Quantity int
--);



--Alter procedure spAddBookData         
--(        
--    @BookName varchar(200),        
--    @Author varchar(200),        
--    @BookImage varchar(200),        
--    @BookRating varchar(200),
--    @RatingCount varchar(200),
--    @DiscountPrice varchar(200),
--    @ActualPrice varchar(200),
--    @BookDetail varchar(200),
--    @Quantity int
--)        
--as         
--Begin         
--    Insert into BooksTable (BookName,Author,BookImage,BookRating,RatingCount,DiscountPrice,ActualPrice,BookDetail,Quantity)         
--    Values (@BookName,@Author,@BookImage,@BookRating,@RatingCount,@DiscountPrice,@ActualPrice,@BookDetail,@Quantity)         
--End 

--alter procedure spGetAllBooks      
--as      
--Begin      
--    select *      
--    from BooksTable      
--End

--alter procedure spgetbookbyid
--(
--    @bookid int
--)
--as      
--begin      
--    select *      
--    from BooksTable where bookid=@bookid     
--end

--alter procedure spUpdateBook         
--(     
--    @BookId int,
--    @BookName varchar(200),        
--    @Author varchar(200),        
--    @BookImage varchar(200),        
--    @BookRating varchar(200),
--    @RatingCount varchar(200),
--    @DiscountPrice varchar(200),
--    @ActualPrice varchar(200),
--    @BookDetail varchar(200),
--    @Quantity int
--)          
--as          
--begin          
--   Update BooksTable           
--   set BookName=@BookName,
--   Author=@Author,
--   BookImage=@BookImage,
--   BookRating=@BookRating,
--   RatingCount=@RatingCount,
--   DiscountPrice=@DiscountPrice,
--   ActualPrice=@ActualPrice,
--   BookDetail=@BookDetail,
--   Quantity=@Quantity
--   WHERE BookId=@BookId
--End

--create procedure spDeleteBook
--(
--     @bookid int
--)
--as
--BEGIN
--    delete from BooksTable where bookid=@bookid 
--end

--create table CartsTable(
--	CartId int identity (1,1) primary key,
--	CartQuantity int default 1,
--	UserId int not null foreign key (UserId) references UserTable(UserId),
--	BookId int not null foreign key (BookId) references BooksTable(BookId)
--	)

--alter procedure spAddToCart
--(
--    @CartQuantity int,
--	@UserId int,
--	@BookId int
--)
--as
--BEGIN
--IF (NOT EXISTS(SELECT * FROM CartsTable WHERE BookId = @BookId and UserId=@UserId))
--		begin
--		insert into CartsTable
--		values(@CartQuantity, @UserId, @BookId);
--		end
--end

--alter procedure spUpdateCart
--(
--	@CartId int,
--	@CartQuantity int
--)
--as
--BEGIN
--	update CartsTable set CartQuantity = @CartQuantity where CartId = @CartId;
--END 

--alter procedure spDeleteCart
--(
--	@CartId int
--)
--as
--BEGIN
--	delete from CartsTable where CartId = @CartId;
--END

--alter procedure spgetallcart 
--(
--    @UserId int
--)
--as      
--begin      
--    select 
--        c.CartId,
--		c.BookId,
--		c.UserId,
--		c.CartQuantity,
--		b.BookName,
--		b.BookImage,
--		b.Author,
--		b.DiscountPrice,
--		b.ActualPrice,
--		b.Quantity
--    from CartsTable c
--	inner join BooksTable b
--	on c.BookId=b.BookId
--	where c.UserId=@UserId;
--end

--create table WishList(
--	WishListId int identity (1,1) primary key,
--	UserId int not null foreign key (UserId) references UserTable(UserId),
--	BookId int not null foreign key (BookId) references BooksTable(BookId)
--	);


--create procedure spAddToWishList
--(
--	@UserId int,
--	@BookId int
--)
--as
--begin
--insert into WishList
--values( @UserId, @BookId);
--end

--alter procedure spGetAllWishlist 
--(
--    @UserId int
--)
--as      
--Begin      
--    select 
--        w.WishListId,
--		w.BookId,
--		w.UserId,
--		b.BookName,
--		b.BookImage,
--		b.Author,
--		b.DiscountPrice,
--		b.ActualPrice	
--    from WishList w
--    inner join BooksTable b
--    on w.BookId=b.BookId
--    where w.UserId=@UserId;
--End

--create procedure spDeleteWishListItem
--(
--	@WishListId int
--)
--as
--BEGIN 
--	delete from WishList where WishListId = @WishListId;
--END 

-----------------ADDRESS---------------

--create table AddressType(
--	TypeId int identity (1,1) primary key,
--	Type varchar(200)
--	)

--insert into AddressType values ('Home');
--insert into AddressType values ('Work');
--insert into AddressType values ('Others');

--create table AddressTable(
--	AddressId int identity (1,1) primary key,
--	Address varchar(200) not null,
--	City varchar(200) not null,
--	State varchar(200) not null,
--	TypeId int not null foreign key (TypeId) references AddressType(TypeId),
--	UserId int not null foreign key (UserId) references UserTable(UserId)
--	);

--alter procedure spAddAddress
--(
--    @Address varchar(200),
--	@City varchar(200),
--	@State varchar(200),
--	@TypeId int,
--	@UserId int
--)
--as
--begin 
--	insert into AddressTable
--	values(@Address, @City, @State, @TypeId, @UserId);
--end

--create procedure spUpdateAddress(
--	@AddressId int,
--	@Address varchar(max),
--	@City varchar(100),
--	@State varchar(100),
--	@TypeId int,
--	@UserId int
--	)
--as
--begin
--	update AddressTable set
--	Address=@Address,City=@City,State=@State,TypeId=@TypeId where UserId=@UserId and AddressId=@AddressId;
--end

--create procedure spGetAllAddress(
--	@UserId int
--	)
--as
--begin
--	select * from AddressTable where UserId=@UserId;
--end

-----------------FEEDBACK---------------

--create table Feedback(
--	FeedbackId int identity (1,1) primary key,
--	BookRating float not null,
--	Comment varchar(max) not null,
--	BookId int not null foreign key (BookId) references BooksTable(BookId),
--	UserId int not null foreign key (UserId) references UserTable(UserId)
--	)

--create procedure spAddFeedback(
--	@BookRating float,
--	@Comment varchar(max),
--	@BookId int,
--	@UserId int
--	)
--as
--	declare @TotalRating float;
--begin
--	if(not exists(select * from Feedback where BookId=@BookId and UserId=@UserId))
--	begin
--		insert into Feedback values(@BookRating,@Comment,@BookId,@UserId);

--		select @TotalRating = avg(@BookRating) from BooksTable where BookId = @BookId;

--		Update BooksTable set BookRating = @TotalRating, RatingCount = (RatingCount+1) where BookId=@BookId;
--	end
--end

--alter procedure spGetFeedback(
--	@BookId int
--	)
--as
--begin
--	select Feedback.FeedbackId,Feedback.Comment,Feedback.BookId,Feedback.BookRating,Feedback.UserId,UserTable.FullName
--	from UserTable
--	inner join Feedback
--	on Feedback.UserId = UserTable.UserId where BookId=@BookId;
--end



-----------------ORDER---------------

--create table Orders(
--	OrderId int identity(1,1) primary key,
--	OrderQty int not null,
--	TotalPrice float not null,
--	OrderDate Date not null,
--	UserId INT NOT NULL FOREIGN KEY REFERENCES UserTable(UserId),
--	BookId INT NOT NULL FOREIGN KEY REFERENCES BooksTable(BookId),
--	AddressId int not null FOREIGN KEY REFERENCES AddressTable(AddressId)
--)

alter procedure spAddOrder(
	@UserId int,
	@BookId int,
	@AddressId int
	)
as
	declare @TotalPrice int;
	declare @OrderQty int;
begin
	set @TotalPrice = (select DiscountPrice from BooksTable where BookId = @BookId); 
	set @OrderQty = (select CartQuantity from CartsTable where BookId = @BookId); 
	if(exists(select * from BooksTable where BookId = @BookId))
	begin
				if((select Quantity from BooksTable where BookId = @BookId)>= @OrderQty)
				begin
					insert into Orders values(@OrderQty,@TotalPrice*@OrderQty,GETDATE(),@UserId,@BookId,@AddressId);
					update BooksTable set Quantity = (Quantity - @OrderQty) where BookId = @BookId;
					delete from CartsTable where BookId = @BookId and UserId = @UserId; 
				end
	end
end

--create procedure spGetAllOrders(
--	@UserId int
--	)
--as
--begin
--	select 
--		Orders.OrderId, Orders.UserId, Orders.AddressId, BooksTable.BookId,
--		Orders.TotalPrice, Orders.OrderQty, Orders.OrderDate,
--		BooksTable.BookName, BooksTable.Author, BooksTable.BookImage,BooksTable.DiscountPrice,BooksTable.ActualPrice
--		from BooksTable 
--		inner join Orders on Orders.BookId = BooksTable.BookId 
--		where Orders.UserId = @UserId; 
--end

--create procedure spRemoveOrder(
--	@OrderId int
--	)
--as
--begin
--	delete from Orders where OrderId=@OrderId;
--end


