# BlogEngine
Test programmation Nware

Solution BlogEngine

BlogEngine.Common 
	.NET Standard 2.0
	#Common entities for Rest API services and MVC Web project 

BlogEngine.Web

	.NET Core 2.1
	Modelo–vista–controlador (Model–view–controller)

	Controllers API
	Controllers MVC

	Data
	DataContext
	SeedDB to populate DB with data

	Helper (Converter entities to break the circular relationship to Rest Api Services)
	ConverterHelper
	IConverterHelper

	EF Core 2.1.1
	Migrations Folder

	Models
	Views
		Categories
		Posts

Swagger Documentation REST API
https://localhost:[Port]/swagger/index.html

BlogEngine.postman_collection to test Rest Api Services

	api/categories
	api/categories/[Id]
	api/categories/[ID]/posts
	api/posts
	api/posts/[Id]
