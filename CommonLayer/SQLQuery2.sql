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

Create procedure spUserLogin         
(                
    @EmailId varchar(200),        
    @Password varchar(200)     
)        
as         
Begin         
    select EmailId,Password from UserTable where  EmailId=@EmailId and Password=@Password
End 