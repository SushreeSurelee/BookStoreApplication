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

--create table CartTable(
--	CartId int identity (1,1) primary key,
--	Quantity int default 1,
--	UserId int not null foreign key (UserId) references UserTable(UserId),
--	BookId int not null foreign key (BookId) references BooksTable(BookId)
--	)

--create procedure spAddToCart
--(
--    @Quantity int,
--	@UserId int,
--	@BookId int
--)
--as
--BEGIN
--IF (NOT EXISTS(SELECT * FROM CartTable WHERE BookId = @BookId and UserId=@UserId))
--		begin
--		insert into CartTable
--		values(@Quantity, @UserId, @BookId);
--		end
--end

--create procedure spUpdateCart
--(
--	@CartId int,
--	@Quantity int
--)
--as
--BEGIN
--	update CartTable set Quantity = @Quantity where CartId = @CartId;
--END 

--create procedure spDeleteCart
--(
--	@CartId int
--)
--as
--BEGIN
--	delete from CartTable where CartId = @CartId;
--END

create procedure spGetAllCart 
(
    @UserId int
)
as      
Begin      
    select *      
    from CartTable where UserId=@UserId;
End