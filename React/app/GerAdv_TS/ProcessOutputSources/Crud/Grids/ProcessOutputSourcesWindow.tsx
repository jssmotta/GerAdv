// CrudWindow.tsx
'use client';
import React, { useEffect } from 'react';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import ProcessOutputSourcesInc from '../Inc/ProcessOutputSources';
import { IProcessOutputSources } from '../../Interfaces/interface.ProcessOutputSources';
import { useIsMobile } from '@/app/context/MobileContext';
import { ProcessOutputSourcesEmpty } from '@/app/GerAdv_TS/Models/ProcessOutputSources';
import { useWindow } from '@/app/hooks/useWindows';
interface ProcessOutputSourcesWindowProps {
  isOpen: boolean;
  onClose: () => void;
  dimensions?: { width: number; height: number };
  selectedProcessOutputSources?: IProcessOutputSources;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const ProcessOutputSourcesWindow: React.FC<ProcessOutputSourcesWindowProps> = ({
  isOpen, 
  onClose, 
  dimensions, 
  selectedProcessOutputSources, 
  onSuccess, 
  onError, 
}) => {

const isMobile = useIsMobile();
const dimensionsEmpty = useWindow();
return (
<>
{!isOpen ? <></> : <>
  <EditWindow
  tableTitle='Process Output Sources'
  isOpen={isOpen}
  onClose={onClose}
  dimensions={dimensions ?? dimensionsEmpty}
  newHeight={560}
  newWidth={900}
  mobile={isMobile}
  id={(selectedProcessOutputSources?.id ?? 0).toString()}
>
<ProcessOutputSourcesInc
id={selectedProcessOutputSources?.id ?? 0}
onClose={onClose}
onSuccess={onSuccess}
onError={onError}
/>
</EditWindow>
</>}
</>
);
};
export const NewWindowProcessOutputSources: React.FC<ProcessOutputSourcesWindowProps> = ({
  isOpen, 
  onClose, 
}) => {
const dimensions = useWindow();
return (
<ProcessOutputSourcesWindow
isOpen={isOpen}
onClose={onClose}
dimensions={dimensions}
onSuccess={onClose}
onError={onClose}
selectedProcessOutputSources={ProcessOutputSourcesEmpty()}>
</ProcessOutputSourcesWindow>
)
};
export default ProcessOutputSourcesWindow;