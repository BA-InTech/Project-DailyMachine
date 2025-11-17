using System;
using OfficeOpenXml;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// EPPlus license
ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

var builder = WebApplication.CreateBuilder(args);

// ------------------------ Services ------------------------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// UBAH DISINI: Ganti dari SQLite ke PostgreSQL
// Pastikan Anda mendapatkan connection string dari Environment Variables Railway,
// JANGAN gunakan fallback ke file database lokal.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Jika connection string kosong, lempar error agar deploy gagal & Anda tahu ada masalah
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
}

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    // UBAH DISINI: Ganti dari UseSqlite ke UseNpgsql
    options.UseNpgsql(connectionString) 
);

// CORS
var allowedOrigins = builder.Configuration.GetSection("CorsSettings:AllowedOrigins").Get<string[]>()
                     ?? new string[] { "http://localhost:3000" };

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins(allowedOrigins)
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// ------------------------ Middleware ------------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();
app.UseCors("AllowReactApp");
app.UseAuthorization();

app.MapControllers();

// UBAH DISINI: Tambahkan ini untuk React Router
// Ini harus setelah MapControllers() tapi sebelum Run()
// Ini akan mengirim index.html untuk rute apa pun yang tidak dikenal (seperti /login, /dashboard)
app.MapFallbackToFile("index.html");


// ------------------------ Run ------------------------
// Bagian ini sudah SEMPURNA. Tidak perlu diubah.
var port = Environment.GetEnvironmentVariable("PORT") ?? "5098";
app.Run($"http://0.0.0.0:{port}");
