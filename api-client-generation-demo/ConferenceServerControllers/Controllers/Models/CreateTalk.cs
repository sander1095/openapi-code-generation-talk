using System.ComponentModel.DataAnnotations;

namespace ConferenceServerControllers.Controllers.Models
{
    public class CreateTalk
    {
        [StringLength(100)]
        public required string Title { get; set; }
    }
}
