using System;

/*
 *
 * Copyright (c) 1999, 2000, 2001, 2002 Bruno Lowagie.
 *
 * The contents of this file are subject to the Mozilla License Version 1.1
 * (the "License"); you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at http://www.mozilla.org/MPL/
 *
 * Software distributed under the License is distributed on an "AS IS" basis,
 * WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License
 * for the specific language governing rights and limitations under the License.
 *
 * The Original Code is 'iText, a free JAVA-PDF library'.
 *
 * The Initial Developer of the Original Code is Bruno Lowagie. Portions created by
 * the Initial Developer are Copyright (C) 1999, 2000, 2001, 2002 by Bruno Lowagie.
 * All Rights Reserved.
 * Co-Developer of the code is Paulo Soares. Portions created by the Co-Developer
 * are Copyright (C) 2000, 2001, 2002 by Paulo Soares. All Rights Reserved.
 *
 * Contributor(s): all the names of the contributors are added in the source code
 * where applicable.
 *
 * Alternatively, the contents of this file may be used under the terms of the
 * LGPL license (the "GNU LIBRARY GENERAL LICENSE"), in which case the
 * provisions of LGPL are applicable instead of those above.  If you wish to
 * allow use of your version of this file only under the terms of the LGPL
 * License and not to allow others to use your version of this file under
 * the MPL, indicate your decision by deleting the provisions above and
 * replace them with the notice and other provisions required by the LGPL.
 * If you do not delete the provisions above, a recipient may use your version
 * of this file under either the MPL or the GNU LIBRARY GENERAL LICENSE.
 *
 * This library is free software; you can redistribute it and/or modify it
 * under the terms of the MPL as stated above or under the terms of the GNU
 * Library General License as published by the Free Software Foundation;
 * either version 2 of the License, or any later version.
 *
 * This library is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU Library general License for more
 * details.
 *
 * If you didn't download this code from the following link, you should check if
 * you aren't using an obsolete version:
 * http://www.lowagie.com/iText/
 */
namespace iTextSharp.text {
   /*
      A class that implements DocListener will perform some
      actions when some actions are performed on a Document.
   */
   public interface IDocListener: IElementListener {
      /*
         Signals that the Document has been opened and that
         Elements can be added.
      */
      void Open();

      /*
         Signals that the Document was closed and that no other
         Elements will be added.
         The output stream of every writer implementing IDocListener will be closed.
      */
      void Close();

      /*
         Signals that an new page has to be started.
         true if the page was added, false if not.
      */
      bool NewPage();

      /*
         Sets the pagesize.
      */
      bool SetPageSize(Rectangle pageSize);

      /*
         Sets the margins.
      */
      bool SetMargins(float marginLeft, float marginRight, float marginTop, float marginBottom);

      /**
       * Parameter that allows you to do margin mirroring (odd/even pages)
       * @param marginMirroring
       * @return true if succesfull
       */
      bool SetMarginMirroring(bool marginMirroring);

      /**
       * Parameter that allows you to do top/bottom margin mirroring (odd/even pages)
       * @param marginMirroringTopBottom
       * @return true if successful
       * @since   2.1.6
       */
      bool SetMarginMirroringTopBottom(bool marginMirroringTopBottom); // [L6]

      /*
         Sets the page number.
      */
      int PageCount {
         set;
      }

      /*
         Sets the page number to 0.
      */
      void ResetPageCount();

      /*
         Changes the header of this document.
      */
      HeaderFooter Header {
         set;
      }

      /*
         Resets the header of this document.
      */
      void ResetHeader();

      /*
         Changes the footer of this document.
      */
      HeaderFooter Footer {
         set;
      }

      /*
         Resets the footer of this document.
      */
      void ResetFooter();
   }
}
