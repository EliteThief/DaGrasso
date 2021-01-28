using Microsoft.Extensions.DependencyInjection;
using DaGrasso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using DaGrasso.Data.Models;
using Microsoft.AspNetCore.Identity;


namespace DaGrasso
{
    public class DbInitializer
    {
        public static async System.Threading.Tasks.Task SeedAsync(IServiceProvider applicationBuilder)
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


            Pizza Margherita = new Pizza
            {
                Name = "Margherita",
                Price = 18.0,
                ImageURL = "Margherita.png",
            };

              Pizza Funghi = new Pizza
              {
                  Name = "Funghi",
                  Price = 20.00,
                  ImageURL = "Funghi.png",
              };
              Pizza Cotto = new Pizza
              {
                  Name = "Cotto",
                  Price = 20.00,
                  ImageURL = "Cotto.png",
              };
              Pizza Hawaii = new Pizza
              {
                  Name = "Hawaii",
                  Price = 20.00,
                  ImageURL = "Hawaii.png",
              };
              Pizza Verona =  new Pizza
                {
                    Name = "Verona",
                    Price = 20.00,
                    ImageURL = "Verona.png",
                };

            Margherita.Toppings = new List<PizzaTopping>
            {
                new PizzaTopping
                {
                    Pizza = Margherita,
                    Topping = Mozarella,
                },
                new PizzaTopping
                {
                    Pizza = Margherita,
                    Topping = sosPomidorowy,
                }
            };
            Funghi.Toppings = new List<PizzaTopping>
            {
                new PizzaTopping
                {
                    Pizza = Funghi,
                    Topping = Mozarella,
                },
                new PizzaTopping
                {
                    Pizza = Funghi,
                    Topping = sosPomidorowy,
                },
                new PizzaTopping
                {
                Pizza = Funghi,
                Topping = Pieczarki,
                }
            };
            Verona.Toppings = new List<PizzaTopping>
            {
                new PizzaTopping
                {
                    Pizza = Verona,
                    Topping = Mozarella,
                },
                new PizzaTopping
                {
                    Pizza = Verona,
                    Topping = sosPomidorowy,
                },
                new PizzaTopping
                {
                    Pizza = Verona,
                    Topping = Salami,
                }
            };
            Cotto.Toppings = new List<PizzaTopping>
            {
                new PizzaTopping
                {
                    Pizza = Cotto,
                    Topping = Mozarella,
                },
                new PizzaTopping
                {
                    Pizza = Cotto,
                    Topping = sosPomidorowy,
                },
                new PizzaTopping
                {
                    Pizza = Cotto,
                    Topping = Szynka,
                }
            };
            Hawaii.Toppings = new List<PizzaTopping>
            {
                new PizzaTopping
                {
                    Pizza = Hawaii,
                    Topping = Mozarella,
                },
                new PizzaTopping
                {
                    Pizza = Hawaii,
                    Topping = sosPomidorowy,
                },
                new PizzaTopping
                {
                    Pizza = Hawaii,
                    Topping = Szynka,
                },
                new PizzaTopping
                {
                    Pizza = Hawaii,
                    Topping = Ananas,
                }
            };

            if (!context.Pizzas.Any())
            {
                context.Pizzas.AddRange(Margherita, Funghi, Cotto, Verona, Hawaii);
                context.SaveChanges();
            }

        }
    }
}


