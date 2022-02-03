namespace GooglePhotos.AttributeFixer.App;

public class GoogleFileInfo
{
    public string title { get; set; }

    public string description { get; set; }
    
    public GoogleTimeInfo creationTime { get; set; }
    
    public GoogleTimeInfo photoTakenTime { get; set; }
    
    public GoogleGeoData geoData { get; set; }
    
    public GoogleGeoData geoDataExif { get; set; }
    
    public string url { get; set; }
}

public class GoogleTimeInfo
{
    public string timestamp { get; set; }
    
    public string formatted { get; set; }
}

public class GoogleGeoData
{
    public double latitude { get; set; }
    
    public double longitude { get; set; }
    
    public double altitude { get; set; }
    
    public double latitudeSpan { get; set; }
    
    public double longitudeSpan { get; set; }
}