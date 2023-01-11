
CREATE TABLE department (
    ID int IDENTITY(1, 1) NOT NULL,
    [name] VARCHAR(50),
    [location] VARCHAR(50),
    PRIMARY KEY(ID)
);

INSERT INTO department (name, location) VALUES ('Marketing', 'Hongkong');
INSERT INTO department (name, location) VALUES ('Human Resources', 'Newyork');
INSERT INTO department (name, location) VALUES ('Marketing', 'Queens');

select * from department;

SELECT * FROM mock_data;

CREATE TABLE employee (
    ID int IDENTITY(1, 1) NOT NULL,
    firstname VARCHAR(50),
    lastname VARCHAR(50),
    ssn int,
    deptID int NOT NULL,
    PRIMARY KEY (ID),
    FOREIGN KEY (ID) REFERENCES department(ID)
);


INSERT INTO employee (firstname, lastname, ssn, deptID) 
VALUES ('tina', 'smith', 624198468, 1),
('tony', 'stark', 835194482, 2),
('harry', 'potter', 739251048, 3);


-- select * from employee;


CREATE TABLE empdetails (
    ID int IDENTITY(1, 1) NOT NULL,
    employeeID int NOT NULL,
    salary int,
    address1 varchar(50),
    address2 varchar(50),
    city varchar(50),
    state varchar(50),
    country varchar(50),
    PRIMARY KEY (ID),
    FOREIGN KEY (employeeID) REFERENCES employee(ID)
);

INSERT INTO empdetails (employeeID, salary, address1, address2, city, state, country) 
VALUES (1, 20000, 'no. 5', 'chadwick street', 'chennai', 'tamil nadu', 'india'), 
(2, 40000, 'no. 28', 'park street', 'downtown', 'zimbia', 'zimbave'), 
(3, 32000, 'no. 41', 'gk street', 'mumbai', 'karnataka', 'india');


-- SELECT * FROM empdetails;


-- list marketing employees
SELECT e.firstname, e.lastname, d.name
FROM department as d
INNER JOIN employee as e
ON d.ID = e.ID
WHERE d.name = 'Marketing';


-- total salary of marketing
SELECT sum(salary) as 'Marketing salary'
FROM empdetails as ep
where ep.ID IN (SELECT ep.ID
FROM empdetails
INNER JOIN department as d
ON ep.ID = d.ID
WHERE d.name = 'Marketing');


-- total employees by department
SELECT count(name) as dept_count, name 
FROM department
GROUP BY name
ORDER BY name;


-- update tina smith salary to 90000
UPDATE empdetails
SET salary = 90000
FROM employee as e
INNER JOIN empdetails as ep
ON e.ID = ep.ID
WHERE e.firstname like 'tina';


