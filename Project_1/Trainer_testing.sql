
INSERT INTO Users (User_ID, Email_ID, [Password], Firstname, Lastname, Age, Gender, Phone_Number, City)
VALUES(1, 'mani@gamil.com', 'nothing123', 'Mani', 'Khan', 22, 'Male', 726862876, 'Chennai'),
(2, 'yuva@yahoo.com', 'password12', 'Yuva', 'Tony', 22, 'Male', 872943467, 'Mumbai'),
(3, 'max@outlook.com', '12345678', 'Max', 'Maxie', 23, 'Male', 875234722, 'Delhi');

INSERT INTO Users (User_ID, Email_ID, [Password], Firstname, Lastname, Age, Gender, Phone_Number, City)
VALUES(4, 'xavier@gamil.com', 'xavi12357', 'Xavier', 'Jax', 24, 'Male', 9344782346, 'Queens');

INSERT INTO skill (user_id, skill_1, skill_2, skill_3)
values(1, 'python', 'c#', 'HTML'),
(2, 'CSS', 'Linux', 'Sql'),
(3, 'Hacking', 'Animation', 'None');

INSERT INTO skill (user_id, skill_1, skill_2)
VALUES(4, 'JS', 'Java');

select * from users;
select * from skill;

SELECT * FROM users as u
INNER JOIN skill as s
on u.User_id = s.user_id; 

SELECT u.Firstname, u.Lastname, u.Gender, CONCAT(s.skill_1, ',', s.skill_2, ',', s.skill_3)  as Skills
FROM users as u
INNER JOIN skill as s
on u.user_id = s.user_id;
