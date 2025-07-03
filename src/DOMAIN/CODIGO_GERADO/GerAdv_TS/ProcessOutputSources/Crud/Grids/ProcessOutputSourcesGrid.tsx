//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { ProcessOutputSourcesEmpty } from '../../../Models/ProcessOutputSources';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IProcessOutputSources } from '../../Interfaces/interface.ProcessOutputSources';
import { ProcessOutputSourcesService } from '../../Services/ProcessOutputSources.service';
import { ProcessOutputSourcesApi } from '../../Apis/ApiProcessOutputSources';
import { ProcessOutputSourcesGridMobileComponent } from '../GridsMobile/ProcessOutputSources';
import { ProcessOutputSourcesGridDesktopComponent } from '../GridsDesktop/ProcessOutputSources';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterProcessOutputSources } from '../../Filters/ProcessOutputSources';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import ProcessOutputSourcesWindow from './ProcessOutputSourcesWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useProcessOutputSourcesList } from '../../Hooks/hookProcessOutputSources';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const ProcessOutputSourcesGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const processoutputsourcesService = useMemo(() => {
    return new ProcessOutputSourcesService(
    new ProcessOutputSourcesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: processoutputsources, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useProcessOutputSourcesList(processoutputsourcesService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedProcessOutputSources, setSelectedProcessOutputSources] = useState<IProcessOutputSources>(ProcessOutputSourcesEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterProcessOutputSources | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterProcessOutputSources | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterProcessOutputSources);
};
// Handlers para o grid
const handleRowClick = (processoutputsources: IProcessOutputSources) => {
  setSelectedProcessOutputSources(processoutputsources);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedProcessOutputSources(ProcessOutputSourcesEmpty());
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
  const processoutputsources = e.dataItem;
  setDeleteId(processoutputsources.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await processoutputsourcesService.deleteProcessOutputSources(deleteId);
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
    <ProcessOutputSourcesGridMobileComponent
    data={processoutputsources}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <ProcessOutputSourcesGridDesktopComponent
    data={processoutputsources}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <ProcessOutputSourcesWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedProcessOutputSources={selectedProcessOutputSources}
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
export default ProcessOutputSourcesGrid;