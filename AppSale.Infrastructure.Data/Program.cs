using AppSale.Infrastructure.Data.Contexts;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Se crea la DB si no existe..!");
ContextSale db = new ContextSale();
db.Database.EnsureCreated();
Console.WriteLine("DB Creada Correctamente..!");
Console.ReadKey();
