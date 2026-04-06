using Blooging.Models;
using Microsoft.EntityFrameworkCore;

namespace Blooging.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
                base.OnModelCreating (modelBuilder);

            modelBuilder.Entity<Category>().HasData (
                
                new Category { Id = 1, Name = "Technology", Description = "Posts related to technology and gadgets." },
                 
                new Category { Id = 2, Name = "Travel", Description = "Posts about travel experiences and tips." },

                new Category { Id = 3, Name = "Food", Description = "Posts about recipes, restaurants, and food culture." }
                );


            modelBuilder.Entity<Post>().HasData(

    new Post
    {
        Id = 1,
        Title = "The Future of AI",
        Content = "Artificial Intelligence is rapidly evolving...",
        Author = "Jhon Smith",
        FeaturesImagePath = "img1.png",
        PublishedDate = new DateTime(2026, 1, 1),
        CategoryId = 1
    },

    new Post
    {
        Id = 2,
        Title = "Top 10 Travel Destinations for 2024",
        Content = "Looking for your next travel adventure...",
        Author = "Jhon Smith",
        FeaturesImagePath = "img2.png",
        PublishedDate = new DateTime(2026, 1, 2),
        CategoryId = 2
    },

    new Post
    {
        Id = 3,
        Title = "Delicious Vegan Recipes",
        Content = "Discover delicious vegan recipes...",
        Author = "Jhon Smith",
        FeaturesImagePath = "img3.png",
        PublishedDate = new DateTime(2026, 1, 3),
        CategoryId = 3
    }
);







        }
    }
}
