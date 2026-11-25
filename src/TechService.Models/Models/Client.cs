namespace TechService.Models;

/// <summary>Клиент на сервиза.</summary>
public class Client
{
    public int Id { get; private set; }
    public string FullName { get; private set; }
    public string Phone { get; private set; }
    public string Email { get; private set; }

    public Client(int id, string fullName, string phone, string email)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Id трябва да е положително число.", nameof(id));
        }

        if (string.IsNullOrWhiteSpace(fullName) || fullName.Trim().Length < 3)
        {
            throw new ArgumentException("Името трябва да съдържа поне 3 символа.", nameof(fullName));
        }

        ValidateContactInfo(phone, email);

        Id = id;
        FullName = fullName.Trim();
        Phone = phone.Trim();
        Email = email.Trim();
    }

    public void UpdateContactInfo(string phone, string email)
    {
        ValidateContactInfo(phone, email);

        Phone = phone.Trim();
        Email = email.Trim();
    }

    public override string ToString()
    {
        return $"Клиент #{Id}: {FullName} | Тел: {Phone} | Email: {Email}";
    }

    private static void ValidateContactInfo(string phone, string email)
    {
        if (string.IsNullOrWhiteSpace(phone))
        {
            throw new ArgumentException("Телефонът не може да е празен.", nameof(phone));
        }

        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("Имейлът не може да е празен.", nameof(email));
        }
    }
}
