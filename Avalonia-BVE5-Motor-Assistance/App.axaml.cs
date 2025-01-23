using System;
using System.Globalization;
using System.Linq;
using Avalonia_BVE5_Motor_Assistance.ViewModels;
using Avalonia_BVE5_Motor_Assistance.Views;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Avalonia.Metadata;

[assembly: XmlnsDefinition("https://github.com/avaloniaui", "Avalonia.BVE5_Motor_Assistance.Controls")]

namespace Avalonia_BVE5_Motor_Assistance;

public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var readCfg = new ReadCfg();
        var language = readCfg.GetSettingsKey("language");

        if (!string.IsNullOrEmpty(language))
        {
            Lang.Resources.Culture = new CultureInfo(language);
        }


        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            DisableAvaloniaDataAnnotationValidation();
            desktop.MainWindow = new EditWindow("test",120)
            {
                DataContext = new EditWindowViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove) BindingPlugins.DataValidators.Remove(plugin);
    }
}