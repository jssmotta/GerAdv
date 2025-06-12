//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { ProcessOutputRequestEmpty } from '../../../Models/ProcessOutputRequest';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IProcessOutputRequest } from '../../Interfaces/interface.ProcessOutputRequest';
import { ProcessOutputRequestService } from '../../Services/ProcessOutputRequest.service';
import { ProcessOutputRequestApi } from '../../Apis/ApiProcessOutputRequest';
import { ProcessOutputRequestGridMobileComponent } from '../GridsMobile/ProcessOutputRequest';
import { ProcessOutputRequestGridDesktopComponent } from '../GridsDesktop/ProcessOutputRequest';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterProcessOutputRequest } from '../../Filters/ProcessOutputRequest';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import ProcessOutputRequestWindow from './ProcessOutputRequestWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useProcessOutputRequestList } from '../../Hooks/hookProcessOutputRequest';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const ProcessOutputRequestGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const processoutputrequestService = useMemo(() => {
    return new ProcessOutputRequestService(
    new ProcessOutputRequestApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: processoutputrequest, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useProcessOutputRequestList(processoutputrequestService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedProcessOutputRequest, setSelectedProcessOutputRequest] = useState<IProcessOutputRequest>(ProcessOutputRequestEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterProcessOutputRequest | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterProcessOutputRequest | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterProcessOutputRequest);
};
// Handlers para o grid
const handleRowClick = (processoutputrequest: IProcessOutputRequest) => {
  setSelectedProcessOutputRequest(processoutputrequest);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedProcessOutputRequest(ProcessOutputRequestEmpty());
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
  const processoutputrequest = e.dataItem;
  setDeleteId(processoutputrequest.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await processoutputrequestService.deleteProcessOutputRequest(deleteId);
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
    <ProcessOutputRequestGridMobileComponent
    data={processoutputrequest}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <ProcessOutputRequestGridDesktopComponent
    data={processoutputrequest}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <ProcessOutputRequestWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedProcessOutputRequest={selectedProcessOutputRequest}
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
export default ProcessOutputRequestGrid;