using System.ComponentModel.DataAnnotations;

namespace ChatMVC.DTO
{
    public class MessageDTO
    {
        [Required]
        public string User { get; set; }

        [Required(ErrorMessage = "You can't send an empty message!")]
        public string MessageText { get; set; }
    }
}