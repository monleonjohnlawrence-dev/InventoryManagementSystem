CREATE TABLE transactionItems (
    id INT IDENTITY(1,1) PRIMARY KEY,
    transaction_id INT NOT NULL,
    prod_id INT NOT NULL,
    prod_name VARCHAR(MAX) NOT NULL,
    qty INT NOT NULL,
    orig_price DECIMAL(18,2) NOT NULL,
    total_price DECIMAL(18,2) NOT NULL,
    order_date DATETIME NULL
);
