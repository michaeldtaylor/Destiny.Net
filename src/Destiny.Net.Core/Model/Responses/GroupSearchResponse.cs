using System.Collections.Generic;

namespace Destiny.Net.Core.Model.Responses
{
    public class GroupMembersResponse : DestinyResponse
    {
        public List<MemberResult> results { get; set; }
        public string totalResults { get; set; }
        public bool hasMore { get; set; }
        public GroupMembersQuery query { get; set; }
        public bool useTotalResults { get; set; }
    }

    public class GroupMembersQuery
    {
        public string groupId { get; set; }
        public int memberType { get; set; }
        public int platformType { get; set; }
        public int sort { get; set; }
        public string nameSearch { get; set; }
        public int itemsPerPage { get; set; }
        public int currentPage { get; set; }
    }

    public class MemberResult
    {
        public DestinyUser user { get; set; }
        public bool hasPendingApplication { get; set; }
        public bool hasRated { get; set; }
        public string approvalDate { get; set; }
        public string approvedByMembershipId { get; set; }
        public int rating { get; set; }
        public string groupId { get; set; }
        public int membershipType { get; set; }
        public string membershipId { get; set; }
        public bool isMember { get; set; }
        public int memberType { get; set; }
        public bool isOriginalFounder { get; set; }
    }

    public class IgnoreStatus
    {
        public bool isIgnored { get; set; }
        public int ignoreFlags { get; set; }
    }

    public class Context
    {
        public bool isFollowing { get; set; }
        public IgnoreStatus ignoreStatus { get; set; }
    }

    public class DestinyUser
    {
        public string membershipId { get; set; }
        public string uniqueName { get; set; }
        public string displayName { get; set; }
        public int profilePicture { get; set; }
        public int profileTheme { get; set; }
        public int userTitle { get; set; }
        public string successMessageFlags { get; set; }
        public bool isDeleted { get; set; }
        public string about { get; set; }
        public string firstAccess { get; set; }
        public string lastUpdate { get; set; }
        public Context context { get; set; }
        public string psnDisplayName { get; set; }
        public string xboxDisplayName { get; set; }
        public bool showActivity { get; set; }
        public int followerCount { get; set; }
        public int followingUserCount { get; set; }
        public string locale { get; set; }
        public bool localeInheritDefault { get; set; }
        public bool showGroupMessaging { get; set; }
        public string profilePicturePath { get; set; }
        public string profileThemeName { get; set; }
        public string userTitleDisplay { get; set; }
    }

    public class GroupSearchResponse : DestinyResponse
    {
        public List<Founder> founders { get; set; }
        public List<GroupSearchResult> results { get; set; }
        public string totalResults { get; set; }
        public bool hasMore { get; set; }
        public GroupSearchQuery query { get; set; }
        public bool useTotalResults { get; set; }
    }

    public class Founder
    {
        public string membershipId { get; set; }
        public string uniqueName { get; set; }
        public string displayName { get; set; }
        public int profilePicture { get; set; }
        public int profileTheme { get; set; }
        public int userTitle { get; set; }
        public string successMessageFlags { get; set; }
        public bool isDeleted { get; set; }
        public string about { get; set; }
        public string firstAccess { get; set; }
        public string lastUpdate { get; set; }
        public string psnDisplayName { get; set; }
        public bool showActivity { get; set; }
        public int followerCount { get; set; }
        public int followingUserCount { get; set; }
        public string locale { get; set; }
        public bool localeInheritDefault { get; set; }
        public bool showGroupMessaging { get; set; }
        public string profilePicturePath { get; set; }
        public string profileThemeName { get; set; }
        public string userTitleDisplay { get; set; }
        public string statusText { get; set; }
        public string statusDate { get; set; }
    }

    public class GroupDetail
    {
        public string groupId { get; set; }
        public string name { get; set; }
        public string membershipIdCreated { get; set; }
        public string creationDate { get; set; }
        public string modificationDate { get; set; }
        public int groupType { get; set; }
        public string about { get; set; }
        public bool isDeleted { get; set; }
        public List<string> tags { get; set; }
        public int rating { get; set; }
        public int ratingCount { get; set; }
        public int memberCount { get; set; }
        public int pendingMemberCount { get; set; }
        public bool isPublic { get; set; }
        public bool isMembershipClosed { get; set; }
        public bool isMembershipReviewed { get; set; }
        public bool isPublicTopicAdminOnly { get; set; }
        public string primaryAlliedGroupId { get; set; }
        public string motto { get; set; }
        public string clanCallsign { get; set; }
        public bool allowChat { get; set; }
        public bool isDefaultPostPublic { get; set; }
        public bool isDefaultPostAlliance { get; set; }
        public int chatSecurity { get; set; }
        public string locale { get; set; }
        public int avatarImageIndex { get; set; }
        public string founderMembershipId { get; set; }
        public int homepage { get; set; }
        public int membershipOption { get; set; }
        public int defaultPublicity { get; set; }
        public string theme { get; set; }
        public string bannerPath { get; set; }
        public string avatarPath { get; set; }
        public bool isAllianceOwner { get; set; }
        public string conversationId { get; set; }
        public int clanReviewType { get; set; }
        public bool enableInvitationMessagingForAdmins { get; set; }
    }

    public class CurrentUserStatus
    {
        public bool isFollowing { get; set; }
    }

    public class Attribute
    {
        public int attributeId { get; set; }
        public int minValue { get; set; }
        public int maxValue { get; set; }
    }

    public class ClanMembershipType
    {
        public int membershipType { get; set; }
        public int memberCount { get; set; }
        public bool isProbation { get; set; }
        public bool isWorld { get; set; }
        public bool needsFounder { get; set; }
    }

    public class GroupSearchResult
    {
        public GroupDetail detail { get; set; }
        public string founderMembershipId { get; set; }
        public Founder founder { get; set; }
        public int followerCount { get; set; }
        public CurrentUserStatus currentUserStatus { get; set; }
        public List<object> alliedIds { get; set; }
        public List<Attribute> attributes { get; set; }
        public List<object> membershipIds { get; set; }
        public List<ClanMembershipType> clanMembershipTypes { get; set; }
        public int allianceStatus { get; set; }
        public List<object> friends { get; set; }
        public int groupJoinRequestCount { get; set; }
        public int groupJoinInviteCount { get; set; }
        public int clanJoinRequestCount { get; set; }
        public int clanJoinInviteCount { get; set; }
    }
}