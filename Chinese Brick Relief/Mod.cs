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
        private static readonly ILog log = LogManager.GetLogger($"{nameof(ChineseBrickRelief)}").SetShowsErrorsInUI(false);
        internal static Logger Logger = new(log, false);

        private string pathToModFolder;

        public void OnLoad(UpdateSystem updateSystem)
        {
            if (!GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset)) return;

            pathToModFolder = $"{new FileInfo(asset.path).DirectoryName}";

            ExtraAssetsImporter.EAI.LoadCustomAssets(pathToModFolder);

            ExtraLocalization.LoadLocalization(Logger, Assembly.GetExecutingAssembly());

        }

        public void OnDispose()
        {
            ExtraAssetsImporter.EAI.UnLoadCustomAssets(pathToModFolder);
        }
    }
}
