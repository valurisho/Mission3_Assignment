
namespace Mission3_Assignment;

public class FoodItem //they have to be called the same thing both the class and the constructor
{
    //super simple only to create the food Item Class
    public string Name;
    public string Category;
    public int Quantity;
    public DateTime ExpirationDate;
    
    public FoodItem(string name, string category, int quantity, DateTime expirationDate)
    {
        Name = name;
        Category = category;
        Quantity = quantity;
        ExpirationDate = expirationDate;
    }
}