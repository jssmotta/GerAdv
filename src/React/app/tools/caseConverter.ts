// Utility functions to convert object keys between camelCase and PascalCase

/**
 * Convert a string from camelCase to PascalCase
 * @param str - The string to convert
 * @returns The PascalCase version of the string
 */
export function toPascalCase(str: string): string {
  if (!str || str.length === 0) return str;
  return str.charAt(0).toUpperCase() + str.slice(1);
}

/**
 * Convert an object's keys from camelCase to PascalCase recursively
 * @param obj - The object to convert
 * @returns A new object with PascalCase keys
 */
export function objectToPascalCase<T = any>(obj: any): T {
  if (obj === null || obj === undefined) {
    return obj;
  }

  if (Array.isArray(obj)) {
    return obj.map((item) => objectToPascalCase(item)) as any;
  }

  if (typeof obj !== 'object' || obj instanceof Date) {
    return obj;
  }

  const result: any = {};
  
  for (const key in obj) {
    if (obj.hasOwnProperty(key)) {
      const pascalKey = toPascalCase(key);
      result[pascalKey] = objectToPascalCase(obj[key]);
    }
  }

  return result;
}

/**
 * Convert a string from PascalCase to camelCase
 * @param str - The string to convert
 * @returns The camelCase version of the string
 */
export function toCamelCase(str: string): string {
  if (!str || str.length === 0) return str;
  return str.charAt(0).toLowerCase() + str.slice(1);
}

/**
 * Convert an object's keys from PascalCase to camelCase recursively
 * @param obj - The object to convert
 * @returns A new object with camelCase keys
 */
export function objectToCamelCase<T = any>(obj: any): T {
  if (obj === null || obj === undefined) {
    return obj;
  }

  if (Array.isArray(obj)) {
    return obj.map((item) => objectToCamelCase(item)) as any;
  }

  if (typeof obj !== 'object' || obj instanceof Date) {
    return obj;
  }

  const result: any = {};
  
  for (const key in obj) {
    if (obj.hasOwnProperty(key)) {
      const camelKey = toCamelCase(key);
      result[camelKey] = objectToCamelCase(obj[key]);
    }
  }

  return result;
}
