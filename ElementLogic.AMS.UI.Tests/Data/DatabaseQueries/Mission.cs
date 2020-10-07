using System;
using Dapper;
using ElementLogic.AMS.UI.Tests.Data.Manager;

namespace ElementLogic.AMS.UI.Tests.Data.DatabaseQueries
{
    public class Mission
    {
        public static Mission Instance => Singleton.Value;

        public string GetMissionStatusFromTaskgroupId(string taskgroupId)
        {
            const string mainSql = @"SELECT MISSIONSTATUS 
                                       FROM MISSION 
                                      WHERE MMPICKLISTID = @taskgroupId";

            var missionStatus = ConnectionManager.Instance.ExecuteReturn(connection =>
                connection.QueryFirstOrDefault<string>(mainSql,
                    new { taskgroupId }));
            return missionStatus;
        }

        public string GetTaskGroupIdFromPicklistId(string picklistId)
        {
            const string mainSql = @"SELECT TOP 1 MMPICKLISTID 
                                       FROM MISSION 
                                      WHERE PICKLISTID = @picklistId";

            var taskGroupId = ConnectionManager.Instance.ExecuteReturn(connection =>
                connection.QueryFirstOrDefault<string>(mainSql,
                    new { picklistId }));
            return taskGroupId;
        }

        public string GetActivityIdFromProductId(string extProductId)
        {
            const string mainSql = @"SELECT TOP 1 TG.ID_ACTIVITY 
                                       FROM MISSION M
                                       JOIN TASKGROUP TG
                                         ON TG.ID = M.MMPICKLISTID
                                      WHERE EXTPRODUCTID = @extProductId";

            var activityId = ConnectionManager.Instance.ExecuteReturn(connection =>
                connection.QueryFirstOrDefault<string>(mainSql,
                    new { extProductId }));
            return activityId;
        }

        private Mission() { }

        private static readonly Lazy<Mission> Singleton = new Lazy<Mission>(() => new Mission());
    }
}
