using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Juggler
{
    class WallpaperStockWallpaperCrawler : WallpaperCrawler
    {
        public WallpaperStockWallpaperCrawler()
        {
            base.BrowsingUrlPart = "http://wallpaperstock.net/wallpapers";
            base.DownloadUrlPart = "http://wallpaperstock.net/";
            base.ImageCodePattern = new Regex(@"
                wallpaper_thumb
                .+?
                href='/
                (.+?)
                -wallpapers_w
                (\d+?)
                \.", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline);
        }

        // http://wallpaperstock.net/nature-wallpapers_1.html
        // http://wallpaperstock.net/yellow-flower-on-pink-background-wallpapers_w42313.html
        // http://wallpaperstock.net/yellow-flower-on-pink-background_wallpapers_42313_1920x1200_1.html

        protected override string GetImageName(System.Text.RegularExpressions.Match match)
        {
            return string.Format("{0}_wallpapers_{1}_{2}x{3}.jpg",
                match.Groups[1].Value,
                match.Groups[2].Value,
                PreferredResolution.Width,
                PreferredResolution.Height);
        }

        protected override string GetBrowsingUrl(int pageNo)
        {
            return string.Format(@"{0}{1}_{2}r.html", base.BrowsingUrlPart, 
                pageNo < 2 ? string.Empty : "_p" + ((pageNo - 1) * 28).ToString(), PreferredResolution.UrlPart);
        }

        internal override Resolution[] GetResolutions()
        {
            return new Resolution[] {
                new Resolution("-: Widescreen :-"),
                new Resolution(2560, 1600, ResolutionType.Widescreen), 
                new Resolution(1920, 1200, ResolutionType.Widescreen),
                new Resolution(1680, 1050, ResolutionType.Widescreen),
                new Resolution(1440, 900, ResolutionType.Widescreen),
                new Resolution(1280, 800, ResolutionType.Widescreen),

                new Resolution("-: Fullscreen :-"),
                new Resolution(2560, 1920, ResolutionType.Fullscreen),
                new Resolution(1920, 1440, ResolutionType.Fullscreen),
                new Resolution(1600, 1200, ResolutionType.Fullscreen),
                new Resolution(1280, 1024, ResolutionType.Fullscreen),
                new Resolution(1280, 960, ResolutionType.Fullscreen),
                new Resolution(1152, 864, ResolutionType.Fullscreen),
                new Resolution(1024, 768, ResolutionType.Fullscreen),
           };
        }

        internal override string[] GetSortOptions()
        {
            return new string[] { "N/A" };
        }
    }
}
