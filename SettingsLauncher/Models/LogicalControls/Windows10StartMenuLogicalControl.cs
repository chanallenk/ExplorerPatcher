﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Win32;
using SettingsLauncher.Contracts.Models;
using SettingsLauncher.Helpers;

namespace SettingsLauncher.Models.LogicalControls;
public class Windows10StartMenuLogicalControl : LogicalControlBase, ILogical
{
    public string Name => "IsWindows10StartMenu";

    public bool Inverted
    {
        get;
        set;
    }

    public override bool CanBeEnabled()
    {
        bool returnVal;
        try
        {
            var oldStart = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "Start_ShowClassicMode", "")?.ToString()?.ToInt();

            if (oldStart != null && oldStart > 0)
            {
                returnVal =  true;
            }
        }
        catch (Exception ex) { }

        returnVal = false;

        return Inverted ? !(returnVal) : returnVal;
    }
}
