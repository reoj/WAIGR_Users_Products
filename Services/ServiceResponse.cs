namespace WAIGR_Users_Products.Services
{
    public class ServiceResponse<T>
    {
        /// <summary>
        /// True if the Response executed as expected, False if an exception ocurred
        /// </summary>
        public bool Successfull { get; set; } = true;
        /// <summary>
        /// The object expected by the user in the response. Null if an exception ocurrs
        /// </summary>
        public T? Body { get; set; }
        /// <summary>
        /// Aditional Information relevant to the state of the response. If an exception occurrs, the exception message can be copied here
        /// </summary>
        public String Message { get; set; } = "Success";

        public override string ToString()
        {
            string result = $"This response was {Successfull}\n";
            result += $"Containing the message: {this.Message}";
            return result;
        }
    }
}