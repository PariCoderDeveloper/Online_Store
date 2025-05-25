
[![Build Status](https://github.com/PariCoderDeveloper/Online_Store/actions/workflows/dotnet.yml/badge.svg)](https://github.com/PariCoderDeveloper/Online_Store/actions)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

# Sperolina Online Store

A **Clean Architecture**–based e-commerce platform leveraging **ASP.NET Core 6**, **Razor Pages**, **Entity Framework Core 6**, **MediatR**, and **FluentValidation**. The solution is divided into five layers to enforce separation of concerns, facilitate TDD, and enable microservices extraction.

---

## 📋 Table of Contents

1. [Solution Structure](#solution-structure)
2. [Core Concepts](#core-concepts)
3. [Domain Model](#domain-model)
4. [Application Layer](#application-layer)
5. [Persistence Layer](#persistence-layer)
6. [Presentation Layer](#presentation-layer)
7. [Configuration & Startup](#configuration--startup)
8. [Database & Migrations](#database--migrations)
9. [Sample Usage](#sample-usage)
10. [Testing & CI/CD](#testing--cicd)
11. [Deployment](#deployment)
12. [Contributing](#contributing)
13. [License](#license)

---

## 🗂 Solution Structure

```
Online_Store
├── Shop.Presentation        # Razor Pages UI (ASP.NET Core Web)
│   ├── Pages
│   ├── ViewModels
│   └── Startup.cs
├── Shop.Application         # CQRS handlers, DTOs, Validators
│   ├── Commands
│   │   └── CreateProductCommand.cs
│   ├── Queries
│   │   └── GetProductByIdQuery.cs
│   └── Validators
├── Shop.Domain              # Entities, ValueObjects, Interfaces
│   ├── Entities
│   │   ├── Product.cs
│   │   ├── Category.cs
│   │   └── Order.cs
│   ├── ValueObjects
│   │   └── Money.cs
│   └── Interfaces
│       └── IProductRepository.cs
├── Shop.Persistence         # EF Core DbContext, Repositories, Migrations
│   ├── Configurations       # IEntityTypeConfiguration<T> implementations
│   ├── Repositories
│   └── ApplicationDbContext.cs
└── Shop.Ccommon             # Shared middleware, constants, extensions
```

> **Note**: `ClassLibrary1` is deprecated — merge its utilities into `Shop.Ccommon` or remove entirely.

## 🧩 Core Concepts

* **Clean Architecture**: Layers depend inward only, enforcing `Presentation → Application → Domain → Persistence`.
* **CQRS with MediatR**: Segregate `Commands` (state changes) from `Queries` (reads).
* **Entity Framework Core**: Code-First approach with `IEntityTypeConfiguration` for fluent model configuration.
* **FluentValidation**: Strongly-typed validators for each command/request.
* **Dependency Injection**: All services registered in `Startup.ConfigureServices`.

## 🏷 Domain Model

```csharp
public class Product : BaseEntity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Money Price { get; private set; }
    public int Stock { get; private set; }
    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; }
}

public struct Money
{
    public decimal Amount { get; }
    public string Currency { get; }
    public Money(decimal amount, string currency) { Amount = amount; Currency = currency; }
}

public class Category : BaseEntity { public string Title { get; private set; } }
```

* **BaseEntity** holds `Id`, `CreatedAt`, `UpdatedAt`.
* Relationships configured via Fluent API in `Configurations/ProductConfiguration`.

## 🚀 Application Layer

* **Commands** (e.g., `CreateProductCommand : IRequest<Guid>`)
* **Queries** (e.g., `GetProductByIdQuery : IRequest<ProductDto>`)
* **Handlers** implement `IRequestHandler<,>`.
* **DTOs** decouple domain from UI.
* **Validators** (`CreateProductCommandValidator` uses FluentValidation rules).

<details>
<summary>Example: CreateProductCommand</summary>
```csharp
public class CreateProductCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Currency { get; set; }
    public int Stock { get; set; }
    public Guid CategoryId { get; set; }
}

public class CreateProductCommandHandler : IRequestHandler\<CreateProductCommand, Guid>
{
private readonly IProductRepository \_repo;
public CreateProductCommandHandler(IProductRepository repo) => \_repo = repo;

```
public async Task<Guid> Handle(CreateProductCommand cmd, CancellationToken ct)
{
    var product = new Product(cmd.Name, cmd.Description,
        new Money(cmd.Price, cmd.Currency), cmd.Stock, cmd.CategoryId);
    await _repo.AddAsync(product);
    await _repo.UnitOfWork.SaveChangesAsync(ct);
    return product.Id;
}
```

}

````
</details>

## 💾 Persistence Layer
- **ApplicationDbContext** inherits `DbContext`.
- Fluent API configurations in `Configurations/` folder:
  ```csharp
  public class ProductConfiguration : IEntityTypeConfiguration<Product>
  {
      public void Configure(EntityTypeBuilder<Product> builder)
      {
          builder.HasKey(p => p.Id);
          builder.OwnsOne(p => p.Price);
          builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
          // ...
      }
  }
````

* **Repositories** implement domain interfaces; e.g., `EfProductRepository`.

## 💻 Presentation Layer

* **Razor Pages** under `Pages/Products`, `Pages/Orders`.
* **PageModel** classes inject `IMediator` to send commands/queries.
* Auto-generated **TagHelpers** for common controls.
* **\_Layout.cshtml** includes Bootstrap and site navigation.

```csharp
public class CreateModel : PageModel
{
    private readonly IMediator _mediator;
    public CreateModel(IMediator mediator) => _mediator = mediator;
    [BindProperty] public CreateProductCommand Input { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();
        var id = await _mediator.Send(Input);
        return RedirectToPage("Details", new { id });
    }
}
```

## ⚙️ Configuration & Startup

In `Shop.Presentation/Startup.cs`:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddRazorPages();
    services.AddDbContext<ApplicationDbContext>(opts =>
        opts.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    services.AddMediatR(typeof(CreateProductCommand));
    services.AddValidatorsFromAssembly(typeof(CreateProductCommandValidator).Assembly);
    services.AddScoped<IProductRepository, EfProductRepository>();
    services.AddCors();
}

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.UseExceptionHandling(); // Custom middleware
    app.UseRouting();
    app.UseAuthorization();
    app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });
}
```

## 🗄 Database & Migrations

```bash
cd Shop.Persistence
dotnet ef migrations add InitialCreate
dotnet ef database update
```

* **Migration files** in `Shop.Persistence/Migrations`.
* **Seeding** in `ApplicationDbContext.OnModelCreating`.

## 📑 Sample Usage

1. **Create a Category** via SQL seed or UI.
2. **Add a Product**:

   ```bash
   POST /products
   Content-Type: application/json
   {
     "name": "Laptop",
     "description": "High-end gaming laptop",
     "price": 1499.99,
     "currency": "USD",
     "stock": 10,
     "categoryId": "<existing-guid>"
   }
   ```
3. **View Products** at `/Products/Index`.

## 🧪 Testing & CI/CD

* **Unit Tests**: Scaffold `Shop.Tests` (xUnit + Moq). Example:

  ```csharp
  [Fact]
  public async Task CreateProduct_SavesToRepository()
  { /* Arrange, Act, Assert */ }
  ```
* **GitHub Actions** workflow (`.github/workflows/dotnet.yml`) runs `dotnet test` on PRs.

## 🚀 Deployment

* **Docker**: Add `Dockerfile` with multi-stage build.
* **Kubernetes**: Provide Helm charts for microservice extraction.
* **Cloud**: Deploy via Azure App Service or AWS EKS.

## 🤝 Contributing

1. Fork and clone.
2. Create branch: `feature/awesome`
3. Commit, push, and open PR.
4. Ensure all tests pass.

## 📄 License

Distributed under the **MIT License**. See [LICENSE](LICENSE).

