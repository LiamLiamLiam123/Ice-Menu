using Photon.Realtime;
using HarmonyLib;
using GTAG_NotificationLib;
using Photon.Pun;

namespace MalachiTemp.Backend
{
    /*
       PROTECTION NOTE: THIS TEMPLATE IS PROTECTED MATERIAL FROM "Project Malachi". 
       IF ANY MATERIAL FROM "MalachiTemp" FOUND IN ANY OTHER PROJECT/THING WITHOUT 
       CREDIT OR PERMISSION MUST AND WILL BE REMOVED IMMEDIATELY
    */

    [HarmonyPatch(typeof(MonoBehaviourPunCallbacks), "OnPlayerEnteredRoom")]
    internal class OnJoin : HarmonyPatch
    {
        private static void Prefix(Player newPlayer)
        {
            try
            {
                if (newPlayer != null)
                {
                    NotifiLib.SendNotification("[<color=blue>ROOM</color>] Player: " + newPlayer.NickName + " Joined Lobby");
                }
            }
            catch { }
        }
    }

    [HarmonyPatch(typeof(MonoBehaviourPunCallbacks), "OnPlayerLeftRoom")]
    internal class OnLeave : HarmonyPatch
    {
        private static void Prefix(Player otherPlayer)
        {
            try
        {
            if (otherPlayer != null && otherPlayer != PhotonNetwork.LocalPlayer)
            {
                NotifiLib.SendNotification("[<color=blue>ROOM</color>] Player: " + otherPlayer.NickName + " Left Lobby");
            }
        }
        catch { }
        }
    }
}