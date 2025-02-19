namespace DAL.DTO
{
    public class ShiftResponseModel
    {
        public int StatusCode { get; set; }

        public string Title { get; set; }
        public object Data { get; set; }

        public ShiftResponseModel(int statusCode, string title, object data)
        {
            StatusCode = statusCode;
            Title = title;
            Data = data;
        }
    }
}