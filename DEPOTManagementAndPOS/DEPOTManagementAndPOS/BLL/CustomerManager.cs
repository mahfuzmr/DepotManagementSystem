using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPOTManagementAndPOS.DLL;
using DEPOTManagementAndPOS.Model;

namespace DEPOTManagementAndPOS.BLL
{
    class CustomerManager
    {
        private static CustomerGateway _aCustomerGateway;
        public bool SaveAllCustomerInfo(Customer newCustomer)
        {
            _aCustomerGateway = new CustomerGateway();

            return _aCustomerGateway.SaveAllCustomerInfo(newCustomer);


        }

        public Customer GetCustomerInfoUsingId(string id)
        {

            _aCustomerGateway = new CustomerGateway();
            return _aCustomerGateway.GetCustomerInfoUsingId(id);   
        }

        public static long GetCustomerId()
        {
            _aCustomerGateway = new CustomerGateway();
            return _aCustomerGateway.GetCustomerId();
        }
    }
}
