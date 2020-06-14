using AdvertAPI.Models;

namespace AdvertAPI.Mappers
{
    public class ClientToClientWrapper
    {
        public static ClientWrapper MapToClientWrapper(Client client)
        {
            return new ClientWrapper
            {
                FirstName = client.FirstName,
                LastName = client.LastName,
                Email = client.Email,
                Phone = client.Phone
            };
        }
    }
}