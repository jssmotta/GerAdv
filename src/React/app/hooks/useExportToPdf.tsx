"use client";
import { useCallback } from 'react';
import { saveAs } from '@progress/kendo-file-saver';
import { drawDOM, exportPDF } from '@progress/kendo-drawing';
import React from 'react';

interface ExportColumn {
  field: string;
  title: string;
  width?: number;
  format?: string;
  hidden?: boolean;
}

interface UseExportToPdfProps {
  filename?: string;
  columns: ExportColumn[];
  title?: string;
  paperSize?: string;
  margin?: string;
  landscape?: boolean;
}

interface ExportOptions {
  filteredData?: boolean;
  customFilename?: string;
  customTitle?: string;
  customPaperSize?: string;
  customMargin?: string;
  customLandscape?: boolean;
}

export function getExportColumnsPdf(gridColumns: React.ReactNode, columnsState: any[], excludeFields: string[] = ['id', 'index']) {
  const visibilityMap = columnsState?.reduce((acc: any, col: any) => {
    if (col.field) acc[col.field] = !col.hidden;
    return acc;
  }, {}) || {};

  const filteredColumns = React.Children.toArray(gridColumns)
    .map((col: any) => col.props)
    .filter((col: any) => {
      const hasField = !!col.field;
      const notExcluded = !excludeFields.includes(col.field);
      const notIdEdit = !col.field?.startsWith('id_edit_');
      const titleLower = col.title?.toLowerCase() || '';
      const notActionTitle = !titleLower.includes('excluir') && 
                            !titleLower.includes('editar') &&                             
                            !titleLower.includes('action');
      const isvisible = columnsState?.length > 0 ? visibilityMap[col.field] !== false : true;
      
      return hasField && notExcluded && notIdEdit && notActionTitle && isvisible;
    });

  return filteredColumns
    .map((col: any) => ({
      field: col.field,
      title: col.title,
      hidden: false,
    }));

  // Log final para debug
  if (process.env.NEXT_PUBLIC_SHOW_LOG === '1') {
    console.log('Colunas finais para PDF:', filteredColumns.map(c => c.field));
  }

  return filteredColumns;
}

export const useExportToPdf = ({
  filename = 'export',
  columns,
  title = 'Relatório',
  paperSize = 'A4',
  margin = '0.75in',
  landscape = false
}: UseExportToPdfProps) => {
  
  const formatValue = useCallback((value: any, format?: string) => {
    if (value === null || value === undefined) return '';
    
    let stringValue = '';
    const userLocale = navigator.language || 'pt-BR';
    
    if (format) {
      if (format.includes('date')) {
        try {
          const date = new Date(value);
          stringValue = date.toLocaleDateString(userLocale);
        } catch (e) {
          stringValue = String(value);
        }
      }
      else if (format.includes('number') || format.includes('currency')) {
        try {
          const num = Number(value);
          if (format.includes('currency')) {
            const currencyMap: { [key: string]: string } = {
              'pt-BR': 'BRL',
              'en-US': 'USD',
              'en-GB': 'GBP',
              'es-ES': 'EUR',
              'fr-FR': 'EUR',
              'de-DE': 'EUR',
              'it-IT': 'EUR',
              'ja-JP': 'JPY',
              'zh-CN': 'CNY',
              'ko-KR': 'KRW'
            };
            const currency = currencyMap[userLocale] || currencyMap[userLocale.split('-')[0]] || 'BRL';
            stringValue = num.toLocaleString(userLocale, { style: 'currency', currency: currency });
          } else {
            stringValue = num.toLocaleString(userLocale);
          }
        } catch (e) {
          stringValue = String(value);
        }
      }
      else if (format.includes('percent')) {
        try {
          const num = Number(value);
          stringValue = (num * 100).toFixed(2) + '%';
        } catch (e) {
          stringValue = String(value);
        }
      } else {
        stringValue = String(value);
      }
    } else {
      stringValue = String(value);
    }
    
    return stringValue.normalize('NFC').trim();
  }, []);

  const formatHeader = useCallback((headerText: string) => {
    return String(headerText).normalize('NFC').trim();
  }, []);

  const createHtmlTable = useCallback((data: any[], visibleColumns: ExportColumn[], tableTitle: string) => {
    const shouldUseLandscape = visibleColumns.length > 4;
    
    const calculateColumnWidths = () => {
      const totalColumns = visibleColumns.length;
      
      if (totalColumns <= 3) {
        return visibleColumns.map(() => `${Math.floor(100 / totalColumns)}%`);
      } else if (totalColumns <= 5) {
        return visibleColumns.map(() => `${Math.floor(100 / totalColumns)}%`);
      } else if (totalColumns <= 8) {
        return visibleColumns.map(() => `${Math.floor(90 / totalColumns)}%`);
      } else {
        return visibleColumns.map(() => `${Math.max(8, Math.floor(85 / totalColumns))}%`);
      }
    };
    
    const columnWidths = calculateColumnWidths();
    
    const getFontSize = () => {
      if (visibleColumns.length <= 5) return '11px';
      if (visibleColumns.length <= 8) return '9px';
      return '8px';
    };
    
    const fontSize = getFontSize();
    const headerFontSize = visibleColumns.length > 8 ? '9px' : '12px';
    
    const modernColors = {
      primary: '#2563eb',
      primaryLight: '#3b82f6',
      secondary: '#1e40af',
      accent: '#f8fafc',
      text: '#1f2937',
      textLight: '#6b7280',
      border: '#e5e7eb',
      success: '#10b981',
      warning: '#f59e0b'
    };
    
    const headerHtml = visibleColumns.map((col, index) => 
      `<th style="
        background: linear-gradient(135deg, ${modernColors.primary} 0%, ${modernColors.primaryLight} 100%);
        color: white !important;
        border: none;
        padding: 14px 12px;
        text-align: left;
        font-weight: 600;
        min-width: ${columnWidths[index]};
        font-size: ${headerFontSize};
        font-family: 'Segoe UI', 'Roboto', 'Arial', sans-serif;
        text-transform: uppercase;
        letter-spacing: 0.5px;
        box-shadow: 0 2px 4px rgba(0,0,0,0.1);
        word-wrap: break-word;
        white-space: normal;
        ${index === 0 ? 'border-top-left-radius: 8px;' : ''}
        ${index === visibleColumns.length - 1 ? 'border-top-right-radius: 8px;' : ''}
      ">${formatHeader(col.title)}</th>`
    ).join('');
    
    // Gerar dados com design alternado moderno
    const bodyRows = data.map((item, rowIndex) => {
      const isEven = rowIndex % 2 === 0;
      const cells = visibleColumns.map((col, colIndex) => {
        const value = formatValue(item[col.field], col.format);
        const isFirstCol = colIndex === 0;
        const isLastCol = colIndex === visibleColumns.length - 1;
        const isLastRow = rowIndex === data.length - 1;
        
        return `<td style="
          border: none;
          border-bottom: 1px solid ${modernColors.border};
          padding: 12px;
          color: ${modernColors.text} !important;
          background-color: ${isEven ? '#ffffff' : modernColors.accent};
          min-width: ${columnWidths[colIndex]};
          font-size: ${fontSize};
          font-family: 'Segoe UI', 'Roboto', 'Arial', sans-serif;
          line-height: 1.5;
          word-wrap: break-word;
          white-space: normal;
          transition: background-color 0.2s ease;
          ${isLastRow && isFirstCol ? 'border-bottom-left-radius: 8px;' : ''}
          ${isLastRow && isLastCol ? 'border-bottom-right-radius: 8px;' : ''}
          ${isFirstCol ? 'font-weight: 500;' : ''}
        ">${value}</td>`;
      }).join('');
      
      return `<tr style="transition: all 0.2s ease;">${cells}</tr>`;
    }).join('');
    
    // Ajustar espaçamento para maximizar uso da página
    const containerPadding = '5px';
    const titleFontSize = visibleColumns.length > 8 ? '18px' : '22px';
    
    // Data e hora formatadas
    const currentDate = new Date();
    const formattedDate = currentDate.toLocaleDateString(navigator.language || 'pt-BR', {
      weekday: 'long',
      year: 'numeric',
      month: 'long',
      day: 'numeric'
    });
    const formattedTime = currentDate.toLocaleTimeString(navigator.language || 'pt-BR', {
      hour: '2-digit',
      minute: '2-digit'
    });
    
    const tableHtml = `
      <div style="
        font-family: 'Segoe UI', 'Roboto', 'Arial', sans-serif;
        padding: ${containerPadding};
        background: linear-gradient(135deg, #f8fafc 0%, #e2e8f0 100%);
        min-height: 100vh;
        box-sizing: border-box;
        margin: 0;
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: flex-start;
      ">
        <meta charset="UTF-8">
        
        <!-- Header compacto para maximizar espaço da tabela -->
        <div style="
          text-align: center;
          margin-bottom: 10px;
          padding: 15px 10px;
          background: white;
          border-radius: 8px;
          box-shadow: 0 2px 8px rgba(0,0,0,0.05);
          border-left: 3px solid ${modernColors.primary};
          width: 100%;
          max-width: 100%;
        ">
          <h1 style="
            color: ${modernColors.text} !important;
            font-size: ${titleFontSize};
            font-weight: 700;
            margin: 0 0 5px 0;
            text-transform: uppercase;
            letter-spacing: 1px;
          ">${formatHeader(tableTitle)}</h1>
          <div style="
            color: ${modernColors.textLight} !important;
            font-size: 10px;
            font-weight: 400;
            text-transform: capitalize;
          ">${formattedDate} às ${formattedTime}</div>
        </div>
        
        <!-- Container da tabela maximizado e centralizado -->
        <div style="
          background: white;
          border-radius: 8px;
          overflow: hidden;
          box-shadow: 0 2px 10px rgba(0,0,0,0.05);
          border: 1px solid ${modernColors.border};
          height: calc(100vh - 120px);
          display: flex;
          justify-content: center;
          align-items: flex-start;
          padding: 10px;
          width: 100%;
          max-width: 100%;
        ">
          <div style="
            width: 100%;
            max-width: 100%;
            overflow-x: auto;
            display: flex;
            justify-content: center;
          ">
            <table style="
              width: 100%;
              max-width: 100%;
              border-collapse: collapse;
              font-size: ${fontSize};
              color: ${modernColors.text} !important;
              background-color: white;
              table-layout: auto;
              margin: 0 auto;
            ">
            <thead>
              <tr>
                ${headerHtml}
              </tr>
            </thead>
            <tbody>
              ${bodyRows}
            </tbody>
            </table>
          </div>
        </div>      </div>
    `;
    
    return { tableHtml, shouldUseLandscape };
  }, [formatValue, formatHeader]);

  const exportToPdf = useCallback((
    data: any[],
    options: ExportOptions = {}
  ) => {
    const {
      customFilename = filename,
      customTitle = title,
      customPaperSize = paperSize,
      customMargin = margin,
      customLandscape = landscape
    } = options;

    // Filtrar apenas colunas visíveis
    const visibleColumns = columns.filter(col => !col.hidden);

    // Criar HTML temporário para a tabela
    const { tableHtml, shouldUseLandscape } = createHtmlTable(data, visibleColumns, customTitle);
    
    // Usar modo paisagem automático se tiver mais de 5 colunas
    const finalLandscape = shouldUseLandscape || customLandscape;
    
    // Criar elemento DOM temporário
    const tempDiv = document.createElement('div');
    
    // Configurar encoding UTF-8
    tempDiv.setAttribute('charset', 'UTF-8');
    tempDiv.style.fontFamily = 'Segoe UI, Roboto, Arial, sans-serif';
    tempDiv.style.background = 'white';
    
    tempDiv.innerHTML = tableHtml;
    // Tornar o elemento visível temporariamente para o Kendo processar
    tempDiv.style.position = 'absolute';
    tempDiv.style.left = '0px';
    tempDiv.style.top = '0px';
    tempDiv.style.width = 'auto';
    tempDiv.style.height = 'auto';
    tempDiv.style.overflow = 'visible';
    tempDiv.style.zIndex = '-9999';
    tempDiv.style.opacity = '1';
    document.body.appendChild(tempDiv);

    console.log('Elemento DOM criado:', tempDiv);
    console.log('HTML do elemento:', tempDiv.innerHTML.substring(0, 500));
    console.log(`Modo paisagem: ${finalLandscape} (${visibleColumns.length} colunas)`);

    // Aguardar o elemento ser renderizado
    setTimeout(() => {
      // Configurações de margem mínimas para usar 100% do espaço
      const getMargins = () => {
        return { top: "0.3cm", right: "0.3cm", bottom: "0.3cm", left: "0.3cm" };
      };
      
      // Exportar para PDF usando configuração otimizada
      drawDOM(tempDiv, {
        paperSize: customPaperSize || 'A4',
        margin: getMargins(),
        landscape: finalLandscape,
        scale: 1.0, // Usar escala máxima para aproveitar todo o espaço
        forcePageBreak: '.page-break',
        keepTogether: '.keep-together'
      })
      .then((group) => {
        console.log('DrawDOM group:', group);
        return exportPDF(group, {
          paperSize: customPaperSize || 'A4',
          landscape: finalLandscape
        });
      })
      .then((dataURI) => {
        console.log('PDF DataURI gerado:', dataURI ? 'Sucesso' : 'Falhou');
        saveAs(dataURI, `${customFilename}.pdf`);
        // Remover elemento temporário
        if (document.body.contains(tempDiv)) {
          document.body.removeChild(tempDiv);
        }
      })
      .catch((error) => {
        console.error('Erro ao exportar PDF:', error);
        // Remover elemento temporário em caso de erro
        if (document.body.contains(tempDiv)) {
          document.body.removeChild(tempDiv);
        }
      });
    }, 100);
  }, [columns, filename, title, paperSize, margin, landscape, createHtmlTable]);

  return { exportToPdf };
};