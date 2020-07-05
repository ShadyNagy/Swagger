using System.Threading.Tasks;

namespace ShadyNagy.Swagger.Core.Interfaces
{
  public interface ITokenClaimsService
  {
    Task<string> GetTokenAsync(string userName);
  }
}
