using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionPos.Dto.DirectoryDto
{
    public class CreateDirectoryDto
    {
        [DisplayName("Ad")]
        [Required(ErrorMessage ="{0} boş olamaz")]
        [StringLength(100,ErrorMessage ="{0} {1} karakterden fazla olamaz")]
        [RegularExpression(@"[a-zA-ZğüşöıçİĞÜŞÖÇ\s]*", ErrorMessage = "{0} sadece harf içerebilir")]

        public string FirstName { get; set; } = string.Empty;
        [DisplayName("Soyad")]
        [Required(ErrorMessage = "{0} boş olamaz")]
        [StringLength(100, ErrorMessage = "{0} {1} karakterden fazla olamaz")]
        [RegularExpression(@"[a-zA-ZğüşöıçİĞÜŞÖÇ\s]*", ErrorMessage = "{0} sadece harf içerebilir")]
        public string LastName { get; set; } = string.Empty;
        [DisplayName("Telefon Numarası")]
        [Required(ErrorMessage = "{0} boş olamaz")]
        [MinLength(9,ErrorMessage ="{0} En az {1} hane olmalıdır")]
        [Phone(ErrorMessage ="Telefon Numarası Geçerli Değil")]
        public string TelephoneNumber { get; set; } = string.Empty; 

    }
}
