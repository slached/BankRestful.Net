namespace hangi_kredi_restful.Models
{
    public class BankReturnType
    {
        public List<BankDto>? Banks { get; set; }
        public int? NextPage { get; set; }
        public int? PreviousPage { get; set; }
        public int TotalItem { get; set; }

    }
}
