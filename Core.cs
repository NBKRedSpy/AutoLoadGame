// Decompiled with JetBrains decompiler
// Type: AutoLoadGame.Core
// Assembly: AutoLoadGame, Version=1.1.1.0, Culture=neutral, PublicKeyToken=null
// MVID: DD249999-4DA8-4398-93B2-D10A42D454AF
// Assembly location: E:\Games\Steam\steamapps\common\BATTLETECH\Mods\AutoLoadGame\AutoLoadGame.dll

using Harmony;
using System;
using System.IO;
using System.Reflection;

namespace AutoLoadGame
{
    public class Core
    {
        internal static HarmonyInstance harmony;

        public static void Init(string modDir, string modSettings)
        {
            Core.Log((object)("Starting up " + DateTime.Now.ToShortTimeString()));
            Core.harmony = HarmonyInstance.Create("ca.gnivler.BattleTech.AutoLoadGame");
            Core.harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        internal static void Log(object input)
        {
        }
    }
}
