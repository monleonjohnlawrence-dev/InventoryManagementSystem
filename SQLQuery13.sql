INSERT INTO transactionData (customer_id, total_amount, cash_paid, change_amount, transaction_date)
SELECT 
    customer_id,
    total_price,
    amount,
    change_amount,
    order_date
FROM customers;
