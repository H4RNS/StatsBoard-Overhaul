using System.Reflection;
using BepInEx;
using UnityEngine;
using UnityEngine.UI;

namespace StatsBoard_Overhaul
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        GameObject _statsBoardobj;
        Text _PlayerHeader;
        void Start() => GorillaTagger.OnPlayerSpawned(OnGameInitialized);
        void OnEnable() => HarmonyPatches.ApplyHarmonyPatches();
        void OnDisable() => HarmonyPatches.RemoveHarmonyPatches();
        void OnGameInitialized()
        {
            try
            {
                if (_statsBoardobj == null)
                {
                    _statsBoardobj = Instantiate(InitialiseBoard("StatsBoard-Overhaul.Resources.StatsBoard").LoadAsset<GameObject>("StatsBoard"));
                }
                else
                {
                    Debug.Log($"[StatsBoard]: SUCCESSFULLY, Initialized StatsBoard");
                }
            }
            catch
            {
                Debug.LogError($"[StatsBoard]: ERROR, when Initialing StatsBoard");
            }
            //_PlayerHeader = _statsBoardobj.transform.Find("").gameObject.GetComponent<Text>();
        }
        void ApplyContent()
        {
            //_PlayerHeader.text = PhotonNetwork.LocalPlayer.NickName;
        }
        void Update()
        {
            ApplyContent();
        }
        public AssetBundle InitialiseBoard(string path)
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            var assetBundle = AssetBundle.LoadFromStream(stream);
            stream.Close();
            return assetBundle;
        }
    }
}
