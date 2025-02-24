﻿namespace Services.CustomModels
{
    using Services.Common;
    using Services.CustomModels.Interfaces;
    using System.ComponentModel.DataAnnotations;

    public class PersonModel : ICustomModel
    {
        public PersonModel()
        {

        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public string Email { get; set; }

        [Password(8, true, true, true, ErrorMessage = "Password not reply to demands")]

        [Compare("ConfirmPassword", ErrorMessage = "Passwords do not match!")]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}