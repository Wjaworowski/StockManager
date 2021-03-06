﻿namespace StockManager.Installers
{
    using System.Windows;

    using Microsoft.Practices.Unity;

    using Prism.Unity;

    /// <summary>
    /// Bootstrapper for IoC.
    /// </summary>
    /// <seealso cref="Prism.Unity.UnityBootstrapper" />
    public class Bootstrapper : UnityBootstrapper
    {
        /// <summary>
        /// Creates the shell or main window of the application.
        /// </summary>
        /// <returns>
        /// The shell of the application.
        /// </returns>
        /// <remarks>
        /// If the returned instance is a <see cref="T:System.Windows.DependencyObject" />, the
        /// <see cref="T:Prism.Bootstrapper" /> will attach the default <see cref="T:Prism.Regions.IRegionManager" /> of
        /// the application in its <see cref="F:Prism.Regions.RegionManager.RegionManagerProperty" /> attached property
        /// in order to be able to add regions by using the <see cref="F:Prism.Regions.RegionManager.RegionNameProperty" />
        /// attached property from XAML.
        /// </remarks>
        protected override DependencyObject CreateShell()
        {
            return this.Container.Resolve<MainWindow>();
        }

        /// <summary>
        /// Initializes the shell.
        /// </summary>
        protected override void InitializeShell()
        {
            base.InitializeShell();
            Window appWindow = this.Shell as Window;
            if ((appWindow == null) || (Application.Current == null))
            {
                return;
            }

            Application.Current.MainWindow = appWindow;
            Application.Current.MainWindow.Show();
        }

        /// <summary>
        /// IoC Container configuration
        /// </summary>
        protected override void ConfigureContainer()
        {
            AutomapperInstaller.Install(this.Container);
            DalInstaller.Install(this.Container);
            base.ConfigureContainer();
        }
    }
}
