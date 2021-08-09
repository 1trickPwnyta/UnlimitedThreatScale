namespace UnlimitedThreatScale
{
    public static class Debug
    {
        public static void Log(string message)
        {
#if DEBUG
            Verse.Log.Message($"[{UnlimitedThreatScaleMod.PACKAGE_NAME}] {message}");
#endif
        }
    }
}
