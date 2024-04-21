using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data;

public class DataContext(DbContextOptions options): DbContext(options)
{
    public DbSet<Kitten> Kittens { get; set; }
}