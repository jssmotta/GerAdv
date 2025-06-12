// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import ModelosDocumentosInc from '../Inc/ModelosDocumentos';
import { IModelosDocumentos } from '../../Interfaces/interface.ModelosDocumentos';
import { useIsMobile } from '@/app/context/MobileContext';
import { ModelosDocumentosEmpty } from '@/app/GerAdv_TS/Models/ModelosDocumentos';
import { useWindow } from '@/app/hooks/useWindows';
interface ModelosDocumentosWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedModelosDocumentos?: IModelosDocumentos;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const ModelosDocumentosWindow: React.FC<ModelosDocumentosWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedModelosDocumentos, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Modelos Documentos'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={702}
  newWidth={1250}
  mobile={isMobile}
  id={(selectedModelosDocumentos?.id ?? 0).toString()}
>
<ModelosDocumentosInc
id={selectedModelosDocumentos?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowModelosDocumentos: React.FC<ModelosDocumentosWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<ModelosDocumentosWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedModelosDocumentos={ModelosDocumentosEmpty()}>
</ModelosDocumentosWindow>
)
};
export default ModelosDocumentosWindow;