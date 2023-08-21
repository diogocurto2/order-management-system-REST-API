USE master;

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'OrderManagement')
BEGIN
    CREATE DATABASE OrderManagement;
END;

USE OrderManagement;