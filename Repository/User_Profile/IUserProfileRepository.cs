using getbiz_launch_app.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_launch_app.Repository.User_Profile
{
    public interface IUserProfileRepository
    {
        Response AddUserProfile(user_profile obj_user_profile);
      //  Response GetUser(vm_user_login_data obj_vm_user_login_data);
        Response GetUserRegistrationApprovalStatusFieldBased(string customer_id, Int64 user_registration_approval_status);
        Response GetUserProfile(string Customet_Id, Int64 User_id);
        Response UpdateUserProfile(user_profile obj_user_profile);
        Response UpdateUserProfileMobileNumber(string Customet_Id, string Login_Mobile_No, Int64 User_Id);
        Response UpdateUserRegistrationApprovalStatus(string Customet_Id, Int64 User_Registration_Approval_Status, Int64 User_Id, Int64 From_Id);

        Response GetVerifyuser(UserLogin obj_UserLogin);

        Response Getlaunchrecent_apps(string customer_id, string userid);
        Response Getlaunchfavourite_apps(string customer_id, string userid);
        Response Getlaunchscreen_apps(string customer_id, string userid);

        Response AddFavouriteAppScreens(FavouriteAppScreens objfavourite);
        Response AddRecentAppScreens(RecentAppScreens objrecent);

        Response GetLaunchScreenApps(string customer_id);
        Response GetBusinessCategoriesApps(string customer_id);


    }
}
