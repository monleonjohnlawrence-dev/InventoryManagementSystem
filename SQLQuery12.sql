-- If transactionData.customer_id is INT, run this to change it to VARCHAR(50)
ALTER TABLE transactionData
ALTER COLUMN customer_id VARCHAR(50) NOT NULL;
