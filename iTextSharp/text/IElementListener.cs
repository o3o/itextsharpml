namespace iTextSharp.text {
   /**
      A class that implements ElementListener will perform some
      actions when an Element is added.
   */
   public interface IElementListener {
      /**
         Signals that an Element was added to the Document.
         @param "element Element added
         @return  true if the element was added, false if not.
      */
      bool Add(IElement element);
   }
}
