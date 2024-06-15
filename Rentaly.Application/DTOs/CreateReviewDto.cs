namespace Rentaly.Application.DTOs;
public class CreateReviewDto
{
    public float StarsRate { get; set; }
    public string Comment { get; set; }
    public int UserId { get; set; }
    public int CarId { get; set; }
}
