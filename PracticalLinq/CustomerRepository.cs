using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticalLinq
{
   public  class CustomerRepository
    {
        public Customer Find(List<Customer> customerList,int customerId)
        {
            Customer CustomerFound = null;
            //foreach (var c in customerList)
            //{
            //    if (c.CustomerId==customerId)
            //    {
            //        CustomerFound = c;
            //        break;
            //    }
            //}
            var query = from c in customerList
                        where c.CustomerId == customerId
                        select c;
            CustomerFound = query.First();
            return CustomerFound;
        }
        public List<Customer> Retrieve()
        {
            List<Customer> custList = new List<Customer>
            {
                new Customer()
                {
                    CustomerId=1,
                    FirstName="Poojitha",
                    LastName="Pancheti",
                    Email="PP@gmail.com",
                    CustomerTypeId=1
                },
                 new Customer()
                {
                    CustomerId=2,
                    FirstName="Srujana",
                    LastName="Jami",
                    Email="Sj@gmail.com",
                    CustomerTypeId=1
                },
                  new Customer()
                {
                    CustomerId=3,
                    FirstName="Nayani",
                    LastName="Kolla",
                    Email="Nk@gmail.com",
                    CustomerTypeId=1
                }
            };
            return custList;
        }
        public IEnumerable<Customer> SortByName(List<Customer> customerList)
        {
            return customerList.OrderBy(c => c.LastName)
                .ThenBy(c => c.FirstName);
        }
        public IEnumerable<Customer> SortByNameInReverse(List<Customer> customerList)
        {
            // return customerList.OrderByDescending(c => c.LastName)
            //.ThenBy(c => c.FirstName);
            return SortByName(customerList).Reverse();
        }
        public IEnumerable<Customer> SortByType(List<Customer> customerList)
        {
            return customerList.OrderBy(c => c.CustomerTypeId.HasValue).ThenBy(c=>c.CustomerTypeId);
        }

    }
}
