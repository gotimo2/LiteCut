using Catel.Reflection;
using Orc.FileAssociation;
using System.Security.Principal;

namespace LiteCut
{
    internal class FileAssociation
    {
        public static void AssociateFile()
        {
            var applicationInfo = new ApplicationInfo("LiteCut", "LiteCut", "LiteCut", Application.ExecutablePath);
            applicationInfo.SupportedExtensions.Add(".mp4");

            IApplicationRegistrationService registrationService = new ApplicationRegistrationService();

            registrationService.RegisterApplication(applicationInfo);

            }
    }
}
