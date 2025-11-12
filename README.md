# Wildlife Tracker 🦁

A full-stack wildlife tracking and management system built with modern web technologies. This application enables users to track wildlife sightings, manage animal data, and monitor habitats with a robust and scalable architecture.

## 🎯 Overview

Wildlife Tracker is a comprehensive web application designed for wildlife conservation and research. It provides a complete system for recording animal sightings, managing habitat information, and tracking wildlife populations with a user-friendly interface and powerful backend infrastructure.

## ✨ Technical Achievements

### 🏗️ Advanced Backend Architecture

#### **Generic CRUD Controller Pattern**
- Implemented a highly reusable `GenericController<TEntity, TCreateDto, TReadDto, TUpdateDto>` that eliminates code duplication across all resource endpoints
- Automatic CRUD operations for any entity type, reducing boilerplate code by ~80%
- Type-safe operations with compile-time validation

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
- **Role-Based Access Control**: Admin users have elevated permissions across the system
- **Secure Password Requirements**: Configurable password policies via ASP.NET Identity Core

#### **Custom Middleware Pipeline**
- **Response Wrapper Middleware**: Consistent API response format with automatic JSON wrapping
  ```json
  {
    "status": 200,
    "data": { /* actual response */ }
  }
  ```
- **Global Exception Handler**: Centralized error handling with proper HTTP status codes and error messages
- **User Activity Tracking**: Real-time online user monitoring with 30-minute activity windows

#### **Entity Framework Core Excellence**
- **Soft Delete Pattern**: Global query filters automatically exclude soft-deleted entities
- **Audit Trail**: Automatic tracking of `CreatedOn`, `ModifiedOn`, and `CreatedBy` fields
- **Cascade Delete Prevention**: Safety mechanism preventing accidental data loss
- **Repository Pattern**: Generic repository implementation with `EfRepository<T>` and `IDeletableEntityRepository<T>`

#### **Image Processing Service**
- Automatic image conversion to JPEG format with 75% quality compression
- Type validation and secure file handling
- Efficient storage in `wwwroot/animals-images/`
- Integration with ImageSharp library for cross-platform image manipulation

#### **Advanced Mapping with AutoMapper**
- Automatic DTO to entity mapping reducing manual mapping code
- ProjectTo<T> for efficient database projections
- Consistent data transformation across the application

#### **API Versioning**
- URL segment-based API versioning (`/api/v1/`, `/api/v2/`)
- Version discovery and reporting enabled
- Future-proof API evolution strategy

### 🎨 Modern Frontend Stack

#### **Angular 18 Integration**
- Latest Angular framework with standalone components architecture
- Full TypeScript support for type-safe frontend development
- ASP.NET Core SPA proxy for seamless development experience

#### **Development Infrastructure**
- Cross-platform development support (Windows, macOS, Linux)
- HTTPS certificate management via `aspnetcore-https.js`
- Hot module replacement for rapid development

### 🐳 DevOps & Deployment

#### **Docker Containerization**
- Multi-container setup with Docker Compose
- Separate containers for:
  - ASP.NET Core backend
  - Angular frontend
  - SQL Server 2022 database
- Persistent volume storage for database
- Production-ready container configuration

#### **Database Management**
- SQL Server 2022 with Entity Framework Core 9.0
- Automatic database initialization and seeding
- Test data generation via `DummyDataSeeder`
- Role-based seeding for initial admin setup

### 📊 Data Models & Relationships

#### **Rich Domain Model**
- **Animal**: Comprehensive wildlife data (name, species, age, weight, height, images)
- **Sighting**: Wildlife observation records with location and time tracking
- **Habitat**: Ecosystem management with habitat characteristics
- **User**: Extended ASP.NET Identity with custom properties

#### **Relationship Management**
- One-to-many relationships between Animals and Sightings
- Navigation properties with lazy loading support
- Foreign key constraints with referential integrity

### 🔧 Code Quality Features

#### **Custom Validation Attributes**
- `DateOfBirthValidatorAttribute`: Ensures valid age ranges
- `DateNotInFutureValidatorAttribute`: Prevents future date entries
- `E164FormatValidatorAttribute`: International phone number validation
- Custom error messages with proper localization support

#### **Extension Methods**
- `LinqExtensions.Shuffle<T>()`: Efficient random element shuffling
- `UserClaimsExtensions`: Convenient user claim extraction
- Phone number formatting to E.164 international standard

#### **Swagger/OpenAPI Documentation**
- Interactive API documentation with Swagger UI
- Bearer token authentication testing in browser
- Custom JavaScript enhancements for improved UX
- API version-aware documentation

### 🔐 Additional Security Features

#### **Memory-Based Session Management**
- In-memory caching for online user tracking
- Automatic cleanup of stale sessions
- Privacy-conscious implementation without persistent storage

#### **CORS Configuration**
- Secure cross-origin resource sharing
- Credential support for authentication
- Configurable allowed origins

### 📝 Logging & Diagnostics

#### **Comprehensive Logging**
- Console and debug logging providers
- Trace ID and Span ID tracking for distributed tracing
- Configurable log levels per namespace
- ActivityTrackingOptions for request correlation

### 🎯 Clean Code Practices

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
- **Strategy Pattern**: Dynamic query building

## 🚀 Technology Stack

### Backend
- **Framework**: ASP.NET Core 9.0 (.NET 9)
- **Database**: Entity Framework Core 9.0 with SQL Server 2022
- **Authentication**: ASP.NET Core Identity with JWT Bearer tokens
- **Validation**: FluentValidation-style custom attributes
- **Mapping**: AutoMapper 14.0
- **API Documentation**: Swashbuckle (Swagger/OpenAPI)
- **Image Processing**: ImageSharp/SixLabors
- **Phone Validation**: libphonenumber-csharp
- **API Versioning**: Asp.Versioning 8.1

### Frontend
- **Framework**: Angular 18.2
- **Language**: TypeScript 5.5
- **Build System**: Angular CLI
- **Testing**: Jasmine & Karma

### DevOps
- **Containerization**: Docker & Docker Compose
- **Database**: SQL Server 2022 (Linux container)
- **Web Server**: Kestrel

## 🏃 Getting Started

### Prerequisites
- .NET 9.0 SDK
- Node.js 18+ and npm
- Docker Desktop (for containerized deployment)
- SQL Server 2022 or LocalDB (for local development)

### Running with Docker (Recommended)

```bash
# Clone the repository
git clone https://github.com/Lounderr/WildlifeTracker.git
cd WildlifeTracker

# Start all services with Docker Compose
docker-compose up --build

# Access the application
# Backend API: https://localhost:5001
# Frontend: http://localhost:4200
# Swagger UI: https://localhost:5001/swagger
```

### Running Locally

#### Backend
```bash
cd WildlifeTracker
dotnet restore
dotnet run

# API will be available at https://localhost:5001
# Swagger documentation at https://localhost:5001/swagger
```

#### Frontend
```bash
cd wildlifetracker.client
npm install
npm start

# Application will be available at https://localhost:50898
```

## 📚 API Features

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

## 🔒 Authentication

The application uses JWT Bearer token authentication:

1. **Register/Login**: Use `/api/v1/identity/register` or `/api/v1/identity/login`
2. **Receive Tokens**: Get access token (30 min) and refresh token (30 days)
3. **Authenticate Requests**: Include `Authorization: Bearer {token}` header
4. **Refresh Token**: Use refresh token endpoint before access token expires

## 🌟 Key Features

- ✅ Complete CRUD operations for all entities
- ✅ Advanced query capabilities (filtering, sorting, field selection)
- ✅ Secure authentication and authorization
- ✅ Image upload and processing for animal profiles
- ✅ Real-time online user tracking
- ✅ Automatic data validation with custom attributes
- ✅ Comprehensive API documentation with Swagger
- ✅ Soft delete with audit trails
- ✅ Docker containerization for easy deployment
- ✅ Cross-platform compatibility

## 📄 License

This project is licensed under the MIT License - see the [LICENSE.txt](LICENSE.txt) file for details.

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## 📧 Contact

For questions or support, please open an issue on the GitHub repository.

---

**Built with ❤️ using ASP.NET Core and Angular**
