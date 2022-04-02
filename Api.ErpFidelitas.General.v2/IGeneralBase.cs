using Api.ErpFidelitas.General.v2.Utilities;
 

namespace Api.ErpFidelitas.General.v2
{
	public interface IGeneralBase<T>
	{
		Request Insert(T insertar);
		Request GetAll();
		Request GetById(object id);
		Request GetByCondition();
		Request UpdateById(T actualizar);
		Request Delete(object id);
		Request Validations(T verificar);

	}
}
