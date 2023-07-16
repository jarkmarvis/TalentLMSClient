using System.Text.Json.Serialization;
using TalentLMSClient.Domain.Entities.Common;

namespace TalentLMSClient.Domain.Entities;

/// <summary>
/// The User entity.
/// Used for Creating, Retrieving, and Updating a user.
/// </summary>
public class User : BaseEntity
{
    /// <summary>
    /// The user's id.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// The user's username name.
    /// </summary>
    [JsonPropertyName("login")]
    public string Login { get; set; }

    /// <summary>
    /// The user's first name.
    /// </summary>
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    /// <summary>
    /// The user's last name.
    /// </summary>
    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    /// <summary>
    /// The user's email address.
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }

    /// <summary>
    /// Controls whether the user will receive email notifications from the platform.
    /// '0' No emails sent or '1' emails will be sent.
    /// </summary>
    [JsonPropertyName("restrict_email")]
    public string RestrictEmail { get; set; }

    /// <summary>
    /// (Optional) The customizable type of user.
    /// </summary>
    [JsonPropertyName("user_type")]
    public string UserType { get; set; } = string.Empty;

    /// <summary>
    /// (Optional) The user's timezone
    /// </summary>
    [JsonPropertyName("timezone")]
    public string Timezone { get; set; } = string.Empty;

    /// <summary>
    /// (Optional) The user's specified language.
    /// </summary>
    [JsonPropertyName("language")]
    public string Language { get; set; } = string.Empty;

    /// <summary>
    /// (Optional) The user's status.
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// (Optional) The date that the user will be deactivated.
    /// Note: The deactivation date can be set only if the user is already active.
    /// Passing an empty value disables the deactivation date.
    /// </summary>
    [JsonPropertyName("deactivation_date")]
    public DateTime? DeactivationDate { get; set; }

    /// <summary>
    /// (Optional) The user's level.
    /// </summary>
    [JsonPropertyName("level")]
    public string Level { get; set; } = string.Empty;

    /// <summary>
    /// (Optional) The user's points.
    /// </summary>
    [JsonPropertyName("points")]
    public string Points { get; set; } = string.Empty;

    /// <summary>
    /// (Optional) The date that the user was created.
    /// </summary>
    [JsonPropertyName("created_on")]
    public DateTime? DateCreated { get; set; }

    /// <summary>
    /// (Optional) The date that the user was updated.
    /// </summary>
    [JsonPropertyName("last_updated")]
    public DateTime? DateUpdated { get; set; }

    /// <summary>
    /// (Optional) The timestamp that the user was updated.
    /// </summary>
    [JsonPropertyName("last_updated_timestamp")]
    public string LastUpdatedTimestamp { get; set; } = string.Empty;

    /// <summary>
    /// (Optional) The user's avatar.
    /// </summary>
    [JsonPropertyName("avatar")]
    public string Avatar { get; set; } = string.Empty;

    /// <summary>
    /// (Optional) The user's bio.
    /// </summary>
    [JsonPropertyName("bio")]
    public string Bio { get; set; } = string.Empty;

    /// <summary>
    /// (Optional) The user's login key.
    /// </summary>
    [JsonPropertyName("login_key")]
    public string LoginKey { get; set; } = string.Empty;

    /// <summary>
    /// The user's password.
    /// This field is required only when creating a new user, but is not returned when getting a user.
    /// </summary>
    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;

    

    

    /// <summary>
    /// (Optional) The branch id the user will be assigned to.
    /// </summary>
    [JsonPropertyName("branch_id")]
    public string BranchId { get; set; } = string.Empty;

    /// <summary>
    /// (Optional) The group id the user will be assigned to.
    /// </summary>
    [JsonPropertyName("group_id")]
    public string GroupId { get; set; } = string.Empty;

    

    

    
}
