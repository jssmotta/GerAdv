// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import DocsRecebidosItensInc from '../Inc/DocsRecebidosItens';
import { IDocsRecebidosItens } from '../../Interfaces/interface.DocsRecebidosItens';
import { useIsMobile } from '@/app/context/MobileContext';
import { DocsRecebidosItensEmpty } from '@/app/GerAdv_TS/Models/DocsRecebidosItens';
import { useWindow } from '@/app/hooks/useWindows';
interface DocsRecebidosItensWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedDocsRecebidosItens?: IDocsRecebidosItens;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const DocsRecebidosItensWindow: React.FC<DocsRecebidosItensWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedDocsRecebidosItens, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Docs Recebidos Itens'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedDocsRecebidosItens?.id ?? 0).toString()}
>
<DocsRecebidosItensInc
id={selectedDocsRecebidosItens?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowDocsRecebidosItens: React.FC<DocsRecebidosItensWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<DocsRecebidosItensWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedDocsRecebidosItens={DocsRecebidosItensEmpty()}>
</DocsRecebidosItensWindow>
)
};
export default DocsRecebidosItensWindow;