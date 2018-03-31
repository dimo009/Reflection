namespace _03BarracksFactory.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    using P03_BarraksWars.Core.Commands;

    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }
        
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // TODO: refactor for Problem 4
        private string InterpredCommand(string[] data, string commandName)
        {
            string result = string.Empty;
            Assembly asembly = Assembly.GetCallingAssembly();
            Type model = asembly.GetTypes().FirstOrDefault(m => m.Name.ToLower().Contains(commandName));

            if (model==null)
            {
                throw new ArgumentException("Invalid command!");
            }

            //could be cast to IExecutable or Command
            if (!typeof(IExecutable).IsAssignableFrom(model))
            {
                throw new ArgumentException("This command is not a valid one!");
            }

            MethodInfo method = typeof(IExecutable).GetMethods().FirstOrDefault(m => m.Name == "Execute");
            object[] constructorAtgs = new object[] { data, this.repository, this.unitFactory };
            object instance = Activator.CreateInstance(model,constructorAtgs);
            try
            {
                result = (string)method.Invoke(instance, null);
                return result;
            }
            catch (TargetInvocationException e)
            {

                throw e.InnerException;
            }
            
            
        }


        //private string ReportCommand(string[] data)
        //{
        //    string output = this.repository.Statistics;
        //    return output;
        //}


        ////private string AddUnitCommand(string[] data)
        ////{
        ////    string unitType = data[1];
        ////    IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
        ////    this.repository.AddUnit(unitToAdd);
        ////    string output = unitType + " added!";
        ////    return output;
        ////}
    }
}
