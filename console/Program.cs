using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Console
{
    using Epiworx.Business;
    using Epiworx.Business.Security;

    public class Program
    {
        static void Main(string[] args)
        {
            var currentLine = string.Empty;

            while (currentLine != "exit")
            {
                System.Console.ForegroundColor = ConsoleColor.Green;
                System.Console.Out.Write("epiworx >> ");
                System.Console.ResetColor();

                currentLine = System.Console.In.ReadLine();

                if (currentLine == null)
                {
                    continue;
                }

                if (currentLine.StartsWith("login"))
                {
                    Program.Login();
                    continue;
                }

                if (currentLine.StartsWith("logout"))
                {
                    Program.Logout();
                    continue;
                }

                if (currentLine.StartsWith("project add"))
                {
                    Program.ProjectAdd();
                    continue;
                }

                if (currentLine.StartsWith("project list"))
                {
                    Program.ProjectList();
                    continue;
                }

                System.Console.WriteLine(string.Format("'{0}' is an unknown command.", currentLine));
            }
        }

        static void Login()
        {
            System.Console.Out.Write("Name: ");

            var name = System.Console.In.ReadLine();

            System.Console.Out.Write("Password: ");

            var password = System.Console.In.ReadLine();

            BusinessPrincipal.Login(name, password);

            System.Console.WriteLine(string.Format("Welcome {0}!", Csla.ApplicationContext.User.Identity.Name));
        }

        static void ProjectAdd()
        {
            var project = ProjectRepository.ProjectNew();

            System.Console.Out.Write("Name: ");

            project.Name = System.Console.In.ReadLine();

            project = ProjectRepository.ProjectSave(project);

            if (project.ProjectId != 0)
            {
                System.Console.WriteLine("Project '{0}' created successful!", project.Name);
                return;
            }

            System.Console.WriteLine("Create failed!");
        }

        static void ProjectList()
        {
            var projects = ProjectRepository.ProjectFetchInfoList();

            if (projects.Count == 0)
            {
                System.Console.WriteLine("No projects available.");
            }

            foreach (var project in projects)
            {
                System.Console.WriteLine(project.Name);
            }
        }

        static void Logout()
        {
            BusinessPrincipal.Logout();

            System.Console.WriteLine("Good bye!");
        }
    }
}
