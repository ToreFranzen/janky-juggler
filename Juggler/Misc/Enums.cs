namespace Juggler
{
    /// <summary>
    /// Style enum for setting wallpaper.
    /// </summary>
    internal enum Style : int
    {
        FitToScreen = 0,
        Tiled = 1,
        Centered = 2
    }

    /// <summary>
    /// Duration of displaying donfirm dialog in seconds
    /// </summary>
    internal enum ConfirmDuration : int
    {
        Five = 5,
        Ten = 10,
        Thirty = 30
    }

    /// <summary>
    /// Stores the menu indexes in enum to avoid collection traversing while accessing items and removing string literals
    /// </summary>
    internal enum MenuIndex : int
    {
        LastUpdCaption,
        LastWallpaper,
        Download,
        JuggleNow,
        Delete,
        Active,
        Preferences,
        About,
        Exit
    }

    /// <summary>
    /// Type of event sent to UI from the background downloading threads
    /// </summary>
    internal enum EventType : int
    {
        Start,
        Completed,
        ItemUpdate
    }

    /// <summary>
    /// Status of the image being downloaded. Its used to update UI with proper image status
    /// </summary>
    internal enum ImageStatus
    {
        Skipped,
        Downloaded,
        Saved,
        Started
    }

    /// <summary>
    /// Crawling status. Used to track the status and thread manipulation.
    /// </summary>
    internal enum CrawlStatus
    {
        Downloading,
        StopPending,
        StopRequested,
        Stopped
    }

    /// <summary>
    /// Reason why the download is being stopped.
    /// </summary>
    internal enum StopReason : int
    {
        /// <summary>
        /// Clicked stop buttom
        /// </summary>
        Stop,
        /// <summary>
        /// Form is being closed
        /// </summary>
        Close,
        /// <summary>
        /// Application is being exited
        /// </summary>
        Exit,
        /// <summary>
        /// User forced stop by clicking stop button twice
        /// </summary>
        Forced
    }

    /// <summary>
    /// Resolution type which maps 1-1 with resolution types on interfaceLift.com
    /// </summary>
    internal enum ResolutionType : int
    {
        Any,
        Widescreen,
        Fullscreen,
        HDTV,
        Dual_Monitors,
        Triple_Monitors,
        Mobile_Devices,
    }

    
}
