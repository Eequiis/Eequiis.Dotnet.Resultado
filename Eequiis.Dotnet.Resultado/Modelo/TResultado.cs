/*******************************************************************************
 *
 * Copyright (C) 2020, 2021 Eequiis Vásquez
 *
 * This file is part of Eequiis.Dotnet.Resultado.
 *
 * Eequiis.Dotnet.Resultado is free software: you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public License as
 * published by the Free Software Foundation, either version 3 of the License,
 * or (at your option) any later version.
 *
 * Eequiis.Dotnet.Resultado is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser
 * General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with Eequiis.Dotnet.Resultado. If not, see
 * <https://www.gnu.org/licenses/>.
 *
 ******************************************************************************/

using System;

namespace Eequiis.Dotnet.Resultado
{
	/// <summary>
	/// <para>Representa el resultado de una operación cualquiera, que puede ser de éxito o fracaso.</para>
	/// <para>Para comprobar si un resultado ha sido de éxito disponemos de la propiedad de solo lectura
	/// <see cref="EsExito"/>, y también de <see cref="EsCorrecto"/>, siendo la última una propiedad obsoleta,
	/// manetnida por retro compatibilidad, pero su uso se debería evitar.</para>
	/// <para>De igual forma, para comprobar si el resuoltado es de fracaso, tenemos la propiedad de solo lectura
	/// <see cref="EsFracaso"/>, y la obsoleta <see cref="EsError"/>.</para>
	/// <para><i>Nota: las propiedades obsoletas son consistentes con sus análogas actuales. Es decir, la propiedad
	/// <c>EsCorrecto</c> devolverá el mismo valor booleano que <c>EsExito</c>; e igualmente, <c>EsError</c> devolverá
	/// lo mismo que <c>EsFracaso</c>.</i></para>
	/// </summary>
	public abstract class TResultado
	{
		/// <summary>
		/// <para>Indica si la operación que devuelve este resultado se ha realizado con éxito, es decir, de manera
		/// correcta.</para>
		/// </summary>
		[Obsolete("Sustituir por propiedad EsExito", false)]
		public bool EsCorrecto => EsExito;

		/// <summary>
		/// <para>Indica si la operación que devuelve este resultado se ha realizado exitosamente.</para>
		/// </summary>
		public virtual bool EsExito => false;

		/// <summary>
		/// <para>Indica si la operación que devuelve este resultado ha fracasado, es decir, si ha fallado durante
		/// la ejecución.</para>
		/// </summary>
		[Obsolete("Sustituir por propiedad EsFracaso", false)]
		public bool EsError => EsFracaso;

		/// <summary>
		/// <para>Indica si la operación que devuelve este resultado ha fracasado.</para>
		/// </summary>
		public virtual bool EsFracaso => false;
	}
}
