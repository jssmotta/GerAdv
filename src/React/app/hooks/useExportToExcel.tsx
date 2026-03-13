"use client";
import { useCallback } from 'react';
import { saveAs } from '@progress/kendo-file-saver';
import { Workbook } from '@progress/kendo-ooxml';
import React from 'react';

interface ExportColumn {
  field: string;
  title: string;
  width?: number;
  format?: string;
  hidden?: boolean;
}

interface UseExportToExcelProps {
  filename?: string;
  columns: ExportColumn[];
  sheetName?: string;
}

interface ExportOptions {
  filteredData?: boolean;
  customFilename?: string;
  customSheetName?: string;
}

export function getExportColumns(gridColumns: React.ReactNode, columnsState: any[], excludeFields: string[] = ['id', 'index']) {
  // Cria um mapa de visibilidade a partir do columnsState
  const visibilityMap = columnsState.reduce((acc: any, col: any) => {
    if (col.field) acc[col.field] = !col.hidden;
    return acc;
  }, {});

  // Extrai props das colunas do grid e filtra conforme visibilidade e exclusão
  return React.Children.toArray(gridColumns)
    .map((col: any) => col.props)
    .filter((col: any) => {
      const hasField = !!col.field;
      const notExcluded = !excludeFields.includes(col.field);
      const notIdEdit = !col.field?.startsWith('id_edit_');
      const titleLower = col.title?.toLowerCase() || '';
      const notActionTitle = !titleLower.includes('excluir') && 
                            !titleLower.includes('editar') &&                             
                            !titleLower.includes('action');
      const isvisible = visibilityMap[col.field] !== false; // só inclui se não estiver oculto
      
     
      
      return hasField && notExcluded && notIdEdit && notActionTitle && isvisible;
    })
    .map((col: any) => ({
      field: col.field,
      title: col.title,
      hidden: false,
    }));
} 

export const useExportToExcel = ({
  filename = 'export',
  columns,
  sheetName = 'Dados'
}: UseExportToExcelProps) => {
  
  const exportToExcel = useCallback((
    data: any[],
    options: ExportOptions = {}
  ) => {
    const {
      customFilename = filename,
      customSheetName = sheetName
    } = options;

    // Filtrar apenas colunas visíveis
    const visibleColumns = columns.filter(col => !col.hidden);

    // Criar o workbook
    const workbook = new Workbook({
      sheets: [
        {
          name: customSheetName,
          rows: [
            // Cabeçalho
            {
              cells: visibleColumns.map(col => ({
                value: col.title,
                bold: true,
                background: '#E0E0E0',
                color: '#000000'
              }))
            },
            // Dados
            ...data.map(item => ({
              cells: visibleColumns.map(col => {
                let value = item[col.field];
                
                // Aplicar formatação se especificada
                if (col.format && value !== null && value !== undefined) {
                  // Exemplo de formatação para datas
                  if (col.format.includes('date')) {
                    value = new Date(value);
                  }
                  // Exemplo de formatação para números
                  else if (col.format.includes('number')) {
                    value = Number(value);
                  }
                }
                
                return {
                  value: value || '',
                  format: col.format
                };
              })
            }))
          ],
          // Configurar largura das colunas
          columns: visibleColumns.map(col => ({
            width: col.width || 120
          }))
        }
      ]
    });

    // Gerar o arquivo Excel
    workbook.toDataURL().then((dataURL: string) => {
      saveAs(dataURL, `${customFilename}.xlsx`);
    });
  }, [columns, filename, sheetName]);

  return { exportToExcel };
};