namespace DbUpDemo.Infrastructure.Postgres.Migrations
{
    using System;
    using System.Reflection;
    using DbUp;
    using Microsoft.Extensions.Hosting;

    public class Scaffold
    {
        public static void Execute(string connectionString, IHostEnvironment hostEnvironment)
        {
            var upgrader =
                DeployChanges.To
                .PostgresqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), s => ApplyScriptFilter(s, hostEnvironment))
                .WithTransactionPerScript()
                .LogToAutodetectedLog()
                .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                throw new Exception("Migration issue", result.Error);
            }
        }

        /// <summary>
        /// Certain scripts should only be executed on the correct environments.
        /// </summary>
        /// <param name="scriptPath">The full embedded path of the script being considered.</param>
        /// <param name="hostEnvironment">The current host environment, from which the environment name is extracted.</param>
        /// <returns>True if the script should be considered, False otherwise.</returns>
        private static bool ApplyScriptFilter(string scriptPath, IHostEnvironment hostEnvironment)
        {
            const string AllEnvironmentsScriptsPrefix = "Script";
            const string TestEnvironmentsScriptsPostfix = "_Testdata";

            var scriptName = scriptPath.Split('.').Penultimate();
            switch (hostEnvironment.EnvironmentName.ToLowerInvariant())
            {
                case "production":
                    return scriptName.StartsWith(AllEnvironmentsScriptsPrefix, StringComparison.InvariantCultureIgnoreCase)
                        && !scriptName.EndsWith(TestEnvironmentsScriptsPostfix, StringComparison.InvariantCultureIgnoreCase);

                default:
                    return scriptName.StartsWith(AllEnvironmentsScriptsPrefix, StringComparison.InvariantCultureIgnoreCase);
            }
        }
    }
}
