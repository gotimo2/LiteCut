using Catel.Reflection;
using Orc.FileAssociation;
using System.Security.Principal;

namespace LiteCut
{
    internal class FileAssociation
    {
        public static void associateFile()
        {
            var applicationInfo = new ApplicationInfo("LiteCut", "LiteCut", "LiteCut", Application.ExecutablePath);
            applicationInfo.SupportedExtensions.Add(".mp4");

            IApplicationRegistrationService registrationService = new ApplicationRegistrationService();

            registrationService.RegisterApplication(applicationInfo);

            }
        public static bool IsAdministrator()
        {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                      .IsInRole(WindowsBuiltInRole.Administrator);
        }


    }
}
