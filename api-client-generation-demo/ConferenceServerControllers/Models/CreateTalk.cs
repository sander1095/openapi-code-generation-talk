using System.ComponentModel.DataAnnotations;

namespace ConferenceServerControllers.Models
{
    public class CreateTalk
    {
        [StringLength(100)]
        public required string Title { get; set; }
    }
}
