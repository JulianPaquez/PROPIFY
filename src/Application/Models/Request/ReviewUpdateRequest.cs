using domain.Entities;

public class ReviewUpdateRequest
       { public int Id { get; set; }  // Para identificar qué review se está actualizando
        public int Clasification { get; set; }
        public string Comment { get; set; }
       }