
-- User
INSERT INTO [Users] (FirstName, LastName, Email, Phone, Title, Bio, Created, Password)
VALUES
('John', 'Doe', 'john.doe@example.com', '+1-555-1234', 'Software Engineer', 'I enjoy programming and hiking.', '2022-01-01 10:00:00', 'Password'),
('Jane', 'Doe', 'jane.doe@example.com', '+1-555-5678', 'Product Manager', 'I love building great products.', '2022-01-02 11:00:00', 'Password'),
('Bob', 'Smith', 'bob.smith@example.com', '+1-555-2468', 'Marketing Manager', 'I specialize in digital marketing.', '2022-01-03 12:00:00', 'Password'),
('Alice', 'Johnson', 'alice.johnson@example.com', '+1-555-3698', 'Sales Representative', 'I excel at building relationships with customers.', '2022-01-04 13:00:00', 'Password'),
('Tom', 'Lee', 'tom.lee@example.com', '+1-555-9876', 'Data Analyst', 'I have a passion for data analysis and visualization.', '2022-01-05 14:00:00', 'Password');

INSERT INTO [Users] (FirstName, LastName, Email, Phone, Title, Bio, Created, Password)
VALUES
('Sarah', 'Johnson', 'sarah.johnson@example.com', '+1-555-4321', 'Graphic Designer', 'I love creating beautiful designs that capture the essence of a brand.', '2022-01-06 15:00:00', 'Password'),
('Chris', 'Miller', 'chris.miller@example.com', '+1-555-7531', 'Project Manager', 'I excel at leading cross-functional teams to deliver successful projects.', '2022-01-07 16:00:00', 'Password'),
('Emily', 'Garcia', 'emily.garcia@example.com', '+1-555-8642', 'HR Manager', 'I am passionate about creating a positive work culture where everyone can thrive.', '2022-01-08 17:00:00', 'Password'),
('Mike', 'Brown', 'mike.brown@example.com', '+1-555-1357', 'Financial Analyst', 'I am a detail-oriented financial analyst who loves working with numbers.', '2022-01-09 18:00:00', 'Password'),
('Linda', 'Davis', 'linda.davis@example.com', '+1-555-2468', 'Customer Service Representative', 'I am committed to providing outstanding customer service and resolving issues quickly and effectively.', '2022-01-10 19:00:00', 'Password');

-- Project
INSERT INTO [Projects] (Name, Description, AuthorId, Status, Deadline, Created)
VALUES
('Website Redesign', 'Redesigning the company website to improve user experience and increase conversions.', 1, 1, '2023-01-31 23:59:59', '2022-01-01 10:00:00'),
('Product Launch', 'Launching a new product in the market, targeting young adults and teenagers.', 2, 2, '2022-12-31 23:59:59', '2022-01-02 11:00:00'),
('Social Media Campaign', 'Creating a social media campaign to increase brand awareness and reach new customers.', 3, 1, '2023-05-31 23:59:59', '2022-01-03 12:00:00'),
('Sales Training Program', 'Developing a training program for the sales team to improve their skills and productivity.', 4, 2, '2022-11-30 23:59:59', '2022-01-04 13:00:00'),
('Data Analytics Dashboard', 'Designing and building a data analytics dashboard to help executives make informed decisions.', 5, 1, '2023-03-31 23:59:59', '2022-01-05 14:00:00');

-- Task
INSERT INTO [Tasks] (Name, Description, ProjectId, AuthorId, AssignedId, Status, Type, Priority, Difficulty, Deadline, Created)
VALUES
('Design landing page', 'Design a new landing page for the website.', 1, 1, 3, 1, 1, 1, 2, '2023-01-15 23:59:59', '2022-01-01 10:00:00'),
('Write product description', 'Write a compelling product description for the new product.', 2, 2, 4, 1, 2, 1, 1, '2022-12-31 23:59:59', '2022-01-02 11:00:00'),
('Create social media graphics', 'Create graphics for the social media campaign.', 3, 3, 2, 2, 1, 2, 3, '2023-04-30 23:59:59', '2022-01-03 12:00:00'),
('Develop sales training modules', 'Develop modules for the sales training program.', 4, 4, 5, 1, 3, 3, 4, '2022-10-31 23:59:59', '2022-01-04 13:00:00'),
('Build data analytics dashboard', 'Build the data analytics dashboard using Power BI.', 5, 3, 1, 2, 3, 2, 5, '2023-03-15 23:59:59', '2022-01-05 14:00:00');


INSERT INTO [Tasks] (Name, Description, ProjectId, AuthorId, AssignedId, Status, Type, Priority, Difficulty, Deadline, Created)
VALUES 
('Implement responsive design', 'Update the website to be responsive on different devices.', 1, 1, 3, 2, 1, 2, 4, '2023-02-28 23:59:59', '2022-01-06 15:00:00'),
('Create user onboarding flow', 'Develop an onboarding flow for new users of the platform.', 2, 5, 4, 1, 2, 1, 2, '2022-12-15 23:59:59', '2022-01-07 16:00:00'),
('Write email marketing campaign', 'Write a series of emails for the email marketing campaign.', 3, 1, 1, 1, 1, 3, 3, '2023-04-15 23:59:59', '2022-01-08 17:00:00'),
('Develop sales scripts', 'Develop scripts for the sales team to use during calls with potential customers.', 4, 5, 1, 2, 2, 2, 4, '2022-11-15 23:59:59', '2022-01-09 18:00:00'),
('Create social media content calendar', 'Create a content calendar for the social media campaign.', 3, 2, 3, 2, 1, 1, 2, '2023-05-31 23:59:59', '2022-01-10 19:00:00'),
('Write help documentation', 'Write documentation for the new product to help users get started.', 2, 2, 5, 1, 3, 1, 1, '2022-12-31 23:59:59', '2022-01-11 20:00:00'),
('Create wireframes for new feature', 'Create wireframes for a new feature to be added to the platform.', 1, 5, 1, 2, 2, 2, 3, '2023-03-15 23:59:59', '2022-01-12 21:00:00'),
('Optimize website loading speed', 'Optimize the website loading speed for better user experience.', 1, 5, 3, 1, 1, 3, 4, '2023-02-15 23:59:59', '2022-01-13 22:00:00'),
('Conduct user research', 'Conduct user research to better understand user needs and pain points.', 2, 2, 4, 2, 3, 1, 3, '2022-11-30 23:59:59', '2022-01-14 23:00:00'),
('Design email templates', 'Design templates for the email marketing campaign.', 3, 2, 1, 1, 2, 2, 2, '2023-03-31 23:59:59', '2022-01-15 00:00:00');

INSERT INTO [Tasks] (Name, Description, ProjectId, AuthorId, AssignedId, Status, Type, Priority, Difficulty, Deadline, Created)
VALUES 
('Implement responsive design', 'Update the website to be responsive on different devices.', 5, 2, 3, 2, 1, 2, 4, '2023-02-28 23:59:59', '2022-01-06 15:00:00'),
('Implement payment gateway integration', 'Integrate a new payment gateway into the platform for users to make payments.', 4, 4, 5, 2, 2, 3, 4, '2023-01-31 23:59:59', '2022-01-16 01:00:00'),
('Write blog post', 'Write a blog post on industry trends and insights for the company blog.', 5, 4, 2, 1, 1, 2, 2, '2022-09-30 23:59:59', '2022-01-17 02:00:00'),
('Develop customer feedback survey', 'Develop a survey to gather feedback from customers on the product.', 2, 5, 2, 1, 3, 1, 3, '2023-04-30 23:59:59', '2022-01-18 03:00:00'),
('Create video tutorial series', 'Create a series of video tutorials to help users understand how to use the product.', 1, 1, 3, 2, 3, 2, 3, '2023-05-15 23:59:59', '2022-01-19 04:00:00'),
('Test website for bugs', 'Conduct testing to identify and fix any bugs on the website.', 1, 5, 1, 2, 1, 2, 3, '2022-12-31 23:59:59', '2022-01-20 05:00:00'),
('Develop marketing plan', 'Develop a marketing plan to promote the product and increase sales.', 3, 3, 1, 1, 2, 1, 2, '2023-06-30 23:59:59', '2022-01-21 06:00:00'),
('Create product roadmap', 'Create a roadmap for the product to outline future plans and goals.', 4, 4, 1, 1, 1, 1, 2, '2022-10-31 23:59:59', '2022-01-22 07:00:00'),
('Develop customer personas', 'Develop personas to better understand the target audience and their needs.', 2, 5, 2, 2, 3, 1, 3, '2023-02-28 23:59:59', '2022-01-23 08:00:00'),
('Create marketing materials', 'Create marketing materials such as brochures and flyers to promote the product.', 3, 1, 2, 1, 2, 2, 2, '2023-04-30 23:59:59', '2022-01-24 09:00:00');

-- UserProject
INSERT INTO [UserProject] (UserId, ProjectId)
VALUES
(1, 1),
(1, 3),
(1, 4),
(2, 2),
(2, 3),
(2, 5),
(3, 1),
(3, 3),
(3, 5),
(4, 2),
(4, 4),
(4, 5),
(5, 1),
(5, 2),
(5, 4);
