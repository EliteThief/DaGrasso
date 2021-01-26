using Microsoft.Extensions.DependencyInjection;
using DaGrasso.Models;
using System;
using System.Linq;



namespace DaGrasso
{
    public class DbInitializer
    {
        public static void Seed(IServiceProvider applicationBuilder)
        {
            AppDbContext context = applicationBuilder.GetRequiredService<AppDbContext>();

            Topping sosPomidorowy = new Topping { Name = "Sos Pomidorowy" };
            Topping Mozarella = new Topping { Name = "Mozarella" };
            Topping Pieczarki = new Topping { Name = "Pieczarki" };
            Topping Szynka = new Topping { Name = "Szynka" };
            Topping Kurczak = new Topping { Name = "Kurczak" };
            Topping Salami = new Topping { Name = "Salami" };
            Topping Boczek = new Topping { Name = "Boczek" };
            Topping Oliwki = new Topping { Name = "Oliwki" };
            Topping Cukinia = new Topping { Name = "Cukinia" };
            Topping Ananas = new Topping { Name = "Ananas" };

            if (!context.Toppings.Any())
            {
                context.Toppings.Add(sosPomidorowy);
                context.Toppings.Add(Salami);
                context.Toppings.Add(Mozarella);
                context.Toppings.Add(Pieczarki);
                context.Toppings.Add(Szynka);
                context.Toppings.Add(Kurczak);
                context.Toppings.Add(Boczek);
                context.Toppings.Add(Oliwki);
                context.Toppings.Add(Cukinia);
                context.Toppings.Add(Ananas);
            }
            context.SaveChanges();
            if (!context.Pizzas.Any())
            {
                context.Pizzas.AddRange(
                new Pizza
                {
                    Name = "Margherita",
                    Price = 18.0,
                    ImageURL = "Margherita.png",
                },
                new Pizza
                {
                    Name = "Funghi",
                    Price = 20.00,
                    ImageURL = "Funghi.png",
                },
                new Pizza
                {
                    Name = "Cotto",
                    Price = 20.00,
                    ImageURL = "Cotto.png",
                },
                new Pizza
                {
                    Name = "Hawaii",
                    Price = 20.00,
                    ImageURL = "Hawaii.png",
                },
                new Pizza
                {
                    Name = "Verona",
                    Price = 20.00,
                    ImageURL = "Verona.png",
                });
                context.SaveChanges();
            }
            if (!context.PizzaToppings.Any())
            {
                context.PizzaToppings.AddRange(
                new PizzaToppings
                {
                    PizzaId = 1,
                    ToppingId = 1
                },
                new PizzaToppings
                {
                    PizzaId = 1,
                    ToppingId = 3
                },
                new PizzaToppings
                {
                    PizzaId = 2,
                    ToppingId = 1
                },
                new PizzaToppings
                {
                    PizzaId = 2,
                    ToppingId = 3
                },
                new PizzaToppings
                {
                    PizzaId = 3,
                    ToppingId = 1
                },
                new PizzaToppings
                {
                    PizzaId = 3,
                    ToppingId = 3
                },
                new PizzaToppings
                {
                    PizzaId = 4,
                    ToppingId = 1
                },
                new PizzaToppings
                {
                    PizzaId = 4,
                    ToppingId = 3
                },
                new PizzaToppings
                {
                    PizzaId = 5,
                    ToppingId = 1
                },
                new PizzaToppings
                {
                    PizzaId = 5,
                    ToppingId = 3
                },
                new PizzaToppings
                {
                    PizzaId = 2,
                    ToppingId = 4
                },
                new PizzaToppings
                {
                    PizzaId = 3,
                    ToppingId = 5
                },
                new PizzaToppings
                {
                    PizzaId = 4,
                    ToppingId = 5
                },
                new PizzaToppings
                {
                    PizzaId = 4,
                    ToppingId = 10
                },
                new PizzaToppings
                {
                    PizzaId = 5,
                    ToppingId = 2
                });
                context.SaveChanges();
            }



            context.SaveChanges();
        }
    }
}


