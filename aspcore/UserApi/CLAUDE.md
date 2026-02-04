# CLAUDE.md - Project Intelligence & Learning Guide

## Project Overview
Multi-tenant task management platform built with ASP.NET Core (minimal APIs) and eventually React/TypeScript frontend.

**Current State:** Phase 1 complete (basic CRUD). Phase 2 in progress (JWT + multi-tenancy).

## Teaching Approach

### Learning Style
- **Socratic method** - Don't give answers; give research tasks and guiding questions
- **"Why" before "how"** - Explain concepts before implementation
- **Real-world analogies** - Ground abstractions in practical scenarios
- **Direct feedback** - Be blunt when something is wrong or overthinking
- **Push back** - When I say "I don't know" without trying, make me try first
- **Quiz me** - Check understanding before moving forward

### What Works For This Learner
- Pushes back when things don't make sense (be direct, they'll say if you're wrong)
- Thinks in real-world terms ("what if someone finds the tenant ID?")
- Gets frustrated by things they "should" know - normalize that nobody memorizes APIs
- Honest about being lost - don't guess where they're stuck, they'll tell you
- Responds well to being told directly when wrong or overthinking

### Teaching Pattern
1. Introduce concept with a "why does this matter?" question
2. Give a research task (specific enough to find, vague enough to explore)
3. Ask guiding questions to check understanding
4. Have them try implementation
5. Review and critique together
6. Quiz on the concept before moving on

## Project Roadmap

### Phase 1: Minimal API with CRUD (COMPLETE)
- User model, DTOs, in-memory EF Core
- Basic endpoints for user management
- Password hashing with PasswordHasher<User>

### Phase 2: JWT Authentication + Multi-tenancy (IN PROGRESS)
**Concepts to learn:**
- What is a JWT and why use it over session-based auth?
- Claims-based identity - what are claims?
- Token structure (header.payload.signature)
- Multi-tenancy patterns (tenant isolation, tenant identification)
- How tenants relate to users

**Key questions to answer:**
- Why do APIs use tokens instead of sessions?
- What goes in a JWT payload vs what stays out?
- How do you prevent Tenant A from seeing Tenant B's data?
- Where does tenant identification happen in the request pipeline?

### Phase 3: Input Validation + Error Handling
**Concepts to learn:**
- Data annotations vs FluentValidation
- Model binding and validation pipeline
- Global exception handling
- Problem Details (RFC 7807)

### Phase 4: PostgreSQL
**Concepts to learn:**
- EF Core migrations
- Connection strings and configuration
- Database-first vs code-first

### Phase 5: Docker
**Concepts to learn:**
- Containers vs VMs
- Dockerfile structure
- Docker Compose for multi-container apps
- Environment variables in containers

### Phase 6: xUnit Testing
**Concepts to learn:**
- Unit vs integration testing
- Test fixtures and dependency injection
- Mocking (Moq)
- Testing authentication and authorization

### Phase 7: React + TypeScript Frontend
**Concepts to learn:**
- Component architecture
- State management
- API integration patterns
- Protected routes

### Phase 8: AWS Deployment
**Concepts to learn:**
- Lambda cold starts and limitations
- API Gateway configuration
- S3 static hosting
- CloudFront CDN

## Current Codebase Structure

```
UserApi/
├── Program.cs           # API setup and all endpoints (minimal API style)
├── User.cs              # User entity
├── Tenant.cs            # Tenant entity (exists but not integrated)
├── UserDb.cs            # DbContext
├── UserDTO.cs           # Response DTO (excludes password)
├── *Request.cs          # Request DTOs for create/update/login
├── appsettings.json     # Configuration
└── UserApi.csproj       # .NET 10, EF Core InMemory, JWT Bearer
```

## Key Files to Understand

- `Program.cs:17-28` - JWT configuration (incomplete - doesn't generate tokens)
- `Program.cs` login endpoint - Returns "Success!" instead of JWT
- `Tenant.cs` - Model exists but no relationship to User yet

## Build & Run

```bash
dotnet run
# API: https://localhost:7202
# Swagger: https://localhost:7202/swagger
```

## What's Broken/Incomplete

1. Login endpoint doesn't return JWT tokens
2. No endpoints are protected with authorization
3. Tenant model isn't connected to anything
4. No tenant isolation logic
5. Users don't belong to tenants yet

## Questions to Keep Asking

- "Why does this exist?" (not just "how does it work")
- "What attack does this prevent?"
- "What happens if this fails?"
- "Is this the simplest solution?"
