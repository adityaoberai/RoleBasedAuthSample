# Role Based Auth Sample - .NET Conf 2023

## Description

The **Role Based Auth .NET Sample** is an **sample ASP.NET Web API** to help understand how role based authentication can be implemented via JWTs in a **.NET 8** application. It utilizes an **InMemory database** using **Entity Framework Core** for storing user data and the **Argon2** hashing algorithm for encrypting passwords.

The API has 1 controller:

- **AuthController**: Contains the login, registration, and test APIs

### AuthController

The `AuthController` contains the login, registration, and test APIs we are using to get and try the JWT token authentication.

* POST `/auth/login`

    * Returns the JWT token along with the user information from the database after the user enters their email and password.
    * Post Http Request Link: `https://<YOUR-DOMAIN:PORT>/auth/login`
    * Request Body Example:

        ```json
        {
            "userName": "adityaoberai1",
            "password": "test1234"
        }
        ```

    * Response Example:

        ```json
        {
            "userName": "adityaoberai1",
            "name": "Aditya Oberai",
            "roles": [
                "User",
                "Admin"
            ],
            "isActive": true,
            "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImFkaXR5YW9iZXJhaTEiLCJnaXZlbl9uYW1lIjoiQWRpdHlhIE9iZXJhaSIsInJvbGUiOlsiVXNlciIsIkFkbWluIl0sIm5iZiI6MTY5OTI3OTQyNywiZXhwIjoxNjk5MjgxMjI3LCJpYXQiOjE2OTkyNzk0MjcsImlzcyI6IlRlc3RJc3N1ZXIiLCJhdWQiOiJUZXN0QXVkaWVuY2UifQ.d9bAAqm1iHWmf7klIBWA2tFf2Pkvzfkee1lBvhv0_Ag",
            "password": "$argon2id$v=19$m=65536,t=3,p=1$gFcsc5mOvzCclGj+o2CqeQ$TBCPrC6HW1+kCmtCc7vai9JJv3SOgPQK/mMjiJf7X8M"
        }
        ```
         
        > Note: Token returned will be different from the example

* POST `/auth/register`

    * Adds the user's details to the database and returns the JWT token along with the user information after the user enters their information.
    * Post Http Request Link: `https://<YOUR-DOMAIN:PORT>/auth/register`
    * Request Body Example:

        ```json
        {
            "name": "Aditya Oberai",
            "userName": "adityaoberai1",
            "password": "test1234",
            "role": [
                "User", 
                "Admin"
            ]
        }
        ```

    * Response Example:

        ```json
        {
            "userName": "adityaoberai1",
            "name": "Aditya Oberai",
            "roles": [
                "User",
                "Admin"
            ],
            "isActive": false,
            "token": null,
            "password": "$argon2id$v=19$m=65536,t=3,p=1$gFcsc5mOvzCclGj+o2CqeQ$TBCPrC6HW1+kCmtCc7vai9JJv3SOgPQK/mMjiJf7X8M"
        }
        ```

* GET `/auth/test`

    * Returns claims from the JWT sent as the **Bearer token** in the `Authorization` header with **User** role.
    * Get Http Request Link: `https://<YOUR-DOMAIN:PORT>/auth/usertest`
    * Request Header Example:

        ```
        Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImFkaXR5YTEiLCJnaXZlbl9uYW1lIjoiQWRpdHlhIE9iZXJhaSIsInJvbGUiOiJVc2VyIiwibmJmIjoxNjk5Mjc5NjA2LCJleHAiOjE2OTkyODE0MDYsImlhdCI6MTY5OTI3OTYwNiwiaXNzIjoiVGVzdElzc3VlciIsImF1ZCI6IlRlc3RBdWRpZW5jZSJ9.JpCzjncNg14Ptx1c1fRt4fZmUAIcuBSowL_WoVYZo6s
        ```
    
    * Response Example:

        ```
        List of Claims: 

        unique_name: aditya1
        given_name: Aditya Oberai
        role: User
        nbf: 1699279606
        exp: 1699281406
        iat: 1699279606
        iss: TestIssuer
        aud: TestAudience
        ```

## Steps to Setup

- Clone the repository and enter it
- Run the command `dotnet restore`
- Run the command `dotnet run`