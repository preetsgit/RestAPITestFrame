/// This class contains the general constants used in this project
public static class ConstUtil
{
    public static string BaseURI = "http://dummy.restapiexample.com/";
    public static string LogPath="RestAPILogs\\RestLog.txt";
    public static string MaxLogSize = "1GB";
    public static string LogConversionPattern = "%date [%thread] %-5level %logger - %message%newline"; 
    public static int MaxSizeRollBackup = 5;
    public static string JSONHeaderParameter = "application/json; charset=utf-8";
    public static string AddSuccessMessage = "Successfully! Record has been added";
    public static string UpdateSuccessMessage = "Successfully! Record has been updated";
    public static string DeleteSuccessMessage = "Successfully! Record has been deleted";

}