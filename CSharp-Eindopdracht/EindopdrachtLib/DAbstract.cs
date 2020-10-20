using Newtonsoft.Json;

namespace EindopdrachtLib
{
    public abstract class DAbstract
    {
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
