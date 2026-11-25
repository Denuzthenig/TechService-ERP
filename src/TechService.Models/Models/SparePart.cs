namespace TechService.Models;

/// <summary>Резервна част в склада (напр. RAM, SSD, Display, Battery).</summary>
public class SparePart
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Category { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }

    public SparePart(int id, string name, string category, decimal price, int quantity)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Id трябва да е положително число.", nameof(id));
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Името на частта не може да е празно.", nameof(name));
        }

        if (string.IsNullOrWhiteSpace(category))
        {
            throw new ArgumentException("Категорията не може да е празна.", nameof(category));
        }

        if (price <= 0)
        {
            throw new ArgumentException("Цената трябва да е по-голяма от 0.", nameof(price));
        }

        if (quantity < 0)
        {
            throw new ArgumentException("Наличността не може да е отрицателна.", nameof(quantity));
        }

        Id = id;
        Name = name.Trim();
        Category = category.Trim();
        Price = price;
        Quantity = quantity;
    }

    /// <summary>Увеличава наличността.</summary>
    public void AddStock(int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Количеството трябва да е по-голямо от 0.", nameof(amount));
        }

        Quantity += amount;
    }

    /// <summary>Намалява наличността.</summary>
    public void ConsumeStock(int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Количеството трябва да е по-голямо от 0.", nameof(amount));
        }

        if (amount > Quantity)
        {
            throw new ArgumentException(
                $"Недостатъчна наличност: искани {amount}, налични {Quantity}.", nameof(amount));
        }

        Quantity -= amount;
    }

    public override string ToString()
    {
        return $"Част #{Id}: {Name} [{Category}] | Цена: {Price:F2} | Наличност: {Quantity} бр.";
    }
}
