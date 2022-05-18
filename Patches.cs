// Decompiled with JetBrains decompiler
// Type: AutoLoadGame.Patches
// Assembly: AutoLoadGame, Version=1.1.1.0, Culture=neutral, PublicKeyToken=null
// MVID: DD249999-4DA8-4398-93B2-D10A42D454AF
// Assembly location: E:\Games\Steam\steamapps\common\BATTLETECH\Mods\AutoLoadGame\AutoLoadGame.dll

using BattleTech;
using BattleTech.Save;
using BattleTech.Save.SaveGameStructure;
using BattleTech.UI;
using Harmony;
using HBS;
using System;
using System.IO;
using System.Linq;
using UnityEngine;

namespace AutoLoadGame
{
    public class Patches
    {
        [HarmonyPatch(typeof(MainMenu), "ShowRefreshingSaves")]
        public static class MainMenu_ShowRefreshingSaves_Patch
        {
            private static bool doneMode;
            private static bool doneAbort;
            private static Mode mode;
            private static string saveFile = "Mods/AutoLoadGame/operatingMode.txt";

            public static bool Prepare()
            {
                try
                {
                    if (File.Exists(Patches.MainMenu_ShowRefreshingSaves_Patch.saveFile))
                    {
                        Patches.MainMenu_ShowRefreshingSaves_Patch.mode = (Mode)Enum.Parse(typeof(Mode), File.ReadAllText(Patches.MainMenu_ShowRefreshingSaves_Patch.saveFile));
                        Core.Log((object)("Read mode: " + (object)Patches.MainMenu_ShowRefreshingSaves_Patch.mode));
                    }
                    if (!Patches.MainMenu_ShowRefreshingSaves_Patch.doneMode)
                    {
                        if (!Input.GetKey(KeyCode.LeftControl))
                        {
                            if (!Input.GetKey(KeyCode.RightControl))
                                goto label_10;
                        }
                        switch (Patches.MainMenu_ShowRefreshingSaves_Patch.mode)
                        {
                            case Mode.Save:
                                Patches.MainMenu_ShowRefreshingSaves_Patch.mode = Mode.MechBay;
                                Core.Log((object)"Mode is MechBay");
                                break;
                            case Mode.MechBay:
                                Patches.MainMenu_ShowRefreshingSaves_Patch.mode = Mode.Save;
                                Core.Log((object)"Mode is Save");
                                break;
                        }
                        Core.Log((object)("Writing mode: " + (object)Patches.MainMenu_ShowRefreshingSaves_Patch.mode));
                        File.WriteAllText(Patches.MainMenu_ShowRefreshingSaves_Patch.saveFile, Patches.MainMenu_ShowRefreshingSaves_Patch.mode.ToString());
                        Core.Log((object)("Read back: " + (object)(Mode)Enum.Parse(typeof(Mode), File.ReadAllText(Patches.MainMenu_ShowRefreshingSaves_Patch.saveFile))));
                        Patches.MainMenu_ShowRefreshingSaves_Patch.doneMode = true;
                    }
                }
                catch (Exception ex)
                {
                    Core.Log((object)ex);
                }
            label_10:
                return !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift);
            }

            public static void Postfix(MainMenu __instance, BattleTech.Save.SaveGameStructure.SaveGameStructure ____saveStructure)
            {
                try
                {
                    if (Patches.MainMenu_ShowRefreshingSaves_Patch.doneAbort)
                    {
                        Core.Log((object)"Aborted loading once, return");
                    }
                    else
                    {
                        Patches.MainMenu_ShowRefreshingSaves_Patch.doneAbort = true;
                        Core.Log((object)("Running mode: " + (object)Patches.MainMenu_ShowRefreshingSaves_Patch.mode));
                        if (Patches.MainMenu_ShowRefreshingSaves_Patch.mode == Mode.MechBay)
                        {
                            Core.Log((object)"Loading MechBay");
                            LazySingletonBehavior<UIManager>.Instance.GetOrCreateUIModule<SkirmishMechBayPanel>().SetData();
                        }
                        else
                        {
                            Core.Log((object)"Loading Save");
                            SaveManager saveManager = UnityGameInstance.BattleTechGame.SaveManager;
                            SlotModel slotModel = ____saveStructure.GetAllSlots().OrderByDescending<SlotModel, DateTime>((Func<SlotModel, DateTime>)(x => x.SaveTime)).FirstOrDefault<SlotModel>();
                            Traverse.Create((object)__instance).Method("BeginResumeSave", (object)slotModel).GetValue();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Core.Log((object)ex);
                }
            }
        }
    }
}
