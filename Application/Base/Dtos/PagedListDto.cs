namespace Application.Base.Dtos;

public class PagedListDto<T>
{
    public long Count { get; set; }
    public List<T> List { get; set; }

    public PagedListDto()
    {
        List = new List<T>();
    }
}