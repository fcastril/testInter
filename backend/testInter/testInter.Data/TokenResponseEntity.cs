using System;

namespace testInter.Data
{
    public class TokenResponseEntity
    {
        public string token { get; set; }
        public DateTime expires { get; set; }
        public string login { get; set; }
        public string userName { get; set; }
    }
}
