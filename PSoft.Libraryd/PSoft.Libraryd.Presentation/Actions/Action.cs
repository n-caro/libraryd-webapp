using Microsoft.Extensions.DependencyInjection;
namespace PSoft.Libraryd.Presentation.Actions
{
    abstract class Action: IAction
    {
        protected string description;

        public Action (string description)
        {
            this.description = description;
        }
        abstract public void runAction();

        public string getDescription()
        {
            return description;
        }

    }
}
