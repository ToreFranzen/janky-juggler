using System.Collections.Generic;
using System.Windows.Forms;

namespace Juggler
{
    internal static class ExtensionMethods
    {
        internal static ToolStripMenuItem Menu(this ToolStripItem[] menuItems, MenuIndex index)
        {
            return menuItems[(int)index] as ToolStripMenuItem;
        }

        internal static string FormattedTimePart(this int time, string unit)
        {
            return 1 > time ? string.Empty : (1 == time ? "1 " + unit : string.Format("{0} {1}s", time, unit));
        }

        internal static bool IsSameAs(this List<string> orig, List<string> toCompare)
        {
            if (orig.Count != toCompare.Count)
            {
                return false;
            }
            else
            {
                for (int i = 0 ; i < orig.Count ; i++)
                {
                    if (!orig[i].Equals(toCompare[i]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static string GetResolutionUrl(this ResolutionType theenum)
        {
            switch (theenum)
            {
                case ResolutionType.Dual_Monitors:
                    return "2_screens";
                case ResolutionType.Triple_Monitors:
                    return "3_screens";
                default:
                    return theenum.ToString().ToLower();
            }
        }
    }
}
