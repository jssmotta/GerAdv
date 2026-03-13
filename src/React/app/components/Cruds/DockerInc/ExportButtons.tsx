'use client';
import React, { useState } from 'react';
import { Button } from '@progress/kendo-react-buttons';
import { Dialog, DialogActionsBar } from '@progress/kendo-react-dialogs';
import { SvgIcon } from '@progress/kendo-react-common';
import { fileExcelIcon, filePdfIcon } from '@progress/kendo-svg-icons';
import { useAppSelector } from '@/app/store/hooks';
import { selectSystemContext } from '@/app/store/slices/systemContextSlice';
import { useIsMobile } from '@/app/context/MobileContext';

interface ExportButtonsProps {
  onExportExcel?: () => void;
  onExportPdf?: () => void;
  showExcelButton?: boolean;
  showPdfButton?: boolean;
  confirmationMessage?: string;
  excelButtonText?: string;
  pdfButtonText?: string;
  containerStyle?: React.CSSProperties;
  onlyMaster?: boolean;
}

export const ExportButtons: React.FC<ExportButtonsProps> = ({
  onExportExcel,
  onExportPdf,
  onlyMaster = false,
  showExcelButton = true,
  showPdfButton = true,
  confirmationMessage = 'Tem certeza que deseja exportar os dados?',
  excelButtonText = 'Exportar Excel',
  pdfButtonText = 'Exportar Pdf',
  containerStyle = { marginTop: '10px' }
}) => {
  const [showDialog, setShowDialog] = useState(false);
  const [exportType, setExportType] = useState<'excel' | 'pdf' | null>(null);
  const systemContext = useAppSelector(selectSystemContext);
  const isMobile = useIsMobile();
  const handleExportClick = (type: 'excel' | 'pdf') => {
    setExportType(type);
    setShowDialog(true);
  };

  const handleConfirmExport = () => {
    if (exportType === 'excel' && onExportExcel) {
      onExportExcel();
    } else if (exportType === 'pdf' && onExportPdf) {
      onExportPdf();
    }
    setShowDialog(false);
    setExportType(null);
  };

  const handleCancelExport = () => {
    setShowDialog(false);
    setExportType(null);
  };

  return (
    <>
      {(!onlyMaster || systemContext?.IsMaster) && (
        <>
          <div style={{ display: 'flex', gap: '10px' }}>
            {showExcelButton && onExportExcel && (
              
                <Button
                  className="k-button"
                  title='Clique para exportar para formato do Microsoft Excel'
                  aria-label={excelButtonText}
                  onClick={() => handleExportClick('excel')}>
                  <SvgIcon icon={fileExcelIcon} />
                </Button>
              
            )}

            {showPdfButton && !isMobile && onExportPdf && (
             
                <Button
                  className="k-button"
                  title='Clique para exportar para PDF'
                  aria-label={pdfButtonText}
                  onClick={() => handleExportClick('pdf')}>
                  <SvgIcon icon={filePdfIcon} />
                </Button>
              
            )}
          </div>

          {showDialog && (
            <Dialog
              title={`Confirmação de Exportação para ${exportType?.toUpperCase()}`}
              onClose={handleCancelExport}
              width={440}
              height={220}
            >
              <p style={{ margin: '20px 20px' }}>{confirmationMessage}</p>
              <DialogActionsBar>
                <Button aria-label="Cancelar" onClick={handleCancelExport} title='Clique para cancelar a exportação'>Cancelar</Button>
                <Button aria-label="Confirmar" onClick={handleConfirmExport} themeColor="primary" title='Clique para confirmar a exportação'>
                  Confirmar
                </Button>
              </DialogActionsBar>
            </Dialog>
          )}
        </>
      )}
    </>

  );
};

