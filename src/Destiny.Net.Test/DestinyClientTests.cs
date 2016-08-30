using System;
using System.Linq;
using System.Threading.Tasks;
using Destiny.Net.Core;
using Destiny.Net.Core.Model;
using Destiny.Net.Core.Model.Responses;
using Destiny.Net.Test.Configuration;
using Machine.Specifications;

namespace Destiny.Net.Test
{
    [Subject(typeof(DestinyClient))]
    public class DestinyClientTests
    {
        Establish context = () =>
        {
            var destinyApiKeyProvider = new DestinyApiKeyProvider(new EnvironmentVariableConfigurationProvider());

            _apiKey = destinyApiKeyProvider.GetApiKey();
            _client = new DestinyClient(_apiKey);
        };

        public class When_using_invalid_api_key
        {
            Establish context = () =>
            {
                _apiKey = string.Empty;
                _client = new DestinyClient(_apiKey);
            };

            Because of = () =>
            {
                _exception = Catch.Exception(() => _getAccountSummary = CallSync(() => _client.GetAccountSummary(Platform.PlayStation, "Tyridan")));
            };

            It should_throw_a_destiny_client_exception = () =>
            {
                _getAccountSummary.ShouldBeNull();

                var destinyClientException = (DestinyClientException)_exception;

                destinyClientException.ShouldNotBeNull();
                destinyClientException.ResponseEnvelope.ErrorCode.ShouldEqual(DestinyErrorCodes.ApiInvalidOrExpiredKey);
            };

            static Exception _exception;
            static GetAccountSummaryResponse _getAccountSummary;
        }

        public class When_getting_inventory_item
        {
            Because of = () =>
            {
                var task = _client.GetInventoryItem(1274330687);
                task.Wait();
                _inventoryItem = task.Result;
            };

            It should_have_a_name = () =>
            {
                _inventoryItem.ItemName.ShouldEqual("Gjallarhorn");
            };

            static InventoryItem _inventoryItem;
        }

        public class When_getting_manifest
        {
            Because of = () =>
            {
                _manifestResponse = CallSync(() => _client.GetDestinyManifest());
            };

            It should_not_be_null = () =>
            {
                _manifestResponse.ShouldNotBeNull();
            };

            static GetDestinyManifestResponse _manifestResponse;
        }

        public class When_getting_known_player
        {
            Because of = () =>
            {
                _getAccountSummaryResponse = CallSync(() => _client.GetAccountSummary(Platform.PlayStation, "Tyridan"));
            };

            It should_have_a_name = () =>
            {
                _getAccountSummaryResponse.Characters.First().CharacterLevel.ShouldEqual(40);
            };

            static GetAccountSummaryResponse _getAccountSummaryResponse;
        }

        public class When_getting_unknown_player
        {
            Because of = () =>
            {
                _getAccountSummaryResponse = CallSync(() => _client.GetAccountSummary(Platform.PlayStation, "TyridanUnknownPlayer"));
            };

            It should_be_null = () =>
            {
                _getAccountSummaryResponse.ShouldBeNull();
            };

            static GetAccountSummaryResponse _getAccountSummaryResponse;
        }

        static T CallSync<T>(Func<Task<T>> func)
        {
            var task = func();

            try
            {
                task.Wait();
            }
            catch (AggregateException ex)
            {
                throw ex.InnerException;
            }

            return task.Result;
        }

        static string _apiKey;
        static DestinyClient _client;
    }
}
