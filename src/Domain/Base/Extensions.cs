namespace Domain.Base;

public static class Extensions
{

    public static DateTime BrazilDateTime(this DateTime dataHora)
    {
        TimeZoneInfo timeZone = GetTimeZone();
        return TimeZoneInfo.ConvertTime(dataHora, timeZone);
    }
    private static TimeZoneInfo GetTimeZone()
    {
        try
        {
            return TimeZoneInfo.FindSystemTimeZoneById("America/Sao_Paulo");
        }
        catch (Exception)
        {
            return TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
        }
    }
}
