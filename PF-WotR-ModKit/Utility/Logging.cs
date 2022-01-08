
using System;
using System.IO;
using PF_WotR_ModKit.Utility.Extensions;
using UnityModManagerNet;
using static UnityModManagerNet.UnityModManager;

namespace PF_WotR_ModKit.Utility
{
    public enum LogLevel : int
    {
        Error,
        Warning,
        Info,
        Debug,
        Trace
    }

    public static class Mod {
        public static ModEntry modEntry { get; set; } = null;
        public static string modEntryPath { get; set; } = null;

        public static LogLevel logLevel = LogLevel.Info;
        
        private static ModEntry.ModLogger modLogger;

        private static StreamWriter logFile;
        
        public static void OnLoad(ModEntry modEntry) {
            Mod.modEntry = modEntry;
            modLogger = modEntry.Logger;
            modEntryPath = modEntry.Path;
            logFile = File.AppendText(modEntryPath + "/" + "log.txt");
        }
        
        public static void Error(string str) {
            modLogger?.Error(str.Yellow().Bold() + "\n" + Environment.StackTrace);
            append(str + "\n" + Environment.StackTrace);
        }
        
        public static void Error(Exception ex) => Error(ex.ToString());
        
        public static void Warn(string str) {
            if (logLevel >= LogLevel.Warning)
            {
                modLogger?.Log("[Warn] ".Orange().Bold() + str);
                append("[Warn] " + str);
            }
        }
        
        public static void Log(string str) {
            if (logLevel >= LogLevel.Info)
            {
                modLogger?.Log("[Info] " + str);
                append("[Info] " + str);
            }
        }
        
        public static void Debug(string str) {
            if (logLevel >= LogLevel.Debug)
            {
                modLogger?.Log("[Debug] ".Green() + str);
                append("[Debug] " + str);
            }
        }
        
        public static void Trace(string str) {
            if (logLevel >= LogLevel.Trace)
            {
                modLogger?.Log("[Trace] ".Lightblue() + str);
                append("[Trace] " + str);
            }
        }
        private static void append(string logMessage)
        {
            logFile.WriteLine("{0} {1}: {2}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString(), logMessage);
            logFile.Flush();
        }
    }
}
