namespace ShoppingCart.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateJwtToken(string userId);
    }
}
