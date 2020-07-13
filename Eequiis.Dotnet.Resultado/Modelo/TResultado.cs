namespace Eequiis.Dotnet.Resultado
{
	/// <summary>
	/// Representa el resultado de una operación cualquiera, que puede ser exitoso o no.
	/// </summary>
	public abstract class TResultado
	{
		/// <summary>
		/// Indica si la operación que devuelve este resultado se ha realizado con éxito, es decir, de manera correcta.
		/// </summary>
		public virtual bool EsCorrecto => false;

		/// <summary>
		/// Indica si la operación que devuelve este resultado ha fracasado, es decir, si ha fallado durante
		/// la ejecución.
		/// </summary>
		public virtual bool EsError => false;
	}
}
