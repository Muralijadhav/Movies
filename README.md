=================================================================================================================================================================
       ASP.NET MVC APPLICATION(Entity Framework- Code First appraoch) : MoviesApp Project Overview
=================================================================================================================================================================

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
Problem Statement:

Create a IMDB.com like website with basic CRUD and movie listings using an MVC web-framework of your choice (Asp.NET MVC / Asp.NET Core / Django / Rails / MEAN stack). We would like to have the following entities in the application. 
 
Actors  - Name  - Sex  - DOB  - Bio 
Movies  - Name  - Year of release  - Plot  - Poster (image) 
 
Relationships 
● Actor can act in multiple movies 
● Movie can have multiple actors 
 
application specifics (minimum requirements): 
1. Screen to list all movies with Name, Year of release and all Actors of that movie 
2. Screen to ‘add’ a new movie with the necessary fields with existing actors. If the user wants to add new ‘Actors’ while creating the movie which are not present in the database then he should be able to do so while being on the same screen.  
3. ‘Listing’ screen should allow user to click on ‘Edit’ and edit all the details of the movie and save it would be nice. 


/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

Key components:

* Web.config file: contains all the necessary configuration information of 
  this web application, I have used CodeFirst approach. So, Please update only connectionsstring [In web.config] as per your system.
  <add name="MovieAppContext" connectionString="user id=UPDATE_YOUR_DB_USER_ID;password=UPDATE_YOUR_DB_PASSWORD;Data Source=UPDATE_YOUR_DB_SOURCENAME;Database=Movies">
  
  If the code first approach didn't work, i also uploaded DB table scripts[In first root itself] in name 'Movies_Queris.sql'.

* RegisterRoutes.cs: contains all the URL routing rules

* HomeController class: contains the main application 
    navigation logic(such as default page and about page)

* MoviesController class: contains the functions for add, update movie, details & delete movies.

* ActorsController class: contains the functions for add, update actor, details & delete actors.

* Home Views: the page UI elements for HomeController

* Movies Views: the page UI elements for MoviesController

* Actors Views: the page UI elements for ActorsController

* Shared Views & _ViewStart.cshtml: those UI elements shared by all page UI

* Images: Banner Images, few movie banner images.


/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
References:

#ASP.NET MVC Tutorials
http://www.asp.net/Learn/mvc/
