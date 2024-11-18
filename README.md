# About
This project demonstrates the use of Azure Functions Http Trigger + Azure Table Storage + Azure Blob Storage.

# Stacks of this project
- .NET 8
- Azure Function
- Azure Blob Storage
- Azure Table Storage
- Postman _(for API testing)_
- Visual Studio 2022

# Azure Server settings
Go to Azure Server and create a new storage called "poccustomer"
![image](https://github.com/user-attachments/assets/52564063-64c7-4f3f-9c35-b2e64dd54e1c)

Inside the storage, click on menu "Container" and create  a new container named "customer-images-container"
![image](https://github.com/user-attachments/assets/01939cdb-e069-4726-acf2-d2c911fa9af8)

Still inside the storage, click on menu "Data storage" -> "Tables" and create a new Azure Table Storage named "TbCustomer"
![image](https://github.com/user-attachments/assets/08e2756d-3492-485a-97b9-a9babdf533a6)

# Visual Studio
Create Azure Function Http Trigger
![image](https://github.com/user-attachments/assets/f2157e1f-03cb-4ee1-b291-b277eea53dea)

Add Azure.Data.Tables
![image](https://github.com/user-attachments/assets/a13f40eb-b399-4409-b421-9ac71939f969)
![image](https://github.com/user-attachments/assets/c6c06ad4-da92-4425-b76f-3a03a5cc5b3d)


Save and upload

![image](https://github.com/user-attachments/assets/d3cce700-fd5c-48c4-a5b3-86aee3b524f1)

# Visual Studio Publish
