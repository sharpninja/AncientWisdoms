using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AncientWisdomsUapXaml
{
    public sealed partial class GamePage : Page
    {
        readonly AncientWisdomsGame _game;

        public GamePage()
        {
            this.InitializeComponent();

            // Create the game.
            var launchArguments = string.Empty;
            _game = MonoGame.Framework.XamlGame<AncientWisdomsGame>.Create(launchArguments, Window.Current.CoreWindow, swapChainPanel);
        }
    }
}
