using System.Text.Json.Serialization;

namespace TalentLMSClient.Domain.Entities;

public sealed class Course
{
    /// <summary>
    /// The course's name.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// The course's description.
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>
    /// The course's code.
    /// </summary>
    [JsonPropertyName("code")] 
    public string Code { get; set; }

    /// <summary>
    /// The course's price.
    /// </summary>
    [JsonPropertyName("price")]
    public string Price { get; set; } = "0";

    /// <summary>
    /// The course's time limit.
    /// </summary>
    [JsonPropertyName("time_limit")] 
    public string TimeLimit { get; set; }

    /// <summary>
    /// The course's category id.
    /// </summary>
    [JsonPropertyName("category_id")]
    public string CategoryId { get; set; }

    /// <summary>
    /// The Id of the course creator.
    /// </summary>
    [JsonPropertyName("creator_id")]
    public string CreatorId { get; set; }
}
