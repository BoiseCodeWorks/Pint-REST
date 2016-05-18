using System.Collections.Generic;
using Newtonsoft.Json;

namespace Pintrest.Web.Models
{

    public class Board
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TestMissing { get; set; }

        [JsonExtensionDataAttribute]
        public IDictionary<string, object> _Json { get; set; }

        [JsonIgnore]
        public string Json
        {
            get { return JsonConvert.SerializeObject(_Json); }
            set
            {
                if (string.IsNullOrEmpty(value)) return;

                var metaData = JsonConvert.DeserializeObject<IDictionary<string, object>>(value);

                _Json = metaData ?? new Dictionary<string, object>();
            }
        }
    }
}