// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import DadosProcuracaoInc from '../Inc/DadosProcuracao';
import { IDadosProcuracao } from '../../Interfaces/interface.DadosProcuracao';
import { useIsMobile } from '@/app/context/MobileContext';
import { DadosProcuracaoEmpty } from '@/app/GerAdv_TS/Models/DadosProcuracao';
import { useWindow } from '@/app/hooks/useWindows';
interface DadosProcuracaoWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedDadosProcuracao?: IDadosProcuracao;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const DadosProcuracaoWindow: React.FC<DadosProcuracaoWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedDadosProcuracao, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Dados Procuracao'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={791}
  newWidth={900}
  mobile={isMobile}
  id={(selectedDadosProcuracao?.id ?? 0).toString()}
>
<DadosProcuracaoInc
id={selectedDadosProcuracao?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowDadosProcuracao: React.FC<DadosProcuracaoWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<DadosProcuracaoWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedDadosProcuracao={DadosProcuracaoEmpty()}>
</DadosProcuracaoWindow>
)
};
export default DadosProcuracaoWindow;