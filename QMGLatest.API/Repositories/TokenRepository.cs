using QMGLatest.API;
using QMGLatest.API;

public class TokenRepository : ITokenRepository
{
    private readonly ApplicationDbContext _context;

    public TokenRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public void SaveToken(Token token)
    {

            _context.Tokens.Add(token);
            _context.SaveChanges();
        
    }


    
}

