using getbiz_launch_app.Getbiz_DbContext;
using getbiz_launch_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_launch_app.Repository.Manifest
{
    public class ManifestRepository : IManifestRepository
    {



        public Response GetManifestFile(string subdomain)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.GetManifestFile(subdomain);
                response = result;

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }


        public Response VerifySubdomain(string Subdomainname)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.VerifySubdomain(Subdomainname);
                response = result;

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response GetSubdomainList()
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.GetSubdomainList();
                response = result;

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response Updatemanifest(AssignManifestDetailsModal ObjManifest)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.Updatemanifest(ObjManifest);
                response = result;

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }



    }
}
