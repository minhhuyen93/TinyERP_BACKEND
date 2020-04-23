using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using TinyERP.Common.Enums;
using TinyERP.Common.Tasks;

namespace TinyERP.Common.Helpers
{
    public class AssemblyHelper
    {
        public static void Execute<IInterface>(object args = null) where IInterface : ITask
        {
            IList<Type> types = AssemblyHelper.GetTypes<IInterface>();
            foreach (Type type in types)
            {
                ITask task = (ITask)Activator.CreateInstance(type);
                task.Execute(args);
            }
        }
        private static IList<Type> GetTypes<IInterface>()
        {
            IList<Type> types = new List<Type>();
            IList<string> dllNames = AssemblyHelper.GetApplicationDllNames();
            foreach (string dll in dllNames)
            {
                IList<Type> result = Assembly.Load(dll)
                                            .GetTypes()
                                            .Where(item => typeof(IInterface).IsAssignableFrom(item) && item.IsClass && !item.IsAbstract)
                                            .ToList();
                types = types.Concat(result).ToList();
            }
            return types;
        }
        private static IList<string> GetApplicationDllNames()
        {
            IList<string> dllNames = new List<string>();
            string binPath = AssemblyHelper.GetBinPath();
            dllNames = Directory.GetFiles(binPath, ".dll")
                                .Where(item => IsCustomeClass(item)).Select(file => Path.GetFileNameWithoutExtension(file))
                                .ToList();
            return dllNames;
        }
        private static string GetBinPath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().EscapedCodeBase).Replace("file:\\", string.Empty);
        }
        private static bool IsCustomeClass(string item)
        {
            Regex regex = new Regex(ApplicationConsts.ApplicationName);
            Match match = regex.Match(Path.GetFileName(item));
            return match.Success;
        }
    }
}
