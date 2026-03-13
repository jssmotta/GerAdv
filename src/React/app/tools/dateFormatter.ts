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
    
    return date.toLocaleDateString(locale, options);
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
