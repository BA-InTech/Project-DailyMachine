using System;
using OfficeOpenXml;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// NOTE:
// Pastikan ApplicationDbContext berada di namespace backend.Data
// dan EPPlus sudah diinstall (EPPlus package ada di backend.csproj).

var builder = WebApplication.CreateBuilder(args);

// --- EPPlus license (panggil sekali) ---
// Gunakan namespace lengkap supaya tidak ambiguous di editor/OmniSharp
OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

// --- Services ---
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database (SQLite) - fallback kalau connection string belum ada
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Data Source=dailymachine.db";

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString)
);

// CORS (Baca dari appsettings)
builder.Services.AddCors(options =>
{
    // Ambil daftar origin yang diizinkan dari appsettings.json
    var allowedOrigins = builder.Configuration.GetSection("CorsSettings:AllowedOrigins").Get<string[]>();

    if (allowedOrigins == null || allowedOrigins.Length == 0)
    {
        // Fallback jika tidak ada setting di appsettings (minimal izinkan localhost)
        allowedOrigins = ["http://localhost:3000"];
        Console.WriteLine("[Warning] CORS AllowedOrigins not found in appsettings. Allowing default: http://localhost:3000");
    }

    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins(allowedOrigins) // <-- Baca dari variabel allowedOrigins
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// ===================================================================
// BLOK CORS KEDUA (YANG DUPLIKAT) SUDAH DIHAPUS DARI SINI
// ===================================================================

var app = builder.Build();

// --- HTTP pipeline ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();

// Urutan routing -> cors -> auth penting
app.UseRouting();
app.UseCors("AllowReactApp"); // <-- Ini akan menggunakan "AllowReactApp" yang BENAR
app.UseAuthorization();

app.MapControllers();

// Jalankan app (ubah port jika perlu)
app.Run("http://0.0.0.0:5098");