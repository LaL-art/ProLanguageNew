using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProLanguage.Models.Entities;

public class UserFile
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [StringLength(255)]
    public string FileName { get; set; }

    [Required]
    [StringLength(255)]
    public string FilePath { get; set; }

    [Required]
    public DateTime UploadDate { get; set; } = DateTime.Now;

    public bool IsPrivate { get; set; } = false;

    // Зберігаємо Username як зовнішній ключ 
    [ForeignKey("Username")]
    public string Username { get; set; }

    public virtual User User { get; set; } 
}
