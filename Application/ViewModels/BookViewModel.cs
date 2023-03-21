using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class BookViewModel
    {
        [Required(ErrorMessage = "Book title must be informed.")]
        [MinLength(1)]
        [MaxLength(150)]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Book author must be informed.")]
        [MinLength(1)]
        [MaxLength(150)]
        [DisplayName("Author")]
        public string Author { get; set; }
    }
}