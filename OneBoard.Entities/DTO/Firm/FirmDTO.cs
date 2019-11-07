using OneBoard.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Entities.DTO.Firm
{
    public class FirmDTO:IDTO
    {
        //public int ID { get; set; }
        public int? ParentID { get; set; }
        public string FirmName { get; set; }

        //{"Name":"kalem",
        // "Category":"kırtasiye",
        //  "Price":21} => Bu Product 'ta cast etmeye calısıcak Product Dto dan Örnek
        //Bu DTO ları kullanmak icin AutoMapper Kullanıcaz. Ki Firm de ki Classı eşletirmeyi sağlasın.
        //Mapping Class =>(Dto -Entity)
        //Mapster library can be instead of Automapper.
        //Without using These Library.
        //Product p = new Product();
        //p.nAME = ProductDto.name we assume that more than 20 prop.It can be harder to implement so that we can absolutely use .
    }
}
