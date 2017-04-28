namespace VideoOnDemand.Models.DTOModels
{
    public class LessonInfoDTO
    {
        public int LessonNumber { get; set; }   // ex: Lesson 1/5
        public int NumberOfLessons { get; set; }
        public int PreviousVideoId { get; set; }
        public int NextVideoId { get; set; }
        public string NextVideoTitle { get; set; }
        public string NextVideoThumbnail { get; set; }
        public string CurrentVideoTitle { get; set; }
        public string CurrentVideoThumbnail { get; set; }
    }
}
