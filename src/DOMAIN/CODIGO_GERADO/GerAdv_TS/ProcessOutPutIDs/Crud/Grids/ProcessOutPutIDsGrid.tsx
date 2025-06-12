//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { ProcessOutPutIDsEmpty } from '../../../Models/ProcessOutPutIDs';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IProcessOutPutIDs } from '../../Interfaces/interface.ProcessOutPutIDs';
import { ProcessOutPutIDsService } from '../../Services/ProcessOutPutIDs.service';
import { ProcessOutPutIDsApi } from '../../Apis/ApiProcessOutPutIDs';
import { ProcessOutPutIDsGridMobileComponent } from '../GridsMobile/ProcessOutPutIDs';
import { ProcessOutPutIDsGridDesktopComponent } from '../GridsDesktop/ProcessOutPutIDs';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterProcessOutPutIDs } from '../../Filters/ProcessOutPutIDs';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import ProcessOutPutIDsWindow from './ProcessOutPutIDsWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useProcessOutPutIDsList } from '../../Hooks/hookProcessOutPutIDs';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const ProcessOutPutIDsGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const processoutputidsService = useMemo(() => {
    return new ProcessOutPutIDsService(
    new ProcessOutPutIDsApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: processoutputids, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useProcessOutPutIDsList(processoutputidsService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedProcessOutPutIDs, setSelectedProcessOutPutIDs] = useState<IProcessOutPutIDs>(ProcessOutPutIDsEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterProcessOutPutIDs | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterProcessOutPutIDs | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterProcessOutPutIDs);
};
// Handlers para o grid
const handleRowClick = (processoutputids: IProcessOutPutIDs) => {
  setSelectedProcessOutPutIDs(processoutputids);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedProcessOutPutIDs(ProcessOutPutIDsEmpty());
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
  const processoutputids = e.dataItem;
  setDeleteId(processoutputids.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await processoutputidsService.deleteProcessOutPutIDs(deleteId);
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
    <ProcessOutPutIDsGridMobileComponent
    data={processoutputids}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <ProcessOutPutIDsGridDesktopComponent
    data={processoutputids}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <ProcessOutPutIDsWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedProcessOutPutIDs={selectedProcessOutPutIDs}
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
export default ProcessOutPutIDsGrid;