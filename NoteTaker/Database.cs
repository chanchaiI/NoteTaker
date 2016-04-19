using System;
using System.IO;
using SQLite;


#if __IOS__
using Foundation;
#endif

namespace NoteTaker
{
	public class Database
	{
		public Database ()
		{
			CreateDatabase ();
		}

		public static string documentFolder(){
			string path;


			#if __IOS__
			path = NSFileManager.DefaultManager.GetUrls(NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User)[0].Path;
			#endif

			#if __MOBILE__
//			path = Android.App.Application.
			#endif


			Directory.CreateDirectory(path);

			return path;
		}

		public static void CreateDatabase(){
			var conn = new SQLiteConnection (documentFolder (), "database.db");	
			conn.CreateTable<Note> ();
			conn.Close ();
		}

		public static void InsertNote(Note note){
			var conn = new SQLiteConnection (documentFolder (), "database.db");
			conn.Insert (note);
			conn.Close ();
		}

		public static void DeleteNote(Note note){
			var conn = new SQLiteConnection (documentFolder (), "database.db");
			conn.Query<Note> ("DELETE * FROM Note WHERE dateCreated=?", note.dateCreated);
			conn.Close ();
		}

		public static List<Note> GetNotes(){
			var conn = new SQLiteConnection (documentFolder (), "database.db");
			var results = conn.Query<Note> ("SELECT * FROM Note");
			conn.Close ();
			return results;
		}
	}
}

