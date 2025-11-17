IF OBJECT_ID('customers', 'U') IS NOT NULL
    DROP TABLE customers;
GO

CREATE TABLE customers
(
    id INT PRIMARY KEY IDENTITY(1,1),
    customer_id VARCHAR(MAX) NULL,
    total_price FLOAT NULL,
    amount FLOAT NULL,
    change_amount FLOAT NULL,
    order_date DATE NULL
);

SELECT * FROM customers;