//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { ProcessosEmpty } from '../../../Models/Processos';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IProcessos } from '../../Interfaces/interface.Processos';
import { ProcessosService } from '../../Services/Processos.service';
import { ProcessosApi } from '../../Apis/ApiProcessos';
import { ProcessosGridMobileComponent } from '../GridsMobile/Processos';
import { ProcessosGridDesktopComponent } from '../GridsDesktop/Processos';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterProcessos } from '../../Filters/Processos';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import ProcessosWindow from './ProcessosWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useProcessosList } from '../../Hooks/hookProcessos';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const ProcessosGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const processosService = useMemo(() => {
    return new ProcessosService(
    new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: processos, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useProcessosList(processosService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedProcessos, setSelectedProcessos] = useState<IProcessos>(ProcessosEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterProcessos | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterProcessos | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterProcessos);
};
// Handlers para o grid
const handleRowClick = (processos: IProcessos) => {
  setSelectedProcessos(processos);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedProcessos(ProcessosEmpty());
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
  const processos = e.dataItem;
  setDeleteId(processos.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await processosService.deleteProcessos(deleteId);
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
    <ProcessosGridMobileComponent
    data={processos}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <ProcessosGridDesktopComponent
    data={processos}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <ProcessosWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedProcessos={selectedProcessos}
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
export default ProcessosGrid;