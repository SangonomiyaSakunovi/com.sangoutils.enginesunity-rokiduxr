using System;

namespace SangoUtils.Engines_Unity.Rokid_UXR.Core
{
    internal interface IComponentsHelper
    {
        void OnInitialize();

        Type[] GetReleventComponents();
    }
}
