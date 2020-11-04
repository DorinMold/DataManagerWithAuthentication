using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TRMDesktopUI.ViewModels;

namespace TRMDesktopUI
{
    public class Bootstrapper : BootstrapperBase
    {
        //SimpleContainer is part of Caliburn.Micro to help with dependency injection
        private SimpleContainer _container = new SimpleContainer();
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            //base.Configure();
            _container.Instance(_container);
            _container.Singleton<IWindowManager, WindowManager>();
            _container.Singleton<IEventAggregator, EventAggregator>();

            GetType().Assembly.GetTypes()
                   .Where(type => type.IsClass)
                   .Where(type => type.Name.EndsWith("ViewModel"))
                   .ToList()
                   .ForEach(viewModelType => _container.RegisterPerRequest(
                      viewModelType, viewModelType.ToString(), viewModelType));
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            //base.OnStartup(sender, e);
            //it says on startup launch shellviewmodel as base view
            //plugin Caliburn.micro will use ShellViewModel to launch view ShellView (wiring them together)
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            //return base.GetInstance(service, key);
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            //return base.GetAllInstances(service);
            return _container.GetAllInstances(service);
        }
    }
}
