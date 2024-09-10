using WebApplicationKitap.CustomValidation;

namespace WebApplicationKitap.Models
{
	public class Yazar
	{
        // ! koymak merak etme bu değer null gelmeyecek demektir
        public int Id { get; set; }
        [NameLengthValidation]
        public string? Name { get; set; }
        public int Age { get; set; }
    }
}
