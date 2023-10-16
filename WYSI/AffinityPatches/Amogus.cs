using SiraUtil.Affinity;
using TMPro;

namespace WYSI.AffinityPatches
{
    internal class Amogus : IAffinity
    {
        [AffinityPrefix]
        [AffinityPatch(typeof(TMP_Text), nameof(TMP_Text.text), AffinityMethodType.Setter)]
        private void Joke(ref string value)
        {
            if (value == null)
            {
                return;
            }
            if (value.EndsWith("7.27") || value.EndsWith("727") || value.EndsWith("7:27"))
            {
                value += " WYSI";
            }
            else
            {
                value = value.Replace("7.27", "7.27 WYSI");
                value = value.Replace("7,27", "7,27 WYSI");
                value = value.Replace("7:27", "7:27 WYSI");
                value = value.Replace("727 ms", "WYSI ms");
                value = value.Replace("727", "WYSI");
                value = value.Replace("72.7", "72.7 WYSI");
                value = value.Replace("72,7", "72,7 WYSI");
                value = value.Replace("96.41", "96.41 WYSI");
                value = value.Replace("96,41", "96,41 WYSI");
            }
        }
    }
}