using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.TeamFoundation.Build.Client;
using Microsoft.TeamFoundation.Client;

namespace whatsbuilding.Models {
    public class TfsControllerRepository : IControllerRepository{
        public List<BuildController> GetBuildControllers(string tfsTeamProjectCollectionUrl) {
            var buildServer=TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(tfsTeamProjectCollectionUrl)).GetService<IBuildServer>();
            var qbResults=buildServer.QueryQueuedBuilds(buildServer.CreateBuildQueueSpec("*", "*"));
            var buildControllers=buildServer.
                                 QueryBuildControllers().
                                 Select(bc => new BuildController {
                                     Name=bc.Name,
                                     Status=bc.StatusMessage,
                                     Builds=qbResults.QueuedBuilds.
                                         Select(qb => new Build {
                                             Priority=qb.Priority.ToString(),
                                             QueuedAt=qb.QueueTime,
                                             RequestedBy=qb.RequestedBy,
                                             Status=qb.Status.ToString(),
                                             TeamProject=qb.TeamProject,
                                             BuildDefinition=(qb.BuildDefinition==null?"N/A":qb.BuildDefinition.Name),
                                             Position=(qb.QueuePosition)
                                         }).ToList()
                                 }).ToList();
            return buildControllers;
        }
    }
}