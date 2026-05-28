
--Transaction with COMMIT

-- BEGIN TRANSACTION;

-- UPDATE Bills
-- SET TotalAmount = TotalAmount + 500
-- WHERE BillID = 1;

-- COMMIT;

--Transaction with ROLLBACK

-- BEGIN TRANSACTION;

-- UPDATE Bills
-- SET TotalAmount = TotalAmount + 1000
-- WHERE BillID = 2;

-- ROLLBACK;