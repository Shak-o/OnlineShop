using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace OnlineShop.Domain.Customers.Commands
{
    public class CreateCustomerCommand : IRequest
    {
        public bool NameStyle { get; set; }
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Suffix { get; set; }
        public string? CompanyName { get; set; }
        public string? SalesPerson { get; set; }
        public string? EmailAddress { get; set; }
        public string? Phone { get; set; }
        public string Password { get; set; }
        
        #region Constructors
        public CreateCustomerCommand()
        {
            
        }

        public CreateCustomerCommand(bool nameStyle, string? title, string firstName, string? middleName, string lastName, string? suffix, string companyName, string salesPerson, string emailAddress, string phone, string password)
        {
            NameStyle = nameStyle;
            Title = title;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Suffix = suffix;
            CompanyName = companyName;
            SalesPerson = salesPerson;
            EmailAddress = emailAddress;
            Phone = phone;
            Password = password;
        }
        #endregion
    }
}
