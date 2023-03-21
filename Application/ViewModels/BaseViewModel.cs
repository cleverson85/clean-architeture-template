using NetDevPack.Domain;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels;

public class BaseViewModel
{
    [Key]
    public Guid Id { get; set; }
}
