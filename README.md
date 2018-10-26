# school-challenge
This is a simple application demonstrating the concepts of building a simple crud applciation using MVC and being able to import a file.
I have also added migrations for ease of setting up the database and also being able to version the Database.

Setps below are required for running the application
1. Create a Blank DB
2. Replace the name of the Database in the command provided below also change the provider if you have to 
3. once the database is created and you have done the appropriate changes run the command and a database will be created with all teh tables and procedures required
migrate -c "Server=.;Database=SchoolManagement1;Integrated Security=True;" -db SchoolManagement -a "C:\Projects\School Challenge - Task\SchoolChallenge\SchoolChallenge.Migration\bin\Debug\SchoolChallenge.Migration.dll" -db SqlServer2016
4. Open the solution and restore all Nuget packages build and run application (Make sure you have changed connection strign in .congfig and set path for your logs).

