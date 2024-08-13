CREATE DATABASE QuanLy;
USE QuanLy;

CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    BirthDate DATE NULL,
    Gender CHAR(1) NULL,  -- 'M' cho Nam, 'F' cho Nữ, hoặc 'O' cho Khác
    Height DECIMAL(5,2) NULL,  -- Chiều cao tính bằng mét
    Weight DECIMAL(5,2) NULL  -- Cân nặng tính bằng kg
);



CREATE TABLE HealthStats (
    StatId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    Date DATE NOT NULL,
    Steps INT NOT NULL,
    WaterIntake DECIMAL(5,2) NOT NULL, -- Lượng nước tính bằng lít
    SleepDuration DECIMAL(4,2) NOT NULL, -- Thời gian ngủ tính bằng giờ
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

-- Chèn dữ liệu mẫu vào bảng Users
INSERT INTO Users (Username, Password, Email, BirthDate, Gender, Height, Weight)
VALUES 
('user1', 'password1', 'user1@example.com', '1990-01-01', 'M', 1.75, 70.0),
('user2', 'password2', 'user2@example.com', '1992-02-02', 'F', 1.65, 60.0),
('user3', 'password3', 'user3@example.com', '1993-03-03', 'M', 1.80, 75.0),
('user4', 'password4', 'user4@example.com', '1994-04-04', 'F', 1.60, 55.0),
('user5', 'password5', 'user5@example.com', '1995-05-05', 'M', 1.85, 80.0),
('user6', 'password6', 'user6@example.com', '1996-06-06', 'F', 1.70, 65.0),
('user7', 'password7', 'user7@example.com', '1997-07-07', 'M', 1.78, 72.0),
('user8', 'password8', 'user8@example.com', '1998-08-08', 'F', 1.68, 62.0),
('user9', 'password9', 'user9@example.com', '1999-09-09', 'M', 1.82, 78.0),
('user10', 'password10', 'user10@example.com', '2000-10-10', 'F', 1.75, 67.0);


