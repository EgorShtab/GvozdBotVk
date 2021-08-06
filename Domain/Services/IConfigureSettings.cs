namespace Domain.Services
{
    public interface IConfigureSettings
    {
        public int GroupId { get; set; }
        public string ConfirmationString { get; set; }
        public string ApiKey { get; set; }
    }
}
