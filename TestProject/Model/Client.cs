using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestProject.Model
{
    public class Client
    {
        public int? Id { get; set; }

        public string Forename { get; set; }

        public string MiddleName { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string NiNumber { get; set; }

        public string AddressLineOne { get; set; }

        public string AddressLineTwo { get; set; }

        public string AddressLineThree { get; set; }

        public string AddressLineFour { get; set; }

        public string EmailAddress { get; set; }

        public string PhotographUrl { get; set; }
    }
}