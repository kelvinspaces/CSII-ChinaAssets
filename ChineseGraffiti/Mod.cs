using Colossal.Logging;
using Game;
using Game.Modding;
using Game.SceneFlow;
using System.IO;
using Extra.Lib.Localization;
using System.Reflection;

namespace ChineseGraffiti
{
    public class Mod : IMod
    {
        public static ILog log = LogManager.GetLogger($"{nameof(ChineseGraffiti)}.{nameof(Mod)}").SetShowsErrorsInUI(false);

        private string pathToModFolder;

        public void OnLoad(UpdateSystem updateSystem)
        {
            if (!GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset)) return;

            pathToModFolder = $"{new FileInfo(asset.path).DirectoryName}";

            ExtraLocalization.LoadLocalization(log, Assembly.GetExecutingAssembly(), false, nameof(ChineseGraffiti));

            ExtraAssetsImporter.EAI.LoadCustomAssets(pathToModFolder);

        }

        public void OnDispose()
        {
            ExtraAssetsImporter.EAI.UnLoadCustomAssets(pathToModFolder);
        }
    }
}
