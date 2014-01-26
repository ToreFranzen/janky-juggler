using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Juggler
{
    class InterfaceLiftWallpaperCrawler : WallpaperCrawler
    {
        //http://interfacelift.com/wallpaper/downloads/date/2_screens/3840x1200/
        //http://interfacelift.com/wallpaper/7yz4ma1/03480_palousecanola_3840x1200.jpg

        public InterfaceLiftWallpaperCrawler()
        {
            base.BrowsingUrlPart = "http://interfacelift.com/wallpaper/downloads";
            base.DownloadUrlPart = "http://interfacelift.com/wallpaper/";
            //base.ImageCodePattern = new Regex(@"sndReqdown.this,'([0-9]*)[\s',]*(.*?)'", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline);
            //base.ImageCodePattern = new Regex(@"download_.+?href=""/wallpaper/download/(.+?)_(.+?)_", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline);
            base.ImageCodePattern = new Regex(@"download_[0-9]+.+?href=""/wallpaper/(.+?)/(.+?)_(.+?)_", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
            // download_.+?href=\"/wallpaper/([a-z0-9])+/(.+?)_(.+?)_
        }

        protected override string GetImageName(Match match)
        {
            string temp = string.Format("{0}/{1}_{2}_{3}x{4}.jpg",
                match.Groups[1].Value,
                match.Groups[2].Value,
                match.Groups[3].Value,                
                PreferredResolution.Width,
                PreferredResolution.Height);
            return string.Format("{0}/{1}_{2}_{3}x{4}.jpg",
                match.Groups[1].Value,
                match.Groups[2].Value,
                match.Groups[3].Value,
                PreferredResolution.Width,
                PreferredResolution.Height);
        }

        protected override string GetBrowsingUrl(int pageNo)
        {
            string temp = string.Format(@"{0}/{1}/{2}/{3}/index{4}.html", base.BrowsingUrlPart, SortBy.ToLower(), PreferredResolution.ResolutionType.GetResolutionUrl(), PreferredResolution.UrlPart, pageNo);
            return string.Format(@"{0}/{1}/{2}/{3}/index{4}.html", base.BrowsingUrlPart, SortBy.ToLower(), PreferredResolution.ResolutionType.GetResolutionUrl(), PreferredResolution.UrlPart, pageNo);
        }

        internal override Resolution[] GetResolutions()
        {
            return new Resolution[] {
                new Resolution("-: Widescreen 16:10 :-"),
                new Resolution(2560, 1600, ResolutionType.Widescreen), 
                new Resolution(1920, 1200, ResolutionType.Widescreen),
                new Resolution(1680, 1050, ResolutionType.Widescreen),
                new Resolution(1440, 900, ResolutionType.Widescreen),
                new Resolution(1280, 800, ResolutionType.Widescreen),

                new Resolution("-: Fullscreen 4:3 :-"),
                new Resolution(1600, 1200, ResolutionType.Fullscreen),
                new Resolution(1400, 1050, ResolutionType.Fullscreen),
                new Resolution(1280, 960, ResolutionType.Fullscreen),
                new Resolution(1024, 768, ResolutionType.Fullscreen),
                
                new Resolution("-: Fullscreen 5:4 :-"),
                new Resolution(1280, 1024, ResolutionType.Fullscreen),

                new Resolution("-: HDTV 16:9 :-"),
                new Resolution(1920, 1080, "1080p", ResolutionType.HDTV),
                new Resolution(1280, 720, "720p", ResolutionType.HDTV),

                new Resolution("-: Dual Monitors :-"),
                new Resolution(5120, 1600, ResolutionType.Dual_Monitors),
                new Resolution(3840, 1200, ResolutionType.Dual_Monitors),
                new Resolution(3360, 1050, ResolutionType.Dual_Monitors),
                new Resolution(3200, 1200, ResolutionType.Dual_Monitors),
                new Resolution(2880, 900, ResolutionType.Dual_Monitors),
                new Resolution(2560, 1024, ResolutionType.Dual_Monitors),

                new Resolution("-: Triple Monitors :-"),
                new Resolution(5040, 1050, ResolutionType.Triple_Monitors),
                new Resolution(4800, 1200, ResolutionType.Triple_Monitors),
                new Resolution(4320, 900, ResolutionType.Triple_Monitors),
                new Resolution(4096, 1024, ResolutionType.Triple_Monitors),
                new Resolution(3840, 1024, ResolutionType.Triple_Monitors),
                new Resolution(3840, 960, ResolutionType.Triple_Monitors),

                new Resolution("-: Mobile Devices :-"),
                new Resolution(800, 480, "UMPC et al (800x480)", ResolutionType.Mobile_Devices),
                new Resolution(320, 480,"iPhone (320x480)", "apple_iphone_320x480", ResolutionType.Mobile_Devices),
                new Resolution(480, 272,"PSP (480x272)", "sony_psp_480x272", ResolutionType.Mobile_Devices),
                new Resolution(320, 240,"Cellphone/iPod (320x240)", "cellphone_320x240", ResolutionType.Mobile_Devices)
            };
        }

        internal override string[] GetSortOptions()
        {
            return new string[] { "Date", "Downloads", "Rating", "Comments", "Random" };
        }
    }
}