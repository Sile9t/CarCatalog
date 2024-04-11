*This ReadMe is not a documentation, it my comment on my own old (2022, man) project. U can notice the difference between project and ReadMe creation.*

It was a diplom project, so I made by myself from 0. 
There was some stages:
* documentationing;
* architecture development (UML diagrams, idef diagrams and so on);
* database design;
* coding;
* testing;
* and diplom protection.

As the result I made very ugly app, which is something between a shop app and erp system (yeah it's my crazy mutant), with vary ugly WinForms interface.

So, what u can do in this app:
  1. U can logging, or create a profile. The type of profile ("client" or "employee") will influence on number of options. I hadn't deep knowledge C# (something like premediate) and OOP (just basic) at that moment, so I made a lot of spaghetti code (yeah I noticed it yet).
  
![Login Form](https://github.com/Sile9t/CarCatalog/assets/91737196/4189c7ea-2d27-4f73-9cc2-267c02182d0a)

  
  2. Then, after log in, u'll see this ugly MDI (may be it's not MDI, whatever...) container interface.

![Main program interface](https://github.com/Sile9t/CarCatalog/assets/91737196/5e9e4fe8-a7c4-488a-ba7b-83f1a68c4663)


  3. There u can open catalog page, and see all car models are available for purchase (as I thought).

![Car catalog page](https://github.com/Sile9t/CarCatalog/assets/91737196/a3247954-dbb5-4ec9-b0be-9825085cc0e7)


  4. Then I can click any of them to check out their specs.

![Car specs page](https://github.com/Sile9t/CarCatalog/assets/91737196/f31d4ce3-b683-4e0b-b373-56f0aed1948b)

And u can print their specs.

![Car specs print](https://github.com/Sile9t/CarCatalog/assets/91737196/1974e153-870f-44ed-9221-e5d2694d096b)

  5. If u are an employee u can add a new car model in car_catalog page, where u can see all models as a table (one of the most useless in this app).

![Car_catalog page](https://github.com/Sile9t/CarCatalog/assets/91737196/77c51d62-3f41-429d-81ab-dcb7f1671f18)

  6. If click order page, there will an car order table, where u can create, alter, cancel or delete on order.

![Orders page](https://github.com/Sile9t/CarCatalog/assets/91737196/09adea1b-465c-4686-b931-2fed0a145464)

This page has two interesting (on my opinion) buttons: "Agreement" and "Report" buttons. By clicking "Agreement" button u'll open a word automatically half filled agreement document.

![Agreement document](https://github.com/Sile9t/CarCatalog/assets/91737196/543bd4b4-9b78-466d-8edf-9d2efafd0de8)

By clicking "Report" button u'll open excel automatically filled document with hictogramm and pie chart.

![Report document](https://github.com/Sile9t/CarCatalog/assets/91737196/edd96e5a-c818-432a-927b-949aa521a49e)

  7. Next one is leasing page, and the same table 

![Leasing page](https://github.com/Sile9t/CarCatalog/assets/91737196/c3fa071e-9442-4fa1-b0bd-71fa48ca75f3)

with "Leasing agreement" button, which opens word leasing agreemet document

![Leasing document](https://github.com/Sile9t/CarCatalog/assets/91737196/975c921d-080b-4c51-ab89-9a1e297c069b)

  9. And there another 3 different tables for clients, employees and suppliers (I thought it cool, but now I understand that they are useless for some reason).

![Clients page](https://github.com/Sile9t/CarCatalog/assets/91737196/d621e8ed-f262-470a-acc5-66e33d1cf612)
![Employees page](https://github.com/Sile9t/CarCatalog/assets/91737196/a40fb4b1-b4c6-4051-9ce9-40bcd54a65d5)
![Suppliers page](https://github.com/Sile9t/CarCatalog/assets/91737196/96a99bff-4e79-4e23-be3d-6744156341a8)

And, that it. Oh, i forgot about architecture! There all:

*Don't want to explain all of this, so I just put it without comments*
![image](https://github.com/Sile9t/CarCatalog/assets/91737196/f3331368-1002-4d39-8466-f18c6d7a1786)
![image](https://github.com/Sile9t/CarCatalog/assets/91737196/fa4fcbac-0eef-4190-9bfa-b3427d33542f)
![image](https://github.com/Sile9t/CarCatalog/assets/91737196/d1f949c5-e8ef-4ede-9aaf-807ce5fc95a5)
![image](https://github.com/Sile9t/CarCatalog/assets/91737196/acb87b6a-409a-456a-b025-ced018f84d5c)
![image](https://github.com/Sile9t/CarCatalog/assets/91737196/41631a94-b927-425a-8599-1355daf8d1ee)
![image](https://github.com/Sile9t/CarCatalog/assets/91737196/47d32463-eb1c-4b7f-b562-81f760eca46f)
![image](https://github.com/Sile9t/CarCatalog/assets/91737196/aa4de1ba-c832-4c30-8c28-3dcc2b038c3b)

And done. Thank you for that time, what u spent on reading this mess of characters and images. I hope u had some fun while read this, and I hope someday I'll remake this app, but not now.
