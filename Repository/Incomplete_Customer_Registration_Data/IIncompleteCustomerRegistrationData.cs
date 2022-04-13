using getbiz_launch_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_launch_app.Repository.Incomplete_Customer_Registration_Data
{ 
    public interface IIncompleteCustomerRegistrationData
    {
     Response AddIncompleteCustomerRegistrationData(incomplete_customer_registration_data_Step1 obj_incomplete_customer_registration_data,incomplete_customer_registration_data_Step2 obj_incomplete_customer_registration_data_step2,incomplete_customer_registration_data ObjMain, incomplete_customer_registration_data_Step3 obj_incomplete_customer_registration_data_Step3);
    }
    
}
