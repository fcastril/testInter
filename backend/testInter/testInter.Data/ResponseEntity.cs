namespace testInter.Data
{
    public class ResponseEntity
    {
        public bool Response { get; set; }
        public string Message { get; set; }
        public dynamic Result { get; set; }
        public string Href { get; set; }
        public ResponseEntity()
        {
            Response = false;
            Message = "Ocurrio un Error Inesperado";
        }
    }
}
