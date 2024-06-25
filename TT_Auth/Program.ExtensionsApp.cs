

namespace TT
{
    public static class ExtensionsApp
    {

        public static void AddMyAppExtensions(this WebApplication app)
        {

            app.UseAuthentication();
            app.UseAuthorization();


        }

    }
}
