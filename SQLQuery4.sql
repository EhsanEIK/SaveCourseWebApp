/****** Script for SelectTopNRows command from SSMS  ******/
SELECT 
a.Id,
a.Assignment,ClassTest,
a.LabReport,
c.CourseTitle,
c.CourseCode
from AssignTable as a INNER JOIN CourseTable as c on  a.CourseId=c.Id






CREATE VIEW GetAllDetailsView AS
SELECT 
a.Id,
a.UserId, 
a.Assignment, 
a.ClassTest, 
a.LabReport, 
a.CourseId, 
c.CourseTitle, 
c.CourseCode,
l.UserCode
FROM AssignTable as a INNER JOIN CourseTable as c on  a.CourseId=c.Id
INNER JOIN LogInTable as l on a.UserId=l.Id


//Final query
SELECT 
l.UserCodeId,
c.CourseTitle,
c.CourseCode,
a.Assignment,
a.ClassTest,
a.LabReport 
FROM 
AssignTable as a JOIN CourseTable as c on a.CourseId=c.Id
JOIN LogInTable as l on a.UserId=l.Id WHERE UserId=6
