using domain.Entities;

public class ReviewCreateRequest
{
    public int Clasification { get; set; }
        public int IdUser { get; set; }
        public int IdProp { get; set; }
        public string Comment { get; set; }
   
}