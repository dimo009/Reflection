namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {



            Assembly assembly = Assembly.GetExecutingAssembly();

            //models = all classes in the project
            //assembly.GetTypes = gets all classes from the project and could be filtered out with linq
            Type[] models = assembly.GetTypes();
            Type model = assembly.GetTypes().FirstOrDefault(t => t.Name == unitType);

            if (model==null)
            {
                throw new ArgumentException("Invalid unit type!");
            }

            if (!typeof(IUnit).IsAssignableFrom(model))
            {
                throw new InvalidOperationException($"The {unitType} is not valid for this case!");
            }
            var constructor = model.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null, new Type[0], null);
            IUnit iunit = (IUnit)constructor.Invoke(null);

            //or the example below is from SoftUni lectors

            //IUnit iunit_II = (IUnit)Activator.CreateInstance(model); 
            return iunit;

           

            ////TODO: implement for Problem 3
            
        }
    }
}
