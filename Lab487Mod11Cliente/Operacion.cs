using System.Web.Script.Serialization;

namespace Lab487Mod11Cliente
{
    public class Operacion
    {
        public int Op1 { get; set; }
        public int Op2 { get; set; }

        public string ToJson()
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();

            return ser.Serialize(this);
        }


    }
}
