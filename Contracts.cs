// see http://lightcxontracts.codeplex.com 
// Apache License 2.0 (Apache)
namespace iTextSharp {
   internal class Requires {
      /**
         Checks a precondition and throws an exception if this precondition is false
         
         @param precondition This precondition should be true, otherwise an exception will be thrown
         @param conditionDescription A textual description of the
         precondition
      */
      internal static void That(bool precondition, string conditionDescription) {
         if (!precondition) {
            throw AssertException.Create("Precondition", conditionDescription);
         }
      }

      /**
         Checks a precondition and throws an exception if this
         precondition is false This method should be used, if a
         description must be dynamically created.  string.Format() will
         only be called, if the precondition fails.
      
         @param precondition This precondition should be true, otherwise an exception will be thrown
         @param descriptionFormat Will be passed to string.Format(), to create a textual description of the precondition
         @param descriptionParameters Will be passed to string.Format(), to create a textual description of the precondition
      */
      internal static void That(bool precondition, string descriptionFormat, params object[] descriptionParameters) {
         if (!precondition) {
            throw AssertException.Create("Precondition", descriptionFormat, descriptionParameters);
         }
      }

     
      internal static void That(System.Func<bool> function) {
         if (!function()) {
            throw AssertException.Create("Precondition", function);
         }
      }

      /**
         Checks if the toBeTested is not null and throws an exception if this precondition is false.
      
         @param toBeTested The object for test.
         @param objectName Name of the object.
      */
      internal static void IsNotNull(object toBeTested, string objectName) {
         if (toBeTested == null) {
            throw AssertException.Create("Precondition", objectName + " is not null");
         }
      }

      internal static void IsNotNullOrEmpty(string toBeTested, string objectName) {
         if (string.IsNullOrEmpty(toBeTested)) {
            throw AssertException.Create("Precondition", objectName + " is not null or empty");
         }
      }
   }

   internal class Ensures {
      /**
         Checks a postcondition and throws an exception if this postcondition is false
         
         @param postcondition This postcondition should be true, otherwise an exception will be thrown
         @param conditionDescription A textual description of the postcondition
      */
      internal static void That(bool postcondition, string conditionDescription) {
         if (!postcondition) {
            throw AssertException.Create("Postcondition", conditionDescription);
         }
      }

      /**
         Checks a postcondition and throws an exception if this
         postcondition is false.  This method should be used, if a
         description must be dynamically created.  string.Format() will
         only be called, if the postcondition fails.
      
         @param postcondition This postcondition should be true, otherwise an exception will be thrown
         @param descriptionFormat Will be passed to string.Format(), to create a textual description of the postcondition
         @param descriptionParameters Will be passed to string.Format(), to create a textual description of the postcondition
      */
      internal static void That(bool postcondition, string descriptionFormat, params object[] descriptionParameters) {
         if (!postcondition) {
            throw AssertException.Create("Postcondition",
                                         descriptionFormat,
                                         descriptionParameters);
         }
      }
      
      internal static void That(System.Func<bool> function) {
         if (!function()) {
            throw AssertException.Create("Postcondition", function);
         }
      }

      /**
         Checks if the toBeTested is not null and throws an exception if this postcondition is false.
         
         @param toBeTested The object for test.
         @param objectName Name of the object.
      */
      internal static void IsNotNull(object toBeTested, string objectName) {
         if (toBeTested == null) {
            throw AssertException.Create("Postcondition", objectName + " is not null");
         }
      }

      internal static void IsNotNullOrEmpty(string toBeTested, string objectName) {
         if (string.IsNullOrEmpty(toBeTested)) {
            throw AssertException.Create("Postcondition", objectName + " is not null or empty");
         }
      }
   }

   internal class Checks {
      /**
         Checks a condition and throws an exception if this condition is false
         
         @param condition This condition should be true, otherwise an exception will be thrown
         @param conditionDescription A textual description of the condition
      */
      internal static void That(bool condition, string conditionDescription) {
         if (!condition) {
            throw AssertException.Create("Condition", conditionDescription);
         }
      }

      /**
         Checks a condition and throws an exception if this condition is
         false.  This method should be used, if a description must be
         dynamically created.  string.Format() will only be called, if the
         condition fails.
      
         @param condition This condition should be true, otherwise an
         exception will be thrown
         @param descriptionFormat Will be passed to string.Format(), to
         create a textual description of the condition
         @param descriptionParameters Will be passed to string.Format(),
         to create a textual description of the condition
      */
      internal static void That(bool condition, string descriptionFormat, params object[] descriptionParameters) {
         if (!condition) {
            throw AssertException.Create("Condition",
                                         descriptionFormat,
                                         descriptionParameters);
         }
      }

      
      internal static void That(System.Func<bool> function) {
         if (!function()) {
            throw AssertException.Create("Condition", function);
         }
      }

      /**
         Checks if the toBeTested is not null and throws an exception if
         this precondition is false.

         @param toBeTested The object for test.
         @param objectName Name of the object.
      */
      internal static void IsNotNull(object toBeTested, string objectName) {
         if (toBeTested == null) {
            throw AssertException.Create("Condition", objectName + " is not null");
         }
      }

      internal static void IsNotNullOrEmpty(string toBeTested, string objectName) {
         if (string.IsNullOrEmpty(toBeTested)) {
            throw AssertException.Create("Condition", objectName + " is not null or empty");
         }
      }

   }
   
   internal class AssertException: System.Exception {
      private static string AnonymousFunctionDescription = "anonymous function delivers true";
      internal static AssertException Create(string assertionType, string conditionDescription) {
         return new AssertException(assertionType, conditionDescription);
      }

      internal static AssertException Create(
         string assertionType,
         string descriptionFormat,
         params object[] descriptionParameters) {
         return new AssertException(
                   assertionType,
                   string.Format(System.Globalization.CultureInfo.InvariantCulture,
                                 descriptionFormat,
                                 descriptionParameters));
      }

      internal static AssertException Create(
         string assertionType, System.Func<bool> function) {
         string methodName = function.Method.Name;
         System.Text.RegularExpressions.Regex anonymousFunctionNamePattern = new System.Text.RegularExpressions.Regex(@"<.*>.*__.*");
         if (!anonymousFunctionNamePattern.IsMatch(methodName)) {
            return new AssertException(assertionType, methodName);
         } else {
            throw new AssertException(
               assertionType, AnonymousFunctionDescription);
         }
      }

      internal AssertException() {}

      internal AssertException(string message): base(message) {}
      internal AssertException(string message, System.Exception innerException): base(message, innerException) {}


      internal AssertException(string assertionType, string description)
        : base(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                             "{0} failed. The expectation was '{1}', but this is false.",
                             assertionType, description)) {
      }
   }
}
