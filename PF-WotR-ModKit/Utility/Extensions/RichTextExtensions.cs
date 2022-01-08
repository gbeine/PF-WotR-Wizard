using UnityEngine;

namespace PF_WotR_ModKit.Utility.Extensions
{
    public enum RGBA : uint {
        aqua = 0x00ffffff,
        blue = 0x8080ffff,
        brown = 0xC09050ff, //0xa52a2aff,
        cyan = 0x00ffffff,
        darkblue = 0x0000a0ff,
        fuchsia = 0xff40ffff,
        green = 0x40C040ff,
        lightblue = 0xd8e6ff,
        lime = 0x40ff40ff,
        magenta = 0xff40ffff,
        maroon = 0xFF6060ff,
        navy = 0x000080ff,
        olive = 0xB0B000ff,
        orange = 0xffa500ff, // 0xffa500ff,
        purple = 0xC060F0ff,
        red = 0xFF4040ff,
        teal = 0x80f0c0ff,
        yellow = 0xffff00ff,
        black = 0x000000ff,
        darkgrey = 0x808080ff,
        silver = 0xD0D0D0ff,
        grey = 0xC0C0C0ff,
        lightgrey = 0xE8E8E8ff,
        white = 0xffffffff,
    }

    public static class StringExtensions
    {
        public static string Bold(this string str) => $"<b>{str}</b>";

        public static string Color(this string str, Color color) => $"<color=#{ColorUtility.ToHtmlStringRGBA(color)}>{str}</color>";

        public static string Color(this string str, RGBA color) => $"<color=#{color:X}>{str}</color>";

        public static string Color(this string str, string color) => _ = $"<color={color}>{str}</color>";

        public static string Green(this string str) => _ = str.Color(RGBA.green);
        public static string Lightblue(this string str) => _ = str.Color(RGBA.lightblue);
        public static string Orange(this string str) => _ = str.Color(RGBA.orange);
        public static string Yellow(this string str) => _ = str.Color(RGBA.yellow);
    }
}