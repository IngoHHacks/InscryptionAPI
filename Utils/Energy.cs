using DiskCardGame;
using System.Collections;
using UnityEngine;

namespace APIPlugin
{
  public partial class Plugin
  {
    private void EnableEnergy(string sceneName)
    {
      if (sceneName == "Part1_Cabin")
      {
        UnityEngine.Object.Instantiate(Resources.Load<ResourceDrone>("prefabs/cardbattle/ResourceModules"));
        if(Plugin.configDrone.Value)
        {
          StartCoroutine(AwakeDrone());
        }
      }
    }

    private IEnumerator AwakeDrone()
    {
      yield return new WaitForSeconds(1);
      if (Singleton<ResourceDrone>.Instance != null)
      {
        Singleton<ResourceDrone>.Instance.Awake();
      }
      yield return new WaitForSeconds(1);
      if (Singleton<ResourceDrone>.Instance != null)
      {
        Singleton<ResourceDrone>.Instance.AttachGemsModule();
      }
    }
  }
}
