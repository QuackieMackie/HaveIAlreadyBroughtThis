using System;
using System.Linq;
using System.Numerics;
using Dalamud.Game.Addon.Lifecycle;
using Dalamud.Game.Addon.Lifecycle.AddonArgTypes;
using Dalamud.Game.Text.SeStringHandling;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace HaveIAlreadyBroughtThis.Handlers;

public class Shop
{
    internal static unsafe void ShopEvent(AddonEvent eventType, AddonArgs args)
    {
        var shopAddon = (AtkUnitBase*)args.Addon;
        var itemList = (AtkComponentList*)shopAddon->GetComponentByNodeId(16);

        foreach (uint index in Enumerable.Range(0, itemList->ListLength))
        {
            var listItemRenderer = itemList->ItemRendererList[index].AtkComponentListItemRenderer;

            if (listItemRenderer == null)
            {
                continue;
            }

            var text = (AtkTextNode*)listItemRenderer->GetTextNodeById(3);
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
