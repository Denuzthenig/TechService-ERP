namespace TechService.Models;

/// <summary>Заявка за ремонт на устройство.</summary>
public class RepairTicket
{
    private readonly List<SparePart> _usedParts;

    public int Id { get; private set; }
    public Client Client { get; private set; }
    public string DeviceModel { get; private set; }
    public string SerialNumber { get; private set; }
    public string ProblemDescription { get; private set; }
    public TicketPriority Priority { get; private set; }
    public TicketStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public IReadOnlyCollection<SparePart> UsedParts => _usedParts.AsReadOnly();

    public RepairTicket(
        int id,
        Client client,
        string deviceModel,
        string serialNumber,
        string problemDescription,
        TicketPriority priority = TicketPriority.Medium)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Id трябва да е положително число.", nameof(id));
        }

        if (client == null)
        {
            throw new ArgumentException("Клиентът е задължителен.", nameof(client));
        }

        if (string.IsNullOrWhiteSpace(deviceModel))
        {
            throw new ArgumentException("Моделът на устройството не може да е празен.", nameof(deviceModel));
        }

        if (string.IsNullOrWhiteSpace(serialNumber))
        {
            throw new ArgumentException("Серийният номер не може да е празен.", nameof(serialNumber));
        }

        if (string.IsNullOrWhiteSpace(problemDescription))
        {
            throw new ArgumentException("Описанието на проблема не може да е празно.", nameof(problemDescription));
        }

        Id = id;
        Client = client;
        DeviceModel = deviceModel.Trim();
        SerialNumber = serialNumber.Trim();
        ProblemDescription = problemDescription.Trim();
        Priority = priority;
        Status = TicketStatus.Pending;
        CreatedAt = DateTime.Now;
        _usedParts = new List<SparePart>();
    }

    /// <summary>Сменя статуса на заявката.</summary>
    public void ChangeStatus(TicketStatus newStatus)
    {
        if (!Enum.IsDefined(newStatus))
        {
            throw new ArgumentException("Невалиден статус.", nameof(newStatus));
        }

        Status = newStatus;
    }

    /// <summary>Добавя използвана резервна част към заявката.</summary>
    public void AddPart(SparePart part)
    {
        if (part == null)
        {
            throw new ArgumentException("Частта е задължителна.", nameof(part));
        }

        _usedParts.Add(part);
    }

    /// <summary>Връща общата цена на използваните части.</summary>
    public decimal CalculatePartsTotal()
    {
        return _usedParts.Sum(p => p.Price);
    }

    public override string ToString()
    {
        return $"Заявка #{Id}: {DeviceModel} (S/N: {SerialNumber}) | {Client.FullName} | " +
               $"{Priority} | {Status} | {CreatedAt:dd.MM.yyyy HH:mm} | Части: {CalculatePartsTotal():F2}";
    }
}
