using System;
using System.Numerics;
using Dalamud.Game.Addon.Lifecycle;
using Dalamud.Game.Addon.Lifecycle.AddonArgTypes;
using Dalamud.Game.Text.SeStringHandling;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace HaveIAlreadyBroughtThis.Handlers;

public class InclusionShop
{
    internal static unsafe void InclusionShopEvent(AddonEvent eventType, AddonArgs args)
    {
        var inclusionShopAddon = (AtkUnitBase*)args.Addon;

        var itemList = (AtkComponentTreeList*)inclusionShopAddon->GetComponentByNodeId(19);
        if (itemList != null)
        {
            foreach (var item in itemList->Items)
            {
                var listItemRenderer = item.Value->Renderer;
                if (listItemRenderer == null)
                {
                    continue;
                }

                var text = (AtkTextNode*)listItemRenderer->GetTextNodeById(5);
                if (text == null)
                {
                    continue;
                }

                var itemName = SeString.Parse((byte*)text->GetText()).TextValue;
                if (itemName.Contains("A", StringComparison.OrdinalIgnoreCase))
                {
                    text->TextColor = Dalamud.Utility.Numerics.VectorExtensions.ToByteColor(new Vector4(0.6f, 0.4f, 0.4f, 1f));
                    text->SetText(SeString.Parse((byte*)text->GetText()).TextValue);
                }
            }
        }
    }
}
