namespace Domain.Services
{
    public class ConfigureSettings : IConfigureSettings
    {
        public int GroupId { get; set; }
        public string ConfirmationString { get; set; }
        public string ApiKey { get; set; }
    }
}
