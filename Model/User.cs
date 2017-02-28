using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public  class User
    {
        [Key]
        public string id { get; set; }
        public bool isFollowed { get; set; }
        public int followingCount { get; set; }
        public int markedAnswersCount { get; set; }
        public string userType { get; set; }
        public bool showSinaWeibo { get; set; }
        public int pinsCount { get; set; }
        public bool isFollowing { get; set; }
        public string markedAnswersText { get;set; }
        public int favoriteCount { get;set;}
        public int logsCount { get; set; }
        public int voteupCount { get; set; }
        public bool isBlocking { get; set; }
        public int followingColumnsCount { get;set;}
        public bool isForceRenamed { get; set; }
        public int thankToCount { get;set;}
        public string headline { get;set;}
        public int participatedLiveCount { get;set;}
        public bool isBindSina { get;set;}
        public bool isAdvertiser { get; set; }
        public int followingFavlistsCount { get; set; }
        public int favoritedCount { get;set;}
        public bool allowMessage { get;set;}
        public bool isOrg { get; set; }
        public bool isBlocked { get; set; }
        public int followerCount { get; set; }
        public int mutualFolloweesCount { get; set; }
        public string type { get;set;}
        public string avatarUrlTemplate { get; set; }
        public int followingTopicCount { get; set; }
        public string description { get; set; }
        public string voteFromCount { get; set; }
        public string sinaWeiboUrl { get; set; }
        public int isActive { get; set; }
        public string coverUrl { get; set; }
        public int answerCount { get; set; }
        public int thankFromCount { get;set;}
        public int voteToCount { get; set; }
        public string urlToken { get;set;}
        public int questionCount { get; set; }
        public int articlesCount { get; set; }
        public string name { get; set; }
        public string url { get;set;}
        public int gender { get; set; }
        public string sinaWeiboName { get; set; }
        public string messageThreadToken { get; set; }
        public string avatarUrl { get;set;}
        public int followingQuestionCount { get; set; }
        public int thankedCount { get; set; }
        public int hostedLiveCount { get; set; }
        public virtual business business { get; set; }
        public virtual ICollection<employments> employments { get; set; }
        public virtual ICollection<educations> educations { get; set; }
        public virtual ICollection<locations> locations { get; set; }
    }
}
