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
    public async Task<(bool IsSuccess, string? ErrorMessage)> AddExtrasAsync(long? userId, int sausage = 0, int cheese = 0, int turkey = 0, int beef = 0, int balonesia = 0)
    {
        ArgumentNullException.ThrowIfNull(userId);

        var user = await GetUserAsync(userId);

        if(user is null)
        {
            return (false, "User not found");
        }

        user.ExtraBalonesia += balonesia;
        user.ExtraBeef += beef;
        user.ExtraCheese += cheese;
        user.ExtraSausage += sausage;
        user.ExtraTurkey += turkey;

        _context?.Users?.Update(user);
        await _context.SaveChangesAsync();

        return (true, null);
    }

    public async Task<string?> GetLanguageCodeAsync(long? userId)
    {
        var user = await GetUserAsync(userId);

        return user?.LanguageCode;
    }

    public async Task<int> GetExtraSausageAsync(long? userId)
    {
        var user = await GetUserAsync(userId);

        return user.ExtraSausage;
    }
    public async Task<int?> GetExtraCheeseAsync(long? userId)
    {
        var user = await GetUserAsync(userId);

        return user?.ExtraCheese;
    }
    public async Task<int?> GetExtraBeefAsync(long? userId)
    {
        var user = await GetUserAsync(userId);

        return user?.ExtraBeef;
    }
    public async Task<int?> GetExtraTurkeyAsync(long? userId)
    {
        var user = await GetUserAsync(userId);

        return user?.ExtraTurkey;
    }
    public async Task<int?> GetExtraBalonesiaAsync(long? userId)
    {
        var user = await GetUserAsync(userId);

        return user?.ExtraBalonesia;
    }
    public async Task<bool> Exists(long userId)
        => await _context.Users.AnyAsync(u => u.UserId == userId);
}