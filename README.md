
# peabux

An assessment.

It is built with .NET 6, Postgres, EntityFrameworkCore and React on the frontend.

Kindly input your username and password for the Postgres Db and run migrations.

To run the .NET API in Visual Studio, open the PeabuxAssessment and run the solution file.

To run the frontend, open the peabux-assessment in VS Code or any code editor of your choice.

run `npm install`

after successful installation, Kindly create a `.env` file in your root folder.

Create a variable named **REACT_APP_API_URL** and assign your backend base url to it (without the ending forward slash '/').

Use `npm start` to start the application

Note: you should have the backend running before trying to do any activities on the frontend.

Run tests for the backend in Visual studio or using `dotnet cli`

Run tests for the frontend using `npm test`
