-- CREATE DATABASE BookStoreDB;
-- GO

-- USE BookStoreDB;
-- GO

-- CREATE TABLE Books
-- (
--     Id INT IDENTITY(1,1) PRIMARY KEY,
--     Title NVARCHAR(100),
--     Author NVARCHAR(100),
--     Price DECIMAL(10,2)
-- );

-- ADD BOOK

-- CREATE PROCEDURE sp_AddBook
--     @Title NVARCHAR(100),
--     @Author NVARCHAR(100),
--     @Price DECIMAL(10,2)
-- AS
-- BEGIN
--     INSERT INTO Books(Title, Author, Price)
--     VALUES(@Title,@Author,@Price)
-- END

--Update Book

-- CREATE PROCEDURE sp_UpdateBook
--     @Id INT,
--     @Title NVARCHAR(100),
--     @Author NVARCHAR(100),
--     @Price DECIMAL(10,2)
-- AS
-- BEGIN
--     UPDATE Books
--     SET Title=@Title,
--         Author=@Author,
--         Price=@Price
--     WHERE Id=@Id
-- END

--Delete Book

-- CREATE PROCEDURE sp_DeleteBook
--     @Id INT
-- AS
-- BEGIN
--     DELETE FROM Books
--     WHERE Id=@Id
-- END

-- USE BookStoreDB;

-- INSERT INTO Books(Title, Author, Price)
-- VALUES
-- ('Clean Code', 'Robert Martin', 599),
-- ('The Pragmatic Programmer', 'Andrew Hunt', 799);