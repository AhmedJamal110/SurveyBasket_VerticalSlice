namespace SurveyBasket_VerticalSlice.Middelwares
{
    public class TransactionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<TransactionMiddleware> _logger;

        public TransactionMiddleware(RequestDelegate next , ILogger<TransactionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext , ApplicationDbContext context)
        {
            var method = httpContext.Request.Method.ToUpper();

            if (method == "POST" || method == "PUT" || method == "DELETE")
            {
                var transaction = context.Database.BeginTransaction();

                try
                {
                   await  _next(httpContext);
                    var x =  await context.SaveChangesAsync();
                    var w = context.Polls.Where(p => p.Id == 11).Select(p => p.Id).FirstOrDefault();
                    await Console.Out.WriteLineAsync(w + " ======= ID ");
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    _logger.LogError("Error happend while Save changes", ex.Message);
                }
            }
            else
            {
                await _next(httpContext);
            }


        }


    }
}
