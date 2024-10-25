using TronNet;

namespace TronGenerateWallet.Services
{
    public class TronWalletGenerateService
    {
        private readonly ITronClient _tronClient;

        public TronWalletGenerateService(ITronClient tronClient)
        {
            _tronClient = tronClient;
        }

        public async Task<string> GenerateTronWalletAsync()
        {
            var key = TronECKey.GenerateKey(TronNetwork.MainNet);
            var privatekey=key.GetPrivateKey();
            var address = key.GetPublicAddress();
            Console.WriteLine($"--PrivateKey:{privatekey}\nWalletAdress:{address}--");
            return $"Private Key:{privatekey}\nAddress:{address}";
        }
    }
}
