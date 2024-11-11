namespace Olimpiaaa.Models
{
    public class DTOs
    {
        public record createPlayerDTO(string name, int age, int weight, int height);
        public record createDataDTO(string country, string county, string description, Guid playerID);

        public record updateDataDto(string country, string county, string description);
        public record updatePlayerDTO(string name, int age, int weight, int height);
        
    }
}
