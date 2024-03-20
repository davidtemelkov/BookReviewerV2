using Microsoft.EntityFrameworkCore;

namespace BookReviewerV2.Data.Models;

[PrimaryKey(nameof(ListId), nameof(BookId))] 
public class ListBook
{
    public int ListId { get; set; }
    public int BookId { get; set; }
    
    public List List { get; set; }
    public Book Book { get; set; }
}