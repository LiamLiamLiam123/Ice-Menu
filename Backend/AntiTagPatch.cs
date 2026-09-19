using HarmonyLib;
using Photon.Pun;

namespace MalachiTemp.Backend
{
    /*
       PROTECTION NOTE: THIS TEMPLATE IS PROTECTED MATERIAL FROM "Project Malachi". 
       IF ANY MATERIAL FROM "MalachiTemp" FOUND IN ANY OTHER PROJECT/THING WITHOUT 
       CREDIT OR PERMISSION MUST AND WILL BE REMOVED IMMEDIATELY
    */
    [HarmonyPatch(typeof(GorillaGameManager), "LocalTag")]
    internal class AntiTagPatch
    {
        public static bool enabled = false;
        private static bool Prefix(NetPlayer taggedPlayer, NetPlayer taggingPlayer)
        {
            try
            {
                return !(enabled && taggedPlayer != null && taggingPlayer != null && taggedPlayer.IsLocal);
            }
            catch
            {
                return true;
            }
        }
    }
}