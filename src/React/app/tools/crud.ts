'use client';
export const ActionEditar = 'Editar';
export const ActionAdicionar = 'Adicionar';

export const applyFilter = (data: any, field: string, filterValue: string) => {
  // If no filter value provided, treat as no-op (match all)
  if (filterValue === '' || filterValue === null || filterValue === undefined) {
    return true;
  }

  const fieldValue = data[field];

  if (filterValue === 'isnotempty') {
    return fieldValue !== '';
  } else if (filterValue === 'isempty') {
    return fieldValue === '';
  } else if (filterValue === 'isnull') {
    return fieldValue === null;
  } else if (filterValue === 'notisnull') {
    return fieldValue !== null;
  }

  // For string comparison operations, convert field value to string
  const fieldValueStr = fieldValue != null ? String(fieldValue).toLowerCase() : '';
  const filterValueLower = filterValue.toLowerCase();

  if (filterValue.startsWith('!')) {
    return !fieldValueStr.includes(filterValue.substring(1).toLowerCase());
  } else if (filterValue.startsWith('eq:')) {
    return fieldValueStr === filterValue.substring(3).toLowerCase();
  } else if (filterValue.startsWith('neq:')) {
    return fieldValueStr !== filterValue.substring(4).toLowerCase();
  } else if (filterValue.startsWith('contains:')) {
    return fieldValueStr.includes(filterValue.substring(9).toLowerCase());
  } else if (filterValue.startsWith('doesnotcontain:')) {
    return !fieldValueStr.includes(filterValue.substring(15).toLowerCase());
  } else if (filterValue.startsWith('startswith:')) {
    return fieldValueStr.startsWith(filterValue.substring(11).toLowerCase());
  } else if (filterValue.startsWith('endswith:')) {
    return fieldValueStr.endsWith(filterValue.substring(9).toLowerCase());
  } else {
    return fieldValueStr.includes(filterValueLower);
  }
};

export const applyFilterToColumn = (filter: any, newColumnFilters: any) => {
  if (
    'field' in filter &&
    typeof filter.field === 'string' &&
    'value' in filter &&
    filter.field in newColumnFilters
  ) {
    if (filter.operator === 'isnotempty') {
      newColumnFilters[filter.field as keyof typeof newColumnFilters] =
        'isnotempty';
    } else if (filter.operator === 'isempty') {
      newColumnFilters[filter.field as keyof typeof newColumnFilters] =
        'isempty';
    } else if (filter.operator === 'isnull') {
      newColumnFilters[filter.field as keyof typeof newColumnFilters] =
        'isnull';
    } else if (filter.operator === 'notisnull') {
      newColumnFilters[filter.field as keyof typeof newColumnFilters] =
        'notisnull';
    } else if (filter.operator === 'eq') {
      newColumnFilters[filter.field as keyof typeof newColumnFilters] =
        'eq:' + filter.value?.toLowerCase();
    } else if (filter.operator === 'neq') {
      newColumnFilters[filter.field as keyof typeof newColumnFilters] =
        'neq:' + filter.value?.toLowerCase();
    } else if (filter.operator === 'contains') {
      newColumnFilters[filter.field as keyof typeof newColumnFilters] =
        'contains:' + filter.value?.toLowerCase();
    } else if (filter.operator === 'doesnotcontain') {
      newColumnFilters[filter.field as keyof typeof newColumnFilters] =
        'doesnotcontain:' + filter.value?.toLowerCase();
    } else if (filter.operator === 'startswith') {
      newColumnFilters[filter.field as keyof typeof newColumnFilters] =
        'startswith:' + filter.value?.toLowerCase();
    } else if (filter.operator === 'endswith') {
      newColumnFilters[filter.field as keyof typeof newColumnFilters] =
        'endswith:' + filter.value?.toLowerCase();
    } else if (filter.value) {
      newColumnFilters[filter.field as keyof typeof newColumnFilters] =
        filter.value?.toLowerCase();
    }
  }
};

// Helper function to detect and parse different data types for sorting
const getComparableValue = (value: any, field: string): any => {
  if (value === null || value === undefined) {
    return '';
  }

  // Convert to string for analysis
  const stringValue = String(value);

  // Check if it's a date (ISO format, dd/mm/yyyy, mm/dd/yyyy, etc.)
  if (field.toLowerCase().includes('dt') || field.toLowerCase().includes('date') ||
    /^\d{4}-\d{2}-\d{2}/.test(stringValue) ||
    /^\d{2}\/\d{2}\/\d{4}/.test(stringValue) ||
    /^\d{2}-\d{2}-\d{4}/.test(stringValue)) {
    const dateValue = new Date(value);
    return isNaN(dateValue.getTime()) ? new Date(0) : dateValue;
  }

  // Check if it's a currency (contains currency symbols)
  if (typeof value === 'string' && /[$€£¥₹R$]/.test(stringValue)) {
    // Remove currency symbols and parse as number
    const numericValue = parseFloat(stringValue.replace(/[$€£¥₹R$,\s]/g, ''));
    return isNaN(numericValue) ? 0 : numericValue;
  }

  // Check if it's a number (integer or decimal)
  if (typeof value === 'number') {
    return value;
  }

  // Try to parse as number (for string numbers)
  const numericValue = parseFloat(stringValue);
  if (!isNaN(numericValue) && isFinite(numericValue)) {
    return numericValue;
  }

  // Default to string comparison (case-insensitive)
  return stringValue.toLowerCase();
};

export const sortData = (data: any[], sortDescriptor: any[]) => {
  if (sortDescriptor.length === 0) {
    return data;
  }

  const direction = sortDescriptor[0].dir;
  const field = sortDescriptor[0].field;

  if (!field || !direction) {
    return data;
  }

  const sortedData = [...data].sort((a: any, b: any) => {
    const valueA = getComparableValue(a[field], field);
    const valueB = getComparableValue(b[field], field);

    // Handle null/undefined values
    if (valueA === '' && valueB !== '') return direction === 'asc' ? 1 : -1;
    if (valueA !== '' && valueB === '') return direction === 'asc' ? -1 : 1;
    if (valueA === '' && valueB === '') return 0;

    // For dates, numbers, and other comparable types
    if (valueA instanceof Date && valueB instanceof Date) {
      const comparison = valueA.getTime() - valueB.getTime();
      return direction === 'asc' ? comparison : -comparison;
    }

    // For numbers
    if (typeof valueA === 'number' && typeof valueB === 'number') {
      const comparison = valueA - valueB;
      return direction === 'asc' ? comparison : -comparison;
    }

    // For strings (default case)
    if (valueA < valueB) {
      return direction === 'asc' ? -1 : 1;
    }
    if (valueA > valueB) {
      return direction === 'asc' ? 1 : -1;
    }
    return 0;
  });

  return sortedData;
};

// Determina o DEFAULT_TAKE baseado na altura da tela
const calculateDefaultTake = (): number => {
  if (typeof window === 'undefined') { 
    return 10;
  }
  const screenHeight = window.innerHeight || window.screen.height;
  const defaultTake = screenHeight > 800 ? 15 : 10; 
  return defaultTake;
};

// Calcula o valor uma vez durante a inicialização
const DEFAULT_TAKE_VALUE = calculateDefaultTake(); 

export const CRUD_CONSTANTS = {
  DEFAULT_MAX_RECORDS: 200,
  REFRESH_TIMEOUT: 500,
  MAX_RECORDS_COMBO: 5000,
  PAGINATION: {
    DEFAULT_TAKE: DEFAULT_TAKE_VALUE,
    PAGE_SIZES: [10, 15, 30, 50, 100, 200],
    BUTTON_COUNT: 5,
  },
} as const;

// Additional helper functions for specific data types
export const formatCurrency = (value: number, currency: string = 'BRL'): string => {
  try {
    return new Intl.NumberFormat('pt-BR', {
      style: 'currency',
      currency: currency,
    }).format(value);
  } catch (error) {
    // Fallback to manual formatting if locale is not supported
    const symbol = currency === 'BRL' ? 'R$' : currency;
    return `${symbol} ${value.toFixed(2).replace('.', ',').replace(/\B(?=(\d{3})+(?!\d))/g, '.')}`;
  }
};

export const formatNumber = (value: number, minimumFractionDigits: number = 0): string => {
  try {
    return new Intl.NumberFormat('pt-BR', {
      minimumFractionDigits: minimumFractionDigits,
    }).format(value);
  } catch (error) {
    // Fallback to manual formatting if locale is not supported
    return value.toFixed(minimumFractionDigits).replace('.', ',').replace(/\B(?=(\d{3})+(?!\d))/g, '.');
  }
};

// Custom sort functions for specific scenarios
export const sortByDate = (data: any[], field: string, direction: 'asc' | 'desc' = 'asc') => {
  return [...data].sort((a, b) => {
    const dateA = new Date(a[field]);
    const dateB = new Date(b[field]);

    if (isNaN(dateA.getTime()) && isNaN(dateB.getTime())) return 0;
    if (isNaN(dateA.getTime())) return direction === 'asc' ? 1 : -1;
    if (isNaN(dateB.getTime())) return direction === 'asc' ? -1 : 1;

    const comparison = dateA.getTime() - dateB.getTime();
    return direction === 'asc' ? comparison : -comparison;
  });
};

export const sortByNumber = (data: any[], field: string, direction: 'asc' | 'desc' = 'asc') => {
  return [...data].sort((a, b) => {
    const numA = parseFloat(a[field]) || 0;
    const numB = parseFloat(b[field]) || 0;

    const comparison = numA - numB;
    return direction === 'asc' ? comparison : -comparison;
  });
};

export const sortByCurrency = (data: any[], field: string, direction: 'asc' | 'desc' = 'asc') => {
  return [...data].sort((a, b) => {
    const numA = parseFloat(String(a[field]).replace(/[$€£¥₹R$,\s]/g, '')) || 0;
    const numB = parseFloat(String(b[field]).replace(/[$€£¥₹R$,\s]/g, '')) || 0;

    const comparison = numA - numB;
    return direction === 'asc' ? comparison : -comparison;
  });
};

export interface ApiError {
  message: string;
  status: number;
  code?: string;
}



/**
 * Utilitário para formatação de datas
 */

export interface DateFormatOptions {
  year?: 'numeric' | '2-digit';
  month?: 'numeric' | '2-digit' | 'short' | 'long' | 'narrow';
  day?: 'numeric' | '2-digit';
  hour?: 'numeric' | '2-digit';
  minute?: 'numeric' | '2-digit';
  second?: 'numeric' | '2-digit';
}

/**
 * Formata uma data usando a localização do navegador
 * @param value - Valor da data (Date, string ou número)
 * @param locale - Localização (padrão: 'pt-BR')
 * @param options - Opções de formatação
 * @returns String formatada da data ou string vazia se valor inválido
 */
export const formatDate = (
  value: Date | string | number | null | undefined,
  locale: string = 'pt-BR',
  options: DateFormatOptions = {
    year: 'numeric',
    month: '2-digit',
    day: '2-digit'
  }
): string => {
  if (!value) return '';

  try {
    const date = new Date(value);

    // Verifica se a data é válida
    if (isNaN(date.getTime())) {
      return '';
    }

    try {
      return date.toLocaleDateString(locale, options);
    } catch (localeError) {
      // Fallback to manual formatting if locale is not supported
      const day = String(date.getDate()).padStart(2, '0');
      const month = String(date.getMonth() + 1).padStart(2, '0');
      const year = date.getFullYear();
      
      if (options.hour || options.minute) {
        const hour = String(date.getHours()).padStart(2, '0');
        const minute = String(date.getMinutes()).padStart(2, '0');
        return `${day}/${month}/${year} ${hour}:${minute}`;
      }
      
      return `${day}/${month}/${year}`;
    }
  } catch (error) {
    console.warn('Erro ao formatar data:', error);
    return '';
  }
};

/**
 * Formata uma data no formato padrão brasileiro (dd/MM/yyyy)
 * @param value - Valor da data
 * @returns String formatada no formato brasileiro
 */
export const formatDateBR = (value: Date | string | number | null | undefined): string => {
  return formatDate(value, 'pt-BR', {
    year: 'numeric',
    month: '2-digit',
    day: '2-digit'
  });
};

/**
 * Formata uma data com hora no formato brasileiro (dd/MM/yyyy HH:mm)
 * @param value - Valor da data
 * @returns String formatada com data e hora
 */
export const formatDateTimeBR = (value: Date | string | number | null | undefined): string => {
  return formatDate(value, 'pt-BR', {
    year: 'numeric',
    month: '2-digit',
    day: '2-digit',
    hour: '2-digit',
    minute: '2-digit'
  });
};

/**
 * Formata uma data no formato americano (MM/dd/yyyy)
 * @param value - Valor da data
 * @returns String formatada no formato americano
 */
export const formatDateUS = (value: Date | string | number | null | undefined): string => {
  return formatDate(value, 'en-US', {
    year: 'numeric',
    month: '2-digit',
    day: '2-digit'
  });
};

/**
 * Formata uma data usando a localização do navegador do usuário
 * @param value - Valor da data
 * @param options - Opções de formatação
 * @returns String formatada usando a localização do navegador
 */
export const formatDateBrowser = (
  value: Date | string | number | null | undefined,
  options: DateFormatOptions = {
    year: 'numeric',
    month: '2-digit',
    day: '2-digit'
  }
): string => {
  // Detecta a localização do navegador
  const locale = navigator.language || navigator.languages?.[0] || 'pt-BR';
  return formatDate(value, locale, options);
};

export const encodeDataForStorage = (data: any): string => {
  if (data === null || data === undefined) {
    return '';
  }  
  try {
    // Limita arrays a 200 registros para evitar problemas de quota
    let processedData = data;
    if (Array.isArray(data) && data.length > 200) {
      processedData = data.slice(0, 200);
    }

    const encoded = btoa(JSON.stringify(processedData, (key, value) => {
      // Converte Date para string ISO com um marcador especial
      if (value instanceof Date) {
        return { __isDate: true, value: value.toISOString() };
      }
      // Verifica se é uma string que parece ser uma data ISO (só para campos específicos de data)
      if (typeof value === 'string' &&
        (key.toLowerCase().includes('date') || key.toLowerCase().includes('data')) &&
        value.match(/^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}/)) {
        return { __isDate: true, value: value };
      }
      return value;
    }));
    return encoded;
  } catch (error) {
    console.log('Error encoding data');
    throw error;
  }
}

export const decodeDataFromStorage = (encodedData: string): any => {
  try {
    const decoded = JSON.parse(atob(encodedData), (key, value) => {
      // Reconverte strings marcadas de volta para Date
      if (value && typeof value === 'object' && value.__isDate) {
        return new Date(value.value);
      }
      return value;
    });
    return decoded;
  } catch (error) {
    console.log('Error decoding data');
    throw error;
  }
}


 export function uniqueKeyDay(): string {
  const today = new Date();
  const year = today.getFullYear();
  const month = String(today.getMonth() + 1).padStart(2, '0');
  const day = String(today.getDate()).padStart(2, '0');
  return `${year}${month}${day}`;
}