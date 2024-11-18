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

Add Azure.Data.Tables and Azure.Storage.Blobs
![image](https://github.com/user-attachments/assets/1e8a5be9-a878-46ba-90bb-b86c95770b51)



Save and upload

![image](https://github.com/user-attachments/assets/d3cce700-fd5c-48c4-a5b3-86aee3b524f1)

# Visual Studio Publish
![image](https://github.com/user-attachments/assets/1b0df9d2-dab2-49b8-9f07-70b7d9f79826)
![image](https://github.com/user-attachments/assets/145f118b-6d83-4da8-af30-0cac8e0de52b)
![image](https://github.com/user-attachments/assets/9c68abb2-00ab-4ba1-afab-1ea886084f97)
![image](https://github.com/user-attachments/assets/1b5fea2e-e30c-44d0-ae4f-48bdbe729128)

# Testing
Sending the request by postman
![image](https://github.com/user-attachments/assets/52073974-34ff-4250-90e0-2e40cdb23175)

Azure Table Storage 
![image](https://github.com/user-attachments/assets/04af9739-ec30-4e57-8825-465095350151)

Azure Blob Storage
![image](https://github.com/user-attachments/assets/bc6b3f59-ceae-4b12-bee3-f2cbedc97251)


