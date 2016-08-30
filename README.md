# Destiny.Net

An unofficial and opinionated .NET wrapper for the Destiny API

Currently supported APIs:

/{membershipType}/Account/{destinyMembershipId}/														GET		Returns Destiny account information for the supplied membership. DEPRECATED - Please use GetAccountSummary instead, pretty please with sugar on top. Seriously, we'll be BFFs 4 evah.
/{membershipType}/Account/{destinyMembershipId}/Summary/												GET		Returns Destiny account information for the supplied membership in a compact summary form. Don't you want to be a cool kid and use this service instead of GetAccount?
/Manifest/																								GET		Returns the current version of the manifest as a json object.
/Manifest/{type}/{id}/																					GET		Returns the specific item from the current manifest a json object.
/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Inventory/						GET		Returns the inventory for the supplied character. DEPRECATED - please use GetCharacterInventorySummary, pretty please with sugar on top.
/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Inventory/Summary/				GET		Returns summary information for the inventory for the supplied character.

Remaining APIs:

/Stats/ActivityHistory/{membershipType}/{destinyMembershipId}/{characterId}/							GET		Gets activity history stats for indicated character.
/{membershipType}/Account/{destinyMembershipId}/Items/													GET		Returns information about all items on the for the supplied Destiny Membership ID, and a minimal set of character information so that it can be used.
/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Activities/						GET		Retrieve the inventory for the supplied character.
/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Progression/					GET		Provides the progression details for the supplied character.
/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/								GET		Returns a character summary for the supplied membership.
/Stats/AggregateActivityStats/{membershipType}/{destinyMembershipId}/{characterId}/						GET		Gets all activities the character has participated in together with aggregate statistics for those activities.
/Explorer/Items/																						GET		Gets a page list of Destiny items.
/Explorer/TalentNodeSteps/																				GET		Gets a page list of Destiny talent node steps, ordered by the step name.
/Vanguard/Grimoire/{membershipType}/{membershipId}/														GET		Gets someone else's Grimoire.
/Vanguard/Grimoire/Definition/																			GET		Gets Grimoire definitions.
/Stats/{membershipType}/{destinyMembershipId}/{characterId}/											GET		Gets historical stats for indicated character.
/Stats/Definition/																						GET		Gets historical stats definitions.
/Stats/Account/{membershipType}/{destinyMembershipId}/													GET		Gets aggregate historical stats organized around each character for a given account.
/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Inventory/{itemInstanceId}/		GET		Retrieve the details of a Destiny Item.
/{membershipType}/Stats/GetMembershipIdByDisplayName/{displayName}/										GET		Returns the numerical id of a player based on their display name, zero if not found.
/Stats/PostGameCarnageReport/{activityId}/																GET		Gets the available post game carnage report for the activity ID.
/{membershipType}/Account/{destinyMembershipId}/Triumphs/												GET		Provides Triumphs for a given Destiny account.
/Stats/UniqueWeapons/{membershipType}/{destinyMembershipId}/{characterId}/								GET		Gets details about unique weapon usage, including all exotic weapons.
/SearchDestinyPlayer/{membershipType}/{displayName}/													GET		Returns a list of Destiny memberships given a full Gamertag or PSN ID.
