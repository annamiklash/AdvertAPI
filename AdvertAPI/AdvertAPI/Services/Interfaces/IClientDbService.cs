using System.Collections.Generic;
using AdvertAPI.DTOs;
using AdvertAPI.Models;

namespace AdvertAPI.Services
{
    public interface IClientDbService
    {
        List<Client> GetAllClients();
        NewClientResponse AddNewClient(NewClientRequest request);
        RefreshTokenResponse RefreshToken(RefreshTokenRequest request);
        LoginResponse AuthenticateClient(LoginRequest request);
        Client GetClientByLogin(string login);
        Client GetClientById(int clientId);
        bool ClientExists(int clientId);
    }
}