namespace StripeTests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Microsoft.Extensions.DependencyModel;
    using Newtonsoft.Json;
    using Stripe;
    using Xunit;

#if NETCOREAPP
    public class NullableValueTypes
    {
        [Fact]
        public void EnsureAllValueTypesAreNullable()
        {
            List<string> results = new List<string>();

            // Get all classes that implement INestedOptions
            var type = typeof(INestedOptions);
            var assembly = type.GetTypeInfo().Assembly;
            var optionsClasses = assembly.DefinedTypes
                .Where(t => t.IsClass && t.ImplementedInterfaces.Contains(type))
                .Select(t => t.AsType());

            foreach (Type optionsClass in optionsClasses)
            {
                foreach (PropertyInfo property in optionsClass.GetProperties())
                {
                    var propType = property.PropertyType;

                    // Skip properties that don't have a `JsonProperty` attribute
                    var attribute = property.GetCustomAttribute<JsonPropertyAttribute>();
                    if (attribute == null)
                    {
                        continue;
                    }

                    // Skip non-value types
                    if (!propType.GetTypeInfo().IsValueType)
                    {
                        continue;
                    }

                    // Skip value types that are already nullable
                    if (propType.GetTypeInfo().IsGenericType &&
                        propType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        continue;
                    }

                    results.Add($"{optionsClass.Name}.{property.Name}");
                }
            }

            if (results.Any())
            {
                // Sort results alphabetically
                results = results.OrderBy(i => i).ToList();

                // Display our own error message (because Assert.Empty truncates the results)
                Console.WriteLine("Found non-nullable value types:");
                foreach (string item in results)
                {
                    Console.WriteLine($"- {item}");
                }

                // Actually fail test
                Assert.True(false, "Found at least one non-nullable value type");
            }
        }
    }
#endif
}
