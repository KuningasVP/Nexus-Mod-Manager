﻿using System;
using System.Collections.Generic;
using Nexus.Client.Mods;

namespace Nexus.Client.ModRepositories
{
	/// <summary>
	/// Describes the methods and properties of a mod repository.
	/// </summary>
	/// <remarks>
	/// A mod repository provides access to mods, and mod minformation.
	/// </remarks>
	public interface IModRepository
	{
		#region Properties

		/// <summary>
		/// Gets the id of the mod repository.
		/// </summary>
		/// <value>The id of the mod repository.</value>
		string Id { get; }

		/// <summary>
		/// Gets the name of the mod repository.
		/// </summary>
		/// <value>The name of the mod repository.</value>
		string Name { get; }

		/// <summary>
		/// Gets the user membership status.
		/// </summary>
		/// <value>The user membership status.</value>
		string[] UserStatus { get; }

		/// <summary>
		/// Gets the User Agent used for the mod repository.
		/// </summary>
		/// <value>The User Agent.</value>
		string UserAgent { get; }

		#endregion

		#region Account Management

		/// <summary>
		/// Logs the user into the mod repository.
		/// </summary>
		/// <param name="p_strUsername">The username of the account with which to login.</param>
		/// <param name="p_strPassword">The password of the account with which to login.</param>
		/// <param name="p_dicTokens">The returned tokens that can be used to login instead of the username/password
		/// credentials.</param>
		/// <returns><c>true</c> if the login was successful;
		/// <c>fales</c> otherwise.</returns>
		bool Login(string p_strUsername, string p_strPassword, out Dictionary<string,string> p_dicTokens);

		/// <summary>
		/// Logs the user into the mod repository.
		/// </summary>
		/// <param name="p_dicTokens">The authentication tokens with which to login.</param>
		/// <returns><c>true</c> if the given tokens are valid;
		/// <c>fales</c> otherwise.</returns>
		bool Login(Dictionary<string,string> p_dicTokens);

		/// <summary>
		/// Logs the user out of the mod repository.
		/// </summary>
		void Logout();

		#endregion

		/// <summary>
		/// Gets the mod info for the mod to which the specified download file belongs.
		/// </summary>
		/// <param name="p_strFilename">The name of the file whose mod's info is to be returned..</param>
		/// <returns>The info for the mod to which the specified file belongs.</returns>
		IModInfo GetModInfoForFile(string p_strFilename);

		/// <summary>
		/// Gets the info for the specifed mod.
		/// </summary>
		/// <param name="p_strModId">The id of the mod info is be retrieved.</param>
		/// <returns>The info for the specifed mod.</returns>
		IModInfo GetModInfo(string p_strModId);

		/// <summary>
		/// Gets the list of files for the specified mod.
		/// </summary>
		/// <param name="p_strModId">The id of the mod whose list of files is to be returned.</param>
		/// <returns>The list of files for the specified mod.</returns>
		IList<IModFileInfo> GetModFileInfo(string p_strModId);

		/// <summary>
		/// Gets the URLs of the file parts for the specified download file of the specified mod.
		/// </summary>
		/// <param name="p_strModId">The id of the mod whose download file's parts' URLs are to be retrieved.</param>
		/// <param name="p_strFileId">The id of the download file whose parts' URLs are to be retrieved.</param>
		/// <returns>The URLs of the file parts for the specified download file.</returns>
		Uri[] GetFilePartUrls(string p_strModId, string p_strFileId);

		/// <summary>
		/// Gets the file info for the specified download file of the specified mod.
		/// </summary>
		/// <param name="p_strModId">The id of the mod the whose file's metadata is to be retrieved.</param>
		/// <param name="p_strFileId">The id of the download file whose metadata is to be retrieved.</param>
		/// <returns>The file info for the specified download file of the specified mod.</returns>
		IModFileInfo GetFileInfo(string p_strModId, string p_strFileId);

		/// <summary>
		/// Gets the file info for the specified download file.
		/// </summary>
		/// <param name="p_strFilename">The name of the file whose info is to be returned..</param>
		/// <returns>The file info for the specified download file.</returns>
		IModFileInfo GetFileInfoForFile(string p_strFilename);

		/// <summary>
		/// Gets the file info for the default file of the speficied mod.
		/// </summary>
		/// <param name="p_strModId">The id of the mod the whose default file's metadata is to be retrieved.</param>
		/// <returns>The file info for the default file of the speficied mod.</returns>
		IModFileInfo GetDefaultFileInfo(string p_strModId);

		/// <summary>
		/// Finds the mods containing the given search terms.
		/// </summary>
		/// <param name="p_strModNameSearchString">The terms to use to search for mods.</param>
		/// <param name="p_booIncludeAllTerms">Whether the returned mods' names should include all of
		/// the given search terms.</param>
		/// <returns>The mod info for the mods matching the given search criteria.</returns>
		IList<IModInfo> FindMods(string p_strModNameSearchString, bool p_booIncludeAllTerms);

        /// <summary>
        /// Finds the mods by Author name.
        /// </summary>
        /// <param name="p_strModNameSearchString">The terms to use to search for mods.</param>
        /// <param name="p_strAuthorSearchString">The Author to use to search for mods.</param>
        /// <returns>The mod info for the mods matching the given search criteria.</returns>
        IList<IModInfo> FindMods(string p_strModNameSearchString, string p_strAuthorSearchString);

				/// <summary>
		/// Finds the mods containing the given search terms.
		/// </summary>
		/// <param name="p_strModNameSearchString">The terms to use to search for mods.</param>
		/// <param name="p_strModAuthor">The Mod author.</param>
		/// <param name="p_booIncludeAllTerms">Whether the returned mods' names should include all of
		/// the given search terms.</param>
		/// <returns>The mod info for the mods matching the given search criteria.</returns>
		/// <exception cref="RepositoryUnavailableException">Thrown if the repository cannot be reached.</exception>
		IList<IModInfo> FindMods(string p_strModNameSearchString, string p_strModAuthor, bool p_booIncludeAllTerms);
	}
}
