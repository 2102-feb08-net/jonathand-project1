using System;
using System.Collections.Generic;

namespace PizzaParadise.Library
{
    public class Customer
    {
        private int customerId;
        private string firstName;

        private string lastName;

        public Customer(string fname, string lname)
        {
            firstName = fname;
            lastName = lname;
        }
        public Customer(int id, string fname, string lname)
        {
            customerId = id;
            firstName = fname;
            lastName = lname;
        }

        public string FirstName
        {

            get => firstName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("First name must not be empty.", nameof(value));
                }
                firstName = value;
            }
        }
        public string LastName
        {

            get => lastName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Last name must not be empty.", nameof(value));
                }
                lastName = value;
            }
        }

        public int CustomerId
        {

            get => customerId;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Id must be greater than 0", nameof(value));
                }
                customerId = value;
            }
        }
        public List<Order> CustomerOrders { get; set; } = new List<Order>();
    }
}

