using System;
using System.Collections.Generic;
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
                _exception = Catch.Exception(() => _accountSummary = CallSync(() => _client.GetAccountSummary(Platform.PlayStation, "Tyridan")));
            };

            It should_throw_a_destiny_client_exception = () =>
            {
                _accountSummary.ShouldBeNull();

                var destinyClientException = (DestinyClientException)_exception;

                destinyClientException.ShouldNotBeNull();
                destinyClientException.ResponseEnvelope.ErrorCode.ShouldEqual(DestinyErrorCodes.ApiInvalidOrExpiredKey);
            };

            static Exception _exception;
            static AccountSummaryResponse _accountSummary;
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
                _manifestResponse = CallSync(() => _client.GetManifest());
            };

            It should_not_be_null = () =>
            {
                _manifestResponse.ShouldNotBeNull();
            };

            static ManifestResponse _manifestResponse;
        }

        public class When_getting_known_bungie_account
        {
            Because of = () =>
            {
                _bungieAccountResponse = CallSync(() => _client.GetBungieAccount("Tyridan", Platform.PlayStation));
            };

            It should_have_a_name = () =>
            {
                _bungieAccountResponse.DestinyAccounts.First().Characters.First().Level.ShouldEqual(40);
            };

            static BungieAccountResponse _bungieAccountResponse;
        }

        public class When_getting_unknown_bungie_account
        {
            Because of = () =>
            {
                _bungieAccountResponse = CallSync(() => _client.GetBungieAccount("TyridanUnknownPlayer", Platform.PlayStation));
            };

            It should_be_null = () =>
            {
                _bungieAccountResponse.ShouldBeNull();
            };

            static BungieAccountResponse _bungieAccountResponse;
        }

        public class When_searching_for_destiny_group
        {
            Because of = () =>
            {
                _groupSearchResponse = CallSync(() => _client.GroupSearch("DoD Graveyard Shift"));
            };

            It should_not_be_null = () =>
            {
                _groupSearchResponse.ShouldNotBeNull();
            };

            static GroupSearchResponse _groupSearchResponse;
        }

        public class When_searching_for_destiny_group_members
        {
            Because of = () =>
            {
                _membersResult = CallSync(() => _client.GetMembersOfGroup("886149"));
            };

            It should_not_be_null = () =>
            {
                _membersResult.ShouldNotBeNull();
            };

            static List<MemberResult> _membersResult;
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
