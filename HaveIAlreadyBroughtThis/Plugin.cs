using System;
using System.Linq;
using System.Numerics;
using Dalamud.Game.Addon.Lifecycle;
using Dalamud.Game.Addon.Lifecycle.AddonArgTypes;
using Dalamud.Game.Text.SeStringHandling;
using Dalamud.Interface.Windowing;
using Dalamud.Plugin;
using FFXIVClientStructs.FFXIV.Component.GUI;
using HaveIAlreadyBroughtThis.Handlers;
using HaveIAlreadyBroughtThis.Windows;

namespace HaveIAlreadyBroughtThis;

public sealed class Plugin : IDalamudPlugin
{
    public Configuration Configuration { get; init; }

    public readonly WindowSystem WindowSystem = new("HaveIAlreadyBroughtThis");
    private ConfigWindow ConfigWindow { get; init; }

    public Plugin(IDalamudPluginInterface pluginInterface)
    {
        pluginInterface.Create<Service>();
        Configuration = Service.PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();
        
        Service.AddonLifecycle.RegisterListener(AddonEvent.PostDraw, ["Shop"], Handler.ShopEvent);
        Service.AddonLifecycle.RegisterListener(AddonEvent.PostDraw, ["InclusionShop"], Handler.InclusionShopEvent);
        
        ConfigWindow = new ConfigWindow();
        WindowSystem.AddWindow(ConfigWindow);

        Service.PluginInterface.UiBuilder.Draw += DrawUI;
        Service.PluginInterface.UiBuilder.OpenConfigUi += ToggleConfigUI;
    }
    
    public void Dispose()
    {
        WindowSystem.RemoveAllWindows();
        ConfigWindow.Dispose();

        Service.AddonLifecycle.UnregisterListener(AddonEvent.PostDraw, ["Shop"], Handler.ShopEvent);
        Service.AddonLifecycle.UnregisterListener(AddonEvent.PostDraw, ["InclusionShop"], Handler.InclusionShopEvent);
    }

    private void DrawUI() => WindowSystem.Draw();
    public void ToggleConfigUI() => ConfigWindow.Toggle();
}
