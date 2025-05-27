using Microsoft.EntityFrameworkCore;
using QuanLyXe.Models; // namespace chứa ApplicationDbContext

var builder = WebApplication.CreateBuilder(args);

// Kết nối cơ sở dữ liệu
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // bảo mật HSTS
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // ✅ Dùng để phục vụ file tĩnh (CSS, JS, hình ảnh)

app.UseRouting();

app.UseAuthorization();

// Cấu hình route mặc định
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
