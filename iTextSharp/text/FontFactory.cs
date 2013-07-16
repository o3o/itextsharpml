using System;
using System.IO;
using System.Collections;
using System.util;
using System.Globalization;

using iTextSharp.text.html;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace iTextSharp.text {
   /**
      If you are using True Type fonts, you can declare the paths of the
      different ttf- and ttc-files to this static class first and then
      create fonts in your code using one of the static getFont-method
      without having to enter a path as parameter.
   */
   public sealed class FontFactory {
      /** This is a possible value of a base 14 type 1 font */
      public const string COURIER = BaseFont.COURIER;
    
      /** This is a possible value of a base 14 type 1 font */
      public const string COURIER_BOLD = BaseFont.COURIER_BOLD;
       
      /** This is a possible value of a base 14 type 1 font */
      public const string COURIER_OBLIQUE = BaseFont.COURIER_OBLIQUE;
    
      /** This is a possible value of a base 14 type 1 font */
      public const string COURIER_BOLDOBLIQUE = BaseFont.COURIER_BOLDOBLIQUE;
    
      /** This is a possible value of a base 14 type 1 font */
      public const string HELVETICA = BaseFont.HELVETICA;
    
      /** This is a possible value of a base 14 type 1 font */
      public const string HELVETICA_BOLD = BaseFont.HELVETICA_BOLD;
    
      /** This is a possible value of a base 14 type 1 font */
      public const string HELVETICA_OBLIQUE = BaseFont.HELVETICA_OBLIQUE;
    
      /** This is a possible value of a base 14 type 1 font */
      public const string HELVETICA_BOLDOBLIQUE = BaseFont.HELVETICA_BOLDOBLIQUE;
    
      /** This is a possible value of a base 14 type 1 font */
      public const string SYMBOL = BaseFont.SYMBOL;
    
      /** This is a possible value of a base 14 type 1 font */
      public const string TIMES = "Times";
    
      /** This is a possible value of a base 14 type 1 font */
      public const string TIMES_ROMAN = BaseFont.TIMES_ROMAN;
    
      /** This is a possible value of a base 14 type 1 font */
      public const string TIMES_BOLD = BaseFont.TIMES_BOLD;
    
      /** This is a possible value of a base 14 type 1 font */
      public const string TIMES_ITALIC = BaseFont.TIMES_ITALIC;
    
      /** This is a possible value of a base 14 type 1 font */
      public const string TIMES_BOLDITALIC = BaseFont.TIMES_BOLDITALIC;
    
      /** This is a possible value of a base 14 type 1 font */
      public const string ZAPFDINGBATS = BaseFont.ZAPFDINGBATS;
        
      private static FontFactoryImp fontImp = new FontFactoryImp();

      private static string defaultEncoding = BaseFont.WINANSI;
    
      private static bool defaultEmbedding = BaseFont.NOT_EMBEDDED;
    
      private FontFactory() { }
    
      /**
         Constructs a Font-object. 

         @parm fontname the name of the font>
         @parm encoding the encoding of the font
         @parm embedded true if the font is to be embedded in the PDF
         @parm size the size of this font
         @parm style the style of this font
         @parm color the Color of this font
      */
      public static Font GetFont(string fontname, string encoding, bool embedded, float size, int style, Color color) {
         return fontImp.GetFont(fontname, encoding, embedded, size, style, color);
      }
    
      /**
         Constructs a Font-object.

         @parm fontname the name of the font
         @parm encoding the encoding of the font
         @parm embedded true if the font is to be embedded in the PDF
         @parm size the size of this font
         @parm style the style of this font
         @parm color the Color of this font
         @parm cached true if the font comes from the cache or is added to the cache if new, false if the font is always created new
      */
      public static Font GetFont(string fontname, string encoding, bool embedded, float size, int style, Color color, bool cached) {
         return fontImp.GetFont(fontname, encoding, embedded, size, style, color, cached);
      }
      
      /**
         Constructs a Font-object.
         
         @parm attributes the attributes of a Font object
      */
      public static Font GetFont(Properties attributes) {
         fontImp.DefaultEmbedding = defaultEmbedding;
         fontImp.DefaultEncoding = defaultEncoding;
         return fontImp.GetFont(attributes);
      }
    
      /**
         Constructs a Font-object.

         @parm fontname the name of the font
         @parm encoding the encoding of the font
         @parm embedded true if the font is to be embedded in the PDF
         @parm size the size of this font
         @parm style the style of this font
      */
      public static Font GetFont(string fontname, string encoding, bool embedded, float size, int style) {
         return GetFont(fontname, encoding, embedded, size, style, null);
      }
    
      /**
         Constructs a Font-object.

         @parm fontname the name of the font
         @parm encoding the encoding of the font
         @parm embedded true if the font is to be embedded in the PDF
         @parm size the size of this font
      */
      public static Font GetFont(string fontname, string encoding, bool embedded, float size) {
         return GetFont(fontname, encoding, embedded, size, Font.UNDEFINED, null);
      }
    
      /**
         Constructs a Font-object.
      
         @parm fontname the name of the font
         @parm encoding the encoding of the font
         @parm embedded true if the font is to be embedded in the PDF
      */
      public static Font GetFont(string fontname, string encoding, bool embedded) {
         return GetFont(fontname, encoding, embedded, Font.UNDEFINED, Font.UNDEFINED, null);
      }
    
      /**
         Constructs a Font-object.
       
         @parm fontname the name of the font
         @parm encoding the encoding of the font
         @parm size the size of this font
         @parm style the style of this font
         @parm color the Color of this font
      */
      public static Font GetFont(string fontname, string encoding, float size, int style, Color color) {
         return GetFont(fontname, encoding, defaultEmbedding, size, style, color);
      }
    
      /**
         Constructs a Font-object.
       
         @parm fontname the name of the font
         @parm encoding the encoding of the font
         @parm size the size of this font
         @parm style the style of this font
      */
      public static Font GetFont(string fontname, string encoding, float size, int style) {
         return GetFont(fontname, encoding, defaultEmbedding, size, style, null);
      }
    
      /**
         Constructs a Font-object.
       
         @parm fontname the name of the font
         @parm encoding the encoding of the font
         @parm size the size of this font
      */
      public static Font GetFont(string fontname, string encoding, float size) {
         return GetFont(fontname, encoding, defaultEmbedding, size, Font.UNDEFINED, null);
      }
    
      /**
         Constructs a Font-object.
       
         @parm fontname the name of the font
         @parm encoding the encoding of the font
      */
      public static Font GetFont(string fontname, string encoding) {
         return GetFont(fontname, encoding, defaultEmbedding, Font.UNDEFINED, Font.UNDEFINED, null);
      }
    
      /**
         Constructs a Font-object.
       
         @parm fontname the name of the font
         @parm size the size of this font
         @parm style the style of this font
         @parm color the Color of this font
      */
      public static Font GetFont(string fontname, float size, int style, Color color) {
         return GetFont(fontname, defaultEncoding, defaultEmbedding, size, style, color);
      }
    
      /**
         Constructs a Font-object.
       
         @parm fontname the name of the font
         @parm size the size of this font
         @parm color the Color of this font
      */
      public static Font GetFont(string fontname, float size, Color color) {
         return GetFont(fontname, defaultEncoding, defaultEmbedding, size, Font.UNDEFINED, color);
      }
        
      /**
         Constructs a Font-object.
       
         @parm fontname the name of the font
         @parm size the size of this font
         @parm style the style of this font
      */
      public static Font GetFont(string fontname, float size, int style) {
         return GetFont(fontname, defaultEncoding, defaultEmbedding, size, style, null);
      }
    
      /**
         Constructs a Font-object.
       
         @parm fontname the name of the font
         @parm size the size of this font
      */
      public static Font GetFont(string fontname, float size) {
         return GetFont(fontname, defaultEncoding, defaultEmbedding, size, Font.UNDEFINED, null);
      }
    
      /**
         Constructs a Font-object.
       
         @parm fontname the name of the font
      */
      public static Font GetFont(string fontname) {
         return GetFont(fontname, defaultEncoding, defaultEmbedding, Font.UNDEFINED, Font.UNDEFINED, null);
      }

      /**
       * Register a font by giving explicitly the font family and name.
       * @param familyName the font family
       * @param fullName the font name
       * @param path the font path
       */
      public void RegisterFamily(String familyName, String fullName, String path) {
         fontImp.RegisterFamily(familyName, fullName, path);
      }
        
      public static void Register(Properties attributes) {
         string path;
         string alias = null;

         path = attributes.Remove("path");
         alias = attributes.Remove("alias");

         fontImp.Register(path, alias);
      }
    
      /**
         Register a ttf- or a ttc-file.
      
         @parm path the path to a ttf- or ttc-file
      */
      public static void Register(string path) {
         Register(path, null);
      }
    
      /**
         Register a ttf- or a ttc-file and use an alias for the font contained in the ttf-file.

      @parm path the path to a ttf- or ttc-file
      @parm alias the alias you want to use for the font
      */
      public static void Register(string path, string alias) {
         fontImp.Register(path, alias);
      }
    
      /** 
          Register all the fonts in a directory.
          @param dir the directory
         @return the number of fonts registered
      */    
      public static int RegisterDirectory(String dir) {
         return fontImp.RegisterDirectory(dir);
      }

      /**
       Register all the fonts in a directory and possibly its subdirectories.
       @param dir the directory
       @param scanSubdirectories recursively scan subdirectories if <code>true</true>
       @return the number of fonts registered
       @since 2.1.2
      */
      public static int RegisterDirectory(String dir, bool scanSubdirectories) {
         return fontImp.RegisterDirectory(dir, scanSubdirectories);
      }
            
      /** Register fonts in some probable directories. It usually works in Windows,
       Linux and Solaris.
       @return the number of fonts registered
      */    
      public static int RegisterDirectories() {
         return fontImp.RegisterDirectories();
      }

      /**
         Gets a set of registered fontnames.
      */
      public static ICollection RegisteredFonts {
         get {
            return fontImp.RegisteredFonts;
         }
      }
    
      /**
         Gets a set of registered font families.
      */
      public static ICollection RegisteredFamilies {
         get {
            return fontImp.RegisteredFamilies;
         }
      }
    
      /**
         Checks whether the given font is contained within the object

         @parm fontname the name of the font
      */
      public static bool Contains(string fontname) {
         return fontImp.IsRegistered(fontname);
      }
    
      /**
         Checks if a certain font is registered.
         @parm fontname the name of the font that has to be checked
      */
      public static bool IsRegistered(string fontname) {
         return fontImp.IsRegistered(fontname);
      }

      public static string DefaultEncoding {
         get {
            return defaultEncoding;
         }
      }

      public static bool DefaultEmbedding {
         get {
            return defaultEmbedding;
         }
      }


      public static FontFactoryImp FontImp {
         get {
            return fontImp;
         }
         set {
            Requires.IsNotNull(value, "value");
            fontImp = value;
         }
      }
   }
}