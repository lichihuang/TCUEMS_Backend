public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoggingMiddleware> _logger;

    public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    // 中介軟體的Invoke方法，處理HTTP請求
    public async Task Invoke(HttpContext context)
    {
        _logger.LogInformation($"Request: {context.Request.Path}");

        await _next(context);

        _logger.LogInformation($"Response: {context.Response.StatusCode}");
    }
}
