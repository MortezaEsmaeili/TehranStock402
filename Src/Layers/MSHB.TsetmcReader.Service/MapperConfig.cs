using AutoMapper;

namespace MSHB.TsetmcReader.Service
{
    public static class MapperConfig
    {
        private static Mapper instance;
        public static Mapper Instance { 
            get
            {
                instance= instance ?? InitializeAutomapper();
                return instance;
            } 
        }
        public static Mapper InitializeAutomapper()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {

                //Any Other Mapping Configuration ....
            });

            //Create an Instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }

}
