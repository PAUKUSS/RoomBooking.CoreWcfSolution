
using System.ComponentModel.DataAnnotations;

namespace RoomBooking.WebClient.ViewModels;

public class RoomEditViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Название обязательно.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Локация обязательна.")]
    public string Location { get; set; } = string.Empty;

    [Range(1, 1000, ErrorMessage = "Вместимость должна быть больше нуля.")]
    public int Capacity { get; set; }

    public bool HasProjector { get; set; }
    public bool HasWhiteboard { get; set; }
    public string Description { get; set; } = string.Empty;
}
