namespace Destiny.Net.Core.Model
{
    public class GroupSearchQuery
    {
        public GroupSearchQuery()
        {
            Contents = new GroupSearchContents();
        }

        public GroupSearchContents Contents { get; set; }
        public int CreationDate { get; set; }
        public int SortBy { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int MembershipType { get; set; }
        public string TagText { get; set; }
        public string LocaleFilter { get; set; }
        public int GroupMemberCountFilter { get; set; }
    }
}