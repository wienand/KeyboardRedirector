﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ApplicationLauncher
{
    public class Settings
    {
        #region Static
        private static XMLFileStore<Settings> _xmlStore;
        public static void EnsureXmlStoreExists()
        {
            if (_xmlStore == null)
            {
                string filename = SettingsPath + @"settings.xml";
                _xmlStore = new XMLFileStore<Settings>(filename);
            }
        }
        public static void Save()
        {
            EnsureXmlStoreExists();
            _xmlStore.Save();
        }
        public static Settings Current
        {
            get
            {
                EnsureXmlStoreExists();
                return _xmlStore.Data;
            }
        }
        public static string SettingsPath
        {
            get
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                return path + @"\ApplicationLauncher\";
            }
        }
        #endregion

        public ShortcutList Shortcuts = new ShortcutList();
        public Point WindowLocation = new Point(-1, -1);
        public Size WindowSize = new Size(-1, -1);
        public bool Minimize = false;
    }

    public class ShortcutList : List<Shortcut>
    {
    }

    public class Shortcut
    {
        public string Name = "";
        public string Executable = "";
        public string Arguments = "";
        public bool SwitchTasksIfAlreadyRunning = true;
        public string WorkingFolder = "";
        public string Icon = "";

    }
}
