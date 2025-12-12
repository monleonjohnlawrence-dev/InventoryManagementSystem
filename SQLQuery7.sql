CREATE TABLE transactionData
(
    id INT PRIMARY KEY IDENTITY(1,1),
    customer_id INT NOT NULL,
    total_amount DECIMAL(10,2) NOT NULL,
    cash_paid DECIMAL(10,2) NOT NULL,
    change_amount DECIMAL(10,2) NOT NULL,
    transaction_date DATETIME DEFAULT GETDATE()
);
