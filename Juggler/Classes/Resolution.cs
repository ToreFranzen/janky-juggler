namespace Juggler
{
    internal class Resolution
    {
        /// <summary>
        /// Width part of the resolution
        /// </summary>
        internal int Width { get; set; }
        /// <summary>
        /// Height part of the resolution
        /// </summary>
        internal int Height { get; set; }
        /// <summary>
        /// Display text to show in ComboBox. Use only to override default text. See ToString for more info.
        /// </summary>
        internal string DisplayText { get; set; }
        /// <summary>
        /// Text which will be used to prepare url to get html markup for pages. See InterfaceLiftWallpaperCrawler.GetBrowsingUrl for more info. Use only to override default text.
        /// </summary>
        internal string UrlPart { get; set; }
        /// <summary>
        /// Used to further classify the resolution. This is then used to prepare url to get html markup for pages. See InterfaceLiftWallpaperCrawler.GetBrowsingUrl for more info.
        /// </summary>
        internal ResolutionType ResolutionType { get; set; }

        private Resolution() { }

        public Resolution(int width, int height, ResolutionType resolutionType) : this(width, height, string.Empty, resolutionType) { }

        public Resolution(string displayText) : this(0, 0, displayText, ResolutionType.Any) { }

        public Resolution(int width, int height, string displayText, ResolutionType resolutionType) : this(width, height, displayText, displayText, resolutionType) { }

        public Resolution(int width, int height, string displayText, string urlPart, ResolutionType resolutionType)
        {
            this.Width = width;
            this.Height = height;
            this.DisplayText = displayText;
            this.UrlPart = urlPart.Length > 0 ? urlPart : this.ToString();
            this.ResolutionType = resolutionType;
        }

        /// <summary>
        /// This will be called by runtime when objects of Resolution type are added to ComboBox. Format as appropriate.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.DisplayText.Length > 0 ? this.DisplayText : this.Width.ToString() + "x" + this.Height.ToString();
        }
    }
}
