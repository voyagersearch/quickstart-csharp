using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Diagnostics;

using voyager.util;
using voyager.worker;

namespace VoyagerExtractorQuickstart
{
    public class VoyagerSampleExtractor : BaseVoyagerExtractor
    {
        public override void process(VgExtractionJob job)
        {
            FileInfo info = getValidFile(job);
            VgEntry entry = job.getValidEntry();
            entry.setField(VgDexField.ACCESS_TIME, info.LastAccessTimeUtc);
            entry.setField(VgDexField.CREATED, info.CreationTimeUtc);
            entry.setField(VgDexField.BYTES, info.Length.ToString());
        }

        public override String Name
        {
            get
            {
                return "basic";
            }
        }

        public override VgExtractorInfo Info
        {
            get
            {
                VgExtractorInfo info = new VgExtractorInfo();
                info.name = this.Name;
                info.description = "Read Basic Properties From a File";

                Assembly assembly = Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                info.version = fvi.FileVersion;
                return info;
            }
        }
    }
}
