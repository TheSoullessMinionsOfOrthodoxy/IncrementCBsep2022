# IncrementCBsep2022


Demo BEE app in windows forms.
WinForms: creates an app for desktop. VS is wonderfully equiped to build these very quick. 

xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

Wat do we need?
0. Visual Studio 2022 and WinForms template
1. A UI 
2. XML files for our XML-Database
3. Code that connects our UI to the database koppelt

xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

The UI 
We use the VS-designer to create our UI. 

We start with adding a DataGgridView to the designer. Just drag a DGV from the Toolboxmenu into the designer. That Toolbox has all the UI elements we need and many more.

A DGV is a UI element that has the same functionalities as a spreadsheet and with c# it's highly customizable. And that's what we need here.

Next we add some buttons to the designer. These trigger the events we need when we want to read and write.

We also added a menustrip at the top. We're going to use that in the upcomming days and will fill it with functionality. For now whe chose the default windows implementation.

Over the next days you'll see more buttons and maybe a textbox. Those will be temporarely just like the two buttons read and write. 

How will the def. UI look like? I have no idea.

xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

XML files and XML-Database  
The DGV needs data. We use a XML file to store them. XML == Json only more readable. Data from file is converted by code to object.
In the code we connect the object to the DGV. Databinding. It means that if we change the data displayed in the DGV, the same change is applied to the data in the object. We can change data and create new rows containing data. If we want to save the work we've done we push save and the code converts the object to xml and writes to the XML file. 

With Linq (Language-Integrated Query) we can query the object. Linq == Sql but cleaner and smarter.

How will the code evolve? It will probably end in a single file which contains way too much code. We probably need to follow some basic principles to avoid it. 

xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

Code that connects front and back 
There's a lot of code needed for the UI. VS designer autogenerates that while you work with the designer. So we don't need to care about that. 

The c# code that we need to make things work are written in .cs files.

Up until now our code has only two methods. One for reading the data and converting xml to an object and one for writing which means converting the object to xml and save this to the file. These methods are called when the user triggers the read or save button on the UI.

There's also code for the object. We define it in a class. VS is your friend here. You code a XML file (that's really easy). Copy the xml code and go to the .cs file. From the menu Edit in VS goto pastespecial and choose Paste XML to Classes. The xml datastructure will be converted in a c# class. That's the object we need to bind our DGV. 
 
The DGV comes with some nice functionalities. Sorting is already implemented in the DGV so any data can be sorted by column without us having to write a single line of code. Hehe. That's easy isn't it? Unfortunately
that only works with a DGV that is not databound so we have to write code for that. Which is not that hard because we use linq for that. But that something for tomorrow.
