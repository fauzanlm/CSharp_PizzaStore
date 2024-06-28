namespace PizzaStore.DB;

public record Pizza
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

public class PizzaDB
{
    private static List<Pizza> _pizzaList = new List<Pizza>(){
        new Pizza{Id = 1, Name = "Montemagno, Pizza shaped like a great mountain"},
        new Pizza{ Id=2, Name="The Galloway, Pizza shaped like a submarine, silent but deadly"},
        new Pizza{ Id=3, Name="The Noring, Pizza shaped like a Viking helmet, where's the mead"}
    };

    public static List<Pizza> GetPizzas()
    {
        return _pizzaList;
    }

    public static Pizza? GetPizza(int id)
    {
        return _pizzaList.SingleOrDefault(pizza => pizza.Id == id);
    }

    public static Pizza AddPizza(Pizza newPizza)
    {
        _pizzaList.Add(newPizza);
        return newPizza;
    }

    public static Pizza UpdatePizza(Pizza updatedPizza)
    {
        _pizzaList = _pizzaList.Select(pizza =>
        {
            if (pizza.Id == updatedPizza.Id)
            {
                pizza.Name = updatedPizza.Name;
            }
            return pizza;
        }).ToList();

        return updatedPizza;
    }

    public static void RemovePizza(int id)
    {
        _pizzaList = _pizzaList.FindAll(pizza => pizza.Id != id).ToList();
    }
}