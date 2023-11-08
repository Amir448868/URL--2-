

namespace AcortURL.Models
{
    public class GetUserByIdDto //Acá usamos un dto que creamos para esta consulta, ya que no queremos que nos quede User -> Contact -> User -> Contact, etc
    {
        public int Id { get; set; }
 
        public string UserName { get; set; }
      
     
    }
}
