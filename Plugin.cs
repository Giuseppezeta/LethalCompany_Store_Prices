using BepInEx;
using HarmonyLib;
using LethalCompanyPluginTemplate.Patches;
using BepInEx.Configuration;

namespace LethalCompanyPluginTemplate
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]

    public class Plugin : BaseUnityPlugin
    {
        public static Plugin Instance;
        private readonly Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);
        //config variables
        public static ConfigEntry<int> WalkieTalkie;
        public static ConfigEntry<int> Flashlight;
        public static ConfigEntry<int> Shovel;
        public static ConfigEntry<int> Lockpicker;
        public static ConfigEntry<int> ProFlashlight;
        public static ConfigEntry<int> Stun_granade;
        public static ConfigEntry<int> Boombox;
        public static ConfigEntry<int> TZP;
        public static ConfigEntry<int> Zap_gun;
        public static ConfigEntry<int> Jetpack;
        public static ConfigEntry<int> Extension_ladder;
        public static ConfigEntry<int> Radar_booster;
        //public static ConfigEntry<int> Loud_horn;
        //public static ConfigEntry<int> Teleporter;
        //public static ConfigEntry<int> Inverse_Teleporter;
        private void Awake()
        {
            // Plugin startup logic
            if (Plugin.Instance == null) { Plugin.Instance = this; };
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loading!");
            this.LoadConfigs();
            harmony.PatchAll(typeof(Plugin));
            harmony.PatchAll(typeof(salesPatch));
        }
        private void LoadConfigs()
        {
            WalkieTalkie = Config.Bind("Settings", "WalkieTalkie", 12, "");
            Flashlight = Config.Bind("Settings", "Flashlight", 15, "");
            Shovel = Config.Bind("Settings", "Shovel", 30, "");
            Lockpicker = Config.Bind("Settings", "Lockpicker", 20, "");
            ProFlashlight = Config.Bind("Settings", "ProFlashlight", 25, "");
            Stun_granade = Config.Bind("Settings", "Stun granade", 40, "");
            Boombox = Config.Bind("Settings", "Boombox", 60, "");
            TZP = Config.Bind("Settings", "TZP", 120, "");
            Zap_gun = Config.Bind("Settings", "Zap gun", 400, "");
            Jetpack = Config.Bind("Settings", "Jetpack", 700, "");
            Extension_ladder = Config.Bind("Settings", "Extension ladder", 60, "");
            Radar_booster = Config.Bind("Settings", "Radar booster", 50, "");
            //Loud_horn = Config.Bind("Settings", "Loud horn", 150, "");
            //Teleporter = Config.Bind("Settings", "Teleporter", 375, "");
            //Inverse_Teleporter = Config.Bind("Settings", "Inverse Teleporter", 425, "");
        }
    }
}