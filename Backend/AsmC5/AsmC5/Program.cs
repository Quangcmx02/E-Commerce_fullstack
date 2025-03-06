using System.Text;
using System.Text.Json.Serialization;
using AsmC5;
using AsmC5.Context;
using AsmC5.Mappings;
using AsmC5.Models;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);
// Gọi phương thức mở rộng để đăng ký các service
// Thêm chính sách CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                 .AllowAnyMethod()  // Cho phép tất cả phương thức (GET, POST, PUT, DELETE)
                .AllowAnyHeader() // Cho phép tất cả header
                .AllowCredentials() // Nếu dùng Cookie hoặc JWT
                .WithExposedHeaders("Authorization");
        });
});
builder.Services.AddInfrastructureServices();
// Thêm kết nối cơ sở dữ liệu
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Cấu hình Identity (Chỉ giữ lại một lần)
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Thêm AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Thêm xác thực JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
.AddCookie("Cookies") // Cookie authentication scheme
.AddGoogle(options =>
{
    var googleAuth = builder.Configuration.GetSection("Authentication:Google");
    options.ClientId = googleAuth["ClientId"];
    options.ClientSecret = googleAuth["ClientSecret"];
    options.CallbackPath = "/signin-google"; // Đường dẫn callback (khớp với Google Console)
})
.AddJwtBearer(options =>
{
    var jwtKey = builder.Configuration["JwtSettings:SecurityKey"];
    if (string.IsNullOrEmpty(jwtKey))
    {
        throw new Exception("JWT SecurityKey is missing in appsettings.json");
    }

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDistributedMemoryCache();
// Thêm các dịch vụ API
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

// Thêm dịch vụ Swagger
builder.Services.AddSession(options =>
{

    options.IdleTimeout = TimeSpan.FromSeconds(90);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AsmC5 API",
        Version = "v1",
        Description = "API for AsmC5 Project",
        Contact = new OpenApiContact
        {
            Name = "Tran Xuan Quang",
            Email = "your-email@example.com"
        }
    });
});
var app = builder.Build();
// Sử dụng Swagger nếu ở môi trường phát triển
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AsmC5 API v1");
        c.RoutePrefix = "swagger"; // Truy cập Swagger tại /swagger
    });
}
app.UseCors("AllowAll");
app.UseSession();
app.UseAuthentication(); // Middleware Authentication
app.UseAuthorization();  // Middleware Authorization

app.MapControllers();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    
    await SeedComboFoodItemDetails(context);

}

app.Run();
async Task SeedComboFoodItemDetails(ApplicationDbContext context)
{
    if (!context.ComboFoodItemDetails.Any()) // Kiểm tra nếu chưa có dữ liệu
    {
        var random = new Random();
        var comboFoodItemDetails = new List<ComboFoodItemDetail>();

        for (int i = 1; i <= 15; i++)
        {
            comboFoodItemDetails.Add(new ComboFoodItemDetail
            {
                ComboFoodItemId = i,
                QuantityFoodInCombo = random.Next(1, 11) // Số lượng từ 1 đến 10
            });
        }

        await context.ComboFoodItemDetails.AddRangeAsync(comboFoodItemDetails);
        await context.SaveChangesAsync();
    }
}

async Task SeedComboFoodItems(ApplicationDbContext context)
{
    if (!context.ComboFoodItems.Any()) // Kiểm tra nếu chưa có dữ liệu
    {
        var comboFoodItems = new List<ComboFoodItem>
        {
            new ComboFoodItem { FoodItemID = 2, ComboID = 1 },
            new ComboFoodItem { FoodItemID = 3, ComboID = 1 },

            new ComboFoodItem { FoodItemID = 4, ComboID = 2 },
            new ComboFoodItem { FoodItemID = 5, ComboID = 2 },

            new ComboFoodItem { FoodItemID = 6, ComboID = 3 },
            new ComboFoodItem { FoodItemID = 7, ComboID = 3 },

            new ComboFoodItem { FoodItemID = 8, ComboID = 4 },
            new ComboFoodItem { FoodItemID = 9, ComboID = 4 },

            new ComboFoodItem { FoodItemID = 10, ComboID = 5 },
            new ComboFoodItem { FoodItemID = 11, ComboID = 5 },

            new ComboFoodItem { FoodItemID = 12, ComboID = 6 },
            new ComboFoodItem { FoodItemID = 13, ComboID = 6 },

            new ComboFoodItem { FoodItemID = 14, ComboID = 7 },
            new ComboFoodItem { FoodItemID = 10, ComboID = 7 },

            new ComboFoodItem { FoodItemID = 11, ComboID = 8 },
            new ComboFoodItem { FoodItemID = 12, ComboID = 8 },

            new ComboFoodItem { FoodItemID = 14, ComboID = 9 },
            new ComboFoodItem { FoodItemID = 15, ComboID = 9 },

            new ComboFoodItem { FoodItemID = 5, ComboID = 10 },
            new ComboFoodItem { FoodItemID = 2, ComboID = 10 }
        };

        await context.ComboFoodItems.AddRangeAsync(comboFoodItems);
        await context.SaveChangesAsync();
    }
}

async Task SeedCombos(ApplicationDbContext context)
{
    if (!context.Combos.Any()) // Kiểm tra nếu chưa có dữ liệu
    {
        var combos = new List<Combo>
        {
            new Combo { Name = "Family Feast", Description = "A meal for the whole family", Price = 25.99m, CreatedDate = DateTime.Now, ImagePath = "https://i.pinimg.com/236x/3b/98/f1/3b98f1ae496ff49ec36abfff07a1bd6a.jpg", IsAvailable = true },
            new Combo { Name = "Snack Time", Description = "Perfect snacks for your break", Price = 15.99m, CreatedDate = DateTime.Now, ImagePath = "https://i.pinimg.com/videos/thumbnails/originals/94/b9/37/94b9374c0522f3dc8f1cdd088baf5f49.0000000.jpg", IsAvailable = true },
            new Combo { Name = "Cheese Lovers", Description = "Cheese-loaded delights", Price = 19.99m, CreatedDate = DateTime.Now, ImagePath = "https://i.pinimg.com/474x/11/fd/53/11fd530c7f7d2814f036d0a685a9dd46.jpg", IsAvailable = true },
            new Combo { Name = "Spicy Treat", Description = "A spicy combo for heat lovers", Price = 21.49m, CreatedDate = DateTime.Now, ImagePath = "https://i.pinimg.com/236x/76/3c/91/763c91800f1f0c34a25a112770302d86.jpg", IsAvailable = true },
            new Combo { Name = "Classic Duo", Description = "A classic meal for two", Price = 18.99m, CreatedDate = DateTime.Now, ImagePath = "https://i.pinimg.com/236x/b0/31/f8/b031f8d8c09a5f2d271e73f346d81021.jpg", IsAvailable = true },
            new Combo { Name = "Burger & Fries", Description = "A perfect combo of burger and fries", Price = 14.99m, CreatedDate = DateTime.Now, ImagePath = "https://i.pinimg.com/236x/92/8a/a7/928aa760901e61b094965ded43d78b14.jpg", IsAvailable = true },
            new Combo { Name = "Ultimate BBQ", Description = "BBQ feast for meat lovers", Price = 27.99m, CreatedDate = DateTime.Now, ImagePath = "https://i.pinimg.com/474x/93/17/35/931735b5123894b35dc8c2e150c6a2ef.jpg", IsAvailable = true },
            new Combo { Name = "Seafood Delight", Description = "Fresh and tasty seafood", Price = 30.99m, CreatedDate = DateTime.Now, ImagePath = "https://i.pinimg.com/474x/65/2d/96/652d961a2ded8d6f76f21e2740d2b5de.jpg", IsAvailable = true },
            new Combo { Name = "Veggie Lovers", Description = "A healthy veggie meal", Price = 17.49m, CreatedDate = DateTime.Now, ImagePath = "https://i.pinimg.com/236x/a8/05/d7/a805d79825b364f47c60ccc67eef3ea0.jpg", IsAvailable = true },
            new Combo { Name = "Pizza Party", Description = "Pizza feast for the whole gang", Price = 29.99m, CreatedDate = DateTime.Now, ImagePath = "https://i.pinimg.com/236x/18/a6/84/18a6848c598422a23eb76ec62519cd34.jpg", IsAvailable = true },
            new Combo { Name = "Fried Chicken Feast", Description = "Crispy fried chicken combo", Price = 22.99m, CreatedDate = DateTime.Now, ImagePath = "https://i.pinimg.com/474x/95/84/0e/95840e14eb2eb9c675ccadcfe2babb27.jpg", IsAvailable = true },
            new Combo { Name = "Sushi Set", Description = "Delicious sushi combo", Price = 26.99m, CreatedDate = DateTime.Now, ImagePath = "https://i.pinimg.com/474x/b8/0b/18/b80b1841e04c74c4def2d5a4fe82728e.jpg", IsAvailable = true },
            new Combo { Name = "Sweet Treat", Description = "Desserts for your sweet tooth", Price = 13.99m, CreatedDate = DateTime.Now, ImagePath = "https://i.pinimg.com/474x/93/17/35/931735b5123894b35dc8c2e150c6a2ef.jpg", IsAvailable = true },
            new Combo { Name = "Breakfast Combo", Description = "Perfect breakfast meal", Price = 12.99m, CreatedDate = DateTime.Now, ImagePath = "https://i.pinimg.com/474x/65/2d/96/652d961a2ded8d6f76f21e2740d2b5de.jpg", IsAvailable = true },
            new Combo { Name = "Dinner Special", Description = "A special dinner set", Price = 24.99m, CreatedDate = DateTime.Now, ImagePath = "https://i.pinimg.com/236x/76/3c/91/763c91800f1f0c34a25a112770302d86.jpg", IsAvailable = true }
        };

        await context.Combos.AddRangeAsync(combos);
        await context.SaveChangesAsync();
    }
}

async Task SeedFoodItems(ApplicationDbContext context)
{
    if (!context.FoodItems.Any()) // Kiểm tra nếu chưa có dữ liệu
    {
        var foodItems = new List<FoodItem>
        {
            new FoodItem { Name = "BBQ Burger", Description = "Grilled burger with BBQ sauce", Price = 6.49m, IsAvailable = true, Quantity = 50, CreatedDate = DateTime.Now, ImagePath = "https://i.pinimg.com/474x/fe/ce/1a/fece1a71efad3250026e98820eadc788.jpg", CategoryID = 1},
            new FoodItem { Name = "Crispy Chicken", Description = "Spicy crispy fried chicken", Price = 7.49m, IsAvailable = true, Quantity = 40, CreatedDate = DateTime.Now, ImagePath = "https://i.pinimg.com/474x/be/00/49/be00496c3ea766e0c3e6f5988cc1582b.jpg", CategoryID = 2 },
            new FoodItem { Name = "Hawaiian Pizza", Description = "Pizza with pineapple and ham", Price = 9.99m, IsAvailable = true, Quantity = 30, CreatedDate = DateTime.Now, ImagePath = "https://i.pinimg.com/474x/c4/94/5f/c4945f750dc070fa1c3509df93863735.jpg", CategoryID = 3 },
            new FoodItem { Name = "Curly Fries", Description = "Crispy seasoned curly fries", Price = 3.99m, IsAvailable = true, Quantity = 100, CreatedDate = DateTime.Now, ImagePath = "https://i.pinimg.com/474x/8b/7b/2d/8b7b2d3e27567483cc3064660ff8c4d1.jpg", CategoryID = 4 },
            new FoodItem { Name = "Spicy Hotdog", Description = "Hotdog with jalapeno and cheese", Price = 5.49m, IsAvailable = true, Quantity = 70, CreatedDate = DateTime.Now, ImagePath = "https://i.pinimg.com/474x/8b/7b/2d/8b7b2d3e27567483cc3064660ff8c4d1.jpg", CategoryID = 5 },
            new FoodItem { Name = "Club Sandwich", Description = "Multi-layered sandwich with turkey", Price = 6.99m, IsAvailable = true, Quantity = 60, CreatedDate = DateTime.Now, ImagePath = "https://i.pinimg.com/736x/46/71/88/467188b3c48f4a0887cd70776e1de817.jpg", CategoryID = 6 },
            new FoodItem { Name = "Double Cheese Burger", Description = "Burger with double cheese layers", Price = 7.99m, IsAvailable = true, Quantity = 50, CreatedDate = DateTime.Now, ImagePath = "https://i.pinimg.com/474x/fe/ce/1a/fece1a71efad3250026e98820eadc788.jpg", CategoryID = 7 },
            new FoodItem { Name = "Chicken Popcorn", Description = "Bite-sized crispy chicken", Price = 4.99m, IsAvailable = true, Quantity = 80, CreatedDate = DateTime.Now, ImagePath = "https://i.pinimg.com/474x/be/00/49/be00496c3ea766e0c3e6f5988cc1582b.jpg", CategoryID = 8 },
            new FoodItem { Name = "Margherita Pizza", Description = "Classic Italian pizza with basil", Price = 8.49m, IsAvailable = true, Quantity = 30, CreatedDate = DateTime.Now, ImagePath = "https://i.pinimg.com/474x/c4/94/5f/c4945f750dc070fa1c3509df93863735.jpg", CategoryID = 9 },
            new FoodItem { Name = "Loaded Fries", Description = "Fries with cheese and bacon", Price = 5.99m, IsAvailable = true, Quantity = 100, CreatedDate = DateTime.Now, ImagePath = "https://i.pinimg.com/474x/8b/7b/2d/8b7b2d3e27567483cc3064660ff8c4d1.jpg", CategoryID = 1 },
            new FoodItem { Name = "Chili Cheese Hotdog", Description = "Hotdog with chili and cheese", Price = 6.49m, IsAvailable = true, Quantity = 70, CreatedDate = DateTime.Now, ImagePath = "https://i.pinimg.com/474x/8b/7b/2d/8b7b2d3e27567483cc3064660ff8c4d1.jpg", CategoryID = 2 },
            new FoodItem { Name = "BLT Sandwich", Description = "Bacon, lettuce, tomato sandwich", Price = 5.99m, IsAvailable = true, Quantity = 60, CreatedDate = DateTime.Now, ImagePath = "https://i.pinimg.com/736x/46/71/88/467188b3c48f4a0887cd70776e1de817.jpg", CategoryID = 3 },
            new FoodItem { Name = "Mushroom Swiss Burger", Description = "Burger with mushrooms and Swiss cheese", Price = 8.99m, IsAvailable = true, Quantity = 50, CreatedDate = DateTime.Now, ImagePath = "https://i.pinimg.com/474x/fe/ce/1a/fece1a71efad3250026e98820eadc788.jpg", CategoryID = 4 },
            new FoodItem { Name = "Honey Butter Chicken", Description = "Fried chicken with honey butter sauce", Price = 7.99m, IsAvailable = true, Quantity = 40, CreatedDate = DateTime.Now, ImagePath = "https://i.pinimg.com/474x/be/00/49/be00496c3ea766e0c3e6f5988cc1582b.jpg", CategoryID = 5 },
            new FoodItem { Name = "Buffalo Chicken Pizza", Description = "Pizza with spicy buffalo chicken", Price = 10.49m, IsAvailable = true, Quantity = 30, CreatedDate = DateTime.Now, ImagePath = "https://i.pinimg.com/474x/c4/94/5f/c4945f750dc070fa1c3509df93863735.jpg", CategoryID = 2 }
        };

        await context.FoodItems.AddRangeAsync(foodItems);
        await context.SaveChangesAsync();
    }
}

async Task SeedCategories(ApplicationDbContext context)
{
    if (!context.Categories.Any())
    {
        var categories = new List<Category>
        {
            new Category { Name = "Burgers", Description = "Delicious grilled or fried burgers." },
            new Category { Name = "Fried Chicken", Description = "Crispy and juicy fried chicken." },
            new Category { Name = "Pizza", Description = "Classic and innovative pizzas." },
            new Category { Name = "French Fries", Description = "Golden crispy French fries." },
            new Category { Name = "Hotdogs", Description = "Tasty and quick hotdogs." },
            new Category { Name = "Sandwiches", Description = "Fresh and flavorful sandwiches." },
            new Category { Name = "Tacos & Burritos", Description = "Mexican-style tacos and burritos." },
            new Category { Name = "Quick Noodles & Pasta", Description = "Fast and delicious noodles & pasta." },
            new Category { Name = "Other Snacks & Drinks", Description = "Various snacks and refreshing drinks." }
        };

        await context.Categories.AddRangeAsync(categories);
        await context.SaveChangesAsync();
    }
}
async Task SeedData(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
{
    string[] roles = { "Admin", "User" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    var users = new List<ApplicationUser>
    {
        new ApplicationUser
        {
            UserName = "admin1",
            Email = "admin1@admin.com",
            FirstName = "Admin",
            LastName = "One",
            DateOfBirth = new DateTime(1990, 1, 1),
            EmailConfirmed = true
        },
        new ApplicationUser
        {
            UserName = "admin2",
            Email = "admin2@admin.com",
            FirstName = "Admin",
            LastName = "Two",
            DateOfBirth = new DateTime(1991, 2, 2),
            EmailConfirmed = true
        },
        new ApplicationUser
        {
            UserName = "user1",
            Email = "user1@user.com",
            FirstName = "User",
            LastName = "One",
            DateOfBirth = new DateTime(1995, 3, 3),
            EmailConfirmed = true
        },
        new ApplicationUser
        {
            UserName = "user2",
            Email = "user2@user.com",
            FirstName = "User",
            LastName = "Two",
            DateOfBirth = new DateTime(1996, 4, 4),
            EmailConfirmed = true
        }
    };

    string password = "P@ssword123";

    foreach (var user in users)
    {
        var existingUser = await userManager.FindByEmailAsync(user.Email);
        if (existingUser == null)
        {
            var result = await userManager.CreateAsync(user, password);

            // Chỉ thêm role nếu user được tạo thành công
            if (result.Succeeded)
            {
                string role = user.Email.Contains("admin") ? "Admin" : "User";
                await userManager.AddToRoleAsync(user, role);
            }
            else
            {
                // Log lỗi nếu không thể tạo user
                Console.WriteLine($"Failed to create user {user.Email}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
        }
    }
}

