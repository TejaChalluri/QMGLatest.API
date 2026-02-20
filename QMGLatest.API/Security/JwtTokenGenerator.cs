using Microsoft.IdentityModel.Tokens;
using QMGLatest.API;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class JwtTokenGenerator
{
    public static string GenerateToken(User user, string key)
    {
        //var claims = new[]
        //{
        //    new Claim("userId", user.UserId.ToString()),
        //    new Claim("username", user.Username),
        //    new Claim("role", user.RoleName),
        //    new Claim("roleNumber", user.RoleNumber.ToString())
        //    new Claim("fisrtname", user.FirstName.ToString()),
        //    new Claim("lastname",user.LastName.ToString()),
        //};


        var claims = new List<Claim>
    {
        new Claim("userId", user.UserId.ToString()),
        new Claim("username", user.Username ?? string.Empty),
        new Claim("role", user.RoleName ?? string.Empty),
        new Claim("roleNumber", user.RoleNumber.ToString())
    };

        // Add FirstName with null check
        if (!string.IsNullOrEmpty(user.FirstName))
        {
            claims.Add(new Claim("firstname", user.FirstName));
        }
        else
        {
            claims.Add(new Claim("firstname", string.Empty));
        }

        // Add LastName with null check
        if (!string.IsNullOrEmpty(user.LastName))
        {
            claims.Add(new Claim("lastname", user.LastName));
        }
        else
        {
            claims.Add(new Claim("lastname", string.Empty));
        }

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

