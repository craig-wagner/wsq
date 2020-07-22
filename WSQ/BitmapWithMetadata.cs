using System;
using System.Collections.Generic;
using System.Linq;

namespace Wsqm
{
    internal class BitmapWithMetadata : BitmapWrapper
    {
        public List<string> Comments { get; }

        public Dictionary<string, string> Metadata { get; }

        public BitmapWithMetadata(byte[] pixels, int width, int height, int ppi, int depth, int lossyflag)
            : this(pixels, width, height, ppi, depth, lossyflag, null)
        { }

        public BitmapWithMetadata(byte[] pixels, int width, int height, int ppi, int depth, int lossyflag,
            Dictionary<string, string> metadata, string[] comments = null)
            : base(pixels, width, height, ppi, depth, lossyflag)
        {
            Metadata = metadata ?? new Dictionary<string, string>();
            Comments = comments == null
                ? new List<string>()
                : comments.Where(c => !String.IsNullOrEmpty(c)).ToList();
        }
    }
}