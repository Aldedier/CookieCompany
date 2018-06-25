namespace CookieCompany.Model.Services.Data
{
    using System.Runtime.Serialization;

    [DataContract(Name ="MiServicio", Namespace = "https://miservicio.com")]
    public class ProductoDTO
    {
        [DataMember(Order = 3)]
        public int Id { get; set; }

        [DataMember(Order = 1)]
        public string Name { get; set; }

        [DataMember(Order = 1)]
        public string Image { get; set; }
    }
}
