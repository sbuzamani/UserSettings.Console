-- Question 1
-- Customers Table
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY AUTO_INCREMENT,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    Phone VARCHAR(20),
    AddressLine1 VARCHAR(100),
    AddressLine2 VARCHAR(100),
    City VARCHAR(50),
    State VARCHAR(50),
    ZipCode VARCHAR(10),
    Country VARCHAR(50),
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Merchants Table
CREATE TABLE Merchants (
    MerchantID INT PRIMARY KEY AUTO_INCREMENT,
    BusinessName VARCHAR(100) NOT NULL,
    ContactName VARCHAR(100),
    Email VARCHAR(100) UNIQUE NOT NULL,
    Phone VARCHAR(20),
    AddressLine1 VARCHAR(100),
    AddressLine2 VARCHAR(100),
    City VARCHAR(50),
    State VARCHAR(50),
    ZipCode VARCHAR(10),
    Country VARCHAR(50),
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Products Table
CREATE TABLE Products (
    ProductID INT PRIMARY KEY AUTO_INCREMENT,
    MerchantID INT NOT NULL,
    ProductName VARCHAR(100) NOT NULL,
    Description TEXT,
    Price DECIMAL(10, 2) NOT NULL,
    Stock INT DEFAULT 0,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (MerchantID) REFERENCES Merchants(MerchantID)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

-- Transactions Table
CREATE TABLE Transactions (
    TransactionID INT PRIMARY KEY AUTO_INCREMENT,
    CustomerID INT NOT NULL,
    MerchantID INT NOT NULL,
    TransactionDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    TotalAmount DECIMAL(10, 2) NOT NULL,
    Status ENUM('Pending', 'Completed', 'Failed', 'Refunded') DEFAULT 'Pending',
    PaymentMethod ENUM('Credit Card', 'Debit Card', 'Zapper','SnapScan') NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
        ON DELETE SET NULL
        ON UPDATE CASCADE,
    FOREIGN KEY (MerchantID) REFERENCES Merchants(MerchantID)
        ON DELETE SET NULL
        ON UPDATE CASCADE
);

-- Transaction_Items Table
CREATE TABLE Transaction_Items (
    TransactionItemID INT PRIMARY KEY AUTO_INCREMENT,
    TransactionID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL DEFAULT 1,
    UnitPrice DECIMAL(10, 2) NOT NULL,
    TotalPrice DECIMAL(10, 2) AS (Quantity * UnitPrice) STORED,
    FOREIGN KEY (TransactionID) REFERENCES Transactions(TransactionID)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
        ON DELETE SET NULL
        ON UPDATE CASCADE
);

-- Payments Table (Optional)
CREATE TABLE Payments (
    PaymentID INT PRIMARY KEY AUTO_INCREMENT,
    TransactionID INT NOT NULL,
    PaymentDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    Amount DECIMAL(10, 2) NOT NULL,
    PaymentStatus ENUM('Pending', 'Completed', 'Failed') DEFAULT 'Pending',
    TransactionReference VARCHAR(100),
    FOREIGN KEY (TransactionID) REFERENCES Transactions(TransactionID)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);
