Description
You will be learning how to create and manage a web page’s static and 
dynamic sections. By the end of this, you'll have the skills to create 
an application with Partial views and to use ViewComponent to display the 
dynamic data.


Objective
Upon completion of this, you will be able to:
•	Create how to create the Partial views in your ASP.NET Core application.
•	Create a View component and invoke it.
•	Connect to the backend API to fetch the details.

Prerequisites
You should have a basic understanding of Partial Views and ViewComponents in ASP.NET Core

Requirements
•	Create a Post page to display the post
o	Access the post comments from the comment’s backend API 
at https://jsonplaceholder.typicode.com/
•	And display them using a ViewComponent
•	Display a post and access comments based on the Id of the post.
•	Show the comments counts.
•	Create a reusable Menu for the website.
•	The schema for the models is as:

PostViewModel
{
       Id = 1,
       Title = "What is ASP.NET Core",
       Author = "Mahesh Ram",
       Body = "ASP.NET Core is an open-source framework for building UI 
       and API..."
}

CommentViewModel
{
  PostId= 1,
  Id= 1,
  Name= "id labore ex et quam laborum",
  Email= "Eliseo@gardner.biz",
  Body= "laudantium enim quasi est quidem magnam voluptate ipsam"
}
