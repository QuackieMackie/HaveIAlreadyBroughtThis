using System;
using System.Numerics;
using Dalamud.Interface.Windowing;
using ImGuiNET;

namespace HaveIAlreadyBroughtThis.Windows;

public class ConfigWindow : Window, IDisposable
{
    public ConfigWindow() : base("A Wonderful Configuration Window###With a constant ID")
    {
        Flags = ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoScrollbar |
                ImGuiWindowFlags.NoScrollWithMouse;

        Size = new Vector2(232, 90);
        SizeCondition = ImGuiCond.Always;
    }

    public void Dispose() { }

    public override void PreDraw() { }

    public override void Draw() { }
}
