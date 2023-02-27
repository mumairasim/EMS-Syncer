namespace Syncer.Service.Configurations
{
    public class QuartzConfiguration
    {
        public string SyncClassesJobTimeInterval { get; set; }
        public string SyncCoursesJobTimeInterval { get; set; }
        public string SyncStudentsJobTimeInterval { get; set; }
        public string SyncLessonPlanJobTimeInterval { get; set; }
    }
}
