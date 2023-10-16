using WYSI.AffinityPatches;
using Zenject;

namespace WYSI.Installers
{
    internal class WYSIInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Amogus>().AsSingle();
        }
    }
}
