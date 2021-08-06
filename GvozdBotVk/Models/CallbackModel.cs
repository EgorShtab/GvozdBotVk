using Newtonsoft.Json;
using System;

namespace GvozdBotVk.Models
{
    [Serializable]
    public class CallbackModel
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("object")]
        public object Object { get; set; }
        [JsonProperty("group_id")]
        public int Group_Id { get; set; }
        [JsonProperty("event_id")]
        public string Event_Id { get; set; }
    }
}
