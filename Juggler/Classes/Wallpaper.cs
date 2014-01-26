using System;
using System.Collections.Generic;
using System.IO;
using Juggler.Properties;
using Microsoft.Win32;

namespace Juggler {
    internal class Wallpaper {
        private Settings settings;
        private Random rnd;
        ImageConvertor imageConvertor;

        public Wallpaper() {
            settings = Settings.Default;
            rnd = new Random();
            if (Program.IsVista)
            {
                imageConvertor = new WinVistaImageConvertor();
            }
            else
            {
                imageConvertor = new WinXpImageConvertor();
            }
        }

        /// <summary>
        /// Find an image and call the API functions
        /// </summary>
        public bool Juggle() {
            // Find an image file
            string path = DetermineImageFile();

            if (path == null || path.Length < 1) {
                return false;
            }
            else {
                // Set the image
                SetWallpaper(path, (Style)settings.Positioning);
            }

            // Save the settings
            settings.Save();

            return true;
        }

        /// <summary>
        /// Grab list of files, filter out bad choices, return good one randomly
        /// </summary>
        /// <returns></returns>
        private string DetermineImageFile() {
            // Specify top-level or sub-folders
            SearchOption opt = SearchOption.TopDirectoryOnly;
            if (settings.SubFolders)
            {
                opt = SearchOption.AllDirectories;
            }

            // Grab complete list of files from all folders
            List<string> wallpapers = new List<string>();
            foreach (string folder in settings.Folders.Split(new char[] { '|' }))
            {
                if (folder.Length == 0 || !Directory.Exists(folder)) continue;
                wallpapers.AddRange(Directory.GetFiles(folder, "*.jpg", opt));
            }

            // Make sure there is at least one wallpaper
            if (wallpapers.Count == 0) return null;

            // Randomly grab a file
            string filename = wallpapers[rnd.Next(wallpapers.Count)];

            // Remember last image shown
            settings.LastWallpaper = filename;

            return filename;
        }

        #region Constants
        /// <summary>
        /// Registry key for specifying the wallpaper style.
        /// </summary>
        private const string WallpaperStyle = @"WallpaperStyle";
        /// <summary>
        /// Registry key for specifying the wallpaper tiles.
        /// </summary>
        private const string Tile = @"TileWallpaper";
        /// <summary>
        /// The subkey to set the desktop key.
        /// </summary>
        private const string SubKey = @"Control Panel\Desktop";
        #endregion

        /// <summary>
        /// Set wallpaper and return status.
        /// </summary>
        /// <param name="path">The file path.</param>
        /// <param name="style">The style.</param>
        /// <remarks>
        /// Set the desktop wallpaper, and notify the 
        /// system that it has changed.
        /// </remarks>
        public bool SetWallpaper(string path, Style style)
        {
            // Check if the file existing.
            if (!System.IO.File.Exists(path))
                return false;

            RegistryKey key = Registry.CurrentUser.OpenSubKey(SubKey, true);

            switch (style)
            {
                case Style.FitToScreen:
                    key.SetValue(WallpaperStyle, "2");
                    key.SetValue(Tile, "0");
                    break;
                case Style.Centered:
                    key.SetValue(WallpaperStyle, "1");
                    key.SetValue(Tile, "0");
                    break;
                case Style.Tiled:
                    key.SetValue(WallpaperStyle, "1");
                    key.SetValue(Tile, "1");
                    break;
            }

            return NativeMethods.SystemParametersInfo(NativeMethods.SPI_SETDESKWALLPAPER, 0, imageConvertor.GetImage(path), NativeMethods.SPIF_UPDATEINIFILE | NativeMethods.SPIF_SENDWININICHANGE) != 0;
        }
    }
}
