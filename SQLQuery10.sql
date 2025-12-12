CREATE TABLE sales_history (
    id INT PRIMARY KEY IDENTITY(1,1),
    prod_id INT,
    prod_name VARCHAR(MAX),
    qty INT,
    orig_price FLOAT,
    total_price FLOAT,
    order_date DATE,
    customer_id INT
);
