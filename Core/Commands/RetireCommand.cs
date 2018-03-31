using System;
using System.Linq;
using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.Commands
{
    public class RetireCommand : Command
    {
        private const string Message = "No such units in repository.";

        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            
            string unitToRetire = this.Data[1];
            try
            {
                this.Repository.RemoveUnit(unitToRetire);
                return $"{unitToRetire} retired!";
            }
            catch(Exception e)
            {
                throw new ArgumentException(Message, e);
            }
            
            
            
            
        }
    }
}
