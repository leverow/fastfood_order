using fastfood_order.Entity;

namespace fastfood_order.Services;

public class UserService
{
    public UserService()
    {
        
    }    
    public async Task<User?> GetUserAsync(long? accountId)
    {
        return new User(){ LanguageCode = "en"};
    }
    
}