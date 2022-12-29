namespace IsbakAssessment
{
    public static class Globals
    {
        public static string ConnectionString { get; } = 
            "data source=.;initial catalog=IsbakAssessment;user id=sa;" +
            "MultipleActiveResultSets=True;integrated security=True;";
        public static string FrontendProjectUrl { get; } = "https://localhost:44356/signalrurl";
        public static int CurrencyFetchIntervalSecond { get; } = 30;
        public static string CoinMarketCapUrl { get; } = "https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest";
        public static string CoinMarketCapKey { get; } = "fb9f9115-e803-415d-8102-6a76a5342a2b";
    }
}
