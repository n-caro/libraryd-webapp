using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSoft.Libraryd.Presentation.Actions
{
    abstract class Action: IAction
    {
        public readonly IServiceCollection _serviceProvider;
        public readonly string description;
        public Action(IServiceCollection serviceProvider, string description)
        {
            _serviceProvider = serviceProvider;
            this.description = description;
        }
        abstract public void runAction();
    }
}
