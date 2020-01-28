using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace InroductionToLINQ
{
    public static class CommandInvoker
    {
        public static Dictionary<string,Command> Commands
        {
            get
            {
                if (!flag)
                {
                    var commandTypes = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.BaseType == typeof(Command));
                    foreach(var commandType in commandTypes)
                    {
                        var command = (Command)commandType.GetConstructor(new Type[] { }).Invoke(new object[] { });
                        commands.Add(command.Name, command);
                    }
                    flag = true;
                }
                return commands;
            }
        }

        private static bool flag = false;
        private static Dictionary<string, Command> commands = new Dictionary<string, Command>();

        /// <summary>
        /// Invoke Execute() method of instance of command with same name from current assembly
        /// </summary>
        /// <param name="args">name and criteries of command(name is args[0])</param>
        public static void InvokeCommand(params string[] args)
        {
            if (args == null || args.Length == 0) throw new ArgumentException("Args cannot be null or empty");
            var commandName = args[0];
            Commands[commandName].ExecuteCommand(args.Skip(1).ToArray());
            Console.WriteLine();
        }
    }

    public abstract class Command
    {
        public delegate void Execute(params string[] args);
        public string Name;

        /// <summary>
        /// Command help
        /// </summary>
        /// <returns>text, that help to understanding how to use command</returns>
        public abstract string _Help();
        public Execute OnExecute;

        public Command()
        {
            Name = GetType().Name;
            OnExecute = ExecuteCommand;
        }


        /// <summary>
        /// Execute command
        /// </summary>
        /// <param name="args">criteries of command</param>
        public virtual void ExecuteCommand(params string[] args)
        {

        }
    }

    public class Help : Command
    {
        
        public override void ExecuteCommand(params string[] args)
        {
            Console.WriteLine("Commands:");
            foreach(var command in CommandInvoker.Commands)
            {
                Console.WriteLine(command.Key);
                Console.WriteLine(command.Value._Help()+"\n");
            }
        }

        public override string _Help()
        {
            return "Show general information about current commands";
        }
    }

    public class GetData : Command
    {
        public override void ExecuteCommand(params string[] args)
        {
            int? count = null;
            var criteries = new Dictionary<string, string>();
            for(int i = 0; i<args.Length; i++)
            {
                var criteriaSplit = args[i].Split('=');
                criteries.Add(criteriaSplit[0], criteriaSplit[1]);
            }
            if (!criteries.ContainsKey("r")) throw new Exception("GetData command must contain \"r\" criteria with root to bin file.\nFor Example:\nGetData r=test.bin");
            IEnumerable<TestResult> data = TestResults.ReadResultsFrom(criteries["r"]);
            if (criteries.ContainsKey("o"))
            {
                var value = criteries["o"];
                if (value.ToLower()=="i")
                {
                    if (criteries.ContainsKey("a")) 
                    {
                        if (criteries["a"] == "+")
                            data = data.OrderBy(x => x.ID);
                        else if (criteries["a"] == "-")
                            data = data.OrderByDescending(x => x.ID);
                        else throw new ArgumentException("Wrong \"a\" param");
                    }
                    else
                        data = data.OrderBy(x => x.ID);
                }
                if (value.ToLower() == "s")
                {
                    if (criteries.ContainsKey("a"))
                    {
                        if (criteries["a"] == "+")
                            data = data.OrderBy(x => x.StudentName);
                        else if (criteries["a"] == "-")
                            data = data.OrderByDescending(x => x.StudentName);
                        else throw new ArgumentException("Wrong \"a\" param");
                    }
                    else
                        data = data.OrderBy(x => x.ID);
                }
                if (value.ToLower() == "t")
                {
                    if (criteries.ContainsKey("a"))
                    {
                        if (criteries["a"] == "+")
                            data = data.OrderBy(x => x.TestName);
                        else if (criteries["a"] == "-")
                            data = data.OrderByDescending(x => x.TestName);
                        else throw new ArgumentException("Wrong \"a\" param");
                    }
                    else
                        data = data.OrderBy(x => x.ID);
                }
                if (value.ToLower() == "d")
                {
                    if (criteries.ContainsKey("a"))
                    {
                        if (criteries["a"] == "+")
                            data = data.OrderBy(x => x.Date);
                        else if (criteries["a"] == "-")
                            data = data.OrderByDescending(x => x.Date);
                        else throw new ArgumentException("Wrong \"a\" param");
                    }
                    else
                        data = data.OrderBy(x => x.ID);
                }
                if (value.ToLower() == "a")
                {
                    if (criteries.ContainsKey("a"))
                    {
                        if (criteries["a"] == "+")
                            data = data.OrderBy(x => x.Assessment);
                        else if (criteries["a"] == "-")
                            data = data.OrderByDescending(x => x.Assessment);
                        else throw new ArgumentException("Wrong \"a\" param");
                    }
                    else
                        data = data.OrderBy(x => x.ID);
                }
            }
            if (criteries.ContainsKey("c"))
            {
                try
                {
                    count = int.Parse(criteries["c"]);
                }
                catch(Exception ex)
                {
                    throw new ArgumentException("Wrong \"c\" criteria");
                }
            }
            if (count != null)
            {
                data = data.Take(count.Value);
            }
            if (criteries.ContainsKey("vc"))
            {
                Console.WriteLine(TestResults.ToString(data, criteries["vc"]));
            }
            else
            {
                Console.WriteLine(TestResults.ToString(data));
            }
        }

        public override string _Help()
        {
            return "Show data from *.bin file.\nCriteries:\nr-root to *.bin file\n" +
                "vc-view criteria (default \"I|S|T|D|A\" means format \"ID|Student|Test|Date|Assessment\")\n" +
                "o-order criteria (if exist - order output by one of the params (I-id,S-student, etc.))\n" +
                "a-ascending param (if value is \"+\" order by ascending, if \"-\" - by descending)\n" +
                "c-count criteria (show only [count] elements)";
        }
    }

    public class TestInitiate:Command
    {
        public override void ExecuteCommand(params string[] args)
        {
            var rnd = new Random();
            var names = new List<string>() { "Jonatan", "Josef", "Jottaro" };
            var testNames = new List<string>() { "Math", "History", "English" };
            var results = new TestResults();
            int i = 0;
            foreach (var name in names)
            {
                foreach (var testName in testNames)
                {
                    results.results.Add(new TestResult(i, name, testName, DateTime.Now, (byte)rnd.Next(1, 5)));
                    i++;
                }
            }
            TestResults.WriteResultsTo(results, "test.bin");
        }

        public override string _Help()
        {
            return "Create a test.bin file with 9 elements";
        }
    }

    public class GetCommands : Command
    {
        public override void ExecuteCommand(params string[] args)
        {
            foreach(var command in CommandInvoker.Commands)
            {
                Console.WriteLine(command.Key);
            }
        }

        public override string _Help()
        {
            return "Show all commands";
        }
    }
}
