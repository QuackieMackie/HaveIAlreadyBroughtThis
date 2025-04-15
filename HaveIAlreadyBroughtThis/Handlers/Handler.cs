using Dalamud.Plugin.Services;

namespace HaveIAlreadyBroughtThis.Handlers;

public static class Handler
{
    internal static readonly IAddonLifecycle.AddonEventDelegate InclusionShopEvent = InclusionShop.InclusionShopEvent;
    internal static readonly IAddonLifecycle.AddonEventDelegate ShopEvent = Shop.ShopEvent;
}
