// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import DocumentosInc from '../Inc/Documentos';
import { IDocumentos } from '../../Interfaces/interface.Documentos';
import { useIsMobile } from '@/app/context/MobileContext';
import { DocumentosEmpty } from '@/app/GerAdv_TS/Models/Documentos';
import { useWindow } from '@/app/hooks/useWindows';
interface DocumentosWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedDocumentos?: IDocumentos;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const DocumentosWindow: React.FC<DocumentosWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedDocumentos, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Documentos'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedDocumentos?.id ?? 0).toString()}
>
<DocumentosInc
id={selectedDocumentos?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowDocumentos: React.FC<DocumentosWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<DocumentosWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedDocumentos={DocumentosEmpty()}>
</DocumentosWindow>
)
};
export default DocumentosWindow;