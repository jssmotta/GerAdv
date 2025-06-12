// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import GruposEmpresasCliInc from '../Inc/GruposEmpresasCli';
import { IGruposEmpresasCli } from '../../Interfaces/interface.GruposEmpresasCli';
import { useIsMobile } from '@/app/context/MobileContext';
import { GruposEmpresasCliEmpty } from '@/app/GerAdv_TS/Models/GruposEmpresasCli';
import { useWindow } from '@/app/hooks/useWindows';
interface GruposEmpresasCliWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedGruposEmpresasCli?: IGruposEmpresasCli;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const GruposEmpresasCliWindow: React.FC<GruposEmpresasCliWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedGruposEmpresasCli, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Grupos Empresas Cli'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedGruposEmpresasCli?.id ?? 0).toString()}
>
<GruposEmpresasCliInc
id={selectedGruposEmpresasCli?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowGruposEmpresasCli: React.FC<GruposEmpresasCliWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<GruposEmpresasCliWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedGruposEmpresasCli={GruposEmpresasCliEmpty()}>
</GruposEmpresasCliWindow>
)
};
export default GruposEmpresasCliWindow;