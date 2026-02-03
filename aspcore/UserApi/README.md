# What is this?

A multi-tenant task management platform, utilising an ASP.NET Core Minimal RESTful Web API for the backend and React/Typescript for the frontend

# What works now

- User CRUD Functionality
  - Create User with Tenant Association and hashed passwords
  - Remove User by ID
  - Read All Users
  - Read User by ID
  - Update User by ID

- Utilising C# InMemory Database for testing currently.

- API Testing with Swagger Frontend

# What's Planned

- **Phase 1:** Minimal API with CRUD, password hashing - ✅ DONE
- **Phase 2:** JWT Authentication + Multi-tenancy - login endpoint, protect routes, tenant data isolation
- **Phase 3:** Input validation, error handling, secure coding practices
- **Phase 4:** PostgreSQL - replace in-memory database
- **Phase 5:** Docker - containerize API with real database
- **Phase 6:** Testing with xUnit - auth, multi-tenant logic, CRUD
- **Phase 7:** React + TypeScript frontend - login, tenant-scoped views, task-management board
- **Phase 8:** AWS deployment - Lambda, S3, CloudFront, API Gateway

- **Stretch goals:**
  - Email domain verification for tenant signup
  - Two-factor authentication (2FA)

# How to run the project

1. Install .NET 10
2. Clone the repo
3. Set the Jwt\_\_Key environment variable
4. `dotnet restore`
5. `dotnet watch run`
