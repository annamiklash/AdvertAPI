using System;
using System.Collections.Generic;
using System.Linq;
using AdvertAPI.Context;
using AdvertAPI.DTOs;
using AdvertAPI.Generators;
using AdvertAPI.Helpers;
using AdvertAPI.Models;
using Microsoft.Extensions.Configuration;

namespace AdvertAPI.Services
{
    public class ClientDbService : IClientDbService
    {
        private readonly MyDbContext _context;
        private readonly IConfiguration _configuration;

        public ClientDbService(MyDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public List<Client> GetAllClients()
        {
            return _context.Client.ToList();
        }

        public NewClientResponse AddNewClient(NewClientRequest request)
        {
            if (LoginExists(request.Login))
            {
                throw new Exception("User with login " + request.Login + " already exists");
            }

            var clientId = GenerateNewClientId();
            var hashSalt = HashSaltGenerator.GenerateSaltedHash(request.Password);
            var hashedPassword = hashSalt.Hash;
            var salt = hashSalt.Salt;
            var accessToken = TokensGenerator.GenerateAccessToken(clientId, _configuration);
            var refreshToken = TokensGenerator.GenerateRefreshToken(clientId, accessToken);
            SaveClient(request, clientId, hashedPassword, salt);
            var refreshId = GetNewRefreshTokenId();
            var accessId = GetNewAccessTokenId();

            SaveAccessToken(accessToken, clientId, accessId);
            SaveRefreshToken(refreshToken, clientId, refreshId);
            AssignTokensToClient(clientId, accessToken, refreshToken);

            return new NewClientResponse
            {
                AccessToken = accessToken.Token,
                RefreshToken = refreshToken.Token
            };
        }


        public RefreshTokenResponse RefreshToken(RefreshTokenRequest request)
        {
            var client = GetUserByRefreshToken(request.RefreshToken);

            var accessToken = TokensGenerator.GenerateAccessToken(client.IdClient, _configuration);
            var updatedAccessToken = UpdateAccessToken(accessToken);

            var refreshToken = TokensGenerator.GenerateRefreshToken(client.IdClient, accessToken);
            var updatedRefreshToken = UpdateRefreshToken(refreshToken);

            return new RefreshTokenResponse
            {
                AccessToken = updatedAccessToken,
                RefreshToken = updatedRefreshToken
            };
        }

        public LoginResponse AuthenticateClient(LoginRequest request)
        {
            var client = GetClientByLogin(request.Login);
            if (client == null)
            {
                throw new Exception("Client with login " + request.Login + " DOESNT EXIST");
            }

            string hashedPassword = GetHashedPassword(client.IdClient);
            string salt = GetSalt(client.IdClient);
            bool isPasswordValid = ValidationHelper.IsPasswordValid(request.Password, hashedPassword, salt);
            if (!isPasswordValid)
            {
                throw new Exception("Incorrect password for client with login " + request.Login);
            }

            var accessToken = TokensGenerator.GenerateAccessToken(client.IdClient, _configuration);
            var refreshToken = TokensGenerator.GenerateRefreshToken(client.IdClient, accessToken);

            var updatedAccessToken = UpdateAccessToken(accessToken);
            var updatedRefreshToken = UpdateRefreshToken(refreshToken);

            return new LoginResponse
            {
                AccessToken = updatedAccessToken,
                RefreshToken = updatedRefreshToken
            };
        }
        
        public Client GetClientByLogin(string login)
        {
            return _context.Client.FirstOrDefault(client => client.Login == login);
        }

        public Client GetClientById(int clientId)
        {
            return _context.Client.FirstOrDefault(client => client.IdClient == clientId);
        }

        public bool ClientExists(int clientId)
        {
            return _context.Client.Any(client => client.IdClient == clientId);
        }

        private string GetSalt(int idClient)
        {
            return _context.Client.FirstOrDefault(client => client.IdClient == idClient).Salt;
        }

        private string GetHashedPassword(int idClient)
        {
            return _context.Client.FirstOrDefault(client => client.IdClient == idClient).Password;
        }

        private string UpdateRefreshToken(RefreshToken refreshToken)
        {
            var updatedRefreshToken =
                _context.RefreshTokens.FirstOrDefault(token => token.IdClient == refreshToken.IdClient);
            updatedRefreshToken.Token = refreshToken.Token;
            updatedRefreshToken.IssueDateTime = refreshToken.IssueDateTime;

            _context.SaveChanges();
            return updatedRefreshToken.Token;
        }

        private string UpdateAccessToken(AccessToken accessToken)
        {
            var updatedAccessToken =
                _context.AccessToken.FirstOrDefault(token => token.IdClient == accessToken.IdClient);
            updatedAccessToken.Token = accessToken.Token;
            updatedAccessToken.IssueDateTime = accessToken.IssueDateTime;
            updatedAccessToken.ExpirationDateTime = accessToken.ExpirationDateTime;

            _context.SaveChanges();
            return updatedAccessToken.Token;
        }

        private Client GetUserByRefreshToken(string requestRefreshToken)
        {
            try
            {
                var idClient = _context.RefreshTokens.FirstOrDefault(token => token.Token == requestRefreshToken)
                    .IdClient;
                return _context.Client.FirstOrDefault(client => client.IdClient == idClient);
            }
            catch (Exception e)
            {
                throw new Exception("Client with refresh token " + requestRefreshToken + " DOESNT EXIST.");
            }
        }

        private void AssignTokensToClient(int clientId, AccessToken accessToken, RefreshToken refreshToken)
        {
            accessToken.IdClient = clientId;
            refreshToken.IdClient = clientId;

            _context.SaveChanges();
        }

        private void SaveClient(NewClientRequest request, in int id, string hashedPassword, string salt)
        {
            _context.Client.Add(new Client
            {
                IdClient = id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
                Login = request.Login,
                Password = hashedPassword,
                Salt = salt
            });
            _context.SaveChanges();
        }

        private void SaveAccessToken(AccessToken accessToken, int clientId, int tokenId)
        {
            _context.AccessToken.Add(new AccessToken
            {
                IdAccessToken = tokenId,
                Token = accessToken.Token,
                IssueDateTime = accessToken.IssueDateTime,
                ExpirationDateTime = accessToken.ExpirationDateTime,
                IdClient = clientId,
                Client = _context.Client.FirstOrDefault(c => c.IdClient == clientId)
            });

            _context.SaveChanges();
        }

        private int GetNewAccessTokenId()
        {
            return _context.AccessToken.Max(token => token.IdAccessToken) + 1;
        }


        private void SaveRefreshToken(RefreshToken refreshToken, int clientId, int tokenId)
        {
            _context.RefreshTokens.Add(new RefreshToken
            {
                IdRefreshToken = tokenId,
                Token = refreshToken.Token,
                IssueDateTime = refreshToken.IssueDateTime,
                IdClient = clientId,
                Client = _context.Client.FirstOrDefault(c => c.IdClient == clientId)
            });

            _context.SaveChanges();
        }

        private int GetNewRefreshTokenId()
        {
            return _context.RefreshTokens.Max(token => token.IdRefreshToken) + 1;
        }

        private bool LoginExists(string requestLogin)
        {
            return _context.Client.Any(client => client.Login == requestLogin);
        }

        private int GenerateNewClientId()
        {
            return _context.Client.Max(client => client.IdClient) + 1;
        }
    }
}