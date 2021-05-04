# Rookie Assignment Project - Ecommerce_NT

## Author : **Hoàng Tiến Dũng**
## Contact :
  - phone: **0384256135**
  - email: **hngtiendng@gmail.com**
## FrameWork:
  - Customer Site: ASP.NET Core MVC
  - Server Site: ASP>NET Core API, Identity Server
  - Admin Site: ReactJS
## Database: 
  - SQL Server
## Azure Cloud Services:
  - Admin Site:   azure storage explorer
  - Server Site + Customer Site : WebApp
  - Datbase : SQL Database
## Deploy Hosting:
  - Admin Site : ***https://sahngtiendng.z23.web.core.windows.net/***
  - Server Site : ***https://backend-hngtiendng.azurewebsites.net/***
  - Customer Site : ***http://customersite-hngtiendng.azurewebsites.net/***
## Architecture
![image info](./Architecture.png)
## Database Diagram
![image info](./DatabaseDiagram.PNG)
## Construct
### ServerSite
-	Login/logout
-	Manage product categories (Name, Description)
-	Manage products (Name, Category, Description, Price, Images, CreatedDate, UpdatedDate)
-	View customers


### CustomerSite
-	Home page: category menu, features products
-	View products by category
-	View product details
-	Product rating
-	Register
-	Login/Logout
-	Optional (shopping cart, ordering)

### AdminSite
-	Login/logout
-	Manage product categories (Name, Description)
-	Manage products (Name, Category, Description, Price, Images, CreatedDate, UpdatedDate)
-	View customers
