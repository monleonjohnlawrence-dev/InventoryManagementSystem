CREATE TABLE customers 
(
	id INT PRIMARY KEY IDENTITY(1,1),
	customer_id VARCHAR(MAX) NULL,
	prod_id VARCHAR(MAX) NULL,
	prod_name VARCHAR(MAX) NULL,
	qty INT NULL,	
	orig_price FLOAT NULL,
	total_price VARCHAR(MAX) NULL,
	order_date DATE NULL
);

SELECT * FROM customers;
TRUNCATE TABLE customers;

ALTER TABLE customers

DROP TABLE IF EXISTS customers;

CREATE TABLE customers 
(
	id INT PRIMARY KEY IDENTITY(1,1),
	customer_id VARCHAR(MAX) NULL,
	total_price FLOAT NULL,
	amount FLOAT NULL,
	change_amount FLOAT NULL,
	order_date DATE NULL
);
