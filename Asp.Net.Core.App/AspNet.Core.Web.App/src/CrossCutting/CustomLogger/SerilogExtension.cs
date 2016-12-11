using Serilog;

namespace CustomLogger
{
    public static class SerilogExtension
    {
        /*User,
        Other,
        Enviornment,
        Host*/

        public static void CustomInformation(this ILogger logger, string user = "", string other = "", string enviornment = "", string host = "", string informationMessage = "")
        {
            logger.ForContext(CustomColumn.User.ToString(), user)
                  .ForContext(CustomColumn.User.ToString(), user)
                  .ForContext(CustomColumn.User.ToString(), user)
                  .ForContext(CustomColumn.User.ToString(), user)
                  .Information(informationMessage);
        }

        public static void CustomWarning(this ILogger logger, string user = "", string other = "", string enviornment = "", string host = "", string warningMessage = "")
        {
            logger.ForContext(CustomColumn.User.ToString(), user)
                  .ForContext(CustomColumn.User.ToString(), user)
                  .ForContext(CustomColumn.User.ToString(), user)
                  .ForContext(CustomColumn.User.ToString(), user)
                  .Warning(warningMessage);
        }

        public static void CustomError(this ILogger logger, string user = "", string other = "", string enviornment = "", string host = "", string errorMessage = "")
        {
            logger.ForContext(CustomColumn.User.ToString(), user)
                  .ForContext(CustomColumn.User.ToString(), user)
                  .ForContext(CustomColumn.User.ToString(), user)
                  .ForContext(CustomColumn.User.ToString(), user)
                  .Error(errorMessage);
        }

        public static void CustomFatal(this ILogger logger, string user = "", string other = "", string enviornment = "", string host = "", string fatalMessage = "")
        {
            logger.ForContext(CustomColumn.User.ToString(), user)
                  .ForContext(CustomColumn.User.ToString(), user)
                  .ForContext(CustomColumn.User.ToString(), user)
                  .ForContext(CustomColumn.User.ToString(), user)
                  .Fatal(fatalMessage);
        }
    }
}
