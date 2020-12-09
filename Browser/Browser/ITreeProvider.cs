using System.Collections.Generic;

namespace Browser
{
    public interface ITreeProvider
    {
        public IList<Namespace> getTree();
    }
}
