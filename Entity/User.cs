namespace fastfood_order.Entity;

public class User
{
    public long UserId { get; set; }
    public long ChatId { get; set; }
    public bool IsBot { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Username { get; set; }
    public string? LanguageCode { get; set; } = "uz";
    public int StepOfOrder { get; set; } = 0;    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset LastInteractionAt { get; set; }
    //Hot dogs count    
    public int ClassicHotDog { get; set; } = 0;
    public int DoubleHotDog { get; set; } = 0;
    public int AmericanoHotDog { get; set; } = 0;
    public int FranchHotDog { get; set; } = 0;
    public int MeatHotDog { get; set; } = 0;
    
    
    
    
    
    
    
    
}