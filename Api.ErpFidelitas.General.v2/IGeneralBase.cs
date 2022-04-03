using Api.ErpFidelitas.General.v2.Utilities;
 

namespace Api.ErpFidelitas.General.v2
{
	public interface IGeneralBase<T>
	{
		Request Insert(T insertar);
		Request GetAll(int CompanyId=0);
		Request GetById(int CompanyId=0, object id=null);
		Request GetByCondition();
		Request UpdateById(T actualizar);
		Request Delete(int CompanyId=0, object id=null);
		Request Validations(T verificar);
	}
}
