using AutoMapper;

namespace Common.Utils.AutoMapper
{
    public partial class SettingAutomapper
    {
        public static void CreateMaps()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMissingTypeMaps = true;
                cfg.ValidateInlineMaps = false;
            });           
        }
    }
}
