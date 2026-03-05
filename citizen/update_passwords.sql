-- ================================================
-- UPDATE DEFAULT PASSWORDS TO MEET REQUIREMENTS
-- ================================================
-- Run this in phpMyAdmin SQL tab

USE senior_citizen_db;

-- Delete old weak passwords
DELETE FROM users WHERE username IN ('admin', 'user');

-- Insert new users with STRONG passwords (plain text - will be hashed on migration)
INSERT INTO users (username, password, user_type) VALUES 
('admin', 'Admin@2026', 'admin'),
('user', 'User@2026', 'user');

-- Verify the new passwords
SELECT username, password, user_type FROM users;

-- ================================================
-- NEW LOGIN CREDENTIALS:
-- ================================================
-- USER:   username: user    password: User@2026
-- ADMIN:  username: admin   password: Admin@2026
-- ================================================
