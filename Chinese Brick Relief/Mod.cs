using Colossal.Logging;
using Game;
using Game.Modding;
using Game.SceneFlow;
using System.IO;
using Extra.Lib.Localization;
using System.Reflection;
using Extra.Lib.Debugger;

namespace ChineseBrickRelief
{
    public class Mod : IMod
    {
        private static ILog log = LogManager.GetLogger($"{nameof(ChineseBrickRelief)}.{nameof(Mod)}").SetShowsErrorsInUI(false);
        //internal static Logger Logger = new(log, false);

        private string pathToModFolder;

        public void OnLoad(UpdateSystem updateSystem)
        {
            if (!GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset)) return;

            pathToModFolder = $"{new FileInfo(asset.path).DirectoryName}";

            ExtraLocalization.LoadLocalization(log, Assembly.GetExecutingAssembly(), false, nameof(ChineseBrickRelief));

            ExtraAssetsImporter.EAI.LoadCustomAssets(pathToModFolder);

        }

        public void OnDispose()
        {
            ExtraAssetsImporter.EAI.UnLoadCustomAssets(pathToModFolder);
        }
    }
}
