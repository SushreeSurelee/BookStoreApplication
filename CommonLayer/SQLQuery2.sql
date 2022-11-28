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

--Create table BookTable(        
--    BookId int IDENTITY(1,1) primary key NOT NULL,        
--    BookName varchar(200),        
--    Author varchar(200),        
--    BookImage varchar(200),        
--    BookRating varchar(200),
--    RatingCount varchar(200),
--    DiscountPrice varchar(200),
--    ActualPrice varchar(200),
--    BookDetail varchar(200),
--    UserId int FOREIGN KEY REFERENCES UserTable(UserId)
--);

--ALTER TABLE BookTable
--DROP COLUMN UserId;

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
--    @UserId int
--)        
--as         
--Begin         
--    Insert into BookTable (BookName,Author,BookImage,BookRating,RatingCount,DiscountPrice,ActualPrice,BookDetail)         
--    Values (@BookName,@Author,@BookImage,@BookRating,@RatingCount,@DiscountPrice,@ActualPrice,@BookDetail)         
--End 

Create procedure spGetAllBooks      
as      
Begin      
    select *      
    from BookTable      
End

--select * from UserTable