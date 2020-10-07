using System;

namespace Eequiis.Dotnet.Resultado
{
	/// <summary>
	/// <para>Representa el resultado de una operación que no devuelve ningún valor, y que solo indica si dicha
	/// operación se completó exitosamente, o si por el contrario fracasó.</para>
	/// <para>Para representar u resultado de éxito o fracaso, hay que instanciar las clases <see cref="Exito"/> y
	/// <see cref="Fracaso"/>, que heredan de esta. Sin embargo, del lado cliente, ambos tipos de resultado se pueden
	/// almacenar en variables de tipo <c>Resultado</c>, que provee métodos para comprobar el éxito o fracaso de la
	/// operación, lo que permitiría hacer <i>castings</i> con garantía de éxito.</para>
	/// <para>Las operaciones que devuelven valores booleanos que solo indican el éxito o fracaso de las mismas también
	/// deberían utilizar esta clase como tipo de retorno. Sin embargo, en caso de que una operación devuelva un valor
	/// booleano que no indica el éxito o fracaso de la misma, se recomienda el uso de la clase
	/// <see cref="Resultado{T}"/> genérica, instanciándola como <c>Resultado&lt;bool&gt;</c>.
	/// </para>
	/// </summary>
	public abstract class Resultado : TResultado
	{
		/// <summary>
		/// <para>Obtiene una vista exitosa de este resultado.</para>
		/// <para>Si este resultado no es una instancia de <see cref="Exito"/>, el método devolverá <c>null</c>.</para>
		/// </summary>
		/// <returns>Una vista exitosa de este resultado, o <c>null</c>.</returns>
		public virtual Exito AsExito() => null;

		/// <summary>
		/// <para>Obtiene una vista de fracaso de este resultado.</para>
		/// <para>Si este resultado no es una instancia de <see cref="Fracaso"/>, el método devolverá <c>null</c>.
		/// </para>
		/// </summary>
		/// <returns>Una vista de fracaso de este resultado, o <c>null</c>.</returns>
		public virtual Fracaso AsFracaso() => null;

		/// <summary>
		/// <para>Obtiene un resultado, instancia de <see cref="Exito"/> o de <see cref="Fracaso"/>, en base a un valor
		/// o expresión booleanos y un mensaje de error.</para>
		/// <para>Si el valor booleano es <c>true</c>, se devolverá un resultado exitoso, mientras que si es
		/// <c>false</c>, se devolverá un resultado de fracaso, acompañado por el mensaje indicado. Y si el mensaje de
		/// error indicado no es significativo (nulo, vacío o blanco), se sustituirá por un mensaje genérico, como se
		/// indica en <see cref="Fracaso(string)"/>.</para>
		/// </summary>
		/// <param name="exito">Indica si el resultado a obtener es exitoso.</param>
		/// <param name="mensaje">Mensaje asociado en caso de que el resultado a construir sea de fracaso.</param>
		/// <returns>Un resultado de éxito o fracaso en función del valor booleano indicado.</returns>
		public static Resultado Get(bool exito, string mensaje)
		{
			if (exito) return new Exito();
			else return new Fracaso(mensaje);
		}
	}

	/// <summary>
	/// <para>Representa el resultado de una operación que devuelve un valor del tipo parametrizado indicado.</para>
	/// <para>En caso de que la operación devuelva un valor booleano que solo indica el éxito o fracaso de la misma, o
	/// que no devuelva ningún valor (<c>void</c>), se recomienda el uso de la clase <see cref="Resultado"/> no
	/// genérica.</para>
	/// </summary>
	/// <typeparam name="T">Tipo del valor devuelto por la operación.</typeparam>
	public abstract class Resultado<T> : TResultado
	{
		/// <summary>
		/// <para>Obtiene una vista exitosa de este resultado.</para>
		/// <para>Si este resultado no es una instancia de <see cref="Exito{T}"/>, el método devolverá <c>null</c>.
		/// </para>
		/// </summary>
		/// <returns>Una vista exitosa de este resultado, o <c>null</c>.</returns>
		public virtual Exito<T> AsExito() => null;

		/// <summary>
		/// <para>Obtiene una vista de fracaso de este resultado.</para>
		/// <para>Si este resultado no es una instancia de <see cref="Fracaso{T}"/>, el método devolverá <c>null</c>.
		/// </para>
		/// </summary>
		/// <returns>Una vista de fracaso del resultado, o <c>null</c>.</returns>
		public virtual Fracaso<T> AsFracaso() => null;

		/// <summary>
		/// <para>Obtiene un resultado, instancia de <see cref="Exito{T}"/> o de <see cref="Fracaso{T}"/>, en base a
		/// un valor de un tipo parametrizado, una condición parametrizada y un mensaje de error.</para>
		/// <para>Si la condición parametrizada es cierta, se devolverá un resultado parametrizado exitoso conteniendo
		/// el valor de tipo parametrizado indicado, mientras que si es falsa se devolverá un resultado parametrizado
		/// de fracaso, acompañado por el mensaje de error indicado. Y si el mensaje de error indicado no es
		/// significativo (nulo, vacío o blanco), se sustituirá por un mensaje genérico, como se indica en
		/// <see cref="Fracaso{T}.Fracaso(string)"/>.</para>
		/// </summary>
		/// <param name="valor">Valor devuleto por una operación en el resultado construido, en caso de éxito.</param>
		/// <param name="exito">Condición de tipo parametrizado que indica en qué caso el resultado es exitoso.</param>
		/// <param name="mensaje">Mensaje asociado en caso de que el resultado obtenido sea de fracaso.</param>
		/// <returns>Un resultado parametrizado, de éxito o fracaso, en función de la condición indicada.</returns>
		public static Resultado<T> Get(T valor, Predicate<T> exito, string mensaje)
		{
			if (exito == null) return new Fracaso<T>(mensaje);
			if (exito(valor)) return new Exito<T>(valor);
			else return new Fracaso<T>(mensaje);
		}
	}
}
