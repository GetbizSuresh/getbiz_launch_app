using getbiz_launch_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_launch_app.Getbiz_DbContext
{
    public class LaunchAppDB_DbContext : DbContext
    {

        public LaunchAppDB_DbContext(DbContextOptions<LaunchAppDB_DbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        
        
        
        
        public virtual DbSet<incomplete_customer_registration_data> incomplete_customer_registration_data { set; get; }







        public virtual DbSet<user_profile> user_profile { set; get; }
        public virtual DbSet<user_login_data> user_login_data { set; get; }


        public virtual DbSet<userapp_user_category> userapp_user_category { set; get; }
        //public virtual DbSet<userapp_app_access_copy> userapp_app_access_copy { set; get; }
    }









}
