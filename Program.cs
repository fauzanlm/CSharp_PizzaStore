using Microsoft.OpenApi.Models;
using PizzaStore.DB;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PizzaStore API", Description = "Making the Pizzas you love", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API v1"));
}

app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

app.MapGet("/pizzas", () => PizzaDB.GetPizzas());
app.MapGet("/pizza/{id}", (int id) => PizzaDB.GetPizza(id));
app.MapPost("/pizzza", (Pizza pizza) => PizzaDB.AddPizza(pizza));
app.MapPut("/pizza", (Pizza pizza) => PizzaDB.UpdatePizza(pizza));
app.MapDelete("/pizza/{id}", (int id) => PizzaDB.RemovePizza(id));

app.Run();

