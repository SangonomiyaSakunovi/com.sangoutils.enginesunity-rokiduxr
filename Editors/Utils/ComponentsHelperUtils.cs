using SangoUtils.Engines_Unity.Rokid_UXR.Core;
using System;
using UnityEngine;

namespace SangoUtils.Engines_Unity.Rokid_UXR.Editors
{
#if UNITY_EDITOR
    internal static class ComponentsHelperUtils
    {
        internal static void AddComponentsHelper<T>(this GameObject gameObject) where T : MonoBehaviour
        {
            Component component = gameObject.AddComponent<T>();
            if (component is IComponentsHelper meta)
            {
                meta.OnInitialize();
            }
        }

        internal static void AddComponentsHelper(this GameObject gameObject, Type type)
        {
            Component component = gameObject.AddComponent(type);
            if (component is IComponentsHelper meta)
            {
                meta.OnInitialize();
            }
        }

        internal static void RemoveComponentsHelper<T>(this GameObject gameObject) where T : MonoBehaviour
        {
            if (gameObject.TryGetComponent<T>(out var component))
            {
                if (component is IComponentsHelper meta)
                {
                    Type[] types = meta.GetReleventComponents();
                    MonoBehaviour.DestroyImmediate(component);
                    foreach (var type in types)
                    {
                        var componentNeighbor = gameObject.GetComponent(type);
                        if (componentNeighbor != null)
                        {
                            MonoBehaviour.DestroyImmediate(componentNeighbor);
                        }
                    }
                }
            }
        }

        internal static void RemoveComponentsHelper(this GameObject gameObject, Type type)
        {
            Component component = gameObject.GetComponent(type);
            if (component != null)
            {
                if (component is IComponentsHelper meta)
                {
                    Type[] types = meta.GetReleventComponents();
                    MonoBehaviour.DestroyImmediate(component);
                    foreach (var childType in types)
                    {
                        var componentNeighbor = gameObject.GetComponent(childType);
                        if (componentNeighbor != null)
                        {
                            MonoBehaviour.DestroyImmediate(componentNeighbor);
                        }
                    }
                }
            }
        }
    }
#endif
}
