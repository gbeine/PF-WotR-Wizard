namespace PF_WotR_Core.Facades
{
    public static class Harmony
    {
        internal delegate ref TS FastRef<in T, TS>(T source = default);

        internal static FastRef<T, TS> CreateFieldGetter<T, TS>(string name) =>
            new FastRef<T, TS>(
                HarmonyLib.AccessTools.FieldRefAccess<T, TS>(
                    HarmonyLib.AccessTools.Field(typeof(T), name)));

        internal static FastSetter<T, TS> CreateFieldSetter<T, TS>(string name) =>
            new FastSetter<T, TS>(
                HarmonyLib.FastAccess.CreateSetterHandler<T, TS>(
                    HarmonyLib.AccessTools.Field(typeof(T), name)));
            // new FastRef<T, TS>(
            //     HarmonyLib.AccessTools.FieldRefAccess<T, TS>(
            //         HarmonyLib.AccessTools.Field(typeof(T), name)));

        
        //return new FastSetter<T, S>(HarmonyLib.FastAccess.CreateSetterHandler<T, S>(HarmonyLib.AccessTools.Field(typeof(T), name)));

        internal delegate void FastSetter<in T, in TS>(T source, TS value);
        
        //
        // public delegate S FastGetter<in T, out S>(T source);

    }
}