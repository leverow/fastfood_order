using fastfood_order.Data;
using fastfood_order.Entity;
using Microsoft.EntityFrameworkCore;

namespace fastfood_order.Services;

public class UserService
{
    private readonly ILogger<UserService> _logger;
    private readonly BotDbContext _context;

    public UserService(
        ILogger<UserService> logger,
        BotDbContext context
    )
    {
        _logger = logger;
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }    
    public async Task<User?> GetUserAsync(long? userId)
    {
        ArgumentNullException.ThrowIfNull(userId);
        ArgumentNullException.ThrowIfNull(_context.Users);

        return await _context.Users.FindAsync(userId);
    }
    
    public async Task<(bool IsSuccess, string? ErrorMessage)> AddUserAsync(User user)
    {
        if(await Exists(user.UserId))
            return (false, "User exists");
        try
        {
            var result = await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();
            
            return (true, null);
        }
        catch(Exception e)
        {
            return (false, e.Message);
        }
    }

    public async Task<(bool IsSuccess, string? ErrorMessage)> UpdateLanguageCodeAsync(long? userId, string? languageCode)
    {
        ArgumentNullException.ThrowIfNull(languageCode);

        var user = await GetUserAsync(userId);

        if(user is null)
        {
            return (false, "User not found");
        }

        user.LanguageCode = languageCode;
        _context?.Users?.Update(user);
        await _context.SaveChangesAsync();

        return (true, null);
    }
    public async Task<(bool IsSuccess, string? ErrorMessage)> AddHotDogAsync(long? userId, int americano_hot_dog = 0, int franch_hot_dog = 0, int double_hot_dog = 0, int meat_hot_dog = 0, int classic_hot_dog = 0)
    {
        ArgumentNullException.ThrowIfNull(userId);

        var user = await GetUserAsync(userId);

        if(user is null)
        {
            return (false, "User not found");
        }

        user.AmericanoHotDog += americano_hot_dog;
        user.ClassicHotDog += classic_hot_dog;
        user.DoubleHotDog += double_hot_dog;
        user.MeatHotDog += meat_hot_dog;
        user.FranchHotDog += franch_hot_dog;

        _context?.Users?.Update(user);
        await _context.SaveChangesAsync();

        return (true, null);
    }
    public async Task<(bool IsSuccess, string? ErrorMessage)> RemoveHotDogAsync(long? userId, int americano_hot_dog = 0, int franch_hot_dog = 0, int double_hot_dog = 0, int meat_hot_dog = 0, int classic_hot_dog = 0)
    {
        ArgumentNullException.ThrowIfNull(userId);

        var user = await GetUserAsync(userId);

        if(user is null)
        {
            return (false, "User not found");
        }

        user.AmericanoHotDog -= americano_hot_dog;
        user.ClassicHotDog -= classic_hot_dog;
        user.DoubleHotDog -= double_hot_dog;
        user.MeatHotDog -= meat_hot_dog;
        user.FranchHotDog -= franch_hot_dog;

        _context?.Users?.Update(user);
        await _context.SaveChangesAsync();

        return (true, null);
    }
    public async Task<(bool IsSuccess, string? ErrorMessage)> UpdateStepOfOrder(long? userId, int stepOfOrder = 0)
    {
        ArgumentNullException.ThrowIfNull(stepOfOrder);

        var user = await GetUserAsync(userId);

        if(user is null)
        {
            return (false, "User not found");
        }
        
        if(stepOfOrder is 0)
        {
            user.StepOfOrder = 0;
        }
        else
        {
            user.StepOfOrder += stepOfOrder;
        }

        _context?.Users?.Update(user);
        await _context.SaveChangesAsync();

        return (true, null);
    }
    public async Task<int?> GetStepOfOrder(long? userId)
    {
        var user = await GetUserAsync(userId);

        return user?.StepOfOrder;
    }
    public async Task<string?> GetLanguageCodeAsync(long? userId)
    {
        var user = await GetUserAsync(userId);

        return user?.LanguageCode;
    }

    public async Task<int?> GetAmericanoHotdogAsync(long? userId)
    {
        var user = await GetUserAsync(userId);

        return user?.AmericanoHotDog;
    }
    public async Task<int?> GetDoubleHotdogAsync(long? userId)
    {
        var user = await GetUserAsync(userId);

        return user?.DoubleHotDog;
    }
    public async Task<int?> GetMeatHotdogAsync(long? userId)
    {
        var user = await GetUserAsync(userId);

        return user?.MeatHotDog;
    }
    public async Task<int?> GetClassicHotdogAsync(long? userId)
    {
        var user = await GetUserAsync(userId);

        return user?.ClassicHotDog;
    }
    public async Task<int?> GetFranchHotdogAsync(long? userId)
    {
        var user = await GetUserAsync(userId);

        return user?.FranchHotDog;
    }
    public async Task<bool> Exists(long userId)
        => await _context.Users.AnyAsync(u => u.UserId == userId);
}