namespace Management.API.Dtos.Response
{
    public class ClientResponseDto
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public PersonDto Person { get; set; }
    }
}
