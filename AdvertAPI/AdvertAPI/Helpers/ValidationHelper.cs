using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using AdvertAPI.DTOs;

namespace AdvertAPI.Helpers
{
    public class ValidationHelper
    {
        private const string NAME_REGEX = "^[A-Z][-a-zA-Z]+$";
        private const string PHONE_REGEX = @"^\d{3}-\d{3}-\d{3}$";
        private const string DATE_REGEX = @"^\d{4}\-(0?[1-9]|1[012])\-(0?[1-9]|[12][0-9]|3[01])$";

        public static List<Error> ValidateNewClientRequest(NewClientRequest request)
        {
            List<Error> errors = new List<Error>();

            if (!IsNameValid(request.FirstName))
            {
                errors.Add(
                    new Error
                    {
                        Field = "FirstName",
                        InvalidValue = request.FirstName,
                        Message = "Wrong format for First Name. Should be ^[A-Z][-a-zA-Z]+$"
                    }
                );
            }

            if (!IsNameValid(request.LastName))
            {
                errors.Add(
                    new Error
                    {
                        Field = "LastName",
                        InvalidValue = request.LastName,
                        Message = "Wrong format for Last Name. Should be ^[A-Z][-a-zA-Z]+$"
                    }
                );
            }

            if (!IsEmailValid(request.Email))
            {
                errors.Add(
                    new Error
                    {
                        Field = "Email",
                        InvalidValue = request.Email,
                        Message = "Wrong format for email"
                    }
                );
            }

            if (!IsPhoneValid(request.Phone))
            {
                errors.Add(
                    new Error
                    {
                        Field = "Phone",
                        InvalidValue = request.Phone,
                        Message = "Wrong format for phone number. Should be ^\\d{3}-\\d{3}-\\d{3}$"
                    }
                );
            }

            if (string.IsNullOrEmpty(request.Login))
            {
                errors.Add(
                    new Error
                    {
                        Field = "Login",
                        InvalidValue = request.Login,
                        Message = "Login field must be filled in"
                    }
                );
            }

            if (string.IsNullOrEmpty(request.Password))
            {
                errors.Add(
                    new Error
                    {
                        Field = "Password",
                        InvalidValue = request.Password,
                        Message = "Password field must be filled in"
                    }
                );
            }

            return errors;
        }

        public static List<Error> ValidateLoginRequest(LoginRequest request)
        {
            List<Error> errors = new List<Error>();
            if (string.IsNullOrEmpty(request.Login))
            {
                errors.Add(
                    new Error
                    {
                        Field = "Login",
                        InvalidValue = request.Login,
                        Message = "Login field must be filled in"
                    }
                );
            }

            if (string.IsNullOrEmpty(request.Password))
            {
                errors.Add(
                    new Error
                    {
                        Field = "Password",
                        InvalidValue = request.Password,
                        Message = "Password field must be filled in"
                    }
                );
            }

            return errors;
        }

        public static List<Error> ValidateNewCampaignRequest(NewCampaignRequest request)
        {
            List<Error> errors = new List<Error>();
            
            if (!IsDateValid(request.StartDate))
            {
                errors.Add(new Error
                {
                    Field = "StartDate",
                    InvalidValue = request.StartDate,
                    Message = "Date doesnt match regex ^([12]\\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\\d|3[01])$)"
                });
            }
                  
            if (!IsDateValid(request.EndDate))
            {
                errors.Add(new Error
                {
                    Field = "EndDate",
                    InvalidValue = request.EndDate,
                    Message = "Date doesnt match regex ^([12]\\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\\d|3[01])$)"
                });
            }

            return errors;
        }

        public static bool IsPasswordValid(string enteredPassword, string hashedPassword, string salt)
        {
            var saltBytes = Convert.FromBase64String(salt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(enteredPassword, saltBytes, 10000);
            var base64String = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
            return base64String.Equals(hashedPassword);
        }

        private static bool IsNameValid(string name)
        {
            return Regex.IsMatch(name, NAME_REGEX);
        }

        private static bool IsPhoneValid(string phone)
        {
            return Regex.IsMatch(phone, PHONE_REGEX);
        }
        private static bool IsEmailValid(string emailAddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailAddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        
        private static bool IsDateValid(string requestDateAccepted)
        {
            return Regex.IsMatch(requestDateAccepted, DATE_REGEX);
        }
    }
}