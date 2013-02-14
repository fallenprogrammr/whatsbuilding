using System.Collections.Generic;

namespace whatsbuilding.Models {
    public interface IControllerRepository {
        List<BuildController> GetBuildControllers(string tfsProjectCollectionUrl);
    }
}