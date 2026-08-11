using BepInEx;
using HarmonyLib;

namespace AutoWorkout
{
    [BepInPlugin(PluginsInfo.GUID, PluginsInfo.NAME, PluginsInfo.VERSION)]
    public class PluginsCore : BaseUnityPlugin
    {
        public void Awake()
        {
            var harmony = new Harmony(PluginsInfo.GUID);
            harmony.PatchAll();
        }
        public void Start()
        {
        }
        public void Update()
        {
        }
    }
}
