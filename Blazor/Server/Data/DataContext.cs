using Blazor.Shared;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Server.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options):base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Title = "Title1",
                Description = "Description 1",
                ImageUrl = "https://images.unsplash.com/photo-1575936123452-b67c3203c357?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8aW1hZ2V8ZW58MHx8MHx8&w=1000&q=80",
                Price = 10.2m
            },
                new Product
                {
                    Id = 2,
                    Title = "Title2",
                    Description = "Description 2",
                    ImageUrl = "https://www.shutterstock.com/image-photo/three-asses-one-head-up-260nw-1565329723.jpg",
                    Price = 10.92m
                },
                new Product
                {
                    Id = 3,
                    Title = "Title3",
                    Description = "Description 3",
                    ImageUrl = "https://tinypng.com/images/social/website.jpg",
                    Price = 7.2m
                },
                new Product
                {
                    Id = 4,
                    Title = "Title4",
                    Description = "Description 4",
                    ImageUrl = "https://avatars.mds.yandex.net/i?id=84dbd50839c3d640ebfc0de20994c30d-4473719-images-taas-consumers&n=27&h=480&w=480",
                    Price = 9.34m
                }
            );
    }
}
