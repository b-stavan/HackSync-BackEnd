# HackSync-BackEnd

# Project Title

hacksync web api

## Description

 Hackathon Planning Mobile Application. The Application will be easily available and free to use for everyone. It let's an Organization, initiate a Hackathon, and the participants can select themselves to be team-mates/team-leads. Here, The team-lead needs to primarily define his/her problem-statements and can request participating team-mates to join them in their Vision. Moreover, a team-mate can also request a team-lead to be in his team, if he/she wants their vision/aim to similar to be Achieved.

## Getting started
These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system

Prerequisites
Visiaul Studio (specify the version) or Visual Studio Code If you want to develop .NET Core applications on Windows using Visual Studio, you can use the following two versions −

Visual Studio 2015

Visual Studio 2017 or above

.Net Core SDK ( Mention the version here)

Setup
Install the Visual studio or Visual Studio code to run the project Install .Net Core Runtime https://dotnet.microsoft.com/download

Run Project in Development enviorment
Clone the repository in your local enviorment. Rebuild the project so all the dependant packages will be installed. If you are using visual studio then you can directly run the project. If you are using Visual studio code then follow the below steps to run the project.

Run below command to clean the project. This command will cleanups the dll from your bin and obj directory.

dotnet clean
Build the project using below command

dotnet build 
Run the project using below command

dotnet run
If you are using your local copy of the database then set your connection string in appsettings.json file of your project.

Dependancies
Nuget Packages
Please specify all the depant nuget packages. i.e. Newtosoft.json Note: No need to mention default packages here

Third Party API
Provide all the third party API details here i.e Google API, Payment Gateway

Third Party tool
Provide all the third party tools here i.e. Power BI, QuickBooks

Database
Specify your database server with version and database name i.e. Database Server: SQL Server 2014 Database Name: ABCDatabase

Project Architecture
Specify your project architecture here. Suppose you are following Repository pattern then mention your all the projects with description here.

Project.Data (Conatins database model)
Project.Repository(Contains repositories of all the entities)
Project.Services(Contains business logic)
Project.Entities(Contains view model of request and response)
Project.Web / Project.API
Project.Test(Contains all the test methods)
Running the tests
Specify the tool which is used to build the test i.e. XUnit If you are using visual studio for the development then you can run tests in Test Explorer. If Test Explorer is not visible, choose Test on the Visual Studio menu, choose Windows, and then choose Test Explorer. All the unit tests will be listed so choose the test you want to run. You can also run alto tests by selecteing "Run All" option.

If you are using the visual studio code then execute below command in your command prompt to test the your test cases.

dotnet test
Deployment
Deployement server
If you have multiple server for the stage and production then specify all the details here

Deployement prerequistes
If you have EC2 instance or any VPS server then install below prerequistes software 1. Install IIS 2. Install .Net Core Runtime

Deployement Steps
Create virtual directory under IIS
Enable Inbound and Outbound port for SQL Server(1433) in Firewall
Create security group in your production and stage server if you are using EC2
Update the database connection string with Production in appsettings.json
Publish your application from Visual Studio. If you are using visual studio code then use below command to publish your project.

 dotnet publish -o <outputdir>
Move your publish files to the your server

Versioning
Specify the version history |Version |Descrption |Other Description| |----------------|-------------------------------|-----------------------------| |1.0.0.0|First Version | Other Description |