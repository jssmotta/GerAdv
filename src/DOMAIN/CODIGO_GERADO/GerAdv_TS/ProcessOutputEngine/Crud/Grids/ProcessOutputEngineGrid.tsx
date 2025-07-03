//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { ProcessOutputEngineEmpty } from '../../../Models/ProcessOutputEngine';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IProcessOutputEngine } from '../../Interfaces/interface.ProcessOutputEngine';
import { ProcessOutputEngineService } from '../../Services/ProcessOutputEngine.service';
import { ProcessOutputEngineApi } from '../../Apis/ApiProcessOutputEngine';
import { ProcessOutputEngineGridMobileComponent } from '../GridsMobile/ProcessOutputEngine';
import { ProcessOutputEngineGridDesktopComponent } from '../GridsDesktop/ProcessOutputEngine';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterProcessOutputEngine } from '../../Filters/ProcessOutputEngine';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import ProcessOutputEngineWindow from './ProcessOutputEngineWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useProcessOutputEngineList } from '../../Hooks/hookProcessOutputEngine';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const ProcessOutputEngineGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const processoutputengineService = useMemo(() => {
    return new ProcessOutputEngineService(
    new ProcessOutputEngineApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: processoutputengine, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useProcessOutputEngineList(processoutputengineService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedProcessOutputEngine, setSelectedProcessOutputEngine] = useState<IProcessOutputEngine>(ProcessOutputEngineEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterProcessOutputEngine | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterProcessOutputEngine | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterProcessOutputEngine);
};
// Handlers para o grid
const handleRowClick = (processoutputengine: IProcessOutputEngine) => {
  setSelectedProcessOutputEngine(processoutputengine);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedProcessOutputEngine(ProcessOutputEngineEmpty());
  setShowInc(true);
};
const handleClose = () => {
  setShowInc(false);
};
const handleSuccess = () => {
  setShowInc(false);
  // O hook já escuta as notificações e recarrega automaticamente
};
const handleError = () => {
  setShowInc(false);
};
// Handlers para exclusão
const onDeleteClick = (e: any) => {
  const processoutputengine = e.dataItem;
  setDeleteId(processoutputengine.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await processoutputengineService.deleteProcessOutputEngine(deleteId);
      // O hook já escuta as notificações e recarrega automaticamente
    } catch (error) {
    console.error('Erro ao excluir:', error);
    setErrorMessage('Erro ao excluir o registro. Verifique se ele não está vinculado a outros registros.');
  } finally {
  setDeleteId(null);
  setIsModalOpen(false);
}
}
};
const cancelDelete = () => {
  setDeleteId(null);
  setIsModalOpen(false);
};
// Combinar erro do hook com erro local
const displayError = error || errorMessage;
useEffect(() => {
  const unsubscribe = subscribeToNotifications('*', (entity) => {
    if (entity.action == NotifySystemActions.ERROR) {
      return;
    }
    reloadFilter();
  });
  return () => {
    unsubscribe();
  };
}, []);
return (
<>
<AppGridToolbar onAdd={handleAdd} />
{loading && (
  <LoadingSpinner />
  )}
  {isMobile ? (
    <ProcessOutputEngineGridMobileComponent
    data={processoutputengine}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <ProcessOutputEngineGridDesktopComponent
    data={processoutputengine}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <ProcessOutputEngineWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedProcessOutputEngine={selectedProcessOutputEngine}
    />

    <ConfirmationModal
    isOpen={isModalOpen}
    onConfirm={confirmDelete}
    onCancel={cancelDelete}
    message={`Deseja realmente excluir o registro?`}
    />
    <ErrorMessage
    mensagem={displayError}
    setErrorMessage={setErrorMessage}
    />
  </>
);
};
export default ProcessOutputEngineGrid;