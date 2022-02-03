namespace GooglePhotos.AttributeFixer.App;

public static class CoordinateHelper
{
    public static (float Degrees, float Minutes, float Seconds) GetDegrees(double decimalCoordinate)
    {
        var degrees = (int)decimalCoordinate;
        var minutes = (decimalCoordinate - degrees) * 60;
        var seconds = (minutes - (int)minutes) * 60;

        return (degrees, (int)minutes, (float)seconds);
    }
}