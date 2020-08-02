using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HostApp.UI
{
    public class ViewModelCommandExtractor
    {

        public List<Tuple<string, ICommand>> GetCommands(IViewModel vwMdl)
        {
            List<Tuple<string, ICommand>> cmds = new List<Tuple<string, ICommand>>();
            // turn the methods in the form of "<Xyz>Command()" into buttons
            IEnumerable<PropertyInfo> cmdPropInfos = vwMdl.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty).
                        Where(methInfo => methInfo.Name.EndsWith(AppInfo.ViewModelCommandSuffix));

            foreach (PropertyInfo cmdPropInfo in cmdPropInfos)
            {
                string cmdName = Regex.Replace(cmdPropInfo.Name.Substring(0, cmdPropInfo.Name.Length - AppInfo.ViewModelCommandSuffix.Length),
                                    "([a-z](?=[A-Z])|[A-Z](?=[A-Z][a-z]))", "$1 ");
                Tuple<string, ICommand> cmdNameTuple = new Tuple<string, ICommand>(cmdName, (ICommand)cmdPropInfo.GetValue(vwMdl));
                cmds.Add(cmdNameTuple);
            }

            return cmds;
        }

    }
}
