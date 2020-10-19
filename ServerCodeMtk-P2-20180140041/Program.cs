using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ServiceMtk_P2_20180140041;
using System.ServiceModel.Description;
using System.ServiceModel.Channels; //mex

namespace ServerCodeMtk_P2_20180140041
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost hostObj = null;
            Uri address = new Uri("http://localhost:8888/Matematika");
            BasicHttpBinding bind = new BasicHttpBinding();
            try
            {
                hostObj = new ServiceHost(typeof(Matematika), address);
                //ALAMAT BASE ADDRESS
                hostObj.AddServiceEndpoint(typeof(iMatematika), bind, "");
                // IMatematika harus sesuai dengan yang dibuat pertama
                // setelah di edit IMatematika, masuk ke dalam code ini harus memakai iMatematika
                // karena yang pertama dibuat iMatematika lalu di edit menjadi IMatematika
                
                //ALAMAT ENDPOINT
                //wsdl
                ServiceMetadataBehavior smb = new
               ServiceMetadataBehavior(); //Service Runtime Player
                smb.HttpGetEnabled = true; //untuk mengaktifkan wsdl (dibuka saat development, tidak untuk dibuka)
                hostObj.Description.Behaviors.Add(smb);
                //mex
                Binding mexbind =
               MetadataExchangeBindings.CreateMexHttpBinding();
                hostObj.AddServiceEndpoint(typeof(IMetadataExchange),
               mexbind, "mex");
                hostObj.Open();
                Console.WriteLine("Server is ready!!!!");
                Console.ReadLine();
                hostObj.Close();
            }
            catch (Exception ex)
            {
                hostObj = null;
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

        }
    }

    
}
