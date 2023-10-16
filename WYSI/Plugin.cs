using HarmonyLib;
using IPA;
using IPA.Config;
using SiraUtil.Zenject;
using System.Reflection;
using WYSI.Installers;
using IPALogger = IPA.Logging.Logger;

namespace WYSI
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        internal static IPALogger Log { get; private set; }

        public const string HarmonyId = "com.iWYSIGalaxy.WYSI";
        internal static Harmony harmony;

        [Init]
        /// <summary>
        /// Called when the plugin is first loaded by IPA (either when the game starts or when the plugin is enabled if it starts disabled).
        /// [Init] methods that use a Constructor or called before regular methods like InitWithConfig.
        /// Only use [Init] with one Constructor.
        /// </summary>
        public Plugin(IPALogger logger, Zenjector zenjector)
        {
            Instance = this;
            Log = logger;
            harmony = new Harmony(HarmonyId);
            zenjector.Install<WYSIInstaller>(Location.App);
        }

        #region BSIPA Config
        [Init]
        public void InitWithConfig(Config conf)
        {
            Log.Debug("Config loaded");
        }
        #endregion

        [OnEnable]
        public void OnEnable()
        {
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        [OnDisable]
        public void OnDisable()
        {
            harmony.UnpatchSelf();
        }
    }
}
