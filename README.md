# Wildlife Tracker | Proof Of Concept For Reusable Controllers

A client-ready wildlife tracking and management system built with ASP.NET Core. This application enables users to track wildlife sightings, manage animal data, and monitor habitats with a robust and scalable architecture.

## 🎯 Overview

This project is a **proof-of-concept REST API** built to demonstrate a **reusable, developer-friendly architecture** that emphasizes **clean code, reduced boilerplate, and adherence to OOP principles**. It provides a scalable foundation for enterprise-grade applications through a combination of robust patterns, performance optimizations, and maintainable design.

At its core, the API uses the **Specification Pattern** to enable **advanced filtering** with operators like `eq`, `gt`, `ge`, `lt`, `le`, `contains`, `icontains`, and negation, powered by a **runtime LINQ expression builder** for high performance. Complementing this, the **Projection Pattern** supports **dynamic field selection**, enabling clients to shape responses efficiently. Additional features include **multi-field sorting**, **pagination**, and **type-safe DTO mapping** using **AutoMapper’s `ProjectTo`** for optimized database queries.

Data persistence follows a **generic repository approach** (`EfRepository`, `IDeletableEntityRepository`), featuring **soft delete** via **global query filters** and an **audit trail** capturing `CreatedOn`, `ModifiedOn`, and `CreatedBy` for traceability. Security is enforced through **JWT Bearer authentication with refresh tokens**, **resource-level authorization** (`ResourceAccessService`), and **role-based access control**, all integrated with **ASP.NET Identity’s secure password policies**.

The infrastructure includes **response wrapper middleware**, a **global exception handler**, and **API versioning** using URL segments. Frontend integration is supported through an **ASP.NET Core SPA proxy**, and deployment is containerized using **Docker and Docker Compose** for a multi-container environment.

The project also features **Swagger/OpenAPI documentation** with authentication and versioning support, **custom validation attributes** (e.g., date of birth, future date, E.164 format), and a set of **extension methods** for cleaner code reuse. **Distributed tracing** (Trace ID, Span ID) provides observability across requests, while **seeders** simplify data initialization.

Additional highlights include **efficient database projections**, **image storage** under `wwwroot/animals-images`, a **testable service layer**, and an overall **clean SOLID architecture** designed for scalability, maintainability, and performance.

## Highlights

### Generic CRUD Controller With Additional Endpoints

<img width="743" height="406" alt="image" src="https://github.com/user-attachments/assets/992095c6-6290-43f4-b5f5-5b89e6151102" />

<img width="1157" height="538" alt="image" src="https://github.com/user-attachments/assets/64cc4242-ee96-43bd-bd0b-4764a21c63f3" />


### Specification Pattern

<img width="1036" height="472" alt="image" src="https://github.com/user-attachments/assets/ab9fe7cc-797a-4eec-949e-00b8cf24c954" />

### Global Exception Handling

<img width="772" height="739" alt="image" src="https://github.com/user-attachments/assets/aa4752f6-bdd0-4c98-af55-05843b1d551c" />

### Dummy Data Seeder

<img width="1270" height="552" alt="image" src="https://github.com/user-attachments/assets/66961265-0157-4450-bdbd-b26c42c0c25d" />

### Easy Entity Mapping

<img width="659" height="583" alt="image" src="https://github.com/user-attachments/assets/7742987c-8ecb-4091-8930-91a2d0f61bbf" />

## Technical Achievements

### **Advanced Backend Architecture**

#### **Generic CRUD Controller Pattern**
- Implemented a highly reusable `GenericController<TEntity, TCreateDto, TReadDto, TUpdateDto>` that eliminates code duplication across all resource endpoints
- Automatic CRUD operations for any entity type, reducing boilerplate code

#### **Dynamic Query System**
- **Advanced Filtering Engine**: Runtime LINQ expression builder supporting complex query operations
  - Operators: `eq`, `gt`, `ge`, `lt`, `le`, `contains`, `icontains` with negation support (`n` prefix)
  - Example: `?filters=age:gt:5,species:icontains:lion`
- **Dynamic Field Selection**: Client-driven response shaping for optimized data transfer
  - Example: `?fields=name,species,age`
- **Flexible Sorting**: Multi-field sorting with ascending/descending support
  - Example: `?orderBy=age:desc,name:asc`
- **Pagination**: Built-in pagination with configurable page size (max 1000)

#### **Robust Security Implementation**
- **JWT Bearer Token Authentication**: Stateless authentication with 30-day refresh tokens and 30-minute access tokens
- **Resource-Level Authorization**: Custom `ResourceAccessService` ensuring users can only access their own resources

#### **Custom Middleware Pipeline**
- **Response Wrapper Middleware**: Consistent API response format with automatic JSON wrapping
  ```json
  {
    "status": 200,
    "data": { /* actual response */ }
  }
  ```
- **Global Exception Handler**: Centralized error handling with proper HTTP status codes and error messages
- **User Activity Tracking**: Online user monitoring with 30-minute activity windows

#### **Entity Framework Core**
- **Soft Delete Pattern**: Global query filters automatically exclude soft-deleted entities
- **Audit Trail**: Automatic tracking of `CreatedOn`, `ModifiedOn`, and `CreatedBy` fields
- **Cascade Delete Prevention**: Safety mechanism preventing accidental data loss
- **Repository Pattern**: Generic repository implementation with `EfRepository<T>` and `IDeletableEntityRepository<T>`

#### **Advanced Mapping with AutoMapper**
- Automatic DTO to entity mapping reducing manual mapping code
- ProjectTo<T> for efficient database projections
- Consistent data transformation across the application

#### **API Versioning**
- URL segment-based API versioning (`/api/v1/`, `/api/v2/`)
- Version discovery and reporting enabled
- Future-proof API evolution strategy

#### **Swagger/OpenAPI Documentation**
- Interactive API documentation with Swagger UI
- Bearer token authentication testing in browser
- Custom JavaScript enhancements for automatic login when developing
- API version-aware documentation

### Clean Code Practices

#### **SOLID Principles**
- **Single Responsibility**: Each service has a focused purpose
- **Open/Closed**: Generic controllers and services extensible without modification
- **Liskov Substitution**: Interface-based dependency injection
- **Interface Segregation**: Focused interfaces (IRepository, ISeeder, etc.)
- **Dependency Inversion**: Constructor injection throughout

#### **Design Patterns**
- **Repository Pattern**: Data access abstraction
- **Service Layer Pattern**: Business logic separation
- **Middleware Pattern**: Cross-cutting concerns
- **Factory Pattern**: AutoMapper configuration
- **Strategy and Specification Patterns**: Dynamic query building and API responses

## API Features

### Resource Endpoints
All resources follow RESTful conventions with the generic controller pattern:

- `GET /api/v1/{resource}` - List with filtering, sorting, and pagination
- `GET /api/v1/{resource}/{id}` - Get single item
- `POST /api/v1/{resource}` - Create new item
- `PUT /api/v1/{resource}/{id}` - Update existing item
- `DELETE /api/v1/{resource}/{id}` - Delete item (soft delete)

### Available Resources
- `/api/v1/animal` - Wildlife management
- `/api/v1/habitat` - Habitat tracking
- `/api/v1/sighting` - Observation records
- `/api/v1/identity` - Authentication endpoints
- `/api/v1/users` - User management

### Query Examples

```bash
# Get all animals with pagination
GET /api/v1/animal?page=0&size=10

# Filter animals by age and species
GET /api/v1/animal?filters=age:gt:5,species:icontains:lion

# Select specific fields only
GET /api/v1/animal?fields=name,species,age

# Sort by multiple fields
GET /api/v1/animal?orderBy=age:desc,name:asc

# Complex query combining all features
GET /api/v1/animal?page=0&size=20&filters=weight:gt:100&fields=name,species,weight&orderBy=weight:desc
```

## Authentication

The application uses JWT Bearer token authentication:

1. **Register/Login**: Use `/api/v1/identity/register` or `/api/v1/identity/login`
2. **Receive Tokens**: Get access token (30 min) and refresh token (30 days)
3. **Authenticate Requests**: Include `Authorization: Bearer {token}` header
4. **Refresh Token**: Use refresh token endpoint before access token expires

## Key Features

- Complete CRUD operations for all entities
- Advanced query capabilities (filtering, sorting, field selection)
- Secure authentication and authorization
- Image upload and processing for animal profiles
- Real-time online user tracking
- Automatic data validation with custom attributes
- Comprehensive API documentation with Swagger
- Soft delete with audit trails
- Docker containerization for easy deployment
- Cross-platform compatibility

## 📄 License

This project is licensed under the MIT License.
