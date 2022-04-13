using getbiz_launch_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_launch_app.Repository.Manifest
{
    public interface IManifestRepository
    {
        Response GetManifestFile(string subdomain);
        Response VerifySubdomain(string Subdomainname);
        Response GetSubdomainList();
        Response Updatemanifest(AssignManifestDetailsModal ObjManifest);



    }
}
