public static class ConstUtil
{
    public static string BaseURI = "http://dummy.restapiexample.com/";
    public static string LogPath="RestAPILogs\\RestLog.txt";
    public static string MaxLogSize = "1GB";

    public static string LogConversionPattern = "%date [%thread] %-5level %logger - %message%newline"; 

    public static int MaxSizeRollBackup = 5;

}