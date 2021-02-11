using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Joe_s_Pizza.Models
{
    public class PizzaDbContext : IdentityDbContext
    {
        public PizzaDbContext(DbContextOptions<PizzaDbContext> options)
            : base(options)
        {

        }

        public DbSet<PizzaModel> pizzas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<PizzaModel>().HasData(
                new PizzaModel { Pno = 1, Image = "/cheese.jpg", PizzaName = "Cheese Margherita", Size = "Regular/Medium", Price = 300 },
                new PizzaModel { Pno = 2, Image = "/barbeque.jpg", PizzaName = "Barbeque", Size = "Regular/Medium", Price = 400 },
                new PizzaModel { Pno = 3, Image = "/pepperoni.jpg", PizzaName = "Pepperoni", Size = "Regular/Medium", Price = 350 },
                new PizzaModel { Pno = 4, Image = "/sausage.jpg", PizzaName = "Sausage", Size = "Regular/Medium", Price = 450 },
                new PizzaModel { Pno = 5, Image = "/vegetable.jpg", PizzaName = "Vegetable", Size = "Regular/Medium", Price = 250 },
                new PizzaModel { Pno = 6, Image = "/vegsupreme.jpg", PizzaName = "Vegsupreme", Size = "Regular/Medium", Price = 300 }
                );
        }
    }
}