using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MESModel;

namespace MESServer
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IMESService
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);
        [OperationContract]
        int GetDiff(int a, int b);
        [OperationContract]
        List<Department> GetDepartments();
        [OperationContract]
        List<ProductAvailability> GetDepartmentAvailability(Department department);
        [OperationContract]
        List<Product> GetProducts();
        [OperationContract]
        List<Team> GetTeams();
        [OperationContract]
        int AddProduct(int productId, int departmentId);
        [OperationContract]
        int DeleteProduct(int productAvailabilityId);
        [OperationContract]
        int DeleteProducts(List<int> productIds);
        [OperationContract]
        int TakeProduct(int productAvailabilityId, int teamId);
        [OperationContract]
        int TakeProducts(List<int> productIds, int teamId);
        [OperationContract]
        List<Movement> GetInputMovements(Department department);
        [OperationContract]
        List<Movement> GetOutputMovements(Department department);
        [OperationContract]
        int GiveProduct(List<int> productAvailabilityIds, int teamId, int newProductId);
        [OperationContract]
        string InitDb();
    }


    // Используйте контракт данных, как показано в примере ниже, чтобы добавить составные типы к операциям служб.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
